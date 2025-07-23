// Decompiled with JetBrains decompiler
// Type: CavityInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CavityInfo
{
  public HandleVector<int>.Handle handle;
  public bool dirty;
  public int numCells;
  public int maxX;
  public int maxY;
  public int minX;
  public int minY;
  public Room room;
  public List<KPrefabID> buildings = new List<KPrefabID>();
  public List<KPrefabID> plants = new List<KPrefabID>();
  public List<KPrefabID> creatures = new List<KPrefabID>();
  public List<KPrefabID> eggs = new List<KPrefabID>();

  public CavityInfo()
  {
    this.handle = HandleVector<int>.InvalidHandle;
    this.dirty = true;
  }

  public void AddBuilding(KPrefabID bc)
  {
    this.buildings.Add(bc);
    this.dirty = true;
  }

  public void AddPlants(KPrefabID plant)
  {
    this.plants.Add(plant);
    this.dirty = true;
  }

  public void RemoveFromCavity(KPrefabID id, List<KPrefabID> listToRemove)
  {
    int index1 = -1;
    for (int index2 = 0; index2 < listToRemove.Count; ++index2)
    {
      if (id.InstanceID == listToRemove[index2].InstanceID)
      {
        index1 = index2;
        break;
      }
    }
    if (index1 < 0)
      return;
    listToRemove.RemoveAt(index1);
  }

  public void OnEnter(object data)
  {
    foreach (KPrefabID building in this.buildings)
    {
      if ((Object) building != (Object) null)
        building.Trigger(-832141045, data);
    }
  }

  public Vector3 GetCenter()
  {
    return new Vector3((float) (this.minX + (this.maxX - this.minX) / 2), (float) (this.minY + (this.maxY - this.minY) / 2));
  }
}
