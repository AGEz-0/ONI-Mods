﻿// Decompiled with JetBrains decompiler
// Type: ElectrobankConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ElectrobankConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "Electrobank";
  public const float MASS = 20f;
  public const float POWER_CAPACITY = 120000f;
  public static ComplexRecipe recipe;

  public string[] GetRequiredDlcIds() => DlcManager.DLC3;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("Electrobank", (string) STRINGS.ITEMS.INDUSTRIAL_PRODUCTS.ELECTROBANK.NAME, (string) STRINGS.ITEMS.INDUSTRIAL_PRODUCTS.ELECTROBANK.DESC, 20f, true, Assets.GetAnim((HashedString) "electrobank_large_kanim"), "idle1", Grid.SceneLayer.Ore, EntityTemplates.CollisionShape.RECTANGLE, 0.5f, 0.8f, true, element: SimHashes.Katairite, additionalTags: new List<Tag>()
    {
      GameTags.ChargedPortableBattery,
      GameTags.PedestalDisplayable
    });
    if (!Assets.IsTagCountable(GameTags.ChargedPortableBattery))
      Assets.AddCountableTag(GameTags.ChargedPortableBattery);
    looseEntity.AddTag(GameTags.IndustrialProduct);
    looseEntity.AddComponent<Electrobank>().rechargeable = true;
    looseEntity.AddOrGet<OccupyArea>().SetCellOffsets(EntityTemplates.GenerateOffsets(1, 1));
    looseEntity.AddOrGet<DecorProvider>().SetValues(TUNING.DECOR.PENALTY.TIER0);
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
