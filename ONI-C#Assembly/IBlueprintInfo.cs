// Decompiled with JetBrains decompiler
// Type: IBlueprintInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public interface IBlueprintInfo : IHasDlcRestrictions
{
  string id { get; set; }

  string name { get; set; }

  string desc { get; set; }

  PermitRarity rarity { get; set; }

  string animFile { get; set; }
}
