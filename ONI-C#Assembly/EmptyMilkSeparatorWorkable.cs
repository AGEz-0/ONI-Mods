// Decompiled with JetBrains decompiler
// Type: EmptyMilkSeparatorWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;

#nullable disable
public class EmptyMilkSeparatorWorkable : Workable
{
  public System.Action OnWork_PST_Begins;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workLayer = Grid.SceneLayer.BuildingFront;
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Cleaning;
    this.workingStatusItem = Db.Get().MiscStatusItems.Cleaning;
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_milk_separator_kanim")
    };
    this.attributeConverter = Db.Get().AttributeConverters.TidyingSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.PART_DAY_EXPERIENCE;
    this.skillExperienceMultiplier = SKILLS.PART_DAY_EXPERIENCE;
    this.SetWorkTime(15f);
    this.synchronizeAnims = true;
  }

  public override void OnPendingCompleteWork(WorkerBase worker)
  {
    System.Action onWorkPstBegins = this.OnWork_PST_Begins;
    if (onWorkPstBegins != null)
      onWorkPstBegins();
    base.OnPendingCompleteWork(worker);
  }
}
