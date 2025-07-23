// Decompiled with JetBrains decompiler
// Type: DoorTransitionLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DoorTransitionLayer(Navigator navigator) : TransitionDriver.InterruptOverrideLayer(navigator)
{
  private List<INavDoor> doors = new List<INavDoor>();

  private bool AreAllDoorsOpen()
  {
    foreach (INavDoor door in this.doors)
    {
      if (door != null && !door.IsOpen())
        return false;
    }
    return true;
  }

  protected override bool IsOverrideComplete()
  {
    return base.IsOverrideComplete() && this.AreAllDoorsOpen();
  }

  public override void BeginTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    if (this.doors.Count > 0)
      return;
    int cell1 = Grid.PosToCell((KMonoBehaviour) navigator);
    int cell2 = Grid.OffsetCell(cell1, transition.x, transition.y);
    this.AddDoor(cell2);
    if (navigator.CurrentNavType != NavType.Tube)
      this.AddDoor(Grid.CellAbove(cell2));
    for (int index = 0; index < transition.navGridTransition.voidOffsets.Length; ++index)
      this.AddDoor(Grid.OffsetCell(cell1, transition.navGridTransition.voidOffsets[index]));
    if (this.doors.Count == 0)
      return;
    if (!this.AreAllDoorsOpen())
    {
      base.BeginTransition(navigator, transition);
      transition.anim = navigator.NavGrid.GetIdleAnim(navigator.CurrentNavType);
      transition.start = this.originalTransition.start;
      transition.end = this.originalTransition.start;
    }
    foreach (INavDoor door in this.doors)
      door.Open();
  }

  public override void EndTransition(Navigator navigator, Navigator.ActiveTransition transition)
  {
    base.EndTransition(navigator, transition);
    if (this.doors.Count == 0)
      return;
    foreach (INavDoor door in this.doors)
    {
      if (!door.IsNullOrDestroyed())
        door.Close();
    }
    this.doors.Clear();
  }

  private void AddDoor(int cell)
  {
    INavDoor door = this.GetDoor(cell);
    if (door.IsNullOrDestroyed() || this.doors.Contains(door))
      return;
    this.doors.Add(door);
  }

  private INavDoor GetDoor(int cell)
  {
    if (!Grid.HasDoor[cell])
      return (INavDoor) null;
    GameObject go = Grid.Objects[cell, 1];
    if ((Object) go != (Object) null)
    {
      INavDoor door = go.GetComponent<INavDoor>() ?? go.GetSMI<INavDoor>();
      if (door != null && door.isSpawned)
        return door;
    }
    return (INavDoor) null;
  }
}
