// Decompiled with JetBrains decompiler
// Type: Database.FertilityModifiers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;

#nullable disable
namespace Database;

public class FertilityModifiers : ResourceSet<FertilityModifier>
{
  public List<FertilityModifier> GetForTag(Tag searchTag)
  {
    List<FertilityModifier> forTag = new List<FertilityModifier>();
    foreach (FertilityModifier resource in this.resources)
    {
      if (resource.TargetTag == searchTag)
        forTag.Add(resource);
    }
    return forTag;
  }
}
