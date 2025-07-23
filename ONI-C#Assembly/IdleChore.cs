// Decompiled with JetBrains decompiler
// Type: IdleChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class IdleChore : Chore<IdleChore.StatesInstance>
{
  public IdleChore(IStateMachineTarget target)
    : base(Db.Get().ChoreTypes.Idle, target, target.GetComponent<ChoreProvider>(), false, master_priority_class: PriorityScreen.PriorityClass.idle, report_type: ReportManager.ReportType.IdleTime)
  {
    this.showAvailabilityInHoverText = false;
    this.smi = new IdleChore.StatesInstance(this, target.gameObject);
  }

  public class StatesInstance : 
    GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.GameInstance
  {
    private IdleCellSensor idleCellSensor;

    public StatesInstance(IdleChore master, GameObject idler)
      : base(master)
    {
      this.sm.idler.Set(idler, this.smi, false);
      this.idleCellSensor = this.GetComponent<Sensors>().GetSensor<IdleCellSensor>();
    }

    public void UpdateNavType()
    {
      NavType currentNavType = this.GetComponent<Navigator>().CurrentNavType;
      this.sm.isOnLadder.Set(currentNavType == NavType.Ladder || currentNavType == NavType.Pole, this);
      this.sm.isOnTube.Set(currentNavType == NavType.Tube, this);
      int cell = Grid.PosToCell((StateMachine.Instance) this.smi);
      this.sm.isOnSuitMarkerCell.Set(Grid.IsValidCell(cell) && Grid.HasSuitMarker[cell], this);
    }

    public int GetIdleCell() => this.idleCellSensor.GetCell();

    public bool HasIdleCell() => this.idleCellSensor.GetCell() != Grid.InvalidCell;
  }

  public class States : GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore>
  {
    public StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.BoolParameter isOnLadder;
    public StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.BoolParameter isOnTube;
    public StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.BoolParameter isOnSuitMarkerCell;
    public StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.TargetParameter idler;
    public IdleChore.States.IdleState idle;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.idle;
      this.Target(this.idler);
      this.idle.DefaultState(this.idle.onfloor).Enter("UpdateNavType", (StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State.Callback) (smi => smi.UpdateNavType())).Update("UpdateNavType", (Action<IdleChore.StatesInstance, float>) ((smi, dt) => smi.UpdateNavType())).ToggleStateMachine((Func<IdleChore.StatesInstance, StateMachine.Instance>) (smi => (StateMachine.Instance) new TaskAvailabilityMonitor.Instance((IStateMachineTarget) smi.master))).ToggleTag(GameTags.Idle);
      this.idle.onfloor.PlayAnim("idle_default", KAnim.PlayMode.Loop).ParamTransition<bool>((StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.Parameter<bool>) this.isOnLadder, this.idle.onladder, GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.IsTrue).ParamTransition<bool>((StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.Parameter<bool>) this.isOnTube, this.idle.ontube, GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.IsTrue).ParamTransition<bool>((StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.Parameter<bool>) this.isOnSuitMarkerCell, this.idle.onsuitmarker, GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.IsTrue).ToggleScheduleCallback("IdleMove", (Func<IdleChore.StatesInstance, float>) (smi => (float) UnityEngine.Random.Range(5, 15)), (Action<IdleChore.StatesInstance>) (smi => smi.GoTo((StateMachine.BaseState) this.idle.move)));
      this.idle.onladder.PlayAnim("ladder_idle", KAnim.PlayMode.Loop).ToggleScheduleCallback("IdleMove", (Func<IdleChore.StatesInstance, float>) (smi => (float) UnityEngine.Random.Range(5, 15)), (Action<IdleChore.StatesInstance>) (smi => smi.GoTo((StateMachine.BaseState) this.idle.move)));
      this.idle.ontube.PlayAnim("tube_idle_loop", KAnim.PlayMode.Loop).Update("IdleMove", (Action<IdleChore.StatesInstance, float>) ((smi, dt) =>
      {
        if (!smi.HasIdleCell())
          return;
        smi.GoTo((StateMachine.BaseState) this.idle.move);
      }), UpdateRate.SIM_1000ms);
      this.idle.onsuitmarker.PlayAnim("idle_default", KAnim.PlayMode.Loop).Enter((StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State.Callback) (smi =>
      {
        Navigator component = smi.GetComponent<Navigator>();
        int cell = Grid.PosToCell((KMonoBehaviour) component);
        Grid.SuitMarker.Flags flags;
        Grid.TryGetSuitMarkerFlags(cell, out flags, out PathFinder.PotentialPath.Flags _);
        IdleSuitMarkerCellQuery query = new IdleSuitMarkerCellQuery((flags & Grid.SuitMarker.Flags.Rotated) != 0, Grid.CellToXY(cell).X);
        component.RunQuery((PathFinderQuery) query);
        component.GoTo(query.GetResultCell());
      })).EventTransition(GameHashes.DestinationReached, (GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State) this.idle).ToggleScheduleCallback("IdleMove", (Func<IdleChore.StatesInstance, float>) (smi => (float) UnityEngine.Random.Range(5, 15)), (Action<IdleChore.StatesInstance>) (smi => smi.GoTo((StateMachine.BaseState) this.idle.move)));
      this.idle.move.Transition((GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State) this.idle, (StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.Transition.ConditionCallback) (smi => !smi.HasIdleCell())).TriggerOnEnter(GameHashes.BeginWalk).TriggerOnExit(GameHashes.EndWalk).ToggleAnims("anim_loco_walk_kanim").MoveTo((Func<IdleChore.StatesInstance, int>) (smi => smi.GetIdleCell()), (GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State) this.idle, (GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State) this.idle).Exit("UpdateNavType", (StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State.Callback) (smi => smi.UpdateNavType())).Exit("ClearWalk", (StateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State.Callback) (smi => smi.GetComponent<KBatchedAnimController>().Play((HashedString) "idle_default")));
    }

    public class IdleState : 
      GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State
    {
      public GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State onfloor;
      public GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State onladder;
      public GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State ontube;
      public GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State onsuitmarker;
      public GameStateMachine<IdleChore.States, IdleChore.StatesInstance, IdleChore, object>.State move;
    }
  }
}
