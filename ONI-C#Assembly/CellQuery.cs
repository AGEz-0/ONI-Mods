// Decompiled with JetBrains decompiler
// Type: CellQuery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CellQuery : PathFinderQuery
{
  private int targetCell;

  public CellQuery Reset(int target_cell)
  {
    this.targetCell = target_cell;
    return this;
  }

  public override bool IsMatch(int cell, int parent_cell, int cost) => cell == this.targetCell;
}
