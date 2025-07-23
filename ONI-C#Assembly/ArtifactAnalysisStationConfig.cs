﻿// Decompiled with JetBrains decompiler
// Type: ArtifactAnalysisStationConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class ArtifactAnalysisStationConfig : IBuildingConfig
{
  public const string ID = "ArtifactAnalysisStation";
  public const float WORK_TIME = 150f;

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR5 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER5;
    string[] allMetals = MATERIALS.ALL_METALS;
    EffectorValues tieR6 = NOISE_POLLUTION.NOISY.TIER6;
    EffectorValues tieR2 = BUILDINGS.DECOR.PENALTY.TIER2;
    EffectorValues noise = tieR6;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("ArtifactAnalysisStation", 4, 4, "artifact_analysis_kanim", 30, 60f, tieR5, allMetals, 2400f, BuildLocationRule.OnFloor, tieR2, noise);
    buildingDef.RequiresPowerInput = true;
    buildingDef.EnergyConsumptionWhenActive = 480f;
    buildingDef.SelfHeatKilowattsWhenActive = 1f;
    buildingDef.ViewMode = OverlayModes.Power.ID;
    buildingDef.AudioCategory = "HollowMetal";
    buildingDef.AudioSize = "large";
    buildingDef.RequiredSkillPerkID = Db.Get().SkillPerks.CanStudyArtifact.Id;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<DropAllWorkable>();
    go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
    go.AddOrGetDef<ArtifactAnalysisStation.Def>();
    go.AddOrGet<ArtifactAnalysisStationWorkable>();
    Prioritizable.AddRef(go);
    Storage storage = go.AddOrGet<Storage>();
    ManualDeliveryKG manualDeliveryKg = go.AddOrGet<ManualDeliveryKG>();
    manualDeliveryKg.SetStorage(storage);
    manualDeliveryKg.choreTypeIDHash = Db.Get().ChoreTypes.MachineFetch.IdHash;
    manualDeliveryKg.RequestedItemTag = GameTags.CharmedArtifact;
    manualDeliveryKg.refillMass = 1f * ArtifactConfig.ARTIFACT_MASS;
    manualDeliveryKg.MinimumMass = 1f * ArtifactConfig.ARTIFACT_MASS;
    manualDeliveryKg.capacity = 1f * ArtifactConfig.ARTIFACT_MASS;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
  }
}
