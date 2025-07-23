// Decompiled with JetBrains decompiler
// Type: BabyChameleonConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyChameleonConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "ChameleonBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject chameleon = ChameleonConfig.CreateChameleon("ChameleonBaby", (string) CREATURES.SPECIES.CHAMELEON.BABY.NAME, (string) CREATURES.SPECIES.CHAMELEON.BABY.DESC, "baby_chameleo_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(chameleon, (Tag) "Chameleon");
    return chameleon;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
