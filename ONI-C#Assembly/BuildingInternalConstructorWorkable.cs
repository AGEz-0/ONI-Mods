// Decompiled with JetBrains decompiler
// Type: BuildingInternalConstructorWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;

#nullable disable
public class BuildingInternalConstructorWorkable : Workable
{
  private BuildingInternalConstructor.Instance constructorInstance;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.attributeConverter = Db.Get().AttributeConverters.ConstructionSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.MOST_DAY_EXPERIENCE;
    this.minimumAttributeMultiplier = 0.75f;
    this.skillExperienceSkillGroup = Db.Get().SkillGroups.Building.Id;
    this.skillExperienceMultiplier = SKILLS.MOST_DAY_EXPERIENCE;
    this.resetProgressOnStop = false;
    this.multitoolContext = (HashedString) "build";
    this.multitoolHitEffectTag = (Tag) EffectConfigs.BuildSplashId;
    this.workingPstComplete = (HashedString[]) null;
    this.workingPstFailed = (HashedString[]) null;
    this.SetOffsetTable(OffsetGroups.InvertedStandardTable);
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.constructorInstance = this.GetSMI<BuildingInternalConstructor.Instance>();
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    this.constructorInstance.ConstructionComplete();
  }
}
