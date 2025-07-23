// Decompiled with JetBrains decompiler
// Type: RangeVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/RangeVisualizer")]
public class RangeVisualizer : KMonoBehaviour
{
  public Vector2I OriginOffset;
  public Vector2I RangeMin;
  public Vector2I RangeMax;
  public Vector2I TexSize = new Vector2I(64 /*0x40*/, 64 /*0x40*/);
  public bool TestLineOfSight = true;
  public bool BlockingTileVisible;
  public Func<int, bool> BlockingVisibleCb;
  public Func<int, bool> BlockingCb = new Func<int, bool>(Grid.IsSolidCell);
  public bool AllowLineOfSightInvalidCells;
}
