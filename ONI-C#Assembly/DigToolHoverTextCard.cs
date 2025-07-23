﻿// Decompiled with JetBrains decompiler
// Type: DigToolHoverTextCard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class DigToolHoverTextCard : HoverTextConfiguration
{
  private DigToolHoverTextCard.HoverScreenFields hoverScreenElements;

  public override void UpdateHoverElements(List<KSelectable> selected)
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
      if (Grid.IsVisible(cell))
      {
        this.DrawTitle(instance, drawer);
        this.DrawInstructions(HoverTextScreen.Instance, drawer);
        Element element = Grid.Element[cell];
        bool flag = false;
        if (Grid.Solid[cell] && Diggable.IsDiggable(cell))
          flag = true;
        if (flag)
        {
          drawer.NewLine();
          drawer.DrawText(element.nameUpperCase, this.Styles_Title.Standard);
          drawer.NewLine();
          drawer.DrawIcon(instance.GetSprite("dash"));
          drawer.DrawText(element.GetMaterialCategoryTag().ProperName(), this.Styles_BodyText.Standard);
          drawer.NewLine();
          drawer.DrawIcon(instance.GetSprite("dash"));
          string[] strArray = HoverTextHelper.MassStringsReadOnly(cell);
          drawer.DrawText(strArray[0], this.Styles_Values.Property.Standard);
          drawer.DrawText(strArray[1], this.Styles_Values.Property_Decimal.Standard);
          drawer.DrawText(strArray[2], this.Styles_Values.Property.Standard);
          drawer.DrawText(strArray[3], this.Styles_Values.Property.Standard);
          drawer.NewLine();
          drawer.DrawIcon(instance.GetSprite("dash"));
          drawer.DrawText(GameUtil.GetHardnessString(Grid.Element[cell]), this.Styles_BodyText.Standard);
        }
      }
      else
      {
        drawer.DrawIcon(instance.GetSprite("iconWarning"));
        drawer.DrawText((string) STRINGS.UI.TOOLS.GENERIC.UNKNOWN, this.Styles_BodyText.Standard);
      }
      drawer.EndShadowBar();
      drawer.EndDrawing();
    }
  }

  private struct HoverScreenFields
  {
    public GameObject UnknownAreaLine;
    public Image ElementStateIcon;
    public LocText ElementCategory;
    public LocText ElementName;
    public LocText[] ElementMass;
    public LocText ElementHardness;
    public LocText ElementHardnessDescription;
  }
}
