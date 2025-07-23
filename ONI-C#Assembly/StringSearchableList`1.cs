﻿// Decompiled with JetBrains decompiler
// Type: StringSearchableList`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class StringSearchableList<T>
{
  public string filter = "";
  public List<T> allValues;
  public List<T> filteredValues;
  public readonly StringSearchableList<T>.ShouldFilterOutFn shouldFilterOutFn;

  public bool didUseFilter { get; private set; }

  public StringSearchableList(
    List<T> allValues,
    StringSearchableList<T>.ShouldFilterOutFn shouldFilterOutFn)
  {
    this.allValues = allValues;
    this.shouldFilterOutFn = shouldFilterOutFn;
    this.filteredValues = new List<T>();
  }

  public StringSearchableList(
    StringSearchableList<T>.ShouldFilterOutFn shouldFilterOutFn)
  {
    this.shouldFilterOutFn = shouldFilterOutFn;
    this.allValues = new List<T>();
    this.filteredValues = new List<T>();
  }

  public void Refilter()
  {
    if (StringSearchableListUtil.ShouldUseFilter(this.filter))
    {
      this.filteredValues.Clear();
      foreach (T allValue in this.allValues)
      {
        if (!this.shouldFilterOutFn(allValue, in this.filter))
          this.filteredValues.Add(allValue);
      }
      this.didUseFilter = true;
    }
    else
    {
      if (this.filteredValues.Count != this.allValues.Count)
      {
        this.filteredValues.Clear();
        this.filteredValues.AddRange((IEnumerable<T>) this.allValues);
      }
      this.didUseFilter = false;
    }
  }

  public delegate bool ShouldFilterOutFn(T candidateValue, in string filter);
}
