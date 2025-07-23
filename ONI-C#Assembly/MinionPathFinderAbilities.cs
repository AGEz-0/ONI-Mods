// Decompiled with JetBrains decompiler
// Type: MinionPathFinderAbilities
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;

#nullable disable
public class MinionPathFinderAbilities : PathFinderAbilities
{
  private CellOffset[][] transitionVoidOffsets;
  private int proxyID;
  private bool out_of_fuel;
  private bool idleNavMaskEnabled;

  public MinionPathFinderAbilities(Navigator navigator)
    : base(navigator)
  {
    this.transitionVoidOffsets = new CellOffset[navigator.NavGrid.transitions.Length][];
    for (int index = 0; index < this.transitionVoidOffsets.Length; ++index)
      this.transitionVoidOffsets[index] = navigator.NavGrid.transitions[index].voidOffsets;
  }

  protected override void Refresh(Navigator navigator)
  {
    this.proxyID = navigator.GetComponent<MinionIdentity>().assignableProxy.Get().GetComponent<KPrefabID>().InstanceID;
    this.out_of_fuel = navigator.HasTag(GameTags.JetSuitOutOfFuel);
  }

  public void SetIdleNavMaskEnabled(bool enabled) => this.idleNavMaskEnabled = enabled;

  private static bool IsAccessPermitted(
    int proxyID,
    int cell,
    int from_cell,
    NavType from_nav_type)
  {
    return Grid.HasPermission(cell, proxyID, from_cell, from_nav_type);
  }

  public override int GetSubmergedPathCostPenalty(PathFinder.PotentialPath path, NavGrid.Link link)
  {
    return !path.HasAnyFlag(PathFinder.PotentialPath.Flags.HasAtmoSuit | PathFinder.PotentialPath.Flags.HasJetPack | PathFinder.PotentialPath.Flags.HasLeadSuit) ? (int) link.cost * 2 : 0;
  }

  public override bool TraversePath(
    ref PathFinder.PotentialPath path,
    int from_cell,
    NavType from_nav_type,
    int cost,
    int transition_id,
    bool submerged)
  {
    if (!MinionPathFinderAbilities.IsAccessPermitted(this.proxyID, path.cell, from_cell, from_nav_type))
      return false;
    foreach (CellOffset offset in this.transitionVoidOffsets[transition_id])
    {
      if (!MinionPathFinderAbilities.IsAccessPermitted(this.proxyID, Grid.OffsetCell(from_cell, offset), from_cell, from_nav_type))
        return false;
    }
    if (path.navType == NavType.Tube && from_nav_type == NavType.Floor && !Grid.HasUsableTubeEntrance(from_cell, this.prefabInstanceID) || path.navType == NavType.Hover && (this.out_of_fuel || !path.HasFlag(PathFinder.PotentialPath.Flags.HasJetPack)))
      return false;
    Grid.SuitMarker.Flags flags = (Grid.SuitMarker.Flags) 0;
    PathFinder.PotentialPath.Flags pathFlags = PathFinder.PotentialPath.Flags.None;
    bool flag1 = path.HasFlag(PathFinder.PotentialPath.Flags.PerformSuitChecks) && Grid.TryGetSuitMarkerFlags(from_cell, out flags, out pathFlags) && (flags & Grid.SuitMarker.Flags.Operational) != 0;
    bool flag2 = SuitMarker.DoesTraversalDirectionRequireSuit(from_cell, path.cell, flags);
    bool flag3 = path.HasAnyFlag(PathFinder.PotentialPath.Flags.HasAtmoSuit | PathFinder.PotentialPath.Flags.HasJetPack | PathFinder.PotentialPath.Flags.HasOxygenMask | PathFinder.PotentialPath.Flags.HasLeadSuit);
    if (flag1)
    {
      bool flag4 = path.HasFlag(pathFlags);
      if (flag2)
      {
        if (!flag3 && !Grid.HasSuit(from_cell, this.prefabInstanceID))
          return false;
      }
      else if (flag3 && (flags & Grid.SuitMarker.Flags.OnlyTraverseIfUnequipAvailable) != (Grid.SuitMarker.Flags) 0 && (!flag4 || !Grid.HasEmptyLocker(from_cell, this.prefabInstanceID)))
        return false;
    }
    if (this.idleNavMaskEnabled && (Grid.PreventIdleTraversal[path.cell] || Grid.PreventIdleTraversal[from_cell]))
      return false;
    if (flag1)
    {
      if (flag2)
      {
        if (!flag3)
          path.SetFlags(pathFlags);
      }
      else
        path.ClearFlags(PathFinder.PotentialPath.Flags.HasAtmoSuit | PathFinder.PotentialPath.Flags.HasJetPack | PathFinder.PotentialPath.Flags.HasOxygenMask | PathFinder.PotentialPath.Flags.HasLeadSuit);
    }
    return true;
  }

  [Conditional("ENABLE_NAVIGATION_MASK_PROFILING")]
  private void BeginSample(string region_name)
  {
  }

  [Conditional("ENABLE_NAVIGATION_MASK_PROFILING")]
  private void EndSample(string region_name)
  {
  }
}
