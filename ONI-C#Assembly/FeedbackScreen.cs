// Decompiled with JetBrains decompiler
// Type: FeedbackScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Steamworks;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class FeedbackScreen : KModalScreen
{
  public LocText title;
  public KButton dismissButton;
  public KButton closeButton;
  public KButton bugForumsButton;
  public KButton suggestionForumsButton;
  public KButton logsDirectoryButton;
  public KButton saveFilesDirectoryButton;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.title.SetText((string) STRINGS.UI.FRONTEND.FEEDBACK_SCREEN.TITLE);
    this.dismissButton.onClick += (System.Action) (() => this.Deactivate());
    this.closeButton.onClick += (System.Action) (() => this.Deactivate());
    this.bugForumsButton.onClick += (System.Action) (() => App.OpenWebURL("https://forums.kleientertainment.com/klei-bug-tracker/oni/"));
    this.suggestionForumsButton.onClick += (System.Action) (() => App.OpenWebURL("https://forums.kleientertainment.com/forums/forum/133-oxygen-not-included-suggestions-and-feedback/"));
    this.logsDirectoryButton.onClick += (System.Action) (() => App.OpenWebURL(Util.LogsFolder()));
    this.saveFilesDirectoryButton.onClick += (System.Action) (() => App.OpenWebURL(SaveLoader.GetSavePrefix()));
    if (!SteamUtils.IsSteamRunningOnSteamDeck())
      return;
    this.logsDirectoryButton.GetComponentInParent<VerticalLayoutGroup>().padding = new RectOffset(0, 0, 0, 0);
    this.saveFilesDirectoryButton.gameObject.SetActive(false);
    this.logsDirectoryButton.gameObject.SetActive(false);
  }
}
