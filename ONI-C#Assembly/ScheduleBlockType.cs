// Decompiled with JetBrains decompiler
// Type: ScheduleBlockType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;
using UnityEngine;

#nullable disable
[DebuggerDisplay("{Id}")]
public class ScheduleBlockType : Resource
{
  public Color color { get; private set; }

  public string description { get; private set; }

  public ScheduleBlockType(
    string id,
    ResourceSet parent,
    string name,
    string description,
    Color color)
    : base(id, parent, name)
  {
    this.color = color;
    this.description = description;
  }
}
