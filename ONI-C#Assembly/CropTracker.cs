// Decompiled with JetBrains decompiler
// Type: CropTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CropTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    float num = 0.0f;
    foreach (PlantablePlot plantablePlot in Components.PlantablePlots.GetItems(this.WorldID))
    {
      if (!((Object) plantablePlot.plant == (Object) null) && plantablePlot.HasDepositTag(GameTags.CropSeed) && !plantablePlot.plant.HasTag(GameTags.Wilting))
        ++num;
    }
    this.AddPoint(num);
  }

  public override string FormatValueString(float value) => value.ToString() + "%";
}
