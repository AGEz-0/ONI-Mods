// Decompiled with JetBrains decompiler
// Type: SpaceHeater
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class SpaceHeater : 
  StateMachineComponent<SpaceHeater.StatesInstance>,
  IGameObjectEffectDescriptor,
  ISingleSliderControl,
  ISliderControl
{
  public float targetTemperature = 308.15f;
  public float minimumCellMass;
  public int radius = 2;
  [SerializeField]
  private bool heatLiquid;
  [Serialize]
  public float UserSliderSetting;
  public bool produceHeat;
  private StatusItem heatStatusItem;
  private HandleVector<int>.Handle structureTemperature;
  private Extents extents;
  private float overheatTemperature;
  [MyCmpReq]
  private Operational operational;
  [MyCmpReq]
  private PrimaryElement primaryElement;
  [MyCmpGet]
  private KBatchedAnimHeatPostProcessingEffect heatEffect;
  [MyCmpGet]
  private EnergyConsumer energyConsumer;
  private List<int> monitorCells = new List<int>();

  public float TargetTemperature => this.targetTemperature;

  public float MaxPower => 240f;

  public float MinPower => 120f;

  public float MaxSelfHeatKWs => 32f;

  public float MinSelfHeatKWs => 16f;

  public float MaxExhaustedKWs => 4f;

  public float MinExhaustedKWs => 2f;

  public float CurrentSelfHeatKW
  {
    get => Mathf.Lerp(this.MinSelfHeatKWs, this.MaxSelfHeatKWs, this.UserSliderSetting);
  }

  public float CurrentExhaustedKW
  {
    get => Mathf.Lerp(this.MinExhaustedKWs, this.MaxExhaustedKWs, this.UserSliderSetting);
  }

  public float CurrentPowerConsumption
  {
    get => Mathf.Lerp(this.MinPower, this.MaxPower, this.UserSliderSetting);
  }

  public static void GenerateHeat(SpaceHeater.StatesInstance smi, float dt)
  {
    if (!smi.master.produceHeat)
      return;
    double num1 = (double) SpaceHeater.AddExhaustHeat(smi, dt);
    double num2 = (double) SpaceHeater.AddSelfHeat(smi, dt);
  }

  private static float AddExhaustHeat(SpaceHeater.StatesInstance smi, float dt)
  {
    float currentExhaustedKw = smi.master.CurrentExhaustedKW;
    StructureTemperatureComponents.ExhaustHeat(smi.master.extents, currentExhaustedKw, smi.master.overheatTemperature, dt);
    return currentExhaustedKw;
  }

  public static void RefreshHeatEffect(SpaceHeater.StatesInstance smi)
  {
    if (!((UnityEngine.Object) smi.master.heatEffect != (UnityEngine.Object) null) || !smi.master.produceHeat)
      return;
    float heat = smi.IsInsideState((StateMachine.BaseState) smi.sm.online.heating) ? smi.master.CurrentExhaustedKW + smi.master.CurrentSelfHeatKW : 0.0f;
    smi.master.heatEffect.SetHeatBeingProducedValue(heat);
  }

  private static float AddSelfHeat(SpaceHeater.StatesInstance smi, float dt)
  {
    float currentSelfHeatKw = smi.master.CurrentSelfHeatKW;
    GameComps.StructureTemperatures.ProduceEnergy(smi.master.structureTemperature, currentSelfHeatKw * dt, (string) BUILDINGS.PREFABS.STEAMTURBINE2.HEAT_SOURCE, dt);
    return currentSelfHeatKw;
  }

  public void SetUserSpecifiedPowerConsumptionValue(float value)
  {
    if (!this.produceHeat)
      return;
    this.UserSliderSetting = (float) (((double) value - (double) this.MinPower) / ((double) this.MaxPower - (double) this.MinPower));
    SpaceHeater.RefreshHeatEffect(this.smi);
    this.energyConsumer.BaseWattageRating = this.CurrentPowerConsumption;
  }

  protected override void OnPrefabInit()
  {
    if (this.produceHeat)
    {
      this.heatStatusItem = new StatusItem("OperatingEnergy", "BUILDING", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID);
      this.heatStatusItem.resolveStringCallback = (Func<string, object, string>) ((str, data) =>
      {
        SpaceHeater.StatesInstance statesInstance = (SpaceHeater.StatesInstance) data;
        float num = statesInstance.master.CurrentSelfHeatKW + statesInstance.master.CurrentExhaustedKW;
        str = string.Format(str, (object) GameUtil.GetFormattedHeatEnergy(num * 1000f));
        return str;
      });
      this.heatStatusItem.resolveTooltipCallback = (Func<string, object, string>) ((str, data) =>
      {
        SpaceHeater.StatesInstance statesInstance = (SpaceHeater.StatesInstance) data;
        float num = statesInstance.master.CurrentSelfHeatKW + statesInstance.master.CurrentExhaustedKW;
        str = str.Replace("{0}", GameUtil.GetFormattedHeatEnergy(num * 1000f));
        string newValue = string.Format((string) BUILDING.STATUSITEMS.OPERATINGENERGY.LINEITEM, (object) BUILDING.STATUSITEMS.OPERATINGENERGY.OPERATING, (object) GameUtil.GetFormattedHeatEnergy(statesInstance.master.CurrentSelfHeatKW * 1000f, GameUtil.HeatEnergyFormatterUnit.DTU_S)) + string.Format((string) BUILDING.STATUSITEMS.OPERATINGENERGY.LINEITEM, (object) BUILDING.STATUSITEMS.OPERATINGENERGY.EXHAUSTING, (object) GameUtil.GetFormattedHeatEnergy(statesInstance.master.CurrentExhaustedKW * 1000f, GameUtil.HeatEnergyFormatterUnit.DTU_S));
        str = str.Replace("{1}", newValue);
        return str;
      });
    }
    base.OnPrefabInit();
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    GameScheduler.Instance.Schedule("InsulationTutorial", 2f, (Action<object>) (obj => Tutorial.Instance.TutorialMessage(Tutorial.TutorialMessages.TM_Insulation)), (object) null, (SchedulerGroup) null);
    this.extents = this.GetComponent<OccupyArea>().GetExtents();
    this.overheatTemperature = this.GetComponent<BuildingComplete>().Def.OverheatTemperature;
    this.structureTemperature = GameComps.StructureTemperatures.GetHandle(this.gameObject);
    this.smi.StartSM();
    this.SetUserSpecifiedPowerConsumptionValue(this.CurrentPowerConsumption);
  }

  public void SetLiquidHeater() => this.heatLiquid = true;

  private SpaceHeater.MonitorState MonitorHeating(float dt)
  {
    this.monitorCells.Clear();
    GameUtil.GetNonSolidCells(Grid.PosToCell(this.transform.GetPosition()), this.radius, this.monitorCells);
    int num1 = 0;
    float num2 = 0.0f;
    for (int index = 0; index < this.monitorCells.Count; ++index)
    {
      if ((double) Grid.Mass[this.monitorCells[index]] > (double) this.minimumCellMass && (Grid.Element[this.monitorCells[index]].IsGas && !this.heatLiquid || Grid.Element[this.monitorCells[index]].IsLiquid && this.heatLiquid))
      {
        ++num1;
        num2 += Grid.Temperature[this.monitorCells[index]];
      }
    }
    return num1 == 0 ? (!this.heatLiquid ? SpaceHeater.MonitorState.NotEnoughGas : SpaceHeater.MonitorState.NotEnoughLiquid) : ((double) num2 / (double) num1 >= (double) this.targetTemperature ? SpaceHeater.MonitorState.TooHot : SpaceHeater.MonitorState.ReadyToHeat);
  }

  public List<Descriptor> GetDescriptors(GameObject go)
  {
    List<Descriptor> descriptors = new List<Descriptor>();
    Descriptor descriptor = new Descriptor();
    descriptor.SetupDescriptor(string.Format((string) UI.BUILDINGEFFECTS.HEATER_TARGETTEMPERATURE, (object) GameUtil.GetFormattedTemperature(this.targetTemperature)), string.Format((string) UI.BUILDINGEFFECTS.TOOLTIPS.HEATER_TARGETTEMPERATURE, (object) GameUtil.GetFormattedTemperature(this.targetTemperature)));
    descriptors.Add(descriptor);
    return descriptors;
  }

  public string SliderTitleKey => "STRINGS.UI.UISIDESCREENS.SPACEHEATERSIDESCREEN.TITLE";

  public string SliderUnits => (string) UI.UNITSUFFIXES.ELECTRICAL.WATT;

  public int SliderDecimalPlaces(int index) => 0;

  public float GetSliderMin(int index) => !this.produceHeat ? 0.0f : this.MinPower;

  public float GetSliderMax(int index) => !this.produceHeat ? 0.0f : this.MaxPower;

  public float GetSliderValue(int index) => this.CurrentPowerConsumption;

  public void SetSliderValue(float value, int index)
  {
    this.SetUserSpecifiedPowerConsumptionValue(value);
  }

  public string GetSliderTooltipKey(int index)
  {
    return "STRINGS.UI.UISIDESCREENS.SPACEHEATERSIDESCREEN.TOOLTIP";
  }

  string ISliderControl.GetSliderTooltip(int index)
  {
    return string.Format((string) Strings.Get("STRINGS.UI.UISIDESCREENS.SPACEHEATERSIDESCREEN.TOOLTIP"), (object) GameUtil.GetFormattedHeatEnergyRate((float) (((double) this.CurrentSelfHeatKW + (double) this.CurrentExhaustedKW) * 1000.0)));
  }

  public class StatesInstance(SpaceHeater master) : 
    GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.GameInstance(master)
  {
  }

  public class States : GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater>
  {
    public GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State offline;
    public SpaceHeater.States.OnlineStates online;
    private StatusItem statusItemUnderMassLiquid;
    private StatusItem statusItemUnderMassGas;
    private StatusItem statusItemOverTemp;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.offline;
      this.serializable = StateMachine.SerializeType.Never;
      this.statusItemUnderMassLiquid = new StatusItem("statusItemUnderMassLiquid", (string) BUILDING.STATUSITEMS.HEATINGSTALLEDLOWMASS_LIQUID.NAME, (string) BUILDING.STATUSITEMS.HEATINGSTALLEDLOWMASS_LIQUID.TOOLTIP, "", StatusItem.IconType.Info, NotificationType.BadMinor, false, OverlayModes.None.ID);
      this.statusItemUnderMassGas = new StatusItem("statusItemUnderMassGas", (string) BUILDING.STATUSITEMS.HEATINGSTALLEDLOWMASS_GAS.NAME, (string) BUILDING.STATUSITEMS.HEATINGSTALLEDLOWMASS_GAS.TOOLTIP, "", StatusItem.IconType.Info, NotificationType.BadMinor, false, OverlayModes.None.ID);
      this.statusItemOverTemp = new StatusItem("statusItemOverTemp", (string) BUILDING.STATUSITEMS.HEATINGSTALLEDHOTENV.NAME, (string) BUILDING.STATUSITEMS.HEATINGSTALLEDHOTENV.TOOLTIP, "", StatusItem.IconType.Info, NotificationType.BadMinor, false, OverlayModes.None.ID);
      this.statusItemOverTemp.resolveStringCallback = (Func<string, object, string>) ((str, obj) =>
      {
        SpaceHeater.StatesInstance statesInstance = (SpaceHeater.StatesInstance) obj;
        return string.Format(str, (object) GameUtil.GetFormattedTemperature(statesInstance.master.TargetTemperature));
      });
      this.offline.Enter(new StateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State.Callback(SpaceHeater.RefreshHeatEffect)).EventTransition(GameHashes.OperationalChanged, (GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State) this.online, (StateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.Transition.ConditionCallback) (smi => smi.master.operational.IsOperational));
      this.online.EventTransition(GameHashes.OperationalChanged, this.offline, (StateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.Transition.ConditionCallback) (smi => !smi.master.operational.IsOperational)).DefaultState(this.online.heating).Update("spaceheater_online", (Action<SpaceHeater.StatesInstance, float>) ((smi, dt) =>
      {
        switch (smi.master.MonitorHeating(dt))
        {
          case SpaceHeater.MonitorState.ReadyToHeat:
            smi.GoTo((StateMachine.BaseState) this.online.heating);
            break;
          case SpaceHeater.MonitorState.TooHot:
            smi.GoTo((StateMachine.BaseState) this.online.overtemp);
            break;
          case SpaceHeater.MonitorState.NotEnoughLiquid:
            smi.GoTo((StateMachine.BaseState) this.online.undermassliquid);
            break;
          case SpaceHeater.MonitorState.NotEnoughGas:
            smi.GoTo((StateMachine.BaseState) this.online.undermassgas);
            break;
        }
      }), UpdateRate.SIM_4000ms);
      this.online.heating.Enter(new StateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State.Callback(SpaceHeater.RefreshHeatEffect)).Enter((StateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State.Callback) (smi => smi.master.operational.SetActive(true))).ToggleStatusItem((Func<SpaceHeater.StatesInstance, StatusItem>) (smi => smi.master.heatStatusItem), (Func<SpaceHeater.StatesInstance, object>) (smi => (object) smi)).Update(new Action<SpaceHeater.StatesInstance, float>(SpaceHeater.GenerateHeat)).Exit((StateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State.Callback) (smi => smi.master.operational.SetActive(false))).Exit(new StateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State.Callback(SpaceHeater.RefreshHeatEffect));
      this.online.undermassliquid.ToggleCategoryStatusItem(Db.Get().StatusItemCategories.Heat, this.statusItemUnderMassLiquid);
      this.online.undermassgas.ToggleCategoryStatusItem(Db.Get().StatusItemCategories.Heat, this.statusItemUnderMassGas);
      this.online.overtemp.ToggleCategoryStatusItem(Db.Get().StatusItemCategories.Heat, this.statusItemOverTemp);
    }

    public class OnlineStates : 
      GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State
    {
      public GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State heating;
      public GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State overtemp;
      public GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State undermassliquid;
      public GameStateMachine<SpaceHeater.States, SpaceHeater.StatesInstance, SpaceHeater, object>.State undermassgas;
    }
  }

  private enum MonitorState
  {
    ReadyToHeat,
    TooHot,
    NotEnoughLiquid,
    NotEnoughGas,
  }
}
