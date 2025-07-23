﻿// Decompiled with JetBrains decompiler
// Type: LightColorMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/LightColorMenu")]
public class LightColorMenu : KMonoBehaviour
{
  public LightColorMenu.LightColor[] lightColors;
  private int currentColor;
  private static readonly EventSystem.IntraObjectHandler<LightColorMenu> OnRefreshUserMenuDelegate = new EventSystem.IntraObjectHandler<LightColorMenu>((Action<LightColorMenu, object>) ((component, data) => component.OnRefreshUserMenu(data)));

  protected override void OnPrefabInit()
  {
    this.Subscribe<LightColorMenu>(493375141, LightColorMenu.OnRefreshUserMenuDelegate);
    this.SetColor(0);
  }

  private void OnRefreshUserMenu(object data)
  {
    if (this.lightColors.Length == 0)
      return;
    int length = this.lightColors.Length;
    for (int index = 0; index < length; ++index)
    {
      if (index != this.currentColor)
      {
        int new_color = index;
        Game.Instance.userMenu.AddButton(this.gameObject, new KIconButtonMenu.ButtonInfo(this.lightColors[index].name, this.lightColors[index].name, (System.Action) (() => this.SetColor(new_color))));
      }
    }
  }

  private void SetColor(int color_index)
  {
    if (this.lightColors.Length != 0 && color_index < this.lightColors.Length)
    {
      foreach (Light2D componentsInChild in this.GetComponentsInChildren<Light2D>(true))
        componentsInChild.Color = this.lightColors[color_index].color;
      foreach (Renderer componentsInChild in this.GetComponentsInChildren<MeshRenderer>(true))
      {
        foreach (Material material in componentsInChild.materials)
        {
          if (material.name.StartsWith("matScriptedGlow01"))
            material.color = this.lightColors[color_index].color;
        }
      }
    }
    this.currentColor = color_index;
  }

  [Serializable]
  public struct LightColor(string name, Color color)
  {
    public string name = name;
    public Color color = color;
  }
}
