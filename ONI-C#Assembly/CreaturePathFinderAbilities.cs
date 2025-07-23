// Decompiled with JetBrains decompiler
// Type: CreaturePathFinderAbilities
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CreaturePathFinderAbilities(Navigator navigator) : PathFinderAbilities(navigator)
{
  public bool canTraverseSubmered;

  protected override void Refresh(Navigator navigator)
  {
    if (PathFinder.IsSubmerged(Grid.PosToCell((KMonoBehaviour) navigator)))
      this.canTraverseSubmered = true;
    else
      this.canTraverseSubmered = Db.Get().Attributes.MaxUnderwaterTravelCost.Lookup((Component) navigator) == null;
  }

  public override bool TraversePath(
    ref PathFinder.PotentialPath path,
    int from_cell,
    NavType from_nav_type,
    int cost,
    int transition_id,
    bool submerged)
  {
    return !submerged || this.canTraverseSubmered;
  }
}
