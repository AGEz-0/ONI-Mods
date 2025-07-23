// Decompiled with JetBrains decompiler
// Type: RocketOxidizerDiagnostic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class RocketOxidizerDiagnostic : ColonyDiagnostic
{
  public RocketOxidizerDiagnostic(int worldID)
    : base(worldID, (string) UI.COLONY_DIAGNOSTICS.ROCKETOXIDIZERDIAGNOSTIC.ALL_NAME)
  {
    this.tracker = (Tracker) TrackerTool.Instance.GetWorldTracker<RocketOxidizerTracker>(worldID);
    this.icon = "rocket_oxidizer";
  }

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override ColonyDiagnostic.DiagnosticResult Evaluate()
  {
    Clustercraft component = ClusterManager.Instance.GetWorld(this.worldID).gameObject.GetComponent<Clustercraft>();
    ColonyDiagnostic.DiagnosticResult result = new ColonyDiagnostic.DiagnosticResult(ColonyDiagnostic.DiagnosticResult.Opinion.Normal, this.NO_MINIONS);
    if (ColonyDiagnosticUtility.IgnoreRocketsWithNoCrewRequested(this.worldID, out result))
      return result;
    result.opinion = ColonyDiagnostic.DiagnosticResult.Opinion.Normal;
    result.Message = (string) UI.COLONY_DIAGNOSTICS.ROCKETOXIDIZERDIAGNOSTIC.NORMAL;
    RocketEngineCluster engine = component.ModuleInterface.GetEngine();
    if ((double) component.ModuleInterface.OxidizerPowerRemaining == 0.0 && (Object) engine != (Object) null && engine.requireOxidizer)
    {
      result.opinion = ColonyDiagnostic.DiagnosticResult.Opinion.Concern;
      result.Message = (string) UI.COLONY_DIAGNOSTICS.ROCKETOXIDIZERDIAGNOSTIC.WARNING;
    }
    return result;
  }
}
