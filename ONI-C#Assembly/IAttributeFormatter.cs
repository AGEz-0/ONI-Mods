// Decompiled with JetBrains decompiler
// Type: IAttributeFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;

#nullable disable
public interface IAttributeFormatter
{
  GameUtil.TimeSlice DeltaTimeSlice { get; set; }

  string GetFormattedAttribute(AttributeInstance instance);

  string GetFormattedModifier(AttributeModifier modifier);

  string GetFormattedValue(float value, GameUtil.TimeSlice timeSlice);

  string GetTooltip(Attribute master, AttributeInstance instance);

  string GetTooltip(
    Attribute master,
    List<AttributeModifier> modifiers,
    AttributeConverters converters);
}
