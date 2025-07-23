// Decompiled with JetBrains decompiler
// Type: GlobalStringBuilderPool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Text;

#nullable disable
public static class GlobalStringBuilderPool
{
  private static ObjectPool<StringBuilder> pool = new ObjectPool<StringBuilder>((Func<StringBuilder>) (() => new StringBuilder(4096 /*0x1000*/)), 4);

  public static StringBuilder Alloc() => GlobalStringBuilderPool.pool.GetInstance();

  public static void Free(StringBuilder sb)
  {
    sb?.Clear();
    GlobalStringBuilderPool.pool.ReleaseInstance(sb);
  }

  public static string ReturnAndFree(StringBuilder sb)
  {
    string str = sb.ToString();
    GlobalStringBuilderPool.Free(sb);
    return str;
  }
}
