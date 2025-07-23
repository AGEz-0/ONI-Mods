// Decompiled with JetBrains decompiler
// Type: FishFeederBotConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class FishFeederBotConfig : IEntityConfig
{
  public const string ID = "FishFeederBot";

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity("FishFeederBot", "FishFeederBot");
    KBatchedAnimController kbatchedAnimController = entity.AddOrGet<KBatchedAnimController>();
    kbatchedAnimController.AnimFiles = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "fishfeeder_kanim")
    };
    kbatchedAnimController.sceneLayer = Grid.SceneLayer.BuildingBack;
    SymbolOverrideControllerUtil.AddToPrefab(kbatchedAnimController.gameObject);
    return entity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
