// Decompiled with JetBrains decompiler
// Type: SchedulerHandle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public struct SchedulerHandle(Scheduler scheduler, SchedulerEntry entry)
{
  public SchedulerEntry entry = entry;
  private Scheduler scheduler = scheduler;

  public float TimeRemaining => !this.IsValid ? -1f : this.entry.time - this.scheduler.GetTime();

  public void FreeResources()
  {
    this.entry.FreeResources();
    this.scheduler = (Scheduler) null;
  }

  public void ClearScheduler()
  {
    if (this.scheduler == null)
      return;
    this.scheduler.Clear(this);
    this.scheduler = (Scheduler) null;
  }

  public bool IsValid => this.scheduler != null;
}
