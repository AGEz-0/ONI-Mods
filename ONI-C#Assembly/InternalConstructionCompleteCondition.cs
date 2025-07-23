// Decompiled with JetBrains decompiler
// Type: InternalConstructionCompleteCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class InternalConstructionCompleteCondition : ProcessCondition
{
  private BuildingInternalConstructor.Instance target;

  public InternalConstructionCompleteCondition(BuildingInternalConstructor.Instance target)
  {
    this.target = target;
  }

  public override ProcessCondition.Status EvaluateCondition()
  {
    return this.target.IsRequestingConstruction() && !this.target.HasOutputInStorage() ? ProcessCondition.Status.Warning : ProcessCondition.Status.Ready;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return (string) (status == ProcessCondition.Status.Ready ? UI.STARMAP.LAUNCHCHECKLIST.INTERNAL_CONSTRUCTION_COMPLETE.STATUS.READY : UI.STARMAP.LAUNCHCHECKLIST.INTERNAL_CONSTRUCTION_COMPLETE.STATUS.FAILURE);
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return (string) (status == ProcessCondition.Status.Ready ? UI.STARMAP.LAUNCHCHECKLIST.INTERNAL_CONSTRUCTION_COMPLETE.TOOLTIP.READY : UI.STARMAP.LAUNCHCHECKLIST.INTERNAL_CONSTRUCTION_COMPLETE.TOOLTIP.FAILURE);
  }

  public override bool ShowInUI() => true;
}
