// Decompiled with JetBrains decompiler
// Type: MopPlacerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class MopPlacerConfig : CommonPlacerConfig, IEntityConfig
{
  public static string ID = "MopPlacer";

  public GameObject CreatePrefab()
  {
    GameObject prefab = this.CreatePrefab(MopPlacerConfig.ID, (string) MISC.PLACERS.MOPPLACER.NAME, Assets.instance.mopPlacerAssets.material);
    prefab.AddTag(GameTags.NotConversationTopic);
    Moppable moppable = prefab.AddOrGet<Moppable>();
    moppable.synchronizeAnims = false;
    moppable.amountMoppedPerTick = 20f;
    prefab.AddOrGet<Cancellable>();
    return prefab;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }

  [Serializable]
  public class MopPlacerAssets
  {
    public Material material;
  }
}
