// Decompiled with JetBrains decompiler
// Type: RocketRestrictionSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class RocketRestrictionSideScreen : SideScreenContent
{
  private RocketControlStation controlStation;
  [Header("Buttons")]
  public KToggle unrestrictedButton;
  public KToggle spaceRestrictedButton;
  public GameObject automationControlled;
  private int controlStationLogicSubHandle = -1;

  protected override void OnSpawn()
  {
    this.unrestrictedButton.onClick += new System.Action(this.ClickNone);
    this.spaceRestrictedButton.onClick += new System.Action(this.ClickSpace);
  }

  public override int GetSideScreenSortOrder() => 0;

  public override bool IsValidForTarget(GameObject target)
  {
    return target.GetSMI<RocketControlStation.StatesInstance>() != null;
  }

  public override void SetTarget(GameObject new_target)
  {
    if ((UnityEngine.Object) this.controlStation != (UnityEngine.Object) null || this.controlStationLogicSubHandle != -1)
      this.ClearTarget();
    this.controlStation = new_target.GetComponent<RocketControlStation>();
    this.controlStationLogicSubHandle = this.controlStation.Subscribe(1861523068, new Action<object>(this.UpdateButtonStates));
    this.UpdateButtonStates();
  }

  public override void ClearTarget()
  {
    if (this.controlStationLogicSubHandle != -1 && (UnityEngine.Object) this.controlStation != (UnityEngine.Object) null)
    {
      this.controlStation.Unsubscribe(this.controlStationLogicSubHandle);
      this.controlStationLogicSubHandle = -1;
    }
    this.controlStation = (RocketControlStation) null;
  }

  private void UpdateButtonStates(object data = null)
  {
    bool flag = this.controlStation.IsLogicInputConnected();
    if (!flag)
    {
      this.unrestrictedButton.isOn = !this.controlStation.RestrictWhenGrounded;
      this.spaceRestrictedButton.isOn = this.controlStation.RestrictWhenGrounded;
    }
    this.unrestrictedButton.gameObject.SetActive(!flag);
    this.spaceRestrictedButton.gameObject.SetActive(!flag);
    this.automationControlled.gameObject.SetActive(flag);
  }

  private void ClickNone()
  {
    this.controlStation.RestrictWhenGrounded = false;
    this.UpdateButtonStates();
  }

  private void ClickSpace()
  {
    this.controlStation.RestrictWhenGrounded = true;
    this.UpdateButtonStates();
  }
}
