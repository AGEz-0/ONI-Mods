﻿// Decompiled with JetBrains decompiler
// Type: Database.BeforeCycleNumber
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
namespace Database;

public class BeforeCycleNumber : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private int cycleNumber;

  public BeforeCycleNumber(int cycleNumber = 100) => this.cycleNumber = cycleNumber;

  public override bool Success() => GameClock.Instance.GetCycle() + 1 <= this.cycleNumber;

  public override bool Fail() => !this.Success();

  public void Deserialize(IReader reader) => this.cycleNumber = reader.ReadInt32();

  public override string GetProgress(bool complete)
  {
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.REMAINING_CYCLES, (object) Mathf.Max(this.cycleNumber - GameClock.Instance.GetCycle(), 0), (object) this.cycleNumber);
  }
}
