// Decompiled with JetBrains decompiler
// Type: ElementSplitter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public struct ElementSplitter
{
  public PrimaryElement primaryElement;
  public Func<Pickupable, float, Pickupable> onTakeCB;
  public Func<Pickupable, bool> canAbsorbCB;
  public KPrefabID kPrefabID;

  public ElementSplitter(GameObject go)
  {
    this.primaryElement = go.GetComponent<PrimaryElement>();
    this.kPrefabID = go.GetComponent<KPrefabID>();
    this.onTakeCB = (Func<Pickupable, float, Pickupable>) null;
    this.canAbsorbCB = (Func<Pickupable, bool>) null;
  }
}
