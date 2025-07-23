// Decompiled with JetBrains decompiler
// Type: BaseLightBugConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public static class BaseLightBugConfig
{
  public static GameObject BaseLightBug(
    string id,
    string name,
    string desc,
    string anim_file,
    string traitId,
    Color lightColor,
    EffectorValues decor,
    bool is_baby,
    string symbolOverridePrefix = null)
  {
    string id1 = id;
    string name1 = name;
    string desc1 = desc;
    EffectorValues effectorValues = decor;
    KAnimFile anim = Assets.GetAnim((HashedString) anim_file);
    EffectorValues decor1 = effectorValues;
    EffectorValues noise = new EffectorValues();
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity(id1, name1, desc1, 5f, anim, "idle_loop", Grid.SceneLayer.Creatures, 1, 1, decor1, noise);
    EntityTemplates.ExtendEntityToBasicCreature(placedEntity, initialTraitID: traitId, NavGridName: "FlyerNavGrid1x1", navType: NavType.Hover, onDeathDropCount: 0.0f, warningHighTemperature: 313.15f, lethalLowTemperature: 173.15f, lethalHighTemperature: 373.15f);
    if (symbolOverridePrefix != null)
      placedEntity.AddOrGet<SymbolOverrideController>().ApplySymbolOverridesByAffix(Assets.GetAnim((HashedString) anim_file), symbolOverridePrefix);
    placedEntity.AddOrGet<Pickupable>().sortOrder = CREATURES.SORTING.CRITTER_ORDER["LightBug"];
    KPrefabID component1 = placedEntity.GetComponent<KPrefabID>();
    component1.AddTag(GameTags.Creatures.Flyer);
    component1.prefabInitFn += (KPrefabID.PrefabFn) (inst => inst.GetAttributes().Add(Db.Get().Attributes.MaxUnderwaterTravelCost));
    placedEntity.AddOrGet<LoopingSounds>();
    placedEntity.AddOrGet<Trappable>();
    placedEntity.AddOrGetDef<LureableMonitor.Def>().lures = new Tag[2]
    {
      GameTags.Phosphorite,
      GameTags.Creatures.FlyersLure
    };
    placedEntity.AddOrGetDef<ThreatMonitor.Def>();
    placedEntity.AddOrGetDef<SubmergedMonitor.Def>();
    EntityTemplates.CreateAndRegisterBaggedCreature(placedEntity, true, true);
    if (DlcManager.FeatureRadiationEnabled())
    {
      RadiationEmitter radiationEmitter = placedEntity.AddOrGet<RadiationEmitter>();
      radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
      radiationEmitter.radiusProportionalToRads = false;
      radiationEmitter.emitRadiusX = (short) 6;
      radiationEmitter.emitRadiusY = radiationEmitter.emitRadiusX;
      radiationEmitter.emitRads = 60f;
      radiationEmitter.emissionOffset = new Vector3(0.0f, 0.0f, 0.0f);
      component1.prefabSpawnFn += (KPrefabID.PrefabFn) (inst => inst.GetComponent<RadiationEmitter>().SetEmitting(true));
    }
    if (is_baby)
    {
      KBatchedAnimController component2 = placedEntity.GetComponent<KBatchedAnimController>();
      component2.animWidth = 0.5f;
      component2.animHeight = 0.5f;
    }
    if (lightColor != Color.black)
    {
      Light2D light2D = placedEntity.AddOrGet<Light2D>();
      light2D.Color = lightColor;
      light2D.overlayColour = LIGHT2D.LIGHTBUG_OVERLAYCOLOR;
      light2D.Range = 5f;
      light2D.Angle = 0.0f;
      light2D.Direction = LIGHT2D.LIGHTBUG_DIRECTION;
      light2D.Offset = LIGHT2D.LIGHTBUG_OFFSET;
      light2D.shape = LightShape.Circle;
      light2D.drawOverlay = true;
      light2D.Lux = 1800;
      placedEntity.AddOrGet<LightSymbolTracker>().targetSymbol = (HashedString) "snapTo_light_locator";
      placedEntity.AddOrGetDef<CreatureLightToggleController.Def>();
    }
    ChoreTable.Builder builder = new ChoreTable.Builder().Add((StateMachine.BaseDef) new DeathStates.Def()).Add((StateMachine.BaseDef) new AnimInterruptStates.Def()).Add((StateMachine.BaseDef) new GrowUpStates.Def(), is_baby).Add((StateMachine.BaseDef) new IncubatingStates.Def(), is_baby).Add((StateMachine.BaseDef) new TrappedStates.Def()).Add((StateMachine.BaseDef) new BaggedStates.Def()).Add((StateMachine.BaseDef) new StunnedStates.Def()).Add((StateMachine.BaseDef) new DebugGoToStates.Def()).Add((StateMachine.BaseDef) new DrowningStates.Def()).PushInterruptGroup().Add((StateMachine.BaseDef) new CreatureSleepStates.Def()).Add((StateMachine.BaseDef) new FixedCaptureStates.Def()).Add((StateMachine.BaseDef) new RanchedStates.Def(), !is_baby).Add((StateMachine.BaseDef) new LayEggStates.Def(), !is_baby).Add((StateMachine.BaseDef) new EatStates.Def()).Add((StateMachine.BaseDef) new DrinkMilkStates.Def()
    {
      shouldBeBehindMilkTank = true
    }).Add((StateMachine.BaseDef) new MoveToLureStates.Def()).Add((StateMachine.BaseDef) new CallAdultStates.Def(), is_baby);
    CritterCondoStates.Def def = new CritterCondoStates.Def();
    def.working_anim = "cc_working_shinebug";
    int num = !is_baby ? 1 : 0;
    ChoreTable.Builder chore_table = builder.Add((StateMachine.BaseDef) def, num != 0).PopInterruptGroup().Add((StateMachine.BaseDef) new IdleStates.Def());
    EntityTemplates.AddCreatureBrain(placedEntity, chore_table, GameTags.Creatures.Species.LightBugSpecies, symbolOverridePrefix);
    placedEntity.AddOrGetDef<CritterCondoInteractMontior.Def>().condoPrefabTag = (Tag) "AirBorneCritterCondo";
    return placedEntity;
  }

  public static GameObject SetupDiet(
    GameObject prefab,
    HashSet<Tag> consumed_tags,
    Tag producedTag,
    float caloriesPerKg)
  {
    Diet diet = new Diet(new Diet.Info[1]
    {
      new Diet.Info(consumed_tags, producedTag, caloriesPerKg)
    });
    prefab.AddOrGetDef<CreatureCalorieMonitor.Def>().diet = diet;
    prefab.AddOrGetDef<SolidConsumerMonitor.Def>().diet = diet;
    return prefab;
  }

  public static void SetupLoopingSounds(GameObject inst)
  {
    inst.GetComponent<LoopingSounds>().StartSound(GlobalAssets.GetSound("ShineBug_wings_LP"));
  }
}
