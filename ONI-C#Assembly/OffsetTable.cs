// Decompiled with JetBrains decompiler
// Type: OffsetTable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public static class OffsetTable
{
  public static CellOffset[][] Mirror(CellOffset[][] table)
  {
    List<CellOffset[]> cellOffsetArrayList = new List<CellOffset[]>();
    foreach (CellOffset[] cellOffsetArray1 in table)
    {
      cellOffsetArrayList.Add(cellOffsetArray1);
      if (cellOffsetArray1[0].x != 0)
      {
        CellOffset[] cellOffsetArray2 = new CellOffset[cellOffsetArray1.Length];
        for (int index = 0; index < cellOffsetArray2.Length; ++index)
        {
          cellOffsetArray2[index] = cellOffsetArray1[index];
          cellOffsetArray2[index].x = -cellOffsetArray2[index].x;
        }
        cellOffsetArrayList.Add(cellOffsetArray2);
      }
    }
    return cellOffsetArrayList.ToArray();
  }
}
