﻿// Decompiled with JetBrains decompiler
// Type: Blueprints_DlcPack3
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class Blueprints_DlcPack3 : BlueprintProvider
{
  public override string[] GetRequiredDlcIds() => DlcManager.DLC3;

  public override void SetupBlueprints()
  {
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitBelt, PermitRarity.Universal, "permit_atmo_belt_3tone_purple", "atmo_belt_3tone_purple_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitBelt, PermitRarity.Universal, "permit_atmo_belt_circuit", "atmo_belt_biocircuit_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitBody, PermitRarity.Universal, "permit_atmosuit_basic_purple_wildberry", "atmosuit_basic_purple_wildberry_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitBody, PermitRarity.Universal, "permit_atmosuit_basic_orange", "atmosuit_basic_orange_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitShoes, PermitRarity.Universal, "permit_atmo_shoes_biocircuit", "atmo_shoes_biocircuit_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitShoes, PermitRarity.Universal, "permit_atmo_shoes_basic_green", "atmo_shoes_basic_green_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitGloves, PermitRarity.Universal, "permit_atmo_gloves_plum", "atmo_gloves_plum_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitGloves, PermitRarity.Universal, "permit_atmo_gloves_biocircuit", "atmo_gloves_biocircuit_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitHelmet, PermitRarity.Universal, "permit_atmo_helmet_gaudysweater_purple", "atmo_helmet_gaudysweater_purple_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.AtmoSuitHelmet, PermitRarity.Universal, "permit_atmo_helmet_biocircuit", "atmo_helmet_biocircuit_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeTops, PermitRarity.Universal, "permit_jumpsuit_vsuit_stellar", "jumpsuit_vsuit_stellar_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeTops, PermitRarity.Universal, "permit_pj_biocircuit_wildberry", "pj_biocircuit_wildberry_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeBottoms, PermitRarity.Universal, "permit_pants_extendedwaist_blue_wheezewort", "pants_extendedwaist_blue_wheezewort_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeBottoms, PermitRarity.Universal, "permit_pants_snapjacket_brine", "pants_snapjacket_brine_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeShoes, PermitRarity.Universal, "permit_shoes_basic_blue_wheezy", "shoes_basic_blue_wheezy_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeShoes, PermitRarity.Universal, "permit_shoes_futurespace_blue", "shoes_futurespace_blue_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeShoes, PermitRarity.Universal, "permit_shoes_vsuit_stellar", "shoes_vsuit_stellar_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeGloves, PermitRarity.Universal, "permit_gloves_basic_blue_wheezewort", "gloves_basic_blue_wheezewort_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeGloves, PermitRarity.Universal, "permit_gloves_puffer_orange", "gloves_puffer_orange_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeGloves, PermitRarity.Universal, "permit_gloves_futurespace_blue", "gloves_futurespace_blue_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeGloves, PermitRarity.Universal, "permit_gloves_vsuit_stellar", "gloves_vsuit_stellar_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeGloves, PermitRarity.Universal, "permit_gloves_snapjacket_brine", "gloves_snapjacket_brine_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeGloves, PermitRarity.Universal, "permit_gloves_metal_grey", "gloves_metal_grey_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeTops, PermitRarity.Universal, "permit_top_vest_puffer_orange", "top_vest_puffer_orange_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeTops, PermitRarity.Universal, "permit_top_spacetop_white", "top_spacetop_white_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeTops, PermitRarity.Universal, "permit_top_snapjacket_brine", "top_snapjacket_brine_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeTops, PermitRarity.Universal, "permit_top_metal_grey", "top_metal_grey_kanim");
    this.AddClothing(BlueprintProvider.ClothingType.DupeTops, PermitRarity.Universal, "permit_dress_futurespace_blue", "dress_futurespace_blue_kanim");
    this.AddBuilding("ItemPedestal", PermitRarity.Universal, "permit_pedestal_screw_chrome", "pedestal_screw_chrome_kanim");
    this.AddBuilding("ItemPedestal", PermitRarity.Universal, "permit_pedestal_screw_brass", "pedestal_screw_brass_kanim");
    this.AddBuilding("ItemPedestal", PermitRarity.Universal, "permit_pedestal_arcade", "pedestal_arcade_kanim");
    this.AddBuilding("ItemPedestal", PermitRarity.Universal, "permit_pedestal_battery", "pedestal_battery_kanim");
    this.AddBuilding("Headquarters", PermitRarity.Universal, "permit_hqbase_cyberpunk", "hqbase_cyberpunk_kanim");
    this.AddBuilding("ResearchCenter", PermitRarity.Universal, "permit_research_center_cyberpunk", "research_center_cyberpunk_kanim");
    this.AddBuilding("AdvancedResearchCenter", PermitRarity.Universal, "permit_research_center2_cyberpunk", "research_center2_cyberpunk_kanim");
    this.AddBuilding("LogicGateDemultiplexer", PermitRarity.Universal, "permit_logic_demultiplexer_lightcobalt", "logic_demultiplexer_lightcobalt_kanim");
    this.AddBuilding("LogicGateMultiplexer", PermitRarity.Universal, "permit_logic_multiplexer_lightcobalt", "logic_multiplexer_lightcobalt_kanim");
    this.AddBuilding("LogicGateFILTER", PermitRarity.Universal, "permit_logic_filter_lightcobalt", "logic_filter_lightcobalt_kanim");
    this.AddBuilding("LogicGateBUFFER", PermitRarity.Universal, "permit_logic_buffer_lightcobalt", "logic_buffer_lightcobalt_kanim");
    this.AddBuilding("LogicGateNOT", PermitRarity.Universal, "permit_logic_not_lightcobalt", "logic_not_lightcobalt_kanim");
    this.AddBuilding(LogicCounterConfig.ID, PermitRarity.Universal, "permit_logic_counter_lightcobalt", "logic_counter_lightcobalt_kanim");
    this.AddBuilding("LogicGateOR", PermitRarity.Universal, "permit_logic_or_lightcobalt", "logic_or_lightcobalt_kanim");
    this.AddBuilding("LogicGateAND", PermitRarity.Universal, "permit_logic_and_lightcobalt", "logic_and_lightcobalt_kanim");
    this.AddBuilding("LogicGateXOR", PermitRarity.Universal, "permit_logic_xor_lightcobalt", "logic_xor_lightcobalt_kanim");
    this.AddBuilding(LogicMemoryConfig.ID, PermitRarity.Universal, "permit_logic_memory_lightcobalt", "logic_memory_lightcobalt_kanim");
    this.AddBuilding("LogicGateDemultiplexer", PermitRarity.Universal, "permit_logic_demultiplexer_flamingo", "logic_demultiplexer_flamingo_kanim");
    this.AddBuilding("LogicGateMultiplexer", PermitRarity.Universal, "permit_logic_multiplexer_flamingo", "logic_multiplexer_flamingo_kanim");
    this.AddBuilding("LogicGateFILTER", PermitRarity.Universal, "permit_logic_filter_flamingo", "logic_filter_flamingo_kanim");
    this.AddBuilding("LogicGateBUFFER", PermitRarity.Universal, "permit_logic_buffer_flamingo", "logic_buffer_flamingo_kanim");
    this.AddBuilding("LogicGateNOT", PermitRarity.Universal, "permit_logic_not_flamingo", "logic_not_flamingo_kanim");
    this.AddBuilding(LogicCounterConfig.ID, PermitRarity.Universal, "permit_logic_counter_flamingo", "logic_counter_flamingo_kanim");
    this.AddBuilding("LogicGateOR", PermitRarity.Universal, "permit_logic_or_flamingo", "logic_or_flamingo_kanim");
    this.AddBuilding("LogicGateAND", PermitRarity.Universal, "permit_logic_and_flamingo", "logic_and_flamingo_kanim");
    this.AddBuilding("LogicGateXOR", PermitRarity.Universal, "permit_logic_xor_flamingo", "logic_xor_flamingo_kanim");
    this.AddBuilding(LogicMemoryConfig.ID, PermitRarity.Universal, "permit_logic_memory_flamingo", "logic_memory_flamingo_kanim");
    this.AddBuilding("LogicGateDemultiplexer", PermitRarity.Universal, "permit_logic_demultiplexer_lemon", "logic_demultiplexer_lemon_kanim");
    this.AddBuilding("LogicGateMultiplexer", PermitRarity.Universal, "permit_logic_multiplexer_lemon", "logic_multiplexer_lemon_kanim");
    this.AddBuilding("LogicGateFILTER", PermitRarity.Universal, "permit_logic_filter_lemon", "logic_filter_lemon_kanim");
    this.AddBuilding("LogicGateBUFFER", PermitRarity.Universal, "permit_logic_buffer_lemon", "logic_buffer_lemon_kanim");
    this.AddBuilding("LogicGateNOT", PermitRarity.Universal, "permit_logic_not_lemon", "logic_not_lemon_kanim");
    this.AddBuilding(LogicCounterConfig.ID, PermitRarity.Universal, "permit_logic_counter_lemon", "logic_counter_lemon_kanim");
    this.AddBuilding("LogicGateOR", PermitRarity.Universal, "permit_logic_or_lemon", "logic_or_lemon_kanim");
    this.AddBuilding("LogicGateAND", PermitRarity.Universal, "permit_logic_and_lemon", "logic_and_lemon_kanim");
    this.AddBuilding("LogicGateXOR", PermitRarity.Universal, "permit_logic_xor_lemon", "logic_xor_lemon_kanim");
    this.AddBuilding(LogicMemoryConfig.ID, PermitRarity.Universal, "permit_logic_memory_lemon", "logic_memory_lemon_kanim");
    this.AddBuilding("LogicWireBridge", PermitRarity.Universal, "permit_logic_bridge_flamingo", "logic_bridge_flamingo_kanim");
    this.AddBuilding("LogicWire", PermitRarity.Universal, "permit_logic_wires_flamingo", "logic_wires_flamingo_kanim");
    this.AddBuilding("LogicRibbon", PermitRarity.Universal, "permit_logic_ribbon_flamingo", "logic_ribbon_flamingo_kanim");
    this.AddBuilding("LogicRibbonBridge", PermitRarity.Universal, "permit_logic_ribbon_bridge_flamingo", "logic_ribbon_bridge_flamingo_kanim");
    this.AddBuilding("LogicWireBridge", PermitRarity.Universal, "permit_logic_bridge_lemon", "logic_bridge_lemon_kanim");
    this.AddBuilding("LogicWire", PermitRarity.Universal, "permit_logic_wires_lemon", "logic_wires_lemon_kanim");
    this.AddBuilding("LogicRibbon", PermitRarity.Universal, "permit_logic_ribbon_lemon", "logic_ribbon_lemon_kanim");
    this.AddBuilding("LogicRibbonBridge", PermitRarity.Universal, "permit_logic_ribbon_bridge_lemon", "logic_ribbon_bridge_lemon_kanim");
    this.AddBuilding("LogicWireBridge", PermitRarity.Universal, "permit_logic_bridge_bogey", "logic_bridge_bogey_kanim");
    this.AddBuilding("LogicWire", PermitRarity.Universal, "permit_logic_wires_bogey", "logic_wires_bogey_kanim");
    this.AddBuilding("LogicRibbon", PermitRarity.Universal, "permit_logic_ribbon_bogey", "logic_ribbon_bogey_kanim");
    this.AddBuilding("LogicRibbonBridge", PermitRarity.Universal, "permit_logic_ribbon_bridge_bogey", "logic_ribbon_bridge_bogey_kanim");
    this.AddBuilding("WireRefined", PermitRarity.Universal, "permit_utilities_electric_conduct_net_pink", "utilities_electric_conduct_net_pink_kanim");
    this.AddBuilding("WireRefined", PermitRarity.Universal, "permit_utilities_electric_conduct_diamond_orchid", "utilities_electric_conduct_diamond_orchid_kanim");
    this.AddBuilding("WireRefined", PermitRarity.Universal, "permit_utilities_electric_conduct_scale_lime", "utilities_electric_conduct_scale_lime_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Bottom, PermitRarity.Universal, "permit_monument_base_a_bionic", "monument_base_a_bionic_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Bottom, PermitRarity.Universal, "permit_monument_base_b_bionic", "monument_base_b_bionic_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Bottom, PermitRarity.Universal, "permit_monument_base_c_bionic", "monument_base_c_bionic_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Middle, PermitRarity.Universal, "permit_monument_mid_a_bionic", "monument_mid_a_bionic_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Middle, PermitRarity.Universal, "permit_monument_mid_b_bionic", "monument_mid_b_bionic_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Middle, PermitRarity.Universal, "permit_monument_mid_c_bionic", "monument_mid_c_bionic_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Top, PermitRarity.Universal, "permit_monument_upper_a_bionic", "monument_upper_a_bionic_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Top, PermitRarity.Universal, "permit_monument_upper_b_bionic", "monument_upper_b_bionic_kanim");
    this.AddMonumentPart(BlueprintProvider.MonumentPart.Top, PermitRarity.Universal, "permit_monument_upper_c_bionic", "monument_upper_c_bionic_kanim");
    this.AddBuilding("ExteriorWall", PermitRarity.Universal, "permit_walls_circuit_lightcobalt", "walls_circuits_lightcobalt_kanim");
    this.AddBuilding("ExteriorWall", PermitRarity.Universal, "permit_walls_circuit_bogey", "walls_circuits_bogey_kanim");
    this.AddBuilding("ExteriorWall", PermitRarity.Universal, "permit_walls_circuit_punk", "walls_circuits_punk_kanim");
    this.AddBuilding("ExteriorWall", PermitRarity.Universal, "permit_walls_arcade", "walls_arcade_kanim");
    this.AddBuilding("WireRefinedBridge", PermitRarity.Universal, "permit_utilityelectricbridgeconductive_scale_lime", "utilityelectricbridgeconductive_scale_lime_kanim");
    this.AddBuilding("WireRefinedBridge", PermitRarity.Universal, "permit_utilityelectricbridgeconductive_net_pink", "utilityelectricbridgeconductive_net_pink_kanim");
    this.AddBuilding("WireRefinedBridge", PermitRarity.Universal, "permit_utilityelectricbridgeconductive_diamond_orchid", "utilityelectricbridgeconductive_diamond_orchid_kanim");
    this.AddBuilding("CraftingTable", PermitRarity.Universal, "permit_craftingstation_cyberpunk", "craftingstation_cyberpunk_kanim");
    this.AddOutfit(BlueprintProvider.OutfitType.Clothing, "outfit_sculpted_steel", new string[3]
    {
      "permit_dress_futurespace_blue",
      "permit_gloves_futurespace_blue",
      "permit_shoes_futurespace_blue"
    });
    this.AddOutfit(BlueprintProvider.OutfitType.Clothing, "outfit_starched_blazer", new string[3]
    {
      "permit_top_snapjacket_brine",
      "permit_pants_snapjacket_brine",
      "permit_gloves_snapjacket_brine"
    });
    this.AddOutfit(BlueprintProvider.OutfitType.Clothing, "outfit_aerodynamic_flightsuit", new string[3]
    {
      "permit_jumpsuit_vsuit_stellar",
      "permit_gloves_vsuit_stellar",
      "permit_shoes_vsuit_stellar"
    });
    this.AddOutfit(BlueprintProvider.OutfitType.Clothing, "outfit_all_metal_jacket", new string[2]
    {
      "permit_top_metal_grey",
      "permit_gloves_metal_grey"
    });
    this.AddOutfit(BlueprintProvider.OutfitType.Clothing, "outfit_space_expo", new string[4]
    {
      "permit_top_spacetop_white",
      "permit_pants_extendedwaist_blue_wheezewort",
      "permit_gloves_basic_blue_wheezewort",
      "permit_shoes_basic_blue_wheezy"
    });
    this.AddOutfit(BlueprintProvider.OutfitType.Clothing, "outfit_biocircuit", new string[1]
    {
      "permit_pj_biocircuit_wildberry"
    });
    this.AddOutfit(BlueprintProvider.OutfitType.Clothing, "outfit_cadmium_vest", new string[2]
    {
      "permit_top_vest_puffer_orange",
      "permit_gloves_puffer_orange"
    });
    this.AddOutfit(BlueprintProvider.OutfitType.AtmoSuit, "outfit_atmosuit_bionic", new string[5]
    {
      "permit_atmosuit_basic_purple_wildberry",
      "permit_atmo_helmet_biocircuit",
      "permit_atmo_belt_circuit",
      "permit_atmo_gloves_biocircuit",
      "permit_atmo_shoes_biocircuit"
    });
    this.AddOutfit(BlueprintProvider.OutfitType.AtmoSuit, "outfit_atmosuit_gaudy", new string[5]
    {
      "permit_atmo_helmet_gaudysweater_purple",
      "permit_atmo_belt_3tone_purple",
      "permit_atmo_gloves_plum",
      "permit_atmo_shoes_basic_green",
      "permit_atmosuit_basic_orange"
    });
  }
}
