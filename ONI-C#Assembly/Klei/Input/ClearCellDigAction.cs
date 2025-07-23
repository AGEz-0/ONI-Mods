// Decompiled with JetBrains decompiler
// Type: Klei.Input.ClearCellDigAction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.Actions;

#nullable disable
namespace Klei.Input;

[Action("Clear Cell")]
public class ClearCellDigAction : DigAction
{
  public override void Dig(int cell, int distFromOrigin)
  {
    if (!Grid.Solid[cell] || Grid.Foundation[cell])
      return;
    SimMessages.Dig(cell, skipEvent: true);
  }

  protected override void EntityDig(IDigActionEntity digActionEntity) => digActionEntity?.Dig();
}
