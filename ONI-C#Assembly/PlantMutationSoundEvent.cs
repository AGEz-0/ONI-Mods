// Decompiled with JetBrains decompiler
// Type: PlantMutationSoundEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class PlantMutationSoundEvent(
  string file_name,
  string sound_name,
  int frame,
  float min_interval) : SoundEvent(file_name, sound_name, frame, false, false, min_interval, true)
{
  public override void OnPlay(AnimEventManager.EventPlayerData behaviour)
  {
    MutantPlant component = behaviour.controller.gameObject.GetComponent<MutantPlant>();
    Vector3 position = behaviour.position;
    if (!((Object) component != (Object) null))
      return;
    for (int index = 0; index < component.GetSoundEvents().Count; ++index)
      SoundEvent.PlayOneShot(component.GetSoundEvents()[index], position);
  }
}
