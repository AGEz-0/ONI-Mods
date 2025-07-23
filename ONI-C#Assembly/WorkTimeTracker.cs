// Decompiled with JetBrains decompiler
// Type: WorkTimeTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class WorkTimeTracker : WorldTracker
{
  public ChoreGroup choreGroup;

  public WorkTimeTracker(int worldID, ChoreGroup group)
    : base(worldID)
  {
    this.choreGroup = group;
  }

  public override void UpdateData()
  {
    float num = 0.0f;
    List<MinionIdentity> worldItems = Components.LiveMinionIdentities.GetWorldItems(this.WorldID);
    foreach (MinionIdentity minionIdentity in worldItems)
    {
      Chore chore = minionIdentity.GetComponent<ChoreConsumer>().choreDriver.GetCurrentChore();
      if (chore != null && this.choreGroup.choreTypes.Find((Predicate<ChoreType>) (match => match == chore.choreType)) != null)
        ++num;
    }
    this.AddPoint((float) ((double) num / (double) worldItems.Count * 100.0));
  }

  public override string FormatValueString(float value)
  {
    return GameUtil.GetFormattedPercent(Mathf.Round(value)).ToString();
  }
}
