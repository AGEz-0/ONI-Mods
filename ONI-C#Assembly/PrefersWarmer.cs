﻿// Decompiled with JetBrains decompiler
// Type: PrefersWarmer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using TUNING;

#nullable disable
[SkipSaveFileSerialization]
public class PrefersWarmer : StateMachineComponent<PrefersWarmer.StatesInstance>
{
  protected override void OnSpawn() => this.smi.StartSM();

  public class StatesInstance(PrefersWarmer master) : 
    GameStateMachine<PrefersWarmer.States, PrefersWarmer.StatesInstance, PrefersWarmer, object>.GameInstance(master)
  {
  }

  public class States : 
    GameStateMachine<PrefersWarmer.States, PrefersWarmer.StatesInstance, PrefersWarmer>
  {
    private AttributeModifier modifier = new AttributeModifier("ThermalConductivityBarrier", DUPLICANTSTATS.STANDARD.Temperature.Conductivity_Barrier_Modification.SKINNY, (string) DUPLICANTS.TRAITS.NEEDS.PREFERSWARMER.NAME);

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.root;
      this.root.ToggleAttributeModifier((string) DUPLICANTS.TRAITS.NEEDS.PREFERSWARMER.NAME, (Func<PrefersWarmer.StatesInstance, AttributeModifier>) (smi => this.modifier));
    }
  }
}
