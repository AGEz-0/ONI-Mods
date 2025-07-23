﻿// Decompiled with JetBrains decompiler
// Type: GravitasPedestalConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class GravitasPedestalConfig : IBuildingConfig
{
  public const string ID = "GravitasPedestal";

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR2 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER2;
    string[] rawMinerals = MATERIALS.RAW_MINERALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR0 = BUILDINGS.DECOR.BONUS.TIER0;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("GravitasPedestal", 1, 2, "gravitas_pedestal_nice_kanim", 10, 30f, tieR2, rawMinerals, 800f, BuildLocationRule.OnFloor, tieR0, noise);
    buildingDef.DefaultAnimState = "pedestal_nice";
    buildingDef.Floodable = false;
    buildingDef.Overheatable = false;
    buildingDef.ViewMode = OverlayModes.Decor.ID;
    buildingDef.AudioCategory = "Glass";
    buildingDef.AudioSize = "small";
    buildingDef.ShowInBuildMenu = false;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<Storage>().SetDefaultStoredItemModifiers(new List<Storage.StoredItemModifier>((IEnumerable<Storage.StoredItemModifier>) new Storage.StoredItemModifier[2]
    {
      Storage.StoredItemModifier.Seal,
      Storage.StoredItemModifier.Preserve
    }));
    Prioritizable.AddRef(go);
    SingleEntityReceptacle entityReceptacle = go.AddOrGet<SingleEntityReceptacle>();
    entityReceptacle.AddDepositTag(GameTags.PedestalDisplayable);
    entityReceptacle.occupyingObjectRelativePosition = new Vector3(0.0f, 1.2f, -1f);
    go.AddOrGet<DecorProvider>();
    go.AddOrGet<ItemPedestal>();
    go.AddOrGet<PedestalArtifactSpawner>();
    go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
  }
}
