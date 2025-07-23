// Decompiled with JetBrains decompiler
// Type: SighChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SighChore : Chore<SighChore.StatesInstance>
{
  public SighChore(IStateMachineTarget target)
    : base(Db.Get().ChoreTypes.Sigh, target, target.GetComponent<ChoreProvider>(), false)
  {
    this.smi = new SighChore.StatesInstance(this, target.gameObject);
  }

  public class StatesInstance : 
    GameStateMachine<SighChore.States, SighChore.StatesInstance, SighChore, object>.GameInstance
  {
    public StatesInstance(SighChore master, GameObject sigher)
      : base(master)
    {
      this.sm.sigher.Set(sigher, this.smi, false);
    }
  }

  public class States : GameStateMachine<SighChore.States, SighChore.StatesInstance, SighChore>
  {
    public StateMachine<SighChore.States, SighChore.StatesInstance, SighChore, object>.TargetParameter sigher;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.root;
      this.Target(this.sigher);
      this.root.PlayAnim("emote_depressed").OnAnimQueueComplete((GameStateMachine<SighChore.States, SighChore.StatesInstance, SighChore, object>.State) null);
    }
  }
}
