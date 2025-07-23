// Decompiled with JetBrains decompiler
// Type: SandboxStoryTraitToolHoverTextCard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SandboxStoryTraitToolHoverTextCard : HoverTextConfiguration
{
  public override void UpdateHoverElements(List<KSelectable> hoverObjects)
  {
    HoverTextScreen instance = HoverTextScreen.Instance;
    HoverTextDrawer drawer = instance.BeginDrawing();
    int cell = Grid.PosToCell(Camera.main.ScreenToWorldPoint(KInputManager.GetMousePos()));
    if (!Grid.IsValidCell(cell) || (int) Grid.WorldIdx[cell] != ClusterManager.Instance.activeWorldId)
    {
      drawer.EndDrawing();
    }
    else
    {
      drawer.BeginShadowBar();
      Story story;
      string error = this.GetComponent<SandboxStoryTraitTool>().GetError(PlayerController.GetCursorPos(KInputManager.GetMousePos()), out story, out TemplateContainer _);
      if (story == null)
        this.ToolName = (string) UI.TOOLS.SANDBOX.SPAWN_STORY_TRAIT.NAME;
      else
        this.ToolName = (string) Strings.Get(story.StoryTrait.name);
      this.DrawTitle(instance, drawer);
      this.DrawInstructions(instance, drawer);
      if (error != null)
      {
        drawer.NewLine();
        drawer.AddIndent(8);
        drawer.DrawText(error, this.HoverTextStyleSettings[1]);
      }
      drawer.EndShadowBar();
      drawer.EndDrawing();
    }
  }
}
