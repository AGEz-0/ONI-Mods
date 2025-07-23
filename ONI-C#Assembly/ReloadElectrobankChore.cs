// Decompiled with JetBrains decompiler
// Type: ReloadElectrobankChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class ReloadElectrobankChore : Chore<ReloadElectrobankChore.Instance>
{
  public const float LOOP_LENGTH = 4.333f;
  public static readonly Chore.Precondition ElectrobankIsNotNull = new Chore.Precondition()
  {
    id = nameof (ElectrobankIsNotNull),
    description = (string) DUPLICANTS.CHORES.PRECONDITIONS.EDIBLE_IS_NOT_NULL,
    fn = (Chore.PreconditionFn) ((ref Chore.Precondition.Context context, object data) => (UnityEngine.Object) null != (UnityEngine.Object) context.consumerState.consumer.GetSMI<BionicBatteryMonitor.Instance>().GetClosestElectrobank())
  };

  public ReloadElectrobankChore(IStateMachineTarget target)
    : base(Db.Get().ChoreTypes.ReloadElectrobank, target, target.GetComponent<ChoreProvider>(), false, master_priority_class: PriorityScreen.PriorityClass.personalNeeds)
  {
    this.smi = new ReloadElectrobankChore.Instance(this, target.gameObject);
    this.AddPrecondition(ChorePreconditions.instance.IsNotRedAlert, (object) null);
    this.AddPrecondition(ReloadElectrobankChore.ElectrobankIsNotNull, (object) null);
  }

  public override void Begin(Chore.Precondition.Context context)
  {
    if ((UnityEngine.Object) context.consumerState.consumer == (UnityEngine.Object) null)
    {
      Debug.LogError((object) "ReloadElectrobankChore null context.consumer");
    }
    else
    {
      BionicBatteryMonitor.Instance smi = context.consumerState.consumer.GetSMI<BionicBatteryMonitor.Instance>();
      if (smi == null)
      {
        Debug.LogError((object) "ReloadElectrobankChore null BionicBatteryMonitor.Instance");
      }
      else
      {
        Electrobank closestElectrobank = smi.GetClosestElectrobank();
        if ((UnityEngine.Object) closestElectrobank == (UnityEngine.Object) null)
        {
          Debug.LogError((object) "ReloadElectrobankChore null electrobank.gameObject");
        }
        else
        {
          this.smi.sm.electrobankSource.Set(closestElectrobank.gameObject, this.smi, false);
          double num = (double) this.smi.sm.amountRequested.Set(closestElectrobank.GetComponent<PrimaryElement>().Mass, this.smi);
          this.smi.sm.dupe.Set((KMonoBehaviour) context.consumerState.consumer, this.smi);
          base.Begin(context);
        }
      }
    }
  }

  public bool IsInstallingAtMessStation()
  {
    return this.smi.IsInsideState((StateMachine.BaseState) this.smi.sm.installAtMessStation.install);
  }

  public static bool HasAnyDepletedBattery(ReloadElectrobankChore.Instance smi)
  {
    return (UnityEngine.Object) ReloadElectrobankChore.GetAnyEmptyBattery(smi) != (UnityEngine.Object) null;
  }

  public static GameObject GetAnyEmptyBattery(ReloadElectrobankChore.Instance smi)
  {
    return smi.batteryMonitor.storage.FindFirst(GameTags.EmptyPortableBattery);
  }

  public static void RemoveDepletedElectrobank(ReloadElectrobankChore.Instance smi)
  {
    GameObject anyEmptyBattery = ReloadElectrobankChore.GetAnyEmptyBattery(smi);
    if (!((UnityEngine.Object) anyEmptyBattery != (UnityEngine.Object) null))
      return;
    smi.batteryMonitor.storage.Drop(anyEmptyBattery, true);
  }

  public static void InstallElectrobank(ReloadElectrobankChore.Instance smi)
  {
    Storage[] components = smi.gameObject.GetComponents<Storage>();
    for (int index = 0; index < components.Length; ++index)
    {
      if ((UnityEngine.Object) components[index] != (UnityEngine.Object) smi.batteryMonitor.storage && (UnityEngine.Object) components[index].FindFirst(GameTags.ChargedPortableBattery) != (UnityEngine.Object) null)
      {
        components[index].Transfer(smi.batteryMonitor.storage);
        break;
      }
    }
    Tutorial.Instance.TutorialMessage(Tutorial.TutorialMessages.TM_BionicBattery);
  }

  private static void SetStoredItemVisibility(GameObject item, bool visible)
  {
    if ((UnityEngine.Object) item == (UnityEngine.Object) null)
      return;
    KBatchedAnimTracker component = item.GetComponent<KBatchedAnimTracker>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      component.enabled = visible;
    Storage.MakeItemInvisible(item, !visible, false);
  }

  public class States : 
    GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore>
  {
    public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.FetchSubState fetch;
    public ReloadElectrobankChore.States.InstallAtMessStation installAtMessStation;
    public ReloadElectrobankChore.States.InstallAtSafeLocation installAtSafeLocation;
    public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State complete;
    public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State electrobankLost;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.TargetParameter dupe;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.TargetParameter electrobankSource;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.TargetParameter lastDepletedElectrobankFound;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.TargetParameter pickedUpElectrobank;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.TargetParameter messstation;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.TargetParameter safeLocation;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.FloatParameter actualunits;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.FloatParameter amountRequested;
    public StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.IntParameter safeCellIndex;
    public KAnim.Build.Symbol defaultElectrobankSymbol;
    public KAnim.Build.Symbol depletedElectrobankSymbol;
    private const float ROOM_EFFECT_DURATION = 1800f;

    private bool IsMessStationInvalid(GameObject messStation)
    {
      return (UnityEngine.Object) messStation == (UnityEngine.Object) null || !messStation.GetComponent<Operational>().IsOperational;
    }

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      this.defaultElectrobankSymbol = Assets.GetPrefab((Tag) "Electrobank").GetComponent<KBatchedAnimController>().AnimFiles[0].GetData().build.GetSymbolByIndex(0U);
      this.depletedElectrobankSymbol = Assets.GetPrefab((Tag) "EmptyElectrobank").GetComponent<KBatchedAnimController>().AnimFiles[0].GetData().build.GetSymbolByIndex(0U);
      default_state = (StateMachine.BaseState) this.fetch;
      this.Target(this.dupe);
      this.root.Enter("SetMessStation", (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi => smi.UpdateMessStation())).EventHandler(GameHashes.AssignablesChanged, (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi => smi.UpdateMessStation()));
      this.fetch.InitializeStates(this.dupe, this.electrobankSource, this.pickedUpElectrobank, this.amountRequested, this.actualunits, (GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtMessStation).OnTargetLost(this.electrobankSource, this.electrobankLost);
      this.installAtMessStation.Enter((StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi => EatChore.StatesInstance.SetZ(this.pickedUpElectrobank.Get(smi), Grid.GetLayerZ(Grid.SceneLayer.Ore)))).EnterTransition((GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtSafeLocation, (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.Transition.ConditionCallback) (smi => this.IsMessStationInvalid(this.messstation.Get(smi)))).DefaultState((GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtMessStation.approach).ParamTransition<GameObject>((StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.Parameter<GameObject>) this.messstation, (GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtSafeLocation, (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.Parameter<GameObject>.Callback) ((_, messStation) => this.IsMessStationInvalid(messStation)));
      this.installAtMessStation.approach.InitializeStates(this.dupe, this.messstation, (GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtMessStation.removeDepletedBatteries, (GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtSafeLocation);
      this.installAtMessStation.removeDepletedBatteries.InitializeStates((GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtMessStation.install);
      this.installAtMessStation.install.InitializeStates(this.complete, (ReloadElectrobankChore.States.IInstallBatteryAnim) new ReloadElectrobankChore.States.MessStationInstallBatteryAnim()).Enter((StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi =>
      {
        GameObject gameObject = this.dupe.Get(smi);
        EatChore.StatesInstance.SetZ(gameObject, Grid.GetLayerZ(Grid.SceneLayer.BuildingFront));
        EatChore.StatesInstance.SetZ(this.pickedUpElectrobank.Get(smi), Grid.GetLayerZ(Grid.SceneLayer.Ore));
        EatChore.StatesInstance.ApplyRoomAndSaltEffects(this.messstation.Get(smi), gameObject, new float?(1800f));
      })).Exit((StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi => EatChore.StatesInstance.SetZ(this.dupe.Get(smi), Grid.GetLayerZ(Grid.SceneLayer.Move))));
      this.installAtSafeLocation.Enter("CreateSafeLocation", (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi =>
      {
        (GameObject gameObject2, int num2) = EatChore.StatesInstance.CreateLocator(this.dupe.Get<Sensors>(smi), this.dupe.Get<Transform>(smi), "ReloadElectrobankLocator");
        this.safeLocation.Set(gameObject2, smi, false);
        this.safeCellIndex.Set(num2, smi);
      })).Exit("DestroySafeLocation", (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi =>
      {
        Grid.Reserved[this.safeCellIndex.Get(smi)] = false;
        ChoreHelpers.DestroyLocator(this.safeLocation.Get(smi));
        this.safeLocation.Set((KMonoBehaviour) null, smi);
      })).DefaultState((GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtSafeLocation.approach);
      this.installAtSafeLocation.approach.InitializeStates(this.dupe, this.safeLocation, (GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtSafeLocation.removeDepletedBatteries, (GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtSafeLocation.removeDepletedBatteries);
      this.installAtSafeLocation.removeDepletedBatteries.InitializeStates((GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State) this.installAtSafeLocation.install);
      this.installAtSafeLocation.install.InitializeStates(this.complete, (ReloadElectrobankChore.States.IInstallBatteryAnim) new ReloadElectrobankChore.States.DefaultInstallBatteryAnim());
      this.complete.Enter(new StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback(ReloadElectrobankChore.InstallElectrobank)).ReturnSuccess();
      this.electrobankLost.Target(this.dupe).TriggerOnEnter(GameHashes.TargetElectrobankLost).ReturnFailure();
    }

    public class RemoveDepletedBatteries : 
      GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State
    {
      public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State animate;
      public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State end;

      public ReloadElectrobankChore.States.RemoveDepletedBatteries InitializeStates(
        GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State nextState)
      {
        this.DefaultState(this.animate).EnterTransition(nextState, (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.Transition.ConditionCallback) (smi => !ReloadElectrobankChore.HasAnyDepletedBattery(smi)));
        this.animate.ToggleAnims("anim_bionic_kanim").PlayAnim("discharge", KAnim.PlayMode.Once).Enter("Add Symbol Override", (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi => smi.ShowElectrobankSymbol(true, smi.sm.depletedElectrobankSymbol))).Exit("Revert Symbol Override", (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi => smi.ShowElectrobankSymbol(false, smi.sm.depletedElectrobankSymbol))).OnAnimQueueComplete(this.end);
        this.end.Enter(new StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback(ReloadElectrobankChore.RemoveDepletedElectrobank)).EnterTransition(this.animate, new StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.Transition.ConditionCallback(ReloadElectrobankChore.HasAnyDepletedBattery)).GoTo(nextState);
        return this;
      }
    }

    public interface IInstallBatteryAnim
    {
      string GetBank();

      string GetPrefix(
        ReloadElectrobankChore.Instance smi,
        ReloadElectrobankChore.States.IInstallBatteryAnim.Anim anim);

      bool ForceFacing();

      enum Anim
      {
        Pre,
        Loop,
        Pst,
      }
    }

    public class DefaultInstallBatteryAnim : ReloadElectrobankChore.States.IInstallBatteryAnim
    {
      public string GetBank() => "anim_bionic_kanim";

      public string GetPrefix(
        ReloadElectrobankChore.Instance _smi,
        ReloadElectrobankChore.States.IInstallBatteryAnim.Anim _anim)
      {
        return "consume";
      }

      public bool ForceFacing() => false;
    }

    public class MessStationInstallBatteryAnim : ReloadElectrobankChore.States.IInstallBatteryAnim
    {
      public string GetBank() => "anim_bionic_eat_table_kanim";

      public string GetPrefix(
        ReloadElectrobankChore.Instance smi,
        ReloadElectrobankChore.States.IInstallBatteryAnim.Anim anim)
      {
        MinionResume component1 = smi.GetComponent<MinionResume>();
        bool flag1 = (UnityEngine.Object) component1 != (UnityEngine.Object) null && component1.CurrentHat != null;
        bool flag2 = false;
        GameObject gameObject = smi.sm.messstation.Get(smi);
        if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
        {
          MessStation component2 = gameObject.GetComponent<MessStation>();
          if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && component2.HasSalt)
            flag2 = true;
        }
        if (flag2 & flag1)
          return "salt_hat";
        if (flag2)
          return "salt";
        return flag1 && anim != ReloadElectrobankChore.States.IInstallBatteryAnim.Anim.Loop ? "hat" : "working";
      }

      public bool ForceFacing() => true;
    }

    public class InstallBattery : 
      GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State
    {
      public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State pre;
      public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State loop;
      public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State pst;

      public ReloadElectrobankChore.States.InstallBattery InitializeStates(
        GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State nextState,
        ReloadElectrobankChore.States.IInstallBatteryAnim anim)
      {
        this.DefaultState(this.pre).ToggleAnims(anim.GetBank()).Enter("Add Symbol Override", (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi =>
        {
          smi.StowElectrobank(false);
          if (!anim.ForceFacing())
            return;
          Facing component = smi.GetComponent<Facing>();
          if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
            return;
          component.SetFacing(false);
        })).Exit("Revert Symbol Override", (StateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State.Callback) (smi => smi.StowElectrobank(true)));
        this.pre.PlayAnim((Func<ReloadElectrobankChore.Instance, string>) (smi => anim.GetPrefix(smi, ReloadElectrobankChore.States.IInstallBatteryAnim.Anim.Pre) + "_pre")).OnAnimQueueComplete(this.loop).ScheduleGoTo(5f, (StateMachine.BaseState) this.loop);
        this.loop.PlayAnim((Func<ReloadElectrobankChore.Instance, string>) (smi => anim.GetPrefix(smi, ReloadElectrobankChore.States.IInstallBatteryAnim.Anim.Loop) + "_loop"), KAnim.PlayMode.Loop).ScheduleGoTo(4.333f, (StateMachine.BaseState) this.pst);
        this.pst.PlayAnim((Func<ReloadElectrobankChore.Instance, string>) (smi => anim.GetPrefix(smi, ReloadElectrobankChore.States.IInstallBatteryAnim.Anim.Pst) + "_pst")).OnAnimQueueComplete(nextState).ScheduleGoTo(5f, (StateMachine.BaseState) nextState);
        return this;
      }
    }

    public class InstallAtMessStation : 
      GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State
    {
      public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.ApproachSubState<MessStation> approach;
      public ReloadElectrobankChore.States.RemoveDepletedBatteries removeDepletedBatteries;
      public ReloadElectrobankChore.States.InstallBattery install;
    }

    public class InstallAtSafeLocation : 
      GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.State
    {
      public GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.ApproachSubState<IApproachable> approach;
      public ReloadElectrobankChore.States.RemoveDepletedBatteries removeDepletedBatteries;
      public ReloadElectrobankChore.States.InstallBattery install;
    }
  }

  public class Instance(ReloadElectrobankChore master, GameObject duplicant) : 
    GameStateMachine<ReloadElectrobankChore.States, ReloadElectrobankChore.Instance, ReloadElectrobankChore, object>.GameInstance(master)
  {
    private static readonly string SYMBOL_NAME = "object";

    public BionicBatteryMonitor.Instance batteryMonitor
    {
      get => this.sm.dupe.Get(this).GetSMI<BionicBatteryMonitor.Instance>();
    }

    public void UpdateMessStation()
    {
      this.sm.messstation.Set((KMonoBehaviour) EatChore.StatesInstance.GetPreferredMessStation(this.sm.dupe.Get(this).GetComponent<MinionIdentity>()), this);
    }

    public void ShowElectrobankSymbol(bool show, KAnim.Build.Symbol symbol)
    {
      SymbolOverrideController component = this.GetComponent<SymbolOverrideController>();
      if (show)
        component.AddSymbolOverride((HashedString) ReloadElectrobankChore.Instance.SYMBOL_NAME, symbol);
      else
        component.RemoveSymbolOverride((HashedString) ReloadElectrobankChore.Instance.SYMBOL_NAME);
      this.GetComponent<KBatchedAnimController>().SetSymbolVisiblity((KAnimHashedString) ReloadElectrobankChore.Instance.SYMBOL_NAME, show);
    }

    public void StowElectrobank(bool stow)
    {
      GameObject gameObject = this.sm.pickedUpElectrobank.Get(this);
      ReloadElectrobankChore.SetStoredItemVisibility(gameObject, stow);
      KAnim.Build.Symbol symbol = (UnityEngine.Object) gameObject != (UnityEngine.Object) null ? gameObject.GetComponent<KBatchedAnimController>().AnimFiles[0].GetData().build.GetSymbolByIndex(0U) : this.sm.defaultElectrobankSymbol;
      this.ShowElectrobankSymbol(!stow, symbol);
    }
  }
}
