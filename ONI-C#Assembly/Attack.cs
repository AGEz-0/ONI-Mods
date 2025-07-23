﻿// Decompiled with JetBrains decompiler
// Type: Attack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class Attack
{
  private AttackProperties properties;
  private GameObject[] targets;
  public List<Hit> Hits;

  public Attack(AttackProperties properties, GameObject[] targets)
  {
    this.properties = properties;
    this.targets = targets;
    this.RollHits();
  }

  private void RollHits()
  {
    for (int index = 0; index < this.targets.Length && index <= this.properties.maxHits - 1; ++index)
    {
      if ((Object) this.targets[index] != (Object) null)
      {
        Hit hit = new Hit(this.properties, this.targets[index]);
      }
    }
  }
}
