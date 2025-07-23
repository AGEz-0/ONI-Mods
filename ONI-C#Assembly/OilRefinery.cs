﻿// Decompiled with JetBrains decompiler
// Type: OilRefinery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using TUNING;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class OilRefinery : StateMachineComponent<OilRefinery.StatesInstance>
{
  private bool wasOverPressure;
  [SerializeField]
  public float overpressureWarningMass = 4.5f;
  [SerializeField]
  public float overpressureMass = 5f;
  private float maxSrcMass;
  private float envPressure;
  private float cellCount;
  [MyCmpGet]
  private Storage storage;
  [MyCmpReq]
  private Operational operational;
  [MyCmpAdd]
  private OilRefinery.WorkableTarget workable;
  [MyCmpReq]
  private OccupyArea occupyArea;
  [MyCmpAdd]
  private ManuallySetRemoteWorkTargetComponent remoteChore;
  private const bool hasMeter = true;
  private MeterController meter;
  private static readonly EventSystem.IntraObjectHandler<OilRefinery> OnStorageChangedDelegate = new EventSystem.IntraObjectHandler<OilRefinery>((Action<OilRefinery, object>) ((component, data) => component.OnStorageChanged(data)));

  protected override void OnSpawn()
  {
    this.Subscribe<OilRefinery>(-1697596308, OilRefinery.OnStorageChangedDelegate);
    this.meter = new MeterController((KAnimControllerBase) this.GetComponent<KBatchedAnimController>(), "meter_target", "meter", Meter.Offset.Infront, Grid.SceneLayer.NoLayer, Vector3.zero, (string[]) null);
    this.smi.StartSM();
    this.maxSrcMass = this.GetComponent<ConduitConsumer>().capacityKG;
  }

  private void OnStorageChanged(object data)
  {
    this.meter.SetPositionPercent(Mathf.Clamp01(this.storage.GetMassAvailable(SimHashes.CrudeOil) / this.maxSrcMass));
  }

  private static bool UpdateStateCb(int cell, object data)
  {
    OilRefinery oilRefinery = data as OilRefinery;
    if (Grid.Element[cell].IsGas)
    {
      ++oilRefinery.cellCount;
      oilRefinery.envPressure += Grid.Mass[cell];
    }
    return true;
  }

  private void TestAreaPressure()
  {
    this.envPressure = 0.0f;
    this.cellCount = 0.0f;
    if (!((UnityEngine.Object) this.occupyArea != (UnityEngine.Object) null) || !((UnityEngine.Object) this.gameObject != (UnityEngine.Object) null))
      return;
    this.occupyArea.TestArea(Grid.PosToCell(this.gameObject), (object) this, new Func<int, object, bool>(OilRefinery.UpdateStateCb));
    this.envPressure /= this.cellCount;
  }

  private bool IsOverPressure() => (double) this.envPressure >= (double) this.overpressureMass;

  private bool IsOverWarningPressure()
  {
    return (double) this.envPressure >= (double) this.overpressureWarningMass;
  }

  public class StatesInstance(OilRefinery smi) : 
    GameStateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.GameInstance(smi)
  {
    public void TestAreaPressure()
    {
      this.smi.master.TestAreaPressure();
      int num = this.smi.master.IsOverPressure() ? 1 : 0;
      bool flag = this.smi.master.IsOverWarningPressure();
      if (num != 0)
      {
        this.smi.master.wasOverPressure = true;
        this.sm.isOverPressure.Set(true, this);
      }
      else
      {
        if (!this.smi.master.wasOverPressure || flag)
          return;
        this.sm.isOverPressure.Set(false, this);
      }
    }
  }

  public class States : GameStateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery>
  {
    public StateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.BoolParameter isOverPressure;
    public StateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.BoolParameter isOverPressureWarning;
    public GameStateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.State disabled;
    public GameStateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.State overpressure;
    public GameStateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.State needResources;
    public GameStateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.State ready;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.disabled;
      this.root.EventTransition(GameHashes.OperationalChanged, this.disabled, (StateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.Transition.ConditionCallback) (smi => !smi.master.operational.IsOperational));
      this.disabled.EventTransition(GameHashes.OperationalChanged, this.needResources, (StateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.Transition.ConditionCallback) (smi => smi.master.operational.IsOperational));
      this.needResources.EventTransition(GameHashes.OnStorageChange, this.ready, (StateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.Transition.ConditionCallback) (smi => smi.master.GetComponent<ElementConverter>().HasEnoughMassToStartConverting()));
      this.ready.Update("Test Pressure Update", (Action<OilRefinery.StatesInstance, float>) ((smi, dt) => smi.TestAreaPressure()), UpdateRate.SIM_1000ms).ParamTransition<bool>((StateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.Parameter<bool>) this.isOverPressure, this.overpressure, GameStateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.IsTrue).Transition(this.needResources, (StateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.Transition.ConditionCallback) (smi => !smi.master.GetComponent<ElementConverter>().HasEnoughMassToStartConverting())).ToggleChore((Func<OilRefinery.StatesInstance, Chore>) (smi => (Chore) new WorkChore<OilRefinery.WorkableTarget>(Db.Get().ChoreTypes.Fabricate, (IStateMachineTarget) smi.master.workable)), new Action<OilRefinery.StatesInstance, Chore>(OilRefinery.States.SetRemoteChore), this.needResources);
      this.overpressure.Update("Test Pressure Update", (Action<OilRefinery.StatesInstance, float>) ((smi, dt) => smi.TestAreaPressure()), UpdateRate.SIM_1000ms).ParamTransition<bool>((StateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.Parameter<bool>) this.isOverPressure, this.ready, GameStateMachine<OilRefinery.States, OilRefinery.StatesInstance, OilRefinery, object>.IsFalse).ToggleStatusItem(Db.Get().BuildingStatusItems.PressureOk);
    }

    private static void SetRemoteChore(OilRefinery.StatesInstance smi, Chore chore)
    {
      smi.master.remoteChore.SetChore(chore);
    }
  }

  [AddComponentMenu("KMonoBehaviour/Workable/WorkableTarget")]
  public class WorkableTarget : Workable
  {
    [MyCmpGet]
    public Operational operational;

    protected override void OnPrefabInit()
    {
      base.OnPrefabInit();
      this.showProgressBar = false;
      this.workerStatusItem = (StatusItem) null;
      this.skillExperienceSkillGroup = Db.Get().SkillGroups.Technicals.Id;
      this.skillExperienceMultiplier = SKILLS.MOST_DAY_EXPERIENCE;
      this.overrideAnims = new KAnimFile[1]
      {
        Assets.GetAnim((HashedString) "anim_interacts_oilrefinery_kanim")
      };
    }

    protected override void OnSpawn()
    {
      base.OnSpawn();
      this.SetWorkTime(float.PositiveInfinity);
    }

    protected override void OnStartWork(WorkerBase worker) => this.operational.SetActive(true);

    protected override void OnStopWork(WorkerBase worker) => this.operational.SetActive(false);

    protected override void OnCompleteWork(WorkerBase worker) => this.operational.SetActive(false);

    public override bool InstantlyFinish(WorkerBase worker) => false;
  }
}
