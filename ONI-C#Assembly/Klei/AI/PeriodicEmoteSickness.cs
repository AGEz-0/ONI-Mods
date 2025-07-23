// Decompiled with JetBrains decompiler
// Type: Klei.AI.PeriodicEmoteSickness
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
namespace Klei.AI;

public class PeriodicEmoteSickness : Sickness.SicknessComponent
{
  private Emote emote;
  private float cooldown;

  public PeriodicEmoteSickness(Emote emote, float cooldown)
  {
    this.emote = emote;
    this.cooldown = cooldown;
  }

  public override object OnInfect(GameObject go, SicknessInstance diseaseInstance)
  {
    PeriodicEmoteSickness.StatesInstance statesInstance = new PeriodicEmoteSickness.StatesInstance(diseaseInstance, this);
    statesInstance.StartSM();
    return (object) statesInstance;
  }

  public override void OnCure(GameObject go, object instance_data)
  {
    ((StateMachine.Instance) instance_data).StopSM("Cured");
  }

  public class StatesInstance : 
    GameStateMachine<PeriodicEmoteSickness.States, PeriodicEmoteSickness.StatesInstance, SicknessInstance, object>.GameInstance
  {
    public PeriodicEmoteSickness periodicEmoteSickness;

    public StatesInstance(SicknessInstance master, PeriodicEmoteSickness periodicEmoteSickness)
      : base(master)
    {
      this.periodicEmoteSickness = periodicEmoteSickness;
    }

    public Reactable GetReactable()
    {
      return (Reactable) new SelfEmoteReactable(this.master.gameObject, (HashedString) nameof (PeriodicEmoteSickness), Db.Get().ChoreTypes.Emote, localCooldown: this.periodicEmoteSickness.cooldown).SetEmote(this.periodicEmoteSickness.emote).SetOverideAnimSet("anim_sneeze_kanim");
    }
  }

  public class States : 
    GameStateMachine<PeriodicEmoteSickness.States, PeriodicEmoteSickness.StatesInstance, SicknessInstance>
  {
    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.root;
      this.root.ToggleReactable((Func<PeriodicEmoteSickness.StatesInstance, Reactable>) (smi => smi.GetReactable()));
    }
  }
}
