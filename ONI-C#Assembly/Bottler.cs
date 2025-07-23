// Decompiled with JetBrains decompiler
// Type: Bottler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/Bottler")]
public class Bottler : Workable, IUserControlledCapacity
{
  [MyCmpAdd]
  private CopyBuildingSettings copyBuildingSettings;
  public Storage storage;
  public ConduitConsumer consumer;
  public CellOffset workCellOffset = new CellOffset(0, 0);
  [Serialize]
  public float userMaxCapacity = float.PositiveInfinity;
  private Bottler.Controller.Instance smi;
  private int storageHandle;
  private MeterController workerMeter;
  private static readonly EventSystem.IntraObjectHandler<Bottler> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<Bottler>((Action<Bottler, object>) ((component, data) => component.OnCopySettings(data)));

  public float UserMaxCapacity
  {
    get
    {
      return (UnityEngine.Object) this.consumer != (UnityEngine.Object) null ? Mathf.Min(this.userMaxCapacity, this.storage.capacityKg) : 0.0f;
    }
    set
    {
      this.userMaxCapacity = value;
      this.SetConsumerCapacity(value);
    }
  }

  public float AmountStored => this.storage.MassStored();

  public float MinCapacity => 0.0f;

  public float MaxCapacity => this.storage.capacityKg;

  public bool WholeValues => false;

  public LocString CapacityUnits => GameUtil.GetCurrentMassUnit();

  private Tag SourceTag
  {
    get
    {
      return this.smi.master.consumer.conduitType != ConduitType.Gas ? GameTags.LiquidSource : GameTags.GasSource;
    }
  }

