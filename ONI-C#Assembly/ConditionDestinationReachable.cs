﻿// Decompiled with JetBrains decompiler
// Type: ConditionDestinationReachable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class ConditionDestinationReachable : ProcessCondition
{
  private LaunchableRocketRegisterType craftRegisterType;
  private RocketModule module;

  public ConditionDestinationReachable(RocketModule module)
  {
    this.module = module;
    this.craftRegisterType = module.GetComponent<ILaunchableRocket>().registerType;
  }

  public override ProcessCondition.Status EvaluateCondition()
  {
    ProcessCondition.Status condition = ProcessCondition.Status.Failure;
    switch (this.craftRegisterType)
    {
      case LaunchableRocketRegisterType.Spacecraft:
        int id = SpacecraftManager.instance.GetSpacecraftFromLaunchConditionManager(this.module.GetComponent<LaunchConditionManager>()).id;
        SpaceDestination spacecraftDestination = SpacecraftManager.instance.GetSpacecraftDestination(id);
        if (spacecraftDestination != null && this.CanReachSpacecraftDestination(spacecraftDestination) && spacecraftDestination.GetDestinationType().visitable)
        {
          condition = ProcessCondition.Status.Ready;
          break;
        }
        break;
      case LaunchableRocketRegisterType.Clustercraft:
        if (!this.module.GetComponent<RocketModuleCluster>().CraftInterface.GetComponent<RocketClusterDestinationSelector>().IsAtDestination())
        {
          condition = ProcessCondition.Status.Ready;
          break;
        }
        break;
    }
    return condition;
  }

  public bool CanReachSpacecraftDestination(SpaceDestination destination)
  {
    Debug.Assert(!DlcManager.FeatureClusterSpaceEnabled());
    float rocketMaxDistance = this.module.GetComponent<CommandModule>().rocketStats.GetRocketMaxDistance();
    return (double) destination.OneBasedDistance * 10000.0 <= (double) rocketMaxDistance;
  }

  public SpaceDestination GetSpacecraftDestination()
  {
    Debug.Assert(!DlcManager.FeatureClusterSpaceEnabled());
    int id = SpacecraftManager.instance.GetSpacecraftFromLaunchConditionManager(this.module.GetComponent<LaunchConditionManager>()).id;
    return SpacecraftManager.instance.GetSpacecraftDestination(id);
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    string statusMessage = "";
    switch (this.craftRegisterType)
    {
      case LaunchableRocketRegisterType.Spacecraft:
        statusMessage = status != ProcessCondition.Status.Ready || this.GetSpacecraftDestination() == null ? (this.GetSpacecraftDestination() == null ? (string) UI.STARMAP.DESTINATIONSELECTION.NOTSELECTED : (string) UI.STARMAP.DESTINATIONSELECTION.UNREACHABLE) : (string) UI.STARMAP.DESTINATIONSELECTION.REACHABLE;
        break;
      case LaunchableRocketRegisterType.Clustercraft:
        statusMessage = (string) UI.STARMAP.DESTINATIONSELECTION.REACHABLE;
        break;
    }
    return statusMessage;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    string statusTooltip = "";
    switch (this.craftRegisterType)
    {
      case LaunchableRocketRegisterType.Spacecraft:
        statusTooltip = status != ProcessCondition.Status.Ready || this.GetSpacecraftDestination() == null ? (this.GetSpacecraftDestination() == null ? (string) UI.STARMAP.DESTINATIONSELECTION_TOOLTIP.NOTSELECTED : (string) UI.STARMAP.DESTINATIONSELECTION_TOOLTIP.UNREACHABLE) : (string) UI.STARMAP.DESTINATIONSELECTION_TOOLTIP.REACHABLE;
        break;
      case LaunchableRocketRegisterType.Clustercraft:
        statusTooltip = status != ProcessCondition.Status.Ready ? (string) UI.STARMAP.DESTINATIONSELECTION_TOOLTIP.NOTSELECTED : (string) UI.STARMAP.DESTINATIONSELECTION_TOOLTIP.REACHABLE;
        break;
    }
    return statusTooltip;
  }

  public override bool ShowInUI() => true;
}
