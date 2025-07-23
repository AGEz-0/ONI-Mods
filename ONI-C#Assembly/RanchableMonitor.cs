// Decompiled with JetBrains decompiler
// Type: RanchableMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class RanchableMonitor : 
  GameStateMachine<RanchableMonitor, RanchableMonitor.Instance, IStateMachineTarget, RanchableMonitor.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.ToggleBehaviour(GameTags.Creatures.WantsToGetRanched, (StateMachine<RanchableMonitor, RanchableMonitor.Instance, IStateMachineTarget, RanchableMonitor.Def>.Transition.ConditionCallback) (smi => smi.ShouldGoGetRanched()));
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance : 
    GameStateMachine<RanchableMonitor, RanchableMonitor.Instance, IStateMachineTarget, RanchableMonitor.Def>.GameInstance
  {
    public RanchStation.Instance TargetRanchStation;
    private Navigator navComponent;
    private RanchedStates.Instance states;

    public ChoreConsumer ChoreConsumer { get; private set; }

    public Navigator NavComponent => this.navComponent;

    public RanchedStates.Instance States
    {
      get
      {
        if (this.states == null)
          this.states = this.controller.GetSMI<RanchedStates.Instance>();
        return this.states;
      }
    }

    public Instance(IStateMachineTarget master, RanchableMonitor.Def def)
      : base(master, def)
    {
      this.ChoreConsumer = this.GetComponent<ChoreConsumer>();
      this.navComponent = this.GetComponent<Navigator>();
    }

    public bool ShouldGoGetRanched()
    {
      return this.TargetRanchStation != null && this.TargetRanchStation.IsRunning() && this.TargetRanchStation.IsRancherReady;
    }
  }
}
