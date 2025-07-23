// Decompiled with JetBrains decompiler
// Type: PriorityButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/PriorityButton")]
public class PriorityButton : KMonoBehaviour
{
  public KToggle toggle;
  public LocText text;
  public ToolTip tooltip;
  [MyCmpGet]
  private ImageToggleState its;
  public ColorStyleSetting normalStyle;
  public ColorStyleSetting highStyle;
  public bool playSelectionSound = true;
  public Action<PrioritySetting> onClick;
  private PrioritySetting _priority;

  public PrioritySetting priority
  {
    get => this._priority;
    set
    {
      this._priority = value;
      if (!((UnityEngine.Object) this.its != (UnityEngine.Object) null))
        return;
      this.its.colorStyleSetting = this.priority.priority_class != PriorityScreen.PriorityClass.high ? this.normalStyle : this.highStyle;
      this.its.RefreshColorStyle();
      this.its.ResetColor();
    }
  }

  protected override void OnPrefabInit() => this.toggle.onClick += new System.Action(this.OnClick);

  private void OnClick()
  {
    if (this.playSelectionSound)
      PriorityScreen.PlayPriorityConfirmSound(this.priority);
    if (this.onClick == null)
      return;
    this.onClick(this.priority);
  }
}
