﻿// Decompiled with JetBrains decompiler
// Type: OperationalController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class OperationalController : 
  GameStateMachine<OperationalController, OperationalController.Instance>
{
  public GameStateMachine<OperationalController, OperationalController.Instance, IStateMachineTarget, object>.State off;
  public GameStateMachine<OperationalController, OperationalController.Instance, IStateMachineTarget, object>.State working_pre;
  public GameStateMachine<OperationalController, OperationalController.Instance, IStateMachineTarget, object>.State working_loop;
  public GameStateMachine<OperationalController, OperationalController.Instance, IStateMachineTarget, object>.State working_pst;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.off;
    this.root.EventTransition(GameHashes.OperationalChanged, this.off, (StateMachine<OperationalController, OperationalController.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.GetComponent<Operational>().IsOperational));
    this.off.PlayAnim("off").EventTransition(GameHashes.OperationalChanged, this.working_pre, (StateMachine<OperationalController, OperationalController.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.GetComponent<Operational>().IsOperational));
    this.working_pre.PlayAnim("working_pre").OnAnimQueueComplete(this.working_loop);
    this.working_loop.PlayAnim("working_loop", KAnim.PlayMode.Loop).EventTransition(GameHashes.OperationalChanged, this.working_pst, (StateMachine<OperationalController, OperationalController.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.GetComponent<Operational>().IsOperational));
    this.working_pst.PlayAnim("working_pst").OnAnimQueueComplete(this.off);
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance(IStateMachineTarget master, OperationalController.Def def) : 
    GameStateMachine<OperationalController, OperationalController.Instance, IStateMachineTarget, object>.GameInstance(master, (object) def)
  {
  }
}
