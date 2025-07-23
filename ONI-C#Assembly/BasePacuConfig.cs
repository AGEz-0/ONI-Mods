// Decompiled with JetBrains decompiler
// Type: BasePacuConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class BasePacuConfig
{
  private static float KG_ORE_EATEN_PER_CYCLE = 7.5f;
  private static float CALORIES_PER_KG_OF_ORE = PacuTuning.STANDARD_CALORIES_PER_CYCLE / BasePacuConfig.KG_ORE_EATEN_PER_CYCLE;
  public const float UNITS_OF_ALGAE_FROM_ONE_UNIT_OF_KELP = 2.66666675f;
  public static float KG_KELP_EATEN_PER_CYCLE = 20f;
  public static float KELP_TO_PRODUCT_EFFICIENCY = TUNING.CREATURES.CONVERSION_EFFICIENCY.NORMAL;
  private static float CALORIES_PER_KG_OF_KELP = PacuTuning.STANDARD_CALORIES_PER_CYCLE / BasePacuConfig.KG_KELP_EATEN_PER_CYCLE;
  private static float KELP_PLANTS_PER_PACU = BasePacuConfig.KG_KELP_EATEN_PER_CYCLE / 10f;
  private static float KELP_GROWTH_EATEN_PER_CYCLE = 0.2f * BasePacuConfig.KELP_PLANTS_PER_PACU;
  private static float CALORIES_PER_GROWTH_EATEN = PacuTuning.STANDARD_CALORIES_PER_CYCLE / (BasePacuConfig.KELP_GROWTH_EATEN_PER_CYCLE * 5f);
  private static float GROWTH_TO_PRODUCT_EFFICIENCY = BasePacuConfig.KELP_TO_PRODUCT_EFFICIENCY * 10f;
  private static float MIN_POOP_SIZE_IN_KG = 25f;

  public static GameObject CreatePrefab(
    string id,
    string base_trait_id,
    string name,
    string description,
    string anim_file,
    bool is_baby,
    string symbol_prefix,
    float warnLowTemp,
    float warnHighTemp,
    float lethalLowTemp,
    float lethalHighTemp)
  {
    string id1 = id;
    string name1 = name;
    string desc = description;
    double mass = (double) PacuTuning.MASS;
    EffectorValues tieR0 = TUNING.DECOR.BONUS.TIER0;
    KAnimFile anim = Assets.GetAnim((HashedString) anim_file);
    EffectorValues decor = tieR0;
    float num = (float) (((double) warnLowTemp + (double) warnHighTemp) / 2.0);
    EffectorValues noise = new EffectorValues();
    double defaultTemperature = (double) num;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity(id1, name1, desc, (float) mass, anim, "idle_loop", Grid.SceneLayer.Creatures, 1, 1, decor, noise, defaultTemperature: (float) defaultTemperature);
    KPrefabID component1 = placedEntity.GetComponent<KPrefabID>();
    component1.AddTag(GameTags.SwimmingCreature);
    component1.AddTag(GameTags.Creatures.Swimmer);
    Trait trait = Db.Get().CreateTrait(base_trait_id, name, name, (string) null, false, (ChoreGroup[]) null, true, true);
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.maxAttribute.Id, PacuTuning.STANDARD_STOMACH_SIZE, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.deltaAttribute.Id, (float) (-(double) PacuTuning.STANDARD_CALORIES_PER_CYCLE / 600.0), (string) UI.TOOLTIPS.BASE_VALUE));
    trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, 25f, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, 25f, name));
    EntityTemplates.CreateAndRegisterBaggedCreature(placedEntity, false, false, true);
    placedEntity.AddComponent<Movable>();
    EntityTemplates.ExtendEntityToBasicCreature(placedEntity, initialTraitID: base_trait_id, NavGridName: "SwimmerNavGrid", navType: NavType.Swim, onDeathDropID: "FishMeat", drownVulnerable: false, entombVulnerable: false, warningLowTemperature: warnLowTemp, warningHighTemperature: warnHighTemp, lethalLowTemperature: lethalLowTemp, lethalHighTemperature: lethalHighTemp);
    if (is_baby)
    {
      KBatchedAnimController component2 = placedEntity.GetComponent<KBatchedAnimController>();
      component2.animWidth = 0.5f;
      component2.animHeight = 0.5f;
    }
    ChoreTable.Builder chore_table = new ChoreTable.Builder().Add((StateMachine.BaseDef) new DeathStates.Def()).Add((StateMachine.BaseDef) new AnimInterruptStates.Def()).Add((StateMachine.BaseDef) new GrowUpStates.Def(), is_baby).Add((StateMachine.BaseDef) new TrappedStates.Def()).Add((StateMachine.BaseDef) new IncubatingStates.Def(), is_baby).Add((StateMachine.BaseDef) new BaggedStates.Def()).Add((StateMachine.BaseDef) new FallStates.Def()
    {
      getLandAnim = new Func<FallStates.Instance, string>(BasePacuConfig.GetLandAnim)
    }).Add((StateMachine.BaseDef) new DebugGoToStates.Def()).Add((StateMachine.BaseDef) new FlopStates.Def()).PushInterruptGroup().Add((StateMachine.BaseDef) new FixedCaptureStates.Def()).Add((StateMachine.BaseDef) new LayEggStates.Def(), !is_baby).Add((StateMachine.BaseDef) new EatStates.Def()).Add((StateMachine.BaseDef) new PlayAnimsStates.Def(GameTags.Creatures.Poop, false, "lay_egg_pre", (string) STRINGS.CREATURES.STATUSITEMS.EXPELLING_SOLID.NAME, (string) STRINGS.CREATURES.STATUSITEMS.EXPELLING_SOLID.TOOLTIP)).Add((StateMachine.BaseDef) new MoveToLureStates.Def()).Add((StateMachine.BaseDef) new CritterCondoStates.Def(), !is_baby).PopInterruptGroup().Add((StateMachine.BaseDef) new IdleStates.Def());
    CreatureFallMonitor.Def def1 = placedEntity.AddOrGetDef<CreatureFallMonitor.Def>();
    def1.canSwim = true;
    def1.checkHead = false;
    placedEntity.AddOrGetDef<FlopMonitor.Def>();
    placedEntity.AddOrGetDef<FishOvercrowdingMonitor.Def>();
    placedEntity.AddOrGet<Trappable>();
    placedEntity.AddOrGet<LoopingSounds>();
    EntityTemplates.AddCreatureBrain(placedEntity, chore_table, GameTags.Creatures.Species.PacuSpecies, symbol_prefix);
    CritterCondoInteractMontior.Def def2 = placedEntity.AddOrGetDef<CritterCondoInteractMontior.Def>();
    def2.requireCavity = false;
    def2.condoPrefabTag = (Tag) "UnderwaterCritterCondo";
    Tag tag = SimHashes.ToxicSand.CreateTag();
    List<Diet.Info> infoList = new List<Diet.Info>()
    {
      new Diet.Info(new HashSet<Tag>()
      {
        SimHashes.Algae.CreateTag()
      }, tag, BasePacuConfig.CALORIES_PER_KG_OF_ORE, TUNING.CREATURES.CONVERSION_EFFICIENCY.NORMAL)
    };
    if (DlcManager.GetActiveDLCIds().Contains("DLC4_ID"))
      infoList.AddRange((IEnumerable<Diet.Info>) new List<Diet.Info>()
      {
        new Diet.Info(new HashSet<Tag>()
        {
          (Tag) KelpConfig.ID
        }, tag, BasePacuConfig.CALORIES_PER_KG_OF_KELP, BasePacuConfig.KELP_TO_PRODUCT_EFFICIENCY),
        new Diet.Info(new HashSet<Tag>()
        {
          (Tag) "KelpPlant"
        }, tag, BasePacuConfig.CALORIES_PER_GROWTH_EATEN, BasePacuConfig.GROWTH_TO_PRODUCT_EFFICIENCY, food_type: Diet.Info.FoodType.EatPlantDirectly)
      });
    infoList.AddRange((IEnumerable<Diet.Info>) BasePacuConfig.SeedDiet(tag, PacuTuning.STANDARD_CALORIES_PER_CYCLE, TUNING.CREATURES.CONVERSION_EFFICIENCY.NORMAL));
    Diet diet = new Diet(infoList.ToArray());
    CreatureCalorieMonitor.Def def3 = placedEntity.AddOrGetDef<CreatureCalorieMonitor.Def>();
    def3.diet = diet;
    def3.minConsumedCaloriesBeforePooping = BasePacuConfig.CALORIES_PER_KG_OF_ORE * BasePacuConfig.MIN_POOP_SIZE_IN_KG;
    placedEntity.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
    placedEntity.AddOrGetDef<LureableMonitor.Def>().lures = new Tag[1]
    {
      GameTags.Creatures.FishTrapLure
    };
    if (!string.IsNullOrEmpty(symbol_prefix))
      placedEntity.AddOrGet<SymbolOverrideController>().ApplySymbolOverridesByAffix(Assets.GetAnim((HashedString) anim_file), symbol_prefix);
    placedEntity.AddOrGet<Pickupable>().sortOrder = TUNING.CREATURES.SORTING.CRITTER_ORDER["Pacu"];
    return placedEntity;
  }

  public static List<Diet.Info> SeedDiet(
    Tag poopTag,
    float caloriesPerSeed,
    float producedConversionRate)
  {
    List<Diet.Info> infoList = new List<Diet.Info>();
    foreach (GameObject gameObject in Assets.GetPrefabsWithComponent<PlantableSeed>())
    {
      GameObject prefab = Assets.GetPrefab(gameObject.GetComponent<PlantableSeed>().PlantID);
      KPrefabID component1 = gameObject.GetComponent<KPrefabID>();
      if (!prefab.HasTag(GameTags.DeprecatedContent) && !component1.HasTag((Tag) "KelpPlantSeed"))
      {
        SeedProducer component2 = prefab.GetComponent<SeedProducer>();
        if (((UnityEngine.Object) component2 == (UnityEngine.Object) null || component2.seedInfo.productionType == SeedProducer.ProductionType.Harvest || component2.seedInfo.productionType == SeedProducer.ProductionType.Crop ? 1 : (component2.seedInfo.productionType == SeedProducer.ProductionType.HarvestOnly ? 1 : 0)) != 0)
          infoList.Add(new Diet.Info(new HashSet<Tag>()
          {
            new Tag(component1.GetComponent<KPrefabID>().PrefabID())
          }, poopTag, caloriesPerSeed, producedConversionRate));
      }
    }
    return infoList;
  }

  private static string GetLandAnim(FallStates.Instance smi)
  {
    return smi.GetSMI<CreatureFallMonitor.Instance>().CanSwimAtCurrentLocation() ? "idle_loop" : "flop_loop";
  }
}
