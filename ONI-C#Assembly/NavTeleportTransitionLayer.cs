// Decompiled with JetBrains decompiler
// Type: NavTeleportTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class NavTeleportTransitionLayer(Navigator navigator) : TransitionDriver.OverrideLayer(navigator)
{
  public override void BeginTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.BeginTransition(navigator, transition);
    if (transition.start != NavType.Teleport)
      return;
    int cell = Grid.PosToCell((KMonoBehaviour) navigator);
    int x1;
    int y1;
    Grid.CellToXY(cell, out x1, out y1);
    int teleportTransition = navigator.NavGrid.teleportTransitions[cell];
    int x2;
    int y2;
    Grid.CellToXY(navigator.NavGrid.teleportTransitions[cell], out x2, out y2);
    transition.x = x2 - x1;
    transition.y = y2 - y1;
  }
}
