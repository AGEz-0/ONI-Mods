// Decompiled with JetBrains decompiler
// Type: RocketProcessConditionDisplayTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class RocketProcessConditionDisplayTarget : KMonoBehaviour, IProcessConditionSet, ISim1000ms
{
  private CraftModuleInterface craftModuleInterface;
  private Guid statusHandle = Guid.Empty;

  public List<ProcessCondition> GetConditionSet(
    ProcessCondition.ProcessConditionType conditionType)
  {
    if ((UnityEngine.Object) this.craftModuleInterface == (UnityEngine.Object) null)
      this.craftModuleInterface = this.GetComponent<RocketModuleCluster>().CraftInterface;
    return this.craftModuleInterface.GetConditionSet(conditionType);
  }

  public void Sim1000ms(float dt)
  {
    bool flag = false;
    foreach (ProcessCondition condition in this.GetConditionSet(ProcessCondition.ProcessConditionType.All))
    {
      if (condition.EvaluateCondition() == ProcessCondition.Status.Failure)
      {
        flag = true;
        if (this.statusHandle == Guid.Empty)
        {
          this.statusHandle = this.GetComponent<KSelectable>().AddStatusItem(Db.Get().BuildingStatusItems.RocketChecklistIncomplete);
          break;
        }
        break;
      }
    }
    if (flag || !(this.statusHandle != Guid.Empty))
      return;
    this.GetComponent<KSelectable>().RemoveStatusItem(this.statusHandle);
  }
}
