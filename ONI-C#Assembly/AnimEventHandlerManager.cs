// Decompiled with JetBrains decompiler
// Type: AnimEventHandlerManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AnimEventHandlerManager : KMonoBehaviour
{
  private const float HIDE_DISTANCE = 40f;
  private List<AnimEventHandler> handlers;

  public static AnimEventHandlerManager Instance { get; private set; }

  public static void DestroyInstance()
  {
    AnimEventHandlerManager.Instance = (AnimEventHandlerManager) null;
  }

  protected override void OnPrefabInit()
  {
    AnimEventHandlerManager.Instance = this;
    this.handlers = new List<AnimEventHandler>();
  }

  public void Add(AnimEventHandler handler) => this.handlers.Add(handler);

  public void Remove(AnimEventHandler handler) => this.handlers.Remove(handler);

  private bool IsVisibleToZoom()
  {
    return !((Object) Game.MainCamera == (Object) null) && (double) Game.MainCamera.orthographicSize < 40.0;
  }

  public void LateUpdate()
  {
    if (!this.IsVisibleToZoom())
      return;
    Vector2I min;
    Vector2I max;
    Grid.GetVisibleCellRangeInActiveWorld(out min, out max);
    foreach (AnimEventHandler handler in this.handlers)
    {
      if (IsVisible(handler))
        handler.UpdateOffset();
    }

    bool IsVisible(AnimEventHandler handler)
    {
      int x;
      int y;
      Grid.CellToXY(handler.GetCachedCell(), out x, out y);
      return x >= min.x && y >= min.y && x < max.x && y < max.y;
    }
  }
}
