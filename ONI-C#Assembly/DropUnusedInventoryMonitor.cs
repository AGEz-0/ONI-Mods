﻿// Decompiled with JetBrains decompiler
// Type: DropUnusedInventoryMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class DropUnusedInventoryMonitor : 
  GameStateMachine<DropUnusedInventoryMonitor, DropUnusedInventoryMonitor.Instance>
{
  public GameStateMachine<DropUnusedInventoryMonitor, DropUnusedInventoryMonitor.Instance, IStateMachineTarget, object>.State satisfied;
  public GameStateMachine<DropUnusedInventoryMonitor, DropUnusedInventoryMonitor.Instance, IStateMachineTarget, object>.State hasinventory;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.satisfied;
    this.satisfied.EventTransition(GameHashes.OnStorageChange, this.hasinventory, (StateMachine<DropUnusedInventoryMonitor, DropUnusedInventoryMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.GetComponent<Storage>().Count > 0));
    this.hasinventory.EventTransition(GameHashes.OnStorageChange, this.hasinventory, (StateMachine<DropUnusedInventoryMonitor, DropUnusedInventoryMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.GetComponent<Storage>().Count == 0)).ToggleChore((Func<DropUnusedInventoryMonitor.Instance, Chore>) (smi => (Chore) new DropUnusedInventoryChore(Db.Get().ChoreTypes.DropUnusedInventory, smi.master)), this.satisfied);
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<DropUnusedInventoryMonitor, DropUnusedInventoryMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
  }
}
