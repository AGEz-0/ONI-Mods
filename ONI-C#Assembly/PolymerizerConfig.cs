﻿// Decompiled with JetBrains decompiler
// Type: PolymerizerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class PolymerizerConfig : IBuildingConfig
{
  public const string ID = "Polymerizer";
  private const ConduitType INPUT_CONDUIT_TYPE = ConduitType.Liquid;
  private const ConduitType OUTPUT_CONDUIT_TYPE = ConduitType.Gas;
  private const float CONSUMED_OIL_KG_PER_DAY = 500f;
  private const float GENERATED_PLASTIC_KG_PER_DAY = 300f;
  private const float SECONDS_PER_PLASTIC_BLOCK = 60f;
  private const float GENERATED_EXHAUST_STEAM_KG_PER_DAY = 5f;
  private const float GENERATED_EXHAUST_CO2_KG_PER_DAY = 5f;
  public static Tag INPUT_ELEMENT_TAG = GameTags.PlastifiableLiquid;
  private const SimHashes PRODUCED_ELEMENT = SimHashes.Polypropylene;
  private const SimHashes EXHAUST_ENVIRONMENT_ELEMENT = SimHashes.Steam;
  private const SimHashes EXHAUST_CONDUIT_ELEMENT = SimHashes.CarbonDioxide;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR4 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
    string[] allMetals = TUNING.MATERIALS.ALL_METALS;
    EffectorValues tieR3 = NOISE_POLLUTION.NOISY.TIER3;
    EffectorValues none = TUNING.BUILDINGS.DECOR.NONE;
    EffectorValues noise = tieR3;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("Polymerizer", 3, 3, "plasticrefinery_kanim", 30, 30f, tieR4, allMetals, 1600f, BuildLocationRule.OnFloor, none, noise);
    BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
    buildingDef.AudioCategory = "Metal";
    buildingDef.AudioSize = "large";
    buildingDef.EnergyConsumptionWhenActive = 240f;
    buildingDef.ExhaustKilowattsWhenActive = 0.5f;
    buildingDef.SelfHeatKilowattsWhenActive = 32f;
    buildingDef.PowerInputOffset = new CellOffset(0, 0);
    buildingDef.InputConduitType = ConduitType.Liquid;
    buildingDef.UtilityInputOffset = new CellOffset(0, 0);
    buildingDef.OutputConduitType = ConduitType.Gas;
    buildingDef.UtilityOutputOffset = new CellOffset(0, 1);
    buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 1));
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.STEAM);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
    Polymerizer polymerizer = go.AddOrGet<Polymerizer>();
    polymerizer.emitMass = 30f;
    polymerizer.emitTag = GameTagExtensions.Create(SimHashes.Polypropylene);
    polymerizer.emitOffset = new Vector3(-1.45f, 1f, 0.0f);
    polymerizer.exhaustElement = SimHashes.Steam;
    ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
    conduitConsumer.conduitType = ConduitType.Liquid;
    conduitConsumer.consumptionRate = 1.66666663f;
    conduitConsumer.capacityTag = PolymerizerConfig.INPUT_ELEMENT_TAG;
    conduitConsumer.capacityKG = 1.66666663f;
    conduitConsumer.forceAlwaysSatisfied = true;
    conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
    ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
    conduitDispenser.conduitType = ConduitType.Gas;
    conduitDispenser.invertElementFilter = false;
    conduitDispenser.elementFilter = new SimHashes[1]
    {
      SimHashes.CarbonDioxide
    };
    ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
    elementConverter.inputIsCategory = true;
    elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
    {
      new ElementConverter.ConsumedElement(PolymerizerConfig.INPUT_ELEMENT_TAG, 0.8333333f)
    };
    elementConverter.outputElements = new ElementConverter.OutputElement[3]
    {
      new ElementConverter.OutputElement(0.5f, SimHashes.Polypropylene, 348.15f, storeOutput: true),
      new ElementConverter.OutputElement(0.008333334f, SimHashes.Steam, 473.15f, storeOutput: true),
      new ElementConverter.OutputElement(0.008333334f, SimHashes.CarbonDioxide, 423.15f, storeOutput: true)
    };
    go.AddOrGet<DropAllWorkable>();
    Prioritizable.AddRef(go);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGet<LogicOperationalController>();
    go.AddOrGetDef<PoweredActiveController.Def>();
  }
}
