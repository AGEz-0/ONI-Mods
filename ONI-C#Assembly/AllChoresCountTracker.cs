// Decompiled with JetBrains decompiler
// Type: AllChoresCountTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class AllChoresCountTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    float num = 0.0f;
    for (int idx = 0; idx < Db.Get().ChoreGroups.Count; ++idx)
    {
      Tracker choreGroupTracker = (Tracker) TrackerTool.Instance.GetChoreGroupTracker(this.WorldID, Db.Get().ChoreGroups[idx]);
      num += choreGroupTracker == null ? 0.0f : choreGroupTracker.GetCurrentValue();
    }
    this.AddPoint(num);
  }

  public override string FormatValueString(float value) => value.ToString();
}
