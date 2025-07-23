// Decompiled with JetBrains decompiler
// Type: BreathMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using TUNING;

#nullable disable
public class BreathMonitor : GameStateMachine<BreathMonitor, BreathMonitor.Instance>
{
  public BreathMonitor.SatisfiedState satisfied;
  public BreathMonitor.LowBreathState lowbreath;
  public StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.IntParameter recoverBreathCell;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.satisfied;
    this.satisfied.DefaultState(this.satisfied.full).Transition((GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State) this.lowbreath, new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback(BreathMonitor.IsLowBreath));
    this.satisfied.full.Transition(this.satisfied.notfull, new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback(BreathMonitor.IsNotFullBreath)).Enter(new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State.Callback(BreathMonitor.HideBreathBar));
    this.satisfied.notfull.Transition(this.satisfied.full, new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback(BreathMonitor.IsFullBreath)).Enter(new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State.Callback(BreathMonitor.ShowBreathBar));
    this.lowbreath.DefaultState(this.lowbreath.nowheretorecover).Transition((GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State) this.satisfied, new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.Transition.ConditionCallback(BreathMonitor.IsFullBreath)).ToggleExpression(Db.Get().Expressions.RecoverBreath, new Func<BreathMonitor.Instance, bool>(BreathMonitor.IsOutOfOxygen)).ToggleUrge(Db.Get().Urges.RecoverBreath).ToggleThought(Db.Get().Thoughts.Suffocating).ToggleTag(GameTags.HoldingBreath).Enter(new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State.Callback(BreathMonitor.ShowBreathBar)).Enter(new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State.Callback(BreathMonitor.UpdateRecoverBreathCell)).Update(new System.Action<BreathMonitor.Instance, float>(BreathMonitor.UpdateRecoverBreathCell), UpdateRate.RENDER_1000ms, true);
    this.lowbreath.nowheretorecover.ParamTransition<int>((StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.Parameter<int>) this.recoverBreathCell, this.lowbreath.recoveryavailable, new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.Parameter<int>.Callback(BreathMonitor.IsValidRecoverCell));
    this.lowbreath.recoveryavailable.ParamTransition<int>((StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.Parameter<int>) this.recoverBreathCell, this.lowbreath.nowheretorecover, new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.Parameter<int>.Callback(BreathMonitor.IsNotValidRecoverCell)).Enter(new StateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State.Callback(BreathMonitor.UpdateRecoverBreathCell)).ToggleChore(new Func<BreathMonitor.Instance, Chore>(BreathMonitor.CreateRecoverBreathChore), this.lowbreath.nowheretorecover);
  }

  private static bool IsLowBreath(BreathMonitor.Instance smi)
  {
    WorldContainer myWorld = smi.master.gameObject.GetMyWorld();
    return !((UnityEngine.Object) myWorld == (UnityEngine.Object) null) && myWorld.AlertManager.IsRedAlert() ? (double) smi.breath.value < (double) DUPLICANTSTATS.STANDARD.Breath.SUFFOCATE_AMOUNT : (double) smi.breath.value < (double) DUPLICANTSTATS.STANDARD.Breath.RETREAT_AMOUNT;
  }

  private static Chore CreateRecoverBreathChore(BreathMonitor.Instance smi)
  {
    return (Chore) new RecoverBreathChore(smi.master);
  }

  private static bool IsNotFullBreath(BreathMonitor.Instance smi)
  {
    return !BreathMonitor.IsFullBreath(smi);
  }

  private static bool IsFullBreath(BreathMonitor.Instance smi)
  {
    return (double) smi.breath.value >= (double) smi.breath.GetMax();
  }

  private static bool IsOutOfOxygen(BreathMonitor.Instance smi) => smi.breather.IsOutOfOxygen;

  private static void ShowBreathBar(BreathMonitor.Instance smi)
  {
    if (!((UnityEngine.Object) NameDisplayScreen.Instance != (UnityEngine.Object) null))
      return;
    NameDisplayScreen.Instance.SetBreathDisplay(smi.gameObject, new Func<float>(smi.GetBreath), true);
  }

  private static void HideBreathBar(BreathMonitor.Instance smi)
  {
    if (!((UnityEngine.Object) NameDisplayScreen.Instance != (UnityEngine.Object) null))
      return;
    NameDisplayScreen.Instance.SetBreathDisplay(smi.gameObject, (Func<float>) null, false);
  }

  private static bool IsValidRecoverCell(BreathMonitor.Instance smi, int cell)
  {
    return cell != Grid.InvalidCell;
  }

  private static bool IsNotValidRecoverCell(BreathMonitor.Instance smi, int cell)
  {
    return !BreathMonitor.IsValidRecoverCell(smi, cell);
  }

  private static void UpdateRecoverBreathCell(BreathMonitor.Instance smi, float dt)
  {
    BreathMonitor.UpdateRecoverBreathCell(smi);
  }

  private static void UpdateRecoverBreathCell(BreathMonitor.Instance smi)
  {
    if (!smi.canRecoverBreath)
      return;
    smi.query.Reset();
    smi.navigator.RunQuery((PathFinderQuery) smi.query);
    int theSpecificCell = smi.query.GetResultCell();
    if (!GasBreatherFromWorldProvider.GetBestBreathableCellAroundSpecificCell(theSpecificCell, GasBreatherFromWorldProvider.DEFAULT_BREATHABLE_OFFSETS, smi.breather).IsBreathable)
      theSpecificCell = PathFinder.InvalidCell;
    smi.sm.recoverBreathCell.Set(theSpecificCell, smi);
  }

  public class LowBreathState : 
    GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State
  {
    public GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State nowheretorecover;
    public GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State recoveryavailable;
  }

  public class SatisfiedState : 
    GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State
  {
    public GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State full;
    public GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.State notfull;
  }

  public new class Instance : 
    GameStateMachine<BreathMonitor, BreathMonitor.Instance, IStateMachineTarget, object>.GameInstance
  {
    public AmountInstance breath;
    public SafetyQuery query;
    public Navigator navigator;
    public OxygenBreather breather;
    public bool canRecoverBreath = true;

    public Instance(IStateMachineTarget master)
      : base(master)
    {
      this.breath = Db.Get().Amounts.Breath.Lookup(master.gameObject);
      this.query = new SafetyQuery(Game.Instance.safetyConditions.RecoverBreathChecker, this.GetComponent<KMonoBehaviour>(), int.MaxValue);
      this.navigator = this.GetComponent<Navigator>();
      this.breather = this.GetComponent<OxygenBreather>();
    }

    public int GetRecoverCell() => this.sm.recoverBreathCell.Get(this.smi);

    public float GetBreath() => this.breath.value / this.breath.GetMax();
  }
}
