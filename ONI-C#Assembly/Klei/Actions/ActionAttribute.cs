// Decompiled with JetBrains decompiler
// Type: Klei.Actions.ActionAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Klei.Actions;

[AttributeUsage(AttributeTargets.Class)]
public class ActionAttribute : Attribute
{
  public readonly string ActionName;

  public ActionAttribute(string actionName) => this.ActionName = actionName;
}
