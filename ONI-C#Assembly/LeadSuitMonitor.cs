﻿// Decompiled with JetBrains decompiler
// Type: LeadSuitMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LeadSuitMonitor : GameStateMachine<LeadSuitMonitor, LeadSuitMonitor.Instance>
{
  public LeadSuitMonitor.WearingSuit wearingSuit;
  public StateMachine<LeadSuitMonitor, LeadSuitMonitor.Instance, IStateMachineTarget, object>.TargetParameter owner;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.wearingSuit;
    this.Target(this.owner);
    this.wearingSuit.DefaultState(this.wearingSuit.hasBattery);
    this.wearingSuit.hasBattery.Update(new System.Action<LeadSuitMonitor.Instance, float>(LeadSuitMonitor.CoolSuit)).TagTransition(GameTags.SuitBatteryOut, this.wearingSuit.noBattery);
    this.wearingSuit.noBattery.Enter((StateMachine<LeadSuitMonitor, LeadSuitMonitor.Instance, IStateMachineTarget, object>.State.Callback) (smi =>
    {
      Attributes attributes = smi.sm.owner.Get(smi).GetAttributes();
      if (attributes == null)
        return;
      foreach (AttributeModifier noBatteryModifier in smi.noBatteryModifiers)
        attributes.Add(noBatteryModifier);
    })).Exit((StateMachine<LeadSuitMonitor, LeadSuitMonitor.Instance, IStateMachineTarget, object>.State.Callback) (smi =>
    {
      Attributes attributes = smi.sm.owner.Get(smi).GetAttributes();
      if (attributes == null)
        return;
      foreach (AttributeModifier noBatteryModifier in smi.noBatteryModifiers)
        attributes.Remove(noBatteryModifier);
    })).TagTransition(GameTags.SuitBatteryOut, this.wearingSuit.hasBattery, true);
  }

  public static void CoolSuit(LeadSuitMonitor.Instance smi, float dt)
  {
    if (!(bool) (UnityEngine.Object) smi.navigator)
      return;
    GameObject go = smi.sm.owner.Get(smi);
    if (!(bool) (UnityEngine.Object) go)
      return;
    ScaldingMonitor.Instance smi1 = go.GetSMI<ScaldingMonitor.Instance>();
    if (smi1 == null || (double) smi1.AverageExternalTemperature < (double) smi.lead_suit_tank.coolingOperationalTemperature)
      return;
    smi.lead_suit_tank.batteryCharge -= 1f / smi.lead_suit_tank.batteryDuration * dt;
    if (!smi.lead_suit_tank.IsEmpty())
      return;
    go.AddTag(GameTags.SuitBatteryOut);
  }

  public class WearingSuit : 
    GameStateMachine<LeadSuitMonitor, LeadSuitMonitor.Instance, IStateMachineTarget, object>.State
  {
    public GameStateMachine<LeadSuitMonitor, LeadSuitMonitor.Instance, IStateMachineTarget, object>.State hasBattery;
    public GameStateMachine<LeadSuitMonitor, LeadSuitMonitor.Instance, IStateMachineTarget, object>.State noBattery;
  }

  public new class Instance : 
    GameStateMachine<LeadSuitMonitor, LeadSuitMonitor.Instance, IStateMachineTarget, object>.GameInstance
  {
    public Navigator navigator;
    public LeadSuitTank lead_suit_tank;
    public List<AttributeModifier> noBatteryModifiers = new List<AttributeModifier>();

    public Instance(IStateMachineTarget master, GameObject owner)
      : base(master)
    {
      this.sm.owner.Set(owner, this.smi, false);
      this.navigator = owner.GetComponent<Navigator>();
      this.lead_suit_tank = master.GetComponent<LeadSuitTank>();
      this.noBatteryModifiers.Add(new AttributeModifier(TUNING.EQUIPMENT.ATTRIBUTE_MOD_IDS.INSULATION, (float) -TUNING.EQUIPMENT.SUITS.LEADSUIT_INSULATION, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.SUIT_OUT_OF_BATTERIES));
      this.noBatteryModifiers.Add(new AttributeModifier(TUNING.EQUIPMENT.ATTRIBUTE_MOD_IDS.THERMAL_CONDUCTIVITY_BARRIER, -TUNING.EQUIPMENT.SUITS.LEADSUIT_THERMAL_CONDUCTIVITY_BARRIER, (string) STRINGS.EQUIPMENT.PREFABS.LEAD_SUIT.SUIT_OUT_OF_BATTERIES));
    }
  }
}
