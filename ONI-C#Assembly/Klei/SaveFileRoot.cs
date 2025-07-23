// Decompiled with JetBrains decompiler
// Type: Klei.SaveFileRoot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Klei;

internal class SaveFileRoot
{
  public int WidthInCells;
  public int HeightInCells;
  public Dictionary<string, byte[]> streamed;
  public string clusterID;
  public List<ModInfo> requiredMods;
  public List<KMod.Label> active_mods;

  public SaveFileRoot() => this.streamed = new Dictionary<string, byte[]>();
}
