// Decompiled with JetBrains decompiler
// Type: CellVisibility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CellVisibility
{
  private int MinX;
  private int MinY;
  private int MaxX;
  private int MaxY;

  public CellVisibility()
  {
    Grid.GetVisibleExtents(out this.MinX, out this.MinY, out this.MaxX, out this.MaxY);
  }

  public bool IsVisible(int cell)
  {
    int num1 = Grid.CellColumn(cell);
    if (num1 < this.MinX || num1 > this.MaxX)
      return false;
    int num2 = Grid.CellRow(cell);
    return num2 >= this.MinY && num2 <= this.MaxY;
  }
}
