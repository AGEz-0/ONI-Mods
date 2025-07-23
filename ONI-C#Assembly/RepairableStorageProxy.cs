// Decompiled with JetBrains decompiler
// Type: RepairableStorageProxy
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class RepairableStorageProxy : IEntityConfig
{
  public static string ID = nameof (RepairableStorageProxy);

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(RepairableStorageProxy.ID, RepairableStorageProxy.ID);
    entity.AddOrGet<Storage>();
    entity.AddTag(GameTags.NotConversationTopic);
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}
