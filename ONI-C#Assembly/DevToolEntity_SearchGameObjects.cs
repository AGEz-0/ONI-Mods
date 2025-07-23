// Decompiled with JetBrains decompiler
// Type: DevToolEntity_SearchGameObjects
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using System;

#nullable disable
public class DevToolEntity_SearchGameObjects : DevTool
{
  private Action<DevToolEntityTarget> onSelectionMadeFn;

  public DevToolEntity_SearchGameObjects(Action<DevToolEntityTarget> onSelectionMadeFn)
  {
    this.onSelectionMadeFn = onSelectionMadeFn;
  }

  protected override void RenderTo(DevPanel panel) => ImGui.Text("Not implemented yet");
}
