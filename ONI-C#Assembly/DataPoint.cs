// Decompiled with JetBrains decompiler
// Type: DataPoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public struct DataPoint(float start, float end, float value)
{
  public float periodStart = start;
  public float periodEnd = end;
  public float periodValue = value;
}
