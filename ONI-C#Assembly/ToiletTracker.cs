// Decompiled with JetBrains decompiler
// Type: ToiletTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class ToiletTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData() => throw new NotImplementedException();

  public override string FormatValueString(float value) => value.ToString();
}
