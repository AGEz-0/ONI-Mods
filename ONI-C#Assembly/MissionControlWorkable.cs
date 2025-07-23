﻿// Decompiled with JetBrains decompiler
// Type: MissionControlWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using TUNING;
using UnityEngine;

#nullable disable
public class MissionControlWorkable : Workable
{
  private Spacecraft targetSpacecraft;
  [MyCmpReq]
  private Operational operational;
  private Guid workStatusItem = Guid.Empty;

  public Spacecraft TargetSpacecraft
  {
    get => this.targetSpacecraft;
    set
    {
      this.WorkTimeRemaining = this.GetWorkTime();
      this.targetSpacecraft = value;
    }
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.requiredSkillPerk = Db.Get().SkillPerks.CanMissionControl.Id;
    this.workerStatusItem = Db.Get().DuplicantStatusItems.MissionControlling;
    this.attributeConverter = Db.Get().AttributeConverters.ResearchSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.PART_DAY_EXPERIENCE;
    this.skillExperienceSkillGroup = Db.Get().SkillGroups.Research.Id;
    this.skillExperienceMultiplier = SKILLS.PART_DAY_EXPERIENCE;
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_mission_control_station_kanim")
    };
    this.SetWorkTime(90f);
    this.showProgressBar = true;
    this.lightEfficiencyBonus = true;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    Components.MissionControlWorkables.Add(this);
  }

  protected override void OnCleanUp()
  {
    Components.MissionControlWorkables.Remove(this);
    base.OnCleanUp();
  }

  protected override void OnStartWork(WorkerBase worker)
  {
    base.OnStartWork(worker);
    this.workStatusItem = this.gameObject.GetComponent<KSelectable>().AddStatusItem(Db.Get().BuildingStatusItems.MissionControlAssistingRocket, (object) this.TargetSpacecraft);
    this.operational.SetActive(true);
  }

  public override float GetEfficiencyMultiplier(WorkerBase worker)
  {
    return base.GetEfficiencyMultiplier(worker) * Mathf.Clamp01(this.GetSMI<SkyVisibilityMonitor.Instance>().PercentClearSky);
  }

  protected override bool OnWorkTick(WorkerBase worker, float dt)
  {
    if (this.TargetSpacecraft != null)
      return base.OnWorkTick(worker, dt);
    worker.StopWork();
    return true;
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    Debug.Assert(this.TargetSpacecraft != null);
    this.gameObject.GetSMI<MissionControl.Instance>().ApplyEffect(this.TargetSpacecraft);
    base.OnCompleteWork(worker);
  }

  protected override void OnStopWork(WorkerBase worker)
  {
    base.OnStopWork(worker);
    this.gameObject.GetComponent<KSelectable>().RemoveStatusItem(this.workStatusItem);
    this.TargetSpacecraft = (Spacecraft) null;
    this.operational.SetActive(false);
  }
}
