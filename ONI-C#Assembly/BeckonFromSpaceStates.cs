// Decompiled with JetBrains decompiler
// Type: BeckonFromSpaceStates
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
internal class BeckonFromSpaceStates : 
  GameStateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>
{
  public BeckonFromSpaceStates.BeckoningState beckoning;
  public GameStateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.State behaviourcomplete;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.beckoning;
    this.beckoning.ToggleMainStatusItem(Db.Get().CreatureStatusItems.Beckoning).DefaultState(this.beckoning.pre);
    this.beckoning.pre.PlayAnim("beckoning_pre").OnAnimQueueComplete(this.beckoning.loop);
    this.beckoning.loop.PlayAnim("beckoning_loop").Enter(new StateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.State.Callback(BeckonFromSpaceStates.MooEchoFX)).OnAnimQueueComplete(this.beckoning.pst);
    this.beckoning.pst.PlayAnim("beckoning_pst").OnAnimQueueComplete(this.behaviourcomplete);
    this.behaviourcomplete.PlayAnim("idle_loop", KAnim.PlayMode.Loop).Enter(new StateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.State.Callback(BeckonFromSpaceStates.DoBeckon)).Enter(new StateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.State.Callback(BeckonFromSpaceStates.MooCheer)).BehaviourComplete(GameTags.Creatures.WantsToBeckon);
  }

  private static void MooEchoFX(BeckonFromSpaceStates.Instance smi)
  {
    KBatchedAnimController effect = FXHelpers.CreateEffect("moo_call_fx_kanim", smi.master.transform.position);
    effect.destroyOnAnimComplete = true;
    effect.Play((HashedString) "moo_call");
  }

  private static void MooCheer(BeckonFromSpaceStates.Instance smi)
  {
    Vector3 position = smi.transform.GetPosition();
    ListPool<ScenePartitionerEntry, BeckonFromSpaceStates>.PooledList gathered_entries = ListPool<ScenePartitionerEntry, BeckonFromSpaceStates>.Allocate();
    GameScenePartitioner.Instance.GatherEntries(new Extents((int) position.x, (int) position.y, 15), GameScenePartitioner.Instance.pickupablesLayer, (List<ScenePartitionerEntry>) gathered_entries);
    foreach (ScenePartitionerEntry partitionerEntry in (List<ScenePartitionerEntry>) gathered_entries)
    {
      KPrefabID kprefabId = (partitionerEntry.obj as Pickupable).KPrefabID;
      if (!((Object) kprefabId.gameObject == (Object) smi.gameObject) && kprefabId.HasTag((Tag) "Moo") && kprefabId.GetSMI<AnimInterruptMonitor.Instance>() != null)
        kprefabId.GetSMI<AnimInterruptMonitor.Instance>().PlayAnimSequence(smi.def.choirAnims);
    }
    gathered_entries.Recycle();
  }

  private static void DoBeckon(BeckonFromSpaceStates.Instance smi)
  {
    Db.Get().Amounts.Beckoning.Lookup(smi.gameObject).value = 0.0f;
    WorldContainer myWorld = smi.GetMyWorld();
    Vector3 position1 = smi.transform.position;
    float y = (float) (myWorld.Height + myWorld.WorldOffset.y - 1);
    float layerZ = Grid.GetLayerZ(smi.def.sceneLayer);
    float num1 = (y - position1.y) * Mathf.Tan(0.2617994f);
    double num2 = (double) position1.x + (double) Random.Range(-5, 5);
    float num3 = (float) num2 - num1;
    float num4 = (float) num2 + num1;
    float x = position1.x;
    bool state = false;
    if ((double) num3 > (double) myWorld.WorldOffset.x && (double) num3 < (double) (myWorld.WorldOffset.x + myWorld.Width))
    {
      x = num3;
      state = false;
    }
    else if ((double) num3 > (double) myWorld.WorldOffset.x && (double) num3 < (double) (myWorld.WorldOffset.x + myWorld.Width))
    {
      x = num4;
      state = true;
    }
    DebugUtil.DevAssert(myWorld.ContainsPoint(new Vector2(x, y)), "Gassy Moo spawned outside world bounds");
    Vector3 position2 = new Vector3(x, y, layerZ);
    GameObject gameObject = Util.KInstantiate(Assets.GetPrefab((Tag) smi.def.prefab), position2, Quaternion.identity);
    GassyMooComet component = gameObject.GetComponent<GassyMooComet>();
    if ((Object) component != (Object) null)
    {
      component.spawnWithOffset = true;
      if ((double) x != (double) position1.x)
        component.SetCustomInitialFlip(state);
    }
    gameObject.SetActive(true);
  }

  public class Def : StateMachine.BaseDef
  {
    public string prefab;
    public Grid.SceneLayer sceneLayer;
    public HashedString[] choirAnims = new HashedString[1]
    {
      (HashedString) "reply_loop"
    };
  }

  public new class Instance : 
    GameStateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.GameInstance
  {
    public Instance(Chore<BeckonFromSpaceStates.Instance> chore, BeckonFromSpaceStates.Def def)
      : base((IStateMachineTarget) chore, def)
    {
      chore.AddPrecondition(ChorePreconditions.instance.CheckBehaviourPrecondition, (object) GameTags.Creatures.WantsToBeckon);
    }
  }

  public class BeckoningState : 
    GameStateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.State
  {
    public GameStateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.State pre;
    public GameStateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.State loop;
    public GameStateMachine<BeckonFromSpaceStates, BeckonFromSpaceStates.Instance, IStateMachineTarget, BeckonFromSpaceStates.Def>.State pst;
  }
}
