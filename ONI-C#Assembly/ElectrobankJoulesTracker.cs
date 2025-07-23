// Decompiled with JetBrains decompiler
// Type: ElectrobankJoulesTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class ElectrobankJoulesTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    this.AddPoint(WorldResourceAmountTracker<ElectrobankTracker>.Get().CountAmount((Dictionary<string, float>) null, ClusterManager.Instance.GetWorld(this.WorldID).worldInventory));
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedJoules(value);
}
