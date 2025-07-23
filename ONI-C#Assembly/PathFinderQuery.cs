// Decompiled with JetBrains decompiler
// Type: PathFinderQuery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class PathFinderQuery
{
  protected int resultCell;
  private NavType resultNavType;

  public virtual bool IsMatch(int cell, int parent_cell, int cost) => true;

  public void SetResult(int cell, int cost, NavType nav_type)
  {
    this.resultCell = cell;
    this.resultNavType = nav_type;
  }

  public void ClearResult() => this.resultCell = -1;

  public virtual int GetResultCell() => this.resultCell;

  public NavType GetResultNavType() => this.resultNavType;
}
