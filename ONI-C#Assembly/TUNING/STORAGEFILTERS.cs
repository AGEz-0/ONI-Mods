﻿// Decompiled with JetBrains decompiler
// Type: TUNING.STORAGEFILTERS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace TUNING;

public class STORAGEFILTERS
{
  public static List<Tag> DEHYDRATED = new List<Tag>()
  {
    GameTags.Dehydrated
  };
  public static List<Tag> FOOD = new List<Tag>()
  {
    GameTags.Edible,
    GameTags.CookingIngredient,
    GameTags.Medicine
  };
  public static List<Tag> BAGABLE_CREATURES = new List<Tag>()
  {
    GameTags.BagableCreature
  };
  public static List<Tag> SWIMMING_CREATURES = new List<Tag>()
  {
    GameTags.SwimmingCreature
  };
  public static List<Tag> NOT_EDIBLE_SOLIDS = new List<Tag>()
  {
    GameTags.Alloy,
    GameTags.RefinedMetal,
    GameTags.Metal,
    GameTags.BuildableRaw,
    GameTags.BuildableProcessed,
    GameTags.Farmable,
    GameTags.Organics,
    GameTags.Compostable,
    GameTags.Seed,
    GameTags.Agriculture,
    GameTags.Filter,
    GameTags.ConsumableOre,
    GameTags.Sublimating,
    GameTags.Liquifiable,
    GameTags.IndustrialProduct,
    GameTags.IndustrialIngredient,
    GameTags.MedicalSupplies,
    GameTags.Clothes,
    GameTags.ManufacturedMaterial,
    GameTags.Egg,
    GameTags.RareMaterials,
    GameTags.Other,
    GameTags.StoryTraitResource,
    GameTags.Dehydrated,
    GameTags.ChargedPortableBattery,
    GameTags.BionicUpgrade
  };
  public static List<Tag> SPECIAL_STORAGE = new List<Tag>()
  {
    GameTags.Clothes,
    GameTags.Egg,
    GameTags.Sublimating
  };
  public static List<Tag> STORAGE_LOCKERS_STANDARD = STORAGEFILTERS.NOT_EDIBLE_SOLIDS.Union<Tag>((IEnumerable<Tag>) new List<Tag>()
  {
    GameTags.Medicine
  }).ToList<Tag>();
  public static List<Tag> POWER_BANKS = new List<Tag>()
  {
    GameTags.ChargedPortableBattery
  };
  public static List<Tag> LIQUIDS = new List<Tag>()
  {
    GameTags.Liquid
  };
  public static List<Tag> GASES = new List<Tag>()
  {
    GameTags.Breathable,
    GameTags.Unbreathable
  };
  public static List<Tag> PAYLOADS = new List<Tag>()
  {
    (Tag) "RailGunPayload"
  };
  public static Tag[] SOLID_TRANSFER_ARM_CONVEYABLE = new List<Tag>()
  {
    GameTags.Seed,
    GameTags.CropSeed
  }.Concat<Tag>(STORAGEFILTERS.STORAGE_LOCKERS_STANDARD.Concat<Tag>((IEnumerable<Tag>) STORAGEFILTERS.FOOD).Concat<Tag>((IEnumerable<Tag>) STORAGEFILTERS.PAYLOADS)).ToArray<Tag>();
}
