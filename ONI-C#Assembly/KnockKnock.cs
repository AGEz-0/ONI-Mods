// Decompiled with JetBrains decompiler
// Type: KnockKnock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class KnockKnock : Activatable
{
  private bool doorAnswered;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.showProgressBar = false;
  }

  protected override bool OnWorkTick(WorkerBase worker, float dt)
  {
    if (!this.doorAnswered)
      this.workTimeRemaining += dt;
    return base.OnWorkTick(worker, dt);
  }

  public void AnswerDoor()
  {
    this.doorAnswered = true;
    this.workTimeRemaining = 1f;
  }
}
