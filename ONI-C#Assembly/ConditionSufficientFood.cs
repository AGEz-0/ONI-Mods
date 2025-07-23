// Decompiled with JetBrains decompiler
// Type: ConditionSufficientFood
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class ConditionSufficientFood : ProcessCondition
{
  private CommandModule module;

  public ConditionSufficientFood(CommandModule module) => this.module = module;

  public override ProcessCondition.Status EvaluateCondition()
  {
    return (double) this.module.storage.GetAmountAvailable(GameTags.Edible) <= 1.0 ? ProcessCondition.Status.Failure : ProcessCondition.Status.Ready;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.HASFOOD.NAME : (string) UI.STARMAP.NOFOOD.NAME;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.HASFOOD.TOOLTIP : (string) UI.STARMAP.NOFOOD.TOOLTIP;
  }

  public override bool ShowInUI() => true;
}
