﻿// Decompiled with JetBrains decompiler
// Type: EatChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FoodRehydrator;
using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class EatChore : Chore<EatChore.StatesInstance>
{
  public static readonly Chore.Precondition EdibleIsNotNull = new Chore.Precondition()
  {
    id = nameof (EdibleIsNotNull),
    description = (string) DUPLICANTS.CHORES.PRECONDITIONS.EDIBLE_IS_NOT_NULL,
    fn = (Chore.PreconditionFn) ((ref Chore.Precondition.Context context, object data) => (UnityEngine.Object) null != (UnityEngine.Object) context.consumerState.consumer.GetSMI<RationMonitor.Instance>().GetEdible())
  };

  public EatChore(IStateMachineTarget master)
    : base(Db.Get().ChoreTypes.Eat, master, master.GetComponent<ChoreProvider>(), false, master_priority_class: PriorityScreen.PriorityClass.personalNeeds, report_type: ReportManager.ReportType.PersonalTime)
  {
    this.smi = new EatChore.StatesInstance(this);
    this.showAvailabilityInHoverText = false;
    this.AddPrecondition(ChorePreconditions.instance.IsNotRedAlert, (object) null);
    this.AddPrecondition(EatChore.EdibleIsNotNull, (object) null);
  }

  public override void Begin(Chore.Precondition.Context context)
  {
    if ((UnityEngine.Object) context.consumerState.consumer == (UnityEngine.Object) null)
    {
      Debug.LogError((object) "EATCHORE null context.consumer");
    }
    else
    {
      RationMonitor.Instance smi = context.consumerState.consumer.GetSMI<RationMonitor.Instance>();
      if (smi == null)
      {
        Debug.LogError((object) "EATCHORE null RationMonitor.Instance");
      }
      else
      {
        Edible edible = smi.GetEdible();
        if ((UnityEngine.Object) edible.gameObject == (UnityEngine.Object) null)
          Debug.LogError((object) "EATCHORE null edible.gameObject");
        else if (this.smi == null)
          Debug.LogError((object) "EATCHORE null smi");
        else if (this.smi.sm == null)
          Debug.LogError((object) "EATCHORE null smi.sm");
        else if (this.smi.sm.ediblesource == null)
        {
          Debug.LogError((object) "EATCHORE null smi.sm.ediblesource");
        }
        else
        {
          this.smi.sm.ediblesource.Set(edible.gameObject, this.smi, false);
          KCrashReporter.Assert((double) edible.FoodInfo.CaloriesPerUnit > 0.0, edible.GetProperName() + " has invalid calories per unit. Will result in NaNs");
          AmountInstance amountInstance = Db.Get().Amounts.Calories.Lookup(this.gameObject);
          float num1 = (amountInstance.GetMax() - amountInstance.value) / edible.FoodInfo.CaloriesPerUnit;
          KCrashReporter.Assert((double) num1 > 0.0, "EatChore is requesting an invalid amount of food");
          double num2 = (double) this.smi.sm.requestedfoodunits.Set(num1, this.smi);
          this.smi.sm.eater.Set(context.consumerState.gameObject, this.smi, false);
          base.Begin(context);
        }
      }
    }
  }

  public class StatesInstance(EatChore master) : 
    GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.GameInstance(master)
  {
    private int locatorCell;

    public static Assignable GetPreferredMessStation(MinionIdentity minionId)
    {
      Ownables soleOwner = minionId.GetSoleOwner();
      List<Assignable> preferredAssignables = Game.Instance.assignmentManager.GetPreferredAssignables((Assignables) soleOwner, Db.Get().AssignableSlots.MessStation);
      if (preferredAssignables.Count == 0)
      {
        soleOwner.AutoAssignSlot(Db.Get().AssignableSlots.MessStation);
        preferredAssignables = Game.Instance.assignmentManager.GetPreferredAssignables((Assignables) soleOwner, Db.Get().AssignableSlots.MessStation);
      }
      return preferredAssignables.Count <= 0 ? (Assignable) null : preferredAssignables[0];
    }

    public void UpdateMessStation()
    {
      this.smi.sm.messstation.Set((KMonoBehaviour) EatChore.StatesInstance.GetPreferredMessStation(this.sm.eater.Get(this.smi).GetComponent<MinionIdentity>()), this.smi);
    }

    public bool UseSalt()
    {
      if (this.smi.sm.messstation == null || !((UnityEngine.Object) this.smi.sm.messstation.Get(this.smi) != (UnityEngine.Object) null))
        return false;
      MessStation component = this.smi.sm.messstation.Get(this.smi).GetComponent<MessStation>();
      return (UnityEngine.Object) component != (UnityEngine.Object) null && component.HasSalt;
    }

    public static (GameObject, int) CreateLocator(
      Sensors sensors,
      Transform transform,
      string locatorName)
    {
      int num = sensors.GetSensor<SafeCellSensor>().GetCellQuery();
      if (num == Grid.InvalidCell)
        num = Grid.PosToCell(transform.GetPosition());
      Vector3 posCbc = Grid.CellToPosCBC(num, Grid.SceneLayer.Move);
      Grid.Reserved[num] = true;
      return (ChoreHelpers.CreateLocator(locatorName, posCbc), num);
    }

    public void CreateLocator()
    {
      GameObject gameObject;
      (gameObject, this.locatorCell) = EatChore.StatesInstance.CreateLocator(this.sm.eater.Get<Sensors>(this.smi), this.sm.eater.Get<Transform>(this.smi), "EatLocator");
      this.sm.locator.Set(gameObject, this, false);
    }

    public void DestroyLocator()
    {
      Grid.Reserved[this.locatorCell] = false;
      ChoreHelpers.DestroyLocator(this.sm.locator.Get(this));
      this.sm.locator.Set((KMonoBehaviour) null, this);
    }

    public static void SetZ(GameObject go, float z)
    {
      Vector3 position = go.transform.GetPosition() with
      {
        z = z
      };
      go.transform.SetPosition(position);
    }

    public static void ApplyRoomAndSaltEffects(
      GameObject messStation,
      GameObject diner,
      float? effectDurationOverride = null)
    {
      Effects component1 = diner.GetComponent<Effects>();
      Room roomOfGameObject = Game.Instance.roomProber.GetRoomOfGameObject(messStation);
      Storage component2 = messStation.GetComponent<Storage>();
      EffectInstance effectInstance1 = (EffectInstance) null;
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.Has(TableSaltConfig.ID.ToTag()))
      {
        component2.ConsumeIgnoringDisease(TableSaltConfig.ID.ToTag(), TableSaltTuning.CONSUMABLE_RATE);
        effectInstance1 = component1.Add("MessTableSalt", true);
        messStation.Trigger(1356255274);
      }
      if (effectDurationOverride.HasValue)
      {
        List<EffectInstance> result = (List<EffectInstance>) null;
        roomOfGameObject?.roomType.TriggerRoomEffects(messStation.GetComponent<KPrefabID>(), component1, out result);
        if (effectInstance1 != null)
        {
          if (result == null)
            result = new List<EffectInstance>();
          result.Add(effectInstance1);
        }
        if (result == null)
          return;
        foreach (EffectInstance effectInstance2 in result)
          effectInstance2.timeRemaining = effectDurationOverride.Value;
      }
      else
        roomOfGameObject?.roomType.TriggerRoomEffects(messStation.GetComponent<KPrefabID>(), component1);
    }
  }

  public class States : GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore>
  {
    public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.TargetParameter eater;
    public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.TargetParameter ediblesource;
    public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.TargetParameter ediblechunk;
    public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.TargetParameter messstation;
    public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.FloatParameter requestedfoodunits;
    public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.FloatParameter actualfoodunits;
    public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.TargetParameter locator;
    public GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State chooseaction;
    public EatChore.States.RehydrateSubState rehydrate;
    public GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.FetchSubState fetch;
    public EatChore.States.EatOnFloorState eatonfloorstate;
    public EatChore.States.EatAtMessStationState eatatmessstation;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.chooseaction;
      this.Target(this.eater);
      this.root.Enter("SetMessStation", (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi => smi.UpdateMessStation())).EventHandler(GameHashes.AssignablesChanged, (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi => smi.UpdateMessStation()));
      this.chooseaction.EnterTransition((GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.rehydrate, (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.Transition.ConditionCallback) (smi => this.ediblesource.Get(smi).HasTag(GameTags.Dehydrated))).EnterTransition((GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.fetch, (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.Transition.ConditionCallback) (smi => true));
      this.rehydrate.Enter((StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi =>
      {
        DehydratedFoodPackage component = this.ediblesource.Get(smi).GetComponent<Pickupable>().storage.gameObject.GetComponent<DehydratedFoodPackage>();
        this.rehydrate.foodpackage.Set((KMonoBehaviour) component, smi);
        this.rehydrate.rehydrator.Set((UnityEngine.Object) component.Rehydrator != (UnityEngine.Object) null ? component.Rehydrator.GetComponent<AccessabilityManager>() : (AccessabilityManager) null, smi);
        AccessabilityManager accessabilityManager = this.rehydrate.rehydrator.Get(smi);
        if ((UnityEngine.Object) accessabilityManager != (UnityEngine.Object) null)
        {
          GameObject worker = this.eater.Get(smi);
          if (accessabilityManager.CanAccess(worker))
            accessabilityManager.Reserve(this.eater.Get(smi));
          else
            smi.GoTo((StateMachine.BaseState) null);
        }
        else
          smi.GoTo((StateMachine.BaseState) null);
      })).Exit((StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi =>
      {
        AccessabilityManager accessabilityManager = this.rehydrate.rehydrator.Get(smi);
        if (!((UnityEngine.Object) accessabilityManager != (UnityEngine.Object) null))
          return;
        accessabilityManager.Unreserve();
      })).DefaultState((GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.rehydrate.approach);
      this.rehydrate.approach.InitializeStates(this.eater, this.rehydrate.foodpackage, this.rehydrate.work, tactic: NavigationTactics.ReduceTravelDistance).OnTargetLost(this.ediblesource, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) null);
      this.rehydrate.work.ToggleWork("Rehydrate", (Action<EatChore.StatesInstance>) (smi => this.eater.Get<WorkerBase>(smi).StartWork((WorkerBase.StartWorkInfo) new DehydratedFoodPackage.RehydrateStartWorkItem(this.rehydrate.foodpackage.Get<DehydratedFoodPackage>(smi), (Action<GameObject>) (result => this.ediblechunk.Set(result, smi, false))))), (Func<EatChore.StatesInstance, bool>) (smi =>
      {
        AccessabilityManager accessabilityManager = this.rehydrate.rehydrator.Get(smi);
        return !((UnityEngine.Object) accessabilityManager == (UnityEngine.Object) null) && accessabilityManager.CanAccess(this.eater.Get<WorkerBase>(smi).gameObject);
      }), (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.eatatmessstation, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) null);
      this.fetch.InitializeStates(this.eater, this.ediblesource, this.ediblechunk, this.requestedfoodunits, this.actualfoodunits, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.eatatmessstation);
      this.eatatmessstation.DefaultState((GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.eatatmessstation.moveto).ParamTransition<GameObject>((StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.Parameter<GameObject>) this.messstation, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.eatonfloorstate, (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.Parameter<GameObject>.Callback) ((smi, p) => (UnityEngine.Object) p == (UnityEngine.Object) null)).ParamTransition<GameObject>((StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.Parameter<GameObject>) this.messstation, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.eatonfloorstate, (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.Parameter<GameObject>.Callback) ((smi, p) => (UnityEngine.Object) p != (UnityEngine.Object) null && !p.GetComponent<Operational>().IsOperational));
      this.eatatmessstation.moveto.InitializeStates(this.eater, this.messstation, this.eatatmessstation.eat, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.eatonfloorstate);
      this.eatatmessstation.eat.Enter("AnimOverride", (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi => smi.GetComponent<KAnimControllerBase>().AddAnimOverrides(Assets.GetAnim((HashedString) "anim_eat_table_kanim")))).DoEat(this.ediblechunk, this.actualfoodunits, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) null, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) null).Enter((StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi =>
      {
        GameObject gameObject = this.eater.Get(smi);
        EatChore.StatesInstance.SetZ(gameObject, Grid.GetLayerZ(Grid.SceneLayer.BuildingFront));
        EatChore.StatesInstance.ApplyRoomAndSaltEffects(this.messstation.Get(smi), gameObject);
      })).Exit((StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi =>
      {
        EatChore.StatesInstance.SetZ(this.eater.Get(smi), Grid.GetLayerZ(Grid.SceneLayer.Move));
        smi.GetComponent<KAnimControllerBase>().RemoveAnimOverrides(Assets.GetAnim((HashedString) "anim_eat_table_kanim"));
      }));
      this.eatonfloorstate.DefaultState((GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) this.eatonfloorstate.moveto).Enter("CreateLocator", (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi => smi.CreateLocator())).Exit("DestroyLocator", (StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State.Callback) (smi => smi.DestroyLocator()));
      this.eatonfloorstate.moveto.InitializeStates(this.eater, this.locator, this.eatonfloorstate.eat, this.eatonfloorstate.eat);
      this.eatonfloorstate.eat.ToggleAnims("anim_eat_floor_kanim").DoEat(this.ediblechunk, this.actualfoodunits, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) null, (GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State) null);
    }

    public class EatOnFloorState : 
      GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State
    {
      public GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.ApproachSubState<IApproachable> moveto;
      public GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State eat;
    }

    public class EatAtMessStationState : 
      GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State
    {
      public GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.ApproachSubState<MessStation> moveto;
      public GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State eat;
    }

    public class RehydrateSubState : 
      GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State
    {
      public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.TargetParameter foodpackage;
      public StateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.ObjectParameter<AccessabilityManager> rehydrator;
      public GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.ApproachSubState<DehydratedFoodPackage> approach;
      public GameStateMachine<EatChore.States, EatChore.StatesInstance, EatChore, object>.State work;
    }
  }
}
