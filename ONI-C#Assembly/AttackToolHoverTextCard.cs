// Decompiled with JetBrains decompiler
// Type: AttackToolHoverTextCard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AttackToolHoverTextCard : HoverTextConfiguration
{
  public override void UpdateHoverElements(List<KSelectable> hover_objects)
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
      this.DrawTitle(instance, drawer);
      this.DrawInstructions(HoverTextScreen.Instance, drawer);
      drawer.EndShadowBar();
      if (hover_objects != null)
      {
        foreach (KSelectable hoverObject in hover_objects)
        {
          if ((Object) hoverObject.GetComponent<AttackableBase>() != (Object) null)
          {
            drawer.BeginShadowBar();
            drawer.DrawText(hoverObject.GetProperName().ToUpper(), this.Styles_Title.Standard);
            drawer.EndShadowBar();
            break;
          }
        }
      }
      drawer.EndDrawing();
    }
  }
}
