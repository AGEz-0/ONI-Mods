// Decompiled with JetBrains decompiler
// Type: BabyPacuConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyPacuConfig : IEntityConfig
{
  public const string ID = "PacuBaby";

  public GameObject CreatePrefab()
  {
    GameObject pacu = PacuConfig.CreatePacu("PacuBaby", (string) CREATURES.SPECIES.PACU.BABY.NAME, (string) CREATURES.SPECIES.PACU.BABY.DESC, "baby_pacu_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(pacu, (Tag) "Pacu");
    return pacu;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
