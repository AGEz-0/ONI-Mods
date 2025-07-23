// Decompiled with JetBrains decompiler
// Type: BlightVulnerable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[SkipSaveFileSerialization]
public class BlightVulnerable : StateMachineComponent<BlightVulnerable.StatesInstance>
{
  private SchedulerHandle handle;
  public bool prefersDarkness;

  protected override void OnPrefabInit() => base.OnPrefabInit();

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.smi.StartSM();
  }

  protected override void OnCleanUp() => base.OnCleanUp();

  public void MakeBlighted()
  {
    Debug.Log((object) "Blighting plant", (UnityEngine.Object) this);
    this.smi.sm.isBlighted.Set(true, this.smi);
  }

  public class StatesInstance(BlightVulnerable master) : 
    GameStateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable, object>.GameInstance(master)
  {
  }

  public class States : 
    GameStateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable>
  {
    public StateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable, object>.BoolParameter isBlighted;
    public GameStateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable, object>.State comfortable;
    public GameStateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable, object>.State blighted;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.comfortable;
      this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
      this.comfortable.ParamTransition<bool>((StateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable, object>.Parameter<bool>) this.isBlighted, this.blighted, GameStateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable, object>.IsTrue);
      this.blighted.TriggerOnEnter(GameHashes.BlightChanged, (Func<BlightVulnerable.StatesInstance, object>) (smi => (object) true)).Enter((StateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable, object>.State.Callback) (smi => smi.GetComponent<SeedProducer>().seedInfo.seedId = RotPileConfig.ID)).ToggleTag(GameTags.Blighted).Exit((StateMachine<BlightVulnerable.States, BlightVulnerable.StatesInstance, BlightVulnerable, object>.State.Callback) (smi => GameplayEventManager.Instance.Trigger(-1425542080, (object) smi.gameObject)));
    }
  }
}
