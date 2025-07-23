// Decompiled with JetBrains decompiler
// Type: DevToolPOITechUnlocks
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ImGuiNET;
using UnityEngine;

#nullable disable
public class DevToolPOITechUnlocks : DevTool
{
  protected override void RenderTo(DevPanel panel)
  {
    if ((Object) Research.Instance == (Object) null)
      return;
    foreach (TechItem resource in Db.Get().TechItems.resources)
    {
      if (resource.isPOIUnlock)
      {
        ImGui.Text(resource.Id);
        ImGui.SameLine();
        bool v = resource.IsComplete();
        if (ImGui.Checkbox("Unlocked ", ref v))
          resource.POIUnlocked();
      }
    }
  }
}
