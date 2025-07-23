// Decompiled with JetBrains decompiler
// Type: MeteorDiagnostic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;

#nullable disable
public class MeteorDiagnostic : ColonyDiagnostic
{
  public MeteorDiagnostic(int worldID)
    : base(worldID, (string) UI.COLONY_DIAGNOSTICS.METEORDIAGNOSTIC.ALL_NAME)
  {
    this.icon = "meteors";
    this.AddCriterion("BombardmentUnderway", new DiagnosticCriterion((string) UI.COLONY_DIAGNOSTICS.METEORDIAGNOSTIC.CRITERIA.CHECKUNDERWAY, new Func<ColonyDiagnostic.DiagnosticResult>(this.CheckMeteorBombardment)));
  }

  public ColonyDiagnostic.DiagnosticResult CheckMeteorBombardment()
  {
    ColonyDiagnostic.DiagnosticResult diagnosticResult = new ColonyDiagnostic.DiagnosticResult(ColonyDiagnostic.DiagnosticResult.Opinion.Normal, (string) UI.COLONY_DIAGNOSTICS.METEORDIAGNOSTIC.NORMAL);
    List<GameplayEventInstance> results = new List<GameplayEventInstance>();
    GameplayEventManager.Instance.GetActiveEventsOfType<MeteorShowerEvent>(this.worldID, ref results);
    for (int index = 0; index < results.Count; ++index)
    {
      if (results[index].smi is MeteorShowerEvent.StatesInstance smi && smi.IsInsideState((StateMachine.BaseState) smi.sm.running.bombarding))
      {
        diagnosticResult.opinion = ColonyDiagnostic.DiagnosticResult.Opinion.Warning;
        diagnosticResult.Message = string.Format((string) UI.COLONY_DIAGNOSTICS.METEORDIAGNOSTIC.SHOWER_UNDERWAY, (object) GameUtil.GetFormattedTime(smi.BombardTimeRemaining()));
      }
    }
    return diagnosticResult;
  }
}
