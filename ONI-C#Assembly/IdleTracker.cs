// Decompiled with JetBrains decompiler
// Type: IdleTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class IdleTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    this.objectsOfInterest.Clear();
    int num = 0;
    List<MinionIdentity> worldItems = Components.LiveMinionIdentities.GetWorldItems(this.WorldID);
    for (int index = 0; index < worldItems.Count; ++index)
    {
      if (worldItems[index].HasTag(GameTags.Idle))
      {
        ++num;
        this.objectsOfInterest.Add(worldItems[index].gameObject);
      }
    }
    this.AddPoint((float) num);
  }

  public override string FormatValueString(float value) => value.ToString();
}
