﻿// Decompiled with JetBrains decompiler
// Type: PuftBleachstoneConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using UnityEngine;

#nullable disable
public class PuftBleachstoneConfig : IEntityConfig
{
  public const string ID = "PuftBleachstone";
  public const string BASE_TRAIT_ID = "PuftBleachstoneBaseTrait";
  public const string EGG_ID = "PuftBleachstoneEgg";
  public const SimHashes CONSUME_ELEMENT = SimHashes.ChlorineGas;
  public const SimHashes EMIT_ELEMENT = SimHashes.BleachStone;
  private static float KG_ORE_EATEN_PER_CYCLE = 30f;
  private static float CALORIES_PER_KG_OF_ORE = PuftTuning.STANDARD_CALORIES_PER_CYCLE / PuftBleachstoneConfig.KG_ORE_EATEN_PER_CYCLE;
  private static float MIN_POOP_SIZE_IN_KG = 15f;
  public static int EGG_SORT_ORDER = PuftConfig.EGG_SORT_ORDER + 3;

  public static GameObject CreatePuftBleachstone(
    string id,
    string name,
    string desc,
    string anim_file,
    bool is_baby)
  {
    GameObject wildCreature = EntityTemplates.ExtendEntityToWildCreature(BasePuftConfig.BasePuft(id, name, desc, "PuftBleachstoneBaseTrait", anim_file, is_baby, "anti_", 273.15f, 333.15f, 223.15f, 373.15f), PuftTuning.PEN_SIZE_PER_CREATURE);
    Trait trait = Db.Get().CreateTrait("PuftBleachstoneBaseTrait", name, name, (string) null, false, (ChoreGroup[]) null, true, true);
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.maxAttribute.Id, PuftTuning.STANDARD_STOMACH_SIZE, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.deltaAttribute.Id, (float) (-(double) PuftTuning.STANDARD_CALORIES_PER_CYCLE / 600.0), (string) UI.TOOLTIPS.BASE_VALUE));
    trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, 25f, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, 75f, name));
    GameObject go = BasePuftConfig.SetupDiet(wildCreature, SimHashes.ChlorineGas.CreateTag(), SimHashes.BleachStone.CreateTag(), PuftBleachstoneConfig.CALORIES_PER_KG_OF_ORE, TUNING.CREATURES.CONVERSION_EFFICIENCY.GOOD_2, (string) null, 0.0f, PuftBleachstoneConfig.MIN_POOP_SIZE_IN_KG);
    go.AddOrGetDef<LureableMonitor.Def>().lures = new Tag[2]
    {
      SimHashes.BleachStone.CreateTag(),
      GameTags.Creatures.FlyersLure
    };
    return go;
  }

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFertileCreature(PuftBleachstoneConfig.CreatePuftBleachstone("PuftBleachstone", (string) STRINGS.CREATURES.SPECIES.PUFT.VARIANT_BLEACHSTONE.NAME, (string) STRINGS.CREATURES.SPECIES.PUFT.VARIANT_BLEACHSTONE.DESC, "puft_kanim", false), this as IHasDlcRestrictions, "PuftBleachstoneEgg", (string) STRINGS.CREATURES.SPECIES.PUFT.VARIANT_BLEACHSTONE.EGG_NAME, (string) STRINGS.CREATURES.SPECIES.PUFT.VARIANT_BLEACHSTONE.DESC, "egg_puft_kanim", PuftTuning.EGG_MASS, "PuftBleachstoneBaby", 45f, 15f, PuftTuning.EGG_CHANCES_BLEACHSTONE, PuftBleachstoneConfig.EGG_SORT_ORDER);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst) => BasePuftConfig.OnSpawn(inst);
}
