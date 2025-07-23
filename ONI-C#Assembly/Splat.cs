﻿// Decompiled with JetBrains decompiler
// Type: Splat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class Splat : GameStateMachine<Splat, Splat.StatesInstance>
{
  public GameStateMachine<Splat, Splat.StatesInstance, IStateMachineTarget, object>.State complete;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.ToggleChore((Func<Splat.StatesInstance, Chore>) (smi => (Chore) new WorkChore<SplatWorkable>(Db.Get().ChoreTypes.Mop, smi.master)), this.complete);
    this.complete.Enter((StateMachine<Splat, Splat.StatesInstance, IStateMachineTarget, object>.State.Callback) (smi => Util.KDestroyGameObject(smi.master.gameObject)));
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public class StatesInstance(IStateMachineTarget master, Splat.Def def) : 
    GameStateMachine<Splat, Splat.StatesInstance, IStateMachineTarget, object>.GameInstance(master, (object) def)
  {
  }
}
