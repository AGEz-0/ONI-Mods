// Decompiled with JetBrains decompiler
// Type: PrebuildToolHoverTextCard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class PrebuildToolHoverTextCard : HoverTextConfiguration
{
  public string errorMessage;
  public BuildingDef currentDef;

  public override void UpdateHoverElements(List<KSelectable> selected)
  {
    HoverTextScreen instance = HoverTextScreen.Instance;
    HoverTextDrawer hoverTextDrawer = instance.BeginDrawing();
    int cell = Grid.PosToCell(Camera.main.ScreenToWorldPoint(KInputManager.GetMousePos()));
    if (!Grid.IsValidCell(cell) || (int) Grid.WorldIdx[cell] != ClusterManager.Instance.activeWorldId)
    {
      hoverTextDrawer.EndDrawing();
    }
    else
    {
      hoverTextDrawer.BeginShadowBar();
      if (!this.errorMessage.IsNullOrWhiteSpace())
      {
        bool flag = true;
        foreach (string str in this.errorMessage.Split('\n', StringSplitOptions.None))
        {
          if (!flag)
            hoverTextDrawer.NewLine();
          hoverTextDrawer.DrawText(str.ToUpper(), this.HoverTextStyleSettings[flag ? 0 : 1]);
          flag = false;
        }
      }
      hoverTextDrawer.NewLine();
      if (KInputManager.currentControllerIsGamepad)
        hoverTextDrawer.DrawIcon(KInputManager.steamInputInterpreter.GetActionSprite(Action.MouseRight), 20);
      else
        hoverTextDrawer.DrawIcon(instance.GetSprite("icon_mouse_right"), 20);
      hoverTextDrawer.DrawText(this.backStr, this.Styles_Instruction.Standard);
      hoverTextDrawer.EndShadowBar();
      hoverTextDrawer.EndDrawing();
    }
  }
}
