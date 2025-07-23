// Decompiled with JetBrains decompiler
// Type: BabySquirrelHugConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabySquirrelHugConfig : IEntityConfig
{
  public const string ID = "SquirrelHugBaby";

  public GameObject CreatePrefab()
  {
    GameObject squirrelHug = SquirrelHugConfig.CreateSquirrelHug("SquirrelHugBaby", (string) CREATURES.SPECIES.SQUIRREL.VARIANT_HUG.BABY.NAME, (string) CREATURES.SPECIES.SQUIRREL.VARIANT_HUG.BABY.DESC, "baby_squirrel_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(squirrelHug, (Tag) "SquirrelHug");
    return squirrelHug;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
