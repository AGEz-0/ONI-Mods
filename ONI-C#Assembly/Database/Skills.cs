// Decompiled with JetBrains decompiler
// Type: Database.Skills
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;

#nullable disable
namespace Database;

public class Skills : ResourceSet<Skill>
{
  public Skill Mining1;
  public Skill Mining2;
  public Skill Mining3;
  public Skill Mining4;
  public Skill Building1;
  public Skill Building2;
  public Skill Building3;
  public Skill Farming1;
  public Skill Farming2;
  public Skill Farming3;
  public Skill Ranching1;
  public Skill Ranching2;
  public Skill Researching1;
  public Skill Researching2;
  public Skill Researching3;
  public Skill Researching4;
  public Skill AtomicResearch;
  public Skill SpaceResearch;
  public Skill Astronomy;
  public Skill RocketPiloting1;
  public Skill RocketPiloting2;
  public Skill Cooking1;
  public Skill Cooking2;
  public Skill Arting1;
  public Skill Arting2;
  public Skill Arting3;
  public Skill Hauling1;
  public Skill Hauling2;
  public Skill ThermalSuits;
  public Skill Suits1;
  public Skill Technicals1;
  public Skill Technicals2;
  public Skill Engineering1;
  public Skill Basekeeping1;
  public Skill Basekeeping2;
  public Skill Pyrotechnics;
  public Skill Astronauting1;
  public Skill Astronauting2;
  public Skill Medicine1;
  public Skill Medicine2;
  public Skill Medicine3;
  public Skill BionicsA1;
  public Skill BionicsA2;
  public Skill BionicsA3;
  public Skill BionicsB1;
  public Skill BionicsB2;
  public Skill BionicsB3;
  public Skill BionicsC1;
  public Skill BionicsC2;
  public Skill BionicsC3;

