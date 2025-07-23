// Decompiled with JetBrains decompiler
// Type: Klei.Input.DigAction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.Actions;
using UnityEngine;

#nullable disable
namespace Klei.Input;

[ActionType("InterfaceTool", "Dig", true)]
public abstract class DigAction
{
  public void Uproot(int cell)
  {
    if (Grid.ObjectLayers[1].ContainsKey(cell))
    {
      GameObject gameObject = Grid.ObjectLayers[1][cell];
      if ((Object) gameObject == (Object) null)
        return;
      this.EntityDig(gameObject.GetComponent<IDigActionEntity>());
    }
    else
    {
      if (!Grid.ObjectLayers[5].ContainsKey(cell))
        return;
      GameObject gameObject = Grid.ObjectLayers[5][cell];
      if ((Object) gameObject == (Object) null)
        return;
      this.EntityDig(gameObject.GetComponent<IDigActionEntity>());
    }
  }

  public abstract void Dig(int cell, int distFromOrigin);

  protected abstract void EntityDig(IDigActionEntity digAction);
}
