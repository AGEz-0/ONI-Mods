// Decompiled with JetBrains decompiler
// Type: ObjectPool`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class ObjectPool<T>
{
  protected Stack<T> unused;
  protected Func<T> instantiator;

  public ObjectPool(Func<T> instantiator, int initial_count = 0)
  {
    this.instantiator = instantiator;
    this.unused = new Stack<T>(initial_count);
    for (int index = 0; index < initial_count; ++index)
      this.unused.Push(instantiator());
  }

  public virtual T GetInstance()
  {
    T obj = default (T);
    return this.unused.Count <= 0 ? this.instantiator() : this.unused.Pop();
  }

  public void ReleaseInstance(T instance)
  {
    if (object.Equals((object) instance, (object) null))
      return;
    this.unused.Push(instance);
  }
}
