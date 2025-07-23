// Decompiled with JetBrains decompiler
// Type: CurryConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CurryConfig : IEntityConfig
{
  public const string ID = "Curry";

  public GameObject CreatePrefab()
  {
    return EntityTemplates.ExtendEntityToFood(EntityTemplates.CreateLooseEntity("Curry", (string) STRINGS.ITEMS.FOOD.CURRY.NAME, (string) STRINGS.ITEMS.FOOD.CURRY.DESC, 1f, false, Assets.GetAnim((HashedString) "curried_beans_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.9f, 0.5f, true), TUNING.FOOD.FOOD_TYPES.CURRY);
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
