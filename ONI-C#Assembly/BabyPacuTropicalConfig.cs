// Decompiled with JetBrains decompiler
// Type: BabyPacuTropicalConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyPacuTropicalConfig : IEntityConfig
{
  public const string ID = "PacuTropicalBaby";

  public GameObject CreatePrefab()
  {
    GameObject pacu = PacuTropicalConfig.CreatePacu("PacuTropicalBaby", (string) CREATURES.SPECIES.PACU.VARIANT_TROPICAL.BABY.NAME, (string) CREATURES.SPECIES.PACU.VARIANT_TROPICAL.BABY.DESC, "baby_pacu_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(pacu, (Tag) "PacuTropical");
    return pacu;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
