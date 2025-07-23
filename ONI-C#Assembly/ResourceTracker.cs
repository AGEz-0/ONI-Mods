// Decompiled with JetBrains decompiler
// Type: ResourceTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ResourceTracker : WorldTracker
{
  public Tag tag { get; private set; }

  public ResourceTracker(int worldID, Tag materialCategoryTag)
    : base(worldID)
  {
    this.tag = materialCategoryTag;
  }

  public override void UpdateData()
  {
    if ((Object) ClusterManager.Instance.GetWorld(this.WorldID).worldInventory == (Object) null)
      return;
    this.AddPoint(ClusterManager.Instance.GetWorld(this.WorldID).worldInventory.GetAmount(this.tag, false));
  }

  public override string FormatValueString(float value) => GameUtil.GetFormattedMass(value);
}
