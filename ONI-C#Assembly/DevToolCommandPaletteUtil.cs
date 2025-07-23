// Decompiled with JetBrains decompiler
// Type: DevToolCommandPaletteUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

#nullable disable
public static class DevToolCommandPaletteUtil
{
  public static List<DevToolCommandPalette.Command> GenerateDefaultCommandPalette()
  {
    List<DevToolCommandPalette.Command> defaultCommandPalette = new List<DevToolCommandPalette.Command>();
    foreach (System.Type type in ReflectionUtil.CollectTypesThatInheritOrImplement<DevTool>())
    {
      System.Type devToolType = type;
      if (!devToolType.IsAbstract && ReflectionUtil.HasDefaultConstructor(devToolType))
        defaultCommandPalette.Add(new DevToolCommandPalette.Command($"Open DevTool: \"{DevToolUtil.GenerateDevToolName(devToolType)}\"", (System.Action) (() => DevToolUtil.Open((DevTool) Activator.CreateInstance(devToolType)))));
    }
    return defaultCommandPalette;
  }
}
