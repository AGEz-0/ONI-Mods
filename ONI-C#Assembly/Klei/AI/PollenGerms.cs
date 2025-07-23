﻿// Decompiled with JetBrains decompiler
// Type: Klei.AI.PollenGerms
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI.DiseaseGrowthRules;

#nullable disable
namespace Klei.AI;

public class PollenGerms(bool statsOnly) : Disease(nameof (PollenGerms), 5f, new Disease.RangeInfo(263.15f, 273.15f, 363.15f, 373.15f), new Disease.RangeInfo(10f, 100f, 100f, 10f), new Disease.RangeInfo(0.0f, 0.0f, 1000f, 1000f), Disease.RangeInfo.Idempotent(), 0.0f, statsOnly)
{
  public const string ID = "PollenGerms";

  protected override void PopulateElemGrowthInfo()
  {
    this.InitializeElemGrowthArray(ref this.elemGrowthInfo, Disease.DEFAULT_GROWTH_INFO);
    this.AddGrowthRule(new GrowthRule()
    {
      underPopulationDeathRate = new float?(0.6666667f),
      minCountPerKG = new float?(0.4f),
      populationHalfLife = new float?(3000f),
      maxCountPerKG = new float?(500f),
      overPopulationHalfLife = new float?(10f),
      minDiffusionCount = new int?(3000),
      diffusionScale = new float?(1f / 1000f),
      minDiffusionInfestationTickCount = new byte?((byte) 1)
    });
    StateGrowthRule g1 = new StateGrowthRule(Element.State.Solid);
    g1.minCountPerKG = new float?(0.4f);
    g1.populationHalfLife = new float?(10f);
    g1.overPopulationHalfLife = new float?(10f);
    g1.diffusionScale = new float?(1E-06f);
    g1.minDiffusionCount = new int?(1000000);
    this.AddGrowthRule((GrowthRule) g1);
    StateGrowthRule g2 = new StateGrowthRule(Element.State.Gas);
    g2.minCountPerKG = new float?(500f);
    g2.underPopulationDeathRate = new float?(2.66666675f);
    g2.populationHalfLife = new float?(10f);
    g2.overPopulationHalfLife = new float?(10f);
    g2.maxCountPerKG = new float?(1000000f);
    g2.minDiffusionCount = new int?(1000);
    g2.diffusionScale = new float?(0.015f);
    this.AddGrowthRule((GrowthRule) g2);
    ElementGrowthRule g3 = new ElementGrowthRule(SimHashes.Oxygen);
    g3.populationHalfLife = new float?(200f);
    g3.overPopulationHalfLife = new float?(10f);
    this.AddGrowthRule((GrowthRule) g3);
    StateGrowthRule g4 = new StateGrowthRule(Element.State.Liquid);
    g4.minCountPerKG = new float?(0.4f);
    g4.populationHalfLife = new float?(10f);
    g4.overPopulationHalfLife = new float?(10f);
    g4.maxCountPerKG = new float?(100f);
    g4.diffusionScale = new float?(0.01f);
    this.AddGrowthRule((GrowthRule) g4);
    this.InitializeElemExposureArray(ref this.elemExposureInfo, Disease.DEFAULT_EXPOSURE_INFO);
    this.AddExposureRule(new ExposureRule()
    {
      populationHalfLife = new float?(1200f)
    });
    ElementExposureRule g5 = new ElementExposureRule(SimHashes.Oxygen);
    g5.populationHalfLife = new float?(float.PositiveInfinity);
    this.AddExposureRule((ExposureRule) g5);
  }
}
