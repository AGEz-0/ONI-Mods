﻿// Decompiled with JetBrains decompiler
// Type: AdvancedApothecary
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;

#nullable disable
public class AdvancedApothecary : ComplexFabricator
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.choreType = Db.Get().ChoreTypes.Compound;
    this.fetchChoreTypeIdHash = Db.Get().ChoreTypes.DoctorFetch.IdHash;
    this.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.workable.WorkerStatusItem = Db.Get().DuplicantStatusItems.Fabricating;
    this.workable.AttributeConverter = Db.Get().AttributeConverters.CompoundingSpeed;
    this.workable.SkillExperienceSkillGroup = Db.Get().SkillGroups.MedicalAid.Id;
    this.workable.SkillExperienceMultiplier = SKILLS.PART_DAY_EXPERIENCE;
    this.workable.requiredSkillPerk = Db.Get().SkillPerks.CanCompound.Id;
    this.workable.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_medicine_nuclear_kanim")
    };
  }
}
