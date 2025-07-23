// Decompiled with JetBrains decompiler
// Type: MathfExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class MathfExtensions
{
  public static long Max(this long a, long b) => a < b ? b : a;

  public static long Min(this long a, long b) => a > b ? b : a;
}
