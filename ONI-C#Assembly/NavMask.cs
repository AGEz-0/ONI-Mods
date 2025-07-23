// Decompiled with JetBrains decompiler
// Type: NavMask
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class NavMask
{
  public virtual bool IsTraversable(
    PathFinder.PotentialPath path,
    int from_cell,
    int cost,
    int transition_id,
    PathFinderAbilities abilities)
  {
    return true;
  }

  public virtual void ApplyTraversalToPath(ref PathFinder.PotentialPath path, int from_cell)
  {
  }
}
