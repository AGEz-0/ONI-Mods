// Decompiled with JetBrains decompiler
// Type: DrinkMilkMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DrinkMilkMonitor : 
  GameStateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>
{
  public GameStateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.State lookingToDrinkMilk;
  public GameStateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.State applyEffect;
  public GameStateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.State satisfied;
  private StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.Signal didFinishDrinkingMilk;
  private StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.FloatParameter remainingSecondsForEffect;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.lookingToDrinkMilk;
    this.serializable = StateMachine.SerializeType.ParamsOnly;
    double num1;
    this.root.OnSignal(this.didFinishDrinkingMilk, this.applyEffect).Enter((StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.State.Callback) (smi => num1 = (double) this.remainingSecondsForEffect.Set(Mathf.Clamp(this.remainingSecondsForEffect.Get(smi), 0.0f, 600f), smi))).ParamTransition<float>((StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.Parameter<float>) this.remainingSecondsForEffect, this.satisfied, (StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.Parameter<float>.Callback) ((smi, val) => (double) val > 0.0));
    this.lookingToDrinkMilk.PreBrainUpdate(new System.Action<DrinkMilkMonitor.Instance>(DrinkMilkMonitor.FindMilkFeederTarget)).ToggleBehaviour(GameTags.Creatures.Behaviour_TryToDrinkMilkFromFeeder, (StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.Transition.ConditionCallback) (smi => !smi.targetMilkFeeder.IsNullOrStopped() && !smi.targetMilkFeeder.IsReserved())).Exit((StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.State.Callback) (smi => smi.targetMilkFeeder = (MilkFeeder.Instance) null));
    double num2;
    this.applyEffect.Enter((StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.State.Callback) (smi => num2 = (double) this.remainingSecondsForEffect.Set(600f, smi))).EnterTransition(this.satisfied, (StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.Transition.ConditionCallback) (smi => true));
    this.satisfied.Enter((StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.State.Callback) (smi =>
    {
      if (!smi.def.consumesMilk)
        return;
      smi.GetComponent<Effects>().Add("HadMilk", false).timeRemaining = this.remainingSecondsForEffect.Get(smi);
    })).Exit((StateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.State.Callback) (smi =>
    {
      if (smi.def.consumesMilk)
        smi.GetComponent<Effects>().Remove("HadMilk");
      double num3 = (double) this.remainingSecondsForEffect.Set(-1f, smi);
    })).ScheduleGoTo((Func<DrinkMilkMonitor.Instance, float>) (smi => this.remainingSecondsForEffect.Get(smi)), (StateMachine.BaseState) this.lookingToDrinkMilk).Update((System.Action<DrinkMilkMonitor.Instance, float>) ((smi, deltaSeconds) =>
    {
      double num4 = (double) this.remainingSecondsForEffect.Delta(-deltaSeconds, smi);
      if ((double) this.remainingSecondsForEffect.Get(smi) >= 0.0)
        return;
      smi.GoTo((StateMachine.BaseState) this.lookingToDrinkMilk);
    }), UpdateRate.SIM_1000ms);
  }

  private static void FindMilkFeederTarget(DrinkMilkMonitor.Instance smi)
  {
    int cell = Grid.PosToCell(smi.gameObject);
    if (!Grid.IsValidCell(cell))
      return;
    List<MilkFeeder.Instance> items = Components.MilkFeeders.GetItems((int) Grid.WorldIdx[cell]);
    if (items == null || items.Count == 0)
      return;
    using (ListPool<MilkFeeder.Instance, DrinkMilkMonitor>.PooledList pooledList = PoolsFor<DrinkMilkMonitor>.AllocateList<MilkFeeder.Instance>())
    {
      CavityInfo cavityForCell = Game.Instance.roomProber.GetCavityForCell(cell);
      if (cavityForCell != null && cavityForCell.room != null && cavityForCell.room.roomType == Db.Get().RoomTypes.CreaturePen)
      {
        foreach (MilkFeeder.Instance smi1 in items)
        {
          if (!smi1.IsNullOrDestroyed() && Game.Instance.roomProber.GetCavityForCell(Grid.PosToCell((StateMachine.Instance) smi1)) == cavityForCell && smi1.IsReadyToStartFeeding())
            pooledList.Add(smi1);
        }
      }
      bool canDrown = (UnityEngine.Object) smi.drowningMonitor != (UnityEngine.Object) null && smi.drowningMonitor.canDrownToDeath && !smi.drowningMonitor.livesUnderWater;
      smi.targetMilkFeeder = (MilkFeeder.Instance) null;
      smi.doesTargetMilkFeederHaveSpaceForCritter = false;
      int resultCost = -1;
      foreach (MilkFeeder.Instance instance in (List<MilkFeeder.Instance>) pooledList)
      {
        MilkFeeder.Instance milkFeeder = instance;
        if (ConsiderCell(smi.GetDrinkCellOf(milkFeeder, false)))
          smi.doesTargetMilkFeederHaveSpaceForCritter = false;
        else if (ConsiderCell(smi.GetDrinkCellOf(milkFeeder, true)))
          smi.doesTargetMilkFeederHaveSpaceForCritter = true;

        bool ConsiderCell(int cell)
        {
          if (canDrown && !smi.drowningMonitor.IsCellSafe(cell))
            return false;
          int navigationCost = smi.navigator.GetNavigationCost(cell);
          if (navigationCost == -1 || navigationCost >= resultCost && resultCost != -1)
            return false;
          resultCost = navigationCost;
          smi.targetMilkFeeder = milkFeeder;
          return true;
        }
      }
    }
  }

  public class Def : StateMachine.BaseDef
  {
    public bool consumesMilk = true;
    public DrinkMilkStates.Def.DrinkCellOffsetGetFn drinkCellOffsetGetFn;
  }

  public new class Instance(IStateMachineTarget master, DrinkMilkMonitor.Def def) : 
    GameStateMachine<DrinkMilkMonitor, DrinkMilkMonitor.Instance, IStateMachineTarget, DrinkMilkMonitor.Def>.GameInstance(master, def)
  {
    public MilkFeeder.Instance targetMilkFeeder;
    public bool doesTargetMilkFeederHaveSpaceForCritter;
    [MyCmpReq]
    public Navigator navigator;
    [MyCmpGet]
    public DrowningMonitor drowningMonitor;

    public void NotifyFinishedDrinkingMilkFrom(MilkFeeder.Instance milkFeeder)
    {
      if (milkFeeder != null && this.def.consumesMilk)
        milkFeeder.ConsumeMilkForOneFeeding();
      this.sm.didFinishDrinkingMilk.Trigger(this.smi);
    }

    public int GetDrinkCellOf(MilkFeeder.Instance milkFeeder, bool isTwoByTwoCritterCramped)
    {
      return Grid.OffsetCell(Grid.PosToCell((StateMachine.Instance) milkFeeder), this.def.drinkCellOffsetGetFn(milkFeeder, this, isTwoByTwoCritterCramped));
    }
  }
}
