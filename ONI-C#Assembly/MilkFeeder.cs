// Decompiled with JetBrains decompiler
// Type: MilkFeeder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MilkFeeder : 
  GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>
{
  private GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State off;
  private MilkFeeder.OnState on;
  public StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.BoolParameter isReadyToStartFeeding;
  public StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.ObjectParameter<DrinkMilkStates.Instance> currentFeedingCritter;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.off;
    this.root.Enter((StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State.Callback) (smi => smi.UpdateStorageMeter())).EventHandler(GameHashes.OnStorageChange, (StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State.Callback) (smi => smi.UpdateStorageMeter()));
    this.off.PlayAnim("off").EventTransition(GameHashes.OperationalChanged, (GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State) this.on, (StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.Transition.ConditionCallback) (smi => smi.GetComponent<Operational>().IsOperational));
    this.on.DefaultState(this.on.pre).EventTransition(GameHashes.OperationalChanged, this.on.pst, (StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.Transition.ConditionCallback) (smi => !smi.GetComponent<Operational>().IsOperational && smi.GetCurrentState() != this.on.pre)).EventTransition(GameHashes.OperationalChanged, this.off, (StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.Transition.ConditionCallback) (smi => !smi.GetComponent<Operational>().IsOperational && smi.GetCurrentState() == this.on.pre));
    this.on.pre.PlayAnim("working_pre").OnAnimQueueComplete((GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State) this.on.working);
    this.on.working.PlayAnim("on").DefaultState(this.on.working.empty);
    this.on.working.empty.PlayAnim("empty").EnterTransition(this.on.working.refilling, (StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.Transition.ConditionCallback) (smi => smi.HasEnoughMilkForOneFeeding())).EventHandler(GameHashes.OnStorageChange, (StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State.Callback) (smi =>
    {
      if (!smi.HasEnoughMilkForOneFeeding())
        return;
      smi.GoTo((StateMachine.BaseState) this.on.working.refilling);
    }));
    this.on.working.refilling.PlayAnim("fill").OnAnimQueueComplete(this.on.working.full);
    this.on.working.full.PlayAnim("full").Enter((StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State.Callback) (smi => this.isReadyToStartFeeding.Set(true, smi))).Exit((StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State.Callback) (smi => this.isReadyToStartFeeding.Set(false, smi))).ParamTransition<DrinkMilkStates.Instance>((StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.Parameter<DrinkMilkStates.Instance>) this.currentFeedingCritter, this.on.working.emptying, (StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.Parameter<DrinkMilkStates.Instance>.Callback) ((smi, val) => val != null));
    this.on.working.emptying.EnterTransition(this.on.working.full, (StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.Transition.ConditionCallback) (smi =>
    {
      DrinkMilkMonitor.Instance smi1 = this.currentFeedingCritter.Get(smi).GetSMI<DrinkMilkMonitor.Instance>();
      return smi1 != null && !smi1.def.consumesMilk;
    })).PlayAnim("emptying").OnAnimQueueComplete(this.on.working.empty).Exit((StateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State.Callback) (smi => smi.StopFeeding()));
    this.on.pst.PlayAnim("working_pst").OnAnimQueueComplete(this.off);
  }

  public class Def : StateMachine.BaseDef, IGameObjectEffectDescriptor
  {
    public List<Descriptor> GetDescriptors(GameObject go)
    {
      List<Descriptor> descs = new List<Descriptor>();
      go.GetSMI<MilkFeeder.Instance>();
      Descriptor descriptor = new Descriptor();
      descriptor.SetupDescriptor((string) CREATURES.MODIFIERS.GOTMILK.NAME, "");
      descs.Add(descriptor);
      Effect.AddModifierDescriptions(descs, "HadMilk", true, "STRINGS.CREATURES.STATS.");
      return descs;
    }
  }

  public class OnState : 
    GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State
  {
    public GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State pre;
    public MilkFeeder.OnState.WorkingState working;
    public GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State pst;

    public class WorkingState : 
      GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State
    {
      public GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State empty;
      public GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State refilling;
      public GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State full;
      public GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.State emptying;
    }
  }

  public new class Instance : 
    GameStateMachine<MilkFeeder, MilkFeeder.Instance, IStateMachineTarget, MilkFeeder.Def>.GameInstance
  {
    public Storage milkStorage;
    public MeterController storageMeter;

    public Instance(IStateMachineTarget master, MilkFeeder.Def def)
      : base(master, def)
    {
      this.milkStorage = this.GetComponent<Storage>();
      this.storageMeter = new MeterController((KAnimControllerBase) this.smi.GetComponent<KBatchedAnimController>(), "meter_target", "meter", Meter.Offset.Infront, Grid.SceneLayer.NoLayer, Array.Empty<string>());
    }

    public override void StartSM()
    {
      base.StartSM();
      Components.MilkFeeders.Add(this.smi.GetMyWorldId(), this);
    }

    protected override void OnCleanUp()
    {
      base.OnCleanUp();
      Components.MilkFeeders.Remove(this.smi.GetMyWorldId(), this);
    }

    public void UpdateStorageMeter()
    {
      this.storageMeter.SetPositionPercent(1f - Mathf.Clamp01(this.milkStorage.RemainingCapacity() / this.milkStorage.capacityKg));
    }

    public bool IsOperational() => this.GetComponent<Operational>().IsOperational;

    public bool IsReserved() => this.HasTag(GameTags.Creatures.ReservedByCreature);

    public void SetReserved(bool isReserved)
    {
      if (isReserved)
      {
        Debug.Assert(!this.HasTag(GameTags.Creatures.ReservedByCreature));
        this.GetComponent<KPrefabID>().SetTag(GameTags.Creatures.ReservedByCreature, true);
      }
      else if (this.HasTag(GameTags.Creatures.ReservedByCreature))
        this.GetComponent<KPrefabID>().RemoveTag(GameTags.Creatures.ReservedByCreature);
      else
        Debug.LogWarningFormat((UnityEngine.Object) this.smi.gameObject, "Tried to unreserve a MilkFeeder that wasn't reserved");
    }

    public bool IsReadyToStartFeeding()
    {
      return this.IsOperational() && this.sm.isReadyToStartFeeding.Get(this.smi);
    }

    public void RequestToStartFeeding(DrinkMilkStates.Instance feedingCritter)
    {
      this.sm.currentFeedingCritter.Set(feedingCritter, this.smi);
    }

    public void StopFeeding()
    {
      this.sm.currentFeedingCritter.Get(this.smi)?.RequestToStopFeeding();
      this.sm.currentFeedingCritter.Set((DrinkMilkStates.Instance) null, this.smi);
    }

    public bool HasEnoughMilkForOneFeeding()
    {
      return (double) this.milkStorage.GetAmountAvailable(MilkFeederConfig.MILK_TAG) >= 5.0;
    }

    public void ConsumeMilkForOneFeeding()
    {
      this.milkStorage.ConsumeIgnoringDisease(MilkFeederConfig.MILK_TAG, 5f);
    }

    public bool IsInCreaturePenRoom()
    {
      Room roomOfGameObject = Game.Instance.roomProber.GetRoomOfGameObject(this.gameObject);
      return roomOfGameObject != null && roomOfGameObject.roomType == Db.Get().RoomTypes.CreaturePen;
    }
  }
}
