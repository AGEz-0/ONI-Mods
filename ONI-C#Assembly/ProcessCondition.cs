// Decompiled with JetBrains decompiler
// Type: ProcessCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class ProcessCondition
{
  protected ProcessCondition parentCondition;

  public abstract ProcessCondition.Status EvaluateCondition();

  public abstract bool ShowInUI();

  public abstract string GetStatusMessage(ProcessCondition.Status status);

  public string GetStatusMessage() => this.GetStatusMessage(this.EvaluateCondition());

  public abstract string GetStatusTooltip(ProcessCondition.Status status);

  public string GetStatusTooltip() => this.GetStatusTooltip(this.EvaluateCondition());

  public virtual StatusItem GetStatusItem(ProcessCondition.Status status) => (StatusItem) null;

  public virtual ProcessCondition GetParentCondition() => this.parentCondition;

  public enum ProcessConditionType
  {
    RocketFlight,
    RocketPrep,
    RocketStorage,
    RocketBoard,
    All,
  }

  public enum Status
  {
    Failure,
    Warning,
    Ready,
  }
}
