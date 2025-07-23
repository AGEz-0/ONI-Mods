// Decompiled with JetBrains decompiler
// Type: LaunchPadConditions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class LaunchPadConditions : KMonoBehaviour, IProcessConditionSet
{
  private List<ProcessCondition> conditions;

  public List<ProcessCondition> GetConditionSet(
    ProcessCondition.ProcessConditionType conditionType)
  {
    return conditionType != ProcessCondition.ProcessConditionType.RocketStorage ? (List<ProcessCondition>) null : this.conditions;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.conditions = new List<ProcessCondition>();
    this.conditions.Add((ProcessCondition) new TransferCargoCompleteCondition(this.gameObject));
  }
}
