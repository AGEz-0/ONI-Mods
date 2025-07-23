// Decompiled with JetBrains decompiler
// Type: Klei.AI.DiseaseGrowthRules.CompositeExposureRule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.AI.DiseaseGrowthRules;

public class CompositeExposureRule
{
  public string name;
  public float populationHalfLife;

  public string Name() => this.name;

  public void Overlay(ExposureRule rule)
  {
    if (rule.populationHalfLife.HasValue)
      this.populationHalfLife = rule.populationHalfLife.Value;
    this.name = rule.Name();
  }

  public float GetHalfLifeForCount(int count) => this.populationHalfLife;
}
