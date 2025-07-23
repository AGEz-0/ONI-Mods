// Decompiled with JetBrains decompiler
// Type: ModInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

#nullable disable
[Serializable]
public struct ModInfo
{
  [JsonConverter(typeof (StringEnumConverter))]
  public ModInfo.Source source;
  [JsonConverter(typeof (StringEnumConverter))]
  public ModInfo.ModType type;
  public string assetID;
  public string assetPath;
  public bool enabled;
  public bool markedForDelete;
  public bool markedForUpdate;
  public string description;
  public ulong lastModifiedTime;

  public enum Source
  {
    Local,
    Steam,
    Rail,
  }

  public enum ModType
  {
    WorldGen,
    Scenario,
    Mod,
  }
}
