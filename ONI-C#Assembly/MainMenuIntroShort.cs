// Decompiled with JetBrains decompiler
// Type: MainMenuIntroShort
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/MainMenuIntroShort")]
public class MainMenuIntroShort : KMonoBehaviour
{
  [SerializeField]
  private bool alwaysPlay;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    string str = KPlayerPrefs.GetString("PlayShortOnLaunch", "");
    if ((string.IsNullOrEmpty(MainMenu.Instance.IntroShortName) ? 0 : (str != MainMenu.Instance.IntroShortName ? 1 : 0)) != 0)
    {
      VideoScreen component = KScreenManager.AddChild(FrontEndManager.Instance.gameObject, ScreenPrefabs.Instance.VideoScreen.gameObject).GetComponent<VideoScreen>();
      component.PlayVideo(Assets.GetVideo(MainMenu.Instance.IntroShortName), overrideAudioSnapshot: AudioMixerSnapshots.Get().MainMenuVideoPlayingSnapshot);
      component.OnStop += (System.Action) (() =>
      {
        KPlayerPrefs.SetString("PlayShortOnLaunch", MainMenu.Instance.IntroShortName);
        this.gameObject.SetActive(false);
      });
    }
    else
      this.gameObject.SetActive(false);
  }
}
