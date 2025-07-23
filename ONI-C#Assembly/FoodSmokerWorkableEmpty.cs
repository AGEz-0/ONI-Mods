// Decompiled with JetBrains decompiler
// Type: FoodSmokerWorkableEmpty
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;

#nullable disable
public class FoodSmokerWorkableEmpty : Workable
{
  private static readonly HashedString[] WORK_ANIMS = new HashedString[2]
  {
    (HashedString) "empty_pre",
    (HashedString) "empty_loop"
  };
  private static readonly HashedString[] WORK_ANIMS_PST = new HashedString[1]
  {
    (HashedString) "empty_pst"
  };
  private static readonly HashedString[] WORK_ANIMS_FAIL_PST = new HashedString[1]
  {
    (HashedString) ""
  };

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Emptying;
    this.workAnims = FoodSmokerWorkableEmpty.WORK_ANIMS;
    this.workingPstComplete = FoodSmokerWorkableEmpty.WORK_ANIMS_PST;
    this.workingPstFailed = FoodSmokerWorkableEmpty.WORK_ANIMS_FAIL_PST;
    this.requiredSkillPerk = Db.Get().SkillPerks.CanGasRange.Id;
    this.attributeConverter = Db.Get().AttributeConverters.CookingSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.FULL_EXPERIENCE;
    this.skillExperienceSkillGroup = Db.Get().SkillGroups.Cooking.Id;
    this.skillExperienceMultiplier = SKILLS.FULL_EXPERIENCE;
  }
}
