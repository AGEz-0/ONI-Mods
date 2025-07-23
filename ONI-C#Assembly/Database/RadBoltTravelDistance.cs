// Decompiled with JetBrains decompiler
// Type: Database.RadBoltTravelDistance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class RadBoltTravelDistance : ColonyAchievementRequirement
{
  private int travelDistance;

  public RadBoltTravelDistance(int travelDistance) => this.travelDistance = travelDistance;

  public override string GetProgress(bool complete)
  {
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.RADBOLT_TRAVEL, (object) SaveGame.Instance.ColonyAchievementTracker.radBoltTravelDistance, (object) this.travelDistance);
  }

  public override bool Success()
  {
    return (double) SaveGame.Instance.ColonyAchievementTracker.radBoltTravelDistance > (double) this.travelDistance;
  }
}
