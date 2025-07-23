// Decompiled with JetBrains decompiler
// Type: MilkingStationConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using TUNING;
using UnityEngine;

#nullable disable
public class MilkingStationConfig : IBuildingConfig
{
  public const string ID = "MilkingStation";

  public override BuildingDef CreateBuildingDef()
  {
    float[] construction_mass = new float[2]
    {
      BUILDINGS.CONSTRUCTION_MASS_KG.TIER4[0],
      BUILDINGS.CONSTRUCTION_MASS_KG.TIER3[0]
    };
    string[] construction_materials = new string[2]
    {
      "RefinedMetal",
      "Plastic"
    };
    EffectorValues tieR1 = NOISE_POLLUTION.NOISY.TIER1;
    EffectorValues tieR2 = BUILDINGS.DECOR.PENALTY.TIER2;
    EffectorValues noise = tieR1;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("MilkingStation", 2, 4, "milking_station_kanim", 30, 60f, construction_mass, construction_materials, 1600f, BuildLocationRule.OnFloor, tieR2, noise);
    buildingDef.ViewMode = OverlayModes.Rooms.ID;
    buildingDef.OutputConduitType = ConduitType.Liquid;
    buildingDef.UtilityOutputOffset = new CellOffset(1, 0);
    buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
    buildingDef.Overheatable = false;
    buildingDef.AudioCategory = "Metal";
    buildingDef.AudioSize = "large";
    buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
    buildingDef.OutputConduitType = ConduitType.Liquid;
    buildingDef.UtilityOutputOffset = new CellOffset(1, 1);
    buildingDef.RequiredSkillPerkID = Db.Get().SkillPerks.CanUseMilkingStation.Id;
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<LoopingSounds>();
    go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.RanchStationType);
    Storage storage = go.AddOrGet<Storage>();
    storage.capacityKg = MooTuning.MILK_AMOUNT_AT_MILKING * 2f;
    storage.showInUI = true;
    go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
    Prioritizable.AddRef(go);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    RoomTracker roomTracker = go.AddOrGet<RoomTracker>();
    roomTracker.requiredRoomType = Db.Get().RoomTypes.CreaturePen.Id;
    roomTracker.requirement = RoomTracker.Requirement.Required;
    go.AddOrGet<SkillPerkMissingComplainer>().requiredSkillPerk = Db.Get().SkillPerks.CanUseMilkingStation.Id;
    RanchStation.Def ranch_station = go.AddOrGetDef<RanchStation.Def>();
    ranch_station.IsCritterEligibleToBeRanchedCb = (Func<GameObject, RanchStation.Instance, bool>) ((creature_go, ranch_station_smi) => !(creature_go.PrefabID() != (Tag) "Moo") && creature_go.GetComponent<KPrefabID>().HasTag(GameTags.Creatures.RequiresMilking));
    ranch_station.RancherInteractAnim = (HashedString) "anim_interacts_milking_station_kanim";
    ranch_station.RanchedPreAnim = (HashedString) "mooshake_pre";
    ranch_station.RanchedLoopAnim = (HashedString) "mooshake_loop";
    ranch_station.RanchedPstAnim = (HashedString) "mooshake_pst";
    ranch_station.WorkTime = 20f;
    ranch_station.CreatureRanchingStatusItem = Db.Get().CreatureStatusItems.GettingMilked;
    ranch_station.GetTargetRanchCell = (Func<RanchStation.Instance, int>) (smi =>
    {
      int num = Grid.InvalidCell;
      if (!smi.IsNullOrStopped())
        num = Grid.PosToCell(smi.transform.GetPosition());
      return num;
    });
    ranch_station.OnRanchCompleteCb = (Action<GameObject, WorkerBase>) ((creature_go, rancher_wb) =>
    {
      RanchStation.Instance targetRanchStation = creature_go.GetSMI<RanchableMonitor.Instance>().TargetRanchStation;
      AmountInstance amountInstance = creature_go.GetAmounts().Get(Db.Get().Amounts.MilkProduction.Id);
      if ((double) amountInstance.value > 0.0)
      {
        float mass = amountInstance.value * (MooTuning.MILK_AMOUNT_AT_MILKING / amountInstance.GetMax());
        targetRanchStation.GetComponent<Storage>().AddLiquid(SimHashes.Milk, mass, 310.15f, byte.MaxValue, 0);
        double num = (double) amountInstance.SetValue(0.0f);
      }
      creature_go.GetComponent<KPrefabID>().RemoveTag(GameTags.Creatures.RequiresMilking);
    });
    ranch_station.OnRanchWorkTick = (Action<GameObject, float, Workable>) ((creature_go, dt, workable) =>
    {
      if (!((HashedString) creature_go.GetComponent<KAnimControllerBase>().CurrentAnim.name == ranch_station.RanchedPstAnim))
        return;
      RanchStation.Instance ranchStation = creature_go.GetSMI<RanchedStates.Instance>().GetRanchStation();
      AmountInstance amountInstance = creature_go.GetAmounts().Get(Db.Get().Amounts.MilkProduction.Id);
      float num1 = amountInstance.GetMax() * dt / workable.workTime;
      float mass = num1 * (MooTuning.MILK_AMOUNT_AT_MILKING / amountInstance.GetMax());
      float temperature = creature_go.GetComponent<PrimaryElement>().Temperature;
      ranchStation.GetComponent<Storage>().AddLiquid(SimHashes.Milk, mass, temperature, byte.MaxValue, 0);
      double num2 = (double) amountInstance.ApplyDelta(-num1);
    });
    ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
    conduitDispenser.conduitType = ConduitType.Liquid;
    conduitDispenser.alwaysDispense = true;
    conduitDispenser.elementFilter = (SimHashes[]) null;
  }
}
