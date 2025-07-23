// Decompiled with JetBrains decompiler
// Type: Database.ActivateLorePOI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
namespace Database;

public class ActivateLorePOI : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public void Deserialize(IReader reader)
  {
  }

  public override bool Success()
  {
    foreach (BuildingComplete buildingComplete in Components.TemplateBuildings.Items)
    {
      if (!((Object) buildingComplete == (Object) null))
      {
        Unsealable component = buildingComplete.GetComponent<Unsealable>();
        if ((Object) component != (Object) null && component.unsealed)
          return true;
      }
    }
    return false;
  }

  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.INVESTIGATE_A_POI;
  }
}
