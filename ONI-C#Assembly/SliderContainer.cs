// Decompiled with JetBrains decompiler
// Type: SliderContainer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Events;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SliderContainer")]
public class SliderContainer : KMonoBehaviour
{
  public bool isPercentValue = true;
  public KSlider slider;
  public LocText nameLabel;
  public LocText valueLabel;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.slider.onValueChanged.AddListener(new UnityAction<float>(this.UpdateSliderLabel));
  }

  public void UpdateSliderLabel(float newValue)
  {
    if (this.isPercentValue)
      this.valueLabel.text = (newValue * 100f).ToString("F0") + "%";
    else
      this.valueLabel.text = newValue.ToString();
  }
}
