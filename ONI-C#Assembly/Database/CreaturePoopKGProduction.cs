// Decompiled with JetBrains decompiler
// Type: Database.CreaturePoopKGProduction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class CreaturePoopKGProduction : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private Tag poopElement;
  private float amountToPoop;

  public CreaturePoopKGProduction(Tag poopElement, float amountToPoop)
  {
    this.poopElement = poopElement;
    this.amountToPoop = amountToPoop;
  }

  public override bool Success()
  {
    return Game.Instance.savedInfo.creaturePoopAmount.ContainsKey(this.poopElement) && (double) Game.Instance.savedInfo.creaturePoopAmount[this.poopElement] >= (double) this.amountToPoop;
  }

  public void Deserialize(IReader reader)
  {
    this.amountToPoop = reader.ReadSingle();
    this.poopElement = new Tag(reader.ReadKleiString());
  }

  public override string GetProgress(bool complete)
  {
    float num = 0.0f;
    Game.Instance.savedInfo.creaturePoopAmount.TryGetValue(this.poopElement, out num);
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.POOP_PRODUCTION, (object) GameUtil.GetFormattedMass(complete ? this.amountToPoop : num, massFormat: GameUtil.MetricMassFormat.Tonne), (object) GameUtil.GetFormattedMass(this.amountToPoop, massFormat: GameUtil.MetricMassFormat.Tonne));
  }
}
