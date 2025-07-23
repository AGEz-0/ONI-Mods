// Decompiled with JetBrains decompiler
// Type: KleiItemDropScreen_PermitVis_Fallback
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class KleiItemDropScreen_PermitVis_Fallback : KMonoBehaviour
{
  [SerializeField]
  private Image sprite;

  public void ConfigureWith(DropScreenPresentationInfo info) => this.sprite.sprite = info.Sprite;
}
