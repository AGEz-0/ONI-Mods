﻿// Decompiled with JetBrains decompiler
// Type: ElementGrowthMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using KSerialization;
using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ElementGrowthMonitor : 
  GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>
{
  public Tag[] HungryTags = new Tag[1]
  {
    GameTags.Creatures.Hungry
  };
  public GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State halted;
  public ElementGrowthMonitor.GrowingState growing;
  public GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State fullyGrown;
  private static HashedString[] GROWTH_SYMBOL_NAMES = new HashedString[5]
  {
    (HashedString) "del_ginger1",
    (HashedString) "del_ginger2",
    (HashedString) "del_ginger3",
    (HashedString) "del_ginger4",
    (HashedString) "del_ginger5"
  };

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.growing;
    this.root.Enter((StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State.Callback) (smi => ElementGrowthMonitor.UpdateGrowth(smi, 0.0f))).Update(new System.Action<ElementGrowthMonitor.Instance, float>(ElementGrowthMonitor.UpdateGrowth), UpdateRate.SIM_1000ms).EventHandler(GameHashes.EatSolidComplete, (GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.GameEvent.Callback) ((smi, data) => smi.OnEatSolidComplete(data)));
    this.growing.DefaultState(this.growing.growing).Transition(this.fullyGrown, new StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.Transition.ConditionCallback(ElementGrowthMonitor.IsFullyGrown), UpdateRate.SIM_1000ms).TagTransition(this.HungryTags, this.halted);
    this.growing.growing.Transition(this.growing.stunted, GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.Not(new StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.Transition.ConditionCallback(ElementGrowthMonitor.IsConsumedInTemperatureRange)), UpdateRate.SIM_1000ms).ToggleStatusItem(Db.Get().CreatureStatusItems.ElementGrowthGrowing).Enter(new StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State.Callback(ElementGrowthMonitor.ApplyModifier)).Exit(new StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State.Callback(ElementGrowthMonitor.RemoveModifier));
    this.growing.stunted.Transition(this.growing.growing, new StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.Transition.ConditionCallback(ElementGrowthMonitor.IsConsumedInTemperatureRange), UpdateRate.SIM_1000ms).ToggleStatusItem(Db.Get().CreatureStatusItems.ElementGrowthStunted).Enter(new StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State.Callback(ElementGrowthMonitor.ApplyModifier)).Exit(new StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State.Callback(ElementGrowthMonitor.RemoveModifier));
    this.halted.TagTransition(this.HungryTags, (GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State) this.growing, true).ToggleStatusItem(Db.Get().CreatureStatusItems.ElementGrowthHalted);
    this.fullyGrown.ToggleStatusItem(Db.Get().CreatureStatusItems.ElementGrowthComplete).ToggleBehaviour(GameTags.Creatures.ScalesGrown, (StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.Transition.ConditionCallback) (smi => smi.HasTag(GameTags.Creatures.CanMolt))).Transition((GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State) this.growing, GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.Not(new StateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.Transition.ConditionCallback(ElementGrowthMonitor.IsFullyGrown)), UpdateRate.SIM_1000ms);
  }

  private static bool IsConsumedInTemperatureRange(ElementGrowthMonitor.Instance smi)
  {
    if ((double) smi.lastConsumedTemperature == 0.0)
      return true;
    return (double) smi.lastConsumedTemperature >= (double) smi.def.minTemperature && (double) smi.lastConsumedTemperature <= (double) smi.def.maxTemperature;
  }

  private static bool IsFullyGrown(ElementGrowthMonitor.Instance smi)
  {
    return (double) smi.elementGrowth.value >= (double) smi.elementGrowth.GetMax();
  }

  private static void ApplyModifier(ElementGrowthMonitor.Instance smi)
  {
    if (smi.IsInsideState((StateMachine.BaseState) smi.sm.growing.growing))
    {
      smi.elementGrowth.deltaAttribute.Add(smi.growingGrowthModifier);
    }
    else
    {
      if (!smi.IsInsideState((StateMachine.BaseState) smi.sm.growing.stunted))
        return;
      smi.elementGrowth.deltaAttribute.Add(smi.stuntedGrowthModifier);
    }
  }

  private static void RemoveModifier(ElementGrowthMonitor.Instance smi)
  {
    smi.elementGrowth.deltaAttribute.Remove(smi.growingGrowthModifier);
    smi.elementGrowth.deltaAttribute.Remove(smi.stuntedGrowthModifier);
  }

  private static void UpdateGrowth(ElementGrowthMonitor.Instance smi, float dt)
  {
    int num = (int) ((double) smi.def.levelCount * (double) smi.elementGrowth.value / 100.0);
    if (smi.currentGrowthLevel == num)
      return;
    KBatchedAnimController component = smi.GetComponent<KBatchedAnimController>();
    for (int index = 0; index < ElementGrowthMonitor.GROWTH_SYMBOL_NAMES.Length; ++index)
    {
      bool is_visible = index == num - 1;
      component.SetSymbolVisiblity((KAnimHashedString) ElementGrowthMonitor.GROWTH_SYMBOL_NAMES[index], is_visible);
    }
    smi.currentGrowthLevel = num;
  }

  public class Def : StateMachine.BaseDef, IGameObjectEffectDescriptor
  {
    public int levelCount;
    public float defaultGrowthRate;
    public Tag itemDroppedOnShear;
    public float dropMass;
    public float minTemperature;
    public float maxTemperature;

    public override void Configure(GameObject prefab)
    {
      prefab.GetComponent<Modifiers>().initialAmounts.Add(Db.Get().Amounts.ElementGrowth.Id);
    }

    public List<Descriptor> GetDescriptors(GameObject obj)
    {
      return new List<Descriptor>()
      {
        new Descriptor(UI.BUILDINGEFFECTS.SCALE_GROWTH_TEMP.Replace("{Item}", this.itemDroppedOnShear.ProperName()).Replace("{Amount}", GameUtil.GetFormattedMass(this.dropMass)).Replace("{Time}", GameUtil.GetFormattedCycles(1f / this.defaultGrowthRate)).Replace("{TempMin}", GameUtil.GetFormattedTemperature(this.minTemperature)).Replace("{TempMax}", GameUtil.GetFormattedTemperature(this.maxTemperature)), UI.BUILDINGEFFECTS.TOOLTIPS.SCALE_GROWTH_TEMP.Replace("{Item}", this.itemDroppedOnShear.ProperName()).Replace("{Amount}", GameUtil.GetFormattedMass(this.dropMass)).Replace("{Time}", GameUtil.GetFormattedCycles(1f / this.defaultGrowthRate)).Replace("{TempMin}", GameUtil.GetFormattedTemperature(this.minTemperature)).Replace("{TempMax}", GameUtil.GetFormattedTemperature(this.maxTemperature)))
      };
    }
  }

  public class GrowingState : 
    GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State
  {
    public GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State growing;
    public GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.State stunted;
  }

  public new class Instance : 
    GameStateMachine<ElementGrowthMonitor, ElementGrowthMonitor.Instance, IStateMachineTarget, ElementGrowthMonitor.Def>.GameInstance,
    IShearable
  {
    public AmountInstance elementGrowth;
    public AttributeModifier growingGrowthModifier;
    public AttributeModifier stuntedGrowthModifier;
    public int currentGrowthLevel = -1;
    [Serialize]
    public SimHashes lastConsumedElement;
    [Serialize]
    public float lastConsumedTemperature;

    public Instance(IStateMachineTarget master, ElementGrowthMonitor.Def def)
      : base(master, def)
    {
      this.elementGrowth = Db.Get().Amounts.ElementGrowth.Lookup(this.gameObject);
      this.elementGrowth.value = this.elementGrowth.GetMax();
      this.growingGrowthModifier = new AttributeModifier(this.elementGrowth.amount.deltaAttribute.Id, def.defaultGrowthRate * 100f, (string) CREATURES.MODIFIERS.ELEMENT_GROWTH_RATE.NAME);
      this.stuntedGrowthModifier = new AttributeModifier(this.elementGrowth.amount.deltaAttribute.Id, def.defaultGrowthRate * 20f, (string) CREATURES.MODIFIERS.ELEMENT_GROWTH_RATE.NAME);
    }

    public void OnEatSolidComplete(object data)
    {
      KPrefabID kprefabId = (KPrefabID) data;
      if ((UnityEngine.Object) kprefabId == (UnityEngine.Object) null)
        return;
      PrimaryElement component = kprefabId.GetComponent<PrimaryElement>();
      this.lastConsumedElement = component.ElementID;
      this.lastConsumedTemperature = component.Temperature;
    }

    public bool IsFullyGrown() => this.currentGrowthLevel == this.def.levelCount;

    public void Shear()
    {
      this.elementGrowth.value = 0.0f;
      ElementGrowthMonitor.UpdateGrowth(this, 0.0f);
    }

    public Tuple<Tag, float> GetItemDroppedOnShear()
    {
      return new Tuple<Tag, float>(this.def.itemDroppedOnShear, this.def.dropMass);
    }
  }
}
