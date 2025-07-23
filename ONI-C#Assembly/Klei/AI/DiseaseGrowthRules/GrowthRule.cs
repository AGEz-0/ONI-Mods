// Decompiled with JetBrains decompiler
// Type: Klei.AI.DiseaseGrowthRules.GrowthRule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Klei.AI.DiseaseGrowthRules;

public class GrowthRule
{
  public float? underPopulationDeathRate;
  public float? populationHalfLife;
  public float? overPopulationHalfLife;
  public float? diffusionScale;
  public float? minCountPerKG;
  public float? maxCountPerKG;
  public int? minDiffusionCount;
  public byte? minDiffusionInfestationTickCount;

  public void Apply(ElemGrowthInfo[] infoList)
  {
    List<Element> elements = ElementLoader.elements;
    for (int index = 0; index < elements.Count; ++index)
    {
      Element e = elements[index];
      if (e.id != SimHashes.Vacuum && this.Test(e))
      {
        ElemGrowthInfo info = infoList[index];
        if (this.underPopulationDeathRate.HasValue)
          info.underPopulationDeathRate = this.underPopulationDeathRate.Value;
        if (this.populationHalfLife.HasValue)
          info.populationHalfLife = this.populationHalfLife.Value;
        if (this.overPopulationHalfLife.HasValue)
          info.overPopulationHalfLife = this.overPopulationHalfLife.Value;
        if (this.diffusionScale.HasValue)
          info.diffusionScale = this.diffusionScale.Value;
        if (this.minCountPerKG.HasValue)
          info.minCountPerKG = this.minCountPerKG.Value;
        if (this.maxCountPerKG.HasValue)
          info.maxCountPerKG = this.maxCountPerKG.Value;
        if (this.minDiffusionCount.HasValue)
          info.minDiffusionCount = this.minDiffusionCount.Value;
        if (this.minDiffusionInfestationTickCount.HasValue)
          info.minDiffusionInfestationTickCount = this.minDiffusionInfestationTickCount.Value;
        infoList[index] = info;
      }
    }
  }

  public virtual bool Test(Element e) => true;

  public virtual string Name() => (string) null;
}
