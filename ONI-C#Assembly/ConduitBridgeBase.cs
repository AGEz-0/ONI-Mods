// Decompiled with JetBrains decompiler
// Type: ConduitBridgeBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ConduitBridgeBase : KMonoBehaviour
{
  public ConduitBridgeBase.DesiredMassTransfer desiredMassTransfer;
  public ConduitBridgeBase.ConduitBridgeEvent OnMassTransfer;

  protected void SendEmptyOnMassTransfer()
  {
    if (this.OnMassTransfer == null)
      return;
    this.OnMassTransfer(SimHashes.Void, 0.0f, 0.0f, (byte) 0, 0, (Pickupable) null);
  }

  public delegate float DesiredMassTransfer(
    float dt,
    SimHashes element,
    float mass,
    float temperature,
    byte disease_idx,
    int disease_count,
    Pickupable pickupable);

  public delegate void ConduitBridgeEvent(
    SimHashes element,
    float mass,
    float temperature,
    byte disease_idx,
    int disease_count,
    Pickupable pickupable);
}
