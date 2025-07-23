﻿// Decompiled with JetBrains decompiler
// Type: PhonoboxWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using TUNING;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/PhonoboxWorkable")]
public class PhonoboxWorkable : Workable, IWorkerPrioritizable
{
  public Phonobox owner;
  public int basePriority = RELAXATION.PRIORITY.TIER3;
  public string specificEffect = "Danced";
  public string trackingEffect = "RecentlyDanced";
  public KAnimFile[][] workerOverrideAnims = new KAnimFile[3][]
  {
    new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_phonobox_danceone_kanim")
    },
    new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_phonobox_dancetwo_kanim")
    },
    new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_phonobox_dancethree_kanim")
    }
  };

  private PhonoboxWorkable() => this.SetReportType(ReportManager.ReportType.PersonalTime);

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.synchronizeAnims = false;
    this.showProgressBar = true;
    this.resetProgressOnStop = true;
    this.SetWorkTime(15f);
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    Effects component = worker.GetComponent<Effects>();
    if (!string.IsNullOrEmpty(this.trackingEffect))
      component.Add(this.trackingEffect, true);
    if (string.IsNullOrEmpty(this.specificEffect))
      return;
    component.Add(this.specificEffect, true);
  }

  public bool GetWorkerPriority(WorkerBase worker, out int priority)
  {
    priority = this.basePriority;
    Effects component = worker.GetComponent<Effects>();
    if (!string.IsNullOrEmpty(this.trackingEffect) && component.HasEffect(this.trackingEffect))
    {
      priority = 0;
      return false;
    }
    if (!string.IsNullOrEmpty(this.specificEffect) && component.HasEffect(this.specificEffect))
      priority = RELAXATION.PRIORITY.RECENTLY_USED;
    return true;
  }

  protected override void OnStartWork(WorkerBase worker)
  {
    this.owner.AddWorker(worker);
    worker.GetComponent<Effects>().Add("Dancing", false);
  }

  protected override void OnStopWork(WorkerBase worker)
  {
    this.owner.RemoveWorker(worker);
    worker.GetComponent<Effects>().Remove("Dancing");
  }

  public override Workable.AnimInfo GetAnim(WorkerBase worker)
  {
    this.overrideAnims = this.workerOverrideAnims[Random.Range(0, this.workerOverrideAnims.Length)];
    return base.GetAnim(worker);
  }
}
