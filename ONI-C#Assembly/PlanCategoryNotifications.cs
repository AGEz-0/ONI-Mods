// Decompiled with JetBrains decompiler
// Type: PlanCategoryNotifications
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class PlanCategoryNotifications : MonoBehaviour
{
  public Image AttentionImage;

  public void ToggleAttention(bool active)
  {
    if (!(bool) (Object) this.AttentionImage)
      return;
    this.AttentionImage.gameObject.SetActive(active);
  }
}
