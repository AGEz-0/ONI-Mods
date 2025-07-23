﻿// Decompiled with JetBrains decompiler
// Type: ImGuiObjectDrawer.IEnumerableDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;

#nullable disable
namespace ImGuiObjectDrawer;

public sealed class IEnumerableDrawer : CollectionDrawer
{
  public override bool CanDraw(in MemberDrawContext context, in MemberDetails member)
  {
    return member.CanAssignToType<IEnumerable>();
  }

  public override bool IsEmpty(in MemberDrawContext context, in MemberDetails member)
  {
    return !((IEnumerable) member.value).GetEnumerator().MoveNext();
  }

  protected override void VisitElements(
    CollectionDrawer.ElementVisitor visit,
    in MemberDrawContext context,
    in MemberDetails member)
  {
    IEnumerable enumerable = (IEnumerable) member.value;
    int index = 0;
    foreach (object obj in enumerable)
    {
      object el = obj;
      visit(in context, new CollectionDrawer.Element(index, (Action) (() => DrawerUtil.Tooltip(el.GetType())), (Func<object>) (() => (object) new
      {
        value = el
      })));
      ++index;
    }
  }
}
