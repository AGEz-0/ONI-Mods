// Decompiled with JetBrains decompiler
// Type: DevToolSaveGameInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using UnityEngine;

#nullable disable
public class DevToolSaveGameInfo : DevTool
{
  private string clSearch = "";

  protected override void RenderTo(DevPanel panel)
  {
    if ((Object) Game.Instance == (Object) null)
    {
      ImGui.Text("No game loaded");
    }
    else
    {
      ImGui.Text("Seed: " + CustomGameSettings.Instance.GetSettingsCoordinate());
      ImGui.Text("Generated: " + Game.Instance.dateGenerated);
      ImGui.Text("DebugWasUsed: " + Game.Instance.debugWasUsed.ToString());
      ImGui.Text("Content Enabled: ");
      foreach (string dlcId in SaveLoader.Instance.GameInfo.dlcIds)
        ImGui.Text(" - " + (dlcId == "" ? "VANILLA_ID" : dlcId));
      ImGui.PushItemWidth(100f);
      ImGui.NewLine();
      ImGui.Text("Changelists played on");
      ImGui.InputText("Search", ref this.clSearch, 10U);
      ImGui.PopItemWidth();
      foreach (uint num in Game.Instance.changelistsPlayedOn)
      {
        if (this.clSearch.IsNullOrWhiteSpace() || num.ToString().Contains(this.clSearch))
          ImGui.Text(num.ToString());
      }
      ImGui.NewLine();
    }
  }
}
