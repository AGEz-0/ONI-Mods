// Decompiled with JetBrains decompiler
// Type: MovePickupablePlacerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class MovePickupablePlacerConfig : CommonPlacerConfig, IEntityConfig
{
  public static string ID = "MovePickupablePlacer";

  public GameObject CreatePrefab()
  {
    GameObject prefab = this.CreatePrefab(MovePickupablePlacerConfig.ID, (string) MISC.PLACERS.MOVEPICKUPABLEPLACER.NAME, Assets.instance.movePickupToPlacerAssets.material);
    prefab.AddOrGet<CancellableMove>();
    Storage storage = prefab.AddOrGet<Storage>();
    storage.showInUI = false;
    storage.showUnreachableStatus = true;
    prefab.AddOrGet<Approachable>();
    prefab.AddOrGet<Prioritizable>();
    prefab.AddTag(GameTags.NotConversationTopic);
    return prefab;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }

  [Serializable]
  public class MovePickupablePlacerAssets
  {
    public Material material;
  }
}
