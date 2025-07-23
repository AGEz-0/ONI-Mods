﻿// Decompiled with JetBrains decompiler
// Type: DirtyWaterConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DirtyWaterConfig : IOreConfig
{
  public SimHashes ElementID => SimHashes.DirtyWater;

  public SimHashes SublimeElementID => SimHashes.ContaminatedOxygen;

  public GameObject CreatePrefab()
  {
    GameObject liquidOreEntity = EntityTemplates.CreateLiquidOreEntity(this.ElementID);
    Sublimates sublimates = liquidOreEntity.AddOrGet<Sublimates>();
    sublimates.spawnFXHash = SpawnFXHashes.ContaminatedOxygenBubbleWater;
    sublimates.info = new Sublimates.Info(4.00000063E-05f, 0.025f, 1.8f, 1f, this.SublimeElementID);
    return liquidOreEntity;
  }
}
