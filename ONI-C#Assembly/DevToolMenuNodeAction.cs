// Decompiled with JetBrains decompiler
// Type: DevToolMenuNodeAction
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class DevToolMenuNodeAction : IMenuNode
{
  public string name;
  public System.Action onClickFn;
  public Func<bool> isEnabledFn;

  public DevToolMenuNodeAction(string name, System.Action onClickFn)
  {
    this.name = name;
    this.onClickFn = onClickFn;
  }

  public string GetName() => this.name;

  public void Draw()
  {
    if (!ImGuiEx.MenuItem(this.name, this.isEnabledFn == null || this.isEnabledFn()))
      return;
    this.onClickFn();
  }
}
