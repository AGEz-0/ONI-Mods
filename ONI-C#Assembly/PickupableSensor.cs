// Decompiled with JetBrains decompiler
// Type: PickupableSensor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class PickupableSensor : Sensor
{
  private PathProber pathProber;
  private WorkerBase worker;

  public PickupableSensor(Sensors sensors)
    : base(sensors)
  {
    this.worker = this.GetComponent<WorkerBase>();
    this.pathProber = this.GetComponent<PathProber>();
  }

  public override void Update()
  {
    GlobalChoreProvider.Instance.UpdateFetches(this.pathProber);
    Game.Instance.fetchManager.UpdatePickups(this.pathProber, this.worker);
  }
}
