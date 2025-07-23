// Decompiled with JetBrains decompiler
// Type: Movable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
[AddComponentMenu("KMonoBehaviour/Workable/Movable")]
public class Movable : Workable
{
  [MyCmpReq]
  private Pickupable pickupable;
  public Tag tagRequiredForMove = Tag.Invalid;
  [Serialize]
  private bool isMarkedForMove;
  [Serialize]
  private Ref<Storage> storageProxy;
  private int storageReachableChangedHandle = -1;
  private int reachableChangedHandle = -1;
  private int cancelHandle = -1;
  private int tagsChangedHandle = -1;
  private Guid pendingMoveGuid;
  private Guid storageUnreachableGuid;
  public Action<GameObject> onDeliveryComplete;
  public Action<GameObject> onPickupComplete;

  public bool IsMarkedForMove => this.isMarkedForMove;

  public Storage StorageProxy
  {
    get => this.storageProxy == null ? (Storage) null : this.storageProxy.Get();
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe(493375141, new Action<object>(this.OnRefreshUserMenu));
    this.Subscribe(1335436905, new Action<object>(this.OnSplitFromChunk));
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (this.isMarkedForMove)
    {
      if ((UnityEngine.Object) this.StorageProxy != (UnityEngine.Object) null)
      {
        if (this.reachableChangedHandle < 0)
          this.reachableChangedHandle = this.Subscribe(-1432940121, new Action<object>(this.OnReachableChanged));
        if (this.storageReachableChangedHandle < 0)
          this.storageReachableChangedHandle = this.StorageProxy.Subscribe(-1432940121, new Action<object>(this.OnReachableChanged));
        if (this.cancelHandle < 0)
          this.cancelHandle = this.Subscribe(2127324410, new Action<object>(this.CleanupMove));
        if (this.tagsChangedHandle < 0)
          this.tagsChangedHandle = this.Subscribe(-1582839653, new Action<object>(this.OnTagsChanged));
        this.gameObject.AddTag(GameTags.MarkedForMove);
      }
      else
        this.isMarkedForMove = false;
    }
    if (!Movable.IsCritterPickupable(this.gameObject))
      return;
    this.skillsUpdateHandle = Game.Instance.Subscribe(-1523247426, new Action<object>(((Workable) this).UpdateStatusItem));
    this.shouldShowSkillPerkStatusItem = this.isMarkedForMove;
    this.requiredSkillPerk = Db.Get().SkillPerks.CanWrangleCreatures.Id;
    this.UpdateStatusItem();
  }

  private void OnReachableChanged(object data)
  {
    if (!this.isMarkedForMove)
      return;
    if ((UnityEngine.Object) this.StorageProxy != (UnityEngine.Object) null)
    {
      int cell1 = Grid.PosToCell((KMonoBehaviour) this.pickupable);
      int cell2 = Grid.PosToCell((KMonoBehaviour) this.StorageProxy);
      if (cell1 == cell2)
        return;
      bool show = MinionGroupProber.Get().IsReachable(cell1, OffsetGroups.Standard) && MinionGroupProber.Get().IsReachable(cell2, OffsetGroups.Standard);
      if (this.pickupable.KPrefabID.HasTag(GameTags.Creatures.Confined))
        show = false;
      KSelectable component = this.GetComponent<KSelectable>();
      this.pendingMoveGuid = component.ToggleStatusItem(Db.Get().MiscStatusItems.MarkedForMove, this.pendingMoveGuid, show, (object) this);
      this.storageUnreachableGuid = component.ToggleStatusItem(Db.Get().MiscStatusItems.MoveStorageUnreachable, this.storageUnreachableGuid, !show, (object) this);
    }
    else
      this.ClearMove();
  }

  private void OnSplitFromChunk(object data)
  {
    Pickupable pickupable = data as Pickupable;
    if (!((UnityEngine.Object) pickupable != (UnityEngine.Object) null))
      return;
    Movable component = pickupable.GetComponent<Movable>();
    if (!component.isMarkedForMove)
      return;
    this.storageProxy = new Ref<Storage>(component.StorageProxy);
    this.MarkForMove();
  }

  protected override void OnCleanUp()
  {
    base.OnCleanUp();
    if (!this.isMarkedForMove || !((UnityEngine.Object) this.StorageProxy != (UnityEngine.Object) null))
      return;
    this.StorageProxy.GetComponent<CancellableMove>().RemoveMovable(this);
    this.ClearStorageProxy();
  }

  private void CleanupMove(object data)
  {
    if (!((UnityEngine.Object) this.StorageProxy != (UnityEngine.Object) null))
      return;
    this.StorageProxy.GetComponent<CancellableMove>().OnCancel(this);
  }

  private void OnTagsChanged(object data)
  {
    if (!this.isMarkedForMove || this.HasTagRequiredToMove() || !((UnityEngine.Object) this.StorageProxy != (UnityEngine.Object) null))
      return;
    this.StorageProxy.GetComponent<CancellableMove>().OnCancel(this);
  }

