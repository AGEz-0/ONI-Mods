﻿// Decompiled with JetBrains decompiler
// Type: PixelPackConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class PixelPackConfig : IBuildingConfig
{
  public static string ID = "PixelPack";

  public override BuildingDef CreateBuildingDef()
  {
    string id = PixelPackConfig.ID;
    float[] construction_mass = new float[2]
    {
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0],
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER0[0]
    };
    string[] construction_materials = new string[2]
    {
      "Glass",
      "RefinedMetal"
    };
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR3 = TUNING.BUILDINGS.DECOR.BONUS.TIER3;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, 4, 1, "pixel_pack_kanim", 30, 10f, construction_mass, construction_materials, 1600f, BuildLocationRule.NotInTiles, tieR3, noise);
    buildingDef.Overheatable = false;
    buildingDef.Floodable = false;
    buildingDef.Entombable = false;
    buildingDef.Replaceable = false;
    buildingDef.PermittedRotations = PermittedRotations.R360;
    buildingDef.RequiresPowerInput = true;
    buildingDef.PowerInputOffset = new CellOffset(1, 0);
    buildingDef.EnergyConsumptionWhenActive = 10f;
    buildingDef.SelfHeatKilowattsWhenActive = 0.0f;
    buildingDef.ExhaustKilowattsWhenActive = 0.0f;
    buildingDef.LogicInputPorts = new List<LogicPorts.Port>()
    {
      LogicPorts.Port.RibbonInputPort(PixelPack.PORT_ID, new CellOffset(0, 0), (string) STRINGS.BUILDINGS.PREFABS.PIXELPACK.LOGIC_PORT, (string) STRINGS.BUILDINGS.PREFABS.PIXELPACK.INPUT_PORT_ACTIVE, (string) STRINGS.BUILDINGS.PREFABS.PIXELPACK.INPUT_PORT_INACTIVE)
    };
    buildingDef.ViewMode = OverlayModes.Logic.ID;
    buildingDef.AudioCategory = "Metal";
    buildingDef.ObjectLayer = ObjectLayer.Backwall;
    buildingDef.SceneLayer = Grid.SceneLayer.InteriorWall;
    GeneratedBuildings.RegisterWithOverlay(OverlayModes.Logic.HighlightItemIDs, PixelPackConfig.ID);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<AnimTileable>().objectLayer = ObjectLayer.Backwall;
    BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof (RequiresFoundation), prefab_tag);
    go.AddComponent<ZoneTile>();
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.GetComponent<KPrefabID>().AddTag(GameTags.Backwall);
    go.AddOrGet<PixelPack>();
    go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayBehindConduits);
  }
}
