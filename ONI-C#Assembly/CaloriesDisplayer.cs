// Decompiled with JetBrains decompiler
// Type: CaloriesDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class CaloriesDisplayer : StandardAmountDisplayer
{
  public CaloriesDisplayer()
    : base(GameUtil.UnitClass.Calories, GameUtil.TimeSlice.PerCycle)
  {
    this.formatter = (StandardAttributeFormatter) new CaloriesDisplayer.CaloriesAttributeFormatter();
  }

  public class CaloriesAttributeFormatter : StandardAttributeFormatter
  {
    public CaloriesAttributeFormatter()
      : base(GameUtil.UnitClass.Calories, GameUtil.TimeSlice.PerCycle)
    {
    }

    public override string GetFormattedModifier(AttributeModifier modifier)
    {
      return modifier.IsMultiplier ? GameUtil.GetFormattedPercent((float) (-(double) modifier.Value * 100.0)) : base.GetFormattedModifier(modifier);
    }
  }
}
