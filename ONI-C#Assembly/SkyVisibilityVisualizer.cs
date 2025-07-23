// Decompiled with JetBrains decompiler
// Type: SkyVisibilityVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SkyVisibilityVisualizer")]
public class SkyVisibilityVisualizer : KMonoBehaviour
{
  public Vector2I OriginOffset = new Vector2I(0, 0);
  public bool TwoWideOrgin;
  public int RangeMin;
  public int RangeMax;
  public int ScanVerticalStep;
  public bool SkipOnModuleInteriors;
  public bool AllOrNothingVisibility;
  public Func<int, bool> SkyVisibilityCb = new Func<int, bool>(SkyVisibilityVisualizer.HasSkyVisibility);

  private static bool HasSkyVisibility(int cell) => Grid.ExposedToSunlight[cell] >= (byte) 1;
}
