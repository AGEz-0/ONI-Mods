// Decompiled with JetBrains decompiler
// Type: ExternalTemperatureMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using TUNING;

#nullable disable
public class ExternalTemperatureMonitor : 
  GameStateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance>
{
  public GameStateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.State comfortable;
  public GameStateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.State transitionToTooWarm;
  public GameStateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.State tooWarm;
  public GameStateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.State transitionToTooCool;
  public GameStateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.State tooCool;
  private const float BODY_TEMPERATURE_AFFECT_EXTERNAL_FEEL_THRESHOLD = 0.5f;
  public static readonly float BASE_STRESS_TOLERANCE_COLD = DUPLICANTSTATS.STANDARD.BaseStats.DUPLICANT_WARMING_KILOWATTS * 0.2f;
  public static readonly float BASE_STRESS_TOLERANCE_WARM = DUPLICANTSTATS.STANDARD.BaseStats.DUPLICANT_COOLING_KILOWATTS * 0.2f;
  private const float START_GAME_AVERAGING_DELAY = 6f;
  private const float TRANSITION_TO_DELAY = 1f;
  private const float TRANSITION_OUT_DELAY = 6f;

  public static float GetExternalColdThreshold(Attributes affected_attributes) => -0.039f;

  public static float GetExternalWarmThreshold(Attributes affected_attributes) => 0.008f;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.comfortable;
    this.comfortable.Transition(this.transitionToTooWarm, (StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.IsTooHot() && (double) smi.timeinstate > 6.0)).Transition(this.transitionToTooCool, (StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.IsTooCold() && (double) smi.timeinstate > 6.0));
    this.transitionToTooWarm.Transition(this.comfortable, (StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.IsTooHot())).Transition(this.tooWarm, (StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.IsTooHot() && (double) smi.timeinstate > 1.0));
    this.transitionToTooCool.Transition(this.comfortable, (StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.IsTooCold())).Transition(this.tooCool, (StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => smi.IsTooCold() && (double) smi.timeinstate > 1.0));
    this.tooWarm.ToggleTag(GameTags.FeelingWarm).Transition(this.comfortable, (StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.IsTooHot() && (double) smi.timeinstate > 6.0)).EventHandlerTransition(GameHashes.EffectAdded, this.comfortable, (Func<ExternalTemperatureMonitor.Instance, object, bool>) ((smi, obj) => !smi.IsTooHot())).Enter((StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.State.Callback) (smi => Tutorial.Instance.TutorialMessage(Tutorial.TutorialMessages.TM_ThermalComfort)));
    this.tooCool.ToggleTag(GameTags.FeelingCold).Transition(this.comfortable, (StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback) (smi => !smi.IsTooCold() && (double) smi.timeinstate > 6.0)).EventHandlerTransition(GameHashes.EffectAdded, this.comfortable, (Func<ExternalTemperatureMonitor.Instance, object, bool>) ((smi, obj) => !smi.IsTooCold())).Enter((StateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.State.Callback) (smi => Tutorial.Instance.TutorialMessage(Tutorial.TutorialMessages.TM_ThermalComfort)));
  }

  public new class Instance : 
    GameStateMachine<ExternalTemperatureMonitor, ExternalTemperatureMonitor.Instance, IStateMachineTarget, object>.GameInstance
  {
    public float HotThreshold = 306.15f;
    public Effects effects;
    public Traits traits;
    public Attributes attributes;
    public AmountInstance internalTemperature;
    private TemperatureMonitor.Instance internalTemperatureMonitor;
    public CreatureSimTemperatureTransfer temperatureTransferer;
    public PrimaryElement primaryElement;
    private Effect warmAirEffect = Db.Get().effects.Get("WarmAir");
    private Effect coldAirEffect = Db.Get().effects.Get("ColdAir");
    private Effect[] immunityToColdEffects = new Effect[2]
    {
      Db.Get().effects.Get("WarmTouch"),
      Db.Get().effects.Get("WarmTouchFood")
    };

    public float GetCurrentColdThreshold
    {
      get
      {
        return (double) this.internalTemperatureMonitor.IdealTemperatureDelta() > 0.5 ? 0.0f : CreatureSimTemperatureTransfer.PotentialEnergyFlowToCreature(Grid.PosToCell(this.gameObject), this.primaryElement, (SimTemperatureTransfer) this.temperatureTransferer);
      }
    }

    public float GetCurrentHotThreshold => this.HotThreshold;

    public Instance(IStateMachineTarget master)
      : base(master)
    {
      this.attributes = this.gameObject.GetAttributes();
      this.internalTemperatureMonitor = this.gameObject.GetSMI<TemperatureMonitor.Instance>();
      this.internalTemperature = Db.Get().Amounts.Temperature.Lookup(this.gameObject);
      this.temperatureTransferer = this.gameObject.GetComponent<CreatureSimTemperatureTransfer>();
      this.primaryElement = this.gameObject.GetComponent<PrimaryElement>();
      this.effects = this.gameObject.GetComponent<Effects>();
      this.traits = this.gameObject.GetComponent<Traits>();
    }

    public bool IsTooHot()
    {
      return !this.effects.HasEffect("RefreshingTouch") && !this.effects.HasImmunityTo(this.warmAirEffect) && this.temperatureTransferer.LastTemperatureRecordIsReliable && (double) this.smi.temperatureTransferer.average_kilowatts_exchanged.GetUnweightedAverage > (double) ExternalTemperatureMonitor.GetExternalWarmThreshold(this.smi.attributes);
    }

    public bool IsTooCold()
    {
      for (int index = 0; index < this.immunityToColdEffects.Length; ++index)
      {
        if (this.effects.HasEffect(this.immunityToColdEffects[index]))
          return false;
      }
      return !this.effects.HasImmunityTo(this.coldAirEffect) && (!((UnityEngine.Object) this.traits != (UnityEngine.Object) null) || !this.traits.IsEffectIgnored(this.coldAirEffect)) && !WarmthProvider.IsWarmCell(Grid.PosToCell((StateMachine.Instance) this)) && this.temperatureTransferer.LastTemperatureRecordIsReliable && (double) this.smi.temperatureTransferer.average_kilowatts_exchanged.GetUnweightedAverage < (double) ExternalTemperatureMonitor.GetExternalColdThreshold(this.smi.attributes);
    }
  }
}
