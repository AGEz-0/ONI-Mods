// Decompiled with JetBrains decompiler
// Type: BabySealConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabySealConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "SealBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject seal = SealConfig.CreateSeal("SealBaby", (string) CREATURES.SPECIES.SEAL.BABY.NAME, (string) CREATURES.SPECIES.SEAL.BABY.DESC, "baby_seal_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(seal, (Tag) "Seal");
    return seal;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
