// Decompiled with JetBrains decompiler
// Type: SandboxDestroyerTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class SandboxDestroyerTool : BrushTool
{
  public static SandboxDestroyerTool instance;
  protected HashSet<int> recentlyAffectedCells = new HashSet<int>();
  protected Color recentlyAffectedCellColor = new Color(1f, 1f, 1f, 0.1f);

  public static void DestroyInstance()
  {
    SandboxDestroyerTool.instance = (SandboxDestroyerTool) null;
  }

  private SandboxSettings settings => SandboxToolParameterMenu.instance.settings;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    SandboxDestroyerTool.instance = this;
    this.affectFoundation = true;
  }

  protected override string GetDragSound() => "SandboxTool_Delete_Add";

  public void Activate() => PlayerController.Instance.ActivateTool((InterfaceTool) this);

  protected override void OnActivateTool()
  {
    base.OnActivateTool();
    SandboxToolParameterMenu.instance.gameObject.SetActive(true);
    SandboxToolParameterMenu.instance.DisableParameters();
    SandboxToolParameterMenu.instance.brushRadiusSlider.row.SetActive(true);
  }

  protected override void OnDeactivateTool(InterfaceTool new_tool)
  {
    base.OnDeactivateTool(new_tool);
    SandboxToolParameterMenu.instance.gameObject.SetActive(false);
  }

  public override void GetOverlayColorData(out HashSet<ToolMenu.CellColorData> colors)
  {
    colors = new HashSet<ToolMenu.CellColorData>();
    foreach (int recentlyAffectedCell in this.recentlyAffectedCells)
      colors.Add(new ToolMenu.CellColorData(recentlyAffectedCell, this.recentlyAffectedCellColor));
    foreach (int cellsInRadiu in this.cellsInRadius)
      colors.Add(new ToolMenu.CellColorData(cellsInRadiu, this.radiusIndicatorColor));
  }

  public override void OnLeftClickDown(Vector3 cursor_pos)
  {
    base.OnLeftClickDown(cursor_pos);
    KFMOD.PlayUISound(GlobalAssets.GetSound("SandboxTool_Delete"));
  }

  public override void OnMouseMove(Vector3 cursorPos) => base.OnMouseMove(cursorPos);

  protected override void OnPaintCell(int cell, int distFromOrigin)
  {
    base.OnPaintCell(cell, distFromOrigin);
    this.recentlyAffectedCells.Add(cell);
    int index = Game.Instance.callbackManager.Add(new Game.CallbackInfo((System.Action) (() => this.recentlyAffectedCells.Remove(cell)))).index;
    SimMessages.ReplaceElement(cell, SimHashes.Vacuum, CellEventLogger.Instance.SandBoxTool, 0.0f, 0.0f, callbackIdx: index);
    HashSetPool<GameObject, SandboxDestroyerTool>.PooledHashSet pooledHashSet = HashSetPool<GameObject, SandboxDestroyerTool>.Allocate();
    foreach (Pickupable cmp in Components.Pickupables.Items)
    {
      if (Grid.PosToCell((KMonoBehaviour) cmp) == cell)
        pooledHashSet.Add(cmp.gameObject);
    }
    foreach (BuildingComplete cmp in Components.BuildingCompletes.Items)
    {
      if (Grid.PosToCell((KMonoBehaviour) cmp) == cell)
        pooledHashSet.Add(cmp.gameObject);
    }
    if ((UnityEngine.Object) Grid.Objects[cell, 1] != (UnityEngine.Object) null)
      pooledHashSet.Add(Grid.Objects[cell, 1]);
    foreach (Crop cmp in Components.Crops.Items)
    {
      if (Grid.PosToCell((KMonoBehaviour) cmp) == cell)
        pooledHashSet.Add(cmp.gameObject);
    }
    foreach (Health cmp in Components.Health.Items)
    {
      if (Grid.PosToCell((KMonoBehaviour) cmp) == cell)
        pooledHashSet.Add(cmp.gameObject);
    }
    foreach (Comet cmp in Components.Meteors.GetItems((int) Grid.WorldIdx[cell]))
    {
      if (!cmp.IsNullOrDestroyed() && Grid.PosToCell((KMonoBehaviour) cmp) == cell)
        pooledHashSet.Add(cmp.gameObject);
    }
    foreach (GameObject original in (HashSet<GameObject>) pooledHashSet)
      Util.KDestroyGameObject(original);
    pooledHashSet.Recycle();
  }
}
