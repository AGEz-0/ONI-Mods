// Decompiled with JetBrains decompiler
// Type: InfoScreenLineItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/InfoScreenLineItem")]
public class InfoScreenLineItem : KMonoBehaviour
{
  [SerializeField]
  private LocText locText;
  [SerializeField]
  private ToolTip toolTip;
  private string text;
  private string tooltip;

  public void SetText(string text) => this.locText.text = text;

  public void SetTooltip(string tooltip) => this.toolTip.toolTip = tooltip;
}
