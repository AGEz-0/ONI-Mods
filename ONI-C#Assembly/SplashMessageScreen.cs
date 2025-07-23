// Decompiled with JetBrains decompiler
// Type: SplashMessageScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SplashMessageScreen")]
public class SplashMessageScreen : KMonoBehaviour
{
  public KButton forumButton;
  public KButton confirmButton;
  public LocText bodyText;
  public bool previewInEditor;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.forumButton.onClick += (System.Action) (() => App.OpenWebURL("https://forums.kleientertainment.com/forums/forum/118-oxygen-not-included/"));
    this.confirmButton.onClick += (System.Action) (() =>
    {
      this.gameObject.SetActive(false);
      AudioMixer.instance.Stop(AudioMixerSnapshots.Get().FrontEndWelcomeScreenSnapshot);
    });
    this.bodyText.text = (string) STRINGS.UI.DEVELOPMENTBUILDS.ALPHA.LOADING.BODY;
  }

  private void OnEnable()
  {
    this.confirmButton.GetComponent<LayoutElement>();
    this.confirmButton.GetComponentInChildren<LocText>();
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (!DlcManager.IsExpansion1Active())
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    else
      AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndWelcomeScreenSnapshot);
  }
}
