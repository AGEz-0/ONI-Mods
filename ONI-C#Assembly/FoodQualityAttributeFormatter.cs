// Decompiled with JetBrains decompiler
// Type: FoodQualityAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;

#nullable disable
public class FoodQualityAttributeFormatter : StandardAttributeFormatter
{
  public FoodQualityAttributeFormatter()
    : base(GameUtil.UnitClass.SimpleInteger, GameUtil.TimeSlice.None)
  {
  }

  public override string GetFormattedAttribute(AttributeInstance instance)
  {
    return this.GetFormattedValue(instance.GetTotalDisplayValue());
  }

  public override string GetFormattedModifier(AttributeModifier modifier)
  {
    return GameUtil.GetFormattedInt(modifier.Value);
  }

  public override string GetFormattedValue(float value, GameUtil.TimeSlice timeSlice)
  {
    return Util.StripTextFormatting(GameUtil.GetFormattedFoodQuality((int) value));
  }
}
