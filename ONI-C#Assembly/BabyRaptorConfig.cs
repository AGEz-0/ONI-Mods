﻿// Decompiled with JetBrains decompiler
// Type: BabyRaptorConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class BabyRaptorConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "RaptorBaby";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject raptor = RaptorConfig.CreateRaptor("RaptorBaby", (string) CREATURES.SPECIES.RAPTOR.BABY.NAME, (string) CREATURES.SPECIES.RAPTOR.BABY.DESC, "baby_raptor_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(raptor, (Tag) "Raptor").AddOrGetDef<BabyMonitor.Def>().configureAdultOnMaturation = (Action<GameObject>) (go =>
    {
      AmountInstance amountInstance = Db.Get().Amounts.ScaleGrowth.Lookup(go);
      amountInstance.value = amountInstance.GetMax() * RaptorConfig.SCALE_INITIAL_GROWTH_PCT;
    });
    return raptor;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
