﻿// Decompiled with JetBrains decompiler
// Type: OilFloaterHighTempConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using UnityEngine;

#nullable disable
public class OilFloaterHighTempConfig : IEntityConfig
{
  public const string ID = "OilfloaterHighTemp";
  public const string BASE_TRAIT_ID = "OilfloaterHighTempBaseTrait";
  public const string EGG_ID = "OilfloaterHighTempEgg";
  public const SimHashes CONSUME_ELEMENT = SimHashes.CarbonDioxide;
  public const SimHashes EMIT_ELEMENT = SimHashes.Petroleum;
  private static float KG_ORE_EATEN_PER_CYCLE = 20f;
  private static float CALORIES_PER_KG_OF_ORE = OilFloaterTuning.STANDARD_CALORIES_PER_CYCLE / OilFloaterHighTempConfig.KG_ORE_EATEN_PER_CYCLE;
  private static float MIN_POOP_SIZE_IN_KG = 0.5f;
  public static int EGG_SORT_ORDER = OilFloaterConfig.EGG_SORT_ORDER + 1;

  public static GameObject CreateOilFloater(
    string id,
    string name,
    string desc,
    string anim_file,
    bool is_baby)
  {
    GameObject prefab = BaseOilFloaterConfig.BaseOilFloater(id, name, desc, anim_file, "OilfloaterHighTempBaseTrait", 373.15f, 473.15f, 323.15f, 573.15f, is_baby, "hot_");
    EntityTemplates.ExtendEntityToWildCreature(prefab, OilFloaterTuning.PEN_SIZE_PER_CREATURE);
    Trait trait = Db.Get().CreateTrait("OilfloaterHighTempBaseTrait", name, name, (string) null, false, (ChoreGroup[]) null, true, true);
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.maxAttribute.Id, OilFloaterTuning.STANDARD_STOMACH_SIZE, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.deltaAttribute.Id, (float) (-(double) OilFloaterTuning.STANDARD_CALORIES_PER_CYCLE / 600.0), (string) UI.TOOLTIPS.BASE_VALUE));
    trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, 25f, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, 100f, name));
    return BaseOilFloaterConfig.SetupDiet(prefab, SimHashes.CarbonDioxide.CreateTag(), SimHashes.Petroleum.CreateTag(), OilFloaterHighTempConfig.CALORIES_PER_KG_OF_ORE, TUNING.CREATURES.CONVERSION_EFFICIENCY.NORMAL, (string) null, 0.0f, OilFloaterHighTempConfig.MIN_POOP_SIZE_IN_KG);
  }

  public GameObject CreatePrefab()
  {
    GameObject oilFloater = OilFloaterHighTempConfig.CreateOilFloater("OilfloaterHighTemp", (string) STRINGS.CREATURES.SPECIES.OILFLOATER.VARIANT_HIGHTEMP.NAME, (string) STRINGS.CREATURES.SPECIES.OILFLOATER.VARIANT_HIGHTEMP.DESC, "oilfloater_kanim", false);
    EntityTemplates.ExtendEntityToFertileCreature(oilFloater, this as IHasDlcRestrictions, "OilfloaterHighTempEgg", (string) STRINGS.CREATURES.SPECIES.OILFLOATER.VARIANT_HIGHTEMP.EGG_NAME, (string) STRINGS.CREATURES.SPECIES.OILFLOATER.VARIANT_HIGHTEMP.DESC, "egg_oilfloater_kanim", OilFloaterTuning.EGG_MASS, "OilfloaterHighTempBaby", 60.0000038f, 20f, OilFloaterTuning.EGG_CHANCES_HIGHTEMP, OilFloaterHighTempConfig.EGG_SORT_ORDER);
    return oilFloater;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
