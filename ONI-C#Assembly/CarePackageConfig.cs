// Decompiled with JetBrains decompiler
// Type: CarePackageConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class CarePackageConfig : IEntityConfig
{
  public static readonly string ID = "CarePackage";

  public GameObject CreatePrefab()
  {
    return EntityTemplates.CreateLooseEntity(CarePackageConfig.ID, (string) ITEMS.CARGO_CAPSULE.NAME, (string) ITEMS.CARGO_CAPSULE.DESC, 1f, true, Assets.GetAnim((HashedString) "portal_carepackage_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE);
  }

  public void OnPrefabInit(GameObject go) => go.AddOrGet<CarePackage>();

  public void OnSpawn(GameObject go)
  {
  }
}
