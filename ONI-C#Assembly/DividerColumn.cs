// Decompiled with JetBrains decompiler
// Type: DividerColumn
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class DividerColumn(Func<bool> revealed = null, string scrollerID = "") : TableColumn((Action<IAssignableIdentity, GameObject>) ((minion, widget_go) =>
{
  if (revealed != null)
  {
    if (revealed())
    {
      if (widget_go.activeSelf)
        return;
      widget_go.SetActive(true);
    }
    else
    {
      if (!widget_go.activeSelf)
        return;
      widget_go.SetActive(false);
    }
  }
  else
    widget_go.SetActive(true);
}), (Comparison<IAssignableIdentity>) null, revealed: revealed, scrollerID: scrollerID)
{
  public override GameObject GetDefaultWidget(GameObject parent)
  {
    return Util.KInstantiateUI(Assets.UIPrefabs.TableScreenWidgets.Spacer, parent, true);
  }

  public override GameObject GetMinionWidget(GameObject parent)
  {
    return Util.KInstantiateUI(Assets.UIPrefabs.TableScreenWidgets.Spacer, parent, true);
  }

  public override GameObject GetHeaderWidget(GameObject parent)
  {
    return Util.KInstantiateUI(Assets.UIPrefabs.TableScreenWidgets.Spacer, parent, true);
  }
}
