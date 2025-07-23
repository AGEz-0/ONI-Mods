// Decompiled with JetBrains decompiler
// Type: BabyHatchHardConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyHatchHardConfig : IEntityConfig
{
  public const string ID = "HatchHardBaby";

  public GameObject CreatePrefab()
  {
    GameObject hatch = HatchHardConfig.CreateHatch("HatchHardBaby", (string) CREATURES.SPECIES.HATCH.VARIANT_HARD.BABY.NAME, (string) CREATURES.SPECIES.HATCH.VARIANT_HARD.BABY.DESC, "baby_hatch_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(hatch, (Tag) "HatchHard");
    return hatch;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
