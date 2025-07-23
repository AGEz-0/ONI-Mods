// Decompiled with JetBrains decompiler
// Type: TransferCargoCompleteCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class TransferCargoCompleteCondition : ProcessCondition
{
  private GameObject target;

  public TransferCargoCompleteCondition(GameObject target) => this.target = target;

  public override ProcessCondition.Status EvaluateCondition()
  {
    LaunchPad component = this.target.GetComponent<LaunchPad>();
    CraftModuleInterface craftModuleInterface;
    if ((Object) component == (Object) null)
    {
      craftModuleInterface = this.target.GetComponent<Clustercraft>().ModuleInterface;
    }
    else
    {
      RocketModuleCluster landedRocket = component.LandedRocket;
      if ((Object) landedRocket == (Object) null)
        return ProcessCondition.Status.Ready;
      craftModuleInterface = landedRocket.CraftInterface;
    }
    return !craftModuleInterface.HasCargoModule || this.target.HasTag(GameTags.TransferringCargoComplete) ? ProcessCondition.Status.Ready : ProcessCondition.Status.Warning;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.LAUNCHCHECKLIST.CARGO_TRANSFER_COMPLETE.STATUS.READY : (string) UI.STARMAP.LAUNCHCHECKLIST.CARGO_TRANSFER_COMPLETE.STATUS.WARNING;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.LAUNCHCHECKLIST.CARGO_TRANSFER_COMPLETE.TOOLTIP.READY : (string) UI.STARMAP.LAUNCHCHECKLIST.CARGO_TRANSFER_COMPLETE.TOOLTIP.WARNING;
  }

  public override bool ShowInUI() => true;
}
