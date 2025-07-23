// Decompiled with JetBrains decompiler
// Type: StorageTileSwitchItemWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class StorageTileSwitchItemWorkable : Workable
{
  private const string animName = "anim_use_remote_kanim";

  public int LastCellWorkerUsed { private set; get; } = -1;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_use_remote_kanim")
    };
    this.SetOffsetTable(OffsetGroups.InvertedStandardTable);
    this.faceTargetWhenWorking = true;
    this.synchronizeAnims = false;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.SetWorkTime(3f);
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    if ((Object) worker != (Object) null)
      this.LastCellWorkerUsed = Grid.PosToCell(worker.transform.GetPosition());
    base.OnCompleteWork(worker);
  }
}
