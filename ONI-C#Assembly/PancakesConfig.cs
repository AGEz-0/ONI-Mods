// Decompiled with JetBrains decompiler
// Type: PancakesConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PancakesConfig : IEntityConfig
{
  public const string ID = "Pancakes";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Pancakes", (string) STRINGS.ITEMS.FOOD.PANCAKES.NAME, (string) STRINGS.ITEMS.FOOD.PANCAKES.DESC, 1f, false, Assets.GetAnim((HashedString) "stackedpancakes_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.8f, true), TUNING.FOOD.FOOD_TYPES.PANCAKES);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
