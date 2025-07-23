﻿// Decompiled with JetBrains decompiler
// Type: CreatureDeliveryPointConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using TUNING;
using UnityEngine;

#nullable disable
public class CreatureDeliveryPointConfig : IBuildingConfig
{
  public const string ID = "CreatureDeliveryPoint";

  public override BuildingDef CreateBuildingDef()
  {
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("CreatureDeliveryPoint", 1, 3, "relocator_dropoff_kanim", 10, 10f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER1, MATERIALS.RAW_METALS, 1600f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER2, NOISE_POLLUTION.NOISY.TIER0);
    buildingDef.AudioCategory = "Metal";
    buildingDef.ViewMode = OverlayModes.Rooms.ID;
    buildingDef.Deprecated = true;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.GetComponent<KPrefabID>().AddTag(GameTags.CodexCategories.CreatureRelocator);
    Storage storage = go.AddOrGet<Storage>();
    storage.allowItemRemoval = false;
    storage.showDescriptor = true;
    storage.storageFilters = STORAGEFILTERS.BAGABLE_CREATURES;
    storage.workAnims = new HashedString[2]
    {
      (HashedString) "place",
      (HashedString) "release"
    };
    storage.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_restrain_creature_kanim")
    };
    storage.workAnimPlayMode = KAnim.PlayMode.Once;
    storage.synchronizeAnims = false;
    storage.useGunForDelivery = false;
    storage.allowSettingOnlyFetchMarkedItems = false;
    go.AddOrGet<CreatureDeliveryPoint>();
    go.AddOrGet<BaggableCritterCapacityTracker>().maximumCreatures = 20;
    go.AddOrGet<FixedCapturePoint.AutoWrangleCapture>();
    go.AddOrGet<TreeFilterable>();
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGetDef<FixedCapturePoint.Def>().isAmountStoredOverCapacity = (Func<FixedCapturePoint.Instance, FixedCapturableMonitor.Instance, bool>) ((smi, capturable) =>
    {
      TreeFilterable component1 = smi.GetComponent<TreeFilterable>();
      IUserControlledCapacity component2 = smi.GetComponent<IUserControlledCapacity>();
      float amountStored = component2.AmountStored;
      float userMaxCapacity = component2.UserMaxCapacity;
      Tag prefabTag = capturable.PrefabTag;
      return !component1.ContainsTag(prefabTag) || (double) amountStored > (double) userMaxCapacity;
    });
  }
}
