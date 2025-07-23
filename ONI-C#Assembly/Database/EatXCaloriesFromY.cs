// Decompiled with JetBrains decompiler
// Type: Database.EatXCaloriesFromY
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;

#nullable disable
namespace Database;

public class EatXCaloriesFromY : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private int numCalories;
  private List<string> fromFoodType = new List<string>();

  public EatXCaloriesFromY(int numCalories, List<string> fromFoodType)
  {
    this.numCalories = numCalories;
    this.fromFoodType = fromFoodType;
  }

  public override bool Success()
  {
    return (double) WorldResourceAmountTracker<RationTracker>.Get().GetAmountConsumedForIDs(this.fromFoodType) / 1000.0 > (double) this.numCalories;
  }

  public void Deserialize(IReader reader)
  {
    this.numCalories = reader.ReadInt32();
    int capacity = reader.ReadInt32();
    this.fromFoodType = new List<string>(capacity);
    for (int index = 0; index < capacity; ++index)
      this.fromFoodType.Add(reader.ReadKleiString());
  }

  public override string GetProgress(bool complete)
  {
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.CALORIES_FROM_MEAT, (object) GameUtil.GetFormattedCalories(complete ? (float) this.numCalories * 1000f : WorldResourceAmountTracker<RationTracker>.Get().GetAmountConsumedForIDs(this.fromFoodType)), (object) GameUtil.GetFormattedCalories((float) this.numCalories * 1000f));
  }
}
