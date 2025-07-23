// Decompiled with JetBrains decompiler
// Type: Database.HarvestAHiveWithoutBeingStung
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class HarvestAHiveWithoutBeingStung : ColonyAchievementRequirement
{
  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.HARVEST_HIVE;
  }

  public override bool Success()
  {
    return SaveGame.Instance.ColonyAchievementTracker.harvestAHiveWithoutGettingStung;
  }
}
