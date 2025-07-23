// Decompiled with JetBrains decompiler
// Type: MissileLongRangeConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MissileLongRangeConfig : IEntityConfig
{
  public const string ID = "MissileLongRange";
  public const float MASS_PER_MISSILE = 200f;
  public const int DAMAGE_PER_MISSILE = 10;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity("MissileLongRange", (string) ITEMS.MISSILE_LONGRANGE.NAME, (string) ITEMS.MISSILE_LONGRANGE.DESC, 200f, true, Assets.GetAnim((HashedString) "longrange_missile_kanim"), "object", Grid.SceneLayer.Ore, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, isPickupable: true, element: SimHashes.Iron, additionalTags: new List<Tag>());
    looseEntity.AddTag(GameTags.IndustrialProduct);
    looseEntity.AddOrGetDef<MissileLongRangeProjectile.Def>();
    looseEntity.AddOrGet<EntitySplitter>().maxStackSize = 200f;
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }

  public class DamageEventPayload
  {
    public int damage;
    public static MissileLongRangeConfig.DamageEventPayload sharedInstance = new MissileLongRangeConfig.DamageEventPayload();

    public DamageEventPayload(int damage = 10) => this.damage = damage;
  }
}
