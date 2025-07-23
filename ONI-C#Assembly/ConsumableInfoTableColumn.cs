// Decompiled with JetBrains decompiler
// Type: ConsumableInfoTableColumn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class ConsumableInfoTableColumn : CheckboxTableColumn
{
  public IConsumableUIItem consumable_info;
  public Func<GameObject, string> get_header_label;

  public ConsumableInfoTableColumn(
    IConsumableUIItem consumable_info,
    Action<IAssignableIdentity, GameObject> load_value_action,
    Func<IAssignableIdentity, GameObject, TableScreen.ResultValues> get_value_action,
    Action<GameObject> on_press_action,
    Action<GameObject, TableScreen.ResultValues> set_value_action,
    Comparison<IAssignableIdentity> sort_comparison,
    Action<IAssignableIdentity, GameObject, ToolTip> on_tooltip,
    Action<IAssignableIdentity, GameObject, ToolTip> on_sort_tooltip,
    Func<GameObject, string> get_header_label,
    Func<bool> reveal_test)
    : base(load_value_action, get_value_action, on_press_action, set_value_action, sort_comparison, on_tooltip, on_sort_tooltip, reveal_test)
  {
    this.consumable_info = consumable_info;
    this.get_header_label = get_header_label;
  }

  public override GameObject GetHeaderWidget(GameObject parent)
  {
    GameObject headerWidget = base.GetHeaderWidget(parent);
    if ((UnityEngine.Object) headerWidget.GetComponentInChildren<LocText>() != (UnityEngine.Object) null)
      headerWidget.GetComponentInChildren<LocText>().text = this.get_header_label(headerWidget);
    headerWidget.GetComponentInChildren<MultiToggle>().gameObject.SetActive(false);
    return headerWidget;
  }
}
