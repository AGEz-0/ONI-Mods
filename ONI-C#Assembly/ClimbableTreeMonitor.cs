// Decompiled with JetBrains decompiler
// Type: ClimbableTreeMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class ClimbableTreeMonitor : 
  GameStateMachine<ClimbableTreeMonitor, ClimbableTreeMonitor.Instance, IStateMachineTarget, ClimbableTreeMonitor.Def>
{
  private const int MAX_NAV_COST = 2147483647 /*0x7FFFFFFF*/;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.ToggleBehaviour(GameTags.Creatures.WantsToClimbTree, (StateMachine<ClimbableTreeMonitor, ClimbableTreeMonitor.Instance, IStateMachineTarget, ClimbableTreeMonitor.Def>.Transition.ConditionCallback) (smi => smi.UpdateHasClimbable()), (System.Action<ClimbableTreeMonitor.Instance>) (smi => smi.OnClimbComplete()));
  }

  public class Def : StateMachine.BaseDef
  {
    public float searchMinInterval = 60f;
    public float searchMaxInterval = 120f;
  }

  public new class Instance : 
    GameStateMachine<ClimbableTreeMonitor, ClimbableTreeMonitor.Instance, IStateMachineTarget, ClimbableTreeMonitor.Def>.GameInstance
  {
    public GameObject climbTarget;
    public float nextSearchTime;

    public Instance(IStateMachineTarget master, ClimbableTreeMonitor.Def def)
      : base(master, def)
    {
      this.RefreshSearchTime();
    }

    private void RefreshSearchTime()
    {
      this.nextSearchTime = Time.time + Mathf.Lerp(this.def.searchMinInterval, this.def.searchMaxInterval, UnityEngine.Random.value);
    }

    public bool UpdateHasClimbable()
    {
      if ((UnityEngine.Object) this.climbTarget == (UnityEngine.Object) null)
      {
        if ((double) Time.time < (double) this.nextSearchTime)
          return false;
        this.FindClimbableTree();
        this.RefreshSearchTime();
      }
      return (UnityEngine.Object) this.climbTarget != (UnityEngine.Object) null;
    }

    private static bool FindClimbableTreeVisitor(
      object obj,
      ClimbableTreeMonitor.Instance.FindClimableTreeContext context)
    {
      KMonoBehaviour cmp = obj as KMonoBehaviour;
      if (cmp.HasTag(GameTags.Creatures.ReservedByCreature))
        return true;
      int cell = Grid.PosToCell(cmp);
      if (!context.navigator.CanReach(cell))
        return true;
      ForestTreeSeedMonitor component1 = cmp.GetComponent<ForestTreeSeedMonitor>();
      StorageLocker component2 = cmp.GetComponent<StorageLocker>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      {
        if (!component1.ExtraSeedAvailable)
          return true;
      }
      else
      {
        if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
          return true;
        Storage component3 = component2.GetComponent<Storage>();
        if (!component3.allowItemRemoval || component3.IsEmpty())
          return true;
      }
      context.targets.Add(cmp);
      return true;
    }

    private void FindClimbableTree()
    {
      this.climbTarget = (GameObject) null;
      Extents extents = new Extents(Grid.PosToCell(this.master.transform.GetPosition()), 10);
      ClimbableTreeMonitor.Instance.FindClimableTreeContext context;
      context.navigator = this.GetComponent<Navigator>();
      context.targets = ListPool<KMonoBehaviour, ClimbableTreeMonitor>.Allocate();
      GameScenePartitioner.Instance.AsyncSafeVisit<ClimbableTreeMonitor.Instance.FindClimableTreeContext>(extents.x, extents.y, extents.width, extents.height, GameScenePartitioner.Instance.plants, new Func<object, ClimbableTreeMonitor.Instance.FindClimableTreeContext, bool>(ClimbableTreeMonitor.Instance.FindClimbableTreeVisitor), context);
      GameScenePartitioner.Instance.AsyncSafeVisit<ClimbableTreeMonitor.Instance.FindClimableTreeContext>(extents.x, extents.y, extents.width, extents.height, GameScenePartitioner.Instance.completeBuildings, new Func<object, ClimbableTreeMonitor.Instance.FindClimableTreeContext, bool>(ClimbableTreeMonitor.Instance.FindClimbableTreeVisitor), context);
      if (context.targets.Count > 0)
      {
        int index = UnityEngine.Random.Range(0, context.targets.Count);
        this.climbTarget = context.targets[index].gameObject;
      }
      context.targets.Recycle();
    }

    public void OnClimbComplete() => this.climbTarget = (GameObject) null;

    private struct FindClimableTreeContext
    {
      public Navigator navigator;
      public ListPool<KMonoBehaviour, ClimbableTreeMonitor>.PooledList targets;
    }
  }
}
