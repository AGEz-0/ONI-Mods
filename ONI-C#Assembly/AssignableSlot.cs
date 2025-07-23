// Decompiled with JetBrains decompiler
// Type: AssignableSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Diagnostics;
using UnityEngine;

#nullable disable
[DebuggerDisplay("{Id}")]
[Serializable]
public class AssignableSlot : Resource
{
  public bool showInUI = true;

  public AssignableSlot(string id, string name, bool showInUI = true)
    : base(id, name)
  {
    this.showInUI = showInUI;
  }

  public AssignableSlotInstance Lookup(GameObject go)
  {
    Assignables component = go.GetComponent<Assignables>();
    return (UnityEngine.Object) component != (UnityEngine.Object) null ? component.GetSlot(this) : (AssignableSlotInstance) null;
  }
}
