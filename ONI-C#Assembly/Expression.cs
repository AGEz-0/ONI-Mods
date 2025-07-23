// Decompiled with JetBrains decompiler
// Type: Expression
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Diagnostics;

#nullable disable
[DebuggerDisplay("{face.hash} {priority}")]
public class Expression : Resource
{
  public Face face;
  public int priority;

  public Expression(string id, ResourceSet parent, Face face)
    : base(id, parent)
  {
    this.face = face;
  }
}
