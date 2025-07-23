﻿// Decompiled with JetBrains decompiler
// Type: HoverTextScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HoverTextScreen : KScreen
{
  [SerializeField]
  private HoverTextSkin skin;
  public Sprite[] HoverIcons;
  public HoverTextDrawer drawer;
  public static HoverTextScreen Instance;

  public static void DestroyInstance() => HoverTextScreen.Instance = (HoverTextScreen) null;

  protected override void OnActivate()
  {
    base.OnActivate();
    HoverTextScreen.Instance = this;
    this.drawer = new HoverTextDrawer(this.skin.skin, this.GetComponent<RectTransform>());
  }

  public HoverTextDrawer BeginDrawing()
  {
    Vector2 localPoint = Vector2.zero;
    Vector2 mousePos = (Vector2) KInputManager.GetMousePos();
    RectTransform parent = this.transform.parent as RectTransform;
    RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, mousePos, this.transform.parent.GetComponent<Canvas>().worldCamera, out localPoint);
    localPoint.x += parent.sizeDelta.x / 2f;
    localPoint.y -= parent.sizeDelta.y / 2f;
    this.drawer.BeginDrawing(localPoint);
    return this.drawer;
  }

  private void Update()
  {
    this.drawer.SetEnabled(PlayerController.Instance.ActiveTool.ShowHoverUI());
  }

  public Sprite GetSprite(string byName)
  {
    foreach (Sprite hoverIcon in this.HoverIcons)
    {
      if ((Object) hoverIcon != (Object) null && hoverIcon.name == byName)
        return hoverIcon;
    }
    Debug.LogWarning((object) $"No icon named {byName} was found on HoverTextScreen.prefab");
    return (Sprite) null;
  }

  protected override void OnCleanUp()
  {
    base.OnCleanUp();
    this.drawer.Cleanup();
  }
}
