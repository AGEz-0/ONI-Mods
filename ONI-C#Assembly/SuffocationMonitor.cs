// Decompiled with JetBrains decompiler
// Type: SuffocationMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using TUNING;

#nullable disable
public class SuffocationMonitor : 
  GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>
{
  public SuffocationMonitor.SatisfiedState satisfied;
  public SuffocationMonitor.NoOxygenState noOxygen;
  public GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State death;
  public GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State dead;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    this.serializable = StateMachine.SerializeType.ParamsOnly;
    default_state = (StateMachine.BaseState) this.satisfied;
    this.root.TagTransition(GameTags.Dead, this.dead);
    this.satisfied.DefaultState(this.satisfied.normal).ToggleAttributeModifier("Breathing", (Func<SuffocationMonitor.Instance, AttributeModifier>) (smi => smi.increaseBreathModifier)).EventTransition(GameHashes.OxygenBreatherHasAirChanged, (GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State) this.noOxygen, (StateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.Transition.ConditionCallback) (smi => !smi.CanBreath())).Transition((GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State) this.noOxygen, (StateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.Transition.ConditionCallback) (smi => !smi.CanBreath()));
    this.satisfied.normal.Transition(this.satisfied.low, (StateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.Transition.ConditionCallback) (smi => smi.oxygenBreather.IsLowOxygen()));
    this.satisfied.low.Transition(this.satisfied.normal, (StateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.Transition.ConditionCallback) (smi => !smi.oxygenBreather.IsLowOxygen())).ToggleEffect("LowOxygen");
    this.noOxygen.EventTransition(GameHashes.OxygenBreatherHasAirChanged, (GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State) this.satisfied, (StateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.Transition.ConditionCallback) (smi => smi.CanBreath())).TagTransition(GameTags.RecoveringBreath, (GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State) this.satisfied).ToggleExpression(Db.Get().Expressions.Suffocate).ToggleAttributeModifier("Holding Breath", (Func<SuffocationMonitor.Instance, AttributeModifier>) (smi => smi.decreaseBreathModifier)).ToggleTag(GameTags.NoOxygen).DefaultState(this.noOxygen.holdingbreath);
    this.noOxygen.holdingbreath.ToggleCategoryStatusItem(Db.Get().StatusItemCategories.Suffocation, Db.Get().DuplicantStatusItems.HoldingBreath).Transition(this.noOxygen.suffocating, (StateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.Transition.ConditionCallback) (smi => smi.IsSuffocating()));
    this.noOxygen.suffocating.ToggleCategoryStatusItem(Db.Get().StatusItemCategories.Suffocation, Db.Get().DuplicantStatusItems.Suffocating).Transition(this.death, (StateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.Transition.ConditionCallback) (smi => smi.HasSuffocated()));
    this.death.Enter("SuffocationDeath", (StateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State.Callback) (smi => smi.Kill()));
    this.dead.DoNothing();
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public class NoOxygenState : 
    GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State
  {
    public GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State holdingbreath;
    public GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State suffocating;
  }

  public class SatisfiedState : 
    GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State
  {
    public GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State normal;
    public GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.State low;
  }

  public new class Instance : 
    GameStateMachine<SuffocationMonitor, SuffocationMonitor.Instance, IStateMachineTarget, SuffocationMonitor.Def>.GameInstance
  {
    private AmountInstance breath;
    public AttributeModifier increaseBreathModifier;
    public AttributeModifier decreaseBreathModifier;

    public OxygenBreather oxygenBreather { get; private set; }

    public Instance(IStateMachineTarget master, SuffocationMonitor.Def def)
      : base(master, def)
    {
      this.breath = Db.Get().Amounts.Breath.Lookup(master.gameObject);
      Klei.AI.Attribute deltaAttribute = Db.Get().Amounts.Breath.deltaAttribute;
      float breathRate = DUPLICANTSTATS.STANDARD.Breath.BREATH_RATE;
      this.increaseBreathModifier = new AttributeModifier(deltaAttribute.Id, breathRate, (string) DUPLICANTS.MODIFIERS.BREATHING.NAME);
      this.decreaseBreathModifier = new AttributeModifier(deltaAttribute.Id, -breathRate, (string) DUPLICANTS.MODIFIERS.HOLDINGBREATH.NAME);
      this.oxygenBreather = this.GetComponent<OxygenBreather>();
    }

    public override void StartSM() => base.StartSM();

    public bool CanBreath()
    {
      return this.oxygenBreather.prefabID.HasTag(GameTags.RecoveringBreath) || this.oxygenBreather.prefabID.HasTag(GameTags.InTransitTube) || this.oxygenBreather.HasOxygen;
    }

    public bool HasSuffocated() => (double) this.breath.value <= 0.0;

    public bool IsSuffocating()
    {
      return (double) this.breath.deltaAttribute.GetTotalValue() <= 0.0 && (double) this.breath.value <= (double) DUPLICANTSTATS.STANDARD.Breath.SUFFOCATE_AMOUNT;
    }

    public void Kill()
    {
      this.gameObject.GetSMI<DeathMonitor.Instance>().Kill(Db.Get().Deaths.Suffocation);
    }
  }
}
