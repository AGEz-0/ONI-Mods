// Decompiled with JetBrains decompiler
// Type: BabyWoodDeerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyWoodDeerConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "WoodDeerBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject woodDeer = WoodDeerConfig.CreateWoodDeer("WoodDeerBaby", (string) CREATURES.SPECIES.WOODDEER.BABY.NAME, (string) CREATURES.SPECIES.WOODDEER.BABY.DESC, "baby_ice_floof_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(woodDeer, (Tag) "WoodDeer").AddOrGetDef<BabyMonitor.Def>().configureAdultOnMaturation = (Action<GameObject>) (go =>
    {
      AmountInstance amountInstance = Db.Get().Amounts.ScaleGrowth.Lookup(go);
      amountInstance.value = amountInstance.GetMax() * WoodDeerConfig.ANTLER_STARTING_GROWTH_PCT;
    });
    return woodDeer;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
