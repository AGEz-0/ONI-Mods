// Decompiled with JetBrains decompiler
// Type: LoadingCompleteCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class LoadingCompleteCondition : ProcessCondition
{
  private Storage target;
  private IUserControlledCapacity userControlledTarget;

  public LoadingCompleteCondition(Storage target)
  {
    this.target = target;
    this.userControlledTarget = target.GetComponent<IUserControlledCapacity>();
  }

  public override ProcessCondition.Status EvaluateCondition()
  {
    return this.userControlledTarget != null ? ((double) this.userControlledTarget.AmountStored < (double) this.userControlledTarget.UserMaxCapacity ? ProcessCondition.Status.Warning : ProcessCondition.Status.Ready) : (!this.target.IsFull() ? ProcessCondition.Status.Warning : ProcessCondition.Status.Ready);
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return (string) (status == ProcessCondition.Status.Ready ? UI.STARMAP.LAUNCHCHECKLIST.LOADING_COMPLETE.STATUS.READY : UI.STARMAP.LAUNCHCHECKLIST.LOADING_COMPLETE.STATUS.WARNING);
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return (string) (status == ProcessCondition.Status.Ready ? UI.STARMAP.LAUNCHCHECKLIST.LOADING_COMPLETE.TOOLTIP.READY : UI.STARMAP.LAUNCHCHECKLIST.LOADING_COMPLETE.TOOLTIP.WARNING);
  }

  public override bool ShowInUI() => true;
}
