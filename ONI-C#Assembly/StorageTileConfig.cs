﻿// Decompiled with JetBrains decompiler
// Type: StorageTileConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class StorageTileConfig : IBuildingConfig
{
  public const string ANIM_NAME = "storagetile_kanim";
  public const string ID = "StorageTile";
  public static float CAPACITY = 1000f;
  private static readonly List<Storage.StoredItemModifier> StoredItemModifiers = new List<Storage.StoredItemModifier>()
  {
    Storage.StoredItemModifier.Insulate,
    Storage.StoredItemModifier.Seal,
    Storage.StoredItemModifier.Hide
  };

  public override BuildingDef CreateBuildingDef()
  {
    float[] construction_mass = new float[2]{ 100f, 100f };
    string[] construction_materials = new string[2]
    {
      "RefinedMetal",
      "Glass"
    };
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR1 = TUNING.BUILDINGS.DECOR.PENALTY.TIER1;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("StorageTile", 1, 1, "storagetile_kanim", 30, 30f, construction_mass, construction_materials, 800f, BuildLocationRule.Tile, tieR1, noise);
    BuildingTemplates.CreateFoundationTileDef(buildingDef);
    buildingDef.Floodable = false;
    buildingDef.Entombable = false;
    buildingDef.Overheatable = false;
    buildingDef.UseStructureTemperature = false;
    buildingDef.AudioCategory = "Glass";
    buildingDef.AudioSize = "small";
    buildingDef.BaseTimeUntilRepair = -1f;
    buildingDef.SceneLayer = Grid.SceneLayer.TileMain;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.TILE);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.STORAGE);
    buildingDef.ConstructionOffsetFilter = BuildingDef.ConstructionOffsetFilter_OneDown;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    GeneratedBuildings.MakeBuildingAlwaysOperational(go);
    BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof (RequiresFoundation), prefab_tag);
    SimCellOccupier simCellOccupier = go.AddOrGet<SimCellOccupier>();
    simCellOccupier.movementSpeedMultiplier = DUPLICANTSTATS.MOVEMENT_MODIFIERS.PENALTY_2;
    simCellOccupier.notifyOnMelt = true;
    Storage storage = go.AddOrGet<Storage>();
    storage.SetDefaultStoredItemModifiers(StorageTileConfig.StoredItemModifiers);
    storage.capacityKg = StorageTileConfig.CAPACITY;
    storage.showInUI = true;
    storage.allowItemRemoval = true;
    storage.showDescriptor = true;
    storage.storageFilters = STORAGEFILTERS.STORAGE_LOCKERS_STANDARD;
    storage.fetchCategory = Storage.FetchCategory.GeneralStorage;
    storage.showCapacityStatusItem = true;
    storage.showCapacityAsMainStatus = true;
    go.AddOrGet<StorageTileSwitchItemWorkable>();
    TreeFilterable treeFilterable = go.AddOrGet<TreeFilterable>();
    treeFilterable.copySettingsEnabled = false;
    treeFilterable.dropIncorrectOnFilterChange = false;
    treeFilterable.preventAutoAddOnDiscovery = true;
    StorageTile.Def def = go.AddOrGetDef<StorageTile.Def>();
    def.MaxCapacity = StorageTileConfig.CAPACITY;
    def.specialItemCases = new StorageTile.SpecificItemTagSizeInstruction[3]
    {
      new StorageTile.SpecificItemTagSizeInstruction(GameTags.AirtightSuit, 0.5f),
      new StorageTile.SpecificItemTagSizeInstruction(GameTags.Dehydrated, 0.6f),
      new StorageTile.SpecificItemTagSizeInstruction(GameTags.MoltShell, 0.5f)
    };
    go.AddOrGet<TileTemperature>();
    go.AddOrGet<BuildingHP>().destroyOnDamaged = true;
    Prioritizable.AddRef(go);
    go.AddOrGetDef<RocketUsageRestriction.Def>().restrictOperational = false;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    GeneratedBuildings.RemoveLoopingSounds(go);
    go.GetComponent<KPrefabID>().AddTag(GameTags.FloorTiles);
  }
}
