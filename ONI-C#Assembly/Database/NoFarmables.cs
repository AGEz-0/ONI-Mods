﻿// Decompiled with JetBrains decompiler
// Type: Database.NoFarmables
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Database;

public class NoFarmables : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public override bool Success()
  {
    foreach (WorldContainer worldContainer in ClusterManager.Instance.WorldContainers)
    {
      foreach (PlantablePlot plantablePlot in Components.PlantablePlots.GetItems(worldContainer.id))
      {
        if ((Object) plantablePlot.Occupant != (Object) null)
        {
          foreach (Tag depositObjectTag in (IEnumerable<Tag>) plantablePlot.possibleDepositObjectTags)
          {
            if (depositObjectTag != GameTags.DecorSeed)
              return false;
          }
        }
      }
    }
    return true;
  }

  public override bool Fail() => !this.Success();

  public void Deserialize(IReader reader)
  {
  }

  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.NO_FARM_TILES;
  }
}
