// Decompiled with JetBrains decompiler
// Type: DevToolStoryManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DevToolStoryManager : DevTool
{
  protected override void RenderTo(DevPanel panel)
  {
    if (ImGui.CollapsingHeader("Story Instance Data", ImGuiTreeNodeFlags.DefaultOpen))
      this.DrawStoryInstanceData();
    ImGui.Spacing();
    if (!ImGui.CollapsingHeader("Story Telemetry Data", ImGuiTreeNodeFlags.DefaultOpen))
      return;
    this.DrawTelemetryData();
  }

  private void DrawStoryInstanceData()
  {
    if ((Object) StoryManager.Instance == (Object) null)
    {
      ImGui.Text("Couldn't find StoryManager instance");
    }
    else
    {
      ImGui.Text($"Stories (count: {StoryManager.Instance.GetStoryInstances().Count})");
      ImGui.Text("Highest generated: " + (StoryManager.Instance.GetHighestCoordinate() == -2 ? "Before stories" : StoryManager.Instance.GetHighestCoordinate().ToString()));
      foreach (KeyValuePair<int, StoryInstance> storyInstance in StoryManager.Instance.GetStoryInstances())
        ImGui.Text($" - {storyInstance.Value.storyId}: {storyInstance.Value.CurrentState.ToString()}");
      if (StoryManager.Instance.GetStoryInstances().Count != 0)
        return;
      ImGui.Text(" - No stories");
    }
  }

  private void DrawTelemetryData()
  {
    ImGuiEx.DrawObjectTable<StoryManager.StoryTelemetry>("ID_telemetry", (IEnumerable<StoryManager.StoryTelemetry>) StoryManager.GetTelemetry());
  }
}
