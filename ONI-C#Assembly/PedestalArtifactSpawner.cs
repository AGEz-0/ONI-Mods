// Decompiled with JetBrains decompiler
// Type: PedestalArtifactSpawner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using UnityEngine;

#nullable disable
public class PedestalArtifactSpawner : KMonoBehaviour
{
  [MyCmpReq]
  private Storage storage;
  [MyCmpReq]
  private SingleEntityReceptacle receptacle;
  [Serialize]
  private bool artifactSpawned;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    foreach (GameObject gameObject in this.storage.items)
    {
      if (ArtifactSelector.Instance.GetArtifactType(gameObject.name) == ArtifactType.Terrestrial)
        gameObject.GetComponent<KPrefabID>().AddTag(GameTags.TerrestrialArtifact, true);
    }
    if (this.artifactSpawned)
      return;
    GameObject gameObject1 = Util.KInstantiate(Assets.GetPrefab((Tag) ArtifactSelector.Instance.GetUniqueArtifactID(ArtifactType.Terrestrial)), this.transform.position);
    gameObject1.SetActive(true);
    gameObject1.GetComponent<KPrefabID>().AddTag(GameTags.TerrestrialArtifact, true);
    this.storage.Store(gameObject1);
    this.receptacle.ForceDeposit(gameObject1);
    this.artifactSpawned = true;
  }
}
