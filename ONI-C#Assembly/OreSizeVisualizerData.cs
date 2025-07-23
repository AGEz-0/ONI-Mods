// Decompiled with JetBrains decompiler
// Type: OreSizeVisualizerData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public struct OreSizeVisualizerData
{
  public PrimaryElement primaryElement;
  public Action<object> onMassChangedCB;
  public OreSizeVisualizerComponents.TiersSetType tierSetType;

  public OreSizeVisualizerData(GameObject go)
  {
    this.primaryElement = go.GetComponent<PrimaryElement>();
    this.onMassChangedCB = (Action<object>) null;
    this.tierSetType = OreSizeVisualizerComponents.TiersSetType.Ores;
  }
}
