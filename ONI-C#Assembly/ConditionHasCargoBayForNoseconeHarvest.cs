// Decompiled with JetBrains decompiler
// Type: ConditionHasCargoBayForNoseconeHarvest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ConditionHasCargoBayForNoseconeHarvest : ProcessCondition
{
  private LaunchableRocketCluster launchable;

  public ConditionHasCargoBayForNoseconeHarvest(LaunchableRocketCluster launchable)
  {
    this.launchable = launchable;
  }

  public override ProcessCondition.Status EvaluateCondition()
  {
    if (!this.HasHarvestNosecone())
      return ProcessCondition.Status.Ready;
    foreach (Ref<RocketModuleCluster> part in (IEnumerable<Ref<RocketModuleCluster>>) this.launchable.parts)
    {
      if ((bool) (Object) part.Get().GetComponent<CargoBayCluster>())
        return ProcessCondition.Status.Ready;
    }
    return ProcessCondition.Status.Warning;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    string statusMessage = "";
    switch (status)
    {
      case ProcessCondition.Status.Failure:
        statusMessage = (string) UI.STARMAP.LAUNCHCHECKLIST.HAS_CARGO_BAY_FOR_NOSECONE_HARVEST.STATUS.FAILURE;
        break;
      case ProcessCondition.Status.Warning:
        statusMessage = (string) UI.STARMAP.LAUNCHCHECKLIST.HAS_CARGO_BAY_FOR_NOSECONE_HARVEST.STATUS.WARNING;
        break;
      case ProcessCondition.Status.Ready:
        statusMessage = (string) UI.STARMAP.LAUNCHCHECKLIST.HAS_CARGO_BAY_FOR_NOSECONE_HARVEST.STATUS.READY;
        break;
    }
    return statusMessage;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    string statusTooltip = "";
    switch (status)
    {
      case ProcessCondition.Status.Failure:
        statusTooltip = (string) UI.STARMAP.LAUNCHCHECKLIST.HAS_CARGO_BAY_FOR_NOSECONE_HARVEST.TOOLTIP.FAILURE;
        break;
      case ProcessCondition.Status.Warning:
        statusTooltip = (string) UI.STARMAP.LAUNCHCHECKLIST.HAS_CARGO_BAY_FOR_NOSECONE_HARVEST.TOOLTIP.WARNING;
        break;
      case ProcessCondition.Status.Ready:
        statusTooltip = (string) UI.STARMAP.LAUNCHCHECKLIST.HAS_CARGO_BAY_FOR_NOSECONE_HARVEST.TOOLTIP.READY;
        break;
    }
    return statusTooltip;
  }

  public override bool ShowInUI() => this.HasHarvestNosecone();

  private bool HasHarvestNosecone()
  {
    foreach (Ref<RocketModuleCluster> part in (IEnumerable<Ref<RocketModuleCluster>>) this.launchable.parts)
    {
      if (part.Get().HasTag((Tag) "NoseconeHarvest"))
        return true;
    }
    return false;
  }
}
