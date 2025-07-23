// Decompiled with JetBrains decompiler
// Type: InfoScreenSpriteItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/InfoScreenSpriteItem")]
public class InfoScreenSpriteItem : KMonoBehaviour
{
  [SerializeField]
  private Image image;
  [SerializeField]
  private LayoutElement layout;

  public void SetSprite(Sprite sprite)
  {
    this.image.sprite = sprite;
    UnityEngine.Rect rect = sprite.rect;
    double width = (double) rect.width;
    rect = sprite.rect;
    double height = (double) rect.height;
    this.layout.preferredWidth = this.layout.preferredHeight * (float) (width / height);
  }
}
