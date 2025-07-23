﻿// Decompiled with JetBrains decompiler
// Type: MoltStatesChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class MoltStatesChore : 
  GameStateMachine<MoltStatesChore, MoltStatesChore.Instance, IStateMachineTarget, MoltStatesChore.Def>
{
  public GameStateMachine<MoltStatesChore, MoltStatesChore.Instance, IStateMachineTarget, MoltStatesChore.Def>.State molting;
  public GameStateMachine<MoltStatesChore, MoltStatesChore.Instance, IStateMachineTarget, MoltStatesChore.Def>.State complete;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.molting;
    this.molting.PlayAnim((Func<MoltStatesChore.Instance, string>) (smi => smi.def.moltAnimName)).ScheduleGoTo(5f, (StateMachine.BaseState) this.complete).OnAnimQueueComplete(this.complete);
    this.complete.BehaviourComplete(GameTags.Creatures.ReadyToMolt);
  }

  public class Def : StateMachine.BaseDef
  {
    public string moltAnimName;
  }

  public new class Instance : 
    GameStateMachine<MoltStatesChore, MoltStatesChore.Instance, IStateMachineTarget, MoltStatesChore.Def>.GameInstance
  {
    public Instance(Chore<MoltStatesChore.Instance> chore, MoltStatesChore.Def def)
      : base((IStateMachineTarget) chore, def)
    {
      chore.AddPrecondition(ChorePreconditions.instance.CheckBehaviourPrecondition, (object) GameTags.Creatures.ReadyToMolt);
    }
  }
}
