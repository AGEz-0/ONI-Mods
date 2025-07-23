// Decompiled with JetBrains decompiler
// Type: Database.NoDuplicantsCanDie
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class NoDuplicantsCanDie : ColonyAchievementRequirement
{
  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.NO_DUPES_HAVE_DIED.REQUIREMENT_NAME;
  }

  public override bool Success() => !SaveGame.Instance.ColonyAchievementTracker.HasAnyDupeDied;

  public override bool Fail() => SaveGame.Instance.ColonyAchievementTracker.HasAnyDupeDied;
}
