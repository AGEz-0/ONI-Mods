﻿// Decompiled with JetBrains decompiler
// Type: TravellingCargoLander
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class TravellingCargoLander : 
  GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>
{
  public StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.IntParameter destinationWorld = new StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.IntParameter(-1);
  public StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.BoolParameter isLanding = new StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.BoolParameter(false);
  public StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.BoolParameter isLanded = new StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.BoolParameter(false);
  public StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.BoolParameter hasCargo = new StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.BoolParameter(false);
  public StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.Signal emptyCargo;
  public GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State init;
  public TravellingCargoLander.TravelStates travel;
  public TravellingCargoLander.LandingStates landing;
  public TravellingCargoLander.GroundedStates grounded;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.init;
    this.serializable = StateMachine.SerializeType.ParamsOnly;
    this.root.InitializeOperationalFlag(RocketModule.landedFlag).Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => smi.CheckIfLoaded())).EventHandler(GameHashes.OnStorageChange, (StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => smi.CheckIfLoaded()));
    this.init.ParamTransition<bool>((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.Parameter<bool>) this.isLanding, this.landing.landing, GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.IsTrue).ParamTransition<bool>((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.Parameter<bool>) this.isLanded, (GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State) this.grounded, GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.IsTrue).GoTo((GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State) this.travel);
    this.travel.DefaultState(this.travel.travelling).Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => smi.MoveToSpace())).PlayAnim("idle").ToggleTag(GameTags.EntityInSpace).ToggleMainStatusItem(Db.Get().BuildingStatusItems.InFlight, (Func<TravellingCargoLander.StatesInstance, object>) (smi => (object) smi.GetComponent<ClusterTraveler>()));
    this.travel.travelling.EventTransition(GameHashes.ClusterDestinationReached, this.travel.transferWorlds);
    this.travel.transferWorlds.Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => smi.StartLand())).GoTo(this.landing.landing);
    this.landing.Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => this.isLanding.Set(true, smi))).Exit((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => this.isLanding.Set(false, smi)));
    this.landing.landing.PlayAnim("landing", KAnim.PlayMode.Loop).Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => smi.ResetAnimPosition())).Update((System.Action<TravellingCargoLander.StatesInstance, float>) ((smi, dt) => smi.LandingUpdate(dt)), UpdateRate.SIM_EVERY_TICK).Transition(this.landing.impact, (StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.Transition.ConditionCallback) (smi => (double) smi.flightAnimOffset <= 0.0)).Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => smi.MoveToWorld()));
    this.landing.impact.PlayAnim("grounded_pre").OnAnimQueueComplete((GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State) this.grounded);
    this.grounded.DefaultState(this.grounded.loaded).ToggleTag(GameTags.ClusterEntityGrounded).ToggleOperationalFlag(RocketModule.landedFlag).Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => smi.CheckIfLoaded())).Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => this.isLanded.Set(true, smi)));
    this.grounded.loaded.PlayAnim("grounded").ParamTransition<bool>((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.Parameter<bool>) this.hasCargo, this.grounded.empty, GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.IsFalse).OnSignal(this.emptyCargo, this.grounded.emptying).Enter((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State.Callback) (smi => smi.DoLand()));
    this.grounded.emptying.PlayAnim("deploying").TriggerOnEnter(GameHashes.JettisonCargo).OnAnimQueueComplete(this.grounded.empty);
    this.grounded.empty.PlayAnim("deployed").ParamTransition<bool>((StateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.Parameter<bool>) this.hasCargo, this.grounded.loaded, GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.IsTrue);
  }

  public class Def : StateMachine.BaseDef
  {
    public int landerWidth = 1;
    public float landingSpeed = 5f;
    public bool deployOnLanding;
  }

  public class TravelStates : 
    GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State
  {
    public GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State travelling;
    public GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State transferWorlds;
  }

  public class LandingStates : 
    GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State
  {
    public GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State landing;
    public GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State impact;
  }

  public class GroundedStates : 
    GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State
  {
    public GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State loaded;
    public GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State emptying;
    public GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.State empty;
  }

  public class StatesInstance : 
    GameStateMachine<TravellingCargoLander, TravellingCargoLander.StatesInstance, IStateMachineTarget, TravellingCargoLander.Def>.GameInstance
  {
    [Serialize]
    public float flightAnimOffset = 50f;
    public KBatchedAnimController animController;

    public StatesInstance(IStateMachineTarget master, TravellingCargoLander.Def def)
      : base(master, def)
    {
      this.animController = this.GetComponent<KBatchedAnimController>();
    }

    public void Travel(AxialI source, AxialI destination)
    {
      this.GetComponent<BallisticClusterGridEntity>().Configure(source, destination);
      this.sm.destinationWorld.Set(ClusterUtil.GetAsteroidWorldIdAtLocation(destination), this);
      this.GoTo((StateMachine.BaseState) this.sm.travel);
    }

    public void StartLand()
    {
      WorldContainer world = ClusterManager.Instance.GetWorld(this.sm.destinationWorld.Get(this));
      this.transform.SetPosition(Grid.CellToPosCBC(ClusterManager.Instance.GetRandomSurfaceCell(world.id, this.def.landerWidth), this.animController.sceneLayer));
    }

    public bool UpdateLanding(float dt)
    {
      if ((UnityEngine.Object) this.gameObject.GetMyWorld() != (UnityEngine.Object) null)
      {
        Vector3 position = this.transform.GetPosition();
        position.y -= 0.5f;
        int cell = Grid.PosToCell(position);
        if (Grid.IsWorldValidCell(cell) && Grid.IsSolidCell(cell))
          return true;
      }
      return false;
    }

    public void MoveToSpace()
    {
      Pickupable component = this.GetComponent<Pickupable>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.deleteOffGrid = false;
      this.gameObject.transform.SetPosition(new Vector3(-1f, -1f, Grid.GetLayerZ(this.animController.sceneLayer)));
    }

    public void MoveToWorld()
    {
      Pickupable component = this.GetComponent<Pickupable>();
      if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
        return;
      component.deleteOffGrid = true;
    }

    public void ResetAnimPosition()
    {
      this.animController.Offset = Vector3.up * this.flightAnimOffset;
    }

    public void LandingUpdate(float dt)
    {
      this.flightAnimOffset = Mathf.Max(this.flightAnimOffset - dt * this.def.landingSpeed, 0.0f);
      this.ResetAnimPosition();
    }

    public void DoLand()
    {
      this.animController.Offset = Vector3.zero;
      OccupyArea component = this.smi.GetComponent<OccupyArea>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.ApplyToCells = true;
      if (!this.def.deployOnLanding || !this.CheckIfLoaded())
        return;
      this.sm.emptyCargo.Trigger(this);
    }

    public bool CheckIfLoaded()
    {
      bool flag = false;
      MinionStorage component1 = this.GetComponent<MinionStorage>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        flag |= component1.GetStoredMinionInfo().Count > 0;
      Storage component2 = this.GetComponent<Storage>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && !component2.IsEmpty())
        flag = true;
      if (flag != this.sm.hasCargo.Get(this))
        this.sm.hasCargo.Set(flag, this);
      return flag;
    }
  }
}
