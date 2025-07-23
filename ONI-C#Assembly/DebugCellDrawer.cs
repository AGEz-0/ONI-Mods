// Decompiled with JetBrains decompiler
// Type: DebugCellDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/DebugCellDrawer")]
public class DebugCellDrawer : KMonoBehaviour
{
  public List<int> cells;

  private void Update()
  {
    for (int index = 0; index < this.cells.Count; ++index)
    {
      if (this.cells[index] != PathFinder.InvalidCell)
        DebugExtension.DebugPoint(Grid.CellToPosCCF(this.cells[index], Grid.SceneLayer.Background));
    }
  }
}
