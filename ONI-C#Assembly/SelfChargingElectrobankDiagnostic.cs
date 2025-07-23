// Decompiled with JetBrains decompiler
// Type: SelfChargingElectrobankDiagnostic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SelfChargingElectrobankDiagnostic : ColonyDiagnostic
{
  private float WARNING_LIFETIME = 600f;

  public SelfChargingElectrobankDiagnostic(int worldID)
    : base(worldID, (string) UI.SELFCHARGINGBATTERYDIAGNOSTIC.ALL_NAME)
  {
    this.icon = "overlay_radiation";
    this.AddCriterion("CheckLifetime", new DiagnosticCriterion((string) UI.SELFCHARGINGBATTERYDIAGNOSTIC.CRITERIA.CHECKSELFCHARGINGBATTERYLIFE, new Func<ColonyDiagnostic.DiagnosticResult>(this.CheckLifetime)));
  }

  public override string[] GetRequiredDlcIds()
  {
    return DlcManager.EXPANSION1.Concat<string>(DlcManager.DLC3);
  }

  private ColonyDiagnostic.DiagnosticResult CheckLifetime()
  {
    ColonyDiagnostic.DiagnosticResult diagnosticResult = new ColonyDiagnostic.DiagnosticResult(ColonyDiagnostic.DiagnosticResult.Opinion.Normal, (string) UI.SELFCHARGINGBATTERYDIAGNOSTIC.NORMAL);
    foreach (SelfChargingElectrobank chargingElectrobank in Components.SelfChargingElectrobanks.GetItems(this.worldID))
    {
      if ((double) chargingElectrobank.LifetimeRemaining <= (double) this.WARNING_LIFETIME)
      {
        diagnosticResult.opinion = ColonyDiagnostic.DiagnosticResult.Opinion.Concern;
        if (diagnosticResult.clickThroughObjects == null)
          diagnosticResult.clickThroughObjects = new List<GameObject>();
        diagnosticResult.clickThroughObjects.Add(chargingElectrobank.gameObject);
        diagnosticResult.Message = (string) UI.SELFCHARGINGBATTERYDIAGNOSTIC.CRITERIA_BATTERYLIFE_WARNING;
      }
    }
    return diagnosticResult;
  }
}
