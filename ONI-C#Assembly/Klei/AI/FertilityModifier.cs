// Decompiled with JetBrains decompiler
// Type: Klei.AI.FertilityModifier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Klei.AI;

public class FertilityModifier : Resource
{
  public string Description;
  public Tag TargetTag;
  public Func<string, string> TooltipCB;
  public FertilityModifier.FertilityModFn ApplyFunction;

  public FertilityModifier(
    string id,
    Tag targetTag,
    string name,
    string description,
    Func<string, string> tooltipCB,
    FertilityModifier.FertilityModFn applyFunction)
    : base(id, name)
  {
    this.Description = description;
    this.TargetTag = targetTag;
    this.TooltipCB = tooltipCB;
    this.ApplyFunction = applyFunction;
  }

  public string GetTooltip()
  {
    return this.TooltipCB != null ? this.TooltipCB(this.Description) : this.Description;
  }

  public delegate void FertilityModFn(FertilityMonitor.Instance inst, Tag eggTag);
}
