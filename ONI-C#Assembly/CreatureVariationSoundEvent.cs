// Decompiled with JetBrains decompiler
// Type: CreatureVariationSoundEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CreatureVariationSoundEvent(
  string file_name,
  string sound_name,
  int frame,
  bool do_load,
  bool is_looping,
  float min_interval,
  bool is_dynamic) : SoundEvent(file_name, sound_name, frame, do_load, is_looping, min_interval, is_dynamic)
{
  public override void PlaySound(AnimEventManager.EventPlayerData behaviour)
  {
    string sound1 = this.sound;
    CreatureBrain component = behaviour.GetComponent<CreatureBrain>();
    if ((Object) component != (Object) null && !string.IsNullOrEmpty(component.symbolPrefix))
    {
      string sound2 = GlobalAssets.GetSound(StringFormatter.Combine(component.symbolPrefix, this.name));
      if (!string.IsNullOrEmpty(sound2))
        sound1 = sound2;
    }
    this.PlaySound(behaviour, sound1);
  }
}
