// Decompiled with JetBrains decompiler
// Type: ClusterMapRocketAnimator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class ClusterMapRocketAnimator : 
  GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer>
{
  public StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.TargetParameter entityTarget;
  public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State idle;
  public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State grounded;
  public ClusterMapRocketAnimator.MovingStates moving;
  public ClusterMapRocketAnimator.UtilityStates utility;
  public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State exploding;
  public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State exploding_pst;

  public override void InitializeStates(out StateMachine.BaseState defaultState)
  {
    defaultState = (StateMachine.BaseState) this.idle;
    this.root.Transition((GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State) null, new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.entityTarget.IsNull)).Target(this.entityTarget).EventHandlerTransition(GameHashes.RocketSelfDestructRequested, this.exploding, (Func<ClusterMapRocketAnimator.StatesInstance, object, bool>) ((smi, data) => true)).EventHandlerTransition(GameHashes.StartMining, (GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State) this.utility.mining, (Func<ClusterMapRocketAnimator.StatesInstance, object, bool>) ((smi, data) => true)).EventHandlerTransition(GameHashes.RocketLaunched, this.moving.takeoff, (Func<ClusterMapRocketAnimator.StatesInstance, object, bool>) ((smi, data) => true));
    this.idle.Target(this.masterTarget).Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi => smi.PlayVisAnim("idle_loop", KAnim.PlayMode.Loop))).Target(this.entityTarget).Transition((GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State) this.moving.traveling, new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsTraveling)).Transition(this.grounded, new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsGrounded)).Transition(this.moving.landing, new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsLanding)).Transition((GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State) this.utility.mining, new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsMining));
    this.grounded.Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi =>
    {
      this.ToggleSelectable(false, smi);
      smi.ToggleVisAnim(false);
    })).Exit((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi =>
    {
      this.ToggleSelectable(true, smi);
      smi.ToggleVisAnim(true);
    })).Target(this.entityTarget).EventTransition(GameHashes.RocketLaunched, this.moving.takeoff);
    this.moving.takeoff.Transition(this.idle, GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Not(new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsSurfaceTransitioning))).Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi =>
    {
      smi.PlayVisAnim("launching", KAnim.PlayMode.Loop);
      this.ToggleSelectable(false, smi);
    })).Exit((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi => this.ToggleSelectable(true, smi)));
    this.moving.landing.Transition(this.idle, GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Not(new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsSurfaceTransitioning))).Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi =>
    {
      smi.PlayVisAnim("landing", KAnim.PlayMode.Loop);
      this.ToggleSelectable(false, smi);
    })).Exit((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi => this.ToggleSelectable(true, smi)));
    this.moving.traveling.DefaultState(this.moving.traveling.regular).Target(this.entityTarget).EventTransition(GameHashes.ClusterLocationChanged, this.idle, GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Not(new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsTraveling))).EventTransition(GameHashes.ClusterDestinationChanged, this.idle, GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Not(new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsTraveling)));
    this.moving.traveling.regular.Target(this.entityTarget).Transition(this.moving.traveling.boosted, new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsBoosted)).Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi => smi.PlayVisAnim("inflight_loop", KAnim.PlayMode.Loop)));
    this.moving.traveling.boosted.Target(this.entityTarget).Transition(this.moving.traveling.regular, GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Not(new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsBoosted))).Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi => smi.PlayVisAnim("boosted", KAnim.PlayMode.Loop)));
    this.utility.Target(this.masterTarget).EventTransition(GameHashes.ClusterDestinationChanged, this.idle, new StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.Transition.ConditionCallback(this.IsTraveling));
    this.utility.mining.DefaultState(this.utility.mining.pre).Target(this.entityTarget).EventTransition(GameHashes.StopMining, this.utility.mining.pst);
    this.utility.mining.pre.Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi =>
    {
      smi.PlayVisAnim("mining_pre", KAnim.PlayMode.Once);
      smi.SubscribeOnVisAnimComplete((System.Action<object>) (data => smi.GoTo((StateMachine.BaseState) this.utility.mining.loop)));
    }));
    this.utility.mining.loop.Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi => smi.PlayVisAnim("mining_loop", KAnim.PlayMode.Loop)));
    this.utility.mining.pst.Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi =>
    {
      smi.PlayVisAnim("mining_pst", KAnim.PlayMode.Once);
      smi.SubscribeOnVisAnimComplete((System.Action<object>) (data => smi.GoTo((StateMachine.BaseState) this.idle)));
    }));
    this.exploding.Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi =>
    {
      smi.GetComponent<ClusterMapVisualizer>().GetFirstAnimController().SwapAnims(new KAnimFile[1]
      {
        Assets.GetAnim((HashedString) "rocket_self_destruct_kanim")
      });
      smi.PlayVisAnim("explode", KAnim.PlayMode.Once);
      smi.SubscribeOnVisAnimComplete((System.Action<object>) (data => smi.GoTo((StateMachine.BaseState) this.exploding_pst)));
    }));
    this.exploding_pst.Enter((StateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State.Callback) (smi =>
    {
      smi.GetComponent<ClusterMapVisualizer>().GetFirstAnimController().Stop();
      smi.entity.gameObject.Trigger(-1311384361);
    }));
  }

  private bool ClusterChangedAtMyLocation(ClusterMapRocketAnimator.StatesInstance smi, object data)
  {
    ClusterLocationChangedEvent locationChangedEvent = (ClusterLocationChangedEvent) data;
    return locationChangedEvent.oldLocation == smi.entity.Location || locationChangedEvent.newLocation == smi.entity.Location;
  }

  private bool IsTraveling(ClusterMapRocketAnimator.StatesInstance smi)
  {
    return smi.entity.GetComponent<ClusterTraveler>().IsTraveling() && ((Clustercraft) smi.entity).HasResourcesToMove();
  }

  private bool IsBoosted(ClusterMapRocketAnimator.StatesInstance smi)
  {
    return (double) ((Clustercraft) smi.entity).controlStationBuffTimeRemaining > 0.0;
  }

  private bool IsGrounded(ClusterMapRocketAnimator.StatesInstance smi)
  {
    return ((Clustercraft) smi.entity).Status == Clustercraft.CraftStatus.Grounded;
  }

  private bool IsLanding(ClusterMapRocketAnimator.StatesInstance smi)
  {
    return ((Clustercraft) smi.entity).Status == Clustercraft.CraftStatus.Landing;
  }

  private bool IsMining(ClusterMapRocketAnimator.StatesInstance smi)
  {
    return smi.entity.HasTag(GameTags.POIHarvesting);
  }

  private bool IsSurfaceTransitioning(ClusterMapRocketAnimator.StatesInstance smi)
  {
    Clustercraft entity = smi.entity as Clustercraft;
    if (!((UnityEngine.Object) entity != (UnityEngine.Object) null))
      return false;
    return entity.Status == Clustercraft.CraftStatus.Landing || entity.Status == Clustercraft.CraftStatus.Launching;
  }

  private void ToggleSelectable(bool isSelectable, ClusterMapRocketAnimator.StatesInstance smi)
  {
    if (smi.entity.IsNullOrDestroyed())
      return;
    KSelectable component = smi.entity.GetComponent<KSelectable>();
    component.IsSelectable = isSelectable;
    if (isSelectable || !component.IsSelected || ClusterMapScreen.Instance.GetMode() == ClusterMapScreen.Mode.SelectDestination)
      return;
    ClusterMapSelectTool.Instance.Select((KSelectable) null, true);
    SelectTool.Instance.Select((KSelectable) null, true);
  }

  public class TravelingStates : 
    GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State
  {
    public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State regular;
    public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State boosted;
  }

  public class MovingStates : 
    GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State
  {
    public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State takeoff;
    public ClusterMapRocketAnimator.TravelingStates traveling;
    public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State landing;
  }

  public class UtilityStates : 
    GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State
  {
    public ClusterMapRocketAnimator.UtilityStates.MiningStates mining;

    public class MiningStates : 
      GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State
    {
      public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State pre;
      public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State loop;
      public GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.State pst;
    }
  }

  public class StatesInstance : 
    GameStateMachine<ClusterMapRocketAnimator, ClusterMapRocketAnimator.StatesInstance, ClusterMapVisualizer, object>.GameInstance
  {
    public ClusterGridEntity entity;
    private int animCompleteHandle = -1;
    private GameObject animCompleteSubscriber;

    public StatesInstance(ClusterMapVisualizer master, ClusterGridEntity entity)
      : base(master)
    {
      this.entity = entity;
      this.sm.entityTarget.Set((KMonoBehaviour) entity, this);
    }

    public void PlayVisAnim(string animName, KAnim.PlayMode playMode)
    {
      this.GetComponent<ClusterMapVisualizer>().PlayAnim(animName, playMode);
    }

    public void ToggleVisAnim(bool on)
    {
      ClusterMapVisualizer component = this.GetComponent<ClusterMapVisualizer>();
      if (on)
        return;
      component.GetFirstAnimController().Play((HashedString) "grounded");
    }

    public void SubscribeOnVisAnimComplete(System.Action<object> action)
    {
      ClusterMapVisualizer component = this.GetComponent<ClusterMapVisualizer>();
      this.UnsubscribeOnVisAnimComplete();
      this.animCompleteSubscriber = component.GetFirstAnimController().gameObject;
      this.animCompleteHandle = this.animCompleteSubscriber.Subscribe(-1061186183, action);
    }

    public void UnsubscribeOnVisAnimComplete()
    {
      if (this.animCompleteHandle == -1)
        return;
      DebugUtil.DevAssert((UnityEngine.Object) this.animCompleteSubscriber != (UnityEngine.Object) null, "ClusterMapRocketAnimator animCompleteSubscriber GameObject is null. Whatever the previous gameObject in this variable was, it may not have unsubscribed from an event properly");
      this.animCompleteSubscriber.Unsubscribe(this.animCompleteHandle);
      this.animCompleteHandle = -1;
    }

    protected override void OnCleanUp()
    {
      base.OnCleanUp();
      this.UnsubscribeOnVisAnimComplete();
    }
  }
}
