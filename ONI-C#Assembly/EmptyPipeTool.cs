// Decompiled with JetBrains decompiler
// Type: EmptyPipeTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class EmptyPipeTool : FilteredDragTool
{
  public static EmptyPipeTool Instance;

  public static void DestroyInstance() => EmptyPipeTool.Instance = (EmptyPipeTool) null;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    EmptyPipeTool.Instance = this;
  }

  protected override void OnDragTool(int cell, int distFromOrigin)
  {
    for (int layer = 0; layer < 45; ++layer)
    {
      if (this.IsActiveLayer((ObjectLayer) layer))
      {
        GameObject gameObject = Grid.Objects[cell, layer];
        if (!((Object) gameObject == (Object) null))
        {
          IEmptyConduitWorkable component1 = gameObject.GetComponent<IEmptyConduitWorkable>();
          if (!component1.IsNullOrDestroyed())
          {
            if (DebugHandler.InstantBuildMode)
            {
              component1.EmptyContents();
            }
            else
            {
              component1.MarkForEmptying();
              Prioritizable component2 = gameObject.GetComponent<Prioritizable>();
              if ((Object) component2 != (Object) null)
                component2.SetMasterPriority(ToolMenu.Instance.PriorityScreen.GetLastSelectedPriority());
            }
          }
        }
      }
    }
  }

  protected override void OnActivateTool()
  {
    base.OnActivateTool();
    ToolMenu.Instance.PriorityScreen.Show();
  }

  protected override void OnDeactivateTool(InterfaceTool new_tool)
  {
    base.OnDeactivateTool(new_tool);
    ToolMenu.Instance.PriorityScreen.Show(false);
  }

  protected override void GetDefaultFilters(
    Dictionary<string, ToolParameterMenu.ToggleState> filters)
  {
    filters.Add(ToolParameterMenu.FILTERLAYERS.ALL, ToolParameterMenu.ToggleState.On);
    filters.Add(ToolParameterMenu.FILTERLAYERS.LIQUIDCONDUIT, ToolParameterMenu.ToggleState.Off);
    filters.Add(ToolParameterMenu.FILTERLAYERS.GASCONDUIT, ToolParameterMenu.ToggleState.Off);
    filters.Add(ToolParameterMenu.FILTERLAYERS.SOLIDCONDUIT, ToolParameterMenu.ToggleState.Off);
  }
}
