// Decompiled with JetBrains decompiler
// Type: RoleSlotUnlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public class RoleSlotUnlock
{
  public string id { get; protected set; }

  public string name { get; protected set; }

  public string description { get; protected set; }

  public List<Tuple<string, int>> slots { get; protected set; }

  public Func<bool> isSatisfied { get; protected set; }

  public RoleSlotUnlock(
    string id,
    string name,
    string description,
    List<Tuple<string, int>> slots,
    Func<bool> isSatisfied)
  {
    this.id = id;
    this.name = name;
    this.description = description;
    this.slots = slots;
    this.isSatisfied = isSatisfied;
  }
}
