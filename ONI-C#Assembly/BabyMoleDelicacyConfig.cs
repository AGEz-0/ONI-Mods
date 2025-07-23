// Decompiled with JetBrains decompiler
// Type: BabyMoleDelicacyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyMoleDelicacyConfig : IEntityConfig
{
  public const string ID = "MoleDelicacyBaby";

  public GameObject CreatePrefab()
  {
    GameObject mole = MoleDelicacyConfig.CreateMole("MoleDelicacyBaby", (string) CREATURES.SPECIES.MOLE.VARIANT_DELICACY.BABY.NAME, (string) CREATURES.SPECIES.MOLE.VARIANT_DELICACY.BABY.DESC, "baby_driller_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(mole, (Tag) "MoleDelicacy");
    return mole;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst) => MoleConfig.SetSpawnNavType(inst);
}
