﻿// Decompiled with JetBrains decompiler
// Type: StaterpillarGeneratorConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using TUNING;
using UnityEngine;

#nullable disable
public class StaterpillarGeneratorConfig : IBuildingConfig
{
  public static readonly string ID = "StaterpillarGenerator";
  private const int WIDTH = 1;
  private const int HEIGHT = 2;

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    string id = StaterpillarGeneratorConfig.ID;
    string[] allMetals = MATERIALS.ALL_METALS;
    float[] tieR3 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
    string[] construction_materials = allMetals;
    EffectorValues tieR0 = NOISE_POLLUTION.NOISY.TIER0;
    EffectorValues none = BUILDINGS.DECOR.NONE;
    EffectorValues noise = tieR0;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, 1, 2, "egg_caterpillar_kanim", 1000, 10f, tieR3, construction_materials, 9999f, BuildLocationRule.OnFoundationRotatable, none, noise);
    buildingDef.GeneratorWattageRating = 1600f;
    buildingDef.GeneratorBaseCapacity = buildingDef.GeneratorWattageRating;
    buildingDef.ExhaustKilowattsWhenActive = 2f;
    buildingDef.SelfHeatKilowattsWhenActive = 4f;
    buildingDef.Overheatable = false;
    buildingDef.Floodable = false;
    buildingDef.OverheatTemperature = 423.15f;
    buildingDef.PermittedRotations = PermittedRotations.FlipV;
    buildingDef.ViewMode = OverlayModes.Power.ID;
    buildingDef.AudioCategory = "Plastic";
    buildingDef.RequiresPowerOutput = true;
    buildingDef.PowerOutputOffset = new CellOffset(0, 1);
    buildingDef.PlayConstructionSounds = false;
    buildingDef.ShowInBuildMenu = false;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof (RequiresFoundation), prefab_tag);
  }

  public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
  {
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGet<StaterpillarGenerator>().powerDistributionOrder = 9;
    go.GetComponent<Deconstructable>().SetAllowDeconstruction(false);
    go.AddOrGet<Modifiers>();
    go.AddOrGet<Effects>();
    go.GetComponent<KSelectable>().IsSelectable = false;
  }
}
