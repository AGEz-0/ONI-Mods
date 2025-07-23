// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.Vector4Drawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ImGuiObjectDrawer;

public sealed class Vector4Drawer : InlineDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value is Vector4;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    Vector4 vector4 = (Vector4) member.value;
    ImGuiEx.SimpleField(member.name, $"( {vector4.x}, {vector4.y}, {vector4.z}, {vector4.w} )");
  }
}
