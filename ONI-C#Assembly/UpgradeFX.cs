﻿// Decompiled with JetBrains decompiler
// Type: UpgradeFX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class UpgradeFX : GameStateMachine<UpgradeFX, UpgradeFX.Instance>
{
  public StateMachine<UpgradeFX, UpgradeFX.Instance, IStateMachineTarget, object>.TargetParameter fx;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.Target(this.fx);
    this.root.PlayAnim("upgrade").OnAnimQueueComplete((GameStateMachine<UpgradeFX, UpgradeFX.Instance, IStateMachineTarget, object>.State) null).ToggleReactable((Func<UpgradeFX.Instance, Reactable>) (smi => smi.CreateReactable())).Exit("DestroyFX", (StateMachine<UpgradeFX, UpgradeFX.Instance, IStateMachineTarget, object>.State.Callback) (smi => smi.DestroyFX()));
  }

  public new class Instance : 
    GameStateMachine<UpgradeFX, UpgradeFX.Instance, IStateMachineTarget, object>.GameInstance
  {
    public Instance(IStateMachineTarget master, Vector3 offset)
      : base(master)
    {
      this.sm.fx.Set(FXHelpers.CreateEffect("upgrade_fx_kanim", master.gameObject.transform.GetPosition() + offset, master.gameObject.transform, true).gameObject, this.smi, false);
    }

    public void DestroyFX() => Util.KDestroyGameObject(this.sm.fx.Get(this.smi));

    public Reactable CreateReactable()
    {
      return (Reactable) new EmoteReactable(this.master.gameObject, (HashedString) nameof (UpgradeFX), Db.Get().ChoreTypes.Emote).SetEmote(Db.Get().Emotes.Minion.Cheer);
    }
  }
}
