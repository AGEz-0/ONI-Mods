﻿// Decompiled with JetBrains decompiler
// Type: SuperCheckboxTableColumn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class SuperCheckboxTableColumn : CheckboxTableColumn
{
  public GameObject prefab_super_checkbox = Assets.UIPrefabs.TableScreenWidgets.SuperCheckbox_Horizontal;
  public CheckboxTableColumn[] columns_affected;

  public SuperCheckboxTableColumn(
    CheckboxTableColumn[] columns_affected,
    Action<IAssignableIdentity, GameObject> on_load_action,
    Func<IAssignableIdentity, GameObject, TableScreen.ResultValues> get_value_action,
    Action<GameObject> on_press_action,
    Action<GameObject, TableScreen.ResultValues> set_value_action,
    Comparison<IAssignableIdentity> sort_comparison,
    Action<IAssignableIdentity, GameObject, ToolTip> on_tooltip)
    : base(on_load_action, get_value_action, on_press_action, set_value_action, sort_comparison, on_tooltip, (Action<IAssignableIdentity, GameObject, ToolTip>) null)
  {
    this.columns_affected = columns_affected;
  }

  public override GameObject GetDefaultWidget(GameObject parent)
  {
    GameObject widget_go = Util.KInstantiateUI(this.prefab_super_checkbox, parent, true);
    if ((UnityEngine.Object) widget_go.GetComponent<ToolTip>() != (UnityEngine.Object) null)
      widget_go.GetComponent<ToolTip>().OnToolTip = (Func<string>) (() => this.GetTooltip(widget_go.GetComponent<ToolTip>()));
    widget_go.GetComponent<MultiToggle>().onClick += (System.Action) (() => this.on_press_action(widget_go));
    return widget_go;
  }

  public override GameObject GetHeaderWidget(GameObject parent)
  {
    GameObject widget_go = Util.KInstantiateUI(this.prefab_super_checkbox, parent, true);
    if ((UnityEngine.Object) widget_go.GetComponent<ToolTip>() != (UnityEngine.Object) null)
      widget_go.GetComponent<ToolTip>().OnToolTip = (Func<string>) (() => this.GetTooltip(widget_go.GetComponent<ToolTip>()));
    widget_go.GetComponent<MultiToggle>().onClick += (System.Action) (() => this.on_press_action(widget_go));
    return widget_go;
  }

  public override GameObject GetMinionWidget(GameObject parent)
  {
    GameObject widget_go = Util.KInstantiateUI(this.prefab_super_checkbox, parent, true);
    if ((UnityEngine.Object) widget_go.GetComponent<ToolTip>() != (UnityEngine.Object) null)
      widget_go.GetComponent<ToolTip>().OnToolTip = (Func<string>) (() => this.GetTooltip(widget_go.GetComponent<ToolTip>()));
    widget_go.GetComponent<MultiToggle>().onClick += (System.Action) (() => this.on_press_action(widget_go));
    return widget_go;
  }
}
