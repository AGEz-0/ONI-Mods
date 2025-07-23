// Decompiled with JetBrains decompiler
// Type: SpiceInstance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;

#nullable disable
[Serializable]
public struct SpiceInstance
{
  public Tag Id;
  public float TotalKG;

  public AttributeModifier CalorieModifier
  {
    get => SpiceGrinder.SettingOptions[this.Id].Spice.CalorieModifier;
  }

  public AttributeModifier FoodModifier => SpiceGrinder.SettingOptions[this.Id].Spice.FoodModifier;

  public Effect StatBonus => SpiceGrinder.SettingOptions[this.Id].StatBonus;
}
