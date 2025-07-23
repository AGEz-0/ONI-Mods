// Decompiled with JetBrains decompiler
// Type: DevToolObjectViewer`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class DevToolObjectViewer<T> : DevTool
{
  private Func<T> getValue;

  public DevToolObjectViewer(Func<T> getValue)
  {
    this.getValue = getValue;
    this.Name = typeof (T).Name;
  }

  protected override void RenderTo(DevPanel panel)
  {
    T obj = this.getValue();
    this.Name = obj.GetType().Name;
    ImGuiEx.DrawObject((object) obj);
  }
}
