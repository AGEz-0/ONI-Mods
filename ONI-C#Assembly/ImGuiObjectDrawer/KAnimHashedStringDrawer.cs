// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.KAnimHashedStringDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace ImGuiObjectDrawer;

public sealed class KAnimHashedStringDrawer : InlineDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.value is KAnimHashedString;
  }

  protected override void DrawInline(in MemberDrawContext context, in MemberDetails member)
  {
    KAnimHashedString kanimHashedString = (KAnimHashedString) member.value;
    string str1 = kanimHashedString.ToString();
    string str2 = "0x" + kanimHashedString.HashValue.ToString("X");
    ImGuiEx.SimpleField(member.name, $"{str1} ({str2})");
  }
}
