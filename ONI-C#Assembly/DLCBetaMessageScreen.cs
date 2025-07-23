// Decompiled with JetBrains decompiler
// Type: DLCBetaMessageScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DLCBetaMessageScreen : KModalScreen
{
  public RectTransform logo;
  public KButton confirmButton;
  public KButton quitButton;
  public LocText bodyText;
  public RectTransform messageContainer;
  private bool betaIsLive;
  private bool skipInEditor;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
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
    if (!this.betaIsLive || Application.isEditor && this.skipInEditor || !DlcManager.IsContentSubscribed("DLC4_ID"))
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
    else
      AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndWelcomeScreenSnapshot);
  }

  private void Update()
  {
    this.logo.rectTransform().localPosition = new Vector3(0.0f, Mathf.Sin(Time.realtimeSinceStartup) * 7.5f);
  }
}
