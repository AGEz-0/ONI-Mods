﻿// Decompiled with JetBrains decompiler
// Type: FetchAreaChore
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
public class FetchAreaChore : Chore<FetchAreaChore.StatesInstance>
{
  public bool IsFetching => this.smi.pickingup;

  public bool IsDelivering => this.smi.delivering;

  public GameObject GetFetchTarget => this.smi.sm.fetchTarget.Get(this.smi);

  public FetchAreaChore(Chore.Precondition.Context context)
    : base(context.chore.choreType, (IStateMachineTarget) context.consumerState.consumer, context.consumerState.choreProvider, false, master_priority_class: context.masterPriority.priority_class, master_priority_value: context.masterPriority.priority_value)
  {
    this.showAvailabilityInHoverText = false;
    this.smi = new FetchAreaChore.StatesInstance(this, context);
  }

  public override void Cleanup() => base.Cleanup();

  public override void Begin(Chore.Precondition.Context context)
  {
    this.smi.Begin(context);
    base.Begin(context);
  }

  protected override void End(string reason)
  {
    this.smi.End();
    base.End(reason);
  }

  private void OnTagsChanged(object data)
  {
    if (!((UnityEngine.Object) this.smi.sm.fetchTarget.Get(this.smi) != (UnityEngine.Object) null))
      return;
    this.Fail("Tags changed");
  }

  private static bool IsPickupableStillValidForChore(Pickupable pickupable, FetchChore chore)
  {
    KPrefabID kprefabId = pickupable.KPrefabID;
    if (chore.criteria == FetchChore.MatchCriteria.MatchID && !chore.tags.Contains(kprefabId.PrefabTag) || chore.criteria == FetchChore.MatchCriteria.MatchTags && !kprefabId.HasTag(chore.tagsFirst))
    {
      Debug.Log((object) $"Pickupable {pickupable} is not valid for chore because it is not or does not contain one of these tags: {string.Join<Tag>(",", (IEnumerable<Tag>) chore.tags)}");
      return false;
    }
    if (chore.requiredTag.IsValid && !kprefabId.HasTag(chore.requiredTag))
    {
      Debug.Log((object) $"Pickupable {pickupable} is not valid for chore because it does not have the required tag: {chore.requiredTag}");
      return false;
    }
    if (!kprefabId.HasAnyTags(chore.forbiddenTags))
      return pickupable.isChoreAllowedToPickup(chore.choreType);
    Debug.Log((object) $"Pickupable {pickupable} is not valid for chore because it has the forbidden tags: {string.Join<Tag>(",", (IEnumerable<Tag>) chore.forbiddenTags)}");
    return false;
  }

  public static void GatherNearbyFetchChores(
    FetchChore root_chore,
    Chore.Precondition.Context context,
    int x,
    int y,
    int radius,
    List<Chore.Precondition.Context> succeeded_contexts,
    List<Chore.Precondition.Context> failed_contexts)
  {
    ListPool<ScenePartitionerEntry, FetchAreaChore>.PooledList gathered_entries = ListPool<ScenePartitionerEntry, FetchAreaChore>.Allocate();
    GameScenePartitioner.Instance.GatherEntries(x - radius, y - radius, radius * 2 + 1, radius * 2 + 1, GameScenePartitioner.Instance.fetchChoreLayer, (List<ScenePartitionerEntry>) gathered_entries);
    for (int index = 0; index < gathered_entries.Count; ++index)
      (gathered_entries[index].obj as FetchChore).CollectChoresFromGlobalChoreProvider(context.consumerState, succeeded_contexts, (List<Chore.Precondition.Context>) null, failed_contexts, true);
    gathered_entries.Recycle();
  }

