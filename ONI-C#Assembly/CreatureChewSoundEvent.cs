﻿// Decompiled with JetBrains decompiler
// Type: CreatureChewSoundEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMOD.Studio;
using UnityEngine;

#nullable disable
public class CreatureChewSoundEvent(
  string file_name,
  string sound_name,
  int frame,
  float min_interval) : SoundEvent(file_name, sound_name, frame, false, false, min_interval, true)
{
  private static string DEFAULT_CHEW_SOUND = "Rock";
  private const string FMOD_PARAM_IS_BABY_ID = "isBaby";

  public override void OnPlay(AnimEventManager.EventPlayerData behaviour)
  {
    string sound = GlobalAssets.GetSound(StringFormatter.Combine(this.name, "_", CreatureChewSoundEvent.GetChewSound(behaviour)));
    this.objectIsSelectedAndVisible = SoundEvent.ObjectIsSelectedAndVisible(behaviour.controller.gameObject);
    if (!this.objectIsSelectedAndVisible && !SoundEvent.ShouldPlaySound(behaviour.controller, sound, this.looping, this.isDynamic))
      return;
    Vector3 vector3 = behaviour.position with { z = 0.0f };
    if (this.objectIsSelectedAndVisible)
      vector3 = SoundEvent.AudioHighlightListenerPosition(vector3);
    EventInstance instance = SoundEvent.BeginOneShot(sound, vector3, SoundEvent.GetVolume(this.objectIsSelectedAndVisible));
    if (behaviour.controller.gameObject.GetDef<BabyMonitor.Def>() != null)
    {
      int num = (int) instance.setParameterByName("isBaby", 1f);
    }
    SoundEvent.EndOneShot(instance);
  }

  private static string GetChewSound(AnimEventManager.EventPlayerData behaviour)
  {
    string chewSound = CreatureChewSoundEvent.DEFAULT_CHEW_SOUND;
    EatStates.Instance smi = behaviour.controller.GetSMI<EatStates.Instance>();
    if (smi != null)
    {
      Element latestMealElement = smi.GetLatestMealElement();
      if (latestMealElement != null)
      {
        string creatureChewSound = latestMealElement.substance.GetCreatureChewSound();
        if (!string.IsNullOrEmpty(creatureChewSound))
          chewSound = creatureChewSound;
      }
    }
    return chewSound;
  }
}
