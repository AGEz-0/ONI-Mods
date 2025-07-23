// Decompiled with JetBrains decompiler
// Type: MetricsOptionsScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Events;

#nullable disable
public class MetricsOptionsScreen : KModalScreen
{
  public LocText title;
  public KButton dismissButton;
  public KButton closeButton;
  public GameObject enableButton;
  public UnityEngine.UI.Button descriptionButton;
  public LocText restartWarningText;
  private bool disableDataCollection;

  private bool IsSettingsDirty()
  {
    return this.disableDataCollection != KPrivacyPrefs.instance.disableDataCollection;
  }

  public override void OnKeyDown(KButtonEvent e)
  {
    if ((e.TryConsume(Action.Escape) || e.TryConsume(Action.MouseRight)) && !this.IsSettingsDirty())
      this.Show(false);
    base.OnKeyDown(e);
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.disableDataCollection = KPrivacyPrefs.instance.disableDataCollection;
    this.title.SetText((string) STRINGS.UI.FRONTEND.METRICS_OPTIONS_SCREEN.TITLE);
    GameObject gameObject = this.enableButton.GetComponent<HierarchyReferences>().GetReference("Button").gameObject;
    gameObject.GetComponent<ToolTip>().SetSimpleTooltip((string) STRINGS.UI.FRONTEND.METRICS_OPTIONS_SCREEN.TOOLTIP);
    gameObject.GetComponent<KButton>().onClick += (System.Action) (() => this.OnClickToggle());
    this.enableButton.GetComponent<HierarchyReferences>().GetReference<LocText>("Text").SetText((string) STRINGS.UI.FRONTEND.METRICS_OPTIONS_SCREEN.ENABLE_BUTTON);
    this.dismissButton.onClick += (System.Action) (() =>
    {
      if (this.IsSettingsDirty())
        this.ApplySettingsAndDoRestart();
      else
        this.Deactivate();
    });
    this.closeButton.onClick += (System.Action) (() => this.Deactivate());
    this.descriptionButton.onClick.AddListener((UnityAction) (() => App.OpenWebURL("https://www.kleientertainment.com/privacy-policy")));
    this.Refresh();
  }

  private void OnClickToggle()
  {
    this.disableDataCollection = !this.disableDataCollection;
    this.enableButton.GetComponent<HierarchyReferences>().GetReference("CheckMark").gameObject.SetActive(this.disableDataCollection);
    this.Refresh();
  }

  private void ApplySettingsAndDoRestart()
  {
    KPrivacyPrefs.instance.disableDataCollection = this.disableDataCollection;
    KPrivacyPrefs.Save();
    KPlayerPrefs.SetString("DisableDataCollection", KPrivacyPrefs.instance.disableDataCollection ? "yes" : "no");
    KPlayerPrefs.Save();
    ThreadedHttps<KleiMetrics>.Instance.SetEnabled(!KPrivacyPrefs.instance.disableDataCollection);
    this.enableButton.GetComponent<HierarchyReferences>().GetReference("CheckMark").gameObject.SetActive(ThreadedHttps<KleiMetrics>.Instance.enabled);
    App.instance.Restart();
  }

  private void Refresh()
  {
    this.enableButton.GetComponent<HierarchyReferences>().GetReference("Button").transform.GetChild(0).gameObject.SetActive(!this.disableDataCollection);
    this.closeButton.isInteractable = !this.IsSettingsDirty();
    this.restartWarningText.gameObject.SetActive(this.IsSettingsDirty());
    if (this.IsSettingsDirty())
      this.dismissButton.GetComponentInChildren<LocText>().text = (string) STRINGS.UI.FRONTEND.METRICS_OPTIONS_SCREEN.RESTART_BUTTON;
    else
      this.dismissButton.GetComponentInChildren<LocText>().text = (string) STRINGS.UI.FRONTEND.METRICS_OPTIONS_SCREEN.DONE_BUTTON;
  }
}
