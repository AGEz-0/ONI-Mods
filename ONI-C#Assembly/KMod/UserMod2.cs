// Decompiled with JetBrains decompiler
// Type: KMod.UserMod2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace KMod;

public class UserMod2
{
  public Assembly assembly { get; set; }

  public string path { get; set; }

  public Mod mod { get; set; }

  public virtual void OnLoad(Harmony harmony) => harmony.PatchAll(this.assembly);

  public virtual void OnAllModsLoaded(Harmony harmony, IReadOnlyList<Mod> mods)
  {
  }
}
