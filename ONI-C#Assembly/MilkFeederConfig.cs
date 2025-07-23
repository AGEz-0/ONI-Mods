// Decompiled with JetBrains decompiler
// Type: MilkFeederConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class MilkFeederConfig : IBuildingConfig
{
  public const string ID = "MilkFeeder";
  public const string HAD_CONSUMED_MILK_RECENTLY_EFFECT_ID = "HadMilk";
  public const float EFFECT_DURATION_IN_SECONDS = 600f;
  public static readonly CellOffset DRINK_FROM_OFFSET = new CellOffset(1, 0);
  public static readonly Tag MILK_TAG = SimHashes.Milk.CreateTag();
  public const float UNITS_OF_MILK_CONSUMED_PER_FEEDING = 5f;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR4 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
    string[] refinedMetals = TUNING.MATERIALS.REFINED_METALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR2 = TUNING.BUILDINGS.DECOR.PENALTY.TIER2;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("MilkFeeder", 3, 3, "critter_milk_feeder_kanim", 100, 120f, tieR4, refinedMetals, 1600f, BuildLocationRule.OnFloor, tieR2, noise);
    buildingDef.AudioCategory = "Metal";
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    buildingDef.InputConduitType = ConduitType.Liquid;
    buildingDef.UtilityInputOffset = new CellOffset(0, 0);
    buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.RANCHING);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.CRITTER);
    return buildingDef;
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    Prioritizable.AddRef(go);
    go.AddOrGet<LogicOperationalController>();
    RoomTracker roomTracker = go.AddOrGet<RoomTracker>();
    roomTracker.requiredRoomType = Db.Get().RoomTypes.CreaturePen.Id;
    roomTracker.requirement = RoomTracker.Requirement.Required;
    Storage storage = go.AddOrGet<Storage>();
    storage.capacityKg = 80f;
    storage.showInUI = true;
    storage.showDescriptor = true;
    storage.allowItemRemoval = false;
    storage.allowSettingOnlyFetchMarkedItems = false;
    storage.showCapacityStatusItem = true;
    storage.showCapacityAsMainStatus = true;
    ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
    conduitConsumer.conduitType = ConduitType.Liquid;
    conduitConsumer.consumptionRate = 10f;
    conduitConsumer.capacityTag = GameTagExtensions.Create(SimHashes.Milk);
    conduitConsumer.forceAlwaysSatisfied = true;
    conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
    conduitConsumer.storage = storage;
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.RanchStationType);
  }

  public override void DoPostConfigureComplete(GameObject go) => go.AddOrGetDef<MilkFeeder.Def>();

  public override void ConfigurePost(BuildingDef def)
  {
  }
}
