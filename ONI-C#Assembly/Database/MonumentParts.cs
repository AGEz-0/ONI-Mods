// Decompiled with JetBrains decompiler
// Type: Database.MonumentParts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Database;

public class MonumentParts : ResourceSet<MonumentPartResource>
{
  public MonumentParts(ResourceSet parent)
    : base(nameof (MonumentParts), parent)
  {
    this.Initialize();
    foreach (MonumentPartInfo monumentPart in Blueprints.Get().all.monumentParts)
      this.Add(monumentPart.id, monumentPart.name, monumentPart.desc, monumentPart.rarity, monumentPart.animFile, monumentPart.state, monumentPart.symbolName, monumentPart.part, monumentPart.requiredDlcIds, monumentPart.forbiddenDlcIds);
  }

  public void Add(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string animFilename,
    string state,
    string symbolName,
    MonumentPartResource.Part part,
    string[] requiredDlcIds,
    string[] forbiddenDlcIds)
  {
    this.resources.Add(new MonumentPartResource(id, name, desc, rarity, animFilename, state, symbolName, part, requiredDlcIds, forbiddenDlcIds));
  }

  public List<MonumentPartResource> GetParts(MonumentPartResource.Part part)
  {
    return this.resources.FindAll((Predicate<MonumentPartResource>) (mpr => mpr.part == part));
  }
}
