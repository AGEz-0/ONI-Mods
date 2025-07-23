// Decompiled with JetBrains decompiler
// Type: HEPBridgeTileVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class HEPBridgeTileVisualizer : KMonoBehaviour, IHighEnergyParticleDirection
{
  private static readonly EventSystem.IntraObjectHandler<HEPBridgeTileVisualizer> OnRotateDelegate = new EventSystem.IntraObjectHandler<HEPBridgeTileVisualizer>((Action<HEPBridgeTileVisualizer, object>) ((component, data) => component.OnRotate()));

  protected override void OnSpawn()
  {
    this.Subscribe<HEPBridgeTileVisualizer>(-1643076535, HEPBridgeTileVisualizer.OnRotateDelegate);
    this.OnRotate();
  }

  public void OnRotate() => Game.Instance.ForceOverlayUpdate(true);

  public EightDirection Direction
  {
    get
    {
      EightDirection direction = EightDirection.Right;
      Rotatable component = this.GetComponent<Rotatable>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        switch (component.Orientation)
        {
          case Orientation.Neutral:
            direction = EightDirection.Left;
            break;
          case Orientation.R90:
            direction = EightDirection.Up;
            break;
          case Orientation.R180:
            direction = EightDirection.Right;
            break;
          case Orientation.R270:
            direction = EightDirection.Down;
            break;
        }
      }
      return direction;
    }
    set
    {
    }
  }
}
