// Decompiled with JetBrains decompiler
// Type: SoundUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class SoundUtil
{
  public static float GetLiquidDepth(int cell)
  {
    float num = (float) (0.0 + (double) Grid.Mass[cell] * (Grid.Element[cell].IsLiquid ? 1.0 : 0.0));
    int index = Grid.CellBelow(cell);
    if (Grid.IsValidCell(index))
      num += Grid.Mass[index] * (Grid.Element[index].IsLiquid ? 1f : 0.0f);
    return Mathf.Min(num / 1000f, 1f);
  }

  public static float GetLiquidVolume(float mass) => Mathf.Min(mass / 100f, 1f);
}
