// Decompiled with JetBrains decompiler
// Type: CritterElementMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CritterElementMonitor : 
  GameStateMachine<CritterElementMonitor, CritterElementMonitor.Instance, IStateMachineTarget>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.Update("UpdateInElement", (System.Action<CritterElementMonitor.Instance, float>) ((smi, dt) => smi.UpdateCurrentElement(dt)), UpdateRate.SIM_1000ms);
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<CritterElementMonitor, CritterElementMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
    public event System.Action<float> OnUpdateEggChances;

    public void UpdateCurrentElement(float dt) => this.OnUpdateEggChances(dt);
  }
}
