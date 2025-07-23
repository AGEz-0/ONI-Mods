﻿// Decompiled with JetBrains decompiler
// Type: SoundEventVolumeCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class SoundEventVolumeCache : Singleton<SoundEventVolumeCache>
{
  public Dictionary<HashedString, EffectorValues> volumeCache = new Dictionary<HashedString, EffectorValues>();

  public static SoundEventVolumeCache instance => Singleton<SoundEventVolumeCache>.Instance;

  public void AddVolume(string animFile, string eventName, EffectorValues vals)
  {
    HashedString key = new HashedString($"{animFile}:{eventName}");
    if (!this.volumeCache.ContainsKey(key))
      this.volumeCache.Add(key, vals);
    else
      this.volumeCache[key] = vals;
  }

  public EffectorValues GetVolume(string animFile, string eventName)
  {
    HashedString key = new HashedString($"{animFile}:{eventName}");
    return !this.volumeCache.ContainsKey(key) ? new EffectorValues() : this.volumeCache[key];
  }
}
