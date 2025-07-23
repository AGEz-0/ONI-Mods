// Decompiled with JetBrains decompiler
// Type: ReceptacleMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
public class ReceptacleMonitor : 
  StateMachineComponent<ReceptacleMonitor.StatesInstance>,
  IGameObjectEffectDescriptor,
  IWiltCause,
  ISim1000ms
{
  private bool replanted;

  public bool Replanted => this.replanted;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.smi.StartSM();
  }

  public PlantablePlot GetReceptacle() => (PlantablePlot) this.smi.sm.receptacle.Get(this.smi);

  public void SetReceptacle(PlantablePlot plot = null)
  {
    if ((Object) plot == (Object) null)
    {
      this.smi.sm.receptacle.Set((SingleEntityReceptacle) null, this.smi);
      this.replanted = false;
    }
    else
    {
      this.smi.sm.receptacle.Set((SingleEntityReceptacle) plot, this.smi);
      this.replanted = true;
    }
    this.Trigger(-1636776682, (object) null);
  }

  public void Sim1000ms(float dt)
  {
    if ((Object) this.smi.sm.receptacle.Get(this.smi) == (Object) null)
    {
      this.smi.GoTo((StateMachine.BaseState) this.smi.sm.wild);
    }
    else
    {
      Operational component = this.smi.sm.receptacle.Get(this.smi).GetComponent<Operational>();
      if ((Object) component == (Object) null)
        this.smi.GoTo((StateMachine.BaseState) this.smi.sm.operational);
      else if (component.IsOperational)
        this.smi.GoTo((StateMachine.BaseState) this.smi.sm.operational);
      else
        this.smi.GoTo((StateMachine.BaseState) this.smi.sm.inoperational);
    }
  }

  WiltCondition.Condition[] IWiltCause.Conditions
  {
    get
    {
      return new WiltCondition.Condition[1]
      {
        WiltCondition.Condition.Receptacle
      };
    }
  }

  public string WiltStateString
  {
    get
    {
      string wiltStateString = "";
      if (this.smi.IsInsideState((StateMachine.BaseState) this.smi.sm.inoperational))
        wiltStateString += (string) CREATURES.STATUSITEMS.RECEPTACLEINOPERATIONAL.NAME;
      return wiltStateString;
    }
  }

  public bool HasReceptacle() => !this.smi.IsInsideState((StateMachine.BaseState) this.smi.sm.wild);

  public bool HasOperationalReceptacle()
  {
    return this.smi.IsInsideState((StateMachine.BaseState) this.smi.sm.operational);
  }

  public List<Descriptor> GetDescriptors(GameObject go)
  {
    return new List<Descriptor>()
    {
      new Descriptor((string) UI.GAMEOBJECTEFFECTS.REQUIRES_RECEPTACLE, (string) UI.GAMEOBJECTEFFECTS.TOOLTIPS.REQUIRES_RECEPTACLE, Descriptor.DescriptorType.Requirement)
    };
  }

  public class StatesInstance(ReceptacleMonitor master) : 
    GameStateMachine<ReceptacleMonitor.States, ReceptacleMonitor.StatesInstance, ReceptacleMonitor, object>.GameInstance(master)
  {
    public SingleEntityReceptacle ReceptacleObject => this.sm.receptacle.Get(this);
  }

  public class States : 
    GameStateMachine<ReceptacleMonitor.States, ReceptacleMonitor.StatesInstance, ReceptacleMonitor>
  {
    public StateMachine<ReceptacleMonitor.States, ReceptacleMonitor.StatesInstance, ReceptacleMonitor, object>.ObjectParameter<SingleEntityReceptacle> receptacle;
    public GameStateMachine<ReceptacleMonitor.States, ReceptacleMonitor.StatesInstance, ReceptacleMonitor, object>.State wild;
    public GameStateMachine<ReceptacleMonitor.States, ReceptacleMonitor.StatesInstance, ReceptacleMonitor, object>.State inoperational;
    public GameStateMachine<ReceptacleMonitor.States, ReceptacleMonitor.StatesInstance, ReceptacleMonitor, object>.State operational;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.wild;
      this.serializable = StateMachine.SerializeType.Never;
      this.wild.TriggerOnEnter(GameHashes.ReceptacleOperational);
      this.inoperational.TriggerOnEnter(GameHashes.ReceptacleInoperational);
      this.operational.TriggerOnEnter(GameHashes.ReceptacleOperational);
    }
  }
}
