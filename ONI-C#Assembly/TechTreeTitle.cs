// Decompiled with JetBrains decompiler
// Type: TechTreeTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TechTreeTitle : Resource
{
  public string desc;
  private ResourceTreeNode node;

  public Vector2 center => this.node.center;

  public float width => this.node.width;

  public float height => this.node.height;

  public TechTreeTitle(string id, ResourceSet parent, string name, ResourceTreeNode node)
    : base(id, parent, name)
  {
    this.node = node;
  }
}
