﻿// Decompiled with JetBrains decompiler
// Type: WireRefinedBridgeConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class WireRefinedBridgeConfig : WireBridgeConfig
{
  public new const string ID = "WireRefinedBridge";

  protected override string GetID() => "WireRefinedBridge";

  public override BuildingDef CreateBuildingDef()
  {
    BuildingDef buildingDef = base.CreateBuildingDef();
    buildingDef.AnimFiles = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "utilityelectricbridgeconductive_kanim")
    };
    buildingDef.Mass = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER0;
    buildingDef.MaterialCategory = TUNING.MATERIALS.REFINED_METALS;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.POWER);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.WIRE);
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, "WireRefinedBridge");
    return buildingDef;
  }

  protected override WireUtilityNetworkLink AddNetworkLink(GameObject go)
  {
    WireUtilityNetworkLink utilityNetworkLink = base.AddNetworkLink(go);
    utilityNetworkLink.maxWattageRating = Wire.WattageRating.Max2000;
    return utilityNetworkLink;
  }
}
