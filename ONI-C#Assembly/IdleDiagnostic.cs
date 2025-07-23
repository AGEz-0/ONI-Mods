// Decompiled with JetBrains decompiler
// Type: IdleDiagnostic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections.Generic;

#nullable disable
public class IdleDiagnostic : ColonyDiagnostic
{
  public IdleDiagnostic(int worldID)
    : base(worldID, (string) UI.COLONY_DIAGNOSTICS.IDLEDIAGNOSTIC.ALL_NAME)
  {
    this.tracker = (Tracker) TrackerTool.Instance.GetWorldTracker<IdleTracker>(worldID);
    this.icon = "icon_errand_operate";
    this.AddCriterion("CheckIdle", new DiagnosticCriterion((string) UI.COLONY_DIAGNOSTICS.IDLEDIAGNOSTIC.CRITERIA.CHECKIDLE, new Func<ColonyDiagnostic.DiagnosticResult>(this.CheckIdle)));
  }

  private ColonyDiagnostic.DiagnosticResult CheckIdle()
  {
    List<MinionIdentity> worldItems = Components.LiveMinionIdentities.GetWorldItems(this.worldID);
    ColonyDiagnostic.DiagnosticResult diagnosticResult = new ColonyDiagnostic.DiagnosticResult(ColonyDiagnostic.DiagnosticResult.Opinion.Normal, (string) UI.COLONY_DIAGNOSTICS.GENERIC_CRITERIA_PASS);
    if (worldItems.Count == 0)
    {
      diagnosticResult.opinion = ColonyDiagnostic.DiagnosticResult.Opinion.Normal;
      diagnosticResult.Message = this.NO_MINIONS;
    }
    else
    {
      diagnosticResult.opinion = ColonyDiagnostic.DiagnosticResult.Opinion.Normal;
      diagnosticResult.Message = (string) UI.COLONY_DIAGNOSTICS.IDLEDIAGNOSTIC.NORMAL;
      if ((double) this.tracker.GetMinValue(5f) > 0.0 && (double) this.tracker.GetCurrentValue() > 0.0)
      {
        diagnosticResult.opinion = ColonyDiagnostic.DiagnosticResult.Opinion.Concern;
        diagnosticResult.Message = (string) UI.COLONY_DIAGNOSTICS.IDLEDIAGNOSTIC.IDLE;
        diagnosticResult.clickThroughObjects = this.tracker.objectsOfInterest;
      }
    }
    return diagnosticResult;
  }
}
