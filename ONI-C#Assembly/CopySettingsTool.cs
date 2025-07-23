// Decompiled with JetBrains decompiler
// Type: CopySettingsTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CopySettingsTool : DragTool
{
  public static CopySettingsTool Instance;
  public GameObject Placer;
  private GameObject sourceGameObject;

  public static void DestroyInstance() => CopySettingsTool.Instance = (CopySettingsTool) null;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    CopySettingsTool.Instance = this;
  }

  public void Activate() => PlayerController.Instance.ActivateTool((InterfaceTool) this);

  public void SetSourceObject(GameObject sourceGameObject)
  {
    this.sourceGameObject = sourceGameObject;
  }

  protected override void OnDragTool(int cell, int distFromOrigin)
  {
    if ((Object) this.sourceGameObject == (Object) null || !Grid.IsValidCell(cell))
      return;
    CopyBuildingSettings.ApplyCopy(cell, this.sourceGameObject);
  }

  protected override void OnActivateTool() => base.OnActivateTool();

  protected override void OnDeactivateTool(InterfaceTool new_tool)
  {
    base.OnDeactivateTool(new_tool);
    this.sourceGameObject = (GameObject) null;
  }
}
