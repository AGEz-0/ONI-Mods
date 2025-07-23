// Decompiled with JetBrains decompiler
// Type: Rendering.World.Tile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace Rendering.World;

public struct Tile(int idx, int tile_x, int tile_y, int mask_count)
{
  public int Idx = idx;
  public TileCells TileCells = new TileCells(tile_x, tile_y);
  public int MaskCount = mask_count;
}
