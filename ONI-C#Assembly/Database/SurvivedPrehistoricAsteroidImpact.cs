﻿// Decompiled with JetBrains decompiler
// Type: Database.SurvivedPrehistoricAsteroidImpact
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
namespace Database;

public class SurvivedPrehistoricAsteroidImpact : ColonyAchievementRequirement
{
  private int requiredCyclesAfterImpact;

  public SurvivedPrehistoricAsteroidImpact(int requiredCyclesAfterImpact)
  {
    this.requiredCyclesAfterImpact = requiredCyclesAfterImpact;
  }

  public override string GetProgress(bool complete)
  {
    int num = complete ? this.requiredCyclesAfterImpact : 0;
    if (!complete && SaveGame.Instance.ColonyAchievementTracker.largeImpactorLandedCycle >= 0)
      num = Mathf.Clamp(GameClock.Instance.GetCycle() - SaveGame.Instance.ColonyAchievementTracker.largeImpactorLandedCycle, 0, this.requiredCyclesAfterImpact);
    return GameUtil.SafeStringFormat((string) COLONY_ACHIEVEMENTS.ASTEROID_SURVIVED.REQUIREMENT_DESCRIPTION, (object) GameUtil.GetFormattedInt((float) num), (object) GameUtil.GetFormattedInt((float) this.requiredCyclesAfterImpact));
  }

  public override bool Success()
  {
    return SaveGame.Instance.ColonyAchievementTracker.largeImpactorLandedCycle >= 0 && GameClock.Instance.GetCycle() - SaveGame.Instance.ColonyAchievementTracker.largeImpactorLandedCycle >= this.requiredCyclesAfterImpact;
  }

  public override bool Fail()
  {
    return SaveGame.Instance.ColonyAchievementTracker.largeImpactorState == ColonyAchievementTracker.LargeImpactorState.Defeated;
  }
}
