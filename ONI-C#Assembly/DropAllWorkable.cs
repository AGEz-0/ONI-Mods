﻿// Decompiled with JetBrains decompiler
// Type: DropAllWorkable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/DropAllWorkable")]
public class DropAllWorkable : Workable
{
  [Serialize]
  private bool markedForDrop;
  private Chore _chore;
  private bool showCmd;
  private Storage[] storages;
  public float dropWorkTime = 0.1f;
  public string choreTypeID;
  [MyCmpAdd]
  private Prioritizable _prioritizable;
  public List<Tag> removeTags;
  public bool resetTargetWorkableOnCompleteWork;
  private static readonly EventSystem.IntraObjectHandler<DropAllWorkable> OnRefreshUserMenuDelegate = new EventSystem.IntraObjectHandler<DropAllWorkable>((Action<DropAllWorkable, object>) ((component, data) => component.OnRefreshUserMenu(data)));
  private static readonly EventSystem.IntraObjectHandler<DropAllWorkable> OnStorageChangeDelegate = new EventSystem.IntraObjectHandler<DropAllWorkable>((Action<DropAllWorkable, object>) ((component, data) => component.OnStorageChange(data)));
  private Guid statusItem;

  private Chore Chore
  {
    get => this._chore;
    set
    {
      this._chore = value;
      this.markedForDrop = this._chore != null;
    }
  }

  protected DropAllWorkable() => this.SetOffsetTable(OffsetGroups.InvertedStandardTable);

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe<DropAllWorkable>(493375141, DropAllWorkable.OnRefreshUserMenuDelegate);
    this.Subscribe<DropAllWorkable>(-1697596308, DropAllWorkable.OnStorageChangeDelegate);
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Emptying;
    this.synchronizeAnims = false;
    this.SetWorkTime(this.dropWorkTime);
    Prioritizable.AddRef(this.gameObject);
  }

  private Storage[] GetStorages()
  {
    if (this.storages == null)
      this.storages = this.GetComponents<Storage>();
    return this.storages;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.showCmd = this.GetNewShowCmd();
    if (!this.markedForDrop)
      return;
    this.DropAll();
  }

  public void DropAll()
  {
    if (DebugHandler.InstantBuildMode)
      this.OnCompleteWork((WorkerBase) null);
    else if (this.Chore == null)
    {
      this.Chore = (Chore) new WorkChore<DropAllWorkable>(!string.IsNullOrEmpty(this.choreTypeID) ? Db.Get().ChoreTypes.Get(this.choreTypeID) : Db.Get().ChoreTypes.EmptyStorage, (IStateMachineTarget) this, only_when_operational: false);
    }
    else
    {
      this.Chore.Cancel("Cancelled emptying");
      this.Chore = (Chore) null;
      this.GetComponent<KSelectable>().RemoveStatusItem(this.workerStatusItem);
      this.ShowProgressBar(false);
    }
    this.RefreshStatusItem();
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    Storage[] storages = this.GetStorages();
    for (int index1 = 0; index1 < storages.Length; ++index1)
    {
      List<GameObject> gameObjectList = new List<GameObject>((IEnumerable<GameObject>) storages[index1].items);
      for (int index2 = 0; index2 < gameObjectList.Count; ++index2)
      {
        GameObject go = storages[index1].Drop(gameObjectList[index2], true);
        if ((UnityEngine.Object) go != (UnityEngine.Object) null)
        {
          foreach (Tag removeTag in this.removeTags)
            go.RemoveTag(removeTag);
          go.Trigger(580035959, (object) worker);
          if (this.resetTargetWorkableOnCompleteWork)
          {
            Pickupable component;
            component.targetWorkable = (Workable) (component = go.GetComponent<Pickupable>());
            component.SetOffsetTable(OffsetGroups.InvertedStandardTable);
          }
        }
      }
    }
    this.Chore = (Chore) null;
    this.RefreshStatusItem();
    this.Trigger(-1957399615, (object) null);
  }

  private void OnRefreshUserMenu(object data)
  {
    if (!this.showCmd)
      return;
    Game.Instance.userMenu.AddButton(this.gameObject, this.Chore == null ? new KIconButtonMenu.ButtonInfo("action_empty_contents", (string) UI.USERMENUACTIONS.EMPTYSTORAGE.NAME, new System.Action(this.DropAll), tooltipText: (string) UI.USERMENUACTIONS.EMPTYSTORAGE.TOOLTIP) : new KIconButtonMenu.ButtonInfo("action_empty_contents", (string) UI.USERMENUACTIONS.EMPTYSTORAGE.NAME_OFF, new System.Action(this.DropAll), tooltipText: (string) UI.USERMENUACTIONS.EMPTYSTORAGE.TOOLTIP_OFF));
  }

  private bool GetNewShowCmd()
  {
    bool newShowCmd = false;
    foreach (Storage storage in this.GetStorages())
      newShowCmd = newShowCmd || !storage.IsEmpty();
    return newShowCmd;
  }

  private void OnStorageChange(object data)
  {
    bool newShowCmd = this.GetNewShowCmd();
    if (newShowCmd == this.showCmd)
      return;
    this.showCmd = newShowCmd;
    Game.Instance.userMenu.Refresh(this.gameObject);
  }

  private void RefreshStatusItem()
  {
    if (this.Chore != null && this.statusItem == Guid.Empty)
    {
      this.statusItem = this.GetComponent<KSelectable>().AddStatusItem(Db.Get().BuildingStatusItems.AwaitingEmptyBuilding);
    }
    else
    {
      if (this.Chore != null || !(this.statusItem != Guid.Empty))
        return;
      this.statusItem = this.GetComponent<KSelectable>().RemoveStatusItem(this.statusItem);
    }
  }
}
