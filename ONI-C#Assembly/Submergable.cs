// Decompiled with JetBrains decompiler
// Type: Submergable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
[AddComponentMenu("KMonoBehaviour/scripts/Submergable")]
public class Submergable : KMonoBehaviour
{
  [MyCmpReq]
  private Building building;
  [MyCmpReq]
  private PrimaryElement primaryElement;
  [MyCmpGet]
  private SimCellOccupier simCellOccupier;
  [MyCmpReq]
  private Operational operational;
  public static Operational.Flag notSubmergedFlag = new Operational.Flag("submerged", Operational.Flag.Type.Functional);
  private bool isSubmerged;
  private HandleVector<int>.Handle partitionerEntry;

  public bool IsSubmerged => this.isSubmerged;

  public BuildingDef Def => this.building.Def;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.partitionerEntry = GameScenePartitioner.Instance.Add("Submergable.OnSpawn", (object) this.gameObject, this.building.GetExtents(), GameScenePartitioner.Instance.liquidChangedLayer, new Action<object>(this.OnElementChanged));
    this.OnElementChanged((object) null);
    this.operational.SetFlag(Submergable.notSubmergedFlag, this.isSubmerged);
    this.GetComponent<KSelectable>().ToggleStatusItem(Db.Get().BuildingStatusItems.NotSubmerged, !this.isSubmerged, (object) this);
  }

  private void OnElementChanged(object data)
  {
    bool flag = true;
    for (int index = 0; index < this.building.PlacementCells.Length; ++index)
    {
      if (!Grid.IsLiquid(this.building.PlacementCells[index]))
      {
        flag = false;
        break;
      }
    }
    if (flag == this.isSubmerged)
      return;
    this.isSubmerged = flag;
    this.operational.SetFlag(Submergable.notSubmergedFlag, this.isSubmerged);
    this.GetComponent<KSelectable>().ToggleStatusItem(Db.Get().BuildingStatusItems.NotSubmerged, !this.isSubmerged, (object) this);
  }

  protected override void OnCleanUp()
  {
    GameScenePartitioner.Instance.Free(ref this.partitionerEntry);
  }
}
