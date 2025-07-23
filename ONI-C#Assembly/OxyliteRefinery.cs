﻿// Decompiled with JetBrains decompiler
// Type: OxyliteRefinery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class OxyliteRefinery : StateMachineComponent<OxyliteRefinery.StatesInstance>
{
  [MyCmpAdd]
  private Storage storage;
  [MyCmpReq]
  private Operational operational;
  public Tag emitTag;
  public float emitMass;
  public Vector3 dropOffset;

  protected override void OnSpawn() => this.smi.StartSM();

  public class StatesInstance(OxyliteRefinery smi) : 
    GameStateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.GameInstance(smi)
  {
    public void TryEmit()
    {
      Storage storage = this.smi.master.storage;
      GameObject first = storage.FindFirst(this.smi.master.emitTag);
      if (!((Object) first != (Object) null) || (double) first.GetComponent<PrimaryElement>().Mass < (double) this.master.emitMass)
        return;
      Vector3 position = (this.transform.GetPosition() + this.master.dropOffset) with
      {
        z = Grid.GetLayerZ(Grid.SceneLayer.Ore)
      };
      first.transform.SetPosition(position);
      storage.Drop(first, true);
    }
  }

  public class States : 
    GameStateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery>
  {
    public GameStateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.State disabled;
    public GameStateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.State waiting;
    public GameStateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.State converting;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.disabled;
      this.root.EventTransition(GameHashes.OperationalChanged, this.disabled, (StateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.Transition.ConditionCallback) (smi => !smi.master.operational.IsOperational));
      this.disabled.EventTransition(GameHashes.OperationalChanged, this.waiting, (StateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.Transition.ConditionCallback) (smi => smi.master.operational.IsOperational));
      this.waiting.EventTransition(GameHashes.OnStorageChange, this.converting, (StateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.Transition.ConditionCallback) (smi => smi.master.GetComponent<ElementConverter>().HasEnoughMassToStartConverting()));
      this.converting.Enter((StateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.State.Callback) (smi => smi.master.operational.SetActive(true))).Exit((StateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.State.Callback) (smi => smi.master.operational.SetActive(false))).Transition(this.waiting, (StateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.Transition.ConditionCallback) (smi => !smi.master.GetComponent<ElementConverter>().CanConvertAtAll())).EventHandler(GameHashes.OnStorageChange, (StateMachine<OxyliteRefinery.States, OxyliteRefinery.StatesInstance, OxyliteRefinery, object>.State.Callback) (smi => smi.TryEmit()));
    }
  }
}
