﻿// Decompiled with JetBrains decompiler
// Type: Database.CreateMasterPainting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
namespace Database;

public class CreateMasterPainting : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public override bool Success()
  {
    foreach (Painting painting in Components.Paintings.Items)
    {
      if ((Object) painting != (Object) null)
      {
        ArtableStage artableStage = Db.GetArtableStages().TryGet(painting.CurrentStage);
        if (artableStage != null && artableStage.statusItem == Db.Get().ArtableStatuses.LookingGreat)
          return true;
      }
    }
    return false;
  }

  public void Deserialize(IReader reader)
  {
  }

  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.CREATE_A_PAINTING;
  }
}
