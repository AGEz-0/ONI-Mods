﻿// Decompiled with JetBrains decompiler
// Type: NavTypeHelper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class NavTypeHelper
{
  public static Vector3 GetNavPos(int cell, NavType nav_type)
  {
    Vector3 zero = Vector3.zero;
    Vector3 navPos;
    switch (nav_type)
    {
      case NavType.Floor:
        navPos = Grid.CellToPosCBC(cell, Grid.SceneLayer.Move);
        break;
      case NavType.LeftWall:
        navPos = Grid.CellToPosLCC(cell, Grid.SceneLayer.Move);
        break;
      case NavType.RightWall:
        navPos = Grid.CellToPosRCC(cell, Grid.SceneLayer.Move);
        break;
      case NavType.Ceiling:
        navPos = Grid.CellToPosCTC(cell, Grid.SceneLayer.Move);
        break;
      case NavType.Ladder:
        navPos = Grid.CellToPosCCC(cell, Grid.SceneLayer.Move);
        break;
      case NavType.Pole:
        navPos = Grid.CellToPosCCC(cell, Grid.SceneLayer.Move);
        break;
      case NavType.Tube:
        navPos = Grid.CellToPosCCC(cell, Grid.SceneLayer.Move);
        break;
      case NavType.Solid:
        navPos = Grid.CellToPosCCC(cell, Grid.SceneLayer.Move);
        break;
      default:
        navPos = Grid.CellToPosCCC(cell, Grid.SceneLayer.Move);
        break;
    }
    return navPos;
  }

  public static int GetAnchorCell(NavType nav_type, int cell)
  {
    int anchorCell = Grid.InvalidCell;
    if (Grid.IsValidCell(cell))
    {
      switch (nav_type)
      {
        case NavType.Floor:
          anchorCell = Grid.CellBelow(cell);
          break;
        case NavType.LeftWall:
          anchorCell = Grid.CellLeft(cell);
          break;
        case NavType.RightWall:
          anchorCell = Grid.CellRight(cell);
          break;
        case NavType.Ceiling:
          anchorCell = Grid.CellAbove(cell);
          break;
        case NavType.Solid:
          anchorCell = cell;
          break;
      }
    }
    return anchorCell;
  }
}
