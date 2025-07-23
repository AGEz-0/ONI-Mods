﻿// Decompiled with JetBrains decompiler
// Type: ElementUsage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class ElementUsage
{
  public Tag tag;
  public float amount;
  public bool continuous;
  public Func<Tag, float, bool, string> customFormating;

  public ElementUsage(Tag tag, float amount, bool continuous)
    : this(tag, amount, continuous, (Func<Tag, float, bool, string>) null)
  {
  }

  public ElementUsage(
    Tag tag,
    float amount,
    bool continuous,
    Func<Tag, float, bool, string> customFormating)
  {
    this.tag = tag;
    this.amount = amount;
    this.continuous = continuous;
    this.customFormating = customFormating;
  }
}
