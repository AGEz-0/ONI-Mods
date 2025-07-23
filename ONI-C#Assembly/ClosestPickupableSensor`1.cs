// Decompiled with JetBrains decompiler
// Type: ClosestPickupableSensor`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public abstract class ClosestPickupableSensor<T> : Sensor where T : Component
{
  public Action<T> OnItemChanged;
  protected T item;
  protected int itemNavCost = int.MaxValue;
  protected Tag itemSearchTag;
  protected Tag[] requiredTags;
  protected bool isThereAnyItemAvailable;
  protected bool itemInReachButNotPermitted;
  private Navigator navigator;
  protected ConsumableConsumer consumableConsumer;
  private Storage storage;

  public ClosestPickupableSensor(Sensors sensors, Tag itemSearchTag, bool shouldStartActive)
    : base(sensors, shouldStartActive)
  {
    this.navigator = this.GetComponent<Navigator>();
    this.consumableConsumer = this.GetComponent<ConsumableConsumer>();
    this.storage = this.GetComponent<Storage>();
    this.itemSearchTag = itemSearchTag;
  }

  public T GetItem() => this.item;

  public int GetItemNavCost()
  {
    return !((UnityEngine.Object) this.item == (UnityEngine.Object) null) ? this.itemNavCost : int.MaxValue;
  }

  public virtual HashSet<Tag> GetForbbidenTags()
  {
    return !((UnityEngine.Object) this.consumableConsumer == (UnityEngine.Object) null) ? this.consumableConsumer.forbiddenTagSet : new HashSet<Tag>(0);
  }

  public override void Update()
  {
    HashSet<Tag> forbbidenTags = this.GetForbbidenTags();
    int cost = int.MaxValue;
    Pickupable closestPickupable = this.FindClosestPickupable(this.storage, forbbidenTags, out cost, this.itemSearchTag, this.requiredTags);
    bool reachButNotPermitted = this.itemInReachButNotPermitted;
    T obj = default (T);
    bool flag1 = false;
    bool flag2;
    if ((UnityEngine.Object) closestPickupable != (UnityEngine.Object) null)
    {
      obj = closestPickupable.GetComponent<T>();
      flag1 = true;
      flag2 = false;
    }
    else
      flag2 = (UnityEngine.Object) this.FindClosestPickupable(this.storage, new HashSet<Tag>(), out int _, this.itemSearchTag, this.requiredTags) != (UnityEngine.Object) null;
    if (!((UnityEngine.Object) obj != (UnityEngine.Object) this.item) && this.isThereAnyItemAvailable == flag1)
      return;
    this.item = obj;
    this.itemNavCost = cost;
    this.isThereAnyItemAvailable = flag1;
    this.itemInReachButNotPermitted = flag2;
    this.ItemChanged();
  }

  public Pickupable FindClosestPickupable(
    Storage destination,
    HashSet<Tag> exclude_tags,
    out int cost,
    Tag categoryTag,
    Tag[] otherRequiredTags = null)
  {
    ICollection<Pickupable> pickupables = this.gameObject.GetMyWorld().worldInventory.GetPickupables(categoryTag);
    if (pickupables == null)
    {
      cost = int.MaxValue;
      return (Pickupable) null;
    }
    if (otherRequiredTags == null)
      otherRequiredTags = new Tag[1]{ categoryTag };
    Pickupable closestPickupable = (Pickupable) null;
    int num = int.MaxValue;
    foreach (Pickupable pickupable in (IEnumerable<Pickupable>) pickupables)
    {
      if (FetchManager.IsFetchablePickup_Exclude(pickupable.KPrefabID, pickupable.storage, pickupable.UnreservedFetchAmount, exclude_tags, otherRequiredTags, destination))
      {
        int navigationCost = pickupable.GetNavigationCost(this.navigator, pickupable.cachedCell);
        if (navigationCost != -1 && navigationCost < num)
        {
          closestPickupable = pickupable;
          num = navigationCost;
        }
      }
    }
    cost = num;
    return closestPickupable;
  }

  public virtual void ItemChanged()
  {
    Action<T> onItemChanged = this.OnItemChanged;
    if (onItemChanged == null)
      return;
    onItemChanged(this.item);
  }
}
