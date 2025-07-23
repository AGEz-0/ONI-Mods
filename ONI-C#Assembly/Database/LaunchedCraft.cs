// Decompiled with JetBrains decompiler
// Type: Database.LaunchedCraft
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class LaunchedCraft : ColonyAchievementRequirement
{
  public override string GetProgress(bool completed)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.LAUNCHED_ROCKET;
  }

  public override bool Success()
  {
    foreach (Clustercraft clustercraft in Components.Clustercrafts)
    {
      if (clustercraft.Status == Clustercraft.CraftStatus.InFlight)
        return true;
    }
    return false;
  }
}
