﻿// Decompiled with JetBrains decompiler
// Type: AstronautTrainingCenterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class AstronautTrainingCenterConfig : IBuildingConfig
{
  public const string ID = "AstronautTrainingCenter";

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR4 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
    string[] allMetals = MATERIALS.ALL_METALS;
    EffectorValues tieR1 = NOISE_POLLUTION.NOISY.TIER1;
    EffectorValues none = BUILDINGS.DECOR.NONE;
    EffectorValues noise = tieR1;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("AstronautTrainingCenter", 5, 5, "centrifuge_kanim", 30, 30f, tieR4, allMetals, 1600f, BuildLocationRule.OnFloor, none, noise);
    buildingDef.RequiresPowerInput = true;
    buildingDef.EnergyConsumptionWhenActive = 480f;
    buildingDef.ExhaustKilowattsWhenActive = 0.5f;
    buildingDef.SelfHeatKilowattsWhenActive = 4f;
    buildingDef.PowerInputOffset = new CellOffset(-2, 0);
    buildingDef.ViewMode = OverlayModes.Power.ID;
    buildingDef.AudioCategory = "Metal";
    buildingDef.AudioSize = "large";
    buildingDef.Deprecated = true;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
    Prioritizable.AddRef(go);
    AstronautTrainingCenter astronautTrainingCenter = go.AddOrGet<AstronautTrainingCenter>();
    astronautTrainingCenter.workTime = float.PositiveInfinity;
    astronautTrainingCenter.requiredSkillPerk = Db.Get().SkillPerks.CanTrainToBeAstronaut.Id;
    astronautTrainingCenter.daysToMasterRole = 10f;
    astronautTrainingCenter.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_centrifuge_kanim")
    };
    astronautTrainingCenter.workLayer = Grid.SceneLayer.BuildingFront;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
  }
}
