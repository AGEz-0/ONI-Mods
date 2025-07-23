// Decompiled with JetBrains decompiler
// Type: RadiationEater
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
public class RadiationEater : StateMachineComponent<RadiationEater.StatesInstance>
{
  protected override void OnSpawn() => this.smi.StartSM();

  public class StatesInstance : 
    GameStateMachine<RadiationEater.States, RadiationEater.StatesInstance, RadiationEater, object>.GameInstance
  {
    public AttributeModifier radiationEating;

    public StatesInstance(RadiationEater master)
      : base(master)
    {
      this.radiationEating = new AttributeModifier(Db.Get().Attributes.RadiationRecovery.Id, TUNING.TRAITS.RADIATION_EATER_RECOVERY, (string) DUPLICANTS.TRAITS.RADIATIONEATER.NAME);
    }

    public void OnEatRads(float radsEaten)
    {
      float delta = Mathf.Abs(radsEaten) * TUNING.TRAITS.RADS_TO_CALS;
      double num = (double) this.smi.master.gameObject.GetAmounts().Get(Db.Get().Amounts.Calories).ApplyDelta(delta);
    }
  }

  public class States : 
    GameStateMachine<RadiationEater.States, RadiationEater.StatesInstance, RadiationEater>
  {
    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.root;
      this.root.ToggleAttributeModifier("Radiation Eating", (Func<RadiationEater.StatesInstance, AttributeModifier>) (smi => smi.radiationEating)).EventHandler(GameHashes.RadiationRecovery, (GameStateMachine<RadiationEater.States, RadiationEater.StatesInstance, RadiationEater, object>.GameEvent.Callback) ((smi, data) =>
      {
        float radsEaten = (float) data;
        smi.OnEatRads(radsEaten);
      }));
    }
  }
}
