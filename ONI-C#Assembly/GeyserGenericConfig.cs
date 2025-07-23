﻿// Decompiled with JetBrains decompiler
// Type: GeyserGenericConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei;
using System;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class GeyserGenericConfig : IMultiEntityConfig
{
  public const string ID = "GeyserGeneric";
  public const string Steam = "steam";
  public const string HotSteam = "hot_steam";
  public const string HotWater = "hot_water";
  public const string SlushWater = "slush_water";
  public const string FilthyWater = "filthy_water";
  public const string SlushSaltWater = "slush_salt_water";
  public const string SaltWater = "salt_water";
  public const string SmallVolcano = "small_volcano";
  public const string BigVolcano = "big_volcano";
  public const string LiquidCO2 = "liquid_co2";
  public const string HotCO2 = "hot_co2";
  public const string HotHydrogen = "hot_hydrogen";
  public const string HotPO2 = "hot_po2";
  public const string SlimyPO2 = "slimy_po2";
  public const string ChlorineGas = "chlorine_gas";
  public const string ChlorineGasCool = "chlorine_gas_cool";
  public const string Methane = "methane";
  public const string MoltenCopper = "molten_copper";
  public const string MoltenIron = "molten_iron";
  public const string MoltenGold = "molten_gold";
  public const string MoltenAluminum = "molten_aluminum";
  public const string MoltenTungsten = "molten_tungsten";
  public const string MoltenNiobium = "molten_niobium";
  public const string MoltenCobalt = "molten_cobalt";
  public const string OilDrip = "oil_drip";
  public const string LiquidSulfur = "liquid_sulfur";

  public List<GameObject> CreatePrefabs()
  {
    List<GameObject> prefabs = new List<GameObject>();
    List<GeyserGenericConfig.GeyserPrefabParams> configs = this.GenerateConfigs();
    foreach (GeyserGenericConfig.GeyserPrefabParams geyserPrefabParams in configs)
      prefabs.Add(GeyserGenericConfig.CreateGeyser(geyserPrefabParams.id, geyserPrefabParams.anim, geyserPrefabParams.width, geyserPrefabParams.height, (string) Strings.Get(geyserPrefabParams.nameStringKey), (string) Strings.Get(geyserPrefabParams.descStringKey), geyserPrefabParams.geyserType.idHash, geyserPrefabParams.geyserType.geyserTemperature, geyserPrefabParams.geyserType.requiredDlcIds, geyserPrefabParams.geyserType.forbiddenDlcIds));
    configs.RemoveAll((Predicate<GeyserGenericConfig.GeyserPrefabParams>) (x => !x.isGenericGeyser));
    GameObject entity = EntityTemplates.CreateEntity("GeyserGeneric", "Random Geyser Spawner");
    entity.AddOrGet<SaveLoadRoot>();
    entity.GetComponent<KPrefabID>().prefabInitFn += (KPrefabID.PrefabFn) (inst =>
    {
      int num = 0;
      if (SaveLoader.Instance.clusterDetailSave != null)
        num = SaveLoader.Instance.clusterDetailSave.globalWorldSeed;
      else
        Debug.LogWarning((object) "Could not load global world seed for geysers");
      int Seed = num + (int) inst.transform.GetPosition().x + (int) inst.transform.GetPosition().y;
      GameUtil.KInstantiate(Assets.GetPrefab((Tag) configs.FindAll((Predicate<GeyserGenericConfig.GeyserPrefabParams>) (x => Game.IsCorrectDlcActiveForCurrentSave((IHasDlcRestrictions) x.geyserType)))[new KRandom(Seed).Next(0, configs.Count)].id), inst.transform.GetPosition(), Grid.SceneLayer.BuildingBack).SetActive(true);
      inst.DeleteObject();
    });
    prefabs.Add(entity);
    return prefabs;
  }

  public static GameObject CreateGeyser(
    string id,
    string anim,
    int width,
    int height,
    string name,
    string desc,
    HashedString presetType,
    float geyserTemperature)
  {
    return GeyserGenericConfig.CreateGeyser(id, anim, width, height, name, desc, presetType, geyserTemperature, (string[]) null, (string[]) null);
  }

  public static GameObject CreateGeyser(
    string id,
    string anim,
    int width,
    int height,
    string name,
    string desc,
    HashedString presetType,
    float geyserTemperature,
    string[] requiredDlcIds,
    string[] forbiddenDlcIds)
  {
    string id1 = id;
    string name1 = name;
    string desc1 = desc;
    int num1 = width;
    int num2 = height;
    EffectorValues tieR1 = BUILDINGS.DECOR.BONUS.TIER1;
    EffectorValues tieR6 = NOISE_POLLUTION.NOISY.TIER6;
    KAnimFile anim1 = Assets.GetAnim((HashedString) anim);
    int width1 = num1;
    int height1 = num2;
    EffectorValues decor = tieR1;
    EffectorValues noise = tieR6;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity(id1, name1, desc1, 2000f, anim1, "inactive", Grid.SceneLayer.BuildingBack, width1, height1, decor, noise, additionalTags: new List<Tag>()
    {
      GameTags.GeyserFeature
    });
    placedEntity.AddOrGet<OccupyArea>().objectLayers = new ObjectLayer[1]
    {
      ObjectLayer.Building
    };
    PrimaryElement component1 = placedEntity.GetComponent<PrimaryElement>();
    component1.SetElement(SimHashes.Katairite);
    component1.Temperature = geyserTemperature;
    placedEntity.AddOrGet<Prioritizable>();
    placedEntity.AddOrGet<Uncoverable>();
    placedEntity.AddOrGet<Geyser>().outputOffset = new Vector2I(0, 1);
    placedEntity.AddOrGet<GeyserConfigurator>().presetType = presetType;
    Studyable studyable = placedEntity.AddOrGet<Studyable>();
    studyable.meterTrackerSymbol = "geotracker_target";
    studyable.meterAnim = "tracker";
    placedEntity.AddOrGet<LoopingSounds>();
    SoundEventVolumeCache.instance.AddVolume("geyser_side_steam_kanim", "Geyser_shake_LP", NOISE_POLLUTION.NOISY.TIER5);
    SoundEventVolumeCache.instance.AddVolume("geyser_side_steam_kanim", "Geyser_erupt_LP", NOISE_POLLUTION.NOISY.TIER6);
    KPrefabID component2 = placedEntity.GetComponent<KPrefabID>();
    component2.requiredDlcIds = requiredDlcIds;
    component2.forbiddenDlcIds = forbiddenDlcIds;
    return placedEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }

  private List<GeyserGenericConfig.GeyserPrefabParams> GenerateConfigs()
  {
    List<GeyserGenericConfig.GeyserPrefabParams> configs = new List<GeyserGenericConfig.GeyserPrefabParams>();
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_steam_kanim", 2, 4, new GeyserConfigurator.GeyserType("steam", SimHashes.Steam, GeyserConfigurator.GeyserShape.Gas, 383.15f, 1000f, 2000f, 5f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_steam_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_steam", SimHashes.Steam, GeyserConfigurator.GeyserShape.Gas, 773.15f, 500f, 1000f, 5f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_hot_kanim", 4, 2, new GeyserConfigurator.GeyserType("hot_water", SimHashes.Water, GeyserConfigurator.GeyserShape.Liquid, 368.15f, 2000f, 4000f, 500f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_slush_kanim", 4, 2, new GeyserConfigurator.GeyserType("slush_water", SimHashes.DirtyWater, GeyserConfigurator.GeyserShape.Liquid, 263.15f, 1000f, 2000f, 500f, (string[]) null, geyserTemperature: 263f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_water_filthy_kanim", 4, 2, new GeyserConfigurator.GeyserType("filthy_water", SimHashes.DirtyWater, GeyserConfigurator.GeyserShape.Liquid, 303.15f, 2000f, 4000f, 500f, (string[]) null).AddDisease(new SimUtil.DiseaseInfo()
    {
      idx = Db.Get().Diseases.GetIndex((HashedString) "FoodPoisoning"),
      count = 20000
    }), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_salt_water_cool_slush_kanim", 4, 2, new GeyserConfigurator.GeyserType("slush_salt_water", SimHashes.Brine, GeyserConfigurator.GeyserShape.Liquid, 263.15f, 1000f, 2000f, 500f, (string[]) null, geyserTemperature: 263f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_salt_water_kanim", 4, 2, new GeyserConfigurator.GeyserType("salt_water", SimHashes.SaltWater, GeyserConfigurator.GeyserShape.Liquid, 368.15f, 2000f, 4000f, 500f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_volcano_small_kanim", 3, 3, new GeyserConfigurator.GeyserType("small_volcano", SimHashes.Magma, GeyserConfigurator.GeyserShape.Molten, 2000f, 400f, 800f, 150f, (string[]) null, minIterationLength: 6000f, maxIterationLength: 12000f, minIterationPercent: 0.005f, maxIterationPercent: 0.01f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_volcano_big_kanim", 3, 3, new GeyserConfigurator.GeyserType("big_volcano", SimHashes.Magma, GeyserConfigurator.GeyserShape.Molten, 2000f, 800f, 1600f, 150f, (string[]) null, minIterationLength: 6000f, maxIterationLength: 12000f, minIterationPercent: 0.005f, maxIterationPercent: 0.01f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_co2_kanim", 4, 2, new GeyserConfigurator.GeyserType("liquid_co2", SimHashes.LiquidCarbonDioxide, GeyserConfigurator.GeyserShape.Liquid, 218f, 100f, 200f, 50f, (string[]) null, geyserTemperature: 218f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_co2_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_co2", SimHashes.CarbonDioxide, GeyserConfigurator.GeyserShape.Gas, 773.15f, 70f, 140f, 5f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_hydrogen_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_hydrogen", SimHashes.Hydrogen, GeyserConfigurator.GeyserShape.Gas, 773.15f, 70f, 140f, 5f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_po2_hot_kanim", 2, 4, new GeyserConfigurator.GeyserType("hot_po2", SimHashes.ContaminatedOxygen, GeyserConfigurator.GeyserShape.Gas, 773.15f, 70f, 140f, 5f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_po2_slimy_kanim", 2, 4, new GeyserConfigurator.GeyserType("slimy_po2", SimHashes.ContaminatedOxygen, GeyserConfigurator.GeyserShape.Gas, 333.15f, 70f, 140f, 5f, (string[]) null).AddDisease(new SimUtil.DiseaseInfo()
    {
      idx = Db.Get().Diseases.GetIndex((HashedString) "SlimeLung"),
      count = 5000
    }), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_chlorine_kanim", 2, 4, new GeyserConfigurator.GeyserType("chlorine_gas", SimHashes.ChlorineGas, GeyserConfigurator.GeyserShape.Gas, 333.15f, 70f, 140f, 5f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_chlorine_kanim", 2, 4, new GeyserConfigurator.GeyserType("chlorine_gas_cool", SimHashes.ChlorineGas, GeyserConfigurator.GeyserShape.Gas, 278.15f, 70f, 140f, 5f, (string[]) null), false));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_gas_methane_kanim", 2, 4, new GeyserConfigurator.GeyserType("methane", SimHashes.Methane, GeyserConfigurator.GeyserShape.Gas, 423.15f, 70f, 140f, 5f, (string[]) null), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_copper_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_copper", SimHashes.MoltenCopper, GeyserConfigurator.GeyserShape.Molten, 2500f, 200f, 400f, 150f, (string[]) null, minIterationLength: 480f, maxIterationLength: 1080f, minIterationPercent: 0.0166666675f, maxIterationPercent: 0.1f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_iron_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_iron", SimHashes.MoltenIron, GeyserConfigurator.GeyserShape.Molten, 2800f, 200f, 400f, 150f, (string[]) null, minIterationLength: 480f, maxIterationLength: 1080f, minIterationPercent: 0.0166666675f, maxIterationPercent: 0.1f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_gold_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_gold", SimHashes.MoltenGold, GeyserConfigurator.GeyserShape.Molten, 2900f, 200f, 400f, 150f, (string[]) null, minIterationLength: 480f, maxIterationLength: 1080f, minIterationPercent: 0.0166666675f, maxIterationPercent: 0.1f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_aluminum_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_aluminum", SimHashes.MoltenAluminum, GeyserConfigurator.GeyserShape.Molten, 2000f, 200f, 400f, 150f, DlcManager.EXPANSION1, minIterationLength: 480f, maxIterationLength: 1080f, minIterationPercent: 0.0166666675f, maxIterationPercent: 0.1f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_tungsten_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_tungsten", SimHashes.MoltenTungsten, GeyserConfigurator.GeyserShape.Molten, 4000f, 200f, 400f, 150f, DlcManager.EXPANSION1, minIterationLength: 480f, maxIterationLength: 1080f, minIterationPercent: 0.0166666675f, maxIterationPercent: 0.1f), false));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_niobium_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_niobium", SimHashes.MoltenNiobium, GeyserConfigurator.GeyserShape.Molten, 3500f, 800f, 1600f, 150f, DlcManager.EXPANSION1, minIterationLength: 6000f, maxIterationLength: 12000f, minIterationPercent: 0.005f, maxIterationPercent: 0.01f), false));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_molten_cobalt_kanim", 3, 3, new GeyserConfigurator.GeyserType("molten_cobalt", SimHashes.MoltenCobalt, GeyserConfigurator.GeyserShape.Molten, 2500f, 200f, 400f, 150f, DlcManager.EXPANSION1, minIterationLength: 480f, maxIterationLength: 1080f, minIterationPercent: 0.0166666675f, maxIterationPercent: 0.1f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_oil_kanim", 4, 2, new GeyserConfigurator.GeyserType("oil_drip", SimHashes.CrudeOil, GeyserConfigurator.GeyserShape.Liquid, 600f, 1f, 250f, 50f, (string[]) null, minIterationLength: 600f, maxIterationLength: 600f, minIterationPercent: 1f, maxIterationPercent: 1f, minYearLength: 100f, maxYearLength: 500f), true));
    configs.Add(new GeyserGenericConfig.GeyserPrefabParams("geyser_liquid_sulfur_kanim", 4, 2, new GeyserConfigurator.GeyserType("liquid_sulfur", SimHashes.LiquidSulfur, GeyserConfigurator.GeyserShape.Liquid, 438.349976f, 1000f, 2000f, 500f, DlcManager.EXPANSION1), true));
    configs.RemoveAll((Predicate<GeyserGenericConfig.GeyserPrefabParams>) (geyser => !DlcManager.IsCorrectDlcSubscribed((IHasDlcRestrictions) geyser.geyserType)));
    return configs;
  }

  public struct GeyserPrefabParams
  {
    public string id;
    public string anim;
    public int width;
    public int height;
    public StringKey nameStringKey;
    public StringKey descStringKey;
    public GeyserConfigurator.GeyserType geyserType;
    public bool isGenericGeyser;

    public GeyserPrefabParams(
      string anim,
      int width,
      int height,
      GeyserConfigurator.GeyserType geyserType,
      bool isGenericGeyser)
    {
      this.id = "GeyserGeneric_" + geyserType.id;
      this.anim = anim;
      this.width = width;
      this.height = height;
      this.nameStringKey = new StringKey($"STRINGS.CREATURES.SPECIES.GEYSER.{geyserType.id.ToUpper()}.NAME");
      this.descStringKey = new StringKey($"STRINGS.CREATURES.SPECIES.GEYSER.{geyserType.id.ToUpper()}.DESC");
      this.geyserType = geyserType;
      this.isGenericGeyser = isGenericGeyser;
    }
  }

  private static class TEMPERATURES
  {
    public const float BELOW_FREEZING = 263.15f;
    public const float DUPE_NORMAL = 303.15f;
    public const float DUPE_HOT = 333.15f;
    public const float BELOW_BOILING = 368.15f;
    public const float ABOVE_BOILING = 383.15f;
    public const float HOT1 = 423.15f;
    public const float HOT2 = 773.15f;
    public const float MOLTEN_MAGMA = 2000f;
  }

  public static class RATES
  {
    public const float GAS_SMALL_MIN = 40f;
    public const float GAS_SMALL_MAX = 80f;
    public const float GAS_NORMAL_MIN = 70f;
    public const float GAS_NORMAL_MAX = 140f;
    public const float GAS_BIG_MIN = 100f;
    public const float GAS_BIG_MAX = 200f;
    public const float LIQUID_SMALL_MIN = 500f;
    public const float LIQUID_SMALL_MAX = 1000f;
    public const float LIQUID_NORMAL_MIN = 1000f;
    public const float LIQUID_NORMAL_MAX = 2000f;
    public const float LIQUID_BIG_MIN = 2000f;
    public const float LIQUID_BIG_MAX = 4000f;
    public const float MOLTEN_NORMAL_MIN = 200f;
    public const float MOLTEN_NORMAL_MAX = 400f;
    public const float MOLTEN_BIG_MIN = 400f;
    public const float MOLTEN_BIG_MAX = 800f;
    public const float MOLTEN_HUGE_MIN = 800f;
    public const float MOLTEN_HUGE_MAX = 1600f;
  }

  public static class MAX_PRESSURES
  {
    public const float GAS = 5f;
    public const float GAS_HIGH = 15f;
    public const float MOLTEN = 150f;
    public const float LIQUID_SMALL = 50f;
    public const float LIQUID = 500f;
  }

  public static class ITERATIONS
  {
    public static class INFREQUENT_MOLTEN
    {
      public const float PCT_MIN = 0.005f;
      public const float PCT_MAX = 0.01f;
      public const float LEN_MIN = 6000f;
      public const float LEN_MAX = 12000f;
    }

    public static class FREQUENT_MOLTEN
    {
      public const float PCT_MIN = 0.0166666675f;
      public const float PCT_MAX = 0.1f;
      public const float LEN_MIN = 480f;
      public const float LEN_MAX = 1080f;
    }
  }
}
