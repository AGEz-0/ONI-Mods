// Decompiled with JetBrains decompiler
// Type: DeployingScoutLanderFXConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DeployingScoutLanderFXConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "DeployingScoutLanderFXConfig";

  public string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(nameof (DeployingScoutLanderFXConfig), nameof (DeployingScoutLanderFXConfig), false);
    ClusterFXEntity clusterFxEntity = entity.AddOrGet<ClusterFXEntity>();
    clusterFxEntity.kAnimName = "rover01_kanim";
    clusterFxEntity.animName = "landing";
    clusterFxEntity.animPlayMode = KAnim.PlayMode.Loop;
    return entity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
