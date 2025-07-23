// Decompiled with JetBrains decompiler
// Type: CreatureDeliveryPoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CreatureDeliveryPoint : StateMachineComponent<CreatureDeliveryPoint.SMInstance>
{
  [MyCmpAdd]
  private Prioritizable prioritizable;
  [MyCmpReq]
  public BaggableCritterCapacityTracker critterCapacity;
  [Obsolete]
  [Serialize]
  private int creatureLimit = 20;
  public CellOffset[] deliveryOffsets = new CellOffset[1];
  public CellOffset spawnOffset = new CellOffset(0, 0);
  public CellOffset largeCritterSpawnOffset = new CellOffset(0, 0);
  private List<FetchOrder2> fetches;
  public bool playAnimsOnFetch;
  private LogicPorts logicPorts;
  private static readonly EventSystem.IntraObjectHandler<CreatureDeliveryPoint> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<CreatureDeliveryPoint>((Action<CreatureDeliveryPoint, object>) ((component, data) => component.OnCopySettings(data)));
  private static readonly EventSystem.IntraObjectHandler<CreatureDeliveryPoint> RefreshCreatureCountDelegate = new EventSystem.IntraObjectHandler<CreatureDeliveryPoint>((Action<CreatureDeliveryPoint, object>) ((component, data) => component.critterCapacity.RefreshCreatureCount(data)));

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.fetches = new List<FetchOrder2>();
    this.GetComponent<TreeFilterable>().OnFilterChanged += new Action<HashSet<Tag>>(this.OnFilterChanged);
    this.GetComponent<Storage>().SetOffsets(this.deliveryOffsets);
    Prioritizable.AddRef(this.gameObject);
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.smi.StartSM();
    this.Subscribe<CreatureDeliveryPoint>(-905833192, CreatureDeliveryPoint.OnCopySettingsDelegate);
    this.Subscribe<CreatureDeliveryPoint>(643180843, CreatureDeliveryPoint.RefreshCreatureCountDelegate);
    this.critterCapacity = this.GetComponent<BaggableCritterCapacityTracker>();
    this.critterCapacity.onCountChanged += new System.Action(this.RebalanceFetches);
    this.critterCapacity.RefreshCreatureCount();
    this.logicPorts = this.GetComponent<LogicPorts>();
    if (!((UnityEngine.Object) this.logicPorts != (UnityEngine.Object) null))
      return;
    this.logicPorts.Subscribe(-801688580, new Action<object>(this.OnLogicChanged));
  }

  private void OnLogicChanged(object data)
  {
    LogicValueChanged logicValueChanged = (LogicValueChanged) data;
    if (!(logicValueChanged.portID == (HashedString) "CritterDropOffInput"))
      return;
    if (logicValueChanged.newValue > 0)
      this.RebalanceFetches();
    else
      this.ClearFetches();
  }

  [Obsolete]
  [System.Runtime.Serialization.OnDeserialized]
  private void OnDeserialized()
  {
    if (!((UnityEngine.Object) this.critterCapacity != (UnityEngine.Object) null) || this.creatureLimit <= 0)
      return;
    this.critterCapacity.creatureLimit = this.creatureLimit;
    this.creatureLimit = -1;
  }

  private void OnCopySettings(object data)
  {
    GameObject gameObject = (GameObject) data;
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null || (UnityEngine.Object) gameObject.GetComponent<CreatureDeliveryPoint>() == (UnityEngine.Object) null)
      return;
    this.RebalanceFetches();
  }

  private void OnFilterChanged(HashSet<Tag> tags)
  {
    this.ClearFetches();
    this.RebalanceFetches();
  }

  private void ClearFetches()
  {
    for (int index = this.fetches.Count - 1; index >= 0; --index)
      this.fetches[index].Cancel("clearing all fetches");
    this.fetches.Clear();
  }

  private void RebalanceFetches()
  {
    if (!this.LogicEnabled())
      return;
    HashSet<Tag> tags = this.GetComponent<TreeFilterable>().GetTags();
    ChoreType creatureFetch = Db.Get().ChoreTypes.CreatureFetch;
    Storage component = this.GetComponent<Storage>();
    int num1 = this.critterCapacity.creatureLimit - this.critterCapacity.storedCreatureCount;
    int count = this.fetches.Count;
    int num2 = 0;
    int num3 = 0;
    int num4 = 0;
    int num5 = 0;
    for (int index = this.fetches.Count - 1; index >= 0; --index)
    {
      if (this.fetches[index].IsComplete())
      {
        this.fetches.RemoveAt(index);
        ++num2;
      }
    }
    int num6 = 0;
    for (int index = 0; index < this.fetches.Count; ++index)
    {
      if (!this.fetches[index].InProgress)
        ++num6;
    }
    if (num6 == 0 && this.fetches.Count < num1)
    {
      float minimumFetchAmount = FetchChore.GetMinimumFetchAmount(tags);
      FetchOrder2 fetchOrder2 = new FetchOrder2(creatureFetch, tags, FetchChore.MatchCriteria.MatchID, GameTags.Creatures.Deliverable, (Tag[]) null, component, minimumFetchAmount, Operational.State.Operational);
      fetchOrder2.validateRequiredTagOnTagChange = true;
      fetchOrder2.Submit(new Action<FetchOrder2, Pickupable>(this.OnFetchComplete), false, new Action<FetchOrder2, Pickupable>(this.OnFetchBegun));
      this.fetches.Add(fetchOrder2);
      int num7 = num3 + 1;
    }
    int num8 = this.fetches.Count - num1;
    for (int index = this.fetches.Count - 1; index >= 0 && num8 > 0; --index)
    {
      if (!this.fetches[index].InProgress)
      {
        this.fetches[index].Cancel("fewer creatures in room");
        this.fetches.RemoveAt(index);
        --num8;
        ++num4;
      }
    }
    while (num8 > 0 && this.fetches.Count > 0)
    {
      this.fetches[this.fetches.Count - 1].Cancel("fewer creatures in room");
      this.fetches.RemoveAt(this.fetches.Count - 1);
      --num8;
      ++num5;
    }
  }

  private void OnFetchComplete(FetchOrder2 fetchOrder, Pickupable fetchedItem)
  {
    this.RebalanceFetches();
  }

  private void OnFetchBegun(FetchOrder2 fetchOrder, Pickupable fetchedItem)
  {
    this.RebalanceFetches();
  }

  protected override void OnCleanUp()
  {
    this.smi.StopSM(nameof (OnCleanUp));
    this.GetComponent<TreeFilterable>().OnFilterChanged -= new Action<HashSet<Tag>>(this.OnFilterChanged);
    base.OnCleanUp();
  }

  public bool LogicEnabled()
  {
    return (UnityEngine.Object) this.logicPorts == (UnityEngine.Object) null || !this.logicPorts.IsPortConnected((HashedString) "CritterDropOffInput") || this.logicPorts.GetInputValue((HashedString) "CritterDropOffInput") == 1;
  }

  public class SMInstance(CreatureDeliveryPoint master) : 
    GameStateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.GameInstance(master)
  {
  }

  public class States : 
    GameStateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint>
  {
    public CreatureDeliveryPoint.States.OperationalState operational;
    public GameStateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.State unoperational;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.operational.waiting;
      this.root.Update("RefreshCreatureCount", (Action<CreatureDeliveryPoint.SMInstance, float>) ((smi, dt) => smi.master.critterCapacity.RefreshCreatureCount()), UpdateRate.SIM_1000ms).EventHandler(GameHashes.OnStorageChange, new StateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.State.Callback(CreatureDeliveryPoint.States.DropAllCreatures));
      this.unoperational.EventTransition(GameHashes.LogicEvent, (GameStateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.State) this.operational, (StateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.Transition.ConditionCallback) (smi => smi.master.LogicEnabled()));
      this.operational.EventTransition(GameHashes.LogicEvent, this.unoperational, (StateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.Transition.ConditionCallback) (smi => !smi.master.LogicEnabled()));
      this.operational.waiting.EnterTransition(this.operational.interact_waiting, (StateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.Transition.ConditionCallback) (smi => smi.master.playAnimsOnFetch));
      this.operational.interact_waiting.WorkableStartTransition((Func<CreatureDeliveryPoint.SMInstance, Workable>) (smi => (Workable) smi.master.GetComponent<Storage>()), this.operational.interact_delivery);
      this.operational.interact_delivery.PlayAnim("working_pre").QueueAnim("working_pst").OnAnimQueueComplete(this.operational.interact_waiting);
    }

    public static void DropAllCreatures(CreatureDeliveryPoint.SMInstance smi)
    {
      Storage component1 = smi.master.GetComponent<Storage>();
      if (component1.IsEmpty())
        return;
      List<GameObject> items = component1.items;
      int count = items.Count;
      Vector3 posCbc1 = Grid.CellToPosCBC(Grid.OffsetCell(Grid.PosToCell(smi.transform.GetPosition()), smi.master.spawnOffset), Grid.SceneLayer.Creatures);
      Vector3 posCbc2 = Grid.CellToPosCBC(Grid.OffsetCell(Grid.PosToCell(smi.transform.GetPosition()), smi.master.largeCritterSpawnOffset), Grid.SceneLayer.Creatures);
      for (int index = count - 1; index >= 0; --index)
      {
        GameObject go = items[index];
        component1.Drop(go, true);
        KPrefabID component2 = go.GetComponent<KPrefabID>();
        if ((UnityEngine.Object) component2 == (UnityEngine.Object) null || !component2.HasTag(GameTags.LargeCreature))
          go.transform.SetPosition(posCbc1);
        else
          go.transform.SetPosition(posCbc2);
        go.GetComponent<KBatchedAnimController>().SetSceneLayer(Grid.SceneLayer.Creatures);
      }
      smi.master.critterCapacity.RefreshCreatureCount();
    }

    public class OperationalState : 
      GameStateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.State
    {
      public GameStateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.State waiting;
      public GameStateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.State interact_waiting;
      public GameStateMachine<CreatureDeliveryPoint.States, CreatureDeliveryPoint.SMInstance, CreatureDeliveryPoint, object>.State interact_delivery;
    }
  }
}
