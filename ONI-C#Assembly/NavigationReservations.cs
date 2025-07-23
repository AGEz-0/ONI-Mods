﻿// Decompiled with JetBrains decompiler
// Type: NavigationReservations
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/NavigationReservations")]
public class NavigationReservations : KMonoBehaviour
{
  public static NavigationReservations Instance;
  public static int InvalidReservation = -1;
  private Dictionary<int, int> cellOccupancyDensity = new Dictionary<int, int>();

  public static void DestroyInstance()
  {
    NavigationReservations.Instance = (NavigationReservations) null;
  }

  public int GetOccupancyCount(int cell)
  {
    return this.cellOccupancyDensity.ContainsKey(cell) ? this.cellOccupancyDensity[cell] : 0;
  }

  public void AddOccupancy(int cell)
  {
    if (!this.cellOccupancyDensity.ContainsKey(cell))
      this.cellOccupancyDensity.Add(cell, 1);
    else
      ++this.cellOccupancyDensity[cell];
  }

  public void RemoveOccupancy(int cell)
  {
    int num = 0;
    if (!this.cellOccupancyDensity.TryGetValue(cell, out num))
      return;
    if (num == 1)
      this.cellOccupancyDensity.Remove(cell);
    else
      this.cellOccupancyDensity[cell] = num - 1;
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    NavigationReservations.Instance = this;
  }
}
