// Decompiled with JetBrains decompiler
// Type: Database.ClothingOutfitResource
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Database;

public class ClothingOutfitResource : Resource, IHasDlcRestrictions
{
  public ClothingOutfitUtility.OutfitType outfitType;
  public string[] requiredDlcIds;
  public string[] forbiddenDlcIds;

  public string[] itemsInOutfit { get; private set; }

  public ClothingOutfitResource(
    string id,
    string[] items_in_outfit,
    string name,
    ClothingOutfitUtility.OutfitType outfitType,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
    : base(id, name)
  {
    this.itemsInOutfit = items_in_outfit;
    this.outfitType = outfitType;
    this.requiredDlcIds = requiredDlcIds;
    this.forbiddenDlcIds = forbiddenDlcIds;
  }

  public Tuple<Sprite, Color> GetUISprite()
  {
    Sprite sprite = Assets.GetSprite((HashedString) "unknown");
    return new Tuple<Sprite, Color>(sprite, (Object) sprite != (Object) null ? Color.white : Color.clear);
  }

  public string GetDlcIdFrom()
  {
    return this.requiredDlcIds == null ? (string) null : ((IEnumerable<string>) this.requiredDlcIds).Last<string>();
  }

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
}
