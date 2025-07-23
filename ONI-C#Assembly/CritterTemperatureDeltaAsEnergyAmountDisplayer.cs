// Decompiled with JetBrains decompiler
// Type: CritterTemperatureDeltaAsEnergyAmountDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Text;

#nullable disable
public class CritterTemperatureDeltaAsEnergyAmountDisplayer(
  GameUtil.UnitClass unitClass,
  GameUtil.TimeSlice timeSlice) : StandardAmountDisplayer(unitClass, timeSlice)
{
  public override string GetTooltip(Amount master, AmountInstance instance)
  {
    StringBuilder sb = GlobalStringBuilderPool.Alloc();
    CritterTemperatureMonitor.Def def = instance.gameObject.GetDef<CritterTemperatureMonitor.Def>();
    PrimaryElement component = instance.gameObject.GetComponent<PrimaryElement>();
    sb.AppendFormat(master.description, (object) this.formatter.GetFormattedValue(def.temperatureColdUncomfortable), (object) this.formatter.GetFormattedValue(def.temperatureHotUncomfortable), (object) this.formatter.GetFormattedValue(def.temperatureColdDeadly), (object) this.formatter.GetFormattedValue(def.temperatureHotDeadly));
    float num = (float) ((double) ElementLoader.FindElementByHash(SimHashes.Creature).specificHeatCapacity * (double) component.Mass * 1000.0);
    if (this.formatter.DeltaTimeSlice == GameUtil.TimeSlice.PerCycle)
    {
      sb.Append("\n\n");
      sb.AppendFormat((string) UI.CHANGEPERCYCLE, (object) this.formatter.GetFormattedValue(instance.deltaAttribute.GetTotalDisplayValue(), GameUtil.TimeSlice.PerCycle));
    }
    else if (instance.deltaAttribute.Modifiers.Count > 0)
    {
      sb.Append("\n\n");
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
