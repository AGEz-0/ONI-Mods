// Decompiled with JetBrains decompiler
// Type: Klei.AI.ModifierGroup`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Klei.AI;

public class ModifierGroup<T>(string id, string name) : Resource(id, name)
{
  public List<T> modifiers = new List<T>();

  public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) this.modifiers.GetEnumerator();

  public T this[int idx] => this.modifiers[idx];

  public int Count => this.modifiers.Count;

  public void Add(T modifier) => this.modifiers.Add(modifier);
}
