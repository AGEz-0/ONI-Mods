// Decompiled with JetBrains decompiler
// Type: OldVersionMessageScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SplashMessageScreen")]
public class OldVersionMessageScreen : KModalScreen
{
  public KButton forumButton;
  public KButton confirmButton;
  public KButton quitButton;
  public LocText bodyText;
  public bool previewInEditor;
  public RectTransform messageContainer;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.forumButton.onClick += (System.Action) (() => App.OpenWebURL("https://forums.kleientertainment.com/forums/topic/140474-previous-update-steam-branch-access/"));
    this.confirmButton.onClick += (System.Action) (() =>
    {
      this.gameObject.SetActive(false);
      AudioMixer.instance.Stop(AudioMixerSnapshots.Get().FrontEndWelcomeScreenSnapshot);
    });
    this.quitButton.onClick += (System.Action) (() => App.Quit());
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.messageContainer.sizeDelta = new Vector2(Mathf.Max(384f, (float) Screen.width * 0.25f), this.messageContainer.sizeDelta.y);
    AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndWelcomeScreenSnapshot);
  }
}
