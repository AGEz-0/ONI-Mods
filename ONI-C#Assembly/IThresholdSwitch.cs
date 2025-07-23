// Decompiled with JetBrains decompiler
// Type: IThresholdSwitch
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public interface IThresholdSwitch
{
  float Threshold { get; set; }

  bool ActivateAboveThreshold { get; set; }

  float CurrentValue { get; }

  float RangeMin { get; }

  float RangeMax { get; }

  float GetRangeMinInputField();

  float GetRangeMaxInputField();

  LocString Title { get; }

  LocString ThresholdValueName { get; }

  LocString ThresholdValueUnits();

  string Format(float value, bool units);

  string AboveToolTip { get; }

  string BelowToolTip { get; }

  float ProcessedSliderValue(float input);

  float ProcessedInputValue(float input);

  ThresholdScreenLayoutType LayoutType { get; }

  int IncrementScale { get; }

  NonLinearSlider.Range[] GetRanges { get; }
}
