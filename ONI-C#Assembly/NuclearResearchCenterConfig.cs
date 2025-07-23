﻿// Decompiled with JetBrains decompiler
// Type: NuclearResearchCenterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class NuclearResearchCenterConfig : IBuildingConfig
{
  public const string ID = "NuclearResearchCenter";
  public const string PORT_ID = "HEP_STORAGE";
  public const float BASE_TIME_PER_POINT = 100f;
  public const float PARTICLES_PER_POINT = 10f;
  public const float CAPACITY = 100f;
  public static readonly Tag INPUT_MATERIAL = GameTags.HighEnergyParticle;

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR4 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
    string[] refinedMetals = TUNING.MATERIALS.REFINED_METALS;
    EffectorValues tieR1 = NOISE_POLLUTION.NOISY.TIER1;
    EffectorValues none = TUNING.BUILDINGS.DECOR.NONE;
    EffectorValues noise = tieR1;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("NuclearResearchCenter", 5, 3, "material_research_centre_kanim", 30, 30f, tieR4, refinedMetals, 1600f, BuildLocationRule.OnFloor, none, noise);
    buildingDef.RequiresPowerInput = true;
    buildingDef.EnergyConsumptionWhenActive = 120f;
    buildingDef.ExhaustKilowattsWhenActive = 0.5f;
    buildingDef.SelfHeatKilowattsWhenActive = 4f;
    buildingDef.UseHighEnergyParticleInputPort = true;
    buildingDef.HighEnergyParticleInputOffset = new CellOffset(-2, 1);
    buildingDef.ViewMode = OverlayModes.Radiation.ID;
    buildingDef.AudioCategory = "Metal";
    buildingDef.AudioSize = "large";
    buildingDef.Deprecated = !Sim.IsRadiationEnabled();
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.RadiationIDs, "NuclearResearchCenter");
    buildingDef.LogicOutputPorts = new List<LogicPorts.Port>()
    {
      LogicPorts.Port.OutputPort((HashedString) "HEP_STORAGE", new CellOffset(2, 2), (string) STRINGS.BUILDINGS.PREFABS.HEPENGINE.LOGIC_PORT_STORAGE, (string) STRINGS.BUILDINGS.PREFABS.HEPENGINE.LOGIC_PORT_STORAGE_ACTIVE, (string) STRINGS.BUILDINGS.PREFABS.HEPENGINE.LOGIC_PORT_STORAGE_INACTIVE)
    };
    buildingDef.RequiredSkillPerkID = Db.Get().SkillPerks.AllowNuclearResearch.Id;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.RESEARCH);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.ScienceBuilding);
    go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
    Prioritizable.AddRef(go);
    HighEnergyParticleStorage energyParticleStorage = go.AddOrGet<HighEnergyParticleStorage>();
    energyParticleStorage.autoStore = true;
    energyParticleStorage.capacity = 100f;
    energyParticleStorage.PORT_ID = "HEP_STORAGE";
    energyParticleStorage.showCapacityStatusItem = true;
    NuclearResearchCenterWorkable researchCenterWorkable = go.AddOrGet<NuclearResearchCenterWorkable>();
    researchCenterWorkable.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_material_research_centre_kanim")
    };
    researchCenterWorkable.requiredSkillPerk = Db.Get().SkillPerks.AllowNuclearResearch.Id;
    NuclearResearchCenter nuclearResearchCenter = go.AddOrGet<NuclearResearchCenter>();
    nuclearResearchCenter.researchTypeID = "nuclear";
    nuclearResearchCenter.materialPerPoint = 10f;
    nuclearResearchCenter.timePerPoint = 100f;
    nuclearResearchCenter.inputMaterial = NuclearResearchCenterConfig.INPUT_MATERIAL;
    go.AddOrGetDef<PoweredController.Def>();
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
  }
}
