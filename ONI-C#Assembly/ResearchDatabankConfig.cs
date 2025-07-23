﻿// Decompiled with JetBrains decompiler
// Type: ResearchDatabankConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ResearchDatabankConfig : IEntityConfig
{
  public const string ID = "ResearchDatabank";
  public static readonly Tag TAG = TagManager.Create("ResearchDatabank");
  public const float MASS = 1f;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("ResearchDatabank", (string) STRINGS.ITEMS.INDUSTRIAL_PRODUCTS.RESEARCH_DATABANK.NAME, (string) STRINGS.ITEMS.INDUSTRIAL_PRODUCTS.RESEARCH_DATABANK.DESC, 1f, true, Assets.GetAnim((HashedString) "floppy_disc_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.CIRCLE, 0.35f, 0.35f, true, additionalTags: new List<Tag>()
    {
      GameTags.IndustrialIngredient,
      GameTags.Experimental
    });
    if (DlcManager.FeatureClusterSpaceEnabled())
      looseEntity.AddTag(GameTags.HideFromSpawnTool);
    looseEntity.AddOrGet<EntitySplitter>().maxStackSize = (float) TUNING.ROCKETRY.DESTINATION_RESEARCH.BASIC;
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
    if (!Game.IsDlcActiveForCurrentSave("DLC2_ID") || SaveLoader.Instance.ClusterLayout == null || !SaveLoader.Instance.ClusterLayout.clusterTags.Contains("CeresCluster"))
      return;
    inst.AddOrGet<KBatchedAnimController>().SwapAnims(new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "floppy_disc_ceres_kanim")
    });
  }
}
