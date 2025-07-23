﻿// Decompiled with JetBrains decompiler
// Type: LiquidConduitDiseaseSensorConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LiquidConduitDiseaseSensorConfig : ConduitSensorConfig
{
  public static string ID = "LiquidConduitDiseaseSensor";

  protected override ConduitType ConduitType => ConduitType.Liquid;

  public override BuildingDef CreateBuildingDef()
  {
    BuildingDef buildingDef = this.CreateBuildingDef(LiquidConduitDiseaseSensorConfig.ID, "liquid_germs_sensor_kanim", new float[2]
    {
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER0[0],
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER1[0]
    }, new string[2]{ "RefinedMetal", "Plastic" }, new List<LogicPorts.Port>()
    {
      LogicPorts.Port.OutputPort(LogicSwitch.PORT_ID, new CellOffset(0, 0), (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITDISEASESENSOR.LOGIC_PORT, (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITDISEASESENSOR.LOGIC_PORT_ACTIVE, (string) STRINGS.BUILDINGS.PREFABS.LIQUIDCONDUITDISEASESENSOR.LOGIC_PORT_INACTIVE, true)
    });
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, LiquidConduitDiseaseSensorConfig.ID);
    return buildingDef;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    base.DoPostConfigureComplete(go);
    ConduitDiseaseSensor conduitDiseaseSensor = go.AddComponent<ConduitDiseaseSensor>();
    conduitDiseaseSensor.conduitType = this.ConduitType;
    conduitDiseaseSensor.Threshold = 0.0f;
    conduitDiseaseSensor.ActivateAboveThreshold = true;
    conduitDiseaseSensor.manuallyControlled = false;
    conduitDiseaseSensor.defaultState = false;
    go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayInFrontOfConduits);
  }
}
