// Decompiled with JetBrains decompiler
// Type: GameObjectPool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class GameObjectPool(Func<GameObject> instantiator, int initial_count = 0) : 
  ObjectPool<GameObject>(instantiator, initial_count)
{
  public override GameObject GetInstance() => base.GetInstance();

  public void Destroy()
  {
    for (int index = this.unused.Count - 1; index >= 0; --index)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.unused.Pop());
  }
}
