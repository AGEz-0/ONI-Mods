// Decompiled with JetBrains decompiler
// Type: PlaceToolHoverTextCard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class PlaceToolHoverTextCard : HoverTextConfiguration
{
  public Placeable currentPlaceable;

  public override void UpdateHoverElements(List<KSelectable> hoverObjects)
  {
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
      this.ActionName = (string) UI.TOOLS.PLACE.TOOLACTION;
      if ((Object) this.currentPlaceable != (Object) null && this.currentPlaceable.GetProperName() != null)
        this.ToolName = string.Format((string) UI.TOOLS.PLACE.NAME, (object) this.currentPlaceable.GetProperName());
      this.DrawTitle(instance, drawer);
      this.DrawInstructions(instance, drawer);
      int min_height = 26;
      int width = 8;
      string reason;
      if ((Object) this.currentPlaceable != (Object) null && !this.currentPlaceable.IsValidPlaceLocation(cell, out reason))
      {
        drawer.NewLine(min_height);
        drawer.AddIndent(width);
        drawer.DrawText(reason, this.HoverTextStyleSettings[1]);
      }
      drawer.EndShadowBar();
      drawer.EndDrawing();
    }
  }
}
