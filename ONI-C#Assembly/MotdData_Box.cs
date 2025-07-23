// Decompiled with JetBrains decompiler
// Type: MotdData_Box
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class MotdData_Box
{
  public string category;
  public string guid;
  public long startTime;
  public long finishTime;
  public string title;
  public string text;
  public string image;
  public string href;
  public Texture2D resolvedImage;
  public bool resolvedImageIsFromDisk;

  public bool ShouldDisplay()
  {
    long unixTimeSeconds = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    return unixTimeSeconds >= this.startTime && this.finishTime >= unixTimeSeconds;
  }
}
