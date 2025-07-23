// Decompiled with JetBrains decompiler
// Type: WildnessMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using UnityEngine;

#nullable disable
public class WildnessMonitor : 
  GameStateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>
{
  public GameStateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.State wild;
  public GameStateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.State tame;
  private static readonly KAnimHashedString[] DOMESTICATION_SYMBOLS = new KAnimHashedString[2]
  {
    (KAnimHashedString) "tag",
    (KAnimHashedString) "snapto_tag"
  };

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.tame;
    this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
    this.wild.Enter(new StateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.State.Callback(WildnessMonitor.RefreshAmounts)).Enter(new StateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.State.Callback(WildnessMonitor.HideDomesticationSymbol)).Transition(this.tame, (StateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.Transition.ConditionCallback) (smi => !WildnessMonitor.IsWild(smi)), UpdateRate.SIM_1000ms).ToggleEffect((Func<WildnessMonitor.Instance, Effect>) (smi => smi.def.wildEffect)).ToggleTag(GameTags.Creatures.Wild);
    this.tame.Enter(new StateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.State.Callback(WildnessMonitor.RefreshAmounts)).Enter(new StateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.State.Callback(WildnessMonitor.ShowDomesticationSymbol)).Transition(this.wild, new StateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.Transition.ConditionCallback(WildnessMonitor.IsWild), UpdateRate.SIM_1000ms).ToggleEffect((Func<WildnessMonitor.Instance, Effect>) (smi => smi.def.tameEffect)).Enter((StateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.State.Callback) (smi => SaveGame.Instance.ColonyAchievementTracker.LogCritterTamed(smi.PrefabID())));
  }

  private static void HideDomesticationSymbol(WildnessMonitor.Instance smi)
  {
    foreach (KAnimHashedString symbol in WildnessMonitor.DOMESTICATION_SYMBOLS)
      smi.GetComponent<KBatchedAnimController>().SetSymbolVisiblity(symbol, false);
  }

  private static void ShowDomesticationSymbol(WildnessMonitor.Instance smi)
  {
    foreach (KAnimHashedString symbol in WildnessMonitor.DOMESTICATION_SYMBOLS)
      smi.GetComponent<KBatchedAnimController>().SetSymbolVisiblity(symbol, true);
  }

  private static bool IsWild(WildnessMonitor.Instance smi) => (double) smi.wildness.value > 0.0;

  private static void RefreshAmounts(WildnessMonitor.Instance smi)
  {
    bool flag = WildnessMonitor.IsWild(smi);
    smi.wildness.hide = !flag;
    AttributeInstance attributeInstance1 = Db.Get().CritterAttributes.Happiness.Lookup(smi.gameObject);
    if (attributeInstance1 != null)
      attributeInstance1.hide = flag;
    AttributeInstance attributeInstance2 = Db.Get().CritterAttributes.Metabolism.Lookup(smi.gameObject);
    if (attributeInstance2 != null)
      attributeInstance2.hide = flag;
    AmountInstance amountInstance1 = Db.Get().Amounts.Calories.Lookup(smi.gameObject);
    if (amountInstance1 != null)
      amountInstance1.hide = flag;
    AmountInstance amountInstance2 = Db.Get().Amounts.Temperature.Lookup(smi.gameObject);
    if (amountInstance2 != null)
      amountInstance2.hide = flag;
    AmountInstance amountInstance3 = Db.Get().Amounts.Fertility.Lookup(smi.gameObject);
    if (amountInstance3 != null)
      amountInstance3.hide = flag;
    AmountInstance amountInstance4 = Db.Get().Amounts.MilkProduction.Lookup(smi.gameObject);
    if (amountInstance4 != null)
      amountInstance4.hide = flag;
    AmountInstance amountInstance5 = Db.Get().Amounts.Beckoning.Lookup(smi.gameObject);
    if (amountInstance5 == null)
      return;
    amountInstance5.hide = flag;
  }

  public class Def : StateMachine.BaseDef
  {
    public Effect wildEffect;
    public Effect tameEffect;

    public override void Configure(GameObject prefab)
    {
      prefab.GetComponent<Modifiers>().initialAmounts.Add(Db.Get().Amounts.Wildness.Id);
    }
  }

  public new class Instance : 
    GameStateMachine<WildnessMonitor, WildnessMonitor.Instance, IStateMachineTarget, WildnessMonitor.Def>.GameInstance
  {
    public AmountInstance wildness;

    public Instance(IStateMachineTarget master, WildnessMonitor.Def def)
      : base(master, def)
    {
      this.wildness = Db.Get().Amounts.Wildness.Lookup(this.gameObject);
      this.wildness.value = this.wildness.GetMax();
    }

    public bool IsWild() => WildnessMonitor.IsWild(this);

    [ContextMenu("Tame Critter")]
    public void DebugTame()
    {
      AmountInstance amountInstance = Db.Get().Amounts.Wildness.Lookup(this.gameObject);
      if (amountInstance == null)
        return;
      amountInstance.value = 0.0f;
      this.smi.GoTo((StateMachine.BaseState) this.sm.tame);
    }
  }
}
