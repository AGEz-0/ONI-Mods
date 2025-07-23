﻿// Decompiled with JetBrains decompiler
// Type: LogicRadiationSensor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class LogicRadiationSensor : Switch, ISaveLoadable, IThresholdSwitch, ISim200ms
{
  private int simUpdateCounter;
  [Serialize]
  public float thresholdRads = 280f;
  [Serialize]
  public bool activateOnWarmerThan;
  [Serialize]
  private bool dirty = true;
  public float minRads;
  public float maxRads = 5000f;
  private const int NumFrameDelay = 8;
  private float[] radHistory = new float[8];
  private float averageRads;
  private bool wasOn;
  [MyCmpAdd]
  private CopyBuildingSettings copyBuildingSettings;
  private static readonly EventSystem.IntraObjectHandler<LogicRadiationSensor> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<LogicRadiationSensor>((Action<LogicRadiationSensor, object>) ((component, data) => component.OnCopySettings(data)));

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe<LogicRadiationSensor>(-905833192, LogicRadiationSensor.OnCopySettingsDelegate);
  }

  private void OnCopySettings(object data)
  {
    LogicRadiationSensor component = ((GameObject) data).GetComponent<LogicRadiationSensor>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    this.Threshold = component.Threshold;
    this.ActivateAboveThreshold = component.ActivateAboveThreshold;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.OnToggle += new Action<bool>(this.OnSwitchToggled);
    this.UpdateVisualState(true);
    this.UpdateLogicCircuit();
    this.wasOn = this.switchedOn;
  }

  public void Sim200ms(float dt)
  {
    if (this.simUpdateCounter < 8 && !this.dirty)
    {
      int cell = Grid.PosToCell((KMonoBehaviour) this);
      this.radHistory[this.simUpdateCounter] = Grid.Radiation[cell];
      ++this.simUpdateCounter;
    }
    else
    {
      this.simUpdateCounter = 0;
      this.dirty = false;
      this.averageRads = 0.0f;
      for (int index = 0; index < 8; ++index)
        this.averageRads += this.radHistory[index];
      this.averageRads /= 8f;
      if (this.activateOnWarmerThan)
      {
        if (((double) this.averageRads <= (double) this.thresholdRads || this.IsSwitchedOn) && ((double) this.averageRads > (double) this.thresholdRads || !this.IsSwitchedOn))
          return;
        this.Toggle();
      }
      else
      {
        if (((double) this.averageRads < (double) this.thresholdRads || !this.IsSwitchedOn) && ((double) this.averageRads >= (double) this.thresholdRads || this.IsSwitchedOn))
          return;
        this.Toggle();
      }
    }
  }

  public float GetAverageRads() => this.averageRads;

  private void OnSwitchToggled(bool toggled_on)
  {
    this.UpdateVisualState();
    this.UpdateLogicCircuit();
  }

  private void UpdateLogicCircuit()
  {
    this.GetComponent<LogicPorts>().SendSignal(LogicSwitch.PORT_ID, this.switchedOn ? 1 : 0);
  }

  private void UpdateVisualState(bool force = false)
  {
    if (!(this.wasOn != this.switchedOn | force))
      return;
    this.wasOn = this.switchedOn;
    KBatchedAnimController component = this.GetComponent<KBatchedAnimController>();
    component.Play((HashedString) (this.switchedOn ? "on_pre" : "on_pst"));
    component.Queue((HashedString) (this.switchedOn ? "on" : "off"));
  }

  protected override void UpdateSwitchStatus()
  {
    StatusItem status_item = this.switchedOn ? Db.Get().BuildingStatusItems.LogicSensorStatusActive : Db.Get().BuildingStatusItems.LogicSensorStatusInactive;
    this.GetComponent<KSelectable>().SetStatusItem(Db.Get().StatusItemCategories.Power, status_item);
  }

  public float Threshold
  {
    get => this.thresholdRads;
    set
    {
      this.thresholdRads = value;
      this.dirty = true;
    }
  }

  public bool ActivateAboveThreshold
  {
    get => this.activateOnWarmerThan;
    set
    {
      this.activateOnWarmerThan = value;
      this.dirty = true;
    }
  }

  public float CurrentValue => this.GetAverageRads();

  public float RangeMin => this.minRads;

  public float RangeMax => this.maxRads;

  public float GetRangeMinInputField() => GameUtil.GetConvertedTemperature(this.RangeMin);

  public float GetRangeMaxInputField() => GameUtil.GetConvertedTemperature(this.RangeMax);

  public LocString Title => UI.UISIDESCREENS.RADIATIONSWITCHSIDESCREEN.TITLE;

  public LocString ThresholdValueName => UI.UISIDESCREENS.THRESHOLD_SWITCH_SIDESCREEN.RADIATION;

  public string AboveToolTip
  {
    get => (string) UI.UISIDESCREENS.THRESHOLD_SWITCH_SIDESCREEN.RADIATION_TOOLTIP_ABOVE;
  }

  public string BelowToolTip
  {
    get => (string) UI.UISIDESCREENS.THRESHOLD_SWITCH_SIDESCREEN.RADIATION_TOOLTIP_BELOW;
  }

  public string Format(float value, bool units) => GameUtil.GetFormattedRads(value);

  public float ProcessedSliderValue(float input) => Mathf.Round(input);

  public float ProcessedInputValue(float input) => input;

  public LocString ThresholdValueUnits() => (LocString) "";

  public ThresholdScreenLayoutType LayoutType => ThresholdScreenLayoutType.SliderBar;

  public int IncrementScale => 1;

  public NonLinearSlider.Range[] GetRanges
  {
    get
    {
      return new NonLinearSlider.Range[3]
      {
        new NonLinearSlider.Range(50f, 200f),
        new NonLinearSlider.Range(25f, 1000f),
        new NonLinearSlider.Range(25f, 5000f)
      };
    }
  }
}
