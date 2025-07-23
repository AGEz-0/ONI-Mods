// Decompiled with JetBrains decompiler
// Type: DiseaseVisualization
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DiseaseVisualization : ScriptableObject
{
  public Sprite overlaySprite;
  public List<DiseaseVisualization.Info> info = new List<DiseaseVisualization.Info>();

  public DiseaseVisualization.Info GetInfo(HashedString id)
  {
    foreach (DiseaseVisualization.Info info in this.info)
    {
      if (id == (HashedString) info.name)
        return info;
    }
    return new DiseaseVisualization.Info();
  }

  [Serializable]
  public struct Info(string name)
  {
    public string name = name;
    public string overlayColourName = "germFoodPoisoning";
  }
}
