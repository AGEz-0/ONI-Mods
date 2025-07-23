﻿// Decompiled with JetBrains decompiler
// Type: CrabFreshWaterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
[EntityConfigOrder(1)]
public class CrabFreshWaterConfig : IEntityConfig
{
  public const string ID = "CrabFreshWater";
  public const string BASE_TRAIT_ID = "CrabFreshWaterBaseTrait";
  public const string EGG_ID = "CrabFreshWaterEgg";
  private const SimHashes EMIT_ELEMENT = SimHashes.Sand;
  private static float KG_ORE_EATEN_PER_CYCLE = 70f;
  private static float CALORIES_PER_KG_OF_ORE = CrabTuning.STANDARD_CALORIES_PER_CYCLE / CrabFreshWaterConfig.KG_ORE_EATEN_PER_CYCLE;
  private static float MIN_POOP_SIZE_IN_KG = 25f;
  public static int EGG_SORT_ORDER = 0;
  private static string animPrefix = "fresh_";

  public static GameObject CreateCrabFreshWater(
    string id,
    string name,
    string desc,
    string anim_file,
    bool is_baby,
    string deathDropID = null,
    int deathDropCount = 0)
  {
    GameObject wildCreature = EntityTemplates.ExtendEntityToWildCreature(BaseCrabConfig.BaseCrab(id, name, desc, anim_file, "CrabFreshWaterBaseTrait", is_baby, CrabFreshWaterConfig.animPrefix, deathDropID, (float) deathDropCount), CrabTuning.PEN_SIZE_PER_CREATURE);
    Trait trait = Db.Get().CreateTrait("CrabFreshWaterBaseTrait", name, name, (string) null, false, (ChoreGroup[]) null, true, true);
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.maxAttribute.Id, CrabTuning.STANDARD_STOMACH_SIZE, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.deltaAttribute.Id, (float) (-(double) CrabTuning.STANDARD_CALORIES_PER_CYCLE / 600.0), (string) UI.TOOLTIPS.BASE_VALUE));
    trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, 25f, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, 100f, name));
    List<Diet.Info> diet_infos = BaseCrabConfig.DietWithSlime(SimHashes.Sand.CreateTag(), CrabFreshWaterConfig.CALORIES_PER_KG_OF_ORE, TUNING.CREATURES.CONVERSION_EFFICIENCY.NORMAL, (string) null, 0.0f);
    double caloriesPerKgOfOre = (double) CrabFreshWaterConfig.CALORIES_PER_KG_OF_ORE;
    double minPoopSizeInKg = (double) CrabFreshWaterConfig.MIN_POOP_SIZE_IN_KG;
    return BaseCrabConfig.SetupDiet(wildCreature, diet_infos, (float) caloriesPerKgOfOre, (float) minPoopSizeInKg);
  }

  public GameObject CreatePrefab()
  {
    GameObject fertileCreature = EntityTemplates.ExtendEntityToFertileCreature(CrabFreshWaterConfig.CreateCrabFreshWater("CrabFreshWater", (string) STRINGS.CREATURES.SPECIES.CRAB.VARIANT_FRESH_WATER.NAME, (string) STRINGS.CREATURES.SPECIES.CRAB.VARIANT_FRESH_WATER.DESC, "pincher_kanim", false, "ShellfishMeat", 4), this as IHasDlcRestrictions, "CrabFreshWaterEgg", (string) STRINGS.CREATURES.SPECIES.CRAB.VARIANT_FRESH_WATER.EGG_NAME, (string) STRINGS.CREATURES.SPECIES.CRAB.VARIANT_FRESH_WATER.DESC, "egg_pincher_kanim", CrabTuning.EGG_MASS, "CrabFreshWaterBaby", 60.0000038f, 20f, CrabTuning.EGG_CHANCES_FRESH, CrabFreshWaterConfig.EGG_SORT_ORDER);
    EggProtectionMonitor.Def def1 = fertileCreature.AddOrGetDef<EggProtectionMonitor.Def>();
    def1.allyTags = new Tag[1]
    {
      GameTags.Creatures.CrabFriend
    };
    def1.animPrefix = CrabFreshWaterConfig.animPrefix;
    DiseaseEmitter diseaseEmitter = fertileCreature.AddComponent<DiseaseEmitter>();
    List<Klei.AI.Disease> diseases = new List<Klei.AI.Disease>()
    {
      Db.Get().Diseases.FoodGerms,
      Db.Get().Diseases.PollenGerms,
      Db.Get().Diseases.SlimeGerms,
      Db.Get().Diseases.ZombieSpores
    };
    if (DlcManager.IsExpansion1Active())
      diseases.Add(Db.Get().Diseases.RadiationPoisoning);
    diseaseEmitter.SetDiseases(diseases);
    diseaseEmitter.emitRange = (byte) 2;
    diseaseEmitter.emitCount = -1 * Mathf.RoundToInt((float) ((double) DUPLICANTSTATS.STANDARD.Secretions.DISEASE_PER_PEE / 600.0 * 6.0 * 2.0 * 4.0 / 9.0));
    CleaningMonitor.Def def2 = fertileCreature.AddOrGetDef<CleaningMonitor.Def>();
    def2.elementState = Element.State.Liquid;
    def2.cellOffsets = new CellOffset[5]
    {
      new CellOffset(1, 0),
      new CellOffset(-1, 0),
      new CellOffset(0, 1),
      new CellOffset(-1, 1),
      new CellOffset(1, 1)
    };
    def2.coolDown = 30f;
    return fertileCreature;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
