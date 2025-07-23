// Decompiled with JetBrains decompiler
// Type: RadiationTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;

#nullable disable
public class RadiationTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    float num = 0.0f;
    List<MinionIdentity> worldItems = Components.MinionIdentities.GetWorldItems(this.WorldID);
    if (worldItems.Count == 0)
    {
      this.AddPoint(0.0f);
    }
    else
    {
      foreach (MinionIdentity cmp in worldItems)
        num += cmp.GetAmounts().Get(Db.Get().Amounts.RadiationBalance.Id).value;
      this.AddPoint(num / (float) worldItems.Count);
    }
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedRads(value);
}
