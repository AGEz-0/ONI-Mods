// Decompiled with JetBrains decompiler
// Type: MainMenuSoundEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMOD.Studio;
using UnityEngine;

#nullable disable
public class MainMenuSoundEvent(string file_name, string sound_name, int frame) : SoundEvent(file_name, sound_name, frame, true, false, (float) SoundEvent.IGNORE_INTERVAL, false)
{
  public override void PlaySound(AnimEventManager.EventPlayerData behaviour)
  {
    EventInstance instance = KFMOD.BeginOneShot(this.sound, Vector3.zero);
    if (!instance.isValid())
      return;
    int num = (int) instance.setParameterByName("frame", (float) this.frame);
    KFMOD.EndOneShot(instance);
  }
}
