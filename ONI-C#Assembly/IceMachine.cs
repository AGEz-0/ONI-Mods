﻿// Decompiled with JetBrains decompiler
// Type: IceMachine
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class IceMachine : 
  StateMachineComponent<IceMachine.StatesInstance>,
  FewOptionSideScreen.IFewOptionSideScreen
{
  [MyCmpGet]
  private Operational operational;
  public Storage waterStorage;
  public Storage iceStorage;
  public float targetTemperature;
  public float heatRemovalRate;
  private static StatusItem iceStorageFullStatusItem;
  [Serialize]
  public SimHashes targetProductionElement = SimHashes.Ice;

  public void SetStorages(Storage waterStorage, Storage iceStorage)
  {
    this.waterStorage = waterStorage;
    this.iceStorage = iceStorage;
  }

  private bool CanMakeIce()
  {
    int num = !((UnityEngine.Object) this.waterStorage != (UnityEngine.Object) null) ? 0 : ((double) this.waterStorage.GetMassAvailable(SimHashes.Water) >= 0.10000000149011612 ? 1 : 0);
    bool flag = (UnityEngine.Object) this.iceStorage != (UnityEngine.Object) null && this.iceStorage.IsFull();
    return num != 0 && !flag;
  }

  private void MakeIce(IceMachine.StatesInstance smi, float dt)
  {
    float num = this.heatRemovalRate * dt / (float) this.waterStorage.items.Count;
    foreach (GameObject gameObject in this.waterStorage.items)
      GameUtil.DeltaThermalEnergy(gameObject.GetComponent<PrimaryElement>(), -num, smi.master.targetTemperature);
    for (int count = this.waterStorage.items.Count; count > 0; --count)
    {
      GameObject item_go = this.waterStorage.items[count - 1];
      if ((bool) (UnityEngine.Object) item_go && (double) item_go.GetComponent<PrimaryElement>().Temperature < (double) item_go.GetComponent<PrimaryElement>().Element.lowTemp)
      {
        PrimaryElement component = item_go.GetComponent<PrimaryElement>();
        this.waterStorage.AddOre(this.targetProductionElement, component.Mass, component.Temperature, component.DiseaseIdx, component.DiseaseCount);
        this.waterStorage.ConsumeIgnoringDisease(item_go);
      }
    }
    smi.UpdateIceState();
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.smi.StartSM();
  }

  public FewOptionSideScreen.IFewOptionSideScreen.Option[] GetOptions()
  {
    FewOptionSideScreen.IFewOptionSideScreen.Option[] options = new FewOptionSideScreen.IFewOptionSideScreen.Option[IceMachineConfig.ELEMENT_OPTIONS.Length];
    for (int index = 0; index < options.Length; ++index)
    {
      string tooltipText = (string) Strings.Get("STRINGS.BUILDINGS.PREFABS.ICEMACHINE.OPTION_TOOLTIPS." + IceMachineConfig.ELEMENT_OPTIONS[index].ToString().ToUpper());
      options[index] = new FewOptionSideScreen.IFewOptionSideScreen.Option(IceMachineConfig.ELEMENT_OPTIONS[index], ElementLoader.GetElement(IceMachineConfig.ELEMENT_OPTIONS[index]).name, Def.GetUISprite((object) IceMachineConfig.ELEMENT_OPTIONS[index]), tooltipText);
    }
    return options;
  }

  public void OnOptionSelected(
    FewOptionSideScreen.IFewOptionSideScreen.Option option)
  {
    this.targetProductionElement = ElementLoader.GetElementID(option.tag);
  }

  public Tag GetSelectedOption() => this.targetProductionElement.CreateTag();

  public class StatesInstance : 
    GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.GameInstance
  {
    private MeterController meter;
    public Chore emptyChore;

    public StatesInstance(IceMachine smi)
      : base(smi)
    {
      this.meter = new MeterController((KAnimControllerBase) this.gameObject.GetComponent<KBatchedAnimController>(), "meter_target", nameof (meter), Meter.Offset.Infront, Grid.SceneLayer.NoLayer, new string[3]
      {
        "meter_OL",
        "meter_frame",
        "meter_fill"
      });
      this.UpdateMeter();
      this.Subscribe(-1697596308, new Action<object>(this.OnStorageChange));
    }

    private void OnStorageChange(object data) => this.UpdateMeter();

    public void UpdateMeter()
    {
      this.meter.SetPositionPercent(Mathf.Clamp01(this.smi.master.iceStorage.MassStored() / this.smi.master.iceStorage.Capacity()));
    }

    public void UpdateIceState()
    {
      bool flag = false;
      for (int count = this.smi.master.waterStorage.items.Count; count > 0; --count)
      {
        GameObject gameObject = this.smi.master.waterStorage.items[count - 1];
        if ((bool) (UnityEngine.Object) gameObject && (double) gameObject.GetComponent<PrimaryElement>().Temperature <= (double) this.smi.master.targetTemperature)
          flag = true;
      }
      this.sm.doneFreezingIce.Set(flag, this);
    }
  }

  public class States : GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine>
  {
    public StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.BoolParameter doneFreezingIce;
    public GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State off;
    public IceMachine.States.OnStates on;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.off;
      this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
      this.off.PlayAnim("off").EventTransition(GameHashes.OperationalChanged, (GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State) this.on, (StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.Transition.ConditionCallback) (smi => smi.master.operational.IsOperational));
      this.on.PlayAnim("on").EventTransition(GameHashes.OperationalChanged, this.off, (StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.Transition.ConditionCallback) (smi => !smi.master.operational.IsOperational)).DefaultState(this.on.waiting);
      this.on.waiting.EventTransition(GameHashes.OnStorageChange, this.on.working_pre, (StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.Transition.ConditionCallback) (smi => smi.master.CanMakeIce()));
      this.on.working_pre.Enter((StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State.Callback) (smi => smi.UpdateIceState())).PlayAnim("working_pre").OnAnimQueueComplete(this.on.working);
      this.on.working.QueueAnim("working_loop", true).Update("UpdateWorking", (Action<IceMachine.StatesInstance, float>) ((smi, dt) => smi.master.MakeIce(smi, dt))).ParamTransition<bool>((StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.Parameter<bool>) this.doneFreezingIce, this.on.working_pst, GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.IsTrue).Enter((StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State.Callback) (smi =>
      {
        smi.master.operational.SetActive(true);
        smi.master.gameObject.GetComponent<ManualDeliveryKG>().Pause(true, "Working");
      })).Exit((StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State.Callback) (smi =>
      {
        smi.master.operational.SetActive(false);
        smi.master.gameObject.GetComponent<ManualDeliveryKG>().Pause(false, "Done Working");
      })).ToggleStatusItem(Db.Get().BuildingStatusItems.CoolingWater);
      this.on.working_pst.Exit(new StateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State.Callback(this.DoTransfer)).PlayAnim("working_pst").OnAnimQueueComplete((GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State) this.on);
    }

    private void DoTransfer(IceMachine.StatesInstance smi)
    {
      for (int index = smi.master.waterStorage.items.Count - 1; index >= 0; --index)
      {
        GameObject go = smi.master.waterStorage.items[index];
        if ((bool) (UnityEngine.Object) go && (double) go.GetComponent<PrimaryElement>().Temperature <= (double) smi.master.targetTemperature)
          smi.master.waterStorage.Transfer(go, smi.master.iceStorage, hide_popups: true);
      }
      smi.UpdateMeter();
    }

    public class OnStates : 
      GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State
    {
      public GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State waiting;
      public GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State working_pre;
      public GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State working;
      public GameStateMachine<IceMachine.States, IceMachine.StatesInstance, IceMachine, object>.State working_pst;
    }
  }
}
