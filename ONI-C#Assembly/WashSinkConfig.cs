﻿// Decompiled with JetBrains decompiler
// Type: WashSinkConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class WashSinkConfig : IBuildingConfig
{
  public const string ID = "WashSink";
  public static readonly int DISEASE_REMOVAL_COUNT = DUPLICANTSTATS.STANDARD.Secretions.DISEASE_PER_PEE + 20000;
  public const float WATER_PER_USE = 5f;
  public const int USES_PER_FLUSH = 2;
  public const float WORK_TIME = 5f;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR4 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
    string[] rawMetals = MATERIALS.RAW_METALS;
    EffectorValues tieR0 = NOISE_POLLUTION.NOISY.TIER0;
    EffectorValues tieR1 = BUILDINGS.DECOR.BONUS.TIER1;
    EffectorValues noise = tieR0;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("WashSink", 2, 3, "wash_sink_kanim", 30, 30f, tieR4, rawMetals, 1600f, BuildLocationRule.OnFloor, tieR1, noise);
    buildingDef.InputConduitType = ConduitType.Liquid;
    buildingDef.OutputConduitType = ConduitType.Liquid;
    buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
    buildingDef.AudioCategory = "Metal";
    buildingDef.UtilityInputOffset = new CellOffset(0, 0);
    buildingDef.UtilityOutputOffset = new CellOffset(1, 1);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.WashStation);
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.AdvancedWashStation);
    HandSanitizer handSanitizer = go.AddOrGet<HandSanitizer>();
    handSanitizer.massConsumedPerUse = 5f;
    handSanitizer.consumedElement = SimHashes.Water;
    handSanitizer.outputElement = SimHashes.DirtyWater;
    handSanitizer.diseaseRemovalCount = WashSinkConfig.DISEASE_REMOVAL_COUNT;
    handSanitizer.maxUses = 2;
    handSanitizer.dirtyMeterOffset = Meter.Offset.Behind;
    go.AddOrGet<DirectionControl>();
    HandSanitizer.Work work = go.AddOrGet<HandSanitizer.Work>();
    KAnimFile[] kanimFileArray = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_washbasin_kanim")
    };
    work.overrideAnims = kanimFileArray;
    work.workTime = 5f;
    work.trackUses = true;
    ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
    conduitConsumer.conduitType = ConduitType.Liquid;
    conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.Water).tag;
    conduitConsumer.capacityKG = 10f;
    conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Store;
    ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
    conduitDispenser.conduitType = ConduitType.Liquid;
    conduitDispenser.invertElementFilter = true;
    conduitDispenser.elementFilter = new SimHashes[1]
    {
      SimHashes.Water
    };
    Storage storage = go.AddOrGet<Storage>();
    storage.doDiseaseTransfer = false;
    storage.SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
    go.AddOrGet<LoopingSounds>();
    go.AddOrGet<RequireOutputs>().ignoreFullPipe = true;
    go.AddOrGetDef<RocketUsageRestriction.Def>();
    go.GetComponent<KPrefabID>().prefabInitFn += new KPrefabID.PrefabFn(this.OnInit);
  }

  private void OnInit(GameObject go)
  {
    HandSanitizer.Work component = go.GetComponent<HandSanitizer.Work>();
    KAnimFile[] kanimFileArray = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_washbasin_kanim")
    };
    component.workerTypeOverrideAnims.Add((Tag) MinionConfig.ID, kanimFileArray);
    component.workerTypeOverrideAnims.Add((Tag) BionicMinionConfig.ID, new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_bionic_interacts_wash_sink_kanim")
    });
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
  }
}
