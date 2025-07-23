// Decompiled with JetBrains decompiler
// Type: HarvestTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class HarvestTool : DragTool
{
  public GameObject Placer;
  public static HarvestTool Instance;
  public Texture2D[] visualizerTextures;
  private Dictionary<string, ToolParameterMenu.ToggleState> options = new Dictionary<string, ToolParameterMenu.ToggleState>();

  public static void DestroyInstance() => HarvestTool.Instance = (HarvestTool) null;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    HarvestTool.Instance = this;
    this.options.Add("HARVEST_WHEN_READY", ToolParameterMenu.ToggleState.On);
    this.options.Add("DO_NOT_HARVEST", ToolParameterMenu.ToggleState.Off);
    this.viewMode = OverlayModes.Harvest.ID;
  }

  protected override void OnDragTool(int cell, int distFromOrigin)
  {
    if (!Grid.IsValidCell(cell))
      return;
    foreach (HarvestDesignatable cmp in Components.HarvestDesignatables.Items)
    {
      OccupyArea area = cmp.area;
      if (Grid.PosToCell((KMonoBehaviour) cmp) == cell || (Object) area != (Object) null && area.CheckIsOccupying(cell))
      {
        if (this.options["HARVEST_WHEN_READY"] == ToolParameterMenu.ToggleState.On)
          cmp.SetHarvestWhenReady(true);
        else if (this.options["DO_NOT_HARVEST"] == ToolParameterMenu.ToggleState.On)
        {
          Harvestable component = cmp.GetComponent<Harvestable>();
          if ((Object) component != (Object) null)
            component.Trigger(2127324410, (object) null);
          cmp.SetHarvestWhenReady(false);
        }
        Prioritizable component1 = cmp.GetComponent<Prioritizable>();
        if ((Object) component1 != (Object) null)
          component1.SetMasterPriority(ToolMenu.Instance.PriorityScreen.GetLastSelectedPriority());
      }
    }
  }

  public void Update()
  {
    MeshRenderer componentInChildren = this.visualizer.GetComponentInChildren<MeshRenderer>();
    if (!((Object) componentInChildren != (Object) null))
      return;
    if (this.options["HARVEST_WHEN_READY"] == ToolParameterMenu.ToggleState.On)
    {
      componentInChildren.material.mainTexture = (Texture) this.visualizerTextures[0];
    }
    else
    {
      if (this.options["DO_NOT_HARVEST"] != ToolParameterMenu.ToggleState.On)
        return;
      componentInChildren.material.mainTexture = (Texture) this.visualizerTextures[1];
    }
  }

  public override void OnLeftClickUp(Vector3 cursor_pos) => base.OnLeftClickUp(cursor_pos);

  protected override void OnActivateTool()
  {
    base.OnActivateTool();
    ToolMenu.Instance.PriorityScreen.Show();
    ToolMenu.Instance.toolParameterMenu.PopulateMenu(this.options);
  }

  protected override void OnDeactivateTool(InterfaceTool new_tool)
  {
    base.OnDeactivateTool(new_tool);
    ToolMenu.Instance.PriorityScreen.Show(false);
    ToolMenu.Instance.toolParameterMenu.ClearMenu();
  }
}
