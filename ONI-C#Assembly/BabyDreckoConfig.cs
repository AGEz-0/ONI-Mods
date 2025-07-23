// Decompiled with JetBrains decompiler
// Type: BabyDreckoConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyDreckoConfig : IEntityConfig
{
  public const string ID = "DreckoBaby";

  public GameObject CreatePrefab()
  {
    GameObject drecko = DreckoConfig.CreateDrecko("DreckoBaby", (string) CREATURES.SPECIES.DRECKO.BABY.NAME, (string) CREATURES.SPECIES.DRECKO.BABY.DESC, "baby_drecko_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(drecko, (Tag) "Drecko");
    return drecko;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
