// Decompiled with JetBrains decompiler
// Type: AlgaeConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AlgaeConfig : IOreConfig
{
  public SimHashes ElementID => SimHashes.Algae;

  public GameObject CreatePrefab()
  {
    return EntityTemplates.CreateSolidOreEntity(this.ElementID, new List<Tag>()
    {
      GameTags.Life
    });
  }
}
