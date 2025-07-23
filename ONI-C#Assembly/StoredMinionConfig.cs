// Decompiled with JetBrains decompiler
// Type: StoredMinionConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using UnityEngine;

#nullable disable
public class StoredMinionConfig : IEntityConfig
{
  public static string ID = "StoredMinion";

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(StoredMinionConfig.ID, StoredMinionConfig.ID);
    entity.AddOrGet<SaveLoadRoot>();
    entity.AddOrGet<KPrefabID>();
    entity.AddOrGet<Traits>();
    entity.AddOrGet<Schedulable>();
    entity.AddOrGet<StoredMinionIdentity>();
    entity.AddOrGet<KSelectable>().IsSelectable = false;
    entity.AddOrGet<MinionModifiers>().addBaseTraits = false;
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
    GameObject prefab = Assets.GetPrefab((Tag) BionicMinionConfig.ID);
    if (!((Object) prefab != (Object) null))
      return;
    StoredMinionIdentity.IStoredMinionExtension[] components = prefab.GetComponents<StoredMinionIdentity.IStoredMinionExtension>();
    if (components == null)
      return;
    for (int index = 0; index < components.Length; ++index)
      components[index].AddStoredMinionGameObjectRequirements(go);
  }

  public void OnSpawn(GameObject go)
  {
  }
}
