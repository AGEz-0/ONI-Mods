// Decompiled with JetBrains decompiler
// Type: BleachStoneConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class BleachStoneConfig : IOreConfig
{
  public SimHashes ElementID => SimHashes.BleachStone;

  public SimHashes SublimeElementID => SimHashes.ChlorineGas;

  public GameObject CreatePrefab()
  {
    GameObject solidOreEntity = EntityTemplates.CreateSolidOreEntity(this.ElementID);
    Sublimates sublimates = solidOreEntity.AddOrGet<Sublimates>();
    sublimates.spawnFXHash = SpawnFXHashes.BleachStoneEmissionBubbles;
    sublimates.info = new Sublimates.Info(0.000200000009f, 0.00250000018f, 1.8f, 0.5f, this.SublimeElementID);
    return solidOreEntity;
  }
}
