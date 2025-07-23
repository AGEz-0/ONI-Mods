// Decompiled with JetBrains decompiler
// Type: BasePrehistoricPacuConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class BasePrehistoricPacuConfig
{
  private static float CALORIES_PER_KG_OF_PACU = PrehistoricPacuTuning.STANDARD_CALORIES_PER_CYCLE / 1f / PacuTuning.MASS;
  private static float CALORIES_PER_KG_OF_PACU_MEAT = PrehistoricPacuTuning.STANDARD_CALORIES_PER_CYCLE / 1f;

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
    int num1 = is_baby ? 1 : 2;
    int num2 = is_baby ? 1 : 2;
    EffectorValues tieR0 = TUNING.DECOR.BONUS.TIER0;
    KAnimFile anim = Assets.GetAnim((HashedString) anim_file);
    int width = num1;
    int height = num2;
    EffectorValues decor = tieR0;
    float num3 = (float) (((double) warnLowTemp + (double) warnHighTemp) / 2.0);
    EffectorValues noise = new EffectorValues();
    double defaultTemperature = (double) num3;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity(id1, name1, desc, 200f, anim, "idle_loop", Grid.SceneLayer.Creatures, width, height, decor, noise, defaultTemperature: (float) defaultTemperature);
    if (!is_baby)
    {
      KBoxCollider2D kboxCollider2D = placedEntity.AddOrGet<KBoxCollider2D>();
      kboxCollider2D.offset = (Vector2) new Vector2f(0.0f, kboxCollider2D.offset.y);
      placedEntity.GetComponent<KBatchedAnimController>().Offset = new Vector3(0.0f, 0.0f, 0.0f);
    }
    KPrefabID component = placedEntity.GetComponent<KPrefabID>();
    component.AddTag(GameTags.SwimmingCreature);
    component.AddTag(GameTags.Creatures.Swimmer);
    Trait trait = Db.Get().CreateTrait(base_trait_id, name, name, (string) null, false, (ChoreGroup[]) null, true, true);
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.maxAttribute.Id, PrehistoricPacuTuning.STANDARD_STOMACH_SIZE, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Calories.deltaAttribute.Id, (float) (-(double) PrehistoricPacuTuning.STANDARD_CALORIES_PER_CYCLE / 600.0), (string) UI.TOOLTIPS.BASE_VALUE));
    trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, 25f, name));
    trait.Add(new AttributeModifier(Db.Get().Amounts.Age.maxAttribute.Id, 100f, name));
    placedEntity.AddComponent<Movable>();
    EntityTemplates.ExtendEntityToBasicCreature(placedEntity, initialTraitID: base_trait_id, NavGridName: is_baby ? "SwimmerNavGrid" : "SwimmerGrid2x2", navType: NavType.Swim, onDeathDropID: "PrehistoricPacuFillet", onDeathDropCount: 12f, drownVulnerable: false, entombVulnerable: false, warningLowTemperature: warnLowTemp, warningHighTemperature: warnHighTemp, lethalLowTemperature: lethalLowTemp, lethalHighTemperature: lethalHighTemp);
    ChoreTable.Builder chore_table = new ChoreTable.Builder().Add((StateMachine.BaseDef) new DeathStates.Def()).Add((StateMachine.BaseDef) new AnimInterruptStates.Def()).Add((StateMachine.BaseDef) new GrowUpStates.Def(), is_baby).Add((StateMachine.BaseDef) new TrappedStates.Def()).Add((StateMachine.BaseDef) new IncubatingStates.Def(), is_baby).Add((StateMachine.BaseDef) new BaggedStates.Def()).Add((StateMachine.BaseDef) new FallStates.Def()
    {
      getLandAnim = new Func<FallStates.Instance, string>(BasePrehistoricPacuConfig.GetLandAnim)
    }).Add((StateMachine.BaseDef) new DebugGoToStates.Def()).Add((StateMachine.BaseDef) new FlopStates.Def()).PushInterruptGroup().Add((StateMachine.BaseDef) new FixedCaptureStates.Def()).Add((StateMachine.BaseDef) new LayEggStates.Def(), !is_baby).Add((StateMachine.BaseDef) new EatStates.Def()).Add((StateMachine.BaseDef) new PlayAnimsStates.Def(GameTags.Creatures.Poop, false, "lay_egg_pre", (string) STRINGS.CREATURES.STATUSITEMS.EXPELLING_SOLID.NAME, (string) STRINGS.CREATURES.STATUSITEMS.EXPELLING_SOLID.TOOLTIP)).Add((StateMachine.BaseDef) new MoveToLureStates.Def()).Add((StateMachine.BaseDef) new CritterCondoStates.Def(), !is_baby).PopInterruptGroup().Add((StateMachine.BaseDef) new IdleStates.Def());
    CreatureFallMonitor.Def def1 = placedEntity.AddOrGetDef<CreatureFallMonitor.Def>();
    def1.canSwim = true;
    def1.checkHead = true;
    placedEntity.AddOrGetDef<FlopMonitor.Def>();
    placedEntity.AddOrGetDef<FishOvercrowdingMonitor.Def>();
    placedEntity.AddOrGet<Trappable>();
    placedEntity.AddOrGet<LoopingSounds>();
    EntityTemplates.AddCreatureBrain(placedEntity, chore_table, GameTags.Creatures.Species.PrehistoricPacuSpecies, symbol_prefix);
    CritterCondoInteractMontior.Def def2 = placedEntity.AddOrGetDef<CritterCondoInteractMontior.Def>();
    def2.requireCavity = false;
    def2.condoPrefabTag = (Tag) "UnderwaterCritterCondo";
    Diet diet = new Diet(new List<Diet.Info>()
    {
      new Diet.Info(new HashSet<Tag>()
      {
        (Tag) "Pacu",
        (Tag) "PacuCleaner",
        (Tag) "PacuTropical"
      }, PrehistoricPacuTuning.POOP_ELEMENT, BasePrehistoricPacuConfig.CALORIES_PER_KG_OF_PACU, 60f / PacuTuning.MASS, food_type: Diet.Info.FoodType.EatPrey),
      new Diet.Info(new HashSet<Tag>() { (Tag) "FishMeat" }, PrehistoricPacuTuning.POOP_ELEMENT, BasePrehistoricPacuConfig.CALORIES_PER_KG_OF_PACU_MEAT, 60f)
    }.ToArray());
    CreatureCalorieMonitor.Def def3 = placedEntity.AddOrGetDef<CreatureCalorieMonitor.Def>();
    def3.diet = diet;
    def3.minConsumedCaloriesBeforePooping = BasePrehistoricPacuConfig.CALORIES_PER_KG_OF_PACU * 60f;
    placedEntity.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
    if (!string.IsNullOrEmpty(symbol_prefix))
      placedEntity.AddOrGet<SymbolOverrideController>().ApplySymbolOverridesByAffix(Assets.GetAnim((HashedString) anim_file), symbol_prefix);
    placedEntity.AddOrGet<Pickupable>().sortOrder = TUNING.CREATURES.SORTING.CRITTER_ORDER["PrehistoricPacu"];
    return placedEntity;
  }

  private static string GetLandAnim(FallStates.Instance smi)
  {
    return smi.GetSMI<CreatureFallMonitor.Instance>().CanSwimAtCurrentLocation() ? "idle_loop" : "flop_loop";
  }
}
