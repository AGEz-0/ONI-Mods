﻿// Decompiled with JetBrains decompiler
// Type: EvilFlowerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class EvilFlowerConfig : IEntityConfig
{
  public const string ID = "EvilFlower";
  public const string SEED_ID = "EvilFlowerSeed";
  public readonly EffectorValues POSITIVE_DECOR_EFFECT = TUNING.DECOR.BONUS.TIER7;
  public readonly EffectorValues NEGATIVE_DECOR_EFFECT = TUNING.DECOR.PENALTY.TIER5;
  public const int GERMS_PER_SECOND = 1000;

  public GameObject CreatePrefab()
  {
    string name1 = (string) STRINGS.CREATURES.SPECIES.EVILFLOWER.NAME;
    string desc1 = (string) STRINGS.CREATURES.SPECIES.EVILFLOWER.DESC;
    EffectorValues positiveDecorEffect = this.POSITIVE_DECOR_EFFECT;
    KAnimFile anim1 = Assets.GetAnim((HashedString) "potted_evilflower_kanim");
    EffectorValues decor = positiveDecorEffect;
    EffectorValues noise = new EffectorValues();
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity("EvilFlower", name1, desc1, 1f, anim1, "grow_seed", Grid.SceneLayer.BuildingFront, 1, 1, decor, noise);
    EntityTemplates.ExtendEntityToBasicPlant(placedEntity, 168.15f, 258.15f, 513.15f, 563.15f, new SimHashes[1]
    {
      SimHashes.CarbonDioxide
    }, can_tinker: false, max_radiation: 12200f, baseTraitId: "EvilFlowerOriginal", baseTraitName: (string) STRINGS.CREATURES.SPECIES.EVILFLOWER.NAME);
    EvilFlower evilFlower = placedEntity.AddOrGet<EvilFlower>();
    evilFlower.positive_decor_effect = this.POSITIVE_DECOR_EFFECT;
    evilFlower.negative_decor_effect = this.NEGATIVE_DECOR_EFFECT;
    GameObject plant = placedEntity;
    IHasDlcRestrictions dlcRestrictions = this as IHasDlcRestrictions;
    string name2 = (string) STRINGS.CREATURES.SPECIES.SEEDS.EVILFLOWER.NAME;
    string desc2 = (string) STRINGS.CREATURES.SPECIES.SEEDS.EVILFLOWER.DESC;
    KAnimFile anim2 = Assets.GetAnim((HashedString) "seed_potted_evilflower_kanim");
    List<Tag> additionalTags = new List<Tag>();
    additionalTags.Add(GameTags.DecorSeed);
    string domesticateddesc = (string) STRINGS.CREATURES.SPECIES.EVILFLOWER.DOMESTICATEDDESC;
    Tag replantGroundTag = new Tag();
    string domesticatedDescription = domesticateddesc;
    EntityTemplates.CreateAndRegisterPreviewForPlant(EntityTemplates.CreateAndRegisterSeedForPlant(plant, dlcRestrictions, SeedProducer.ProductionType.Hidden, "EvilFlowerSeed", name2, desc2, anim2, additionalTags: additionalTags, replantGroundTag: replantGroundTag, sortOrder: 19, domesticatedDescription: domesticatedDescription, width: 0.4f, height: 0.4f), "EvilFlower_preview", Assets.GetAnim((HashedString) "potted_evilflower_kanim"), "place", 1, 1);
    DiseaseDropper.Def def = placedEntity.AddOrGetDef<DiseaseDropper.Def>();
    def.diseaseIdx = Db.Get().Diseases.GetIndex((HashedString) "ZombieSpores");
    def.emitFrequency = 1f;
    def.averageEmitPerSecond = 1000;
    def.singleEmitQuantity = 100000;
    placedEntity.AddOrGet<DiseaseSourceVisualizer>().alwaysShowDisease = "ZombieSpores";
    return placedEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
