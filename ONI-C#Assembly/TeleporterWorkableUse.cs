// Decompiled with JetBrains decompiler
// Type: TeleporterWorkableUse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class TeleporterWorkableUse : Workable
{
  protected override void OnPrefabInit() => base.OnPrefabInit();

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.SetWorkTime(5f);
    this.resetProgressOnStop = true;
  }

  protected override void OnStartWork(WorkerBase worker)
  {
    Teleporter component = this.GetComponent<Teleporter>();
    Teleporter teleportTarget = component.FindTeleportTarget();
    component.SetTeleportTarget(teleportTarget);
    TeleportalPad.StatesInstance smi = teleportTarget.GetSMI<TeleportalPad.StatesInstance>();
    smi.sm.targetTeleporter.Trigger(smi);
  }

  protected override void OnStopWork(WorkerBase worker)
  {
    TeleportalPad.StatesInstance smi = this.GetSMI<TeleportalPad.StatesInstance>();
    smi.sm.doTeleport.Trigger(smi);
  }
}
