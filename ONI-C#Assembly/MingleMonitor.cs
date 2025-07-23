// Decompiled with JetBrains decompiler
// Type: MingleMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class MingleMonitor : GameStateMachine<MingleMonitor, MingleMonitor.Instance>
{
  public GameStateMachine<MingleMonitor, MingleMonitor.Instance, IStateMachineTarget, object>.State mingle;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.mingle;
    this.serializable = StateMachine.SerializeType.Never;
    this.mingle.ToggleRecurringChore(new Func<MingleMonitor.Instance, Chore>(this.CreateMingleChore));
  }

  private Chore CreateMingleChore(MingleMonitor.Instance smi)
  {
    return (Chore) new MingleChore(smi.master);
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<MingleMonitor, MingleMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
  }
}
