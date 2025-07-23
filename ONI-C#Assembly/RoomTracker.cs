﻿// Decompiled with JetBrains decompiler
// Type: RoomTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/RoomTracker")]
public class RoomTracker : KMonoBehaviour, IGameObjectEffectDescriptor
{
  public RoomTracker.Requirement requirement;
  public string requiredRoomType;
  public string customStatusItemID;
  private Guid statusItemGuid;
  private static readonly EventSystem.IntraObjectHandler<RoomTracker> OnUpdateRoomDelegate = new EventSystem.IntraObjectHandler<RoomTracker>((Action<RoomTracker, object>) ((component, data) => component.OnUpdateRoom(data)));

  public Room room { get; private set; }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    Debug.Assert(!string.IsNullOrEmpty(this.requiredRoomType) && this.requiredRoomType != Db.Get().RoomTypes.Neutral.Id, (object) "RoomTracker must have a requiredRoomType!");
    this.Subscribe<RoomTracker>(144050788, RoomTracker.OnUpdateRoomDelegate);
    this.FindAndSetRoom();
  }

  public void FindAndSetRoom()
  {
    CavityInfo cavityForCell = Game.Instance.roomProber.GetCavityForCell(Grid.PosToCell(this.gameObject));
    if (cavityForCell != null && cavityForCell.room != null)
      this.OnUpdateRoom((object) cavityForCell.room);
    else
      this.OnUpdateRoom((object) null);
  }

  public bool IsInCorrectRoom()
  {
    return this.room != null && this.room.roomType.Id == this.requiredRoomType;
  }

  public bool SufficientBuildLocation(int cell)
  {
    return Grid.IsValidCell(cell) && (this.requirement != RoomTracker.Requirement.Required && this.requirement != RoomTracker.Requirement.CustomRequired || Game.Instance.roomProber.GetCavityForCell(cell)?.room != null);
  }

  private void OnUpdateRoom(object data)
  {
    this.room = (Room) data;
    if (this.room == null || this.room.roomType.Id != this.requiredRoomType)
    {
      switch (this.requirement)
      {
        case RoomTracker.Requirement.TrackingOnly:
          this.statusItemGuid = this.GetComponent<KSelectable>().RemoveStatusItem(this.statusItemGuid);
          break;
        case RoomTracker.Requirement.Recommended:
          this.statusItemGuid = this.GetComponent<KSelectable>().SetStatusItem(Db.Get().StatusItemCategories.RequiredRoom, Db.Get().BuildingStatusItems.NotInRecommendedRoom, (object) this.requiredRoomType);
          break;
        case RoomTracker.Requirement.Required:
          this.statusItemGuid = this.GetComponent<KSelectable>().SetStatusItem(Db.Get().StatusItemCategories.RequiredRoom, Db.Get().BuildingStatusItems.NotInRequiredRoom, (object) this.requiredRoomType);
          break;
        case RoomTracker.Requirement.CustomRecommended:
        case RoomTracker.Requirement.CustomRequired:
          this.statusItemGuid = this.GetComponent<KSelectable>().SetStatusItem(Db.Get().StatusItemCategories.RequiredRoom, Db.Get().BuildingStatusItems.Get(this.customStatusItemID), (object) this.requiredRoomType);
          break;
      }
    }
    else
      this.statusItemGuid = this.GetComponent<KSelectable>().RemoveStatusItem(this.statusItemGuid);
  }

  public List<Descriptor> GetDescriptors(GameObject go)
  {
    List<Descriptor> descriptors = new List<Descriptor>();
    if (!string.IsNullOrEmpty(this.requiredRoomType))
    {
      string name = Db.Get().RoomTypes.Get(this.requiredRoomType).Name;
      switch (this.requirement)
      {
        case RoomTracker.Requirement.Recommended:
        case RoomTracker.Requirement.CustomRecommended:
          descriptors.Add(new Descriptor(string.Format((string) UI.BUILDINGEFFECTS.PREFERS_ROOM, (object) name), string.Format((string) UI.BUILDINGEFFECTS.TOOLTIPS.PREFERS_ROOM, (object) name), Descriptor.DescriptorType.Requirement));
          break;
        case RoomTracker.Requirement.Required:
        case RoomTracker.Requirement.CustomRequired:
          descriptors.Add(new Descriptor(string.Format((string) UI.BUILDINGEFFECTS.REQUIRESROOM, (object) name), string.Format((string) UI.BUILDINGEFFECTS.TOOLTIPS.REQUIRESROOM, (object) name), Descriptor.DescriptorType.Requirement));
          break;
      }
    }
    return descriptors;
  }

  public enum Requirement
  {
    TrackingOnly,
    Recommended,
    Required,
    CustomRecommended,
    CustomRequired,
  }
}
