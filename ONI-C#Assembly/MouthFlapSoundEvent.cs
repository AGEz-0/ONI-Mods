// Decompiled with JetBrains decompiler
// Type: MouthFlapSoundEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class MouthFlapSoundEvent(string file_name, string sound_name, int frame, bool is_looping) : 
  SoundEvent(file_name, sound_name, frame, false, is_looping, (float) SoundEvent.IGNORE_INTERVAL, true)
{
  public override void OnPlay(AnimEventManager.EventPlayerData behaviour)
  {
    behaviour.controller.GetSMI<SpeechMonitor.Instance>().PlaySpeech(this.name, (string) null);
  }
}
