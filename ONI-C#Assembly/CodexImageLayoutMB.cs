// Decompiled with JetBrains decompiler
// Type: CodexImageLayoutMB
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class CodexImageLayoutMB : UIBehaviour
{
  public RectTransform rectTransform;
  public LayoutElement layoutElement;
  public Image image;

  protected override void OnRectTransformDimensionsChange()
  {
    base.OnRectTransformDimensionsChange();
    if (this.image.preserveAspect && (Object) this.image.sprite != (Object) null && (bool) (Object) this.image.sprite)
    {
      UnityEngine.Rect rect = this.image.sprite.rect;
      double height = (double) rect.height;
      rect = this.image.sprite.rect;
      double width = (double) rect.width;
      this.layoutElement.preferredHeight = (float) (height / width) * this.rectTransform.sizeDelta.x;
      this.layoutElement.minHeight = this.layoutElement.preferredHeight;
    }
    else
    {
      this.layoutElement.preferredHeight = -1f;
      this.layoutElement.preferredWidth = -1f;
      this.layoutElement.minHeight = -1f;
      this.layoutElement.minWidth = -1f;
      this.layoutElement.flexibleHeight = -1f;
      this.layoutElement.flexibleWidth = -1f;
      this.layoutElement.ignoreLayout = false;
    }
  }
}
