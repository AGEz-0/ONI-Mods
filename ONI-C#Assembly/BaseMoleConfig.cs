// Decompiled with JetBrains decompiler
// Type: BaseMoleConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public static class BaseMoleConfig
{
  private static readonly string[] SolidIdleAnims = new string[4]
  {
    "idle1",
    "idle2",
    "idle3",
    "idle4"
  };

  public static GameObject BaseMole(
    string id,
    string name,
    string desc,
    string traitId,
    string anim_file,
    bool is_baby,
    float warningLowTemperature,
    float warningHighTemperature,
    float lethalLowTemperature,
    float lethalHighTemperature,
    string symbolOverridePrefix = null,
    int on_death_drop_count = 10)
  {
    string id1 = id;
    string name1 = name;
    string desc1 = desc;
    EffectorValues none = TUNING.BUILDINGS.DECOR.NONE;
    KAnimFile anim = Assets.GetAnim((HashedString) anim_file);
    EffectorValues decor = none;
    EffectorValues noise = new EffectorValues();
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity(id1, name1, desc1, 25f, anim, "idle_loop", Grid.SceneLayer.Creatures, 1, 1, decor, noise);
    EntityTemplates.ExtendEntityToBasicCreature(placedEntity, FactionManager.FactionID.Pest, traitId, "DiggerNavGrid", onDeathDropCount: (float) on_death_drop_count, entombVulnerable: false, warningLowTemperature: warningLowTemperature, warningHighTemperature: warningHighTemperature, lethalLowTemperature: lethalLowTemperature, lethalHighTemperature: lethalHighTemperature);
    if (symbolOverridePrefix != null)
      placedEntity.AddOrGet<SymbolOverrideController>().ApplySymbolOverridesByAffix(Assets.GetAnim((HashedString) anim_file), symbolOverridePrefix);
    placedEntity.AddOrGet<Pickupable>().sortOrder = TUNING.CREATURES.SORTING.CRITTER_ORDER["Mole"];
    placedEntity.AddOrGetDef<CreatureFallMonitor.Def>();
    placedEntity.AddOrGet<Trappable>();
    placedEntity.AddOrGetDef<DiggerMonitor.Def>().depthToDig = MoleTuning.DEPTH_TO_HIDE;
    EntityTemplates.CreateAndRegisterBaggedCreature(placedEntity, true, true);
    placedEntity.GetComponent<KPrefabID>().AddTag(GameTags.Creatures.Walker);
    ChoreTable.Builder chore_table = new ChoreTable.Builder().Add((StateMachine.BaseDef) new DeathStates.Def()).Add((StateMachine.BaseDef) new AnimInterruptStates.Def()).Add((StateMachine.BaseDef) new FallStates.Def()).Add((StateMachine.BaseDef) new StunnedStates.Def()).Add((StateMachine.BaseDef) new DrowningStates.Def()).Add((StateMachine.BaseDef) new DiggerStates.Def()).Add((StateMachine.BaseDef) new GrowUpStates.Def(), is_baby).Add((StateMachine.BaseDef) new TrappedStates.Def()).Add((StateMachine.BaseDef) new IncubatingStates.Def(), is_baby).Add((StateMachine.BaseDef) new BaggedStates.Def()).Add((StateMachine.BaseDef) new DebugGoToStates.Def()).Add((StateMachine.BaseDef) new FleeStates.Def()).Add((StateMachine.BaseDef) new AttackStates.Def(), !is_baby).PushInterruptGroup().Add((StateMachine.BaseDef) new FixedCaptureStates.Def()).Add((StateMachine.BaseDef) new RanchedStates.Def(), !is_baby).Add((StateMachine.BaseDef) new LayEggStates.Def(), !is_baby).Add((StateMachine.BaseDef) new CreatureSleepStates.Def()).Add((StateMachine.BaseDef) new EatStates.Def()).Add((StateMachine.BaseDef) new DrinkMilkStates.Def()
    {
      shouldBeBehindMilkTank = is_baby
    }).Add((StateMachine.BaseDef) new NestingPoopState.Def(is_baby ? Tag.Invalid : SimHashes.Regolith.CreateTag())).Add((StateMachine.BaseDef) new PlayAnimsStates.Def(GameTags.Creatures.Poop, false, "poop", (string) STRINGS.CREATURES.STATUSITEMS.EXPELLING_SOLID.NAME, (string) STRINGS.CREATURES.STATUSITEMS.EXPELLING_SOLID.TOOLTIP)).Add((StateMachine.BaseDef) new CritterCondoStates.Def(), !is_baby).PopInterruptGroup().Add((StateMachine.BaseDef) new IdleStates.Def()
    {
      customIdleAnim = new IdleStates.Def.IdleAnimCallback(BaseMoleConfig.CustomIdleAnim)
    });
    EntityTemplates.AddCreatureBrain(placedEntity, chore_table, GameTags.Creatures.Species.MoleSpecies, symbolOverridePrefix);
    return placedEntity;
  }

  public static List<Diet.Info> SimpleOreDiet(
    List<Tag> elementTags,
    float caloriesPerKg,
    float producedConversionRate)
  {
    List<Diet.Info> infoList = new List<Diet.Info>();
    foreach (Tag elementTag in elementTags)
      infoList.Add(new Diet.Info(new HashSet<Tag>()
      {
        elementTag
      }, elementTag, caloriesPerKg, producedConversionRate, produce_solid_tile: true));
    return infoList;
  }

  private static HashedString CustomIdleAnim(IdleStates.Instance smi, ref HashedString pre_anim)
  {
    if (smi.gameObject.GetComponent<Navigator>().CurrentNavType == NavType.Solid)
    {
      int index = Random.Range(0, BaseMoleConfig.SolidIdleAnims.Length);
      return (HashedString) BaseMoleConfig.SolidIdleAnims[index];
    }
    return smi.gameObject.GetDef<BabyMonitor.Def>() != null && Random.Range(0, 100) >= 90 ? (HashedString) "drill_fail" : (HashedString) "idle_loop";
  }
}
