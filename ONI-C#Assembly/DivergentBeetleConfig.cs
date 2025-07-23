﻿// Decompiled with JetBrains decompiler
// Type: DivergentBeetleConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[EntityConfigOrder(1)]
public class DivergentBeetleConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "DivergentBeetle";
  public const string BASE_TRAIT_ID = "DivergentBeetleBaseTrait";
  public const string EGG_ID = "DivergentBeetleEgg";
  private const float LIFESPAN = 75f;
  private const SimHashes EMIT_ELEMENT = SimHashes.Sucrose;
  private static float KG_ORE_EATEN_PER_CYCLE = 20f;
  private static float CALORIES_PER_KG_OF_ORE = DivergentTuning.STANDARD_CALORIES_PER_CYCLE / DivergentBeetleConfig.KG_ORE_EATEN_PER_CYCLE;
  private static float MIN_POOP_SIZE_IN_KG = 4f;
  public static int EGG_SORT_ORDER = 0;

  public static GameObject CreateDivergentBeetle(
    string id,
    string name,
    string desc,
    string anim_file,
    bool is_baby)
  {
    GameObject wildCreature = EntityTemplates.ExtendEntityToWildCreature(BaseDivergentConfig.BaseDivergent(id, name, desc, 50f, anim_file, "DivergentBeetleBaseTrait", is_baby), DivergentTuning.PEN_SIZE_PER_CREATURE);
    Trait trait = Db.Get().CreateTrait("DivergentBeetleBaseTrait", name, name, (string) null, false, (ChoreGroup[]) null, true, true);
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.maxAttribute.Id, DivergentTuning.STANDARD_STOMACH_SIZE, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.deltaAttribute.Id, (float) (-(double) DivergentTuning.STANDARD_CALORIES_PER_CYCLE / 600.0), (string) UI.TOOLTIPS.BASE_VALUE));
    trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, 25f, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, 75f, name));
    List<Diet.Info> diet_infos = BaseDivergentConfig.BasicSulfurDiet(SimHashes.Sucrose.CreateTag(), DivergentBeetleConfig.CALORIES_PER_KG_OF_ORE, TUNING.CREATURES.CONVERSION_EFFICIENCY.NORMAL, (string) null, 0.0f);
    double caloriesPerKgOfOre = (double) DivergentBeetleConfig.CALORIES_PER_KG_OF_ORE;
    double minPoopSizeInKg = (double) DivergentBeetleConfig.MIN_POOP_SIZE_IN_KG;
    GameObject go = BaseDivergentConfig.SetupDiet(wildCreature, diet_infos, (float) caloriesPerKgOfOre, (float) minPoopSizeInKg);
    go.AddTag(GameTags.OriginalCreature);
    return go;
  }

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject fertileCreature = EntityTemplates.ExtendEntityToFertileCreature(DivergentBeetleConfig.CreateDivergentBeetle("DivergentBeetle", (string) STRINGS.CREATURES.SPECIES.DIVERGENT.VARIANT_BEETLE.NAME, (string) STRINGS.CREATURES.SPECIES.DIVERGENT.VARIANT_BEETLE.DESC, "critter_kanim", false), (IHasDlcRestrictions) this, "DivergentBeetleEgg", (string) STRINGS.CREATURES.SPECIES.DIVERGENT.VARIANT_BEETLE.EGG_NAME, (string) STRINGS.CREATURES.SPECIES.DIVERGENT.VARIANT_BEETLE.DESC, "egg_critter_kanim", DivergentTuning.EGG_MASS, "DivergentBeetleBaby", 45f, 15f, DivergentTuning.EGG_CHANCES_BEETLE, DivergentBeetleConfig.EGG_SORT_ORDER);
    fertileCreature.AddTag(GameTags.Creatures.Pollinator);
    return fertileCreature;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
