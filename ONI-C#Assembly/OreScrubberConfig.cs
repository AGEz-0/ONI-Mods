﻿// Decompiled with JetBrains decompiler
// Type: OreScrubberConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class OreScrubberConfig : IBuildingConfig
{
  public const string ID = "OreScrubber";
  private const float MASS_PER_USE = 0.07f;
  private static readonly int DISEASE_REMOVAL_COUNT = WashBasinConfig.DISEASE_REMOVAL_COUNT * 4;
  private const SimHashes CONSUMED_ELEMENT = SimHashes.ChlorineGas;

  public override BuildingDef CreateBuildingDef()
  {
    string[] strArray = new string[1]{ "Metal" };
    float[] construction_mass = new float[1]
    {
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER3[0]
    };
    string[] construction_materials = strArray;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR1 = TUNING.BUILDINGS.DECOR.BONUS.TIER1;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("OreScrubber", 3, 3, "orescrubber_kanim", 30, 30f, construction_mass, construction_materials, 1600f, BuildLocationRule.OnFloor, tieR1, noise);
    buildingDef.UtilityInputOffset = new CellOffset(1, 1);
    buildingDef.ForegroundLayer = Grid.SceneLayer.BuildingFront;
    buildingDef.InputConduitType = ConduitType.Gas;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.FILTER);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
    OreScrubber oreScrubber = go.AddOrGet<OreScrubber>();
    oreScrubber.massConsumedPerUse = 0.07f;
    oreScrubber.consumedElement = SimHashes.ChlorineGas;
    oreScrubber.diseaseRemovalCount = OreScrubberConfig.DISEASE_REMOVAL_COUNT;
    ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
    conduitConsumer.conduitType = ConduitType.Liquid;
    conduitConsumer.consumptionRate = 1f;
    conduitConsumer.capacityKG = 10f;
    conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
    conduitConsumer.capacityTag = ElementLoader.FindElementByHash(SimHashes.ChlorineGas).tag;
    go.AddOrGet<DirectionControl>();
    OreScrubber.Work work = go.AddOrGet<OreScrubber.Work>();
    work.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_ore_scrubber_kanim")
    };
    work.workTime = 10.2000008f;
    work.trackUses = true;
    work.workLayer = Grid.SceneLayer.BuildingUse;
    go.AddOrGet<Storage>().SetDefaultStoredItemModifiers(Storage.StandardSealedStorage);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.GetComponent<RequireInputs>().requireConduitHasMass = false;
  }
}
