// Decompiled with JetBrains decompiler
// Type: BatteryTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class BatteryTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    float f = 0.0f;
    foreach (ElectricalUtilityNetwork network in (IEnumerable<UtilityNetwork>) Game.Instance.electricalConduitSystem.GetNetworks())
    {
      if (network.allWires != null && network.allWires.Count != 0)
      {
        int cell = Grid.PosToCell((KMonoBehaviour) network.allWires[0]);
        if ((int) Grid.WorldIdx[cell] == this.WorldID)
        {
          foreach (Battery battery in Game.Instance.circuitManager.GetBatteriesOnCircuit(Game.Instance.circuitManager.GetCircuitID(cell)))
            f += battery.JoulesAvailable;
        }
      }
    }
    this.AddPoint(Mathf.Round(f));
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedJoules(value);
}
