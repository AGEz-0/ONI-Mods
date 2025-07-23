// Decompiled with JetBrains decompiler
// Type: BabyDivergentBeetleConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyDivergentBeetleConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "DivergentBeetleBaby";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject divergentBeetle = DivergentBeetleConfig.CreateDivergentBeetle("DivergentBeetleBaby", (string) CREATURES.SPECIES.DIVERGENT.VARIANT_BEETLE.BABY.NAME, (string) CREATURES.SPECIES.DIVERGENT.VARIANT_BEETLE.BABY.DESC, "baby_critter_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(divergentBeetle, (Tag) "DivergentBeetle");
    return divergentBeetle;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
