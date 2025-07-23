// Decompiled with JetBrains decompiler
// Type: Database.CoolBuildingToXKelvin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class CoolBuildingToXKelvin : 
  ColonyAchievementRequirement,
  AchievementRequirementSerialization_Deprecated
{
  private int kelvinToCoolTo;

  public CoolBuildingToXKelvin(int kelvinToCoolTo) => this.kelvinToCoolTo = kelvinToCoolTo;

  public override bool Success()
  {
    return (double) BuildingComplete.MinKelvinSeen <= (double) this.kelvinToCoolTo;
  }

  public void Deserialize(IReader reader) => this.kelvinToCoolTo = reader.ReadInt32();

  public override string GetProgress(bool complete)
  {
    float minKelvinSeen = BuildingComplete.MinKelvinSeen;
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.KELVIN_COOLING, (object) minKelvinSeen);
  }
}
