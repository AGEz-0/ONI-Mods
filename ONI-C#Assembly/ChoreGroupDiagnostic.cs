// Decompiled with JetBrains decompiler
// Type: ChoreGroupDiagnostic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class ChoreGroupDiagnostic : ColonyDiagnostic
{
  public ChoreGroup choreGroup;

  public ChoreGroupDiagnostic(int worldID, ChoreGroup choreGroup)
    : base(worldID, (string) UI.COLONY_DIAGNOSTICS.CHOREGROUPDIAGNOSTIC.ALL_NAME)
  {
    this.choreGroup = choreGroup;
    this.tracker = (Tracker) TrackerTool.Instance.GetChoreGroupTracker(worldID, choreGroup);
    this.name = choreGroup.Name;
    this.colors[ColonyDiagnostic.DiagnosticResult.Opinion.Good] = Constants.NEUTRAL_COLOR;
    this.id = "ChoreGroupDiagnostic_" + choreGroup.Id;
  }

  public override ColonyDiagnostic.DiagnosticResult Evaluate()
  {
    return new ColonyDiagnostic.DiagnosticResult(ColonyDiagnostic.DiagnosticResult.Opinion.Normal, (string) UI.COLONY_DIAGNOSTICS.GENERIC_CRITERIA_PASS)
    {
      opinion = (double) this.tracker.GetCurrentValue() > 0.0 ? ColonyDiagnostic.DiagnosticResult.Opinion.Good : ColonyDiagnostic.DiagnosticResult.Opinion.Normal,
      Message = string.Format((string) UI.COLONY_DIAGNOSTICS.ALLCHORESDIAGNOSTIC.NORMAL, (object) this.tracker.FormatValueString(this.tracker.GetCurrentValue()))
    };
  }
}
