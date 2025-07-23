// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.IDictionaryDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;

#nullable disable
namespace ImGuiObjectDrawer;

public sealed class IDictionaryDrawer : CollectionDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.CanAssignToType<IDictionary>();
  }

  public override bool IsEmpty(in MemberDrawContext context, in MemberDetails member)
  {
    return ((ICollection) member.value).Count == 0;
  }

  protected override void VisitElements(
    CollectionDrawer.ElementVisitor visit,
    in MemberDrawContext context,
    in MemberDetails member)
  {
    IDictionary dictionary = (IDictionary) member.value;
    int index = 0;
    foreach (DictionaryEntry dictionaryEntry in dictionary)
    {
      DictionaryEntry kvp = dictionaryEntry;
      visit(in context, new CollectionDrawer.Element(index, (Action) (() => DrawerUtil.Tooltip($"{kvp.Key.GetType()} -> {kvp.Value.GetType()}")), (Func<object>) (() => (object) new
      {
        key = kvp.Key,
        value = kvp.Value
      })));
      ++index;
    }
  }
}
