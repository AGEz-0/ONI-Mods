﻿// Decompiled with JetBrains decompiler
// Type: CapacityControlSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CapacityControlSideScreen : SideScreenContent
{
  private IUserControlledCapacity target;
  [Header("Slider")]
  [SerializeField]
  private KSlider slider;
  [Header("Number Input")]
  [SerializeField]
  private KNumberInputField numberInput;
  [SerializeField]
  private LocText unitsLabel;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.unitsLabel.text = (string) this.target.CapacityUnits;
    this.slider.onDrag += (System.Action) (() => this.ReceiveValueFromSlider(this.slider.value));
    this.slider.onPointerDown += (System.Action) (() => this.ReceiveValueFromSlider(this.slider.value));
    this.slider.onMove += (System.Action) (() => this.ReceiveValueFromSlider(this.slider.value));
    this.numberInput.onEndEdit += (System.Action) (() => this.ReceiveValueFromInput(this.numberInput.currentValue));
    this.numberInput.decimalPlaces = 1;
  }

  public override bool IsValidForTarget(GameObject target)
  {
    return !target.GetComponent<IUserControlledCapacity>().IsNullOrDestroyed() || target.GetSMI<IUserControlledCapacity>() != null;
  }

  public override void SetTarget(GameObject new_target)
  {
    if ((UnityEngine.Object) new_target == (UnityEngine.Object) null)
    {
      Debug.LogError((object) "Invalid gameObject received");
    }
    else
    {
      this.target = new_target.GetComponent<IUserControlledCapacity>();
      if (this.target == null)
        this.target = new_target.GetSMI<IUserControlledCapacity>();
      if (this.target == null)
      {
        Debug.LogError((object) "The gameObject received does not contain a IThresholdSwitch component");
      }
      else
      {
        this.slider.minValue = this.target.MinCapacity;
        this.slider.maxValue = this.target.MaxCapacity;
        this.slider.value = this.target.UserMaxCapacity;
        this.slider.GetComponentInChildren<ToolTip>();
        this.unitsLabel.text = (string) this.target.CapacityUnits;
        this.numberInput.minValue = this.target.MinCapacity;
        this.numberInput.maxValue = this.target.MaxCapacity;
        this.numberInput.currentValue = Mathf.Max(this.target.MinCapacity, Mathf.Min(this.target.MaxCapacity, this.target.UserMaxCapacity));
        this.numberInput.Activate();
        this.UpdateMaxCapacityLabel();
      }
    }
  }

  private void ReceiveValueFromSlider(float newValue) => this.UpdateMaxCapacity(newValue);

  private void ReceiveValueFromInput(float newValue) => this.UpdateMaxCapacity(newValue);

  private void UpdateMaxCapacity(float newValue)
  {
    this.target.UserMaxCapacity = newValue;
    this.slider.value = newValue;
    this.UpdateMaxCapacityLabel();
  }

  private void UpdateMaxCapacityLabel()
  {
    this.numberInput.SetDisplayValue(this.target.UserMaxCapacity.ToString());
  }
}
