﻿// Decompiled with JetBrains decompiler
// Type: SymbolicConsumableItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class SymbolicConsumableItem : IConsumableUIItem
{
  private string id;
  private string name;
  private int majorOrder;
  private int minorOrder;
  private bool display;
  private string overrideSpriteName;
  private Func<bool> revealTest;

  public SymbolicConsumableItem(
    string id,
    string name,
    int majorOrder,
    int minorOrder,
    bool display,
    string overrideSpriteName,
    Func<bool> revealTest)
  {
    this.id = id;
    this.name = name;
    this.majorOrder = majorOrder;
    this.minorOrder = minorOrder;
    this.display = display;
    this.overrideSpriteName = overrideSpriteName;
    this.revealTest = revealTest;
  }

  string IConsumableUIItem.ConsumableId => this.id;

  string IConsumableUIItem.ConsumableName => this.name;

  int IConsumableUIItem.MajorOrder => this.majorOrder;

  int IConsumableUIItem.MinorOrder => this.minorOrder;

  bool IConsumableUIItem.Display => this.display;

  string IConsumableUIItem.OverrideSpriteName() => this.overrideSpriteName;

  bool IConsumableUIItem.RevealTest() => this.revealTest();
}
