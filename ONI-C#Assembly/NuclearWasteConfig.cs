// Decompiled with JetBrains decompiler
// Type: NuclearWasteConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class NuclearWasteConfig : IOreConfig
{
  public SimHashes ElementID => SimHashes.NuclearWaste;

  public GameObject CreatePrefab()
  {
    GameObject liquidOreEntity = EntityTemplates.CreateLiquidOreEntity(this.ElementID);
    Sublimates sublimates = liquidOreEntity.AddOrGet<Sublimates>();
    sublimates.decayStorage = true;
    sublimates.spawnFXHash = SpawnFXHashes.NuclearWasteDrip;
    sublimates.info = new Sublimates.Info(0.066f, 6.6f, 1000f, 0.0f, this.ElementID);
    return liquidOreEntity;
  }
}
