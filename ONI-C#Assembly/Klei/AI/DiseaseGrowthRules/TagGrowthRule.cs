// Decompiled with JetBrains decompiler
// Type: Klei.AI.DiseaseGrowthRules.TagGrowthRule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.AI.DiseaseGrowthRules;

public class TagGrowthRule : GrowthRule
{
  public Tag tag;

  public TagGrowthRule(Tag tag) => this.tag = tag;

  public override bool Test(Element e) => e.HasTag(this.tag);

  public override string Name() => this.tag.ProperName();
}
