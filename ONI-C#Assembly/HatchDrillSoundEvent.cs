﻿// Decompiled with JetBrains decompiler
// Type: HatchDrillSoundEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMOD.Studio;
using UnityEngine;

#nullable disable
public class HatchDrillSoundEvent(
  string file_name,
  string sound_name,
  int frame,
  float min_interval) : SoundEvent(file_name, sound_name, frame, true, true, min_interval, false)
{
  public override void PlaySound(AnimEventManager.EventPlayerData behaviour)
  {
    Vector3 vector3 = behaviour.position with { z = 0.0f };
    if (SoundEvent.ObjectIsSelectedAndVisible(behaviour.controller.gameObject))
      vector3 = SoundEvent.AudioHighlightListenerPosition(vector3);
    float audioCategory = (float) HatchDrillSoundEvent.GetAudioCategory(Grid.CellBelow(Grid.PosToCell(vector3)));
    EventInstance instance = SoundEvent.BeginOneShot(this.sound, vector3);
    int num = (int) instance.setParameterByName("material_ID", audioCategory);
    SoundEvent.EndOneShot(instance);
  }

  private static int GetAudioCategory(int cell)
  {
    if (!Grid.IsValidCell(cell))
      return 7;
    Element element = Grid.Element[cell];
    if (element.id == SimHashes.Dirt)
      return 0;
    if (element.HasTag(GameTags.IceOre))
      return 1;
    if (element.id == SimHashes.CrushedIce)
      return 12;
    if (element.id == SimHashes.DirtyIce)
      return 13;
    if (Grid.Foundation[cell])
      return 2;
    if (element.id == SimHashes.OxyRock)
      return 3;
    if (element.id == SimHashes.PhosphateNodules || element.id == SimHashes.Phosphorus || element.id == SimHashes.Phosphorite)
      return 4;
    if (element.HasTag(GameTags.Metal))
      return 5;
    if (element.HasTag(GameTags.RefinedMetal))
      return 6;
    if (element.id == SimHashes.Sand)
      return 8;
    if (element.id == SimHashes.Clay)
      return 9;
    if (element.id == SimHashes.Algae)
      return 10;
    return element.id == SimHashes.SlimeMold ? 11 : 7;
  }
}
