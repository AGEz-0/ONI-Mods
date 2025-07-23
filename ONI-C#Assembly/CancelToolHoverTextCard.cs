﻿// Decompiled with JetBrains decompiler
// Type: CancelToolHoverTextCard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CancelToolHoverTextCard : HoverTextConfiguration
{
  private string lastUpdatedFilter;

  public override void UpdateHoverElements(List<KSelectable> selected)
  {
    string lastEnabledFilter = ToolMenu.Instance.toolParameterMenu.GetLastEnabledFilter();
    HoverTextScreen instance = HoverTextScreen.Instance;
    HoverTextDrawer drawer = instance.BeginDrawing();
    int cell = Grid.PosToCell(Camera.main.ScreenToWorldPoint(KInputManager.GetMousePos()));
    if (!Grid.IsValidCell(cell) || (int) Grid.WorldIdx[cell] != ClusterManager.Instance.activeWorldId)
    {
      drawer.EndDrawing();
    }
    else
    {
      drawer.BeginShadowBar();
      this.DrawTitle(instance, drawer);
      this.DrawInstructions(HoverTextScreen.Instance, drawer);
      if (lastEnabledFilter != null && lastEnabledFilter != this.lastUpdatedFilter)
        this.ConfigureTitle(instance);
      drawer.EndShadowBar();
      drawer.EndDrawing();
    }
  }

  protected override void ConfigureTitle(HoverTextScreen screen)
  {
    string lastEnabledFilter = ToolMenu.Instance.toolParameterMenu.GetLastEnabledFilter();
    if (string.IsNullOrEmpty(this.ToolName) || lastEnabledFilter == "ALL")
      this.ToolName = Strings.Get(this.ToolNameStringKey).String.ToUpper();
    if (lastEnabledFilter != null && lastEnabledFilter != "ALL")
      this.ToolName = string.Format((string) UI.TOOLS.CAPITALS, (object) (Strings.Get(this.ToolNameStringKey).String + string.Format((string) UI.TOOLS.FILTER_HOVERCARD_HEADER, (object) Strings.Get($"STRINGS.UI.TOOLS.FILTERLAYERS.{lastEnabledFilter}.TOOLTIP").String)));
    this.lastUpdatedFilter = lastEnabledFilter;
  }
}
