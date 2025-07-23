// Decompiled with JetBrains decompiler
// Type: IEmptyableCargo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IEmptyableCargo
{
  bool CanEmptyCargo();

  void EmptyCargo();

  IStateMachineTarget master { get; }

  bool CanAutoDeploy { get; }

  bool AutoDeploy { get; set; }

  bool ChooseDuplicant { get; }

  bool ModuleDeployed { get; }

  MinionIdentity ChosenDuplicant { get; set; }
}
