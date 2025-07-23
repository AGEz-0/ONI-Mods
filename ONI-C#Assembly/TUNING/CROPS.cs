﻿// Decompiled with JetBrains decompiler
// Type: TUNING.CROPS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace TUNING;

public class CROPS
{
  public const float WILD_GROWTH_RATE_MODIFIER = 0.25f;
  public const float GROWTH_RATE = 0.00166666671f;
  public const float WILD_GROWTH_RATE = 0.000416666677f;
  public const float PLANTERPLOT_GROWTH_PENTALY = -0.5f;
  public const float BASE_BONUS_SEED_PROBABILITY = 0.1f;
  public const float SELF_HARVEST_TIME = 2400f;
  public const float SELF_PLANT_TIME = 2400f;
  public const float TREE_BRANCH_SELF_HARVEST_TIME = 12000f;
  public const float FERTILIZATION_GAIN_RATE = 1.66666663f;
  public const float FERTILIZATION_LOSS_RATE = -0.166666672f;
  public static List<Crop.CropVal> CROP_TYPES = new List<Crop.CropVal>()
  {
    new Crop.CropVal("BasicPlantFood", 1800f),
    new Crop.CropVal(PrickleFruitConfig.ID, 3600f),
    new Crop.CropVal(SwampFruitConfig.ID, 3960f),
    new Crop.CropVal(MushroomConfig.ID, 4500f),
    new Crop.CropVal("ColdWheatSeed", 10800f, 18),
    new Crop.CropVal(SpiceNutConfig.ID, 4800f, 4),
    new Crop.CropVal(BasicFabricConfig.ID, 1200f),
    new Crop.CropVal(SwampLilyFlowerConfig.ID, 7200f, 2),
    new Crop.CropVal("GasGrassHarvested", 2400f),
    new Crop.CropVal("WoodLog", 2700f, 300),
    new Crop.CropVal(SimHashes.WoodLog.ToString(), 2700f, 300),
    new Crop.CropVal(SimHashes.SugarWater.ToString(), 150f, 20),
    new Crop.CropVal("SpaceTreeBranch", 2700f),
    new Crop.CropVal("HardSkinBerry", 1800f),
    new Crop.CropVal(CarrotConfig.ID, 5400f),
    new Crop.CropVal(VineFruitConfig.ID, 1800f),
    new Crop.CropVal(SimHashes.OxyRock.ToString(), 1200f, 2 * Mathf.RoundToInt(17.76f)),
    new Crop.CropVal("Lettuce", 7200f, 12),
    new Crop.CropVal(KelpConfig.ID, 3000f, 50),
    new Crop.CropVal("BeanPlantSeed", 12600f, 12),
    new Crop.CropVal("OxyfernSeed", 7200f),
    new Crop.CropVal("PlantMeat", 18000f, 10),
    new Crop.CropVal("WormBasicFruit", 2400f),
    new Crop.CropVal("WormSuperFruit", 4800f, 8),
    new Crop.CropVal(DewDripConfig.ID, 1200f),
    new Crop.CropVal(FernFoodConfig.ID, 5400f, 36),
    new Crop.CropVal(SimHashes.Salt.ToString(), 3600f, 65),
    new Crop.CropVal(SimHashes.Water.ToString(), 6000f, 350),
    new Crop.CropVal(SimHashes.Amber.ToString(), 7200f, 264),
    new Crop.CropVal("GardenFoodPlantFood", 1800f),
    new Crop.CropVal("Butterfly", 3000f)
  };
}
