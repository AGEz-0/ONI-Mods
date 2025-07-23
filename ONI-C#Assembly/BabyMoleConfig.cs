// Decompiled with JetBrains decompiler
// Type: BabyMoleConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyMoleConfig : IEntityConfig
{
  public const string ID = "MoleBaby";

  public GameObject CreatePrefab()
  {
    GameObject mole = MoleConfig.CreateMole("MoleBaby", (string) CREATURES.SPECIES.MOLE.BABY.NAME, (string) CREATURES.SPECIES.MOLE.BABY.DESC, "baby_driller_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(mole, (Tag) "Mole");
    return mole;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst) => MoleConfig.SetSpawnNavType(inst);
}
