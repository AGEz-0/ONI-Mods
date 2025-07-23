// Decompiled with JetBrains decompiler
// Type: ClothingItemInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using System;

#nullable disable
public class ClothingItemInfo : IBlueprintInfo, IHasDlcRestrictions
{
  public ClothingOutfitUtility.OutfitType outfitType;
  public PermitCategory category;
  private string[] requiredDlcIds;
  private string[] forbiddenDlcIds;

  public string id { get; set; }

  public string name { get; set; }

  public string desc { get; set; }

  public PermitRarity rarity { get; set; }

  public string animFile { get; set; }

  public ClothingItemInfo(
    string id,
    string name,
    string desc,
    PermitCategory category,
    PermitRarity rarity,
    string animFile,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
  {
    Option<ClothingOutfitUtility.OutfitType> outfitTypeFor = PermitCategories.GetOutfitTypeFor(category);
    if (outfitTypeFor.IsNone())
      throw new Exception($"Expected permit category {category} on ClothingItemResource \"{id}\" to have an {"OutfitType"} but none found.");
    this.id = id;
    this.name = name;
    this.desc = desc;
    this.outfitType = outfitTypeFor.Unwrap();
    this.category = category;
    this.rarity = rarity;
    this.animFile = animFile;
    this.requiredDlcIds = requiredDlcIds;
    this.forbiddenDlcIds = forbiddenDlcIds;
  }

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
}
