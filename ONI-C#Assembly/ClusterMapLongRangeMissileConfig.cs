// Decompiled with JetBrains decompiler
// Type: ClusterMapLongRangeMissileConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ClusterMapLongRangeMissileConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "ClusterMapLongRangeMissile";
  public const float MASS = 2000f;
  public const float STARMAP_SPEED = 10f;

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject basicEntity = EntityTemplates.CreateBasicEntity("ClusterMapLongRangeMissile", (string) ITEMS.MISSILE_LONGRANGE.NAME, (string) ITEMS.MISSILE_LONGRANGE.DESC, 2000f, true, Assets.GetAnim((HashedString) "longrange_missile_clustermap_kanim"), "object", Grid.SceneLayer.Front, additionalTags: new List<Tag>()
    {
      GameTags.IgnoreMaterialCategory,
      GameTags.Experimental
    });
    basicEntity.AddOrGetDef<ClusterMapLongRangeMissile.Def>();
    basicEntity.AddComponent<LoopingSounds>();
    basicEntity.AddOrGet<KSelectable>().IsSelectable = true;
    ClusterMapLongRangeMissileGridEntity missileGridEntity = basicEntity.AddOrGet<ClusterMapLongRangeMissileGridEntity>();
    missileGridEntity.clusterAnimName = "longrange_missile_clustermap_kanim";
    missileGridEntity.isWorldEntity = false;
    missileGridEntity.nameKey = new StringKey("STRINGS.ITEMS.MISSILE_LONGRANGE.NAME");
    missileGridEntity.keepRotationWhenSpacingOutInHex = true;
    ClusterDestinationSelector destinationSelector = basicEntity.AddOrGet<ClusterDestinationSelector>();
    destinationSelector.canNavigateFogOfWar = false;
    destinationSelector.dodgesHiddenAsteroids = true;
    destinationSelector.requireAsteroidDestination = false;
    destinationSelector.requireLaunchPadOnAsteroidDestination = false;
    destinationSelector.assignable = false;
    destinationSelector.shouldPointTowardsPath = true;
    basicEntity.AddOrGet<ClusterTraveler>();
    return basicEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
