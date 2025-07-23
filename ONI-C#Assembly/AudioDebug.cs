// Decompiled with JetBrains decompiler
// Type: AudioDebug
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/AudioDebug")]
public class AudioDebug : KMonoBehaviour
{
  private static AudioDebug instance;
  public bool musicEnabled;
  public bool debugSoundEvents;
  public bool debugFloorSounds;
  public bool debugGameEventSounds;
  public bool debugNotificationSounds;
  public bool debugVoiceSounds;

  public static AudioDebug Get() => AudioDebug.instance;

  protected override void OnPrefabInit() => AudioDebug.instance = this;

  public void ToggleMusic()
  {
    if ((Object) Game.Instance != (Object) null)
      Game.Instance.SetMusicEnabled(this.musicEnabled);
    this.musicEnabled = !this.musicEnabled;
  }
}
