// Decompiled with JetBrains decompiler
// Type: InfraredVisualizerComponents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class InfraredVisualizerComponents : KGameObjectComponentManager<InfraredVisualizerData>
{
  public HandleVector<int>.Handle Add(GameObject go)
  {
    return this.Add(go, new InfraredVisualizerData(go));
  }

  public void UpdateTemperature()
  {
    GridArea visibleArea = GridVisibleArea.GetVisibleArea();
    for (int index = 0; index < this.data.Count; ++index)
    {
      KAnimControllerBase controller = this.data[index].controller;
      if ((Object) controller != (Object) null)
      {
        Vector3 position = controller.transform.GetPosition();
        if (visibleArea.Min <= (Vector2) position && (Vector2) position <= visibleArea.Max)
          this.data[index].Update();
      }
    }
  }

  public void ClearOverlayColour()
  {
    Color32 black = (Color32) Color.black;
    for (int index = 0; index < this.data.Count; ++index)
    {
      KAnimControllerBase controller = this.data[index].controller;
      if ((Object) controller != (Object) null)
        controller.OverlayColour = (Color) black;
    }
  }

  public static void ClearOverlayColour(KBatchedAnimController controller)
  {
    if (!((Object) controller != (Object) null))
      return;
    controller.OverlayColour = Color.black;
  }
}
