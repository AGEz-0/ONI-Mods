﻿// Decompiled with JetBrains decompiler
// Type: EquipChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class EquipChore : Chore<EquipChore.StatesInstance>
{
  public EquipChore(IStateMachineTarget equippable)
    : base(Db.Get().ChoreTypes.Equip, equippable, (ChoreProvider) null, false, master_priority_class: PriorityScreen.PriorityClass.personalNeeds)
  {
    this.smi = new EquipChore.StatesInstance(this);
    this.smi.sm.equippable_source.Set(equippable.gameObject, this.smi, false);
    double num = (double) this.smi.sm.requested_units.Set(1f, this.smi);
    this.showAvailabilityInHoverText = false;
    Prioritizable.AddRef(equippable.gameObject);
    Game.Instance.Trigger(1980521255, (object) equippable.gameObject);
    this.AddPrecondition(ChorePreconditions.instance.IsAssignedtoMe, (object) equippable.GetComponent<Assignable>());
    this.AddPrecondition(ChorePreconditions.instance.CanPickup, (object) equippable.GetComponent<Pickupable>());
  }

  public override void Begin(Chore.Precondition.Context context)
  {
    if ((UnityEngine.Object) context.consumerState.consumer == (UnityEngine.Object) null)
      Debug.LogError((object) "EquipChore null context.consumer");
    else if (this.smi == null)
      Debug.LogError((object) "EquipChore null smi");
    else if (this.smi.sm == null)
      Debug.LogError((object) "EquipChore null smi.sm");
    else if (this.smi.sm.equippable_source == null)
    {
      Debug.LogError((object) "EquipChore null smi.sm.equippable_source");
    }
    else
    {
      this.smi.sm.equipper.Set(context.consumerState.gameObject, this.smi, false);
      base.Begin(context);
    }
  }

  public class StatesInstance(EquipChore master) : 
    GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.GameInstance(master)
  {
  }

  public class States : GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore>
  {
    public StateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.TargetParameter equipper;
    public StateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.TargetParameter equippable_source;
    public StateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.TargetParameter equippable_result;
    public StateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.FloatParameter requested_units;
    public StateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.FloatParameter actual_units;
    public GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.FetchSubState fetch;
    public EquipChore.States.Equip equip;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.fetch;
      this.Target(this.equipper);
      this.root.DoNothing();
      this.fetch.InitializeStates(this.equipper, this.equippable_source, this.equippable_result, this.requested_units, this.actual_units, (GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.State) this.equip);
      this.equip.ToggleWork<EquippableWorkable>(this.equippable_result, (GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.State) null, (GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.State) null, (Func<EquipChore.StatesInstance, bool>) null);
    }

    public class Equip : 
      GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.State
    {
      public GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.State pre;
      public GameStateMachine<EquipChore.States, EquipChore.StatesInstance, EquipChore, object>.State pst;
    }
  }
}
