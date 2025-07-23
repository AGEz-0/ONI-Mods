// Decompiled with JetBrains decompiler
// Type: MilkSeparator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MilkSeparator : 
  GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>
{
  public const string WORK_PRE_ANIM_NAME = "separating_pre";
  public const string WORK_ANIM_NAME = "separating_loop";
  public const string WORK_POST_ANIM_NAME = "separating_pst";
  public GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State noOperational;
  public MilkSeparator.OperationalStates operational;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.noOperational;
    this.serializable = StateMachine.SerializeType.ParamsOnly;
    this.root.EventHandler(GameHashes.OnStorageChange, new StateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State.Callback(MilkSeparator.RefreshMeters));
    this.noOperational.TagTransition(GameTags.Operational, (GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State) this.operational).PlayAnim("off");
    this.operational.TagTransition(GameTags.Operational, this.noOperational, true).PlayAnim("on").DefaultState(this.operational.idle);
    this.operational.idle.EventTransition(GameHashes.OnStorageChange, this.operational.working.pre, new StateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.Transition.ConditionCallback(MilkSeparator.CanBeginSeparate)).EnterTransition(this.operational.full, new StateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.Transition.ConditionCallback(MilkSeparator.RequiresEmptying));
    this.operational.working.pre.QueueAnim("separating_pre").OnAnimQueueComplete(this.operational.working.work);
    this.operational.working.work.Enter(new StateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State.Callback(MilkSeparator.BeginSeparation)).PlayAnim("separating_loop", KAnim.PlayMode.Loop).EventTransition(GameHashes.OnStorageChange, this.operational.working.post, new StateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.Transition.ConditionCallback(MilkSeparator.CanNOTKeepSeparating)).Exit(new StateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State.Callback(MilkSeparator.EndSeparation));
    this.operational.working.post.QueueAnim("separating_pst").OnAnimQueueComplete(this.operational.idle);
    this.operational.full.PlayAnim("ready").ToggleRecurringChore(new Func<MilkSeparator.Instance, Chore>(MilkSeparator.CreateEmptyChore)).WorkableCompleteTransition((Func<MilkSeparator.Instance, Workable>) (smi => (Workable) smi.workable), this.operational.emptyComplete).ToggleStatusItem(Db.Get().BuildingStatusItems.MilkSeparatorNeedsEmptying);
    this.operational.emptyComplete.Enter(new StateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State.Callback(MilkSeparator.DropMilkFat)).ScheduleActionNextFrame("AfterMilkFatDrop", (System.Action<MilkSeparator.Instance>) (smi => smi.GoTo((StateMachine.BaseState) this.operational.idle)));
  }

  public static void BeginSeparation(MilkSeparator.Instance smi) => smi.operational.SetActive(true);

  public static void EndSeparation(MilkSeparator.Instance smi) => smi.operational.SetActive(false);

  public static bool CanBeginSeparate(MilkSeparator.Instance smi)
  {
    return !smi.MilkFatLimitReached && smi.elementConverter.HasEnoughMassToStartConverting();
  }

  public static bool CanKeepSeparating(MilkSeparator.Instance smi)
  {
    return !smi.MilkFatLimitReached && smi.elementConverter.CanConvertAtAll();
  }

  public static bool CanNOTKeepSeparating(MilkSeparator.Instance smi)
  {
    return !MilkSeparator.CanKeepSeparating(smi);
  }

  public static bool RequiresEmptying(MilkSeparator.Instance smi) => smi.MilkFatLimitReached;

  public static bool ThereIsCapacityForMilkFat(MilkSeparator.Instance smi)
  {
    return !smi.MilkFatLimitReached;
  }

  public static void DropMilkFat(MilkSeparator.Instance smi) => smi.DropMilkFat();

  public static void RefreshMeters(MilkSeparator.Instance smi) => smi.RefreshMeters();

  private static Chore CreateEmptyChore(MilkSeparator.Instance smi)
  {
    WorkChore<EmptyMilkSeparatorWorkable> emptyChore = new WorkChore<EmptyMilkSeparatorWorkable>(Db.Get().ChoreTypes.EmptyStorage, (IStateMachineTarget) smi.workable);
    emptyChore.AddPrecondition(ChorePreconditions.instance.IsNotARobot, (object) null);
    return (Chore) emptyChore;
  }

  public class Def : StateMachine.BaseDef
  {
    public float MILK_FAT_CAPACITY = 100f;
    public Tag MILK_TAG;
    public Tag MILK_FAT_TAG;

    public Def()
    {
      this.MILK_FAT_TAG = ElementLoader.FindElementByHash(SimHashes.MilkFat).tag;
      this.MILK_TAG = ElementLoader.FindElementByHash(SimHashes.Milk).tag;
    }
  }

  public class WorkingStates : 
    GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State
  {
    public GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State pre;
    public GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State work;
    public GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State post;
  }

  public class OperationalStates : 
    GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State
  {
    public GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State idle;
    public MilkSeparator.WorkingStates working;
    public GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State full;
    public GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.State emptyComplete;
  }

  public new class Instance : 
    GameStateMachine<MilkSeparator, MilkSeparator.Instance, IStateMachineTarget, MilkSeparator.Def>.GameInstance
  {
    [MyCmpGet]
    public EmptyMilkSeparatorWorkable workable;
    [MyCmpGet]
    public Operational operational;
    [MyCmpGet]
    public ElementConverter elementConverter;
    [MyCmpGet]
    private Storage storage;
    private MeterController fatMeter;

    public float MilkFatStored => this.storage.GetAmountAvailable(this.def.MILK_FAT_TAG);

    public float MilkFatStoragePercentage
    {
      get => Mathf.Clamp(this.MilkFatStored / this.def.MILK_FAT_CAPACITY, 0.0f, 1f);
    }

    public bool MilkFatLimitReached
    {
      get => (double) this.MilkFatStored >= (double) this.def.MILK_FAT_CAPACITY;
    }

    public Instance(IStateMachineTarget master, MilkSeparator.Def def)
      : base(master, def)
    {
      this.fatMeter = new MeterController((KAnimControllerBase) this.GetComponent<KBatchedAnimController>(), "meter_target_1", "meter_fat", Meter.Offset.Infront, Grid.SceneLayer.NoLayer, new string[1]
      {
        "meter_target_1"
      });
    }

    public override void StartSM()
    {
      base.StartSM();
      this.workable.OnWork_PST_Begins = new System.Action(this.Play_Empty_MeterAnimation);
      this.RefreshMeters();
    }

    private void Play_Empty_MeterAnimation()
    {
      this.fatMeter.SetPositionPercent(0.0f);
      this.fatMeter.meterController.Play((HashedString) "meter_fat_empty");
    }

    public void DropMilkFat()
    {
      List<GameObject> obj_list = new List<GameObject>();
      this.storage.Drop(this.def.MILK_FAT_TAG, obj_list);
      Vector3 dropSpawnLocation = this.GetDropSpawnLocation();
      foreach (GameObject gameObject in obj_list)
        gameObject.transform.position = dropSpawnLocation;
    }

    private Vector3 GetDropSpawnLocation()
    {
      Vector3 column = (Vector3) this.GetComponent<KBatchedAnimController>().GetSymbolTransform(new HashedString("milkfat"), out bool _).GetColumn(3) with
      {
        z = Grid.GetLayerZ(Grid.SceneLayer.Ore)
      };
      int cell = Grid.PosToCell(column);
      return Grid.IsValidCell(cell) && !Grid.Solid[cell] ? column : this.transform.GetPosition();
    }

    public void RefreshMeters()
    {
      if (this.fatMeter.meterController.currentAnim != (HashedString) "meter_fat")
        this.fatMeter.meterController.Play((HashedString) "meter_fat", KAnim.PlayMode.Paused);
      this.fatMeter.SetPositionPercent(this.MilkFatStoragePercentage);
    }
  }
}
