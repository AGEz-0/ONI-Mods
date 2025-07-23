﻿// Decompiled with JetBrains decompiler
// Type: KleiPermitDioramaVis_Wallpaper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class KleiPermitDioramaVis_Wallpaper : KMonoBehaviour, IKleiPermitDioramaVisTarget
{
  [SerializeField]
  private Image itemSprite;
  private bool itemSpriteDidInit;
  private Vector2 itemSpritePosStart;
  private Vector2 itemSpritePosEnd;

  public GameObject GetGameObject() => this.gameObject;

  public void ConfigureSetup()
  {
  }

  public void ConfigureWith(PermitResource permit)
  {
    PermitPresentationInfo presentationInfo = permit.GetPermitPresentationInfo();
    this.itemSprite.rectTransform().sizeDelta = Vector2.one * 176f;
    this.itemSprite.sprite = presentationInfo.sprite;
    if (!this.itemSpriteDidInit)
    {
      this.itemSpriteDidInit = true;
      this.itemSpritePosStart = this.itemSprite.rectTransform.anchoredPosition + new Vector2(0.0f, 16f);
      this.itemSpritePosEnd = this.itemSprite.rectTransform.anchoredPosition;
    }
    this.itemSprite.StartCoroutine((IEnumerator) Updater.Parallel(Updater.Ease((Action<float>) (alpha => this.itemSprite.color = new Color(1f, 1f, 1f, alpha)), 0.0f, 1f, 0.2f, Easing.SmoothStep, 0.1f), Updater.Ease((Action<Vector2>) (position => this.itemSprite.rectTransform.anchoredPosition = position), this.itemSpritePosStart, this.itemSpritePosEnd, 0.2f, Easing.SmoothStep, 0.1f)));
  }
}
