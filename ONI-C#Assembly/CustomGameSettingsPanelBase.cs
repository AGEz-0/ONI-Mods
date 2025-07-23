// Decompiled with JetBrains decompiler
// Type: CustomGameSettingsPanelBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public abstract class CustomGameSettingsPanelBase : MonoBehaviour
{
  protected List<CustomGameSettingWidget> widgets = new List<CustomGameSettingWidget>();
  private bool isDirty;

  public virtual void Init()
  {
  }

  public virtual void Uninit()
  {
  }

  private void OnEnable() => this.isDirty = true;

  private void Update()
  {
    if (!this.isDirty)
      return;
    this.isDirty = false;
    this.Refresh();
  }

  protected void AddWidget(CustomGameSettingWidget widget)
  {
    widget.onSettingChanged += new Action<CustomGameSettingWidget>(this.OnWidgetChanged);
    this.widgets.Add(widget);
  }

  private void OnWidgetChanged(CustomGameSettingWidget widget) => this.isDirty = true;

  public virtual void Refresh()
  {
    foreach (CustomGameSettingWidget widget in this.widgets)
      widget.Refresh();
  }
}
