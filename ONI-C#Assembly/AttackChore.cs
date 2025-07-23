﻿// Decompiled with JetBrains decompiler
// Type: AttackChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using TUNING;
using UnityEngine;

#nullable disable
public class AttackChore : Chore<AttackChore.StatesInstance>
{
  private MultitoolController.Instance multiTool;

  protected override void OnStateMachineStop(string reason, StateMachine.Status status)
  {
    this.CleanUpMultitool();
    base.OnStateMachineStop(reason, status);
  }

  public AttackChore(IStateMachineTarget target, GameObject enemy)
    : base(Db.Get().ChoreTypes.Attack, target, target.GetComponent<ChoreProvider>(), false)
  {
    this.smi = new AttackChore.StatesInstance(this);
    this.smi.sm.attackTarget.Set(enemy, this.smi, false);
    Game.Instance.Trigger(1980521255, (object) enemy);
    this.SetPrioritizable(enemy.GetComponent<Prioritizable>());
  }

  public string GetHitAnim()
  {
    Workable component = this.smi.sm.attackTarget.Get(this.smi).gameObject.GetComponent<Workable>();
    return (bool) (UnityEngine.Object) component ? MultitoolController.GetAnimationStrings(component, this.gameObject.GetComponent<WorkerBase>(), "hit")[1].Replace("_loop", "") : "hit";
  }

  public void OnTargetMoved(object data)
  {
    int cell1 = Grid.PosToCell(this.smi.master.gameObject);
    if ((UnityEngine.Object) this.smi.sm.attackTarget.Get(this.smi) == (UnityEngine.Object) null)
    {
      this.CleanUpMultitool();
    }
    else
    {
      if (this.smi.GetCurrentState() == this.smi.sm.attack)
      {
        int cell2 = Grid.PosToCell(this.smi.sm.attackTarget.Get(this.smi).gameObject);
        IApproachable component = this.smi.sm.attackTarget.Get(this.smi).gameObject.GetComponent<IApproachable>();
        if (component != null)
        {
          CellOffset[] offsets = component.GetOffsets();
          if (cell1 == cell2 || !Grid.IsCellOffsetOf(cell1, cell2, offsets))
          {
            if (this.multiTool != null)
              this.CleanUpMultitool();
            this.smi.GoTo((StateMachine.BaseState) this.smi.sm.approachtarget);
          }
        }
        else
          Debug.Log((object) "has no approachable");
      }
      if (this.multiTool == null)
        return;
      this.multiTool.UpdateHitEffectTarget();
    }
  }

  public override void Begin(Chore.Precondition.Context context)
  {
    this.smi.sm.attacker.Set(context.consumerState.gameObject, this.smi, false);
    base.Begin(context);
  }

