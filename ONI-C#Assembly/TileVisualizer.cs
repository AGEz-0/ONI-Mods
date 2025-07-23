// Decompiled with JetBrains decompiler
// Type: TileVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class TileVisualizer
{
  private static void RefreshCellInternal(int cell, ObjectLayer tile_layer)
  {
    if (Game.IsQuitting() || !Grid.IsValidCell(cell))
      return;
    GameObject gameObject = Grid.Objects[cell, (int) tile_layer];
    if (!((Object) gameObject != (Object) null))
      return;
    World.Instance.blockTileRenderer.Rebuild(tile_layer, cell);
    KAnimGraphTileVisualizer componentInChildren = gameObject.GetComponentInChildren<KAnimGraphTileVisualizer>();
    if (!((Object) componentInChildren != (Object) null))
      return;
    componentInChildren.Refresh();
  }

  private static void RefreshCell(int cell, ObjectLayer tile_layer)
  {
    if (tile_layer == ObjectLayer.NumLayers)
      return;
    TileVisualizer.RefreshCellInternal(cell, tile_layer);
    TileVisualizer.RefreshCellInternal(Grid.CellAbove(cell), tile_layer);
    TileVisualizer.RefreshCellInternal(Grid.CellBelow(cell), tile_layer);
    TileVisualizer.RefreshCellInternal(Grid.CellLeft(cell), tile_layer);
    TileVisualizer.RefreshCellInternal(Grid.CellRight(cell), tile_layer);
  }

  public static void RefreshCell(int cell, ObjectLayer tile_layer, ObjectLayer replacement_layer)
  {
    TileVisualizer.RefreshCell(cell, tile_layer);
    TileVisualizer.RefreshCell(cell, replacement_layer);
  }
}
