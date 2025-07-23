// Decompiled with JetBrains decompiler
// Type: SeaLettuceConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class SeaLettuceConfig : IEntityConfig
{
  public static string ID = "SeaLettuce";
  public const string SEED_ID = "SeaLettuceSeed";
  public const float WATER_RATE = 0.008333334f;
  public const float FERTILIZATION_RATE = 0.000833333354f;

  public GameObject CreatePrefab()
  {
    string id = SeaLettuceConfig.ID;
    string name1 = (string) STRINGS.CREATURES.SPECIES.SEALETTUCE.NAME;
    string desc1 = (string) STRINGS.CREATURES.SPECIES.SEALETTUCE.DESC;
    EffectorValues tieR0 = TUNING.DECOR.BONUS.TIER0;
    KAnimFile anim1 = Assets.GetAnim((HashedString) "sea_lettuce_kanim");
    EffectorValues decor = tieR0;
    EffectorValues noise = new EffectorValues();
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity(id, name1, desc1, 1f, anim1, "idle_empty", Grid.SceneLayer.BuildingBack, 1, 2, decor, noise, defaultTemperature: 308.15f);
    EntityTemplates.ExtendEntityToBasicPlant(placedEntity, 248.15f, 295.15f, 338.15f, safe_elements: new SimHashes[3]
    {
      SimHashes.Water,
      SimHashes.SaltWater,
      SimHashes.Brine
    }, pressure_sensitive: false, crop_id: "Lettuce", max_radiation: 7400f, baseTraitId: SeaLettuceConfig.ID + "Original", baseTraitName: (string) STRINGS.CREATURES.SPECIES.SEALETTUCE.NAME);
    EntityTemplates.ExtendPlantToIrrigated(placedEntity, new PlantElementAbsorber.ConsumeInfo[1]
    {
      new PlantElementAbsorber.ConsumeInfo()
      {
        tag = SimHashes.SaltWater.CreateTag(),
        massConsumptionRate = 0.008333334f
      }
    });
    EntityTemplates.ExtendPlantToFertilizable(placedEntity, new PlantElementAbsorber.ConsumeInfo[1]
    {
      new PlantElementAbsorber.ConsumeInfo()
      {
        tag = SimHashes.BleachStone.CreateTag(),
        massConsumptionRate = 0.000833333354f
      }
    });
    placedEntity.GetComponent<DrowningMonitor>().canDrownToDeath = false;
    placedEntity.GetComponent<DrowningMonitor>().livesUnderWater = true;
    placedEntity.AddOrGet<StandardCropPlant>();
    placedEntity.AddOrGet<LoopingSounds>();
    GameObject plant = placedEntity;
    IHasDlcRestrictions dlcRestrictions = this as IHasDlcRestrictions;
    string name2 = (string) STRINGS.CREATURES.SPECIES.SEEDS.SEALETTUCE.NAME;
    string desc2 = (string) STRINGS.CREATURES.SPECIES.SEEDS.SEALETTUCE.DESC;
    KAnimFile anim2 = Assets.GetAnim((HashedString) "seed_sealettuce_kanim");
    List<Tag> additionalTags = new List<Tag>();
    additionalTags.Add(GameTags.WaterSeed);
    string domesticateddesc = (string) STRINGS.CREATURES.SPECIES.SEALETTUCE.DOMESTICATEDDESC;
    Tag replantGroundTag = new Tag();
    string domesticatedDescription = domesticateddesc;
    EntityTemplates.CreateAndRegisterPreviewForPlant(EntityTemplates.CreateAndRegisterSeedForPlant(plant, dlcRestrictions, SeedProducer.ProductionType.Harvest, "SeaLettuceSeed", name2, desc2, anim2, additionalTags: additionalTags, replantGroundTag: replantGroundTag, sortOrder: 3, domesticatedDescription: domesticatedDescription), SeaLettuceConfig.ID + "_preview", Assets.GetAnim((HashedString) "sea_lettuce_kanim"), "place", 1, 2);
    SoundEventVolumeCache.instance.AddVolume("sea_lettuce_kanim", "SeaLettuce_grow", NOISE_POLLUTION.CREATURES.TIER3);
    SoundEventVolumeCache.instance.AddVolume("sea_lettuce_kanim", "SeaLettuce_harvest", NOISE_POLLUTION.CREATURES.TIER3);
    return placedEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
