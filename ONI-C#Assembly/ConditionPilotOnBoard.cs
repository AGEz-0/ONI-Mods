// Decompiled with JetBrains decompiler
// Type: ConditionPilotOnBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class ConditionPilotOnBoard : ProcessCondition
{
  private PassengerRocketModule module;
  private RocketModuleCluster rocketModule;

  public ConditionPilotOnBoard(PassengerRocketModule module)
  {
    this.module = module;
    this.rocketModule = module.GetComponent<RocketModuleCluster>();
  }

  public override ProcessCondition.Status EvaluateCondition()
  {
    if (this.module.CheckPilotBoarded())
      return ProcessCondition.Status.Ready;
    return (Object) this.rocketModule.CraftInterface.GetRobotPilotModule() != (Object) null ? ProcessCondition.Status.Warning : ProcessCondition.Status.Failure;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    switch (status)
    {
      case ProcessCondition.Status.Warning:
        if ((Object) this.rocketModule.CraftInterface.GetRobotPilotModule() != (Object) null)
          return (string) UI.STARMAP.LAUNCHCHECKLIST.PILOT_BOARDED.ROBO_PILOT_WARNING;
        break;
      case ProcessCondition.Status.Ready:
        return (string) UI.STARMAP.LAUNCHCHECKLIST.PILOT_BOARDED.READY;
    }
    return (string) UI.STARMAP.LAUNCHCHECKLIST.PILOT_BOARDED.FAILURE;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    switch (status)
    {
      case ProcessCondition.Status.Warning:
        if ((Object) this.rocketModule.CraftInterface.GetRobotPilotModule() != (Object) null)
          return (string) UI.STARMAP.LAUNCHCHECKLIST.PILOT_BOARDED.TOOLTIP.ROBO_PILOT_WARNING;
        break;
      case ProcessCondition.Status.Ready:
        return (string) UI.STARMAP.LAUNCHCHECKLIST.PILOT_BOARDED.TOOLTIP.READY;
    }
    return (string) UI.STARMAP.LAUNCHCHECKLIST.PILOT_BOARDED.TOOLTIP.FAILURE;
  }

  public override bool ShowInUI() => true;
}
