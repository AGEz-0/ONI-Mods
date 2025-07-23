﻿// Decompiled with JetBrains decompiler
// Type: NuclearResearchCenterWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using TUNING;
using UnityEngine;

#nullable disable
public class NuclearResearchCenterWorkable : Workable
{
  [MyCmpReq]
  private Operational operational;
  [Serialize]
  private float pointsProduced;
  private NuclearResearchCenter nrc;
  private HighEnergyParticleStorage radiationStorage;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Researching;
    this.attributeConverter = Db.Get().AttributeConverters.ResearchSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.ALL_DAY_EXPERIENCE;
    this.skillExperienceSkillGroup = Db.Get().SkillGroups.Research.Id;
    this.skillExperienceMultiplier = SKILLS.ALL_DAY_EXPERIENCE;
    this.radiationStorage = this.GetComponent<HighEnergyParticleStorage>();
    this.nrc = this.GetComponent<NuclearResearchCenter>();
    this.lightEfficiencyBonus = true;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.SetWorkTime(float.PositiveInfinity);
  }

  protected override bool OnWorkTick(WorkerBase worker, float dt)
  {
    float num1 = dt / this.nrc.timePerPoint;
    if (Game.Instance.FastWorkersModeActive)
      num1 *= 2f;
    double num2 = (double) this.radiationStorage.ConsumeAndGet(num1 * this.nrc.materialPerPoint);
    this.pointsProduced += num1;
    if ((double) this.pointsProduced >= 1.0)
    {
      int points = Mathf.FloorToInt(this.pointsProduced);
      this.pointsProduced -= (float) points;
      PopFXManager.Instance.SpawnFX(PopFXManager.Instance.sprite_Research, Research.Instance.GetResearchType("nuclear").name, this.transform);
      Research.Instance.AddResearchPoints("nuclear", (float) points);
    }
    TechInstance activeResearch = Research.Instance.GetActiveResearch();
    return this.radiationStorage.IsEmpty() || activeResearch == null || (double) activeResearch.PercentageCompleteResearchType("nuclear") >= 1.0;
  }

  protected override void OnStartWork(WorkerBase worker)
  {
    base.OnStartWork(worker);
    this.GetComponent<KSelectable>().AddStatusItem(Db.Get().BuildingStatusItems.ComplexFabricatorResearching, (object) this.nrc);
  }

  protected override void OnAbortWork(WorkerBase worker) => base.OnAbortWork(worker);

  protected override void OnStopWork(WorkerBase worker)
  {
    base.OnStopWork(worker);
    this.GetComponent<KSelectable>().RemoveStatusItem(Db.Get().BuildingStatusItems.ComplexFabricatorResearching, (bool) (Object) this.nrc);
  }

  public override float GetPercentComplete()
  {
    if (Research.Instance.GetActiveResearch() == null)
      return 0.0f;
    float num1 = Research.Instance.GetActiveResearch().progressInventory.PointsByTypeID["nuclear"];
    float num2 = 0.0f;
    return !Research.Instance.GetActiveResearch().tech.costsByResearchTypeID.TryGetValue("nuclear", out num2) ? 1f : num1 / num2;
  }

  public override bool InstantlyFinish(WorkerBase worker) => false;
}
