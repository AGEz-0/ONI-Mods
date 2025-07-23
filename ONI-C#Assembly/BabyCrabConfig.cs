// Decompiled with JetBrains decompiler
// Type: BabyCrabConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyCrabConfig : IEntityConfig
{
  public const string ID = "CrabBaby";

  public GameObject CreatePrefab()
  {
    GameObject crab = CrabConfig.CreateCrab("CrabBaby", (string) CREATURES.SPECIES.CRAB.BABY.NAME, (string) CREATURES.SPECIES.CRAB.BABY.DESC, "baby_pincher_kanim", true, "CrabShell", 5f);
    EntityTemplates.ExtendEntityToBeingABaby(crab, (Tag) "Crab", "CrabShell");
    crab.AddOrGetDef<BabyMonitor.Def>().onGrowDropUnits = 5f;
    return crab;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
