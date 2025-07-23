﻿// Decompiled with JetBrains decompiler
// Type: GasFilterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class GasFilterConfig : IBuildingConfig
{
  public const string ID = "GasFilter";
  private const ConduitType CONDUIT_TYPE = ConduitType.Gas;
  private ConduitPortInfo secondaryPort = new ConduitPortInfo(ConduitType.Gas, new CellOffset(0, 0));

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR1_1 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
    string[] rawMetals = TUNING.MATERIALS.RAW_METALS;
    EffectorValues tieR1_2 = NOISE_POLLUTION.NOISY.TIER1;
    EffectorValues tieR0 = TUNING.BUILDINGS.DECOR.PENALTY.TIER0;
    EffectorValues noise = tieR1_2;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("GasFilter", 3, 1, "filter_gas_kanim", 30, 10f, tieR1_1, rawMetals, 1600f, BuildLocationRule.Anywhere, tieR0, noise);
    buildingDef.RequiresPowerInput = true;
    buildingDef.EnergyConsumptionWhenActive = 120f;
    buildingDef.SelfHeatKilowattsWhenActive = 0.0f;
    buildingDef.ExhaustKilowattsWhenActive = 0.0f;
    buildingDef.InputConduitType = ConduitType.Gas;
    buildingDef.OutputConduitType = ConduitType.Gas;
    buildingDef.Floodable = false;
    buildingDef.ViewMode = OverlayModes.GasConduits.ID;
    buildingDef.AudioCategory = "Metal";
    buildingDef.UtilityInputOffset = new CellOffset(-1, 0);
    buildingDef.UtilityOutputOffset = new CellOffset(1, 0);
    buildingDef.PermittedRotations = PermittedRotations.R360;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.FILTER);
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.GasVentIDs, "GasFilter");
    return buildingDef;
  }

  private void AttachPort(GameObject go)
  {
    go.AddComponent<ConduitSecondaryOutput>().portInfo = this.secondaryPort;
  }

  public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
  {
    base.DoPostConfigurePreview(def, go);
    this.AttachPort(go);
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
    base.DoPostConfigureUnderConstruction(go);
    this.AttachPort(go);
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
    go.AddOrGet<ElementFilter>().portInfo = this.secondaryPort;
    go.AddOrGet<Filterable>().filterElementState = Filterable.ElementState.Gas;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGetDef<PoweredActiveController.Def>().showWorkingStatus = true;
    go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayInFrontOfConduits);
  }
}
