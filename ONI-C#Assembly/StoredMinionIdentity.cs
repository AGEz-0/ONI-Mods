﻿// Decompiled with JetBrains decompiler
// Type: StoredMinionIdentity
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using Klei.AI;
using KSerialization;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
[AddComponentMenu("KMonoBehaviour/scripts/StoredMinionIdentity")]
public class StoredMinionIdentity : 
  KMonoBehaviour,
  ISaveLoadable,
  IAssignableIdentity,
  IListableOption,
  IPersonalPriorityManager
{
  [Serialize]
  public string storedName;
  [Serialize]
  public Tag model;
  [Serialize]
  public string gender;
  [Serialize]
  [ReadOnly]
  public float arrivalTime;
  [Serialize]
  public int voiceIdx;
  [Serialize]
  public KCompBuilder.BodyData bodyData;
  [Serialize]
  public List<Ref<KPrefabID>> assignedItems;
  [Serialize]
  public List<Ref<KPrefabID>> equippedItems;
  [Serialize]
  public List<string> traitIDs;
  [Serialize]
  public List<ResourceRef<Accessory>> accessories;
  [Obsolete("Deprecated, use customClothingItems")]
  [Serialize]
  public List<ResourceRef<ClothingItemResource>> clothingItems = new List<ResourceRef<ClothingItemResource>>();
  [Serialize]
  public Dictionary<ClothingOutfitUtility.OutfitType, List<ResourceRef<ClothingItemResource>>> customClothingItems = new Dictionary<ClothingOutfitUtility.OutfitType, List<ResourceRef<ClothingItemResource>>>();
  [Serialize]
  public Dictionary<WearableAccessorizer.WearableType, WearableAccessorizer.Wearable> wearables = new Dictionary<WearableAccessorizer.WearableType, WearableAccessorizer.Wearable>();
  [Obsolete("Deprecated, use forbiddenTagSet")]
  [Serialize]
  public List<Tag> forbiddenTags;
  [Serialize]
  public HashSet<Tag> forbiddenTagSet;
  [Serialize]
  public Ref<MinionAssignablesProxy> assignableProxy;
  [Serialize]
  public List<Effects.SaveLoadEffect> saveLoadEffects;
  [Serialize]
  public List<Effects.SaveLoadImmunities> saveLoadImmunities;
  [Serialize]
  public Dictionary<string, bool> MasteryByRoleID = new Dictionary<string, bool>();
  [Serialize]
  public Dictionary<string, bool> MasteryBySkillID = new Dictionary<string, bool>();
  [Serialize]
  public List<string> grantedSkillIDs = new List<string>();
  [Serialize]
  public Dictionary<HashedString, float> AptitudeByRoleGroup = new Dictionary<HashedString, float>();
  [Serialize]
  public Dictionary<HashedString, float> AptitudeBySkillGroup = new Dictionary<HashedString, float>();
  [Serialize]
  public float TotalExperienceGained;
  [Serialize]
  public string currentHat;
  [Serialize]
  public string targetHat;
  [Serialize]
  public Dictionary<HashedString, ChoreConsumer.PriorityInfo> choreGroupPriorities = new Dictionary<HashedString, ChoreConsumer.PriorityInfo>();
  [Serialize]
  public List<AttributeLevels.LevelSaveLoad> attributeLevels;
  [Serialize]
  public Dictionary<string, float> savedAttributeValues;
  public MinionModifiers minionModifiers;

  [Serialize]
  public string genderStringKey { get; set; }

  [Serialize]
  public string nameStringKey { get; set; }

  [Serialize]
  public HashedString personalityResourceId { get; set; }

  [OnDeserialized]
  [Obsolete]
  private void OnDeserializedMethod()
  {
    if (SaveLoader.Instance.GameInfo.IsVersionOlderThan(7, 7))
    {
      int current_skill_points = 0;
      foreach (KeyValuePair<string, bool> keyValuePair in this.MasteryByRoleID)
      {
        if (keyValuePair.Value && keyValuePair.Key != "NoRole")
          ++current_skill_points;
      }
      this.TotalExperienceGained = MinionResume.CalculatePreviousExperienceBar(current_skill_points);
      foreach (KeyValuePair<HashedString, float> keyValuePair in this.AptitudeByRoleGroup)
        this.AptitudeBySkillGroup[keyValuePair.Key] = keyValuePair.Value;
    }
    if (SaveLoader.Instance.GameInfo.IsVersionOlderThan(7, 29))
    {
      this.forbiddenTagSet = new HashSet<Tag>((IEnumerable<Tag>) this.forbiddenTags);
      this.forbiddenTags = (List<Tag>) null;
    }
    if (!this.model.IsValid)
      this.model = MinionConfig.MODEL;
    if (SaveLoader.Instance.GameInfo.IsVersionOlderThan(7, 30))
      this.bodyData = Accessorizer.UpdateAccessorySlots(this.nameStringKey, ref this.accessories);
    if (this.clothingItems.Count > 0)
    {
      this.customClothingItems[ClothingOutfitUtility.OutfitType.Clothing] = new List<ResourceRef<ClothingItemResource>>((IEnumerable<ResourceRef<ClothingItemResource>>) this.clothingItems);
      this.clothingItems.Clear();
    }
    List<ResourceRef<Accessory>> all = this.accessories.FindAll((Predicate<ResourceRef<Accessory>>) (acc => acc.Get() == null));
    if (all.Count > 0)
    {
      List<ClothingItemResource> clothingItemResourceList = new List<ClothingItemResource>();
      foreach (ResourceRef<Accessory> resourceRef in all)
      {
        ClothingItemResource resource = Db.Get().Permits.ClothingItems.TryResolveAccessoryResource(resourceRef.Guid);
        if (resource != null && !clothingItemResourceList.Contains(resource))
        {
          clothingItemResourceList.Add(resource);
          this.customClothingItems[ClothingOutfitUtility.OutfitType.Clothing].Add(new ResourceRef<ClothingItemResource>(resource));
        }
      }
      this.bodyData = Accessorizer.UpdateAccessorySlots(this.nameStringKey, ref this.accessories);
    }
    this.OnDeserializeModifiers();
  }

  public bool HasPerk(SkillPerk perk)
  {
    foreach (KeyValuePair<string, bool> keyValuePair in this.MasteryBySkillID)
    {
      if (keyValuePair.Value && Db.Get().Skills.Get(keyValuePair.Key).perks.Contains(perk))
        return true;
    }
    return false;
  }

  public bool HasMasteredSkill(string skillId)
  {
    return this.MasteryBySkillID.ContainsKey(skillId) && this.MasteryBySkillID[skillId];
  }

  protected override void OnPrefabInit()
  {
    this.assignableProxy = new Ref<MinionAssignablesProxy>();
    this.minionModifiers = this.GetComponent<MinionModifiers>();
    this.savedAttributeValues = new Dictionary<string, float>();
  }

  [OnSerializing]
  private void OnSerialize()
  {
    this.savedAttributeValues.Clear();
    foreach (AttributeInstance attribute in this.minionModifiers.attributes)
      this.savedAttributeValues.Add(attribute.Attribute.Id, attribute.GetTotalValue());
  }

  protected override void OnSpawn()
  {
    string[] attributes = MinionConfig.GetAttributes();
    string[] amounts = MinionConfig.GetAmounts();
    AttributeModifier[] traits = MinionConfig.GetTraits();
    if (this.model == BionicMinionConfig.MODEL)
    {
      attributes = BionicMinionConfig.GetAttributes();
      amounts = BionicMinionConfig.GetAmounts();
      traits = BionicMinionConfig.GetTraits();
    }
    BaseMinionConfig.AddMinionAttributes((Modifiers) this.minionModifiers, attributes);
    BaseMinionConfig.AddMinionAmounts((Modifiers) this.minionModifiers, amounts);
    BaseMinionConfig.AddMinionTraits(BaseMinionConfig.GetMinionNameForModel(this.model), BaseMinionConfig.GetMinionBaseTraitIDForModel(this.model), (Modifiers) this.minionModifiers, traits);
    this.ValidateProxy();
    this.CleanupLimboMinions();
  }

  public void OnHardDelete()
  {
    if ((UnityEngine.Object) this.assignableProxy.Get() != (UnityEngine.Object) null)
      Util.KDestroyGameObject(this.assignableProxy.Get().gameObject);
    ScheduleManager.Instance.OnStoredDupeDestroyed(this);
    Components.StoredMinionIdentities.Remove(this);
  }

  private void OnDeserializeModifiers()
  {
    foreach (KeyValuePair<string, float> savedAttributeValue in this.savedAttributeValues)
    {
      Klei.AI.Attribute attribute = Db.Get().Attributes.TryGet(savedAttributeValue.Key) ?? Db.Get().BuildingAttributes.TryGet(savedAttributeValue.Key);
      if (attribute != null)
      {
        if (this.minionModifiers.attributes.Get(attribute.Id) != null)
        {
          this.minionModifiers.attributes.Get(attribute.Id).Modifiers.Clear();
          this.minionModifiers.attributes.Get(attribute.Id).ClearModifiers();
        }
        else
          this.minionModifiers.attributes.Add(attribute);
        this.minionModifiers.attributes.Add(new AttributeModifier(attribute.Id, savedAttributeValue.Value, (Func<string>) (() => (string) DUPLICANTS.ATTRIBUTES.STORED_VALUE)));
      }
    }
  }

  public void ValidateProxy()
  {
    this.assignableProxy = MinionAssignablesProxy.InitAssignableProxy(this.assignableProxy, (IAssignableIdentity) this);
  }

  public string[] GetClothingItemIds(ClothingOutfitUtility.OutfitType outfitType)
  {
    if (!this.customClothingItems.ContainsKey(outfitType))
      return (string[]) null;
    string[] clothingItemIds = new string[this.customClothingItems[outfitType].Count];
    for (int index = 0; index < this.customClothingItems[outfitType].Count; ++index)
      clothingItemIds[index] = this.customClothingItems[outfitType][index].Get().Id;
    return clothingItemIds;
  }

  private void CleanupLimboMinions()
  {
    KPrefabID component = this.GetComponent<KPrefabID>();
    bool flag1 = false;
    if (component.InstanceID == -1)
    {
      DebugUtil.LogWarningArgs((object) "Stored minion with an invalid kpid! Attempting to recover...", (object) this.storedName);
      flag1 = true;
      if ((UnityEngine.Object) KPrefabIDTracker.Get().GetInstance(component.InstanceID) != (UnityEngine.Object) null)
        KPrefabIDTracker.Get().Unregister(component);
      component.InstanceID = KPrefabID.GetUniqueID();
      KPrefabIDTracker.Get().Register(component);
      DebugUtil.LogWarningArgs((object) "Restored as:", (object) component.InstanceID);
    }
    if (component.conflicted)
    {
      DebugUtil.LogWarningArgs((object) "Minion with a conflicted kpid! Attempting to recover... ", (object) component.InstanceID, (object) this.storedName);
      if ((UnityEngine.Object) KPrefabIDTracker.Get().GetInstance(component.InstanceID) != (UnityEngine.Object) null)
        KPrefabIDTracker.Get().Unregister(component);
      component.InstanceID = KPrefabID.GetUniqueID();
      KPrefabIDTracker.Get().Register(component);
      DebugUtil.LogWarningArgs((object) "Restored as:", (object) component.InstanceID);
    }
    this.assignableProxy.Get().SetTarget((IAssignableIdentity) this, this.gameObject);
    bool flag2 = false;
    foreach (MinionStorage minionStorage in Components.MinionStorages.Items)
    {
      List<MinionStorage.Info> storedMinionInfo = minionStorage.GetStoredMinionInfo();
      for (int index = 0; index < storedMinionInfo.Count; ++index)
      {
        MinionStorage.Info info = storedMinionInfo[index];
        if (flag1 && info.serializedMinion != null && info.serializedMinion.GetId() == -1 && info.name == this.storedName)
        {
          DebugUtil.LogWarningArgs((object) "Found a minion storage with an invalid ref, rebinding.", (object) component.InstanceID, (object) this.storedName, (object) minionStorage.gameObject.name);
          info = new MinionStorage.Info(this.storedName, new Ref<KPrefabID>(component));
          storedMinionInfo[index] = info;
          minionStorage.GetComponent<Assignable>().Assign((IAssignableIdentity) this);
          flag2 = true;
          break;
        }
        if (info.serializedMinion != null && (UnityEngine.Object) info.serializedMinion.Get() == (UnityEngine.Object) component)
        {
          flag2 = true;
          break;
        }
      }
      if (flag2)
        break;
    }
    if (flag2)
      return;
    DebugUtil.LogWarningArgs((object) "Found a stored minion that wasn't in any minion storage. Respawning them at the portal.", (object) component.InstanceID, (object) this.storedName);
    GameObject activeTelepad = GameUtil.GetActiveTelepad();
    if (!((UnityEngine.Object) activeTelepad != (UnityEngine.Object) null))
      return;
    MinionStorage.DeserializeMinion(component.gameObject, activeTelepad.transform.GetPosition());
  }

  public string GetProperName() => this.storedName;

  public List<Ownables> GetOwners() => this.assignableProxy.Get().ownables;

  public Ownables GetSoleOwner() => this.assignableProxy.Get().GetComponent<Ownables>();

  public bool HasOwner(Assignables owner) => this.GetOwners().Contains(owner as Ownables);

  public int NumOwners() => this.GetOwners().Count;

  public Accessory GetAccessory(AccessorySlot slot)
  {
    for (int index = 0; index < this.accessories.Count; ++index)
    {
      if (this.accessories[index].Get() != null && this.accessories[index].Get().slot == slot)
        return this.accessories[index].Get();
    }
    return (Accessory) null;
  }

  public bool IsNull() => (UnityEngine.Object) this == (UnityEngine.Object) null;

  public string GetStorageReason()
  {
    KPrefabID component = this.GetComponent<KPrefabID>();
    foreach (MinionStorage cmp in Components.MinionStorages.Items)
    {
      foreach (MinionStorage.Info info in cmp.GetStoredMinionInfo())
      {
        if ((UnityEngine.Object) info.serializedMinion.Get() == (UnityEngine.Object) component)
          return cmp.GetProperName();
      }
    }
    return "";
  }

  public bool IsPermittedToConsume(string consumable)
  {
    return !this.forbiddenTagSet.Contains((Tag) consumable);
  }

  public bool IsChoreGroupDisabled(ChoreGroup chore_group)
  {
    foreach (string traitId in this.traitIDs)
    {
      if (Db.Get().traits.Exists(traitId))
      {
        Trait trait = Db.Get().traits.Get(traitId);
        if (trait.disabledChoreGroups != null)
        {
          foreach (Resource disabledChoreGroup in trait.disabledChoreGroups)
          {
            if (disabledChoreGroup.IdHash == chore_group.IdHash)
              return true;
          }
        }
      }
    }
    return false;
  }

  public int GetPersonalPriority(ChoreGroup chore_group)
  {
    ChoreConsumer.PriorityInfo priorityInfo;
    return this.choreGroupPriorities.TryGetValue(chore_group.IdHash, out priorityInfo) ? priorityInfo.priority : 0;
  }

  public int GetAssociatedSkillLevel(ChoreGroup group) => 0;

  public void SetPersonalPriority(ChoreGroup group, int value)
  {
  }

  public void ResetPersonalPriorities()
  {
  }

  public interface IStoredMinionExtension
  {
    void PushTo(StoredMinionIdentity destination);

    void PullFrom(StoredMinionIdentity source);

    void AddStoredMinionGameObjectRequirements(GameObject storedMinionGameObject);
  }
}
