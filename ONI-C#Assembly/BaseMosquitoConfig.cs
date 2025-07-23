﻿// Decompiled with JetBrains decompiler
// Type: BaseMosquitoConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using TUNING;
using UnityEngine;

#nullable disable
public static class BaseMosquitoConfig
{
  public static GameObject BaseMosquito(
    string id,
    string name,
    string desc,
    string anim_file,
    string traitId,
    string symbol_override_prefix,
    bool isBaby,
    float warningLowTemperature,
    float warningHighTemperature,
    float lethalLowTemperature,
    float lethalHighTemperature,
    string poke_anim_pre,
    string poke_anim_loop,
    string poke_anim_pst,
    string goingToPokeStatusItemSTRAddress,
    string pokingStatusItemSTRAddress)
  {
    string id1 = id;
    string name1 = name;
    string desc1 = desc;
    EffectorValues tieR0 = DECOR.PENALTY.TIER0;
    KAnimFile anim = Assets.GetAnim((HashedString) anim_file);
    EffectorValues decor = tieR0;
    EffectorValues noise = new EffectorValues();
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity(id1, name1, desc1, 5f, anim, "idle_loop", Grid.SceneLayer.Creatures, 1, 1, decor, noise);
    EntityTemplates.ExtendEntityToBasicCreature(placedEntity, initialTraitID: traitId, NavGridName: isBaby ? "SwimmerNavGrid" : "FlyerNavGrid1x1", navType: isBaby ? NavType.Swim : NavType.Hover, onDeathDropID: (string) null, onDeathDropCount: 0.0f, drownVulnerable: !isBaby, warningLowTemperature: warningLowTemperature, warningHighTemperature: warningHighTemperature, lethalLowTemperature: lethalLowTemperature, lethalHighTemperature: lethalHighTemperature);
    if (!string.IsNullOrEmpty(symbol_override_prefix))
      placedEntity.AddOrGet<SymbolOverrideController>().ApplySymbolOverridesByAffix(Assets.GetAnim((HashedString) anim_file), symbol_override_prefix);
    placedEntity.AddOrGet<Pickupable>().sortOrder = CREATURES.SORTING.CRITTER_ORDER["Mosquito"];
    KPrefabID component = placedEntity.GetComponent<KPrefabID>();
    placedEntity.AddOrGet<LoopingSounds>();
    placedEntity.AddOrGet<Trappable>();
    LureableMonitor.Def def1 = placedEntity.AddOrGetDef<LureableMonitor.Def>();
    Tag[] tagArray;
    if (!isBaby)
      tagArray = new Tag[1]{ GameTags.Creatures.FlyersLure };
    else
      tagArray = new Tag[1]
      {
        GameTags.Creatures.FishTrapLure
      };
    def1.lures = tagArray;
    placedEntity.AddOrGetDef<ThreatMonitor.Def>();
    if (!isBaby)
    {
      component.AddTag(GameTags.Creatures.Flyer);
      placedEntity.AddOrGetDef<SubmergedMonitor.Def>();
      placedEntity.AddOrGet<PokeMonitor>();
      placedEntity.AddOrGetDef<OvercrowdingMonitor.Def>().spaceRequiredPerCreature = CREATURES.SPACE_REQUIREMENTS.TIER1;
      component.prefabInitFn += (KPrefabID.PrefabFn) (inst => inst.GetAttributes().Add(Db.Get().Attributes.MaxUnderwaterTravelCost));
    }
    else
    {
      component.AddTag(GameTags.SwimmingCreature);
      component.AddTag(GameTags.Creatures.Swimmer);
      placedEntity.AddComponent<Movable>();
    }
    EntityTemplates.CreateAndRegisterBaggedCreature(placedEntity, !isBaby, !isBaby, isBaby);
    ChoreTable.Builder builder1 = new ChoreTable.Builder().Add((StateMachine.BaseDef) new DeathStates.Def()).Add((StateMachine.BaseDef) new AnimInterruptStates.Def()).Add((StateMachine.BaseDef) new GrowUpStates.Def(), isBaby).Add((StateMachine.BaseDef) new TrappedStates.Def()).Add((StateMachine.BaseDef) new IncubatingStates.Def(), isBaby).Add((StateMachine.BaseDef) new BaggedStates.Def());
    FallStates.Def def2 = new FallStates.Def();
    def2.getLandAnim = new Func<FallStates.Instance, string>(BaseMosquitoConfig.GetLandAnim);
    int num1 = isBaby ? 1 : 0;
    ChoreTable.Builder builder2 = builder1.Add((StateMachine.BaseDef) def2, num1 != 0).Add((StateMachine.BaseDef) new StunnedStates.Def()).Add((StateMachine.BaseDef) new DebugGoToStates.Def()).Add((StateMachine.BaseDef) new FlopStates.Def(), isBaby).Add((StateMachine.BaseDef) new DrowningStates.Def(), !isBaby).PushInterruptGroup().Add((StateMachine.BaseDef) new CreatureSleepStates.Def()).Add((StateMachine.BaseDef) new FixedCaptureStates.Def()).Add((StateMachine.BaseDef) new UpTopPoopStates.Def()).Add((StateMachine.BaseDef) new LayEggStates.Def(), !isBaby);
    AliveEntityPoker.Def def3 = new AliveEntityPoker.Def();
    def3.PokeAnim_Pre = poke_anim_pre;
    def3.PokeAnim_Loop = poke_anim_loop;
    def3.PokeAnim_Pst = poke_anim_pst;
    def3.statusItemSTR_goingToPoke = goingToPokeStatusItemSTRAddress;
    def3.statusItemSTR_poking = pokingStatusItemSTRAddress;
    int num2 = !isBaby ? 1 : 0;
    ChoreTable.Builder chore_table = builder2.Add((StateMachine.BaseDef) def3, num2 != 0).Add((StateMachine.BaseDef) new MoveToLureStates.Def()).PopInterruptGroup().Add((StateMachine.BaseDef) new IdleStates.Def());
    CreatureFallMonitor.Def def4 = placedEntity.AddOrGetDef<CreatureFallMonitor.Def>();
    def4.canSwim = isBaby;
    def4.checkHead = !isBaby;
    placedEntity.AddOrGetDef<FixedCapturableMonitor.Def>();
    if (isBaby)
    {
      placedEntity.AddOrGetDef<FlopMonitor.Def>();
      placedEntity.AddOrGetDef<FishOvercrowdingMonitor.Def>();
      placedEntity.AddOrGetDef<AquaticCreatureSuffocationMonitor.Def>();
    }
    placedEntity.AddOrGet<LoopingSounds>();
    EntityTemplates.AddCreatureBrain(placedEntity, chore_table, GameTags.Creatures.Species.MosquitoSpecies, symbol_override_prefix);
    return placedEntity;
  }

  private static string GetLandAnim(FallStates.Instance smi)
  {
    return smi.GetSMI<CreatureFallMonitor.Instance>().CanSwimAtCurrentLocation() ? "idle_loop" : "flop_loop";
  }
}