  public class StatesInstance : 
    GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.GameInstance
  {
    private List<FetchChore> chores = new List<FetchChore>();
    private List<Pickupable> fetchables = new List<Pickupable>();
    private List<FetchAreaChore.StatesInstance.Reservation> reservations = new List<FetchAreaChore.StatesInstance.Reservation>();
    private List<Pickupable> deliverables = new List<Pickupable>();
    public List<FetchAreaChore.StatesInstance.Delivery> deliveries = new List<FetchAreaChore.StatesInstance.Delivery>();
    private FetchChore rootChore;
    private Chore.Precondition.Context rootContext;
    private float fetchAmountRequested;
    public bool delivering;
    public bool pickingup;
    private static Tag[] s_transientDeliveryTags = new Tag[2]
    {
      GameTags.Garbage,
      GameTags.Creatures.Deliverable
    };

    public Tag RootChore_RequiredTag => this.rootChore.requiredTag;

    public bool RootChore_ValidateRequiredTagOnTagChange
    {
      get => this.rootChore.validateRequiredTagOnTagChange;
    }

    public StatesInstance(FetchAreaChore master, Chore.Precondition.Context context)
      : base(master)
    {
      this.rootContext = context;
      this.rootChore = context.chore as FetchChore;
    }

    public void Begin(Chore.Precondition.Context context)
    {
      this.sm.fetcher.Set(context.consumerState.gameObject, this.smi, false);
      this.chores.Clear();
      this.chores.Add(this.rootChore);
      int x1;
      int y1;
      Grid.CellToXY(Grid.PosToCell(this.rootChore.destination.transform.GetPosition()), out x1, out y1);
      ListPool<Chore.Precondition.Context, FetchAreaChore>.PooledList succeeded_contexts = ListPool<Chore.Precondition.Context, FetchAreaChore>.Allocate();
      ListPool<Chore.Precondition.Context, FetchAreaChore>.PooledList failed_contexts = ListPool<Chore.Precondition.Context, FetchAreaChore>.Allocate();
      if (this.rootChore.allowMultifetch)
        FetchAreaChore.GatherNearbyFetchChores(this.rootChore, context, x1, y1, 3, (List<Chore.Precondition.Context>) succeeded_contexts, (List<Chore.Precondition.Context>) failed_contexts);
      float max_carry_weight = Mathf.Max(1f, Db.Get().Attributes.CarryAmount.Lookup((Component) context.consumerState.consumer).GetTotalValue());
      Pickupable root_fetchable = context.data as Pickupable;
      if ((UnityEngine.Object) root_fetchable == (UnityEngine.Object) null)
      {
        Debug.Assert(succeeded_contexts.Count > 0, (object) "succeeded_contexts was empty");
        FetchChore chore = (FetchChore) succeeded_contexts[0].chore;
        Debug.Assert(chore != null, (object) "fetch_chore was null");
        DebugUtil.LogWarningArgs((object) "Missing root_fetchable for FetchAreaChore", (object) chore.destination, (object) chore.tagsFirst);
        root_fetchable = chore.FindFetchTarget(context.consumerState);
      }
      Debug.Assert((UnityEngine.Object) root_fetchable != (UnityEngine.Object) null, (object) "root_fetchable was null");
      ListPool<Pickupable, FetchAreaChore>.PooledList potential_fetchables = ListPool<Pickupable, FetchAreaChore>.Allocate();
      potential_fetchables.Add(root_fetchable);
      float fetch_amount_available = root_fetchable.UnreservedFetchAmount;
      max_carry_weight = Mathf.Max(root_fetchable.PrimaryElement.MassPerUnit, max_carry_weight);
      float minTakeAmount = root_fetchable.MinTakeAmount;
      int x2 = 0;
      int y2 = 0;
      Grid.CellToXY(Grid.PosToCell(root_fetchable.transform.GetPosition()), out x2, out y2);
      int num1 = 9;
      x2 -= 3;
      int y3 = y2 - 3;
      Tag root_fetchable_tag = root_fetchable.GetComponent<KPrefabID>().PrefabTag;
      Func<object, object, bool> visitor = (Func<object, object, bool>) ((obj, _) =>
      {
        if ((double) fetch_amount_available > (double) max_carry_weight)
          return false;
        Pickupable pickup = obj as Pickupable;
        KPrefabID kprefabId = pickup.KPrefabID;
        if ((UnityEngine.Object) pickup == (UnityEngine.Object) root_fetchable || kprefabId.HasTag(GameTags.StoredPrivate) || kprefabId.PrefabTag != root_fetchable_tag || (double) pickup.UnreservedFetchAmount <= 0.0 || this.rootChore.criteria == FetchChore.MatchCriteria.MatchID && !this.rootChore.tags.Contains(kprefabId.PrefabTag) || this.rootChore.criteria == FetchChore.MatchCriteria.MatchTags && !kprefabId.HasTag(this.rootChore.tagsFirst) || this.rootChore.requiredTag.IsValid && !kprefabId.HasTag(this.rootChore.requiredTag) || kprefabId.HasAnyTags(this.rootChore.forbiddenTags) || potential_fetchables.Contains(pickup) || !this.rootContext.consumerState.consumer.CanReach((IApproachable) pickup) || kprefabId.HasTag(GameTags.MarkedForMove))
          return true;
        if (!pickup.storage.IsNullOrDestroyed())
        {
          bool flag = true;
          foreach (Chore.Precondition.Context context1 in (List<Chore.Precondition.Context>) succeeded_contexts)
          {
            FetchChore chore = context1.chore as FetchChore;
            if (!FetchManager.IsFetchablePickup(pickup, chore, chore.destination))
            {
              flag = false;
              break;
            }
          }
          if (!flag)
            return true;
        }
        float unreservedFetchAmount = pickup.UnreservedFetchAmount;
        potential_fetchables.Add(pickup);
        fetch_amount_available += unreservedFetchAmount;
        return potential_fetchables.Count < 10;
      });
      GameScenePartitioner.Instance.AsyncSafeVisit<object>(x2, y3, num1, num1, GameScenePartitioner.Instance.pickupablesLayer, visitor, (object) null);
      GameScenePartitioner.Instance.AsyncSafeVisit<object>(x2, y3, num1, num1, GameScenePartitioner.Instance.storedPickupablesLayer, visitor, (object) null);
      fetch_amount_available = Mathf.Min(max_carry_weight, fetch_amount_available);
      if ((double) minTakeAmount > 0.0)
        fetch_amount_available -= fetch_amount_available % minTakeAmount;
      this.deliveries.Clear();
      float amount_to_be_fetched1 = Mathf.Min(this.rootChore.originalAmount, fetch_amount_available);
      if ((double) minTakeAmount > 0.0)
        amount_to_be_fetched1 -= amount_to_be_fetched1 % minTakeAmount;
      this.deliveries.Add(new FetchAreaChore.StatesInstance.Delivery(this.rootContext, amount_to_be_fetched1, new Action<FetchChore>(this.OnFetchChoreCancelled)));
      float a = amount_to_be_fetched1;
      for (int index = 0; index < succeeded_contexts.Count && (double) a < (double) fetch_amount_available; ++index)
      {
        Chore.Precondition.Context context2 = succeeded_contexts[index];
        FetchChore chore = context2.chore as FetchChore;
        if (chore != this.rootChore && (UnityEngine.Object) chore.overrideTarget == (UnityEngine.Object) null && (UnityEngine.Object) chore.driver == (UnityEngine.Object) null && chore.tagsHash == this.rootChore.tagsHash && chore.requiredTag == this.rootChore.requiredTag && chore.forbidHash == this.rootChore.forbidHash)
        {
          float amount_to_be_fetched2 = Mathf.Min(chore.originalAmount, fetch_amount_available - a);
          if ((double) minTakeAmount > 0.0)
            amount_to_be_fetched2 -= amount_to_be_fetched2 % minTakeAmount;
          this.chores.Add(chore);
          this.deliveries.Add(new FetchAreaChore.StatesInstance.Delivery(context2, amount_to_be_fetched2, new Action<FetchChore>(this.OnFetchChoreCancelled)));
          a += amount_to_be_fetched2;
          if (this.deliveries.Count >= 10)
            break;
        }
      }
      float num2 = Mathf.Min(a, fetch_amount_available);
      float num3 = num2;
      this.fetchables.Clear();
      for (int index = 0; index < potential_fetchables.Count && (double) num3 > 0.0; ++index)
      {
        Pickupable pickupable = potential_fetchables[index];
        num3 -= pickupable.UnreservedFetchAmount;
        this.fetchables.Add(pickupable);
      }
      this.fetchAmountRequested = num2;
      this.reservations.Clear();
      succeeded_contexts.Recycle();
      failed_contexts.Recycle();
      potential_fetchables.Recycle();
    }

    public void End()
    {
      foreach (FetchAreaChore.StatesInstance.Delivery delivery in this.deliveries)
        delivery.Cleanup();
      this.deliveries.Clear();
    }

    public void SetupDelivery()
    {
      if (this.deliveries.Count == 0)
      {
        this.StopSM("FetchAreaChoreComplete");
      }
      else
      {
        FetchAreaChore.StatesInstance.Delivery nextDelivery = this.deliveries[0];
        if (((IEnumerable<Tag>) FetchAreaChore.StatesInstance.s_transientDeliveryTags).Contains<Tag>(nextDelivery.chore.requiredTag))
          nextDelivery.chore.requiredTag = Tag.Invalid;
        this.deliverables.RemoveAll((Predicate<Pickupable>) (x =>
        {
          if ((UnityEngine.Object) x == (UnityEngine.Object) null || (double) x.FetchTotalAmount <= 0.0 || x.KPrefabID.HasTag(GameTags.MarkedForMove))
            return true;
          if (FetchAreaChore.IsPickupableStillValidForChore(x, nextDelivery.chore))
            return false;
          Debug.LogWarning((object) $"Removing deliverable {x} for a delivery to {nextDelivery.chore.destination} which did not request it");
          return true;
        }));
        if (this.deliverables.Count == 0)
        {
          this.StopSM("FetchAreaChoreComplete");
        }
        else
        {
          this.sm.deliveryDestination.Set((KMonoBehaviour) nextDelivery.destination, this.smi);
          this.sm.deliveryObject.Set((KMonoBehaviour) this.deliverables[0], this.smi);
          if ((UnityEngine.Object) nextDelivery.destination != (UnityEngine.Object) null)
          {
            if (this.rootContext.consumerState.hasSolidTransferArm)
            {
              if (this.rootContext.consumerState.consumer.IsWithinReach((IApproachable) this.deliveries[0].destination))
                this.GoTo((StateMachine.BaseState) this.sm.delivering.storing);
              else
                this.GoTo((StateMachine.BaseState) this.sm.delivering.deliverfail);
            }
            else
              this.GoTo((StateMachine.BaseState) this.sm.delivering.movetostorage);
          }
          else
            this.smi.GoTo((StateMachine.BaseState) this.sm.delivering.deliverfail);
        }
      }
    }

    public void SetupFetch()
    {
      if (this.reservations.Count > 0)
      {
        this.SetFetchTarget(this.reservations[0].pickupable);
        this.sm.fetchResultTarget.Set((KMonoBehaviour) null, this.smi);
        double num = (double) this.sm.fetchAmount.Set(this.reservations[0].amount, this.smi);
        if ((UnityEngine.Object) this.reservations[0].pickupable != (UnityEngine.Object) null)
        {
          if (this.rootContext.consumerState.hasSolidTransferArm)
          {
            if (this.rootContext.consumerState.consumer.IsWithinReach((IApproachable) this.reservations[0].pickupable))
              this.GoTo((StateMachine.BaseState) this.sm.fetching.pickup);
            else
              this.GoTo((StateMachine.BaseState) this.sm.fetching.fetchfail);
          }
          else
            this.GoTo((StateMachine.BaseState) this.sm.fetching.movetopickupable);
        }
        else
          this.GoTo((StateMachine.BaseState) this.sm.fetching.fetchfail);
      }
      else
        this.GoTo((StateMachine.BaseState) this.sm.delivering.next);
    }

    public void SetFetchTarget(Pickupable fetching)
    {
      this.sm.fetchTarget.Set((KMonoBehaviour) fetching, this.smi);
      if (!((UnityEngine.Object) fetching != (UnityEngine.Object) null))
        return;
      fetching.Subscribe(1122777325, new Action<object>(this.OnMarkForMove));
    }

    public void DeliverFail()
    {
      if (this.deliveries.Count > 0)
      {
        this.deliveries[0].Cleanup();
        this.deliveries.RemoveAt(0);
      }
      this.GoTo((StateMachine.BaseState) this.sm.delivering.next);
    }

    public void DeliverComplete()
    {
      Pickupable pickupable = this.sm.deliveryObject.Get<Pickupable>(this.smi);
      if ((UnityEngine.Object) pickupable == (UnityEngine.Object) null || (double) pickupable.FetchTotalAmount <= 0.0)
      {
        if (this.deliveries.Count > 0 && (double) this.deliveries[0].chore.amount < (double) PICKUPABLETUNING.MINIMUM_PICKABLE_AMOUNT)
        {
          FetchAreaChore.StatesInstance.Delivery delivery = this.deliveries[0];
          Chore chore = (Chore) delivery.chore;
          delivery.Complete(this.deliverables);
          delivery.Cleanup();
          if (this.deliveries.Count > 0 && this.deliveries[0].chore == chore)
            this.deliveries.RemoveAt(0);
          this.GoTo((StateMachine.BaseState) this.sm.delivering.next);
        }
        else
          this.smi.GoTo((StateMachine.BaseState) this.sm.delivering.deliverfail);
      }
      else
      {
        if (this.deliveries.Count > 0)
        {
          FetchAreaChore.StatesInstance.Delivery delivery = this.deliveries[0];
          Chore chore = (Chore) delivery.chore;
          delivery.Complete(this.deliverables);
          delivery.Cleanup();
          if (this.deliveries.Count > 0 && this.deliveries[0].chore == chore)
            this.deliveries.RemoveAt(0);
        }
        this.GoTo((StateMachine.BaseState) this.sm.delivering.next);
      }
    }

    public void FetchFail()
    {
      if ((UnityEngine.Object) this.smi.sm.fetchTarget.Get(this.smi) != (UnityEngine.Object) null)
        this.smi.sm.fetchTarget.Get(this.smi).Unsubscribe(1122777325, new Action<object>(this.OnMarkForMove));
      this.reservations[0].Cleanup();
      this.reservations.RemoveAt(0);
      this.GoTo((StateMachine.BaseState) this.sm.fetching.next);
    }

    public void FetchComplete()
    {
      this.reservations[0].Cleanup();
      this.reservations.RemoveAt(0);
      this.GoTo((StateMachine.BaseState) this.sm.fetching.next);
    }

    public void SetupDeliverables()
    {
      foreach (GameObject gameObject in this.sm.fetcher.Get<Storage>(this.smi).items)
      {
        if (!((UnityEngine.Object) gameObject == (UnityEngine.Object) null))
        {
          KPrefabID component1 = gameObject.GetComponent<KPrefabID>();
          if (!((UnityEngine.Object) component1 == (UnityEngine.Object) null) && !component1.HasTag(GameTags.MarkedForMove))
          {
            Pickupable component2 = component1.GetComponent<Pickupable>();
            if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
              this.deliverables.Add(component2);
          }
        }
      }
    }

    public void ReservePickupables()
    {
      ChoreConsumer consumer = this.sm.fetcher.Get<ChoreConsumer>(this.smi);
      float fetchAmountRequested = this.fetchAmountRequested;
      foreach (Pickupable fetchable in this.fetchables)
      {
        if ((double) fetchAmountRequested <= 0.0)
          break;
        if (!fetchable.KPrefabID.HasTag(GameTags.MarkedForMove) && ((double) fetchable.PrimaryElement.MassPerUnit <= 1.0 || (double) fetchAmountRequested >= (double) fetchable.PrimaryElement.MassPerUnit))
        {
          float reservation_amount = Math.Min(fetchAmountRequested, fetchable.UnreservedFetchAmount);
          fetchAmountRequested -= reservation_amount;
          this.reservations.Add(new FetchAreaChore.StatesInstance.Reservation(consumer, fetchable, reservation_amount));
        }
      }
    }

    private void OnFetchChoreCancelled(FetchChore chore)
    {
      for (int index = 0; index < this.deliveries.Count; ++index)
      {
        if (this.deliveries[index].chore == chore)
        {
          if (this.deliveries.Count == 1)
          {
            this.StopSM("AllDelivericesCancelled");
            break;
          }
          if (index == 0)
          {
            this.sm.currentdeliverycancelled.Trigger(this);
            break;
          }
          this.deliveries[index].Cleanup();
          this.deliveries.RemoveAt(index);
          break;
        }
      }
    }

    public void UnreservePickupables()
    {
      foreach (FetchAreaChore.StatesInstance.Reservation reservation in this.reservations)
        reservation.Cleanup();
      this.reservations.Clear();
    }

    public bool SameDestination(FetchChore fetch)
    {
      foreach (FetchChore chore in this.chores)
      {
        if ((UnityEngine.Object) chore.destination == (UnityEngine.Object) fetch.destination)
          return true;
      }
      return false;
    }

    public void OnMarkForMove(object data)
    {
      GameObject gameObject = this.smi.sm.fetchTarget.Get(this.smi);
      GameObject go = data as GameObject;
      if (!((UnityEngine.Object) gameObject != (UnityEngine.Object) null))
        return;
      if ((UnityEngine.Object) gameObject == (UnityEngine.Object) go)
      {
        go.Unsubscribe(1122777325, new Action<object>(this.OnMarkForMove));
        this.smi.sm.fetchTarget.Set((KMonoBehaviour) null, this.smi);
      }
      else
        Debug.LogError((object) "Listening for MarkForMove on the incorrect fetch target. Subscriptions did not update correctly.");
    }

    public struct Delivery
    {
      private Action<FetchChore> onCancelled;
      private Action<Chore> onFetchChoreCleanup;

      public Storage destination { get; private set; }

      public float amount { get; private set; }

      public FetchChore chore { get; private set; }

      public Delivery(
        Chore.Precondition.Context context,
        float amount_to_be_fetched,
        Action<FetchChore> on_cancelled)
        : this()
      {
        this.chore = context.chore as FetchChore;
        this.amount = this.chore.originalAmount;
        this.destination = this.chore.destination;
        this.chore.SetOverrideTarget(context.consumerState.consumer);
        this.onCancelled = on_cancelled;
        this.onFetchChoreCleanup = new Action<Chore>(this.OnFetchChoreCleanup);
        this.chore.FetchAreaBegin(context, amount_to_be_fetched);
        FetchChore chore = this.chore;
        chore.onCleanup = chore.onCleanup + this.onFetchChoreCleanup;
      }

      public void Complete(List<Pickupable> deliverables)
      {
        using (new KProfiler.Region("FAC.Delivery.Complete"))
        {
          if ((UnityEngine.Object) this.destination == (UnityEngine.Object) null || this.destination.IsEndOfLife())
            return;
          FetchChore chore = this.chore;
          chore.onCleanup = chore.onCleanup - this.onFetchChoreCleanup;
          float amount = this.amount;
          Pickupable pickupable1 = (Pickupable) null;
          for (int index = 0; index < deliverables.Count && (double) amount > 0.0; ++index)
          {
            if ((UnityEngine.Object) deliverables[index] == (UnityEngine.Object) null)
            {
              if ((double) amount < (double) PICKUPABLETUNING.MINIMUM_PICKABLE_AMOUNT)
                this.destination.ForceStore(this.chore.tagsFirst, amount);
            }
            else if (!FetchAreaChore.IsPickupableStillValidForChore(deliverables[index], this.chore))
            {
              Debug.LogError((object) $"Attempting to store {deliverables[index]} in a {this.destination} which did not request it");
            }
            else
            {
              Pickupable pickupable2 = deliverables[index].Take(amount);
              if ((UnityEngine.Object) pickupable2 != (UnityEngine.Object) null && (double) pickupable2.FetchTotalAmount > 0.0)
              {
                amount -= pickupable2.FetchTotalAmount;
                this.destination.Store(pickupable2.gameObject);
                pickupable1 = pickupable2;
                if ((UnityEngine.Object) pickupable2 == (UnityEngine.Object) deliverables[index])
                  deliverables[index] = (Pickupable) null;
              }
            }
          }
          if ((UnityEngine.Object) this.chore.overrideTarget != (UnityEngine.Object) null)
            this.chore.FetchAreaEnd(this.chore.overrideTarget.GetComponent<ChoreDriver>(), pickupable1, true);
          this.chore = (FetchChore) null;
        }
      }

      private void OnFetchChoreCleanup(Chore chore)
      {
        if (this.onCancelled == null)
          return;
        this.onCancelled(chore as FetchChore);
      }

      public void Cleanup()
      {
        if (this.chore == null)
          return;
        FetchChore chore = this.chore;
        chore.onCleanup = chore.onCleanup - this.onFetchChoreCleanup;
        this.chore.FetchAreaEnd((ChoreDriver) null, (Pickupable) null, false);
      }
    }

    public struct Reservation
    {
      private int handle;

      public float amount { get; private set; }

      public Pickupable pickupable { get; private set; }

      public Reservation(ChoreConsumer consumer, Pickupable pickupable, float reservation_amount)
        : this()
      {
        if ((double) reservation_amount <= 0.0)
          Debug.LogError((object) ("Invalid amount: " + reservation_amount.ToString()));
        this.amount = reservation_amount;
        this.pickupable = pickupable;
        this.handle = pickupable.Reserve(nameof (FetchAreaChore), consumer.GetComponent<KPrefabID>().InstanceID, reservation_amount);
      }

      public void Cleanup()
      {
        if (!((UnityEngine.Object) this.pickupable != (UnityEngine.Object) null))
          return;
        this.pickupable.Unreserve(nameof (FetchAreaChore), this.handle);
      }
    }
  }

