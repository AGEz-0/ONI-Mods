// Decompiled with JetBrains decompiler
// Type: ClearTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ClearTool : DragTool
{
  public static ClearTool Instance;

  public static void DestroyInstance() => ClearTool.Instance = (ClearTool) null;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    ClearTool.Instance = this;
    this.interceptNumberKeysForPriority = true;
  }

  public void Activate() => PlayerController.Instance.ActivateTool((InterfaceTool) this);

  protected override void OnDragTool(int cell, int distFromOrigin)
  {
    GameObject gameObject1 = Grid.Objects[cell, 3];
    if ((Object) gameObject1 == (Object) null)
      return;
    ObjectLayerListItem objectLayerListItem = gameObject1.GetComponent<Pickupable>().objectLayerListItem;
    while (objectLayerListItem != null)
    {
      GameObject gameObject2 = objectLayerListItem.gameObject;
      objectLayerListItem = objectLayerListItem.nextItem;
      if (!((Object) gameObject2 == (Object) null) && !((Object) gameObject2.GetComponent<MinionIdentity>() != (Object) null) && gameObject2.GetComponent<Clearable>().isClearable)
      {
        gameObject2.GetComponent<Clearable>().MarkForClear();
        Prioritizable component = gameObject2.GetComponent<Prioritizable>();
        if ((Object) component != (Object) null)
          component.SetMasterPriority(ToolMenu.Instance.PriorityScreen.GetLastSelectedPriority());
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
}
