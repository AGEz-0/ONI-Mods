// Decompiled with JetBrains decompiler
// Type: WorkingToiletTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class WorkingToiletTracker(int worldID) : WorldTracker(worldID)
{
  public override void UpdateData()
  {
    int num = 0;
    foreach (IUsable usable in Components.Toilets.WorldItemsEnumerate(this.WorldID, true))
    {
      if (usable.IsUsable())
        ++num;
    }
    this.AddPoint((float) num);
  }

  public override string FormatValueString(float value) => value.ToString();
}
