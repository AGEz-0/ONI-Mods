// Decompiled with JetBrains decompiler
// Type: ValueTrendImageToggle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ValueTrendImageToggle : MonoBehaviour
{
  public Image targetImage;
  public Sprite Up_One;
  public Sprite Up_Two;
  public Sprite Up_Three;
  public Sprite Down_One;
  public Sprite Down_Two;
  public Sprite Down_Three;
  public Sprite Zero;

  public void SetValue(AmountInstance ainstance)
  {
    float delta = ainstance.GetDelta();
    Sprite sprite = (Sprite) null;
    if (ainstance.paused || (double) delta == 0.0)
    {
      this.targetImage.gameObject.SetActive(false);
    }
    else
    {
      this.targetImage.gameObject.SetActive(true);
      if ((double) delta <= -(double) ainstance.amount.visualDeltaThreshold * 2.0)
        sprite = this.Down_Three;
      else if ((double) delta <= -(double) ainstance.amount.visualDeltaThreshold)
        sprite = this.Down_Two;
      else if ((double) delta <= 0.0)
        sprite = this.Down_One;
      else if ((double) delta > (double) ainstance.amount.visualDeltaThreshold * 2.0)
        sprite = this.Up_Three;
      else if ((double) delta > (double) ainstance.amount.visualDeltaThreshold)
        sprite = this.Up_Two;
      else if ((double) delta > 0.0)
        sprite = this.Up_One;
    }
    this.targetImage.sprite = sprite;
  }
}
