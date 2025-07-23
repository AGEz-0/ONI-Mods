// Decompiled with JetBrains decompiler
// Type: Database.TechTreeTitles
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
namespace Database;

public class TechTreeTitles(ResourceSet parent) : ResourceSet<TechTreeTitle>("TreeTitles", parent)
{
  public void Load(TextAsset tree_file)
  {
    foreach (ResourceTreeNode node in (ResourceLoader<ResourceTreeNode>) new ResourceTreeLoader<ResourceTreeNode>(tree_file))
    {
      if (string.Equals(node.Id.Substring(0, 1), "_"))
      {
        TechTreeTitle techTreeTitle = new TechTreeTitle(node.Id, (ResourceSet) this, (string) Strings.Get("STRINGS.RESEARCH.TREES.TITLE" + node.Id.ToUpper()), node);
      }
    }
  }
}
