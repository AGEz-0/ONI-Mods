﻿// Decompiled with JetBrains decompiler
// Type: SlicedUpdaterSim1000ms`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public abstract class SlicedUpdaterSim1000ms<T> : KMonoBehaviour, ISim200ms where T : KMonoBehaviour, ISlicedSim1000ms
{
  private static int NUM_200MS_BUCKETS = 5;
  public static SlicedUpdaterSim1000ms<T> instance;
  [Serialize]
  public int maxUpdatesPer200ms = 300;
  [Serialize]
  public int numSlicesPer200ms = 3;
  private List<SlicedUpdaterSim1000ms<T>.Slice> m_slices;
  private int m_nextSliceIdx;

  protected override void OnPrefabInit()
  {
    this.InitializeSlices();
    base.OnPrefabInit();
    SlicedUpdaterSim1000ms<T>.instance = this;
  }

  protected override void OnForcedCleanUp()
  {
    SlicedUpdaterSim1000ms<T>.instance = (SlicedUpdaterSim1000ms<T>) null;
    base.OnForcedCleanUp();
  }

  private void InitializeSlices()
  {
    int num = SlicedUpdaterSim1000ms<T>.NUM_200MS_BUCKETS * this.numSlicesPer200ms;
    this.m_slices = new List<SlicedUpdaterSim1000ms<T>.Slice>();
    for (int index = 0; index < num; ++index)
      this.m_slices.Add(new SlicedUpdaterSim1000ms<T>.Slice());
    this.m_nextSliceIdx = 0;
  }

  private int GetSliceIdx(T toBeUpdated)
  {
    return Mathf.Abs(toBeUpdated.GetComponent<KPrefabID>().InstanceID) % this.m_slices.Count;
  }

  public void RegisterUpdate1000ms(T toBeUpdated)
  {
    SlicedUpdaterSim1000ms<T>.Slice slice = this.m_slices[this.GetSliceIdx(toBeUpdated)];
    slice.Register(toBeUpdated);
    DebugUtil.DevAssert(slice.Count < this.maxUpdatesPer200ms, $"The SlicedUpdaterSim1000ms for {typeof (T).Name} wants to update no more than {this.maxUpdatesPer200ms} instances per 200ms tick, but a slice has grown more than the SlicedUpdaterSim1000ms can support.");
  }

  public void UnregisterUpdate1000ms(T toBeUpdated)
  {
    this.m_slices[this.GetSliceIdx(toBeUpdated)].Unregister(toBeUpdated);
  }

  public void Sim200ms(float dt)
  {
    foreach (SlicedUpdaterSim1000ms<T>.Slice slice in this.m_slices)
      slice.IncrementDt(dt);
    int num1 = 0;
    int num2 = 0;
    while (num2 < this.numSlicesPer200ms)
    {
      SlicedUpdaterSim1000ms<T>.Slice slice = this.m_slices[this.m_nextSliceIdx];
      num1 += slice.Count;
      if (num1 > this.maxUpdatesPer200ms && num2 > 0)
        break;
      slice.Update();
      ++num2;
      this.m_nextSliceIdx = (this.m_nextSliceIdx + 1) % this.m_slices.Count;
    }
  }

  private class Slice
  {
    private float m_timeSinceLastUpdate;
    private List<T> m_updateList = new List<T>();
    private Dictionary<T, float> m_recentlyAdded = new Dictionary<T, float>();

    public void Register(T toBeUpdated)
    {
      if ((double) this.m_timeSinceLastUpdate == 0.0)
        this.m_updateList.Add(toBeUpdated);
      else
        this.m_recentlyAdded[toBeUpdated] = 0.0f;
    }

    public void Unregister(T toBeUpdated)
    {
      if (this.m_updateList.Remove(toBeUpdated))
        return;
      this.m_recentlyAdded.Remove(toBeUpdated);
    }

    public int Count => this.m_updateList.Count + this.m_recentlyAdded.Count;

    public List<T> GetUpdateList()
    {
      List<T> updateList = new List<T>();
      updateList.AddRange((IEnumerable<T>) this.m_updateList);
      updateList.AddRange((IEnumerable<T>) this.m_recentlyAdded.Keys);
      return updateList;
    }

    public void Update()
    {
      foreach (T update in this.m_updateList)
        update.SlicedSim1000ms(this.m_timeSinceLastUpdate);
      foreach (KeyValuePair<T, float> keyValuePair in this.m_recentlyAdded)
      {
        keyValuePair.Key.SlicedSim1000ms(keyValuePair.Value);
        this.m_updateList.Add(keyValuePair.Key);
      }
      this.m_recentlyAdded.Clear();
      this.m_timeSinceLastUpdate = 0.0f;
    }

    public void IncrementDt(float dt)
    {
      this.m_timeSinceLastUpdate += dt;
      if (this.m_recentlyAdded.Count <= 0)
        return;
      foreach (T key in new List<T>((IEnumerable<T>) this.m_recentlyAdded.Keys))
        this.m_recentlyAdded[key] += dt;
    }
  }
}
