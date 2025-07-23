﻿// Decompiled with JetBrains decompiler
// Type: LogicDuplicantSensor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using System.Collections.Generic;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class LogicDuplicantSensor : Switch, ISim1000ms, ISim200ms
{
  [MyCmpGet]
  private KSelectable selectable;
  [MyCmpGet]
  private Rotatable rotatable;
  public int pickupRange = 4;
  private bool wasOn;
  private List<Pickupable> duplicants = new List<Pickupable>();
  private HandleVector<int>.Handle pickupablesChangedEntry;
  private bool pickupablesDirty;
  private Extents pickupableExtents;
  private List<int> reachableCells = new List<int>(100);

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.simRenderLoadBalance = true;
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.OnToggle += new Action<bool>(this.OnSwitchToggled);
    this.UpdateLogicCircuit();
    this.UpdateVisualState(true);
    this.RefreshReachableCells();
    this.wasOn = this.switchedOn;
    Vector2I xy = Grid.CellToXY(this.NaturalBuildingCell());
    int cell = Grid.XYToCell(xy.x, xy.y + this.pickupRange / 2);
    CellOffset offset = new CellOffset(0, this.pickupRange / 2);
    if ((bool) (UnityEngine.Object) this.rotatable)
    {
      CellOffset rotatedCellOffset = this.rotatable.GetRotatedCellOffset(offset);
      if (Grid.IsCellOffsetValid(this.NaturalBuildingCell(), rotatedCellOffset))
        cell = Grid.OffsetCell(this.NaturalBuildingCell(), rotatedCellOffset);
    }
    this.pickupableExtents = new Extents(cell, this.pickupRange / 2);
    this.pickupablesChangedEntry = GameScenePartitioner.Instance.Add("DuplicantSensor.PickupablesChanged", (object) this.gameObject, this.pickupableExtents, GameScenePartitioner.Instance.pickupablesChangedLayer, new Action<object>(this.OnPickupablesChanged));
    this.pickupablesDirty = true;
  }

  protected override void OnCleanUp()
  {
    GameScenePartitioner.Instance.Free(ref this.pickupablesChangedEntry);
    MinionGroupProber.Get().ReleaseProber((object) this);
    base.OnCleanUp();
  }

  public void Sim1000ms(float dt) => this.RefreshReachableCells();

  public void Sim200ms(float dt) => this.RefreshPickupables();

  private void RefreshReachableCells()
  {
    ListPool<int, LogicDuplicantSensor>.PooledList pooledList = ListPool<int, LogicDuplicantSensor>.Allocate(this.reachableCells);
    this.reachableCells.Clear();
    int x;
    int y;
    Grid.CellToXY(this.NaturalBuildingCell(), out x, out y);
    int num = x - this.pickupRange / 2;
    for (int index1 = y; index1 < y + this.pickupRange + 1; ++index1)
    {
      for (int index2 = num; index2 < num + this.pickupRange + 1; ++index2)
      {
        int cell1 = Grid.XYToCell(index2, index1);
        CellOffset offset = new CellOffset(index2 - x, index1 - y);
        if ((bool) (UnityEngine.Object) this.rotatable)
        {
          offset = this.rotatable.GetRotatedCellOffset(offset);
          if (Grid.IsCellOffsetValid(this.NaturalBuildingCell(), offset))
          {
            int cell2 = Grid.OffsetCell(this.NaturalBuildingCell(), offset);
            Vector2I xy = Grid.CellToXY(cell2);
            if (Grid.IsValidCell(cell2) && Grid.IsPhysicallyAccessible(x, y, xy.x, xy.y, true))
              this.reachableCells.Add(cell2);
          }
        }
        else if (Grid.IsValidCell(cell1) && Grid.IsPhysicallyAccessible(x, y, index2, index1, true))
          this.reachableCells.Add(cell1);
      }
    }
    pooledList.Recycle();
  }

  public bool IsCellReachable(int cell) => this.reachableCells.Contains(cell);

  private void RefreshPickupables()
  {
    if (!this.pickupablesDirty)
      return;
    this.duplicants.Clear();
    ListPool<ScenePartitionerEntry, LogicDuplicantSensor>.PooledList gathered_entries = ListPool<ScenePartitionerEntry, LogicDuplicantSensor>.Allocate();
    GameScenePartitioner.Instance.GatherEntries(this.pickupableExtents.x, this.pickupableExtents.y, this.pickupableExtents.width, this.pickupableExtents.height, GameScenePartitioner.Instance.pickupablesLayer, (List<ScenePartitionerEntry>) gathered_entries);
    int cell = Grid.PosToCell((KMonoBehaviour) this);
    for (int index = 0; index < gathered_entries.Count; ++index)
    {
      Pickupable pickupable = gathered_entries[index].obj as Pickupable;
      int pickupableCell = this.GetPickupableCell(pickupable);
      int cellRange = Grid.GetCellRange(cell, pickupableCell);
      if (this.IsPickupableRelevantToMyInterestsAndReachable(pickupable) && cellRange <= this.pickupRange)
        this.duplicants.Add(pickupable);
    }
    this.SetState(this.duplicants.Count > 0);
    this.pickupablesDirty = false;
  }

  private void OnPickupablesChanged(object data)
  {
    Pickupable pickupable = data as Pickupable;
    if (!(bool) (UnityEngine.Object) pickupable || !this.IsPickupableRelevantToMyInterests(pickupable))
      return;
    this.pickupablesDirty = true;
  }

  private bool IsPickupableRelevantToMyInterests(Pickupable pickupable)
  {
    return pickupable.KPrefabID.HasTag(GameTags.DupeBrain);
  }

  private bool IsPickupableRelevantToMyInterestsAndReachable(Pickupable pickupable)
  {
    return this.IsPickupableRelevantToMyInterests(pickupable) && this.IsCellReachable(this.GetPickupableCell(pickupable));
  }

  private int GetPickupableCell(Pickupable pickupable) => pickupable.cachedCell;

  private void OnSwitchToggled(bool toggled_on)
  {
    this.UpdateLogicCircuit();
    this.UpdateVisualState();
  }

  private void UpdateLogicCircuit()
  {
    this.GetComponent<LogicPorts>().SendSignal(LogicSwitch.PORT_ID, this.switchedOn ? 1 : 0);
  }

  private void UpdateVisualState(bool force = false)
  {
    if (!(this.wasOn != this.switchedOn | force))
      return;
    this.wasOn = this.switchedOn;
    KBatchedAnimController component = this.GetComponent<KBatchedAnimController>();
    component.Play((HashedString) (this.switchedOn ? "on_pre" : "on_pst"));
    component.Queue((HashedString) (this.switchedOn ? "on" : "off"));
  }

  protected override void UpdateSwitchStatus()
  {
    StatusItem status_item = this.switchedOn ? Db.Get().BuildingStatusItems.LogicSensorStatusActive : Db.Get().BuildingStatusItems.LogicSensorStatusInactive;
    this.GetComponent<KSelectable>().SetStatusItem(Db.Get().StatusItemCategories.Power, status_item);
  }
}
