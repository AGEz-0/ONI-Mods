// Decompiled with JetBrains decompiler
// Type: ShadowImage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ShadowImage : ShadowRect
{
  private Image shadowImage;
  private Image mainImage;

  protected override void MatchRect()
  {
    base.MatchRect();
    if ((Object) this.RectMain == (Object) null || (Object) this.RectShadow == (Object) null)
      return;
    if ((Object) this.shadowImage == (Object) null)
      this.shadowImage = this.RectShadow.GetComponent<Image>();
    if ((Object) this.mainImage == (Object) null)
      this.mainImage = this.RectMain.GetComponent<Image>();
    if ((Object) this.mainImage == (Object) null)
    {
      if (!((Object) this.shadowImage != (Object) null))
        return;
      this.shadowImage.color = Color.clear;
    }
    else
    {
      if ((Object) this.shadowImage == (Object) null)
        return;
      if ((Object) this.shadowImage.sprite != (Object) this.mainImage.sprite)
        this.shadowImage.sprite = this.mainImage.sprite;
      if (!(this.shadowImage.color != this.shadowColor))
        return;
      if ((Object) this.shadowImage.sprite != (Object) null)
        this.shadowImage.color = this.shadowColor;
      else
        this.shadowImage.color = Color.clear;
    }
  }
}
