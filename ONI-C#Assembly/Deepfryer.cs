﻿// Decompiled with JetBrains decompiler
// Type: Deepfryer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class Deepfryer : ComplexFabricator, IGameObjectEffectDescriptor
{
  [SerializeField]
  private int diseaseCountKillRate = 100;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.choreType = Db.Get().ChoreTypes.Cook;
    this.fetchChoreTypeIdHash = Db.Get().ChoreTypes.CookFetch.IdHash;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.workable.requiredSkillPerk = Db.Get().SkillPerks.CanDeepFry.Id;
    this.workable.WorkerStatusItem = Db.Get().DuplicantStatusItems.Cooking;
    this.workable.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_deepfryer_kanim")
    };
    this.workable.AttributeConverter = Db.Get().AttributeConverters.CookingSpeed;
    this.workable.AttributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.MOST_DAY_EXPERIENCE;
    this.workable.SkillExperienceSkillGroup = Db.Get().SkillGroups.Cooking.Id;
    this.workable.SkillExperienceMultiplier = SKILLS.MOST_DAY_EXPERIENCE;
    this.workable.OnWorkTickActions += (Action<WorkerBase, float>) ((worker, dt) =>
    {
      Debug.Assert((UnityEngine.Object) worker != (UnityEngine.Object) null, (object) "How did we get a null worker?");
      if (this.diseaseCountKillRate <= 0)
        return;
      this.GetComponent<PrimaryElement>().ModifyDiseaseCount(-Math.Max(1, (int) ((double) this.diseaseCountKillRate * (double) dt)), nameof (Deepfryer));
    });
    this.GetComponent<ComplexFabricator>().workingStatusItem = Db.Get().BuildingStatusItems.ComplexFabricatorCooking;
  }

  protected override List<GameObject> SpawnOrderProduct(ComplexRecipe recipe)
  {
    List<GameObject> gameObjectList = base.SpawnOrderProduct(recipe);
    foreach (GameObject gameObject in gameObjectList)
    {
      PrimaryElement component = gameObject.GetComponent<PrimaryElement>();
      component.ModifyDiseaseCount(-component.DiseaseCount, "Deepfryer.CompleteOrder");
    }
    this.GetComponent<Operational>().SetActive(false);
    return gameObjectList;
  }

  public override List<Descriptor> GetDescriptors(GameObject go)
  {
    List<Descriptor> descriptors = base.GetDescriptors(go);
    descriptors.Add(new Descriptor((string) UI.BUILDINGEFFECTS.REMOVES_DISEASE, (string) UI.BUILDINGEFFECTS.TOOLTIPS.REMOVES_DISEASE));
    return descriptors;
  }
}
