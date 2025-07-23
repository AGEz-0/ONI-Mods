// Decompiled with JetBrains decompiler
// Type: ObjectCountOneShotUpdater
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
internal class ObjectCountOneShotUpdater : OneShotSoundParameterUpdater
{
  private Dictionary<HashedString, int> soundCounts = new Dictionary<HashedString, int>();

  public ObjectCountOneShotUpdater()
    : base((HashedString) "objectCount")
  {
  }

  public override void Update(float dt) => this.soundCounts.Clear();

  public override void Play(OneShotSoundParameterUpdater.Sound sound)
  {
    UpdateObjectCountParameter.Settings settings = UpdateObjectCountParameter.GetSettings(sound.path, sound.description);
    int num = 0;
    this.soundCounts.TryGetValue(sound.path, out num);
    int count;
    this.soundCounts[sound.path] = count = num + 1;
    UpdateObjectCountParameter.ApplySettings(sound.ev, count, settings);
  }
}
