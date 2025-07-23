// Decompiled with JetBrains decompiler
// Type: DuplicantTemperatureDeltaAsEnergyAmountDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Text;
using TUNING;

#nullable disable
public class DuplicantTemperatureDeltaAsEnergyAmountDisplayer(
  GameUtil.UnitClass unitClass,
  GameUtil.TimeSlice timeSlice) : StandardAmountDisplayer(unitClass, timeSlice)
{
  public override string GetTooltip(Amount master, AmountInstance instance)
  {
    StringBuilder sb = GlobalStringBuilderPool.Alloc();
    sb.AppendFormat(master.description, (object) this.formatter.GetFormattedValue(instance.value), (object) this.formatter.GetFormattedValue(DUPLICANTSTATS.STANDARD.Temperature.Internal.IDEAL));
    float num = (float) ((double) ElementLoader.FindElementByHash(SimHashes.Creature).specificHeatCapacity * (double) DUPLICANTSTATS.STANDARD.BaseStats.DEFAULT_MASS * 1000.0);
    sb.Append("\n\n");
    if (this.formatter.DeltaTimeSlice == GameUtil.TimeSlice.PerCycle)
    {
      sb.AppendFormat((string) UI.CHANGEPERCYCLE, (object) this.formatter.GetFormattedValue(instance.deltaAttribute.GetTotalDisplayValue(), GameUtil.TimeSlice.PerCycle));
    }
    else
    {
      sb.AppendFormat((string) UI.CHANGEPERSECOND, (object) this.formatter.GetFormattedValue(instance.deltaAttribute.GetTotalDisplayValue(), GameUtil.TimeSlice.PerSecond));
      sb.Append("\n");
      sb.AppendFormat((string) UI.CHANGEPERSECOND, (object) GameUtil.GetFormattedJoules(instance.deltaAttribute.GetTotalDisplayValue() * num));
    }
    for (int i = 0; i != instance.deltaAttribute.Modifiers.Count; ++i)
    {
      AttributeModifier modifier = instance.deltaAttribute.Modifiers[i];
      sb.Append("\n");
      sb.AppendFormat((string) UI.MODIFIER_ITEM_TEMPLATE, (object) modifier.GetDescription(), (object) GameUtil.GetFormattedHeatEnergyRate((float) ((double) modifier.Value * (double) num * 1.0)));
    }
    return GlobalStringBuilderPool.ReturnAndFree(sb);
  }
}
