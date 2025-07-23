﻿// Decompiled with JetBrains decompiler
// Type: MonumentTopConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class MonumentTopConfig : IBuildingConfig
{
  public const string ID = "MonumentTop";

  public override BuildingDef CreateBuildingDef()
  {
    float[] construction_mass = new float[3]
    {
      2500f,
      2500f,
      5000f
    };
    string[] construction_materials = new string[3]
    {
      SimHashes.Glass.ToString(),
      SimHashes.Diamond.ToString(),
      SimHashes.Steel.ToString()
    };
    EffectorValues tieR2 = NOISE_POLLUTION.NOISY.TIER2;
    EffectorValues incomplete = TUNING.BUILDINGS.DECOR.BONUS.MONUMENT.INCOMPLETE;
    EffectorValues noise = tieR2;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("MonumentTop", 5, 5, "monument_upper_a_kanim", 1000, 60f, construction_mass, construction_materials, 9999f, BuildLocationRule.BuildingAttachPoint, incomplete, noise);
    BuildingTemplates.CreateMonumentBuildingDef(buildingDef);
    buildingDef.SceneLayer = Grid.SceneLayer.BuildingFront;
    buildingDef.OverheatTemperature = 2273.15f;
    buildingDef.Floodable = false;
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    buildingDef.AttachmentSlotTag = (Tag) "MonumentTop";
    buildingDef.ObjectLayer = ObjectLayer.Building;
    buildingDef.attachablePosition = new CellOffset(0, 0);
    buildingDef.RequiresPowerInput = false;
    buildingDef.CanMove = false;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.STATUE);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.MORALE);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof (RequiresFoundation), prefab_tag);
    go.AddOrGet<LoopingSounds>();
    go.AddOrGet<MonumentPart>().part = MonumentPartResource.Part.Top;
  }

  public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
  {
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGet<KBatchedAnimController>().initialAnim = "option_a";
    go.GetComponent<KPrefabID>().prefabSpawnFn += (KPrefabID.PrefabFn) (game_object =>
    {
      MonumentPart monumentPart = game_object.AddOrGet<MonumentPart>();
      monumentPart.part = MonumentPartResource.Part.Top;
      monumentPart.stateUISymbol = "upper";
    });
  }
}
