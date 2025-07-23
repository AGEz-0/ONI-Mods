// Decompiled with JetBrains decompiler
// Type: BabyPuftConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyPuftConfig : IEntityConfig
{
  public const string ID = "PuftBaby";

  public GameObject CreatePrefab()
  {
    GameObject puft = PuftConfig.CreatePuft("PuftBaby", (string) CREATURES.SPECIES.PUFT.BABY.NAME, (string) CREATURES.SPECIES.PUFT.BABY.DESC, "baby_puft_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(puft, (Tag) "Puft");
    return puft;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