  public Skills(ResourceSet parent)
    : base(nameof (Skills), parent)
  {
    this.Mining1 = this.AddSkill(new Skill(nameof (Mining1), (string) DUPLICANTS.ROLES.JUNIOR_MINER.NAME, (string) DUPLICANTS.ROLES.JUNIOR_MINER.DESCRIPTION, 0, "hat_role_mining1", "skillbadge_role_mining1", Db.Get().SkillGroups.Mining.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseDigSpeedSmall,
      Db.Get().SkillPerks.CanDigVeryFirm
    }));
    this.Mining2 = this.AddSkill(new Skill(nameof (Mining2), (string) DUPLICANTS.ROLES.MINER.NAME, (string) DUPLICANTS.ROLES.MINER.DESCRIPTION, 1, "hat_role_mining2", "skillbadge_role_mining2", Db.Get().SkillGroups.Mining.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseDigSpeedMedium,
      Db.Get().SkillPerks.CanDigNearlyImpenetrable
    }, new List<string>() { this.Mining1.Id }));
    this.Mining3 = this.AddSkill(new Skill(nameof (Mining3), (string) DUPLICANTS.ROLES.SENIOR_MINER.NAME, (string) DUPLICANTS.ROLES.SENIOR_MINER.DESCRIPTION, 2, "hat_role_mining3", "skillbadge_role_mining3", Db.Get().SkillGroups.Mining.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseDigSpeedLarge,
      Db.Get().SkillPerks.CanDigSuperDuperHard
    }, new List<string>() { this.Mining2.Id }));
    string name1 = (string) DUPLICANTS.ROLES.MASTER_MINER.NAME;
    string description1 = (string) DUPLICANTS.ROLES.MASTER_MINER.DESCRIPTION;
    string id1 = Db.Get().SkillGroups.Mining.Id;
    List<SkillPerk> perks1 = new List<SkillPerk>();
    perks1.Add(Db.Get().SkillPerks.CanDigRadioactiveMaterials);
    List<string> priorSkills1 = new List<string>();
    priorSkills1.Add(this.Mining3.Id);
    string[] expansioN1_1 = DlcManager.EXPANSION1;
    this.Mining4 = this.AddSkill(new Skill(nameof (Mining4), name1, description1, 3, "hat_role_mining4", "skillbadge_role_mining4", id1, perks1, priorSkills1, requiredDlcIds: expansioN1_1));
    this.Building1 = this.AddSkill(new Skill(nameof (Building1), (string) DUPLICANTS.ROLES.JUNIOR_BUILDER.NAME, (string) DUPLICANTS.ROLES.JUNIOR_BUILDER.DESCRIPTION, 0, "hat_role_building1", "skillbadge_role_building1", Db.Get().SkillGroups.Building.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseConstructionSmall
    }));
    this.Building2 = this.AddSkill(new Skill(nameof (Building2), (string) DUPLICANTS.ROLES.BUILDER.NAME, (string) DUPLICANTS.ROLES.BUILDER.DESCRIPTION, 1, "hat_role_building2", "skillbadge_role_building2", Db.Get().SkillGroups.Building.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseConstructionMedium
    }, new List<string>() { this.Building1.Id }));
    this.Building3 = this.AddSkill(new Skill(nameof (Building3), (string) DUPLICANTS.ROLES.SENIOR_BUILDER.NAME, (string) DUPLICANTS.ROLES.SENIOR_BUILDER.DESCRIPTION, 2, "hat_role_building3", "skillbadge_role_building3", Db.Get().SkillGroups.Building.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseConstructionLarge,
      Db.Get().SkillPerks.CanDemolish
    }, new List<string>() { this.Building2.Id }));
    this.Farming1 = this.AddSkill(new Skill(nameof (Farming1), (string) DUPLICANTS.ROLES.JUNIOR_FARMER.NAME, (string) DUPLICANTS.ROLES.JUNIOR_FARMER.DESCRIPTION, 0, "hat_role_farming1", "skillbadge_role_farming1", Db.Get().SkillGroups.Farming.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseBotanySmall
    }));
    this.Farming2 = this.AddSkill(new Skill(nameof (Farming2), (string) DUPLICANTS.ROLES.FARMER.NAME, (string) DUPLICANTS.ROLES.FARMER.DESCRIPTION, 1, "hat_role_farming2", "skillbadge_role_farming2", Db.Get().SkillGroups.Farming.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseBotanyMedium,
      Db.Get().SkillPerks.CanFarmTinker,
      Db.Get().SkillPerks.CanFarmStation
    }, new List<string>() { this.Farming1.Id }));
    this.Farming3 = this.AddSkill(new Skill(nameof (Farming3), (string) DUPLICANTS.ROLES.SENIOR_FARMER.NAME, (string) DUPLICANTS.ROLES.SENIOR_FARMER.DESCRIPTION, 2, "hat_role_farming3", "skillbadge_role_farming3", Db.Get().SkillGroups.Farming.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseBotanyLarge
    }, new List<string>() { this.Farming2.Id }));
    if (DlcManager.FeaturePlantMutationsEnabled())
      this.Farming3.perks.Add(Db.Get().SkillPerks.CanIdentifyMutantSeeds);
    this.Ranching1 = this.AddSkill(new Skill(nameof (Ranching1), (string) DUPLICANTS.ROLES.RANCHER.NAME, (string) DUPLICANTS.ROLES.RANCHER.DESCRIPTION, 1, "hat_role_rancher1", "skillbadge_role_rancher1", Db.Get().SkillGroups.Ranching.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanWrangleCreatures,
      Db.Get().SkillPerks.CanUseRanchStation,
      Db.Get().SkillPerks.IncreaseRanchingSmall
    }, new List<string>() { this.Farming1.Id }));
    this.Ranching2 = this.AddSkill(new Skill(nameof (Ranching2), (string) DUPLICANTS.ROLES.SENIOR_RANCHER.NAME, (string) DUPLICANTS.ROLES.SENIOR_RANCHER.DESCRIPTION, 2, "hat_role_rancher2", "skillbadge_role_rancher2", Db.Get().SkillGroups.Ranching.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanUseMilkingStation,
      Db.Get().SkillPerks.IncreaseRanchingMedium
    }, new List<string>() { this.Ranching1.Id }));
    this.Researching1 = this.AddSkill(new Skill(nameof (Researching1), (string) DUPLICANTS.ROLES.JUNIOR_RESEARCHER.NAME, (string) DUPLICANTS.ROLES.JUNIOR_RESEARCHER.DESCRIPTION, 0, "hat_role_research1", "skillbadge_role_research1", Db.Get().SkillGroups.Research.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseLearningSmall,
      Db.Get().SkillPerks.AllowAdvancedResearch,
      Db.Get().SkillPerks.AllowChemistry
    }));
    this.Researching2 = this.AddSkill(new Skill(nameof (Researching2), (string) DUPLICANTS.ROLES.RESEARCHER.NAME, (string) DUPLICANTS.ROLES.RESEARCHER.DESCRIPTION, 1, "hat_role_research2", "skillbadge_role_research2", Db.Get().SkillGroups.Research.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseLearningMedium,
      Db.Get().SkillPerks.CanStudyWorldObjects,
      Db.Get().SkillPerks.AllowGeyserTuning
    }, new List<string>() { this.Researching1.Id }));
    string name2 = (string) DUPLICANTS.ROLES.NUCLEAR_RESEARCHER.NAME;
    string description2 = (string) DUPLICANTS.ROLES.NUCLEAR_RESEARCHER.DESCRIPTION;
    string id2 = Db.Get().SkillGroups.Research.Id;
    List<SkillPerk> perks2 = new List<SkillPerk>();
    perks2.Add(Db.Get().SkillPerks.IncreaseLearningLarge);
    perks2.Add(Db.Get().SkillPerks.AllowNuclearResearch);
    List<string> priorSkills2 = new List<string>();
    priorSkills2.Add(this.Researching2.Id);
    string[] expansioN1_2 = DlcManager.EXPANSION1;
    this.AtomicResearch = this.AddSkill(new Skill(nameof (AtomicResearch), name2, description2, 2, "hat_role_research5", "skillbadge_role_research3", id2, perks2, priorSkills2, requiredDlcIds: expansioN1_2));
    string name3 = (string) DUPLICANTS.ROLES.NUCLEAR_RESEARCHER.NAME;
    string description3 = (string) DUPLICANTS.ROLES.NUCLEAR_RESEARCHER.DESCRIPTION;
    string id3 = Db.Get().SkillGroups.Research.Id;
    List<SkillPerk> perks3 = new List<SkillPerk>();
    perks3.Add(Db.Get().SkillPerks.IncreaseLearningLarge);
    perks3.Add(Db.Get().SkillPerks.AllowNuclearResearch);
    List<string> priorSkills3 = new List<string>();
    priorSkills3.Add(this.Researching2.Id);
    string[] expansioN1_3 = DlcManager.EXPANSION1;
    this.Researching4 = this.AddSkill(new Skill(nameof (Researching4), name3, description3, 2, "hat_role_research4", "skillbadge_role_research3", id3, perks3, priorSkills3, requiredDlcIds: expansioN1_3));
    this.Researching4.deprecated = true;
    this.Researching3 = this.AddSkill(new Skill(nameof (Researching3), (string) DUPLICANTS.ROLES.SENIOR_RESEARCHER.NAME, (string) DUPLICANTS.ROLES.SENIOR_RESEARCHER.DESCRIPTION, 2, "hat_role_research3", "skillbadge_role_research3", Db.Get().SkillGroups.Research.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseLearningLarge,
      Db.Get().SkillPerks.AllowInterstellarResearch,
      Db.Get().SkillPerks.CanMissionControl
    }, new List<string>() { this.Researching2.Id }));
    this.Researching3.deprecated = DlcManager.IsExpansion1Active();
    string name4 = (string) DUPLICANTS.ROLES.SENIOR_RESEARCHER.NAME;
    string description4 = (string) DUPLICANTS.ROLES.SENIOR_RESEARCHER.DESCRIPTION;
    string id4 = Db.Get().SkillGroups.Research.Id;
    List<SkillPerk> perks4 = new List<SkillPerk>();
    perks4.Add(Db.Get().SkillPerks.CanUseClusterTelescope);
    perks4.Add(Db.Get().SkillPerks.CanUseClusterTelescopeEnclosed);
    perks4.Add(Db.Get().SkillPerks.CanMissionControl);
    List<string> priorSkills4 = new List<string>();
    priorSkills4.Add(this.Researching1.Id);
    string[] expansioN1_4 = DlcManager.EXPANSION1;
    this.Astronomy = this.AddSkill(new Skill(nameof (Astronomy), name4, description4, 1, "hat_role_research3", "skillbadge_role_research2", id4, perks4, priorSkills4, requiredDlcIds: expansioN1_4));
    string name5 = (string) DUPLICANTS.ROLES.SPACE_RESEARCHER.NAME;
    string description5 = (string) DUPLICANTS.ROLES.SPACE_RESEARCHER.DESCRIPTION;
    string id5 = Db.Get().SkillGroups.Research.Id;
    List<SkillPerk> perks5 = new List<SkillPerk>();
    perks5.Add(Db.Get().SkillPerks.IncreaseLearningLargeSpace);
    perks5.Add(Db.Get().SkillPerks.AllowOrbitalResearch);
    List<string> priorSkills5 = new List<string>();
    priorSkills5.Add(this.Astronomy.Id);
    string[] expansioN1_5 = DlcManager.EXPANSION1;
    this.SpaceResearch = this.AddSkill(new Skill(nameof (SpaceResearch), name5, description5, 2, "hat_role_research4", "skillbadge_role_research3", id5, perks5, priorSkills5, requiredDlcIds: expansioN1_5));
    if (DlcManager.IsExpansion1Active())
    {
      string name6 = (string) DUPLICANTS.ROLES.ROCKETPILOT.NAME;
      string description6 = (string) DUPLICANTS.ROLES.ROCKETPILOT.DESCRIPTION;
      string id6 = Db.Get().SkillGroups.Rocketry.Id;
      List<SkillPerk> perks6 = new List<SkillPerk>();
      perks6.Add(Db.Get().SkillPerks.CanUseRocketControlStation);
      List<string> priorSkills6 = new List<string>();
      string[] expansioN1_6 = DlcManager.EXPANSION1;
      this.RocketPiloting1 = this.AddSkill(new Skill(nameof (RocketPiloting1), name6, description6, 0, "hat_role_astronaut1", "skillbadge_role_rocketry1", id6, perks6, priorSkills6, requiredDlcIds: expansioN1_6));
      string name7 = (string) DUPLICANTS.ROLES.SENIOR_ROCKETPILOT.NAME;
      string description7 = (string) DUPLICANTS.ROLES.SENIOR_ROCKETPILOT.DESCRIPTION;
      string id7 = Db.Get().SkillGroups.Rocketry.Id;
      List<SkillPerk> perks7 = new List<SkillPerk>();
      perks7.Add(Db.Get().SkillPerks.IncreaseRocketSpeedSmall);
      List<string> priorSkills7 = new List<string>();
      priorSkills7.Add(this.RocketPiloting1.Id);
      priorSkills7.Add(this.Astronomy.Id);
      string[] expansioN1_7 = DlcManager.EXPANSION1;
      this.RocketPiloting2 = this.AddSkill(new Skill(nameof (RocketPiloting2), name7, description7, 2, "hat_role_astronaut2", "skillbadge_role_rocketry3", id7, perks7, priorSkills7, requiredDlcIds: expansioN1_7));
    }
    this.Cooking1 = this.AddSkill(new Skill(nameof (Cooking1), (string) DUPLICANTS.ROLES.JUNIOR_COOK.NAME, (string) DUPLICANTS.ROLES.JUNIOR_COOK.DESCRIPTION, 0, "hat_role_cooking1", "skillbadge_role_cooking1", Db.Get().SkillGroups.Cooking.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseCookingSmall,
      Db.Get().SkillPerks.CanElectricGrill,
      Db.Get().SkillPerks.CanGasRange,
      Db.Get().SkillPerks.CanDeepFry
    }));
    this.Cooking2 = this.AddSkill(new Skill(nameof (Cooking2), (string) DUPLICANTS.ROLES.COOK.NAME, (string) DUPLICANTS.ROLES.COOK.DESCRIPTION, 1, "hat_role_cooking2", "skillbadge_role_cooking2", Db.Get().SkillGroups.Cooking.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseCookingMedium,
      Db.Get().SkillPerks.CanSpiceGrinder
    }, new List<string>() { this.Cooking1.Id }));
    this.Arting1 = this.AddSkill(new Skill(nameof (Arting1), (string) DUPLICANTS.ROLES.JUNIOR_ARTIST.NAME, (string) DUPLICANTS.ROLES.JUNIOR_ARTIST.DESCRIPTION, 0, "hat_role_art1", "skillbadge_role_art1", Db.Get().SkillGroups.Art.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanArt,
      Db.Get().SkillPerks.CanArtUgly,
      Db.Get().SkillPerks.IncreaseArtSmall
    }));
    this.Arting2 = this.AddSkill(new Skill(nameof (Arting2), (string) DUPLICANTS.ROLES.ARTIST.NAME, (string) DUPLICANTS.ROLES.ARTIST.DESCRIPTION, 1, "hat_role_art2", "skillbadge_role_art2", Db.Get().SkillGroups.Art.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanArtOkay,
      Db.Get().SkillPerks.IncreaseArtMedium,
      Db.Get().SkillPerks.CanClothingAlteration
    }, new List<string>() { this.Arting1.Id }));
    if (DlcManager.FeatureClusterSpaceEnabled())
      this.Arting2.perks.Add(Db.Get().SkillPerks.CanStudyArtifact);
    this.Arting3 = this.AddSkill(new Skill(nameof (Arting3), (string) DUPLICANTS.ROLES.MASTER_ARTIST.NAME, (string) DUPLICANTS.ROLES.MASTER_ARTIST.DESCRIPTION, 2, "hat_role_art3", "skillbadge_role_art3", Db.Get().SkillGroups.Art.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanArtGreat,
      Db.Get().SkillPerks.IncreaseArtLarge
    }, new List<string>() { this.Arting2.Id }));
    this.Hauling1 = this.AddSkill(new Skill(nameof (Hauling1), (string) DUPLICANTS.ROLES.HAULER.NAME, (string) DUPLICANTS.ROLES.HAULER.DESCRIPTION, 0, "hat_role_hauling1", "skillbadge_role_hauling1", Db.Get().SkillGroups.Hauling.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseStrengthGofer,
      Db.Get().SkillPerks.IncreaseCarryAmountSmall
    }));
    this.Hauling2 = this.AddSkill(new Skill(nameof (Hauling2), (string) DUPLICANTS.ROLES.MATERIALS_MANAGER.NAME, (string) DUPLICANTS.ROLES.MATERIALS_MANAGER.DESCRIPTION, 1, "hat_role_hauling2", "skillbadge_role_hauling2", Db.Get().SkillGroups.Hauling.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseStrengthCourier,
      Db.Get().SkillPerks.IncreaseCarryAmountMedium
    }, new List<string>() { this.Hauling1.Id }));
    if (DlcManager.IsExpansion1Active())
    {
      string name8 = (string) DUPLICANTS.ROLES.SUIT_DURABILITY.NAME;
      string description8 = (string) DUPLICANTS.ROLES.SUIT_DURABILITY.DESCRIPTION;
      string id8 = Db.Get().SkillGroups.Suits.Id;
      List<SkillPerk> perks8 = new List<SkillPerk>();
      perks8.Add(Db.Get().SkillPerks.IncreaseAthleticsLarge);
      perks8.Add(Db.Get().SkillPerks.ExosuitDurability);
      List<string> priorSkills8 = new List<string>();
      priorSkills8.Add(this.Hauling1.Id);
      priorSkills8.Add(this.RocketPiloting1.Id);
      string[] expansioN1_8 = DlcManager.EXPANSION1;
      this.ThermalSuits = this.AddSkill(new Skill(nameof (ThermalSuits), name8, description8, 1, "hat_role_suits1", "skillbadge_role_suits2", id8, perks8, priorSkills8, requiredDlcIds: expansioN1_8));
    }
    else
      this.ThermalSuits = this.AddSkill(new Skill(nameof (ThermalSuits), (string) DUPLICANTS.ROLES.SUIT_DURABILITY.NAME, (string) DUPLICANTS.ROLES.SUIT_DURABILITY.DESCRIPTION, 1, "hat_role_suits1", "skillbadge_role_suits2", Db.Get().SkillGroups.Suits.Id, new List<SkillPerk>()
      {
        Db.Get().SkillPerks.IncreaseAthleticsLarge,
        Db.Get().SkillPerks.ExosuitDurability
      }, new List<string>() { this.Hauling1.Id }));
    this.Suits1 = this.AddSkill(new Skill(nameof (Suits1), (string) DUPLICANTS.ROLES.SUIT_EXPERT.NAME, (string) DUPLICANTS.ROLES.SUIT_EXPERT.DESCRIPTION, 2, "hat_role_suits2", "skillbadge_role_suits3", Db.Get().SkillGroups.Suits.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.ExosuitExpertise,
      Db.Get().SkillPerks.IncreaseAthleticsMedium
    }, new List<string>() { this.ThermalSuits.Id }));
    this.Technicals1 = this.AddSkill(new Skill(nameof (Technicals1), (string) DUPLICANTS.ROLES.MACHINE_TECHNICIAN.NAME, (string) DUPLICANTS.ROLES.MACHINE_TECHNICIAN.DESCRIPTION, 0, "hat_role_technicals1", "skillbadge_role_technicals1", Db.Get().SkillGroups.Technicals.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseMachinerySmall
    }));
    this.Technicals2 = this.AddSkill(new Skill(nameof (Technicals2), (string) DUPLICANTS.ROLES.POWER_TECHNICIAN.NAME, (string) DUPLICANTS.ROLES.POWER_TECHNICIAN.DESCRIPTION, 1, "hat_role_technicals2", "skillbadge_role_technicals2", Db.Get().SkillGroups.Technicals.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseMachineryMedium,
      Db.Get().SkillPerks.CanPowerTinker,
      Db.Get().SkillPerks.CanCraftElectronics
    }, new List<string>() { this.Technicals1.Id }));
    this.Engineering1 = this.AddSkill(new Skill(nameof (Engineering1), (string) DUPLICANTS.ROLES.MECHATRONIC_ENGINEER.NAME, (string) DUPLICANTS.ROLES.MECHATRONIC_ENGINEER.DESCRIPTION, 2, "hat_role_engineering1", "skillbadge_role_engineering1", Db.Get().SkillGroups.Technicals.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseMachineryLarge,
      Db.Get().SkillPerks.IncreaseConstructionMechatronics,
      Db.Get().SkillPerks.ConveyorBuild
    }, new List<string>()
    {
      this.Hauling2.Id,
      this.Technicals2.Id
    }));
    this.Basekeeping1 = this.AddSkill(new Skill(nameof (Basekeeping1), (string) DUPLICANTS.ROLES.HANDYMAN.NAME, (string) DUPLICANTS.ROLES.HANDYMAN.DESCRIPTION, 0, "hat_role_basekeeping1", "skillbadge_role_basekeeping1", Db.Get().SkillGroups.Basekeeping.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseStrengthGroundskeeper
    }));
    this.Basekeeping2 = this.AddSkill(new Skill(nameof (Basekeeping2), (string) DUPLICANTS.ROLES.PLUMBER.NAME, (string) DUPLICANTS.ROLES.PLUMBER.DESCRIPTION, 1, "hat_role_basekeeping2", "skillbadge_role_basekeeping2", Db.Get().SkillGroups.Basekeeping.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.IncreaseStrengthPlumber,
      Db.Get().SkillPerks.CanDoPlumbing
    }, new List<string>() { this.Basekeeping1.Id }));
    this.Pyrotechnics = this.AddSkill(new Skill(nameof (Pyrotechnics), (string) DUPLICANTS.ROLES.PYROTECHNIC.NAME, (string) DUPLICANTS.ROLES.PYROTECHNIC.DESCRIPTION, 2, "hat_role_pyrotechnics", "skillbadge_role_basekeeping3", Db.Get().SkillGroups.Basekeeping.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanMakeMissiles
    }, new List<string>() { this.Basekeeping2.Id }));
    if (DlcManager.IsExpansion1Active())
    {
      string name9 = (string) DUPLICANTS.ROLES.USELESSSKILL.NAME;
      string description9 = (string) DUPLICANTS.ROLES.USELESSSKILL.DESCRIPTION;
      string id9 = Db.Get().SkillGroups.Suits.Id;
      List<SkillPerk> perks9 = new List<SkillPerk>();
      perks9.Add(Db.Get().SkillPerks.IncreaseAthleticsMedium);
      List<string> priorSkills9 = new List<string>();
      priorSkills9.Add(this.Researching3.Id);
      priorSkills9.Add(this.Suits1.Id);
      string[] expansioN1_9 = DlcManager.EXPANSION1;
      this.Astronauting1 = this.AddSkill(new Skill(nameof (Astronauting1), name9, description9, 3, "hat_role_astronaut1", "skillbadge_role_astronaut1", id9, perks9, priorSkills9, requiredDlcIds: expansioN1_9));
      this.Astronauting1.deprecated = true;
      string name10 = (string) DUPLICANTS.ROLES.USELESSSKILL.NAME;
      string description10 = (string) DUPLICANTS.ROLES.USELESSSKILL.DESCRIPTION;
      string id10 = Db.Get().SkillGroups.Suits.Id;
      List<SkillPerk> perks10 = new List<SkillPerk>();
      perks10.Add(Db.Get().SkillPerks.IncreaseAthleticsMedium);
      List<string> priorSkills10 = new List<string>();
      priorSkills10.Add(this.Astronauting1.Id);
      string[] expansioN1_10 = DlcManager.EXPANSION1;
      this.Astronauting2 = this.AddSkill(new Skill(nameof (Astronauting2), name10, description10, 4, "hat_role_astronaut2", "skillbadge_role_astronaut2", id10, perks10, priorSkills10, requiredDlcIds: expansioN1_10));
      this.Astronauting2.deprecated = true;
    }
    else
    {
      this.Astronauting1 = this.AddSkill(new Skill(nameof (Astronauting1), (string) DUPLICANTS.ROLES.ASTRONAUTTRAINEE.NAME, (string) DUPLICANTS.ROLES.ASTRONAUTTRAINEE.DESCRIPTION, 3, "hat_role_astronaut1", "skillbadge_role_astronaut1", Db.Get().SkillGroups.Suits.Id, new List<SkillPerk>()
      {
        Db.Get().SkillPerks.CanUseRockets
      }, new List<string>()
      {
        this.Researching3.Id,
        this.Suits1.Id
      }));
      this.Astronauting2 = this.AddSkill(new Skill(nameof (Astronauting2), (string) DUPLICANTS.ROLES.ASTRONAUT.NAME, (string) DUPLICANTS.ROLES.ASTRONAUT.DESCRIPTION, 4, "hat_role_astronaut2", "skillbadge_role_astronaut2", Db.Get().SkillGroups.Suits.Id, new List<SkillPerk>()
      {
        Db.Get().SkillPerks.FasterSpaceFlight
      }, new List<string>() { this.Astronauting1.Id }));
    }
    this.Medicine1 = this.AddSkill(new Skill(nameof (Medicine1), (string) DUPLICANTS.ROLES.JUNIOR_MEDIC.NAME, (string) DUPLICANTS.ROLES.JUNIOR_MEDIC.DESCRIPTION, 0, "hat_role_medicalaid1", "skillbadge_role_medicalaid1", Db.Get().SkillGroups.MedicalAid.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanCompound,
      Db.Get().SkillPerks.IncreaseCaringSmall
    }));
    this.Medicine2 = this.AddSkill(new Skill(nameof (Medicine2), (string) DUPLICANTS.ROLES.MEDIC.NAME, (string) DUPLICANTS.ROLES.MEDIC.DESCRIPTION, 1, "hat_role_medicalaid2", "skillbadge_role_medicalaid2", Db.Get().SkillGroups.MedicalAid.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanDoctor,
      Db.Get().SkillPerks.IncreaseCaringMedium
    }, new List<string>() { this.Medicine1.Id }));
    this.Medicine3 = this.AddSkill(new Skill(nameof (Medicine3), (string) DUPLICANTS.ROLES.SENIOR_MEDIC.NAME, (string) DUPLICANTS.ROLES.SENIOR_MEDIC.DESCRIPTION, 2, "hat_role_medicalaid3", "skillbadge_role_medicalaid3", Db.Get().SkillGroups.MedicalAid.Id, new List<SkillPerk>()
    {
      Db.Get().SkillPerks.CanAdvancedMedicine,
      Db.Get().SkillPerks.IncreaseCaringLarge
    }, new List<string>() { this.Medicine2.Id }));
    if (!DlcManager.IsContentSubscribed("DLC3_ID"))
      return;
    string name11 = (string) DUPLICANTS.ROLES.BIONICS_A1.NAME;
    string description11 = (string) DUPLICANTS.ROLES.BIONICS_A1.DESCRIPTION;
    string id11 = Db.Get().SkillGroups.BionicSkills.Id;
    List<SkillPerk> perks11 = new List<SkillPerk>();
    perks11.Add(Db.Get().SkillPerks.ExtraBionicBooster1);
    List<string> priorSkills11 = new List<string>();
    string name12 = GameTags.Minions.Models.Bionic.Name;
    string[] dlC3_1 = DlcManager.DLC3;
    this.BionicsA1 = this.AddSkill(new Skill(nameof (BionicsA1), name11, description11, 0, "hat_role_gainingboosters1", "skillbadge_bionic_booster1", id11, perks11, priorSkills11, name12, dlC3_1));
    string name13 = (string) DUPLICANTS.ROLES.BIONICS_A2.NAME;
    string description12 = (string) DUPLICANTS.ROLES.BIONICS_A2.DESCRIPTION;
    string id12 = Db.Get().SkillGroups.BionicSkills.Id;
    List<SkillPerk> perks12 = new List<SkillPerk>();
    perks12.Add(Db.Get().SkillPerks.ExtraBionicBooster2);
    perks12.Add(Db.Get().SkillPerks.IncreaseAthleticsBionicsA2);
    List<string> priorSkills12 = new List<string>();
    priorSkills12.Add(this.BionicsA1.Id);
    string name14 = GameTags.Minions.Models.Bionic.Name;
    string[] dlC3_2 = DlcManager.DLC3;
    this.BionicsA2 = this.AddSkill(new Skill(nameof (BionicsA2), name13, description12, 1, "hat_role_gainingboosters2", "skillbadge_bionic_booster2", id12, perks12, priorSkills12, name14, dlC3_2));
    string name15 = (string) DUPLICANTS.ROLES.BIONICS_A3.NAME;
    string description13 = (string) DUPLICANTS.ROLES.BIONICS_A3.DESCRIPTION;
    string id13 = Db.Get().SkillGroups.BionicSkills.Id;
    List<SkillPerk> perks13 = new List<SkillPerk>();
    perks13.Add(Db.Get().SkillPerks.ExtraBionicBooster3);
    perks13.Add(Db.Get().SkillPerks.ExosuitExpertise);
    List<string> priorSkills13 = new List<string>();
    priorSkills13.Add(this.BionicsA2.Id);
    string name16 = GameTags.Minions.Models.Bionic.Name;
    string[] dlC3_3 = DlcManager.DLC3;
    this.BionicsA3 = this.AddSkill(new Skill(nameof (BionicsA3), name15, description13, 2, "hat_role_gainingboosters3", "skillbadge_bionic_booster3", id13, perks13, priorSkills13, name16, dlC3_3));
    string name17 = (string) DUPLICANTS.ROLES.BIONICS_B1.NAME;
    string description14 = (string) DUPLICANTS.ROLES.BIONICS_B1.DESCRIPTION;
    string id14 = Db.Get().SkillGroups.BionicSkills.Id;
    List<SkillPerk> perks14 = new List<SkillPerk>();
    perks14.Add(Db.Get().SkillPerks.EfficientBionicGears);
    List<string> priorSkills14 = new List<string>();
    string name18 = GameTags.Minions.Models.Bionic.Name;
    string[] dlC3_4 = DlcManager.DLC3;
    this.BionicsB1 = this.AddSkill(new Skill(nameof (BionicsB1), name17, description14, 0, "hat_role_innerworkings1", "skillbadge_bionic_gears1", id14, perks14, priorSkills14, name18, dlC3_4));
    string name19 = (string) DUPLICANTS.ROLES.BIONICS_B2.NAME;
    string description15 = (string) DUPLICANTS.ROLES.BIONICS_B2.DESCRIPTION;
    string id15 = Db.Get().SkillGroups.BionicSkills.Id;
    List<SkillPerk> perks15 = new List<SkillPerk>();
    perks15.Add(Db.Get().SkillPerks.ExtraBionicBooster4);
    perks15.Add(Db.Get().SkillPerks.IncreaseAthleticsBionicsB2);
    List<string> priorSkills15 = new List<string>();
    priorSkills15.Add(this.BionicsB1.Id);
    string name20 = GameTags.Minions.Models.Bionic.Name;
    string[] dlC3_5 = DlcManager.DLC3;
    this.BionicsB2 = this.AddSkill(new Skill(nameof (BionicsB2), name19, description15, 1, "hat_role_innerworkings2", "skillbadge_bionic_gears2", id15, perks15, priorSkills15, name20, dlC3_5));
    string name21 = (string) DUPLICANTS.ROLES.BIONICS_C1.NAME;
    string description16 = (string) DUPLICANTS.ROLES.BIONICS_C1.DESCRIPTION;
    string id16 = Db.Get().SkillGroups.BionicSkills.Id;
    List<SkillPerk> perks16 = new List<SkillPerk>();
    perks16.Add(Db.Get().SkillPerks.CanCraftElectronics);
    perks16.Add(Db.Get().SkillPerks.IncreaseAthleticsBionicsC1);
    List<string> priorSkills16 = new List<string>();
    string name22 = GameTags.Minions.Models.Bionic.Name;
    string[] dlC3_6 = DlcManager.DLC3;
    this.BionicsC1 = this.AddSkill(new Skill(nameof (BionicsC1), name21, description16, 0, "hat_role_craftingboosters1", "skillbadge_bionic_schematics1", id16, perks16, priorSkills16, name22, dlC3_6));
    string name23 = (string) DUPLICANTS.ROLES.BIONICS_C2.NAME;
    string description17 = (string) DUPLICANTS.ROLES.BIONICS_C2.DESCRIPTION;
    string id17 = Db.Get().SkillGroups.BionicSkills.Id;
    List<SkillPerk> perks17 = new List<SkillPerk>();
    perks17.Add(Db.Get().SkillPerks.ExtraBionicBooster6);
    perks17.Add(Db.Get().SkillPerks.IncreaseAthleticsBionicsC2);
    List<string> priorSkills17 = new List<string>();
    priorSkills17.Add(this.BionicsC1.Id);
    string name24 = GameTags.Minions.Models.Bionic.Name;
    string[] dlC3_7 = DlcManager.DLC3;
    this.BionicsC2 = this.AddSkill(new Skill(nameof (BionicsC2), name23, description17, 1, "hat_role_craftingboosters2", "skillbadge_bionic_schematics2", id17, perks17, priorSkills17, name24, dlC3_7));
    string name25 = (string) DUPLICANTS.ROLES.BIONICS_C3.NAME;
    string description18 = (string) DUPLICANTS.ROLES.BIONICS_C3.DESCRIPTION;
    string id18 = Db.Get().SkillGroups.BionicSkills.Id;
    List<SkillPerk> perks18 = new List<SkillPerk>();
    perks18.Add(Db.Get().SkillPerks.ExtraBionicBatteries);
    List<string> priorSkills18 = new List<string>();
    priorSkills18.Add(this.BionicsB2.Id);
    priorSkills18.Add(this.BionicsC2.Id);
    string name26 = GameTags.Minions.Models.Bionic.Name;
    string[] dlC3_8 = DlcManager.DLC3;
    this.BionicsC3 = this.AddSkill(new Skill(nameof (BionicsC3), name25, description18, 2, "hat_role_innerworkings3", "skillbadge_bionic_gears3", id18, perks18, priorSkills18, name26, dlC3_8));
  }

  private Skill AddSkill(Skill skill)
  {
    return DlcManager.IsCorrectDlcSubscribed((IHasDlcRestrictions) skill) ? this.Add(skill) : skill;
  }

  public List<Skill> GetSkillsWithPerk(string perk)
  {
    List<Skill> skillsWithPerk = new List<Skill>();
    foreach (Skill resource in this.resources)
    {
      if (resource.GivesPerk((HashedString) perk))
        skillsWithPerk.Add(resource);
    }
    return skillsWithPerk;
  }

  public List<Skill> GetSkillsWithPerk(SkillPerk perk)
  {
    List<Skill> skillsWithPerk = new List<Skill>();
    foreach (Skill resource in this.resources)
    {
      if (resource.GivesPerk(perk))
        skillsWithPerk.Add(resource);
    }
    return skillsWithPerk;
  }

  public List<Skill> GetAllPriorSkills(Skill skill)
  {
    List<Skill> allPriorSkills = new List<Skill>();
    foreach (string priorSkill in skill.priorSkills)
    {
      Skill skill1 = this.Get(priorSkill);
      allPriorSkills.Add(skill1);
      allPriorSkills.AddRange((IEnumerable<Skill>) this.GetAllPriorSkills(skill1));
    }
    return allPriorSkills;
  }

  public List<Skill> GetTerminalSkills()
  {
    List<Skill> terminalSkills = new List<Skill>();
    foreach (Skill resource1 in this.resources)
    {
      bool flag = true;
      foreach (Skill resource2 in this.resources)
      {
        if (resource2.priorSkills.Contains(resource1.Id))
        {
          flag = false;
          break;
        }
      }
      if (flag)
        terminalSkills.Add(resource1);
    }
    return terminalSkills;
  }
}
