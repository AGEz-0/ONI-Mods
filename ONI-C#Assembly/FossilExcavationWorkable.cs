// Decompiled with JetBrains decompiler
// Type: FossilExcavationWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using TUNING;

#nullable disable
public abstract class FossilExcavationWorkable : Workable
{
  protected Guid waitingWorkStatusItemHandle;
  protected StatusItem waitingForExcavationWorkStatusItem = Db.Get().BuildingStatusItems.FossilHuntExcavationOrdered;

  protected abstract bool IsMarkedForExcavation();

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workingStatusItem = Db.Get().BuildingStatusItems.FossilHuntExcavationInProgress;
    this.SetWorkerStatusItem(Db.Get().DuplicantStatusItems.FossilHunt_WorkerExcavating);
    this.requiredSkillPerk = Db.Get().SkillPerks.CanArtGreat.Id;
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_fossils_small_kanim")
    };
    this.attributeConverter = Db.Get().AttributeConverters.ArtSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.BARELY_EVER_EXPERIENCE;
    this.skillExperienceMultiplier = SKILLS.PART_DAY_EXPERIENCE;
    this.lightEfficiencyBonus = true;
    this.synchronizeAnims = false;
    this.shouldShowSkillPerkStatusItem = false;
  }

  protected override void UpdateStatusItem(object data = null)
  {
    base.UpdateStatusItem(data);
    KSelectable component = this.GetComponent<KSelectable>();
    if (this.waitingWorkStatusItemHandle != new Guid())
      component.RemoveStatusItem(this.waitingWorkStatusItemHandle);
    if (!((UnityEngine.Object) this.worker == (UnityEngine.Object) null) || !this.IsMarkedForExcavation())
      return;
    this.waitingWorkStatusItemHandle = component.AddStatusItem(this.waitingForExcavationWorkStatusItem);
  }
}
