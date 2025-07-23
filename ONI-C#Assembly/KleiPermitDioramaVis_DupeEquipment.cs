// Decompiled with JetBrains decompiler
// Type: KleiPermitDioramaVis_DupeEquipment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class KleiPermitDioramaVis_DupeEquipment : KMonoBehaviour, IKleiPermitDioramaVisTarget
{
  [SerializeField]
  private UIMannequin uiMannequin;
  [Header("Diorama Backgrounds")]
  [SerializeField]
  private Image dioramaBGImage;
  [SerializeField]
  private Sprite clothingBG;
  [SerializeField]
  private Sprite atmosuitBG;

  public GameObject GetGameObject() => this.gameObject;

  public void ConfigureSetup() => this.uiMannequin.shouldShowOutfitWithDefaultItems = false;

  public void ConfigureWith(PermitResource permit)
  {
    if (permit is ClothingItemResource clothingItemResource)
    {
      this.uiMannequin.SetOutfit(clothingItemResource.outfitType, (IEnumerable<ClothingItemResource>) new ClothingItemResource[1]
      {
        clothingItemResource
      });
      this.uiMannequin.ReactToClothingItemChange(clothingItemResource.Category);
    }
    this.dioramaBGImage.sprite = KleiPermitDioramaVis.GetDioramaBackground(permit.Category);
  }
}
