// Decompiled with JetBrains decompiler
// Type: ConditionHasAstronaut
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;

#nullable disable
public class ConditionHasAstronaut : ProcessCondition
{
  private CommandModule module;

  public ConditionHasAstronaut(CommandModule module) => this.module = module;

  public override ProcessCondition.Status EvaluateCondition()
  {
    List<MinionStorage.Info> storedMinionInfo = this.module.GetComponent<MinionStorage>().GetStoredMinionInfo();
    return storedMinionInfo.Count > 0 && storedMinionInfo[0].serializedMinion != null ? ProcessCondition.Status.Ready : ProcessCondition.Status.Failure;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.LAUNCHCHECKLIST.ASTRONAUT_TITLE : (string) UI.STARMAP.LAUNCHCHECKLIST.ASTRONAUGHT;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.LAUNCHCHECKLIST.HASASTRONAUT : (string) UI.STARMAP.LAUNCHCHECKLIST.ASTRONAUGHT;
  }

  public override bool ShowInUI() => true;
}
