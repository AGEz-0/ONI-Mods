// Decompiled with JetBrains decompiler
// Type: BaseStegoConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class BaseStegoConfig
{
  public static GameObject BaseStego(
    string id,
    string name,
    string desc,
    string anim_file,
    string traitId,
    bool is_baby,
    string symbolOverridePrefix = null)
  {
    string id1 = id;
    string name1 = name;
    string desc1 = desc;
    EffectorValues tieR0 = TUNING.DECOR.BONUS.TIER0;
    KAnimFile anim = Assets.GetAnim((HashedString) anim_file);
    EffectorValues decor = tieR0;
    EffectorValues noise = new EffectorValues();
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity(id1, name1, desc1, 400f, anim, "idle_loop", Grid.SceneLayer.Creatures, 2, 2, decor, noise);
    KBoxCollider2D kboxCollider2D = placedEntity.AddOrGet<KBoxCollider2D>();
    kboxCollider2D.offset = (Vector2) new Vector2f(0.0f, kboxCollider2D.offset.y);
    placedEntity.GetComponent<KBatchedAnimController>().Offset = new Vector3(0.0f, 0.0f, 0.0f);
    string NavGridName = "WalkerNavGrid2x2";
    if (is_baby)
      NavGridName = "WalkerBabyNavGrid";
    EntityTemplates.ExtendEntityToBasicCreature(placedEntity, FactionManager.FactionID.Pest, traitId, NavGridName, moveSpeed: 1.5f, onDeathDropID: "DinosaurMeat", onDeathDropCount: 12f, entombVulnerable: false, warningLowTemperature: 293.15f, warningHighTemperature: 343.15f, lethalLowTemperature: 173.15f, lethalHighTemperature: 373.15f);
    if (symbolOverridePrefix != null)
      placedEntity.AddOrGet<SymbolOverrideController>().ApplySymbolOverridesByAffix(Assets.GetAnim((HashedString) anim_file), symbolOverridePrefix);
    placedEntity.AddOrGet<Pickupable>().sortOrder = TUNING.CREATURES.SORTING.CRITTER_ORDER["Stego"];
    placedEntity.AddOrGet<Trappable>();
    placedEntity.AddOrGetDef<CreatureFallMonitor.Def>();
    placedEntity.AddOrGetDef<ThreatMonitor.Def>().fleethresholdState = Health.HealthState.Dead;
    placedEntity.AddWeapon(1f, 1f);
    KPrefabID component = placedEntity.GetComponent<KPrefabID>();
    component.AddTag(GameTags.Creatures.Walker);
    component.prefabInitFn += (KPrefabID.PrefabFn) (inst => inst.GetAttributes().Add(Db.Get().Attributes.MaxUnderwaterTravelCost));
    if (!is_baby)
    {
      StompMonitor.Def def = placedEntity.AddOrGetDef<StompMonitor.Def>();
      def.Cooldown = 60f;
      def.radius = 10;
    }
    EntityTemplates.CreateAndRegisterBaggedCreature(placedEntity, true, true);
    ChoreTable.Builder builder = new ChoreTable.Builder().Add((StateMachine.BaseDef) new DeathStates.Def()).Add((StateMachine.BaseDef) new AnimInterruptStates.Def()).Add((StateMachine.BaseDef) new GrowUpStates.Def(), is_baby).Add((StateMachine.BaseDef) new TrappedStates.Def()).Add((StateMachine.BaseDef) new IncubatingStates.Def(), is_baby).Add((StateMachine.BaseDef) new BaggedStates.Def()).Add((StateMachine.BaseDef) new FallStates.Def()).Add((StateMachine.BaseDef) new StunnedStates.Def()).Add((StateMachine.BaseDef) new DrowningStates.Def()).Add((StateMachine.BaseDef) new DebugGoToStates.Def()).Add((StateMachine.BaseDef) new FleeStates.Def()).Add((StateMachine.BaseDef) new AttackStates.Def()).PushInterruptGroup().Add((StateMachine.BaseDef) new CreatureSleepStates.Def(), is_baby).Add((StateMachine.BaseDef) new FixedCaptureStates.Def());
    RanchedStates.Def def1 = new RanchedStates.Def();
    def1.WaitCellOffset = 2;
    int num = !is_baby ? 1 : 0;
    ChoreTable.Builder chore_table = builder.Add((StateMachine.BaseDef) def1, num != 0).Add((StateMachine.BaseDef) new LayEggStates.Def(), !is_baby).Add((StateMachine.BaseDef) new StompStates.Def(), !is_baby).Add((StateMachine.BaseDef) new EatStates.Def()).Add((StateMachine.BaseDef) new DrinkMilkStates.Def()
    {
      shouldBeBehindMilkTank = false,
      drinkCellOffsetGetFn = (is_baby ? new DrinkMilkStates.Def.DrinkCellOffsetGetFn(DrinkMilkStates.Def.DrinkCellOffsetGet_CritterOneByOne) : new DrinkMilkStates.Def.DrinkCellOffsetGetFn(DrinkMilkStates.Def.DrinkCellOffsetGet_TwoByTwo))
    }).Add((StateMachine.BaseDef) new PlayAnimsStates.Def(GameTags.Creatures.Poop, false, "poop", (string) STRINGS.CREATURES.STATUSITEMS.EXPELLING_SOLID.NAME, (string) STRINGS.CREATURES.STATUSITEMS.EXPELLING_SOLID.TOOLTIP)).Add((StateMachine.BaseDef) new CallAdultStates.Def(), is_baby).Add((StateMachine.BaseDef) new CritterCondoStates.Def(), !is_baby).PopInterruptGroup().Add((StateMachine.BaseDef) new IdleStates.Def());
    EntityTemplates.AddCreatureBrain(placedEntity, chore_table, GameTags.Creatures.Species.StegoSpecies, symbolOverridePrefix);
    return placedEntity;
  }

  public static List<Diet.Info> StandardDiets()
  {
    List<Diet.Info> infoList = new List<Diet.Info>();
    infoList.Add(new Diet.Info(new HashSet<Tag>()
    {
      (Tag) VineFruitConfig.ID
    }, StegoTuning.POOP_ELEMENT, StegoTuning.CALORIES_PER_KG_OF_ORE, StegoTuning.PEAT_PRODUCED_PER_CYCLE / StegoTuning.VINE_FOOD_PER_CYCLE));
    float num1 = TUNING.FOOD.FOOD_TYPES.PRICKLEFRUIT.CaloriesPerUnit / TUNING.FOOD.FOOD_TYPES.VINEFRUIT.CaloriesPerUnit;
    infoList.Add(new Diet.Info(new HashSet<Tag>()
    {
      (Tag) PrickleFruitConfig.ID
    }, StegoTuning.POOP_ELEMENT, StegoTuning.CALORIES_PER_KG_OF_ORE * num1, StegoTuning.PEAT_PRODUCED_PER_CYCLE / (StegoTuning.VINE_FOOD_PER_CYCLE / num1)));
    if (DlcManager.IsExpansion1Active())
    {
      float num2 = TUNING.FOOD.FOOD_TYPES.SWAMPFRUIT.CaloriesPerUnit / TUNING.FOOD.FOOD_TYPES.VINEFRUIT.CaloriesPerUnit;
      float num3 = 1.5f;
      infoList.Add(new Diet.Info(new HashSet<Tag>()
      {
        (Tag) SwampFruitConfig.ID
      }, StegoTuning.POOP_ELEMENT, StegoTuning.CALORIES_PER_KG_OF_ORE * num2, StegoTuning.PEAT_PRODUCED_PER_CYCLE / (StegoTuning.VINE_FOOD_PER_CYCLE / num2) * num3));
    }
    return infoList;
  }

  public static GameObject SetupDiet(
    GameObject prefab,
    List<Diet.Info> dietInfos,
    float referenceCaloriesPerKg,
    float minPoopSizeInKg)
  {
    Diet diet = new Diet(dietInfos.ToArray());
    CreatureCalorieMonitor.Def def = prefab.AddOrGetDef<CreatureCalorieMonitor.Def>();
    def.diet = diet;
    def.minConsumedCaloriesBeforePooping = referenceCaloriesPerKg * minPoopSizeInKg;
    prefab.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
    return prefab;
  }
}
