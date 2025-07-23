// Decompiled with JetBrains decompiler
// Type: Database.DiscoverGeothermalFacility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class DiscoverGeothermalFacility : VictoryColonyAchievementRequirement
{
  public override string Description() => this.GetProgress(this.Success());

  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.ACTIVATEGEOTHERMALPLANT.REQUIREMENTS.DISCOVER_GEOTHERMAL_FACILITY_DESCRIPTION;
  }

  public override string Name()
  {
    return (string) COLONY_ACHIEVEMENTS.ACTIVATEGEOTHERMALPLANT.REQUIREMENTS.DISCOVER_GEOTHERMAL_FACILITY_TITLE;
  }

  public override bool Success() => GeothermalPlantComponent.GeothermalFacilityDiscovered();
}
