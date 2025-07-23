﻿// Decompiled with JetBrains decompiler
// Type: GasBottlerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class GasBottlerConfig : IBuildingConfig
{
  public const string ID = "GasBottler";
  private const ConduitType CONDUIT_TYPE = ConduitType.Gas;
  private const int WIDTH = 3;
  private const int HEIGHT = 2;
  private const float DEFAULT_FILL_LEVEL = 25f;
  private const float CAPACITY = 200f;
  private static readonly List<Storage.StoredItemModifier> GasBottlerStoredItemModifiers = new List<Storage.StoredItemModifier>()
  {
    Storage.StoredItemModifier.Hide
  };

  public override BuildingDef CreateBuildingDef()
  {
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("GasBottler", 3, 2, "gas_bottler_kanim", 100, 120f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, MATERIALS.ALL_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NOISY.TIER0);
    buildingDef.InputConduitType = ConduitType.Gas;
    buildingDef.Floodable = false;
    buildingDef.ViewMode = OverlayModes.GasConduits.ID;
    buildingDef.AudioCategory = "HollowMetal";
    buildingDef.UtilityInputOffset = new CellOffset(0, 0);
    GeneratedBuildings.RegisterWithOverlay(OverlayScreen.GasVentIDs, "GasBottler");
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    Storage defaultStorage = BuildingTemplates.CreateDefaultStorage(go);
    defaultStorage.showDescriptor = true;
    defaultStorage.storageFilters = STORAGEFILTERS.GASES;
    defaultStorage.capacityKg = 200f;
    defaultStorage.SetDefaultStoredItemModifiers(GasBottlerConfig.GasBottlerStoredItemModifiers);
    defaultStorage.allowItemRemoval = false;
    go.AddTag(GameTags.GasSource);
    DropAllWorkable dropAllWorkable = go.AddOrGet<DropAllWorkable>();
    dropAllWorkable.removeTags = new List<Tag>()
    {
      GameTags.GasSource
    };
    dropAllWorkable.resetTargetWorkableOnCompleteWork = true;
    ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
    conduitConsumer.storage = defaultStorage;
    conduitConsumer.conduitType = ConduitType.Gas;
    conduitConsumer.ignoreMinMassCheck = true;
    conduitConsumer.forceAlwaysSatisfied = true;
    conduitConsumer.alwaysConsume = true;
    conduitConsumer.capacityKG = 200f;
    conduitConsumer.keepZeroMassObject = false;
    Bottler bottler = go.AddOrGet<Bottler>();
    bottler.storage = defaultStorage;
    bottler.workTime = 9f;
    bottler.userMaxCapacity = 25f;
    bottler.consumer = conduitConsumer;
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.GetComponent<KPrefabID>().AddTag(GameTags.OverlayBehindConduits);
  }
}
