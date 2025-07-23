// Decompiled with JetBrains decompiler
// Type: PoweredController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class PoweredController : GameStateMachine<PoweredController, PoweredController.Instance>
{
  public GameStateMachine<PoweredController, PoweredController.Instance, IStateMachineTarget, object>.State off;
  public GameStateMachine<PoweredController, PoweredController.Instance, IStateMachineTarget, object>.State on;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.off;
    this.off.PlayAnim("off").EventTransition(GameHashes.OperationalChanged, this.on, (StateMachine<PoweredController, PoweredController.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.GetComponent<Operational>().IsOperational));
    this.on.PlayAnim("on").EventTransition(GameHashes.OperationalChanged, this.off, (StateMachine<PoweredController, PoweredController.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.GetComponent<Operational>().IsOperational));
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance(IStateMachineTarget master, PoweredController.Def def) : 
    GameStateMachine<PoweredController, PoweredController.Instance, IStateMachineTarget, object>.GameInstance(master, (object) def)
  {
    public bool ShowWorkingStatus;
  }
}
