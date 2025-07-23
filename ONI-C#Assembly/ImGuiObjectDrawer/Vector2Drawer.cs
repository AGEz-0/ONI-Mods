// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.Vector2Drawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace ImGuiObjectDrawer;

public sealed class Vector2Drawer : InlineDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value is Vector2;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    Vector2 vector2 = (Vector2) member.value;
    ImGuiEx.SimpleField(member.name, $"( {vector2.x}, {vector2.y} )");
  }
}