  public class States : 
    GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore>
  {
    public FetchAreaChore.States.FetchStates fetching;
    public FetchAreaChore.States.DeliverStates delivering;
    public StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.TargetParameter fetcher;
    public StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.TargetParameter fetchTarget;
    public StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.TargetParameter fetchResultTarget;
    public StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.FloatParameter fetchAmount;
    public StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.TargetParameter deliveryDestination;
    public StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.TargetParameter deliveryObject;
    public StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.FloatParameter deliveryAmount;
    public StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.Signal currentdeliverycancelled;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.fetching;
      this.Target(this.fetcher);
      this.fetching.DefaultState(this.fetching.next).Enter("ReservePickupables", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.ReservePickupables())).Exit("UnreservePickupables", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.UnreservePickupables())).Enter("pickingup-on", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.pickingup = true)).Exit("pickingup-off", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.pickingup = false));
      this.fetching.next.Enter("SetupFetch", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.SetupFetch()));
      this.fetching.movetopickupable.InitializeStates(new Func<FetchAreaChore.StatesInstance, NavTactic>(this.GetNavTactic), this.fetcher, this.fetchTarget, this.fetching.pickup, this.fetching.fetchfail).Target(this.fetchTarget).EventHandlerTransition(GameHashes.TagsChanged, this.fetching.fetchfail, (Func<FetchAreaChore.StatesInstance, object, bool>) ((smi, obj) => smi.RootChore_ValidateRequiredTagOnTagChange && smi.RootChore_RequiredTag.IsValid && !this.fetchTarget.Get(smi).HasTag(smi.RootChore_RequiredTag))).Target(this.fetcher);
      this.fetching.pickup.DoPickup(this.fetchTarget, this.fetchResultTarget, this.fetchAmount, this.fetching.fetchcomplete, this.fetching.fetchfail).Exit((StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi =>
      {
        GameObject go = smi.sm.fetchTarget.Get(smi);
        if (!((UnityEngine.Object) go != (UnityEngine.Object) null))
          return;
        go.Unsubscribe(1122777325, new Action<object>(smi.OnMarkForMove));
      }));
      this.fetching.fetchcomplete.Enter((StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.FetchComplete()));
      this.fetching.fetchfail.Enter((StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.FetchFail()));
      this.delivering.DefaultState(this.delivering.next).OnSignal(this.currentdeliverycancelled, this.delivering.deliverfail).Enter("SetupDeliverables", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.SetupDeliverables())).Enter("delivering-on", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.delivering = true)).Exit("delivering-off", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.delivering = false));
      this.delivering.next.Enter("SetupDelivery", (StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.SetupDelivery()));
      this.delivering.movetostorage.InitializeStates(new Func<FetchAreaChore.StatesInstance, NavTactic>(this.GetNavTactic), this.fetcher, this.deliveryDestination, this.delivering.storing, this.delivering.deliverfail).Enter((StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi =>
      {
        if (!((UnityEngine.Object) this.deliveryObject.Get(smi) != (UnityEngine.Object) null) || !((UnityEngine.Object) this.deliveryObject.Get(smi).GetComponent<MinionIdentity>() != (UnityEngine.Object) null))
          return;
        this.deliveryObject.Get(smi).transform.SetLocalPosition(Vector3.zero);
        KBatchedAnimTracker component = this.deliveryObject.Get(smi).GetComponent<KBatchedAnimTracker>();
        component.symbol = new HashedString("snapTo_chest");
        component.offset = new Vector3(0.0f, 0.0f, 1f);
      }));
      this.delivering.storing.DoDelivery(this.fetcher, this.deliveryDestination, this.delivering.delivercomplete, this.delivering.deliverfail);
      this.delivering.deliverfail.Enter((StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.DeliverFail()));
      this.delivering.delivercomplete.Enter((StateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State.Callback) (smi => smi.DeliverComplete()));
    }

    private NavTactic GetNavTactic(FetchAreaChore.StatesInstance smi)
    {
      WorkerBase component = this.fetcher.Get(smi).GetComponent<WorkerBase>();
      return (UnityEngine.Object) component != (UnityEngine.Object) null && component.IsFetchDrone() ? NavigationTactics.FetchDronePickup : NavigationTactics.ReduceTravelDistance;
    }

    public class FetchStates : 
      GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State
    {
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State next;
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.ApproachSubState<Pickupable> movetopickupable;
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State pickup;
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State fetchfail;
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State fetchcomplete;
    }

    public class DeliverStates : 
      GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State
    {
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State next;
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.ApproachSubState<Storage> movetostorage;
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State storing;
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State deliverfail;
      public GameStateMachine<FetchAreaChore.States, FetchAreaChore.StatesInstance, FetchAreaChore, object>.State delivercomplete;
    }
  }
}
