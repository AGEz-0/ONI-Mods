// Decompiled with JetBrains decompiler
// Type: GridVisibility
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/GridVisibility")]
public class GridVisibility : KMonoBehaviour
{
  public int radius = 18;
  public float innerRadius = 16.5f;

  protected override void OnSpawn()
  {
    Singleton<CellChangeMonitor>.Instance.RegisterCellChangedHandler(this.transform, new System.Action(this.OnCellChange), "GridVisibility.OnSpawn");
    this.OnCellChange();
    WorldContainer myWorld = this.gameObject.GetMyWorld();
    if (!((UnityEngine.Object) myWorld != (UnityEngine.Object) null) || this.gameObject.HasTag(GameTags.Stored))
      return;
    myWorld.SetDiscovered();
  }

  private void OnCellChange()
  {
    if (this.gameObject.HasTag(GameTags.Dead))
      return;
    int cell = Grid.PosToCell((KMonoBehaviour) this);
    if (!Grid.IsValidCell(cell))
      return;
    if (!Grid.Revealed[cell])
    {
      int x;
      int y;
      Grid.PosToXY(this.transform.GetPosition(), out x, out y);
      GridVisibility.Reveal(x, y, this.radius, this.innerRadius);
      Grid.Revealed[cell] = true;
    }
    FogOfWarMask.ClearMask(cell);
  }

  public static void Reveal(int baseX, int baseY, int radius, float innerRadius)
  {
    int num1 = (int) Grid.WorldIdx[baseY * Grid.WidthInCells + baseX];
    for (int y = -radius; y <= radius; ++y)
    {
      for (int x = -radius; x <= radius; ++x)
      {
        int num2 = baseY + y;
        int num3 = baseX + x;
        if (num2 >= 0 && Grid.HeightInCells - 1 >= num2 && num3 >= 0 && Grid.WidthInCells - 1 >= num3)
        {
          int cell = num2 * Grid.WidthInCells + num3;
          if (Grid.Visible[cell] < byte.MaxValue && num1 == (int) Grid.WorldIdx[cell])
          {
            float num4 = Mathf.Lerp(1f, 0.0f, (float) (((double) new Vector2((float) x, (float) y).magnitude - (double) innerRadius) / ((double) radius - (double) innerRadius)));
            Grid.Reveal(cell, (byte) ((double) byte.MaxValue * (double) num4));
          }
        }
      }
    }
  }

  protected override void OnCleanUp()
  {
    Singleton<CellChangeMonitor>.Instance.UnregisterCellChangedHandler(this.transform, new System.Action(this.OnCellChange));
  }
}
