// Decompiled with JetBrains decompiler
// Type: KSelectableExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class KSelectableExtensions
{
  public static string GetProperName(this Component cmp)
  {
    return (Object) cmp != (Object) null && (Object) cmp.gameObject != (Object) null ? cmp.gameObject.GetProperName() : "";
  }

  public static string GetProperName(this GameObject go)
  {
    if ((Object) go != (Object) null)
    {
      KSelectable component = go.GetComponent<KSelectable>();
      if ((Object) component != (Object) null)
        return component.GetName();
    }
    return "";
  }

  public static string GetProperName(this KSelectable cmp)
  {
    return (Object) cmp != (Object) null ? cmp.GetName() : "";
  }
}
