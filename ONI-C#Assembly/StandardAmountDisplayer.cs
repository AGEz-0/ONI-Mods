// Decompiled with JetBrains decompiler
// Type: StandardAmountDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Text;

#nullable disable
public class StandardAmountDisplayer : IAmountDisplayer
{
  protected StandardAttributeFormatter formatter;
  public GameUtil.IdentityDescriptorTense tense;

  public IAttributeFormatter Formatter => (IAttributeFormatter) this.formatter;

  public GameUtil.TimeSlice DeltaTimeSlice
  {
    get => this.formatter.DeltaTimeSlice;
    set => this.formatter.DeltaTimeSlice = value;
  }

  public StandardAmountDisplayer(
    GameUtil.UnitClass unitClass,
    GameUtil.TimeSlice deltaTimeSlice,
    StandardAttributeFormatter formatter = null,
    GameUtil.IdentityDescriptorTense tense = GameUtil.IdentityDescriptorTense.Normal)
  {
    this.tense = tense;
    if (formatter != null)
      this.formatter = formatter;
    else
      this.formatter = new StandardAttributeFormatter(unitClass, deltaTimeSlice);
  }

  public virtual string GetValueString(Amount master, AmountInstance instance)
  {
    return !master.showMax ? this.formatter.GetFormattedValue(instance.value) : $"{this.formatter.GetFormattedValue(instance.value)} / {this.formatter.GetFormattedValue(instance.GetMax())}";
  }

  public virtual string GetDescription(Amount master, AmountInstance instance)
  {
    return $"{master.Name}: {this.GetValueString(master, instance)}";
  }

  public virtual string GetTooltip(Amount master, AmountInstance instance)
  {
    StringBuilder sb = GlobalStringBuilderPool.Alloc();
    if (master.description.IndexOf("{1}") > -1)
      sb.AppendFormat(master.description, (object) this.formatter.GetFormattedValue(instance.value), (object) GameUtil.GetIdentityDescriptor(instance.gameObject, this.tense));
    else
      sb.AppendFormat(master.description, (object) this.formatter.GetFormattedValue(instance.value));
    sb.Append("\n\n");
    if (this.formatter.DeltaTimeSlice == GameUtil.TimeSlice.PerCycle)
      sb.AppendFormat((string) UI.CHANGEPERCYCLE, (object) this.formatter.GetFormattedValue(instance.deltaAttribute.GetTotalDisplayValue(), GameUtil.TimeSlice.PerCycle));
    else if (this.formatter.DeltaTimeSlice == GameUtil.TimeSlice.PerSecond)
      sb.AppendFormat((string) UI.CHANGEPERSECOND, (object) this.formatter.GetFormattedValue(instance.deltaAttribute.GetTotalDisplayValue(), GameUtil.TimeSlice.PerSecond));
    for (int i = 0; i != instance.deltaAttribute.Modifiers.Count; ++i)
    {
      AttributeModifier modifier = instance.deltaAttribute.Modifiers[i];
      sb.Append("\n");
      sb.AppendFormat((string) UI.MODIFIER_ITEM_TEMPLATE, (object) modifier.GetDescription(), (object) this.formatter.GetFormattedModifier(modifier));
    }
    return GlobalStringBuilderPool.ReturnAndFree(sb);
  }

  public string GetFormattedAttribute(AttributeInstance instance)
  {
    return this.formatter.GetFormattedAttribute(instance);
  }

  public string GetFormattedModifier(AttributeModifier modifier)
  {
    return this.formatter.GetFormattedModifier(modifier);
  }

  public string GetFormattedValue(float value, GameUtil.TimeSlice time_slice)
  {
    return this.formatter.GetFormattedValue(value, time_slice);
  }
}
