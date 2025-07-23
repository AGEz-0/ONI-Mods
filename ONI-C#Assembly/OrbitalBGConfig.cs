// Decompiled with JetBrains decompiler
// Type: OrbitalBGConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class OrbitalBGConfig : IEntityConfig
{
  public static string ID = "OrbitalBG";

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(OrbitalBGConfig.ID, OrbitalBGConfig.ID, false);
    entity.AddOrGet<LoopingSounds>();
    entity.AddOrGet<OrbitalObject>();
    entity.AddOrGet<SaveLoadRoot>();
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}
