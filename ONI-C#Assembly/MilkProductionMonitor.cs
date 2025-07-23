// Decompiled with JetBrains decompiler
// Type: MilkProductionMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using UnityEngine;

#nullable disable
public class MilkProductionMonitor : 
  GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>
{
  public MilkProductionMonitor.ProducingStates producing;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    this.serializable = StateMachine.SerializeType.ParamsOnly;
    default_state = (StateMachine.BaseState) this.producing;
    this.producing.DefaultState(this.producing.paused).EventHandler(GameHashes.CaloriesConsumed, (GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.GameEvent.Callback) ((smi, data) => smi.OnCaloriesConsumed(data)));
    this.producing.paused.Transition(this.producing.full, new StateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.Transition.ConditionCallback(MilkProductionMonitor.IsFull), UpdateRate.SIM_1000ms).Transition(this.producing.producing, new StateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.Transition.ConditionCallback(MilkProductionMonitor.IsProducing), UpdateRate.SIM_1000ms);
    this.producing.producing.Transition(this.producing.full, new StateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.Transition.ConditionCallback(MilkProductionMonitor.IsFull), UpdateRate.SIM_1000ms).Transition(this.producing.paused, GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.Not(new StateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.Transition.ConditionCallback(MilkProductionMonitor.IsProducing)), UpdateRate.SIM_1000ms);
    this.producing.full.ToggleStatusItem(Db.Get().CreatureStatusItems.MilkFull).Transition(this.producing.paused, GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.Not(new StateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.Transition.ConditionCallback(MilkProductionMonitor.IsFull)), UpdateRate.SIM_1000ms).Enter((StateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.State.Callback) (smi => smi.gameObject.AddTag(GameTags.Creatures.RequiresMilking)));
  }

  private static bool IsProducing(MilkProductionMonitor.Instance smi)
  {
    return !smi.IsFull && smi.IsUnderProductionEffect;
  }

  private static bool IsFull(MilkProductionMonitor.Instance smi) => smi.IsFull;

  private static bool HasCapacity(MilkProductionMonitor.Instance smi) => !smi.IsFull;

  public class Def : StateMachine.BaseDef
  {
    public const SimHashes element = SimHashes.Milk;
    public string effectId;
    public float Capacity = 200f;
    public float CaloriesPerCycle = 1000f;
    public float HappinessRequired;

    public override void Configure(GameObject prefab)
    {
      prefab.GetComponent<Modifiers>().initialAmounts.Add(Db.Get().Amounts.MilkProduction.Id);
    }
  }

  public class ProducingStates : 
    GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.State
  {
    public GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.State paused;
    public GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.State producing;
    public GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.State full;
  }

  public new class Instance(IStateMachineTarget master, MilkProductionMonitor.Def def) : 
    GameStateMachine<MilkProductionMonitor, MilkProductionMonitor.Instance, IStateMachineTarget, MilkProductionMonitor.Def>.GameInstance(master, def)
  {
    public System.Action<float> OnMilkAmountChanged;
    public AmountInstance milkAmountInstance;
    public EffectInstance effectInstance;
    [MyCmpGet]
    private Effects effects;

    public float MilkAmount => this.MilkPercentage / 100f * this.def.Capacity;

    public float MilkPercentage => this.milkAmountInstance.value;

    public bool IsFull => (double) this.MilkPercentage >= (double) this.milkAmountInstance.GetMax();

    public bool IsUnderProductionEffect => (double) this.milkAmountInstance.GetDelta() > 0.0;

    public override void StartSM()
    {
      this.milkAmountInstance = Db.Get().Amounts.MilkProduction.Lookup(this.gameObject);
      if (this.def.effectId != null)
        this.effectInstance = this.effects.Get(this.smi.def.effectId);
      base.StartSM();
    }

    public void OnCaloriesConsumed(object data)
    {
      if (this.def.effectId == null)
        return;
      CreatureCalorieMonitor.CaloriesConsumedEvent caloriesConsumedEvent = (CreatureCalorieMonitor.CaloriesConsumedEvent) data;
      this.effectInstance = this.effects.Get(this.smi.def.effectId);
      if (this.effectInstance == null)
        this.effectInstance = this.effects.Add(this.smi.def.effectId, true);
      this.effectInstance.timeRemaining += (float) ((double) caloriesConsumedEvent.calories / (double) this.smi.def.CaloriesPerCycle * 600.0);
    }

    private void RemoveMilk(float amount)
    {
      if (this.milkAmountInstance == null)
        return;
      double num = (double) this.milkAmountInstance.SetValue(Mathf.Min(this.milkAmountInstance.GetMin(), this.MilkPercentage - amount));
    }

    public PrimaryElement ExtractMilk(float desiredAmount)
    {
      float num = Mathf.Min(desiredAmount, this.MilkAmount);
      float temperature = this.GetComponent<PrimaryElement>().Temperature;
      if ((double) num <= 0.0)
        return (PrimaryElement) null;
      this.RemoveMilk(num);
      PrimaryElement component = LiquidSourceManager.Instance.CreateChunk(SimHashes.Milk, num, temperature, (byte) 0, 0, this.transform.GetPosition()).GetComponent<PrimaryElement>();
      component.KeepZeroMassObject = false;
      return component;
    }

    public PrimaryElement ExtractMilkIntoElementChunk(
      float desiredAmount,
      PrimaryElement elementChunk)
    {
      if ((UnityEngine.Object) elementChunk == (UnityEngine.Object) null || elementChunk.ElementID != SimHashes.Milk)
        return (PrimaryElement) null;
      float num = Mathf.Min(desiredAmount, this.MilkAmount);
      float temperature = this.GetComponent<PrimaryElement>().Temperature;
      this.RemoveMilk(num);
      float mass = elementChunk.Mass;
      float finalTemperature = GameUtil.GetFinalTemperature(elementChunk.Temperature, mass, temperature, num);
      elementChunk.SetMassTemperature(mass + num, finalTemperature);
      return elementChunk;
    }

    public PrimaryElement ExtractMilkIntoStorage(float desiredAmount, Storage storage)
    {
      float num = Mathf.Min(desiredAmount, this.MilkAmount);
      float temperature = this.GetComponent<PrimaryElement>().Temperature;
      this.RemoveMilk(num);
      return storage.AddLiquid(SimHashes.Milk, num, temperature, (byte) 0, 0);
    }
  }
}
