// Decompiled with JetBrains decompiler
// Type: CellOffsetQuery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CellOffsetQuery : CellArrayQuery
{
  public CellArrayQuery Reset(int cell, CellOffset[] offsets)
  {
    int[] target_cells = new int[offsets.Length];
    for (int index = 0; index < offsets.Length; ++index)
      target_cells[index] = Grid.OffsetCell(cell, offsets[index]);
    this.Reset(target_cells);
    return (CellArrayQuery) this;
  }
}