  protected override void End(string reason)
  {
    this.CleanUpMultitool();
    if (!this.smi.sm.attackTarget.IsNull(this.smi))
    {
      GameObject go = this.smi.sm.attackTarget.Get(this.smi);
      Prioritizable component = go.GetComponent<Prioritizable>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.IsPrioritizable())
        Prioritizable.RemoveRef(go);
    }
    base.End(reason);
  }

  public void OnTargetDestroyed(object data) => this.Fail("target destroyed");

  private void CleanUpMultitool()
  {
    if (this.smi.master.multiTool == null)
      return;
    this.multiTool.DestroyHitEffect();
    this.multiTool.StopSM("attack complete");
    this.multiTool = (MultitoolController.Instance) null;
  }

  public class StatesInstance(AttackChore master) : 
    GameStateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.GameInstance(master)
  {
  }

  public class States : GameStateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore>
  {
    public StateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.TargetParameter attackTarget;
    public StateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.TargetParameter attacker;
    public GameStateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.ApproachSubState<RangedAttackable> approachtarget;
    public GameStateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.State attack;
    public GameStateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.State success;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.approachtarget;
      this.root.ToggleStatusItem(Db.Get().DuplicantStatusItems.Fighting, (Func<AttackChore.StatesInstance, object>) (smi => (object) smi.master.gameObject)).EventHandler(GameHashes.TargetLost, (StateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.State.Callback) (smi => smi.master.Fail("target lost"))).Enter((StateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.State.Callback) (smi => smi.master.GetComponent<Weapon>().Configure(DUPLICANTSTATS.STANDARD.Combat.BasicWeapon.MIN_DAMAGE_PER_HIT, DUPLICANTSTATS.STANDARD.Combat.BasicWeapon.MAX_DAMAGE_PER_HIT, DUPLICANTSTATS.STANDARD.Combat.BasicWeapon.DAMAGE_TYPE, DUPLICANTSTATS.STANDARD.Combat.BasicWeapon.TARGET_TYPE, DUPLICANTSTATS.STANDARD.Combat.BasicWeapon.MAX_HITS, DUPLICANTSTATS.STANDARD.Combat.BasicWeapon.AREA_OF_EFFECT_RADIUS)));
      this.approachtarget.InitializeStates(this.attacker, this.attackTarget, this.attack, override_offsets: BaseMinionConfig.ATTACK_OFFSETS, tactic: NavigationTactics.Range_3_ProhibitOverlap).Enter((StateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.State.Callback) (smi =>
      {
        smi.master.CleanUpMultitool();
        smi.master.Trigger(1039067354, (object) this.attackTarget.Get(smi));
        Health component = this.attackTarget.Get(smi).GetComponent<Health>();
        if (!((UnityEngine.Object) component == (UnityEngine.Object) null) && !component.IsDefeated())
          return;
        smi.StopSM("target defeated approachtarget");
      }));
      this.attack.Target(this.attacker).Enter((StateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.State.Callback) (smi =>
      {
        this.attackTarget.Get(smi).Subscribe(1088554450, new Action<object>(smi.master.OnTargetMoved));
        if (this.attackTarget != null && smi.master.multiTool == null)
        {
          smi.master.multiTool = new MultitoolController.Instance(this.attackTarget.Get(smi).GetComponent<Workable>(), smi.master.GetComponent<WorkerBase>(), (HashedString) "attack", Assets.GetPrefab((Tag) EffectConfigs.AttackSplashId));
          smi.master.multiTool.StartSM();
        }
        this.attackTarget.Get(smi).Subscribe(1969584890, new Action<object>(smi.master.OnTargetDestroyed));
        smi.ScheduleGoTo(1f / DUPLICANTSTATS.STANDARD.Combat.BasicWeapon.ATTACKS_PER_SECOND, (StateMachine.BaseState) this.success);
      })).Update((Action<AttackChore.StatesInstance, float>) ((smi, dt) =>
      {
        if (smi.master.multiTool == null)
          return;
        smi.master.multiTool.UpdateHitEffectTarget();
      })).Exit((StateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.State.Callback) (smi =>
      {
        if (!((UnityEngine.Object) this.attackTarget.Get(smi) != (UnityEngine.Object) null))
          return;
        this.attackTarget.Get(smi).Unsubscribe(1088554450, new Action<object>(smi.master.OnTargetMoved));
      }));
      this.success.Enter("finishAttack", (StateMachine<AttackChore.States, AttackChore.StatesInstance, AttackChore, object>.State.Callback) (smi =>
      {
        if ((UnityEngine.Object) this.attackTarget.Get(smi) != (UnityEngine.Object) null)
        {
          Transform transform = this.attackTarget.Get(smi).transform;
          Weapon component1 = this.attacker.Get(smi).gameObject.GetComponent<Weapon>();
          if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
          {
            component1.AttackTarget(transform.gameObject);
            Health component2 = this.attackTarget.Get(smi).GetComponent<Health>();
            if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
              return;
            if (!component2.IsDefeated())
            {
              smi.GoTo((StateMachine.BaseState) this.attack);
            }
            else
            {
              smi.master.CleanUpMultitool();
              smi.StopSM("target defeated success");
            }
          }
          else
          {
            smi.master.CleanUpMultitool();
            smi.StopSM("no weapon");
          }
        }
        else
        {
          smi.master.CleanUpMultitool();
          smi.StopSM("no target");
        }
      })).ReturnSuccess();
    }
  }
}
