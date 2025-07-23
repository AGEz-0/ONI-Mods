// Decompiled with JetBrains decompiler
// Type: YellowAlertMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class YellowAlertMonitor : GameStateMachine<YellowAlertMonitor, YellowAlertMonitor.Instance>
{
  public GameStateMachine<YellowAlertMonitor, YellowAlertMonitor.Instance, IStateMachineTarget, object>.State off;
  public GameStateMachine<YellowAlertMonitor, YellowAlertMonitor.Instance, IStateMachineTarget, object>.State on;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.off;
    this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
    this.off.EventTransition(GameHashes.EnteredYellowAlert, (Func<YellowAlertMonitor.Instance, KMonoBehaviour>) (smi => (KMonoBehaviour) Game.Instance), this.on, (StateMachine<YellowAlertMonitor, YellowAlertMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => YellowAlertManager.Instance.Get().IsOn()));
    this.on.EventTransition(GameHashes.ExitedYellowAlert, (Func<YellowAlertMonitor.Instance, KMonoBehaviour>) (smi => (KMonoBehaviour) Game.Instance), this.off, (StateMachine<YellowAlertMonitor, YellowAlertMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !YellowAlertManager.Instance.Get().IsOn())).Enter("EnableYellowAlert", (StateMachine<YellowAlertMonitor, YellowAlertMonitor.Instance, IStateMachineTarget, object>.State.Callback) (smi => smi.EnableYellowAlert()));
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<YellowAlertMonitor, YellowAlertMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
    public void EnableYellowAlert()
    {
    }
  }
}
