﻿// Decompiled with JetBrains decompiler
// Type: EffectArea
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/EffectArea")]
public class EffectArea : KMonoBehaviour
{
  public string EffectName;
  public int Area;
  private Effect Effect;

  protected override void OnPrefabInit() => this.Effect = Db.Get().effects.Get(this.EffectName);

  private void Update()
  {
    int x1 = 0;
    int y1 = 0;
    Grid.PosToXY(this.transform.GetPosition(), out x1, out y1);
    foreach (MinionIdentity minionIdentity in Components.MinionIdentities.Items)
    {
      int x2 = 0;
      int y2 = 0;
      Grid.PosToXY(minionIdentity.transform.GetPosition(), out x2, out y2);
      if (Math.Abs(x2 - x1) <= this.Area && Math.Abs(y2 - y1) <= this.Area)
        minionIdentity.GetComponent<Effects>().Add(this.Effect, true);
    }
  }
}
