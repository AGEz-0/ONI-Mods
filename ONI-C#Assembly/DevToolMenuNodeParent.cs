// Decompiled with JetBrains decompiler
// Type: DevToolMenuNodeParent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using System.Collections.Generic;

#nullable disable
public class DevToolMenuNodeParent : IMenuNode
{
  public string name;
  public List<IMenuNode> children;

  public DevToolMenuNodeParent(string name)
  {
    this.name = name;
    this.children = new List<IMenuNode>();
  }

  public void AddChild(IMenuNode menuNode) => this.children.Add(menuNode);

  public string GetName() => this.name;

  public void Draw()
  {
    if (!ImGui.BeginMenu(this.name))
      return;
    foreach (IMenuNode child in this.children)
      child.Draw();
    ImGui.EndMenu();
  }
}
