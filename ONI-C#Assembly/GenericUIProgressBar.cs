// Decompiled with JetBrains decompiler
// Type: GenericUIProgressBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/GenericUIProgressBar")]
public class GenericUIProgressBar : KMonoBehaviour
{
  public Image fill;
  public LocText label;
  private float maxValue;

  public void SetMaxValue(float max) => this.maxValue = max;

  public void SetFillPercentage(float value)
  {
    this.fill.fillAmount = value;
    this.label.text = $"{Util.FormatWholeNumber(Mathf.Min(this.maxValue, this.maxValue * value))}/{this.maxValue.ToString()}";
  }
}
