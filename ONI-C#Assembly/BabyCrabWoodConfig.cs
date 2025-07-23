// Decompiled with JetBrains decompiler
// Type: BabyCrabWoodConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyCrabWoodConfig : IEntityConfig
{
  public const string ID = "CrabWoodBaby";

  public GameObject CreatePrefab()
  {
    GameObject crabWood = CrabWoodConfig.CreateCrabWood("CrabWoodBaby", (string) CREATURES.SPECIES.CRAB.VARIANT_WOOD.BABY.NAME, (string) CREATURES.SPECIES.CRAB.VARIANT_WOOD.BABY.DESC, "baby_pincher_kanim", true, deathDropCount: 10f);
    EntityTemplates.ExtendEntityToBeingABaby(crabWood, (Tag) "CrabWood", "CrabWoodShell");
    crabWood.AddOrGetDef<BabyMonitor.Def>().onGrowDropUnits = 50f;
    return crabWood;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
