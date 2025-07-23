// Decompiled with JetBrains decompiler
// Type: FullereneCometConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class FullereneCometConfig : IEntityConfig, IHasDlcRestrictions
{
  public static readonly string ID = "FullereneComet";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject prefab = BaseCometConfig.BaseComet(FullereneCometConfig.ID, (string) UI.SPACEDESTINATIONS.COMETS.FULLERENECOMET.NAME, "meteor_fullerene_kanim", SimHashes.Fullerene, new Vector2(3f, 20f), new Vector2(323.15f, 423.15f), "Meteor_Medium_Impact", explosionEffect: SpawnFXHashes.MeteorImpactMetal, size: 0.6f);
    Comet component = prefab.GetComponent<Comet>();
    component.explosionOreCount = new Vector2I(2, 4);
    component.entityDamage = 15;
    component.totalTileDamage = 0.5f;
    component.affectedByDifficulty = false;
    return prefab;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}
