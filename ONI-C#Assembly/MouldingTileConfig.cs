﻿// Decompiled with JetBrains decompiler
// Type: MouldingTileConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class MouldingTileConfig : IBuildingConfig
{
  public const string ID = "MouldingTile";
  public static readonly int BlockTileConnectorID = Hash.SDBMLower("tiles_bunker_tops");

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR3 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
    string[] rawMinerals = MATERIALS.RAW_MINERALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues decor = new EffectorValues()
    {
      amount = 10,
      radius = 1
    };
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("MouldingTile", 1, 1, "floor_moulding_kanim", 100, 30f, tieR3, rawMinerals, 1600f, BuildLocationRule.Tile, decor, noise);
    buildingDef.Floodable = false;
    buildingDef.Overheatable = false;
    buildingDef.Entombable = false;
    buildingDef.UseStructureTemperature = false;
    buildingDef.IsFoundation = true;
    buildingDef.TileLayer = ObjectLayer.FoundationTile;
    buildingDef.ReplacementLayer = ObjectLayer.ReplacementTile;
    buildingDef.AudioCategory = "Metal";
    buildingDef.AudioSize = "small";
    buildingDef.BaseTimeUntilRepair = -1f;
    buildingDef.SceneLayer = Grid.SceneLayer.TileMain;
    buildingDef.ConstructionOffsetFilter = BuildingDef.ConstructionOffsetFilter_OneDown;
    buildingDef.isKAnimTile = true;
    buildingDef.BlockTileAtlas = Assets.GetTextureAtlas("tiles_moulding");
    buildingDef.BlockTilePlaceAtlas = Assets.GetTextureAtlas("tiles_moulding_place");
    buildingDef.BlockTileMaterial = Assets.GetMaterial("tiles_solid");
    buildingDef.DecorBlockTileInfo = Assets.GetBlockTileDecorInfo("tiles_bunker_tops_decor_info");
    buildingDef.DecorPlaceBlockTileInfo = Assets.GetBlockTileDecorInfo("tiles_bunker_tops_decor_place_info");
    buildingDef.Deprecated = true;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    GeneratedBuildings.MakeBuildingAlwaysOperational(go);
    BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof (RequiresFoundation), prefab_tag);
    go.AddOrGet<SimCellOccupier>().doReplaceElement = true;
    go.AddOrGet<TileTemperature>();
    go.AddOrGet<KAnimGridTileVisualizer>().blockTileConnectorID = MouldingTileConfig.BlockTileConnectorID;
    go.AddOrGet<BuildingHP>().destroyOnDamaged = true;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    GeneratedBuildings.RemoveLoopingSounds(go);
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
    base.DoPostConfigureUnderConstruction(go);
    go.AddOrGet<KAnimGridTileVisualizer>();
  }
}
