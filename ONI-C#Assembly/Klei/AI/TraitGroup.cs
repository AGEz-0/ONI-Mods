// Decompiled with JetBrains decompiler
// Type: Klei.AI.TraitGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Klei.AI;

public class TraitGroup : ModifierGroup<Trait>
{
  public bool IsSpawnTrait;

  public TraitGroup(string id, string name, bool is_spawn_trait)
    : base(id, name)
  {
    this.IsSpawnTrait = is_spawn_trait;
  }
}
