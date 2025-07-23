// Decompiled with JetBrains decompiler
// Type: UISounds
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/UISounds")]
public class UISounds : KMonoBehaviour
{
  [SerializeField]
  private bool logSounds;
  [SerializeField]
  private UISounds.SoundData[] soundData;

  public static UISounds Instance { get; private set; }

  public static void DestroyInstance() => UISounds.Instance = (UISounds) null;

  protected override void OnPrefabInit() => UISounds.Instance = this;

  public static void PlaySound(UISounds.Sound sound) => UISounds.Instance.PlaySoundInternal(sound);

  private void PlaySoundInternal(UISounds.Sound sound)
  {
    for (int index = 0; index < this.soundData.Length; ++index)
    {
      if (this.soundData[index].sound == sound)
      {
        if (this.logSounds)
          DebugUtil.LogArgs((object) "Play sound", (object) this.soundData[index].name);
        KMonoBehaviour.PlaySound(GlobalAssets.GetSound(this.soundData[index].name));
      }
    }
  }

  public enum Sound
  {
    NegativeNotification,
    PositiveNotification,
    Select,
    Negative,
    Back,
    ClickObject,
    HUD_Mouseover,
    Object_Mouseover,
    ClickHUD,
    Object_AutoSelected,
  }

  [Serializable]
  private struct SoundData
  {
    public string name;
    public UISounds.Sound sound;
  }
}
