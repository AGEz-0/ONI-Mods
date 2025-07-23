// Decompiled with JetBrains decompiler
// Type: Database.ClothingOutfits
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Database;

public class ClothingOutfits : ResourceSet<ClothingOutfitResource>
{
  public ClothingOutfits(ResourceSet parent, ClothingItems items_resource)
    : base(nameof (ClothingOutfits), parent)
  {
    this.Initialize();
    this.resources.AddRange((IEnumerable<ClothingOutfitResource>) Blueprints.Get().all.outfits);
    foreach (ClothingOutfitResource resource1 in this.resources)
    {
      foreach (string str in resource1.itemsInOutfit)
      {
        string itemId = str;
        int index = items_resource.resources.FindIndex((Predicate<ClothingItemResource>) (e => e.Id == itemId));
        if (index < 0)
        {
          DebugUtil.DevAssert(false, $"Outfit \"{resource1.Id}\" contains an item that doesn't exist. Given item id: \"{itemId}\"");
        }
        else
        {
          ClothingItemResource resource2 = items_resource.resources[index];
          if (resource2.outfitType != resource1.outfitType)
            DebugUtil.DevAssert(false, $"Outfit \"{resource1.Id}\" contains an item that has a mis-matched outfit type. Defined outfit's type: \"{resource1.outfitType}\". Given item: {{ id: \"{itemId}\" forOutfitType: \"{resource2.outfitType}\" }}");
        }
      }
    }
    ClothingOutfitUtility.LoadClothingOutfitData(this);
  }
}
