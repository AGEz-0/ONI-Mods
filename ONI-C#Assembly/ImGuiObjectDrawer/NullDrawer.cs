// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.NullDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace ImGuiObjectDrawer;

public class NullDrawer : InlineDrawer
{
  public override bool CanDrawAtDepth(int depth) => true;

  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value == null;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    ImGuiEx.SimpleField(member.name, "null");
  }
}
