// Decompiled with JetBrains decompiler
// Type: MilkFatSeparatorConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class MilkFatSeparatorConfig : IBuildingConfig
{
  public const string ID = "MilkFatSeparator";
  public const float INPUT_RATE = 1f;
  public const float MILK_STORED_CAPACITY = 4f;
  public const float MILK_FAT_CAPACITY = 15f;
  public const float EFFICIENCY = 0.9f;
  public const float MILKFAT_PERCENT = 0.1f;
  private const float MILK_TO_FAT_OUTPUT_RATE = 0.0899999961f;
  private const float MILK_TO_BRINE_WATER_OUTPUT_RATE = 0.809999943f;
  private const float MILK_TO_CO2_RATE = 0.100000024f;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR5 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER5;
    string[] refinedMetals = MATERIALS.REFINED_METALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR2 = BUILDINGS.DECOR.PENALTY.TIER2;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("MilkFatSeparator", 4, 4, "milk_separator_kanim", 100, 120f, tieR5, refinedMetals, 1600f, BuildLocationRule.OnFloor, tieR2, noise);
    buildingDef.RequiresPowerInput = true;
    buildingDef.EnergyConsumptionWhenActive = 480f;
    buildingDef.SelfHeatKilowattsWhenActive = 8f;
    buildingDef.ExhaustKilowattsWhenActive = 0.0f;
    buildingDef.InputConduitType = ConduitType.Liquid;
    buildingDef.OutputConduitType = ConduitType.Liquid;
    buildingDef.UtilityInputOffset = new CellOffset(0, 0);
    buildingDef.UtilityOutputOffset = new CellOffset(2, 2);
    buildingDef.AudioCategory = "HollowMetal";
    buildingDef.AudioSize = "large";
    buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    return buildingDef;
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    Storage storage = go.AddOrGet<Storage>();
    storage.allowItemRemoval = false;
    storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
    storage.showInUI = true;
    go.AddOrGet<Operational>();
    go.AddOrGet<EmptyMilkSeparatorWorkable>();
    go.AddOrGetDef<MilkSeparator.Def>().MILK_FAT_CAPACITY = 15f;
    ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
    elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
    {
      new ElementConverter.ConsumedElement(new Tag("Milk"), 1f)
    };
    elementConverter.outputElements = new ElementConverter.OutputElement[3]
    {
      new ElementConverter.OutputElement(0.0899999961f, SimHashes.MilkFat, 0.0f, storeOutput: true),
      new ElementConverter.OutputElement(0.809999943f, SimHashes.Brine, 0.0f, storeOutput: true, diseaseWeight: 0.0f),
      new ElementConverter.OutputElement(0.100000024f, SimHashes.CarbonDioxide, 348.15f, outputElementOffsetx: 1f, outputElementOffsety: 3f, diseaseWeight: 0.0f)
    };
    ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
    conduitConsumer.conduitType = ConduitType.Liquid;
    conduitConsumer.consumptionRate = 10f;
    conduitConsumer.capacityKG = 4f;
    conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Milk).tag;
    conduitConsumer.forceAlwaysSatisfied = true;
    conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Store;
    ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
    conduitDispenser.conduitType = ConduitType.Liquid;
    conduitDispenser.invertElementFilter = true;
    conduitDispenser.elementFilter = new SimHashes[1]
    {
      SimHashes.Milk
    };
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
    Prioritizable.AddRef(go);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
  }

  public override void ConfigurePost(BuildingDef def)
  {
  }
}
