// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.PrimaryMemberDrawerProvider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace ImGuiObjectDrawer;

public class PrimaryMemberDrawerProvider : IMemberDrawerProvider
{
  public int Priority => 100;

  public void AppendDrawersTo(List<MemberDrawer> drawers)
  {
    drawers.AddRange((IEnumerable<MemberDrawer>) new MemberDrawer[15]
    {
      (MemberDrawer) new NullDrawer(),
      (MemberDrawer) new SimpleDrawer(),
      (MemberDrawer) new LocStringDrawer(),
      (MemberDrawer) new EnumDrawer(),
      (MemberDrawer) new HashedStringDrawer(),
      (MemberDrawer) new KAnimHashedStringDrawer(),
      (MemberDrawer) new Vector2Drawer(),
      (MemberDrawer) new Vector3Drawer(),
      (MemberDrawer) new Vector4Drawer(),
      (MemberDrawer) new UnityObjectDrawer(),
      (MemberDrawer) new ArrayDrawer(),
      (MemberDrawer) new IDictionaryDrawer(),
      (MemberDrawer) new IEnumerableDrawer(),
      (MemberDrawer) new PlainCSharpObjectDrawer(),
      (MemberDrawer) new FallbackDrawer()
    });
  }
}