  private Tag ElementTag
  {
    get => this.smi.master.consumer.conduitType != ConduitType.Gas ? GameTags.Liquid : GameTags.Gas;
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_bottler_kanim")
    };
    this.workAnims = new HashedString[1]
    {
      (HashedString) "pick_up"
    };
    this.workingPstComplete = (HashedString[]) null;
    this.workingPstFailed = (HashedString[]) null;
    this.synchronizeAnims = true;
    this.SetOffsets(new CellOffset[1]{ this.workCellOffset });
    this.SetWorkTime(this.overrideAnims[0].GetData().GetAnim("pick_up").totalTime);
    this.resetProgressOnStop = true;
    this.showProgressBar = false;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.smi = new Bottler.Controller.Instance(this);
    this.smi.StartSM();
    this.Subscribe<Bottler>(-905833192, Bottler.OnCopySettingsDelegate);
    this.UpdateStoredItemState();
    this.SetConsumerCapacity(this.userMaxCapacity);
  }

  protected override void OnForcedCleanUp()
  {
    if ((UnityEngine.Object) this.worker != (UnityEngine.Object) null)
    {
      ChoreDriver component = this.worker.GetComponent<ChoreDriver>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        component.StopChore();
      else
        this.worker.StopWork();
    }
    if (this.workerMeter != null)
      this.CleanupBottleProxyObject();
    base.OnForcedCleanUp();
  }

  protected override void OnStartWork(WorkerBase worker)
  {
    base.OnStartWork(worker);
    this.CreateBottleProxyObject(worker);
  }

  private void CreateBottleProxyObject(WorkerBase worker)
  {
    if (this.workerMeter != null)
      this.CleanupBottleProxyObject();
    PrimaryElement firstPrimaryElement = this.smi.master.GetFirstPrimaryElement();
    if ((UnityEngine.Object) firstPrimaryElement == (UnityEngine.Object) null)
      return;
    this.workerMeter = new MeterController((KAnimControllerBase) worker.GetComponent<KBatchedAnimController>(), "snapto_chest", "meter", Meter.Offset.Infront, Grid.SceneLayer.NoLayer, new string[1]
    {
      "snapto_chest"
    });
    this.workerMeter.meterController.SwapAnims(firstPrimaryElement.Element.substance.anims);
    this.workerMeter.meterController.Play((HashedString) "empty", KAnim.PlayMode.Paused);
    Color32 colour = firstPrimaryElement.Element.substance.colour with
    {
      a = byte.MaxValue
    };
    this.workerMeter.SetSymbolTint(new KAnimHashedString("meter_fill"), colour);
    this.workerMeter.SetSymbolTint(new KAnimHashedString("water1"), colour);
    this.workerMeter.SetSymbolTint(new KAnimHashedString("substance_tinter"), colour);
    this.workerMeter.SetSymbolTint(new KAnimHashedString("substance_tinter_cap"), colour);
  }

  private void CleanupBottleProxyObject()
  {
    if (this.workerMeter != null && !this.workerMeter.gameObject.IsNullOrDestroyed())
    {
      this.workerMeter.Unlink();
      this.workerMeter.gameObject.DeleteObject();
    }
    else
    {
      DebugUtil.DevLogError("Bottler finished work but could not clean up the proxy bottle object. workerMeter=" + this.workerMeter?.ToString());
      KCrashReporter.ReportDevNotification("Bottle emptier could not clean up proxy object", Environment.StackTrace);
    }
    this.workerMeter = (MeterController) null;
  }

  protected override void OnStopWork(WorkerBase worker)
  {
    base.OnStopWork(worker);
    this.CleanupBottleProxyObject();
  }

  protected override void OnAbortWork(WorkerBase worker)
  {
    base.OnAbortWork(worker);
    this.GetAnimController().Play((HashedString) "ready");
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    Storage component1 = worker.GetComponent<Storage>();
    Pickupable.PickupableStartWorkInfo startWorkInfo = (Pickupable.PickupableStartWorkInfo) worker.GetStartWorkInfo();
    if ((double) startWorkInfo.amount > 0.0)
      this.storage.TransferMass(component1, startWorkInfo.originalPickupable.KPrefabID.PrefabID(), startWorkInfo.amount);
    GameObject first = component1.FindFirst(startWorkInfo.originalPickupable.KPrefabID.PrefabID());
    if ((UnityEngine.Object) first != (UnityEngine.Object) null)
    {
      Pickupable component2;
      component2.targetWorkable = (Workable) (component2 = first.GetComponent<Pickupable>());
      component2.RemoveTag(this.SourceTag);
      component2.GetSMI<FetchableMonitor.Instance>()?.SetForceUnfetchable(false);
      startWorkInfo.setResultCb(first);
    }
    else
      startWorkInfo.setResultCb((GameObject) null);
    base.OnCompleteWork(worker);
  }

  private void OnReservationsChanged(
    Pickupable _ignore,
    bool _ignore2,
    Pickupable.Reservation _ignore3)
  {
    bool is_unfetchable = false;
    foreach (GameObject gameObject in this.storage.items)
    {
      if ((double) gameObject.GetComponent<Pickupable>().ReservedAmount > 0.0)
      {
        is_unfetchable = true;
        break;
      }
    }
    foreach (GameObject go in this.storage.items)
      go.GetSMI<FetchableMonitor.Instance>()?.SetForceUnfetchable(is_unfetchable);
  }

  private void SetConsumerCapacity(float value)
  {
    if (!((UnityEngine.Object) this.consumer != (UnityEngine.Object) null))
      return;
    this.consumer.capacityKG = value;
    float amount = this.storage.MassStored() - this.userMaxCapacity;
    if ((double) amount <= 0.0)
      return;
    this.storage.DropSome(this.storage.FindFirstWithMass(this.smi.master.ElementTag).ElementID.CreateTag(), amount, offset: new Vector3(0.8f, 0.0f, 0.0f));
  }

  protected override void OnCleanUp()
  {
    if (this.smi != null)
      this.smi.StopSM(nameof (OnCleanUp));
    base.OnCleanUp();
  }

  private PrimaryElement GetFirstPrimaryElement()
  {
    for (int idx = 0; idx < this.storage.Count; ++idx)
    {
      GameObject gameObject = this.storage[idx];
      if (!((UnityEngine.Object) gameObject == (UnityEngine.Object) null))
      {
        PrimaryElement component = gameObject.GetComponent<PrimaryElement>();
        if (!((UnityEngine.Object) component == (UnityEngine.Object) null))
          return component;
      }
    }
    return (PrimaryElement) null;
  }

  private void UpdateStoredItemState()
  {
    this.storage.allowItemRemoval = this.smi != null && this.smi.GetCurrentState() == this.smi.sm.operational.ready;
    foreach (GameObject go in this.storage.items)
    {
      if ((UnityEngine.Object) go != (UnityEngine.Object) null)
        go.Trigger(-778359855, (object) this.storage);
    }
  }

  private void OnCopySettings(object data)
  {
    this.UserMaxCapacity = ((GameObject) data).GetComponent<Bottler>().UserMaxCapacity;
  }

  private class Controller : 
    GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler>
  {
    public GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State nonoperational;
    public Bottler.Controller.OperationalStates operational;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.nonoperational;
      this.root.Enter((StateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State.Callback) (smi => smi.master.storage.allowItemRemoval = false));
      this.nonoperational.PlayAnim("off").TagTransition(GameTags.Operational, (GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State) this.operational);
      this.operational.EnterTransition(this.operational.ready, new StateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.Transition.ConditionCallback(Bottler.Controller.IsFull)).DefaultState(this.operational.empty).TagTransition(GameTags.Operational, this.nonoperational, true);
      this.operational.empty.PlayAnim("off").EventHandlerTransition(GameHashes.OnStorageChange, this.operational.filling, (Func<Bottler.Controller.Instance, object, bool>) ((smi, o) => Bottler.Controller.IsFull(smi)));
      this.operational.filling.PlayAnim("working").Enter((StateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State.Callback) (smi => smi.UpdateMeter())).OnAnimQueueComplete(this.operational.ready);
      this.operational.ready.EventTransition(GameHashes.OnStorageChange, this.operational.empty, GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.Not(new StateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.Transition.ConditionCallback(Bottler.Controller.IsFull))).PlayAnim("ready").Enter((StateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State.Callback) (smi => smi.master.storage.allowItemRemoval = true)).Exit((StateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State.Callback) (smi => smi.master.storage.allowItemRemoval = false)).Enter((StateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State.Callback) (smi =>
      {
        smi.master.storage.allowItemRemoval = true;
        smi.UpdateMeter();
        foreach (GameObject go in smi.master.storage.items)
        {
          Pickupable component = go.GetComponent<Pickupable>();
          component.targetWorkable = (Workable) smi.master;
          component.SetOffsets(new CellOffset[1]
          {
            smi.master.workCellOffset
          });
          component.OnReservationsChanged += new Action<Pickupable, bool, Pickupable.Reservation>(smi.master.OnReservationsChanged);
          component.KPrefabID.AddTag(smi.master.SourceTag);
          go.Trigger(-778359855, (object) smi.master.storage);
        }
      })).Exit((StateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State.Callback) (smi =>
      {
        smi.master.storage.allowItemRemoval = false;
        foreach (GameObject go in smi.master.storage.items)
        {
          Pickupable component;
          component.targetWorkable = (Workable) (component = go.GetComponent<Pickupable>());
          component.SetOffsetTable(OffsetGroups.InvertedStandardTable);
          component.OnReservationsChanged -= new Action<Pickupable, bool, Pickupable.Reservation>(smi.master.OnReservationsChanged);
          component.KPrefabID.RemoveTag(smi.master.SourceTag);
          component.GetSMI<FetchableMonitor.Instance>()?.SetForceUnfetchable(false);
          go.Trigger(-778359855, (object) smi.master.storage);
        }
      }));
    }

    public static bool IsFull(Bottler.Controller.Instance smi)
    {
      return (double) smi.master.storage.MassStored() >= (double) smi.master.userMaxCapacity && (double) smi.master.userMaxCapacity > 0.0;
    }

    public class OperationalStates : 
      GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State
    {
      public GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State empty;
      public GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State filling;
      public GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.State ready;
    }

    public new class Instance : 
      GameStateMachine<Bottler.Controller, Bottler.Controller.Instance, Bottler, object>.GameInstance
    {
      public MeterController meter { get; private set; }

      public Instance(Bottler master)
        : base(master)
      {
        this.meter = new MeterController((KAnimControllerBase) this.GetComponent<KBatchedAnimController>(), "bottle", "off", Meter.Offset.UserSpecified, Grid.SceneLayer.BuildingFront, new string[3]
        {
          "bottle",
          "substance_tinter",
          "substance_tinter_cap"
        });
      }

      public void UpdateMeter()
      {
        PrimaryElement firstPrimaryElement = this.smi.master.GetFirstPrimaryElement();
        if ((UnityEngine.Object) firstPrimaryElement == (UnityEngine.Object) null)
          return;
        this.meter.meterController.SwapAnims(firstPrimaryElement.Element.substance.anims);
        this.meter.meterController.Play(OreSizeVisualizerComponents.GetAnimForMass(firstPrimaryElement.Mass), KAnim.PlayMode.Paused);
        Color32 colour = firstPrimaryElement.Element.substance.colour with
        {
          a = byte.MaxValue
        };
        this.meter.SetSymbolTint(new KAnimHashedString("meter_fill"), colour);
        this.meter.SetSymbolTint(new KAnimHashedString("water1"), colour);
        this.meter.SetSymbolTint(new KAnimHashedString("substance_tinter"), colour);
        this.meter.SetSymbolTint(new KAnimHashedString("substance_tinter_cap"), colour);
      }
    }
  }
}
