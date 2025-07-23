// Decompiled with JetBrains decompiler
// Type: HashMapObjectPool`2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class HashMapObjectPool<PoolKey, PoolValue>
{
  private Dictionary<PoolKey, ObjectPool<PoolValue>> objectPoolMap = new Dictionary<PoolKey, ObjectPool<PoolValue>>();
  private int initialCount;
  private PoolKey currentPoolId;
  private Func<PoolKey, PoolValue> instantiator;

  public HashMapObjectPool(Func<PoolKey, PoolValue> instantiator, int initialCount = 0)
  {
    this.initialCount = initialCount;
    this.instantiator = instantiator;
  }

  public HashMapObjectPool(
    HashMapObjectPool<PoolKey, PoolValue>.IPoolDescriptor[] descriptors,
    int initialCount = 0)
  {
    this.initialCount = initialCount;
    for (int index = 0; index < descriptors.Length; ++index)
    {
      if (this.objectPoolMap.ContainsKey(descriptors[index].PoolId))
        Debug.LogWarning((object) $"HshMapObjectPool alaready contains key of {descriptors[index].PoolId}! Skipping!");
      else
        this.objectPoolMap[descriptors[index].PoolId] = new ObjectPool<PoolValue>(new Func<PoolValue>(descriptors[index].GetInstance), initialCount);
    }
  }

  public PoolValue GetInstance(PoolKey poolId)
  {
    ObjectPool<PoolValue> objectPool;
    if (!this.objectPoolMap.TryGetValue(poolId, out objectPool))
      objectPool = this.objectPoolMap[poolId] = new ObjectPool<PoolValue>(new Func<PoolValue>(this.PoolInstantiator), this.initialCount);
    this.currentPoolId = poolId;
    return objectPool.GetInstance();
  }

  public void ReleaseInstance(PoolKey poolId, PoolValue inst)
  {
    ObjectPool<PoolValue> objectPool;
    if ((object) inst == null || !this.objectPoolMap.TryGetValue(poolId, out objectPool))
      return;
    objectPool.ReleaseInstance(inst);
  }

  private PoolValue PoolInstantiator()
  {
    return this.instantiator == null ? default (PoolValue) : this.instantiator(this.currentPoolId);
  }

  public interface IPoolDescriptor
  {
    PoolKey PoolId { get; }

    PoolValue GetInstance();
  }
}
