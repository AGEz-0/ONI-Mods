﻿// Decompiled with JetBrains decompiler
// Type: CreatureDebugGoToMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CreatureDebugGoToMonitor : 
  GameStateMachine<CreatureDebugGoToMonitor, CreatureDebugGoToMonitor.Instance, IStateMachineTarget, CreatureDebugGoToMonitor.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.ToggleBehaviour(GameTags.HasDebugDestination, new StateMachine<CreatureDebugGoToMonitor, CreatureDebugGoToMonitor.Instance, IStateMachineTarget, CreatureDebugGoToMonitor.Def>.Transition.ConditionCallback(CreatureDebugGoToMonitor.HasTargetCell), new System.Action<CreatureDebugGoToMonitor.Instance>(CreatureDebugGoToMonitor.ClearTargetCell));
  }

  private static bool HasTargetCell(CreatureDebugGoToMonitor.Instance smi)
  {
    return smi.targetCell != Grid.InvalidCell;
  }

  private static void ClearTargetCell(CreatureDebugGoToMonitor.Instance smi)
  {
    smi.targetCell = Grid.InvalidCell;
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance(IStateMachineTarget target, CreatureDebugGoToMonitor.Def def) : 
    GameStateMachine<CreatureDebugGoToMonitor, CreatureDebugGoToMonitor.Instance, IStateMachineTarget, CreatureDebugGoToMonitor.Def>.GameInstance(target, def)
  {
    public int targetCell = Grid.InvalidCell;

    public void GoToCursor() => this.targetCell = DebugHandler.GetMouseCell();

    public void GoToCell(int cellIndex) => this.targetCell = cellIndex;
  }
}