  public void ClearMove()
  {
    if (this.isMarkedForMove)
    {
      this.isMarkedForMove = false;
      KSelectable component = this.GetComponent<KSelectable>();
      this.pendingMoveGuid = component.RemoveStatusItem(this.pendingMoveGuid);
      this.storageUnreachableGuid = component.RemoveStatusItem(this.storageUnreachableGuid);
      this.ClearStorageProxy();
      this.gameObject.RemoveTag(GameTags.MarkedForMove);
      if (this.reachableChangedHandle != -1)
      {
        this.Unsubscribe(-1432940121, new Action<object>(this.OnReachableChanged));
        this.reachableChangedHandle = -1;
      }
      if (this.cancelHandle != -1)
      {
        this.Unsubscribe(2127324410, new Action<object>(this.CleanupMove));
        this.cancelHandle = -1;
      }
      if (this.tagsChangedHandle != -1)
      {
        this.Unsubscribe(-1582839653, new Action<object>(this.OnTagsChanged));
        this.tagsChangedHandle = -1;
      }
    }
    this.UpdateStatusItem();
  }

  private void ClearStorageProxy()
  {
    if (this.storageReachableChangedHandle != -1)
    {
      this.StorageProxy.Unsubscribe(-1432940121, new Action<object>(this.OnReachableChanged));
      this.storageReachableChangedHandle = -1;
    }
    this.storageProxy = (Ref<Storage>) null;
  }

  private void OnClickMove() => MoveToLocationTool.Instance.Activate(this);

  private void OnClickCancel()
  {
    if (!((UnityEngine.Object) this.StorageProxy != (UnityEngine.Object) null))
      return;
    this.StorageProxy.GetComponent<CancellableMove>().OnCancel(this);
  }

  private void OnRefreshUserMenu(object data)
  {
    if (this.pickupable.KPrefabID.HasTag(GameTags.Stored) || !this.HasTagRequiredToMove())
      return;
    Game.Instance.userMenu.AddButton(this.gameObject, this.isMarkedForMove ? new KIconButtonMenu.ButtonInfo("action_control", (string) UI.USERMENUACTIONS.PICKUPABLEMOVE.NAME_OFF, new System.Action(this.OnClickCancel), tooltipText: (string) UI.USERMENUACTIONS.PICKUPABLEMOVE.TOOLTIP_OFF) : new KIconButtonMenu.ButtonInfo("action_control", (string) UI.USERMENUACTIONS.PICKUPABLEMOVE.NAME, new System.Action(this.OnClickMove), tooltipText: (string) UI.USERMENUACTIONS.PICKUPABLEMOVE.TOOLTIP));
  }

  private bool HasTagRequiredToMove()
  {
    return this.tagRequiredForMove == Tag.Invalid || this.pickupable.KPrefabID.HasTag(this.tagRequiredForMove);
  }

  public void MoveToLocation(int cell)
  {
    this.CreateStorageProxy(cell);
    this.MarkForMove();
    this.gameObject.Trigger(1122777325, (object) this.gameObject);
  }

  private void MarkForMove()
  {
    this.Trigger(2127324410, (object) null);
    this.isMarkedForMove = true;
    this.OnReachableChanged((object) null);
    this.storageReachableChangedHandle = this.StorageProxy.Subscribe(-1432940121, new Action<object>(this.OnReachableChanged));
    this.reachableChangedHandle = this.Subscribe(-1432940121, new Action<object>(this.OnReachableChanged));
    this.StorageProxy.GetComponent<CancellableMove>().SetMovable(this);
    this.gameObject.AddTag(GameTags.MarkedForMove);
    this.cancelHandle = this.Subscribe(2127324410, new Action<object>(this.CleanupMove));
    this.tagsChangedHandle = this.Subscribe(-1582839653, new Action<object>(this.OnTagsChanged));
    this.UpdateStatusItem();
  }

  private void UpdateStatusItem()
  {
    if (!Movable.IsCritterPickupable(this.gameObject))
      return;
    this.shouldShowSkillPerkStatusItem = this.isMarkedForMove;
    this.UpdateStatusItem((object) null);
  }

  public bool CanMoveTo(int cell)
  {
    return !Grid.IsSolidCell(cell) && Grid.IsWorldValidCell(cell) && this.gameObject.IsMyParentWorld(cell);
  }

  private void CreateStorageProxy(int cell)
  {
    if (this.storageProxy != null && !((UnityEngine.Object) this.storageProxy.Get() == (UnityEngine.Object) null))
      return;
    if ((UnityEngine.Object) Grid.Objects[cell, 44] != (UnityEngine.Object) null)
    {
      this.storageProxy = new Ref<Storage>(Grid.Objects[cell, 44].GetComponent<Storage>());
    }
    else
    {
      Vector3 posCbc = Grid.CellToPosCBC(cell, MoveToLocationTool.Instance.visualizerLayer);
      GameObject gameObject = Util.KInstantiate(Assets.GetPrefab((Tag) MovePickupablePlacerConfig.ID), posCbc);
      Storage component = gameObject.GetComponent<Storage>();
      gameObject.SetActive(true);
      this.storageProxy = new Ref<Storage>(component);
    }
  }

  public static bool IsCritterPickupable(GameObject pickupable_go)
  {
    return (bool) (UnityEngine.Object) pickupable_go.GetComponent<Capturable>();
  }
}
