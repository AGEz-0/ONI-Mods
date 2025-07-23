// Decompiled with JetBrains decompiler
// Type: DefComponent`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class DefComponent<T> where T : Component
{
  [SerializeField]
  private T cmp;

  public DefComponent(T cmp) => this.cmp = cmp;

  public T Get(StateMachine.Instance smi)
  {
    T[] components = this.cmp.GetComponents<T>();
    int index = 0;
    while (index < components.Length && !((UnityEngine.Object) components[index] == (UnityEngine.Object) this.cmp))
      ++index;
    return smi.gameObject.GetComponents<T>()[index];
  }

  public static implicit operator DefComponent<T>(T cmp) => new DefComponent<T>(cmp);
}
