// Decompiled with JetBrains decompiler
// Type: MooConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MooConfig : IEntityConfig
{
  public const string ID = "Moo";
  public const string BASE_TRAIT_ID = "MooBaseTrait";
  public const SimHashes CONSUME_ELEMENT = SimHashes.Carbon;
  public static Tag POOP_ELEMENT = SimHashes.Methane.CreateTag();
  public static readonly float DAYS_PLANT_GROWTH_EATEN_PER_CYCLE = 2f;
  private static float CALORIES_PER_DAY_OF_PLANT_EATEN = MooTuning.STANDARD_CALORIES_PER_CYCLE / MooConfig.DAYS_PLANT_GROWTH_EATEN_PER_CYCLE;
  private static float KG_POOP_PER_DAY_OF_PLANT = 5f;
  private static float MIN_POOP_SIZE_IN_KG = 1.5f;
  private static float MIN_POOP_SIZE_IN_CALORIES = MooConfig.CALORIES_PER_DAY_OF_PLANT_EATEN * MooConfig.MIN_POOP_SIZE_IN_KG / MooConfig.KG_POOP_PER_DAY_OF_PLANT;

  public static GameObject CreateMoo(
    string id,
    string name,
    string desc,
    string anim_file,
    bool is_baby)
  {
    GameObject moo = BaseMooConfig.BaseMoo(id, name, (string) CREATURES.SPECIES.MOO.DESC, "MooBaseTrait", anim_file, is_baby, (string) null);
    EntityTemplates.ExtendEntityToWildCreature(moo, MooTuning.PEN_SIZE_PER_CREATURE);
    Trait trait = Db.Get().CreateTrait("MooBaseTrait", name, name, (string) null, false, (ChoreGroup[]) null, true, true);
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.maxAttribute.Id, MooTuning.STANDARD_STOMACH_SIZE, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.deltaAttribute.Id, (float) (-(double) MooTuning.STANDARD_CALORIES_PER_CYCLE / 600.0), (string) UI.TOOLTIPS.BASE_VALUE));
    trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, 50f, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, MooTuning.STANDARD_LIFESPAN, name));
    Diet diet = new Diet(new Diet.Info[1]
    {
      new Diet.Info(new HashSet<Tag>()
      {
        "GasGrass".ToTag()
      }, MooConfig.POOP_ELEMENT, MooConfig.CALORIES_PER_DAY_OF_PLANT_EATEN, MooConfig.KG_POOP_PER_DAY_OF_PLANT, food_type: Diet.Info.FoodType.EatPlantDirectly)
    });
    CreatureCalorieMonitor.Def def = moo.AddOrGetDef<CreatureCalorieMonitor.Def>();
    def.diet = diet;
    def.minConsumedCaloriesBeforePooping = MooConfig.MIN_POOP_SIZE_IN_CALORIES;
    moo.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
    moo.AddTag(GameTags.OriginalCreature);
    return moo;
  }

  public GameObject CreatePrefab()
  {
    return MooConfig.CreateMoo("Moo", (string) CREATURES.SPECIES.MOO.NAME, (string) CREATURES.SPECIES.MOO.DESC, "gassy_moo_kanim", false);
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst) => BaseMooConfig.OnSpawn(inst);
}
