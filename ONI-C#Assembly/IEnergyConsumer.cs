// Decompiled with JetBrains decompiler
// Type: IEnergyConsumer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IEnergyConsumer : ICircuitConnected
{
  float WattsUsed { get; }

  float WattsNeededWhenActive { get; }

  int PowerSortOrder { get; }

  void SetConnectionStatus(CircuitManager.ConnectionStatus status);

  string Name { get; }

  bool IsConnected { get; }

  bool IsPowered { get; }
}
