// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.PlainCSharpObjectDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using System;

#nullable disable
namespace ImGuiObjectDrawer;

public class PlainCSharpObjectDrawer : MemberDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member) => true;

  public override MemberDrawType GetDrawType(in MemberDrawContext context, in MemberDetails member)
  {
    return MemberDrawType.Custom;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    throw new InvalidOperationException();
  }

  protected override void DrawCustom(
    in MemberDrawContext context,
    in MemberDetails member,
    int depth)
  {
    ImGuiTreeNodeFlags flags = ImGuiTreeNodeFlags.None;
    if (context.default_open && depth <= 0)
      flags |= ImGuiTreeNodeFlags.DefaultOpen;
    int num = ImGui.TreeNodeEx(member.name, flags) ? 1 : 0;
    DrawerUtil.Tooltip(member.type);
    if (num == 0)
      return;
    this.DrawContents(in context, in member, depth);
    ImGui.TreePop();
  }

  protected virtual void DrawContents(
    in MemberDrawContext context,
    in MemberDetails member,
    int depth)
  {
    DrawerUtil.DrawObjectContents(member.value, in context, depth + 1);
  }
}
