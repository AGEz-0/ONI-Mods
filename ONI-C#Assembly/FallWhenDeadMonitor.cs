// Decompiled with JetBrains decompiler
// Type: FallWhenDeadMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FallWhenDeadMonitor : 
  GameStateMachine<FallWhenDeadMonitor, FallWhenDeadMonitor.Instance>
{
  public GameStateMachine<FallWhenDeadMonitor, FallWhenDeadMonitor.Instance, IStateMachineTarget, object>.State standing;
  public GameStateMachine<FallWhenDeadMonitor, FallWhenDeadMonitor.Instance, IStateMachineTarget, object>.State falling;
  public GameStateMachine<FallWhenDeadMonitor, FallWhenDeadMonitor.Instance, IStateMachineTarget, object>.State entombed;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.standing;
    this.standing.Transition(this.entombed, (StateMachine<FallWhenDeadMonitor, FallWhenDeadMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.IsEntombed())).Transition(this.falling, (StateMachine<FallWhenDeadMonitor, FallWhenDeadMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.IsFalling()));
    this.falling.ToggleGravity(this.standing);
    this.entombed.Transition(this.standing, (StateMachine<FallWhenDeadMonitor, FallWhenDeadMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.IsEntombed()));
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<FallWhenDeadMonitor, FallWhenDeadMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
    public bool IsEntombed()
    {
      Pickupable component = this.GetComponent<Pickupable>();
      return (Object) component != (Object) null && component.IsEntombed;
    }

    public bool IsFalling()
    {
      int num = Grid.CellBelow(Grid.PosToCell(this.master.transform.GetPosition()));
      return Grid.IsValidCell(num) && !Grid.Solid[num];
    }
  }
}
