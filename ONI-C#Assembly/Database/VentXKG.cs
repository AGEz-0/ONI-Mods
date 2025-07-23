// Decompiled with JetBrains decompiler
// Type: Database.VentXKG
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Database;

public class VentXKG : ColonyAchievementRequirement, AchievementRequirementSerialization_Deprecated
{
  private SimHashes element;
  private float kilogramsToVent;

  public VentXKG(SimHashes element, float kilogramsToVent)
  {
    this.element = element;
    this.kilogramsToVent = kilogramsToVent;
  }

  public override bool Success()
  {
    float num = 0.0f;
    foreach (UtilityNetwork network in (IEnumerable<UtilityNetwork>) Conduit.GetNetworkManager(ConduitType.Gas).GetNetworks())
    {
      if (network is FlowUtilityNetwork flowUtilityNetwork)
      {
        foreach (FlowUtilityNetwork.IItem sink in flowUtilityNetwork.sinks)
        {
          Vent component = sink.GameObject.GetComponent<Vent>();
          if ((Object) component != (Object) null)
            num += component.GetVentedMass(this.element);
        }
      }
    }
    return (double) num >= (double) this.kilogramsToVent;
  }

  public void Deserialize(IReader reader)
  {
    this.element = (SimHashes) reader.ReadInt32();
    this.kilogramsToVent = reader.ReadSingle();
  }

  public override string GetProgress(bool complete)
  {
    float num = 0.0f;
    foreach (UtilityNetwork network in (IEnumerable<UtilityNetwork>) Conduit.GetNetworkManager(ConduitType.Gas).GetNetworks())
    {
      if (network is FlowUtilityNetwork flowUtilityNetwork)
      {
        foreach (FlowUtilityNetwork.IItem sink in flowUtilityNetwork.sinks)
        {
          Vent component = sink.GameObject.GetComponent<Vent>();
          if ((Object) component != (Object) null)
            num += component.GetVentedMass(this.element);
        }
      }
    }
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.VENTED_MASS, (object) GameUtil.GetFormattedMass(complete ? this.kilogramsToVent : num, massFormat: GameUtil.MetricMassFormat.Kilogram), (object) GameUtil.GetFormattedMass(this.kilogramsToVent, massFormat: GameUtil.MetricMassFormat.Kilogram));
  }
}
