// Decompiled with JetBrains decompiler
// Type: BabyCrabFreshWaterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyCrabFreshWaterConfig : IEntityConfig
{
  public const string ID = "CrabFreshWaterBaby";

  public GameObject CreatePrefab()
  {
    GameObject crabFreshWater = CrabFreshWaterConfig.CreateCrabFreshWater("CrabFreshWaterBaby", (string) CREATURES.SPECIES.CRAB.VARIANT_FRESH_WATER.BABY.NAME, (string) CREATURES.SPECIES.CRAB.VARIANT_FRESH_WATER.BABY.DESC, "baby_pincher_kanim", true, "ShellfishMeat", 4);
    EntityTemplates.ExtendEntityToBeingABaby(crabFreshWater, (Tag) "CrabFreshWater");
    return crabFreshWater;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
