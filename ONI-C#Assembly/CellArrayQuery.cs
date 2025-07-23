// Decompiled with JetBrains decompiler
// Type: CellArrayQuery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CellArrayQuery : PathFinderQuery
{
  private int[] targetCells;

  public CellArrayQuery Reset(int[] target_cells)
  {
    this.targetCells = target_cells;
    return this;
  }

  public override bool IsMatch(int cell, int parent_cell, int cost)
  {
    for (int index = 0; index < this.targetCells.Length; ++index)
    {
      if (this.targetCells[index] == cell)
        return true;
    }
    return false;
  }
}
