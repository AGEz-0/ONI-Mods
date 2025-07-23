﻿// Decompiled with JetBrains decompiler
// Type: BeeForagingMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BeeForagingMonitor : 
  GameStateMachine<BeeForagingMonitor, BeeForagingMonitor.Instance, IStateMachineTarget, BeeForagingMonitor.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.ToggleBehaviour(GameTags.Creatures.WantsToForage, new StateMachine<BeeForagingMonitor, BeeForagingMonitor.Instance, IStateMachineTarget, BeeForagingMonitor.Def>.Transition.ConditionCallback(BeeForagingMonitor.ShouldForage), (System.Action<BeeForagingMonitor.Instance>) (smi => smi.RefreshSearchTime()));
  }

  public static bool ShouldForage(BeeForagingMonitor.Instance smi)
  {
    bool flag = (double) GameClock.Instance.GetTimeInCycles() >= (double) smi.nextSearchTime;
    KPrefabID hiveInRoom = smi.master.GetComponent<Bee>().FindHiveInRoom();
    if ((UnityEngine.Object) hiveInRoom != (UnityEngine.Object) null)
    {
      BeehiveCalorieMonitor.Instance smi1 = hiveInRoom.GetSMI<BeehiveCalorieMonitor.Instance>();
      if (smi1 == null || !smi1.IsHungry())
        flag = false;
    }
    return flag && (UnityEngine.Object) hiveInRoom != (UnityEngine.Object) null;
  }

  public class Def : StateMachine.BaseDef
  {
    public float searchMinInterval = 0.25f;
    public float searchMaxInterval = 0.3f;
  }

  public new class Instance : 
    GameStateMachine<BeeForagingMonitor, BeeForagingMonitor.Instance, IStateMachineTarget, BeeForagingMonitor.Def>.GameInstance
  {
    public float nextSearchTime;

    public Instance(IStateMachineTarget master, BeeForagingMonitor.Def def)
      : base(master, def)
    {
      this.RefreshSearchTime();
    }

    public void RefreshSearchTime()
    {
      this.nextSearchTime = GameClock.Instance.GetTimeInCycles() + Mathf.Lerp(this.def.searchMinInterval, this.def.searchMaxInterval, UnityEngine.Random.value);
    }
  }
}
