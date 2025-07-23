// Decompiled with JetBrains decompiler
// Type: EggConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using TUNING;
using UnityEngine;

#nullable disable
public class EggConfig
{
  [Obsolete("Mod compatibility: Use CreateEgg with requiredDlcIds and forbiddenDlcIds")]
  public static GameObject CreateEgg(
    string id,
    string name,
    string desc,
    Tag creature_id,
    string anim,
    float mass,
    int egg_sort_order,
    float base_incubation_rate)
  {
    return EggConfig.CreateEgg(id, name, desc, creature_id, anim, mass, egg_sort_order, base_incubation_rate, (string[]) null, (string[]) null);
  }

  [Obsolete("Mod compatibility: Use CreateEgg with requiredDlcIds and forbiddenDlcIds")]
  public static GameObject CreateEgg(
    string id,
    string name,
    string desc,
    Tag creature_id,
    string anim,
    float mass,
    int egg_sort_order,
    float base_incubation_rate,
    string[] dlcIds)
  {
    string[] requiredDlcIds;
    string[] forbiddenDlcIds;
    DlcManager.ConvertAvailableToRequireAndForbidden(dlcIds, out requiredDlcIds, out forbiddenDlcIds);
    return EggConfig.CreateEgg(id, name, desc, creature_id, anim, mass, egg_sort_order, base_incubation_rate, requiredDlcIds, forbiddenDlcIds);
  }

  public static GameObject CreateEgg(
    string id,
    string name,
    string desc,
    Tag creature_id,
    string anim,
    float mass,
    int egg_sort_order,
    float base_incubation_rate,
    string[] requiredDlcIds,
    string[] forbiddenDlcIds)
  {
    return EggConfig.CreateEgg(id, name, desc, creature_id, anim, mass, egg_sort_order, base_incubation_rate, requiredDlcIds, forbiddenDlcIds, false);
  }

  public static GameObject CreateEgg(
    string id,
    string name,
    string desc,
    Tag creature_id,
    string anim,
    float mass,
    int egg_sort_order,
    float base_incubation_rate,
    string[] requiredDlcIds,
    string[] forbiddenDlcIds,
    bool preventEggDrops)
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity(id, name, desc, mass, true, Assets.GetAnim((HashedString) anim), "idle", Grid.SceneLayer.Ore, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.8f, true);
    looseEntity.AddOrGet<KBoxCollider2D>().offset = (Vector2) new Vector2f(0.0f, 0.36f);
    looseEntity.AddOrGet<Pickupable>().sortOrder = SORTORDER.EGGS + egg_sort_order;
    looseEntity.AddOrGet<Effects>();
    KPrefabID kprefabId = looseEntity.AddOrGet<KPrefabID>();
    kprefabId.AddTag(GameTags.Egg);
    kprefabId.AddTag(GameTags.IncubatableEgg);
    kprefabId.AddTag(GameTags.PedestalDisplayable);
    kprefabId.requiredDlcIds = requiredDlcIds;
    kprefabId.forbiddenDlcIds = forbiddenDlcIds;
    IncubationMonitor.Def def = looseEntity.AddOrGetDef<IncubationMonitor.Def>();
    def.preventEggDrops = preventEggDrops;
    def.spawnedCreature = creature_id;
    def.baseIncubationRate = base_incubation_rate;
    looseEntity.AddOrGetDef<OvercrowdingMonitor.Def>().spaceRequiredPerCreature = 0;
    UnityEngine.Object.Destroy((UnityEngine.Object) looseEntity.GetComponent<EntitySplitter>());
    Assets.AddPrefab(looseEntity.GetComponent<KPrefabID>());
    if (preventEggDrops)
      return looseEntity;
    EggCrackerConfig.RegisterEgg((Tag) id, name, desc, mass, requiredDlcIds, forbiddenDlcIds);
    return looseEntity;
  }
}
