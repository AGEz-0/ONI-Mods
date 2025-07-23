// Decompiled with JetBrains decompiler
// Type: DehydratedSurfAndTurfConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DehydratedSurfAndTurfConfig : IEntityConfig
{
  public static Tag ID = new Tag("DehydratedSurfAndTurf");
  public const float MASS = 1f;
  public const int FABRICATION_TIME_SECONDS = 300;
  public const string ANIM_FILE = "dehydrated_food_surf_and_turf_kanim";
  public const string INITIAL_ANIM = "idle";

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }

  public GameObject CreatePrefab()
  {
    KAnimFile anim = Assets.GetAnim((HashedString) "dehydrated_food_surf_and_turf_kanim");
    GameObject looseEntity = EntityTemplates.CreateLooseEntity(DehydratedSurfAndTurfConfig.ID.Name, (string) STRINGS.ITEMS.FOOD.SURFANDTURF.DEHYDRATED.NAME, (string) STRINGS.ITEMS.FOOD.SURFANDTURF.DEHYDRATED.DESC, 1f, true, anim, "idle", Grid.SceneLayer.BuildingFront, EntityTemplates.CollisionShape.RECTANGLE, 0.6f, 0.7f, true, element: SimHashes.Polypropylene);
    EntityTemplates.ExtendEntityToDehydratedFoodPackage(looseEntity, TUNING.FOOD.FOOD_TYPES.SURF_AND_TURF);
    return looseEntity;
  }
}
