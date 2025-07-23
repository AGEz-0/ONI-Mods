// Decompiled with JetBrains decompiler
// Type: StarryEyed
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
[SkipSaveFileSerialization]
public class StarryEyed : StateMachineComponent<StarryEyed.StatesInstance>
{
  protected override void OnSpawn() => this.smi.StartSM();

  public class StatesInstance(StarryEyed master) : 
    GameStateMachine<StarryEyed.States, StarryEyed.StatesInstance, StarryEyed, object>.GameInstance(master)
  {
    public bool IsInSpace()
    {
      WorldContainer myWorld = this.GetMyWorld();
      if (!(bool) (UnityEngine.Object) myWorld)
        return false;
      int parentWorldId = myWorld.ParentWorldId;
      int id = myWorld.id;
      return (bool) (UnityEngine.Object) myWorld.GetComponent<Clustercraft>() && parentWorldId == id;
    }
  }

  public class States : GameStateMachine<StarryEyed.States, StarryEyed.StatesInstance, StarryEyed>
  {
    public GameStateMachine<StarryEyed.States, StarryEyed.StatesInstance, StarryEyed, object>.State idle;
    public GameStateMachine<StarryEyed.States, StarryEyed.StatesInstance, StarryEyed, object>.State inSpace;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.idle;
      this.root.Enter((StateMachine<StarryEyed.States, StarryEyed.StatesInstance, StarryEyed, object>.State.Callback) (smi =>
      {
        if (!smi.IsInSpace())
          return;
        smi.GoTo((StateMachine.BaseState) this.inSpace);
      }));
      this.idle.EventTransition(GameHashes.MinionMigration, (Func<StarryEyed.StatesInstance, KMonoBehaviour>) (smi => (KMonoBehaviour) Game.Instance), this.inSpace, (StateMachine<StarryEyed.States, StarryEyed.StatesInstance, StarryEyed, object>.Transition.ConditionCallback) (smi => smi.IsInSpace()));
      this.inSpace.EventTransition(GameHashes.MinionMigration, (Func<StarryEyed.StatesInstance, KMonoBehaviour>) (smi => (KMonoBehaviour) Game.Instance), this.idle, (StateMachine<StarryEyed.States, StarryEyed.StatesInstance, StarryEyed, object>.Transition.ConditionCallback) (smi => !smi.IsInSpace())).ToggleEffect(nameof (StarryEyed));
    }
  }
}
