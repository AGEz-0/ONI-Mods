// Decompiled with JetBrains decompiler
// Type: Klei.AI.AttributeModifier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Diagnostics;

#nullable disable
namespace Klei.AI;

[DebuggerDisplay("{AttributeId}")]
public class AttributeModifier
{
  public string Description;
  public Func<string> DescriptionCB;

  public string AttributeId { get; private set; }

  public float Value { get; private set; }

  public bool IsMultiplier { get; private set; }

  public GameUtil.TimeSlice? OverrideTimeSlice { get; set; }

  public bool UIOnly { get; private set; }

  public bool IsReadonly { get; private set; }

  public AttributeModifier(
    string attribute_id,
    float value,
    string description = null,
    bool is_multiplier = false,
    bool uiOnly = false,
    bool is_readonly = true)
  {
    this.AttributeId = attribute_id;
    this.Value = value;
    this.Description = description == null ? attribute_id : description;
    this.DescriptionCB = (Func<string>) null;
    this.IsMultiplier = is_multiplier;
    this.UIOnly = uiOnly;
    this.IsReadonly = is_readonly;
    this.OverrideTimeSlice = new GameUtil.TimeSlice?();
  }

  public AttributeModifier(
    string attribute_id,
    float value,
    Func<string> description_cb,
    bool is_multiplier = false,
    bool uiOnly = false)
  {
    this.AttributeId = attribute_id;
    this.Value = value;
    this.DescriptionCB = description_cb;
    this.Description = (string) null;
    this.IsMultiplier = is_multiplier;
    this.UIOnly = uiOnly;
    this.OverrideTimeSlice = new GameUtil.TimeSlice?();
    if (description_cb != null)
      return;
    Debug.LogWarning((object) ("AttributeModifier being constructed without a description callback: " + attribute_id));
  }

  public void SetValue(float value) => this.Value = value;

  public string GetName()
  {
    Attribute attribute = Db.Get().Attributes.TryGet(this.AttributeId);
    return attribute != null && attribute.ShowInUI != Attribute.Display.Never ? attribute.Name : "";
  }

  public string GetDescription()
  {
    return this.DescriptionCB == null ? this.Description : this.DescriptionCB();
  }

  public string GetFormattedString()
  {
    IAttributeFormatter attributeFormatter = (IAttributeFormatter) null;
    Attribute attribute1 = Db.Get().Attributes.TryGet(this.AttributeId);
    if (!this.IsMultiplier)
    {
      if (attribute1 != null)
      {
        attributeFormatter = attribute1.formatter;
      }
      else
      {
        Attribute attribute2 = Db.Get().BuildingAttributes.TryGet(this.AttributeId);
        if (attribute2 != null)
        {
          attributeFormatter = attribute2.formatter;
        }
        else
        {
          Attribute attribute3 = Db.Get().PlantAttributes.TryGet(this.AttributeId);
          if (attribute3 != null)
            attributeFormatter = attribute3.formatter;
        }
      }
    }
    string str = "";
    string text = attributeFormatter == null ? (!this.IsMultiplier ? str + GameUtil.GetFormattedSimple(this.Value) : str + GameUtil.GetFormattedPercent(this.Value * 100f)) : attributeFormatter.GetFormattedModifier(this);
    if (text != null && text.Length > 0 && text[0] != '-')
    {
      GameUtil.TimeSlice? overrideTimeSlice = this.OverrideTimeSlice;
      GameUtil.TimeSlice timeSlice = GameUtil.TimeSlice.None;
      if (!(overrideTimeSlice.GetValueOrDefault() == timeSlice & overrideTimeSlice.HasValue))
        text = GameUtil.AddPositiveSign(text, (double) this.Value > 0.0);
    }
    return text;
  }

  public AttributeModifier Clone()
  {
    return new AttributeModifier(this.AttributeId, this.Value, this.Description);
  }
}
