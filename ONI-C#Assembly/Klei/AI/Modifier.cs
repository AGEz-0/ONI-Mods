﻿// Decompiled with JetBrains decompiler
// Type: Klei.AI.Modifier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Klei.AI;

public class Modifier : Resource
{
  public string description;
  public List<AttributeModifier> SelfModifiers = new List<AttributeModifier>();

  public Modifier(string id, string name, string description)
    : base(id, name)
  {
    this.description = description;
  }

  public void Add(AttributeModifier modifier)
  {
    if (!(modifier.AttributeId != ""))
      return;
    this.SelfModifiers.Add(modifier);
  }

  public virtual void AddTo(Attributes attributes)
  {
    foreach (AttributeModifier selfModifier in this.SelfModifiers)
      attributes.Add(selfModifier);
  }

  public virtual void RemoveFrom(Attributes attributes)
  {
    foreach (AttributeModifier selfModifier in this.SelfModifiers)
      attributes.Remove(selfModifier);
  }
}
