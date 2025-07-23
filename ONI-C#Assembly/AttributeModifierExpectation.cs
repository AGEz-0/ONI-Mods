// Decompiled with JetBrains decompiler
// Type: AttributeModifierExpectation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using UnityEngine;

#nullable disable
public class AttributeModifierExpectation : Expectation
{
  public AttributeModifier modifier;
  public Sprite icon;

  public AttributeModifierExpectation(
    string id,
    string name,
    string description,
    AttributeModifier modifier,
    Sprite icon)
    : base(id, name, description, (Action<MinionResume>) (resume => resume.GetAttributes().Get(modifier.AttributeId).Add(modifier)), (Action<MinionResume>) (resume => resume.GetAttributes().Get(modifier.AttributeId).Remove(modifier)))
  {
    this.modifier = modifier;
    this.icon = icon;
  }
}
