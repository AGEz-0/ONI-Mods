﻿// Decompiled with JetBrains decompiler
// Type: DevPumpSolidConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class DevPumpSolidConfig : IBuildingConfig
{
  public const string ID = "DevPumpSolid";
  private const ConduitType CONDUIT_TYPE = ConduitType.Solid;
  private ConduitPortInfo primaryPort = new ConduitPortInfo(ConduitType.Solid, new CellOffset(1, 1));

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR1_1 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
    string[] allMetals = MATERIALS.ALL_METALS;
    EffectorValues tieR2 = NOISE_POLLUTION.NOISY.TIER2;
    EffectorValues tieR1_2 = BUILDINGS.DECOR.PENALTY.TIER1;
    EffectorValues noise = tieR2;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("DevPumpSolid", 2, 2, "dev_pump_solid_kanim", 100, 30f, tieR1_1, allMetals, 9999f, BuildLocationRule.Anywhere, tieR1_2, noise);
    buildingDef.RequiresPowerInput = false;
    buildingDef.OutputConduitType = ConduitType.Solid;
    buildingDef.Floodable = false;
    buildingDef.Invincible = true;
    buildingDef.Overheatable = false;
    buildingDef.Entombable = false;
    buildingDef.ViewMode = OverlayModes.SolidConveyor.ID;
    buildingDef.AudioCategory = "Metal";
    buildingDef.UtilityOutputOffset = this.primaryPort.offset;
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.SolidConveyorIDs, "DevPumpSolid");
    buildingDef.DebugOnly = true;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddTag(GameTags.DevBuilding);
    base.ConfigureBuildingTemplate(go, prefab_tag);
    GeneratedBuildings.MakeBuildingAlwaysOperational(go);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
    go.AddOrGet<LoopingSounds>();
    go.AddOrGet<DevPump>().elementState = Filterable.ElementState.Solid;
    go.AddOrGet<Storage>().capacityKg = 20f;
    go.AddTag(GameTags.CorrosionProof);
    SolidConduitDispenser conduitDispenser = go.AddOrGet<SolidConduitDispenser>();
    conduitDispenser.alwaysDispense = true;
    conduitDispenser.elementFilter = (SimHashes[]) null;
    go.AddOrGetDef<OperationalController.Def>();
    go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayBehindConduits);
  }
}
