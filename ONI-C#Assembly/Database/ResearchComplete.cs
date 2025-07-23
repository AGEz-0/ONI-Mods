﻿// Decompiled with JetBrains decompiler
// Type: Database.ResearchComplete
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class ResearchComplete : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  public override bool Success()
  {
    foreach (Tech resource in Db.Get().Techs.resources)
    {
      if (!resource.IsComplete())
        return false;
    }
    return true;
  }

  public void Deserialize(IReader reader)
  {
  }

  public override string GetProgress(bool complete)
  {
    if (complete)
      return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.TECH_RESEARCHED, (object) Db.Get().Techs.resources.Count, (object) Db.Get().Techs.resources.Count);
    int num = 0;
    foreach (Tech resource in Db.Get().Techs.resources)
    {
      if (resource.IsComplete())
        ++num;
    }
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.TECH_RESEARCHED, (object) num, (object) Db.Get().Techs.resources.Count);
  }
}
