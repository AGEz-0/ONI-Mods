﻿// Decompiled with JetBrains decompiler
// Type: UraniumCentrifugeConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class UraniumCentrifugeConfig : IBuildingConfig
{
  public const string ID = "UraniumCentrifuge";
  public const float OUTPUT_TEMP = 1173.15f;
  public const float REFILL_RATE = 2400f;
  public static readonly CellOffset outPipeOffset = new CellOffset(1, 3);
  private static readonly List<Storage.StoredItemModifier> storedItemModifiers = new List<Storage.StoredItemModifier>()
  {
    Storage.StoredItemModifier.Hide,
    Storage.StoredItemModifier.Preserve,
    Storage.StoredItemModifier.Insulate
  };

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    string[] strArray = new string[2]
    {
      "RefinedMetal",
      "Plastic"
    };
    float[] construction_mass = new float[2]
    {
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER5[0],
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0]
    };
    string[] construction_materials = strArray;
    EffectorValues tieR5 = NOISE_POLLUTION.NOISY.TIER5;
    EffectorValues tieR1 = TUNING.BUILDINGS.DECOR.PENALTY.TIER1;
    EffectorValues noise = tieR5;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("UraniumCentrifuge", 3, 4, "enrichmentCentrifuge_kanim", 100, 480f, construction_mass, construction_materials, 2400f, BuildLocationRule.OnFloor, tieR1, noise);
    buildingDef.Overheatable = false;
    buildingDef.RequiresPowerInput = true;
    buildingDef.PowerInputOffset = new CellOffset(0, 0);
    buildingDef.EnergyConsumptionWhenActive = 480f;
    buildingDef.ExhaustKilowattsWhenActive = 0.125f;
    buildingDef.SelfHeatKilowattsWhenActive = 0.5f;
    buildingDef.AudioCategory = "HollowMetal";
    buildingDef.OutputConduitType = ConduitType.Liquid;
    buildingDef.UtilityOutputOffset = UraniumCentrifugeConfig.outPipeOffset;
    buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
    buildingDef.Deprecated = !Sim.IsRadiationEnabled();
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
    UraniumCentrifuge fabricator = go.AddOrGet<UraniumCentrifuge>();
    BuildingTemplates.CreateComplexFabricatorStorage(go, (ComplexFabricator) fabricator);
    fabricator.outStorage.capacityKg = 2000f;
    fabricator.storeProduced = true;
    fabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
    go.AddOrGet<FabricatorIngredientStatusManager>();
    fabricator.duplicantOperated = false;
    fabricator.inStorage.SetDefaultStoredItemModifiers(UraniumCentrifugeConfig.storedItemModifiers);
    fabricator.buildStorage.SetDefaultStoredItemModifiers(UraniumCentrifugeConfig.storedItemModifiers);
    fabricator.outStorage.SetDefaultStoredItemModifiers(UraniumCentrifugeConfig.storedItemModifiers);
    ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
    conduitDispenser.alwaysDispense = true;
    conduitDispenser.conduitType = ConduitType.Liquid;
    conduitDispenser.storage = fabricator.outStorage;
    ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
    {
      new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.UraniumOre).tag, 10f)
    };
    ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[2]
    {
      new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.EnrichedUranium).tag, 2f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature),
      new ComplexRecipe.RecipeElement(ElementLoader.FindElementByHash(SimHashes.MoltenUranium).tag, 8f, ComplexRecipe.RecipeElement.TemperatureOperation.Melted)
    };
    ComplexRecipe complexRecipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID("UraniumCentrifuge", (IList<ComplexRecipe.RecipeElement>) recipeElementArray1, (IList<ComplexRecipe.RecipeElement>) recipeElementArray2), recipeElementArray1, recipeElementArray2)
    {
      time = 40f,
      nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
      description = (string) STRINGS.BUILDINGS.PREFABS.URANIUMCENTRIFUGE.RECIPE_DESCRIPTION,
      fabricators = new List<Tag>()
      {
        TagManager.Create("UraniumCentrifuge")
      }
    };
    Prioritizable.AddRef(go);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGet<LogicOperationalController>();
    go.AddOrGetDef<PoweredActiveController.Def>();
  }
}
