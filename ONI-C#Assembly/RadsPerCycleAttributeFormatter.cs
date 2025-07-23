// Decompiled with JetBrains decompiler
// Type: RadsPerCycleAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class RadsPerCycleAttributeFormatter : StandardAttributeFormatter
{
  public RadsPerCycleAttributeFormatter()
    : base(GameUtil.UnitClass.Radiation, GameUtil.TimeSlice.PerCycle)
  {
  }

  public override string GetFormattedAttribute(AttributeInstance instance)
  {
    return this.GetFormattedValue(instance.GetTotalDisplayValue(), GameUtil.TimeSlice.PerCycle);
  }

  public override string GetFormattedValue(float value, GameUtil.TimeSlice timeSlice)
  {
    return base.GetFormattedValue(value / 600f, timeSlice);
  }
}
