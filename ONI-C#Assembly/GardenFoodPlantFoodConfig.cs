// Decompiled with JetBrains decompiler
// Type: GardenFoodPlantFoodConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class GardenFoodPlantFoodConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "GardenFoodPlantFood";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("GardenFoodPlantFood", (string) STRINGS.ITEMS.FOOD.GARDENFOODPLANTFOOD.NAME, (string) STRINGS.ITEMS.FOOD.GARDENFOODPLANTFOOD.DESC, 1f, false, Assets.GetAnim((HashedString) "spikefruit_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.CIRCLE, 0.25f, 0.25f, true);
    EntityTemplates.ExtendEntityToFood(looseEntity, TUNING.FOOD.FOOD_TYPES.GARDENFOODPLANT);
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
