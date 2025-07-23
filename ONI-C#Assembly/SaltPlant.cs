﻿// Decompiled with JetBrains decompiler
// Type: SaltPlant
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class SaltPlant : StateMachineComponent<SaltPlant.StatesInstance>
{
  private static readonly EventSystem.IntraObjectHandler<SaltPlant> OnWiltDelegate = new EventSystem.IntraObjectHandler<SaltPlant>((Action<SaltPlant, object>) ((component, data) => component.OnWilt(data)));
  private static readonly EventSystem.IntraObjectHandler<SaltPlant> OnWiltRecoverDelegate = new EventSystem.IntraObjectHandler<SaltPlant>((Action<SaltPlant, object>) ((component, data) => component.OnWiltRecover(data)));

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.Subscribe<SaltPlant>(-724860998, SaltPlant.OnWiltDelegate);
    this.Subscribe<SaltPlant>(712767498, SaltPlant.OnWiltRecoverDelegate);
  }

  private void OnWilt(object data = null)
  {
    this.gameObject.GetComponent<ElementConsumer>().EnableConsumption(false);
  }

  private void OnWiltRecover(object data = null)
  {
    this.gameObject.GetComponent<ElementConsumer>().EnableConsumption(true);
  }

  public class StatesInstance(SaltPlant master) : 
    GameStateMachine<SaltPlant.States, SaltPlant.StatesInstance, SaltPlant, object>.GameInstance(master)
  {
  }

  public class States : GameStateMachine<SaltPlant.States, SaltPlant.StatesInstance, SaltPlant>
  {
    public GameStateMachine<SaltPlant.States, SaltPlant.StatesInstance, SaltPlant, object>.State alive;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
      default_state = (StateMachine.BaseState) this.alive;
      this.alive.DoNothing();
    }
  }
}
