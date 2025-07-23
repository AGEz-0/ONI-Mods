// Decompiled with JetBrains decompiler
// Type: BabyPrehistoricPacuConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyPrehistoricPacuConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "PrehistoricPacuBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject prehistoricPacu = PrehistoricPacuConfig.CreatePrehistoricPacu("PrehistoricPacuBaby", (string) CREATURES.SPECIES.PREHISTORICPACU.BABY.NAME, (string) CREATURES.SPECIES.PREHISTORICPACU.BABY.DESC, "baby_paculacanth_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(prehistoricPacu, (Tag) "PrehistoricPacu");
    return prehistoricPacu;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
