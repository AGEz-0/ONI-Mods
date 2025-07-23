// Decompiled with JetBrains decompiler
// Type: Expectation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class Expectation
{
  public string id { get; protected set; }

  public string name { get; protected set; }

  public string description { get; protected set; }

  public Action<MinionResume> OnApply { get; protected set; }

  public Action<MinionResume> OnRemove { get; protected set; }

  public Expectation(
    string id,
    string name,
    string description,
    Action<MinionResume> OnApply,
    Action<MinionResume> OnRemove)
  {
    this.id = id;
    this.name = name;
    this.description = description;
    this.OnApply = OnApply;
    this.OnRemove = OnRemove;
  }
}
