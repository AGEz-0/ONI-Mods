// Decompiled with JetBrains decompiler
// Type: Usable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public abstract class Usable : KMonoBehaviour, IStateMachineTarget
{
  private StateMachine.Instance smi;

  public abstract void StartUsing(User user);

  protected void StartUsing(StateMachine.Instance smi, User user)
  {
    DebugUtil.Assert(this.smi == null);
    DebugUtil.Assert(smi != null);
    this.smi = smi;
    smi.OnStop += new Action<string, StateMachine.Status>(user.OnStateMachineStop);
    smi.StartSM();
  }

  public void StopUsing(User user)
  {
    if (this.smi == null)
      return;
    this.smi.OnStop -= new Action<string, StateMachine.Status>(user.OnStateMachineStop);
    this.smi.StopSM("Usable.StopUsing");
    this.smi = (StateMachine.Instance) null;
  }
}
