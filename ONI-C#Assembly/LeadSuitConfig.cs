﻿// Decompiled with JetBrains decompiler
// Type: LeadSuitConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class LeadSuitConfig : IEquipmentConfig, IHasDlcRestrictions
{
  public const string ID = "Lead_Suit";
  public const string WORN_ID = "Worn_Lead_Suit";
  public static ComplexRecipe recipe;
  private const PathFinder.PotentialPath.Flags suit_flags = PathFinder.PotentialPath.Flags.HasLeadSuit;
  private AttributeModifier expertAthleticsModifier;

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public EquipmentDef CreateEquipmentDef()
  {
    List<AttributeModifier> AttributeModifiers = new List<AttributeModifier>();
    AttributeModifiers.Add(new AttributeModifier(TUNING.EQUIPMENT.ATTRIBUTE_MOD_IDS.ATHLETICS, (float) TUNING.EQUIPMENT.SUITS.LEADSUIT_ATHLETICS, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.NAME));
    AttributeModifiers.Add(new AttributeModifier(Db.Get().Attributes.ScaldingThreshold.Id, (float) TUNING.EQUIPMENT.SUITS.LEADSUIT_SCALDING, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.NAME));
    AttributeModifiers.Add(new AttributeModifier(Db.Get().Attributes.ScoldingThreshold.Id, (float) TUNING.EQUIPMENT.SUITS.LEADSUIT_SCOLDING, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.NAME));
    AttributeModifiers.Add(new AttributeModifier(Db.Get().Attributes.RadiationResistance.Id, TUNING.EQUIPMENT.SUITS.LEADSUIT_RADIATION_SHIELDING, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.NAME));
    AttributeModifiers.Add(new AttributeModifier(Db.Get().Attributes.Strength.Id, (float) TUNING.EQUIPMENT.SUITS.LEADSUIT_STRENGTH, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.NAME));
    AttributeModifiers.Add(new AttributeModifier(TUNING.EQUIPMENT.ATTRIBUTE_MOD_IDS.INSULATION, (float) TUNING.EQUIPMENT.SUITS.LEADSUIT_INSULATION, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.NAME));
    AttributeModifiers.Add(new AttributeModifier(TUNING.EQUIPMENT.ATTRIBUTE_MOD_IDS.THERMAL_CONDUCTIVITY_BARRIER, TUNING.EQUIPMENT.SUITS.LEADSUIT_THERMAL_CONDUCTIVITY_BARRIER, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.NAME));
    this.expertAthleticsModifier = new AttributeModifier(TUNING.EQUIPMENT.ATTRIBUTE_MOD_IDS.ATHLETICS, (float) -TUNING.EQUIPMENT.SUITS.ATMOSUIT_ATHLETICS, Db.Get().Skills.Suits1.Name);
    EquipmentDef equipmentDef = EquipmentTemplates.CreateEquipmentDef("Lead_Suit", TUNING.EQUIPMENT.SUITS.SLOT, SimHashes.Dirt, (float) TUNING.EQUIPMENT.SUITS.ATMOSUIT_MASS, "suit_leadsuit_kanim", "", "body_leadsuit_kanim", 6, AttributeModifiers, IsBody: true, additional_tags: new Tag[2]
    {
      GameTags.Suit,
      GameTags.Clothes
    });
    equipmentDef.wornID = "Worn_Lead_Suit";
    equipmentDef.RecipeDescription = (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.RECIPE_DESC;
    equipmentDef.EffectImmunites.Add(Db.Get().effects.Get("SoakingWet"));
    equipmentDef.EffectImmunites.Add(Db.Get().effects.Get("WetFeet"));
    equipmentDef.EffectImmunites.Add(Db.Get().effects.Get("ColdAir"));
    equipmentDef.EffectImmunites.Add(Db.Get().effects.Get("WarmAir"));
    equipmentDef.EffectImmunites.Add(Db.Get().effects.Get("PoppedEarDrums"));
    equipmentDef.EffectImmunites.Add(Db.Get().effects.Get("RecentlySlippedTracker"));
    equipmentDef.OnEquipCallBack = (Action<Equippable>) (eq =>
    {
      Ownables soleOwner = eq.assignee.GetSoleOwner();
      if (!((UnityEngine.Object) soleOwner != (UnityEngine.Object) null))
        return;
      GameObject targetGameObject = soleOwner.GetComponent<MinionAssignablesProxy>().GetTargetGameObject();
      Navigator component1 = targetGameObject.GetComponent<Navigator>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        component1.SetFlags(PathFinder.PotentialPath.Flags.HasLeadSuit);
      MinionResume component2 = targetGameObject.GetComponent<MinionResume>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.HasPerk((HashedString) Db.Get().SkillPerks.ExosuitExpertise.Id))
        targetGameObject.GetAttributes().Get(Db.Get().Attributes.Athletics).Add(this.expertAthleticsModifier);
      targetGameObject.AddTag(GameTags.HasAirtightSuit);
    });
    equipmentDef.OnUnequipCallBack = (Action<Equippable>) (eq =>
    {
      if (eq.assignee == null)
        return;
      Ownables soleOwner = eq.assignee.GetSoleOwner();
      if (!((UnityEngine.Object) soleOwner != (UnityEngine.Object) null))
        return;
      GameObject targetGameObject = soleOwner.GetComponent<MinionAssignablesProxy>().GetTargetGameObject();
      if ((bool) (UnityEngine.Object) targetGameObject)
      {
        targetGameObject.GetAttributes()?.Get(Db.Get().Attributes.Athletics).Remove(this.expertAthleticsModifier);
        Navigator component3 = targetGameObject.GetComponent<Navigator>();
        if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
          component3.ClearFlags(PathFinder.PotentialPath.Flags.HasLeadSuit);
        Effects component4 = targetGameObject.GetComponent<Effects>();
        if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && component4.HasEffect("SoiledSuit"))
          component4.Remove("SoiledSuit");
        targetGameObject.RemoveTag(GameTags.HasAirtightSuit);
      }
      Tag elementTag = eq.GetComponent<SuitTank>().elementTag;
      eq.GetComponent<Storage>().DropUnlessHasTag(elementTag);
    });
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SuitIDs, "Lead_Suit");
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SuitIDs, "Helmet");
    return equipmentDef;
  }

  public void DoPostConfigure(GameObject go)
  {
    SuitTank suitTank = go.AddComponent<SuitTank>();
    suitTank.element = "Oxygen";
    suitTank.capacity = DUPLICANTSTATS.STANDARD.BaseStats.OXYGEN_USED_PER_SECOND * 400f;
    suitTank.elementTag = GameTags.Breathable;
    suitTank.SafeCellFlagsToIgnoreOnEquipped = SafeCellQuery.SafeFlags.CorrectTemperature | SafeCellQuery.SafeFlags.IsNotRadiated | SafeCellQuery.SafeFlags.IsBreathable | SafeCellQuery.SafeFlags.IsNotLiquidOnMyFace | SafeCellQuery.SafeFlags.IsNotLiquid;
    go.AddComponent<LeadSuitTank>().batteryDuration = 200f;
    go.AddComponent<HelmetController>();
    KPrefabID component = go.GetComponent<KPrefabID>();
    component.AddTag(GameTags.Clothes);
    component.AddTag(GameTags.PedestalDisplayable);
    component.AddTag(GameTags.AirtightSuit);
    Durability durability = go.AddComponent<Durability>();
    durability.wornEquipmentPrefabID = "Worn_Lead_Suit";
    durability.durabilityLossPerCycle = TUNING.EQUIPMENT.SUITS.ATMOSUIT_DECAY;
    Storage storage = go.AddOrGet<Storage>();
    storage.SetDefaultStoredItemModifiers(Storage.StandardInsulatedStorage);
    storage.showInUI = true;
    go.AddOrGet<AtmoSuit>();
    go.AddComponent<SuitDiseaseHandler>();
  }
}
