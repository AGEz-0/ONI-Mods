// Decompiled with JetBrains decompiler
// Type: DigTool
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DigTool : DragTool
{
  public static DigTool Instance;

  public static void DestroyInstance() => DigTool.Instance = (DigTool) null;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    DigTool.Instance = this;
  }

  protected override void OnDragTool(int cell, int distFromOrigin)
  {
    InterfaceTool.ActiveConfig.DigAction.Uproot(cell);
    InterfaceTool.ActiveConfig.DigAction.Dig(cell, distFromOrigin);
  }

  public static GameObject PlaceDig(int cell, int animationDelay = 0)
  {
    if (Grid.Solid[cell] && !Grid.Foundation[cell] && (Object) Grid.Objects[cell, 7] == (Object) null)
    {
      for (int layer = 0; layer < 45; ++layer)
      {
        if ((Object) Grid.Objects[cell, layer] != (Object) null && (Object) Grid.Objects[cell, layer].GetComponent<Constructable>() != (Object) null)
          return (GameObject) null;
      }
      GameObject gameObject = Util.KInstantiate(Assets.GetPrefab(new Tag("DigPlacer")));
      gameObject.SetActive(true);
      Grid.Objects[cell, 7] = gameObject;
      Vector3 posCbc = Grid.CellToPosCBC(cell, DigTool.Instance.visualizerLayer);
      float num = -0.15f;
      posCbc.z += num;
      gameObject.transform.SetPosition(posCbc);
      gameObject.GetComponentInChildren<EasingAnimations>().PlayAnimation("ScaleUp", Mathf.Max(0.0f, (float) animationDelay * 0.02f));
      return gameObject;
    }
    return (Object) Grid.Objects[cell, 7] != (Object) null ? Grid.Objects[cell, 7] : (GameObject) null;
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
