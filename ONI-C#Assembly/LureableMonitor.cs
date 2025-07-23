// Decompiled with JetBrains decompiler
// Type: LureableMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LureableMonitor : 
  GameStateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>
{
  public StateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.TargetParameter targetLure;
  public GameStateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.State nolure;
  public GameStateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.State haslure;
  public GameStateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.State cooldown;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.cooldown;
    this.cooldown.ScheduleGoTo((Func<LureableMonitor.Instance, float>) (smi => smi.def.cooldown), (StateMachine.BaseState) this.nolure);
    this.nolure.PreBrainUpdate((System.Action<LureableMonitor.Instance>) (smi => smi.FindLure())).ParamTransition<GameObject>((StateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.Parameter<GameObject>) this.targetLure, this.haslure, (StateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.Parameter<GameObject>.Callback) ((smi, p) => (UnityEngine.Object) p != (UnityEngine.Object) null));
    this.haslure.ParamTransition<GameObject>((StateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.Parameter<GameObject>) this.targetLure, this.nolure, (StateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.Parameter<GameObject>.Callback) ((smi, p) => (UnityEngine.Object) p == (UnityEngine.Object) null)).PreBrainUpdate((System.Action<LureableMonitor.Instance>) (smi => smi.FindLure())).ToggleBehaviour(GameTags.Creatures.MoveToLure, (StateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.Transition.ConditionCallback) (smi => smi.HasLure()), (System.Action<LureableMonitor.Instance>) (smi => smi.GoTo((StateMachine.BaseState) this.cooldown)));
  }

  public class Def : StateMachine.BaseDef, IGameObjectEffectDescriptor
  {
    public float cooldown = 20f;
    public Tag[] lures;

    public List<Descriptor> GetDescriptors(GameObject go)
    {
      List<Descriptor> descriptors = new List<Descriptor>();
      foreach (Tag lure in this.lures)
      {
        if (lure == GameTags.Creatures.FlyersLure)
          descriptors.Add(new Descriptor((string) UI.BUILDINGEFFECTS.CAPTURE_METHOD_FLYING_TRAP, (string) UI.BUILDINGEFFECTS.TOOLTIPS.CAPTURE_METHOD_FLYING_TRAP));
        else if (lure == GameTags.Creatures.FishTrapLure)
          descriptors.Add(new Descriptor((string) UI.BUILDINGEFFECTS.CAPTURE_METHOD_FISH_TRAP, (string) UI.BUILDINGEFFECTS.TOOLTIPS.CAPTURE_METHOD_FISH_TRAP));
      }
      return descriptors;
    }
  }

  public new class Instance(IStateMachineTarget master, LureableMonitor.Def def) : 
    GameStateMachine<LureableMonitor, LureableMonitor.Instance, IStateMachineTarget, LureableMonitor.Def>.GameInstance(master, def)
  {
    [MyCmpReq]
    private Navigator navigator;
    private static LureableMonitor.Instance.FindLureCounterContext context = new LureableMonitor.Instance.FindLureCounterContext();

    private static bool FindLureCounter(
      object obj,
      LureableMonitor.Instance.FindLureCounterContext context)
    {
      if (!(obj is Lure.Instance instance) || !instance.IsActive() || !instance.HasAnyLure(context.inst.def.lures))
        return true;
      int navigationCost = context.inst.navigator.GetNavigationCost(Grid.PosToCell(instance.transform.GetPosition()), instance.LurePoints);
      if (navigationCost != -1 && (context.cost == -1 || navigationCost < context.cost))
      {
        context.cost = navigationCost;
        context.result = instance.gameObject;
      }
      return true;
    }

    public void FindLure()
    {
      LureableMonitor.Instance.context.inst = this;
      LureableMonitor.Instance.context.cost = -1;
      LureableMonitor.Instance.context.result = (GameObject) null;
      GameScenePartitioner.Instance.AsyncSafeVisit<LureableMonitor.Instance.FindLureCounterContext>(Grid.PosToCell(this.smi.transform.GetPosition()), 1, GameScenePartitioner.Instance.lure, new Func<object, LureableMonitor.Instance.FindLureCounterContext, bool>(LureableMonitor.Instance.FindLureCounter), LureableMonitor.Instance.context);
      this.sm.targetLure.Set(LureableMonitor.Instance.context.result, this, false);
    }

    public bool HasLure() => (UnityEngine.Object) this.sm.targetLure.Get(this) != (UnityEngine.Object) null;

    public GameObject GetTargetLure() => this.sm.targetLure.Get(this);

    private class FindLureCounterContext
    {
      public LureableMonitor.Instance inst;
      public int cost;
      public GameObject result;
    }
  }
}
