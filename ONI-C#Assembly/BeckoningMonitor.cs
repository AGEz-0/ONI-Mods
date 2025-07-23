// Decompiled with JetBrains decompiler
// Type: BeckoningMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using UnityEngine;

#nullable disable
public class BeckoningMonitor : 
  GameStateMachine<BeckoningMonitor, BeckoningMonitor.Instance, IStateMachineTarget, BeckoningMonitor.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.EventHandler(GameHashes.CaloriesConsumed, (GameStateMachine<BeckoningMonitor, BeckoningMonitor.Instance, IStateMachineTarget, BeckoningMonitor.Def>.GameEvent.Callback) ((smi, data) => smi.OnCaloriesConsumed(data))).ToggleBehaviour(GameTags.Creatures.WantsToBeckon, (StateMachine<BeckoningMonitor, BeckoningMonitor.Instance, IStateMachineTarget, BeckoningMonitor.Def>.Transition.ConditionCallback) (smi => smi.IsReadyToBeckon())).Update((System.Action<BeckoningMonitor.Instance, float>) ((smi, dt) => smi.UpdateBlockedStatusItem()), UpdateRate.SIM_1000ms);
  }

  public class Def : StateMachine.BaseDef
  {
    public float caloriesPerCycle;
    public string effectId = "MooWellFed";

    public override void Configure(GameObject prefab)
    {
      prefab.AddOrGet<Modifiers>().initialAmounts.Add(Db.Get().Amounts.Beckoning.Id);
    }
  }

  public new class Instance : 
    GameStateMachine<BeckoningMonitor, BeckoningMonitor.Instance, IStateMachineTarget, BeckoningMonitor.Def>.GameInstance
  {
    private AmountInstance beckoning;
    [MyCmpGet]
    private Effects effects;
    [MyCmpGet]
    public KSelectable kselectable;
    private Guid beckoningBlockedHandle;

    public Instance(IStateMachineTarget master, BeckoningMonitor.Def def)
      : base(master, def)
    {
      this.beckoning = Db.Get().Amounts.Beckoning.Lookup(this.gameObject);
    }

    private bool IsSpaceVisible()
    {
      int cell = Grid.PosToCell((StateMachine.Instance) this);
      return Grid.IsValidCell(cell) && Grid.ExposedToSunlight[cell] > (byte) 0;
    }

    private bool IsBeckoningAvailable()
    {
      return (double) this.smi.beckoning.value >= (double) this.smi.beckoning.GetMax();
    }

    public bool IsReadyToBeckon() => this.IsBeckoningAvailable() && this.IsSpaceVisible();

    public void UpdateBlockedStatusItem()
    {
      bool flag = this.IsSpaceVisible();
      if (!flag && this.IsBeckoningAvailable() && this.beckoningBlockedHandle == Guid.Empty)
      {
        this.beckoningBlockedHandle = this.kselectable.AddStatusItem(Db.Get().CreatureStatusItems.BeckoningBlocked);
      }
      else
      {
        if (!flag)
          return;
        this.beckoningBlockedHandle = this.kselectable.RemoveStatusItem(this.beckoningBlockedHandle);
      }
    }

    public void OnCaloriesConsumed(object data)
    {
      CreatureCalorieMonitor.CaloriesConsumedEvent caloriesConsumedEvent = (CreatureCalorieMonitor.CaloriesConsumedEvent) data;
      (this.effects.Get(this.smi.def.effectId) ?? this.effects.Add(this.smi.def.effectId, true)).timeRemaining += (float) ((double) caloriesConsumedEvent.calories / (double) this.smi.def.caloriesPerCycle * 600.0);
    }
  }
}
