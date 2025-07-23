// Decompiled with JetBrains decompiler
// Type: POITechItemUnlockWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class POITechItemUnlockWorkable : Workable
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.workerStatusItem = Db.Get().DuplicantStatusItems.ResearchingFromPOI;
    this.alwaysShowProgressBar = true;
    this.resetProgressOnStop = false;
    this.synchronizeAnims = true;
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    base.OnCompleteWork(worker);
    POITechItemUnlocks.Instance smi = this.GetSMI<POITechItemUnlocks.Instance>();
    smi.UnlockTechItems();
    smi.sm.pendingChore.Set(false, smi);
    this.gameObject.Trigger(1980521255);
    Prioritizable.RemoveRef(this.gameObject);
  }
}
