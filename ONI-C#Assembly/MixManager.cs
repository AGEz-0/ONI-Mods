// Decompiled with JetBrains decompiler
// Type: MixManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MixManager : MonoBehaviour
{
  private void Update()
  {
    if (AudioMixer.instance == null || !AudioMixer.instance.persistentSnapshotsActive)
      return;
    AudioMixer.instance.UpdatePersistentSnapshotParameters();
  }

  private void OnApplicationFocus(bool hasFocus)
  {
    if (AudioMixer.instance == null || (Object) AudioMixerSnapshots.Get() == (Object) null)
      return;
    if (!hasFocus && KPlayerPrefs.GetInt(AudioOptionsScreen.MuteOnFocusLost) == 1)
      AudioMixer.instance.Start(AudioMixerSnapshots.Get().GameNotFocusedSnapshot);
    else
      AudioMixer.instance.Stop(AudioMixerSnapshots.Get().GameNotFocusedSnapshot);
  }
}
