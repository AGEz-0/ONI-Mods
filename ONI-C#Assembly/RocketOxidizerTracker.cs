// Decompiled with JetBrains decompiler
// Type: RocketOxidizerTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RocketOxidizerTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    Clustercraft component = ClusterManager.Instance.GetWorld(this.WorldID).GetComponent<Clustercraft>();
    this.AddPoint((Object) component != (Object) null ? component.ModuleInterface.OxidizerPowerRemaining : 0.0f);
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedMass(value);
}
