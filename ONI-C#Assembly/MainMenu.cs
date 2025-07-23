﻿// Decompiled with JetBrains decompiler
// Type: MainMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMOD.Studio;
using Klei;
using ProcGenGame;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MainMenu : KScreen
{
  private static MainMenu _instance;
  public KButton Button_ResumeGame;
  private KButton Button_NewGame;
  private GameObject GameSettingsScreen;
  private bool m_screenshotMode;
  [SerializeField]
  private CanvasGroup uiCanvas;
  [SerializeField]
  private KButton buttonPrefab;
  [SerializeField]
  private GameObject buttonParent;
  [SerializeField]
  private ColorStyleSetting topButtonStyle;
  [SerializeField]
  private ColorStyleSetting normalButtonStyle;
  [SerializeField]
  private string menuMusicEventName;
  [SerializeField]
  private string ambientLoopEventName;
  private EventInstance ambientLoop;
  [SerializeField]
  private MainMenu_Motd motd;
  [SerializeField]
  private PatchNotesScreen patchNotesScreenPrefab;
  [SerializeField]
  private NextUpdateTimer nextUpdateTimer;
  [SerializeField]
  private DLCToggle expansion1Toggle;
  [SerializeField]
  private GameObject expansion1Ad;
  [SerializeField]
  private BuildWatermark buildWatermark;
  [SerializeField]
  public string IntroShortName;
  [SerializeField]
  private HierarchyReferences logoDLC1;
  [SerializeField]
  private HierarchyReferences logoDLC2;
  [SerializeField]
  private HierarchyReferences logoDLC3;
  [SerializeField]
  private HierarchyReferences logoDLC4;
  private KButton lockerButton;
  private bool itemDropOpenFlag;
  private static bool HasAutoresumedOnce = false;
  private bool refreshResumeButton = true;
  private int m_cheatInputCounter;
  public const string AutoResumeSaveFileKey = "AutoResumeSaveFile";
  public const string PLAY_SHORT_ON_LAUNCH = "PlayShortOnLaunch";
  private static int LANGUAGE_CONFIRMATION_VERSION = 2;
  private Dictionary<string, MainMenu.SaveFileEntry> saveFileEntries = new Dictionary<string, MainMenu.SaveFileEntry>();

  public static MainMenu Instance => MainMenu._instance;

  private KButton MakeButton(MainMenu.ButtonInfo info)
  {
    KButton kbutton = Util.KInstantiateUI<KButton>(this.buttonPrefab.gameObject, this.buttonParent, true);
    kbutton.onClick += info.action;
    KImage component = kbutton.GetComponent<KImage>();
    component.colorStyleSetting = info.style;
    component.ApplyColorStyleSetting();
    LocText componentInChildren = kbutton.GetComponentInChildren<LocText>();
    componentInChildren.text = (string) info.text;
    componentInChildren.fontSize = (float) info.fontSize;
    return kbutton;
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    MainMenu._instance = this;
    this.Button_NewGame = this.MakeButton(new MainMenu.ButtonInfo(STRINGS.UI.FRONTEND.MAINMENU.NEWGAME, new System.Action(this.NewGame), 22, this.topButtonStyle));
    this.MakeButton(new MainMenu.ButtonInfo(STRINGS.UI.FRONTEND.MAINMENU.LOADGAME, new System.Action(this.LoadGame), 22, this.normalButtonStyle));
    this.MakeButton(new MainMenu.ButtonInfo(STRINGS.UI.FRONTEND.MAINMENU.RETIREDCOLONIES, (System.Action) (() => MainMenu.ActivateRetiredColoniesScreen(this.transform.gameObject)), 14, this.normalButtonStyle));
    this.lockerButton = this.MakeButton(new MainMenu.ButtonInfo(STRINGS.UI.FRONTEND.MAINMENU.LOCKERMENU, (System.Action) (() => MainMenu.ActivateLockerMenu()), 14, this.normalButtonStyle));
    if (DistributionPlatform.Initialized)
    {
      this.MakeButton(new MainMenu.ButtonInfo(STRINGS.UI.FRONTEND.MAINMENU.TRANSLATIONS, new System.Action(this.Translations), 14, this.normalButtonStyle));
      this.MakeButton(new MainMenu.ButtonInfo(STRINGS.UI.FRONTEND.MODS.TITLE, new System.Action(this.Mods), 14, this.normalButtonStyle));
    }
    this.MakeButton(new MainMenu.ButtonInfo(STRINGS.UI.FRONTEND.MAINMENU.OPTIONS, new System.Action(this.Options), 14, this.normalButtonStyle));
    this.MakeButton(new MainMenu.ButtonInfo(STRINGS.UI.FRONTEND.MAINMENU.QUITTODESKTOP, new System.Action(this.QuitGame), 14, this.normalButtonStyle));
    this.RefreshResumeButton();
    this.Button_ResumeGame.onClick += new System.Action(this.ResumeGame);
    this.SpawnVideoScreen();
    this.StartFEAudio();
    this.CheckPlayerPrefsCorruption();
    if (PatchNotesScreen.ShouldShowScreen())
      Util.KInstantiateUI(this.patchNotesScreenPrefab.gameObject, FrontEndManager.Instance.gameObject, true);
    this.CheckDoubleBoundKeys();
    bool flag = DistributionPlatform.Inst.IsDLCPurchased("EXPANSION1_ID");
    this.expansion1Toggle.gameObject.SetActive(flag);
    if ((UnityEngine.Object) this.expansion1Ad != (UnityEngine.Object) null)
      this.expansion1Ad.gameObject.SetActive(!flag);
    this.RefreshDLCLogos();
    this.motd.Setup();
    if (DistributionPlatform.Initialized && DistributionPlatform.Inst.IsPreviousVersionBranch)
      UnityEngine.Object.Instantiate<GameObject>(ScreenPrefabs.Instance.OldVersionWarningScreen, this.uiCanvas.transform);
    string targetExpansion1AdURL = "";
    Sprite sprite = Assets.GetSprite((HashedString) "expansionPromo_en");
    if (DistributionPlatform.Initialized && (UnityEngine.Object) this.expansion1Ad != (UnityEngine.Object) null)
    {
      switch (DistributionPlatform.Inst.Name)
      {
        case "Steam":
          targetExpansion1AdURL = "https://store.steampowered.com/app/1452490/Oxygen_Not_Included__Spaced_Out/";
          break;
        case "Epic":
          targetExpansion1AdURL = "https://store.epicgames.com/en-US/p/oxygen-not-included--spaced-out";
          break;
        case "Rail":
          targetExpansion1AdURL = "https://www.wegame.com.cn/store/2001539/";
          sprite = Assets.GetSprite((HashedString) "expansionPromo_cn");
          break;
      }
      this.expansion1Ad.GetComponentInChildren<KButton>().onClick += (System.Action) (() => App.OpenWebURL(targetExpansion1AdURL));
      this.expansion1Ad.GetComponent<HierarchyReferences>().GetReference<Image>("Image").sprite = sprite;
    }
    this.activateOnSpawn = true;
  }

  private void RefreshDLCLogos()
  {
    this.logoDLC1.GetReference<Image>("icon").material = DlcManager.IsContentSubscribed("EXPANSION1_ID") ? GlobalResources.Instance().AnimUIMaterial : GlobalResources.Instance().AnimMaterialUIDesaturated;
    this.logoDLC2.GetReference<Image>("icon").material = DlcManager.IsContentSubscribed("DLC2_ID") ? GlobalResources.Instance().AnimUIMaterial : GlobalResources.Instance().AnimMaterialUIDesaturated;
    this.logoDLC3.GetReference<Image>("icon").material = DlcManager.IsContentSubscribed("DLC3_ID") ? GlobalResources.Instance().AnimUIMaterial : GlobalResources.Instance().AnimMaterialUIDesaturated;
    this.logoDLC4.GetReference<Image>("icon").material = DlcManager.IsContentSubscribed("DLC4_ID") ? GlobalResources.Instance().AnimUIMaterial : GlobalResources.Instance().AnimMaterialUIDesaturated;
    if (!DistributionPlatform.Initialized && !Application.isEditor)
      return;
    string DLC1_STORE_URL = "";
    string DLC2_STORE_URL = "";
    string DLC3_STORE_URL = "";
    string DLC4_STORE_URL = "";
    switch (DistributionPlatform.Inst.Name)
    {
      case "Steam":
        DLC1_STORE_URL = "https://store.steampowered.com/app/1452490/Oxygen_Not_Included__Spaced_Out/";
        DLC2_STORE_URL = "https://store.steampowered.com/app/2952300/Oxygen_Not_Included_The_Frosty_Planet_Pack/";
        DLC3_STORE_URL = "https://store.steampowered.com/app/3302470/Oxygen_Not_Included_The_Bionic_Booster_Pack/";
        DLC4_STORE_URL = "https://store.steampowered.com/app/3655420/Oxygen_Not_Included_The_Prehistoric_Planet_Pack/";
        break;
      case "Epic":
        DLC1_STORE_URL = "https://store.epicgames.com/en-US/p/oxygen-not-included--spaced-out";
        DLC2_STORE_URL = "https://store.epicgames.com/p/oxygen-not-included-oxygen-not-included-the-frosty-planet-pack-915ba1";
        DLC3_STORE_URL = "https://store.epicgames.com/p/oxygen-not-included-oxygen-not-included-the-bionic-booster-pack-3ba9e9";
        DLC4_STORE_URL = "https://store.epicgames.com/p/oxygen-not-included-oxygen-not-included-the-prehistoric-planet-pack-c14f10";
        break;
      case "Rail":
        DLC1_STORE_URL = "https://www.wegame.com.cn/store/2001539/";
        DLC2_STORE_URL = "https://www.wegame.com.cn/store/2002196/";
        DLC3_STORE_URL = "https://www.wegame.com.cn/store/2002347";
        DLC4_STORE_URL = "https://www.wegame.com.cn/store/2002496";
        this.logoDLC1.GetReference<Image>("icon").sprite = Assets.GetSprite((HashedString) "dlc1_logo_crop_cn");
        this.logoDLC2.GetReference<Image>("icon").sprite = Assets.GetSprite((HashedString) "dlc2_logo_crop_cn");
        this.logoDLC3.GetReference<Image>("icon").sprite = Assets.GetSprite((HashedString) "dlc3_logo_crop_cn");
        this.logoDLC4.GetReference<Image>("icon").sprite = Assets.GetSprite((HashedString) "dlc4_logo_crop_cn");
        break;
    }
    this.logoDLC1.GetReference<MultiToggle>("multitoggle").onClick += (System.Action) (() =>
    {
      if (DlcManager.IsContentOwned("EXPANSION1_ID"))
        this.logoDLC1.GetReference<DLCToggle>("dlctoggle").ToggleExpansion1Cicked();
      else
        App.OpenWebURL(DLC1_STORE_URL);
    });
    string dlcStatusString = this.GetDLCStatusString("EXPANSION1_ID", true);
    string message1 = DlcManager.IsContentOwned("EXPANSION1_ID") ? (string) (DlcManager.IsContentSubscribed("EXPANSION1_ID") ? STRINGS.UI.FRONTEND.MAINMENU.DLC.DEACTIVATE_EXPANSION1_TOOLTIP : STRINGS.UI.FRONTEND.MAINMENU.DLC.ACTIVATE_EXPANSION1_TOOLTIP) : $"{dlcStatusString}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.WISHLIST_AD_TOOLTIP}";
    this.logoDLC1.GetReference<ToolTip>("tooltip").SetSimpleTooltip(message1);
    this.logoDLC2.GetReference<MultiToggle>("multitoggle").onClick += (System.Action) (() => App.OpenWebURL(DLC2_STORE_URL));
    this.logoDLC2.GetReference<LocText>("statuslabel").SetText(this.GetDLCStatusString("DLC2_ID"));
    string message2 = $"{this.GetDLCStatusString("DLC2_ID", true)}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.WISHLIST_AD_TOOLTIP}";
    this.logoDLC2.GetReference<ToolTip>("tooltip").SetSimpleTooltip(message2);
    this.logoDLC3.GetReference<MultiToggle>("multitoggle").onClick += (System.Action) (() => App.OpenWebURL(DLC3_STORE_URL));
    this.logoDLC3.GetReference<LocText>("statuslabel").SetText(this.GetDLCStatusString("DLC3_ID"));
    string message3 = $"{this.GetDLCStatusString("DLC3_ID", true)}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.WISHLIST_AD_TOOLTIP}";
    this.logoDLC3.GetReference<ToolTip>("tooltip").SetSimpleTooltip(message3);
    this.logoDLC4.GetReference<MultiToggle>("multitoggle").onClick += (System.Action) (() => App.OpenWebURL(DLC4_STORE_URL));
    this.logoDLC4.GetReference<LocText>("statuslabel").SetText(this.GetDLCStatusString("DLC4_ID"));
    string message4 = $"{this.GetDLCStatusString("DLC4_ID", true)}\n\n{(string) STRINGS.UI.FRONTEND.MAINMENU.WISHLIST_AD_TOOLTIP}";
    this.logoDLC4.GetReference<ToolTip>("tooltip").SetSimpleTooltip(message4);
  }

  public string GetDLCStatusString(string dlcID, bool tooltip = false)
  {
    if (!DlcManager.IsContentOwned(dlcID))
      return (string) (tooltip ? STRINGS.UI.FRONTEND.MAINMENU.DLC.CONTENT_NOTOWNED_TOOLTIP : STRINGS.UI.FRONTEND.MAINMENU.WISHLIST_AD);
    return DlcManager.IsContentSubscribed(dlcID) ? (string) (tooltip ? STRINGS.UI.FRONTEND.MAINMENU.DLC.CONTENT_ACTIVE_TOOLTIP : STRINGS.UI.FRONTEND.MAINMENU.DLC.CONTENT_INSTALLED_LABEL) : (string) (tooltip ? STRINGS.UI.FRONTEND.MAINMENU.DLC.CONTENT_OWNED_NOTINSTALLED_TOOLTIP : STRINGS.UI.FRONTEND.MAINMENU.DLC.CONTENT_OWNED_NOTINSTALLED_LABEL);
  }

  private void OnApplicationFocus(bool focus)
  {
    if (!focus)
      return;
    this.RefreshResumeButton();
  }

  public override void OnKeyDown(KButtonEvent e)
  {
    base.OnKeyDown(e);
    if (e.Consumed)
      return;
    if (e.TryConsume(Action.DebugToggleUI))
    {
      this.m_screenshotMode = !this.m_screenshotMode;
      this.uiCanvas.alpha = this.m_screenshotMode ? 0.0f : 1f;
    }
    KKeyCode key_code;
    switch (this.m_cheatInputCounter)
    {
      case 0:
        key_code = KKeyCode.K;
        break;
      case 1:
        key_code = KKeyCode.L;
        break;
      case 2:
        key_code = KKeyCode.E;
        break;
      case 3:
        key_code = KKeyCode.I;
        break;
      case 4:
        key_code = KKeyCode.P;
        break;
      case 5:
        key_code = KKeyCode.L;
        break;
      case 6:
        key_code = KKeyCode.A;
        break;
      default:
        key_code = KKeyCode.Y;
        break;
    }
    if (e.Controller.GetKeyDown(key_code))
    {
      e.Consumed = true;
      ++this.m_cheatInputCounter;
      if (this.m_cheatInputCounter < 8)
        return;
      Debug.Log((object) "Cheat Detected - enabling Debug Mode");
      DebugHandler.SetDebugEnabled(true);
      this.buildWatermark.RefreshText();
      this.m_cheatInputCounter = 0;
    }
    else
      this.m_cheatInputCounter = 0;
  }

  private void PlayMouseOverSound()
  {
    KMonoBehaviour.PlaySound(GlobalAssets.GetSound("HUD_Mouseover"));
  }

  private void PlayMouseClickSound()
  {
    KMonoBehaviour.PlaySound(GlobalAssets.GetSound("HUD_Click_Open"));
  }

  protected override void OnSpawn()
  {
    Debug.Log((object) "-- MAIN MENU -- ");
    base.OnSpawn();
    this.m_cheatInputCounter = 0;
    Canvas.ForceUpdateCanvases();
    this.ShowLanguageConfirmation();
    this.InitLoadScreen();
    LoadScreen.Instance.ShowMigrationIfNecessary(true);
    string savePrefix = SaveLoader.GetSavePrefix();
    try
    {
      string path = System.IO.Path.Combine(savePrefix, "__SPCCHK");
      using (FileStream fileStream = File.OpenWrite(path))
      {
        byte[] buffer = new byte[1024 /*0x0400*/];
        for (int index = 0; index < 15360; ++index)
          fileStream.Write(buffer, 0, buffer.Length);
      }
      File.Delete(path);
    }
    catch (Exception ex)
    {
      string text = string.Format(!(ex is IOException) ? string.Format((string) STRINGS.UI.FRONTEND.SUPPORTWARNINGS.SAVE_DIRECTORY_READ_ONLY, (object) savePrefix) : string.Format((string) STRINGS.UI.FRONTEND.SUPPORTWARNINGS.SAVE_DIRECTORY_INSUFFICIENT_SPACE, (object) savePrefix), (object) savePrefix);
      Util.KInstantiateUI<ConfirmDialogScreen>(ScreenPrefabs.Instance.ConfirmDialogScreen.gameObject, this.gameObject, true).PopupConfirmDialog(text, (System.Action) null, (System.Action) null);
    }
    Global.Instance.modManager.Report(this.gameObject);
    if (GenericGameSettings.instance.autoResumeGame && !MainMenu.HasAutoresumedOnce && !KCrashReporter.hasCrash || !string.IsNullOrEmpty(GenericGameSettings.instance.performanceCapture.saveGame) || KPlayerPrefs.HasKey("AutoResumeSaveFile"))
    {
      MainMenu.HasAutoresumedOnce = true;
      this.ResumeGame();
    }
    if (GenericGameSettings.instance.devAutoWorldGen && !KCrashReporter.hasCrash)
    {
      GenericGameSettings.instance.devAutoWorldGen = false;
      GenericGameSettings.instance.devAutoWorldGenActive = true;
      GenericGameSettings.instance.SaveSettings();
      Util.KInstantiateUI(ScreenPrefabs.Instance.WorldGenScreen.gameObject, this.gameObject, true);
    }
    this.RefreshInventoryNotification();
  }

  protected override void OnForcedCleanUp() => base.OnForcedCleanUp();

  private void RefreshInventoryNotification()
  {
    bool flag = PermitItems.HasUnopenedItem();
    this.lockerButton.GetComponent<HierarchyReferences>().GetReference<RectTransform>("AttentionIcon").gameObject.SetActive(flag);
  }

  protected override void OnActivate()
  {
    if (this.ambientLoopEventName.IsNullOrWhiteSpace())
      return;
    this.ambientLoop = KFMOD.CreateInstance(GlobalAssets.GetSound(this.ambientLoopEventName));
    if (!this.ambientLoop.isValid())
      return;
    int num = (int) this.ambientLoop.start();
  }

  protected override void OnDeactivate()
  {
    base.OnDeactivate();
    this.motd.CleanUp();
  }

  public override void ScreenUpdate(bool topLevel)
  {
    this.refreshResumeButton = topLevel;
    if (!((UnityEngine.Object) KleiItemDropScreen.Instance != (UnityEngine.Object) null) || KleiItemDropScreen.Instance.gameObject.activeInHierarchy == this.itemDropOpenFlag)
      return;
    this.RefreshInventoryNotification();
    this.itemDropOpenFlag = KleiItemDropScreen.Instance.gameObject.activeInHierarchy;
  }

  protected override void OnLoadLevel()
  {
    base.OnLoadLevel();
    this.StopAmbience();
    this.motd.CleanUp();
  }

  private void ShowLanguageConfirmation()
  {
    if (!SteamManager.Initialized || SteamUtils.GetSteamUILanguage() != "schinese" || KPlayerPrefs.GetInt("LanguageConfirmationVersion") >= MainMenu.LANGUAGE_CONFIRMATION_VERSION)
      return;
    KPlayerPrefs.SetInt("LanguageConfirmationVersion", MainMenu.LANGUAGE_CONFIRMATION_VERSION);
    this.Translations();
  }

  private void ResumeGame()
  {
    string path;
    if (KPlayerPrefs.HasKey("AutoResumeSaveFile"))
    {
      path = KPlayerPrefs.GetString("AutoResumeSaveFile");
      KPlayerPrefs.DeleteKey("AutoResumeSaveFile");
    }
    else
      path = string.IsNullOrEmpty(GenericGameSettings.instance.performanceCapture.saveGame) ? SaveLoader.GetLatestSaveForCurrentDLC() : GenericGameSettings.instance.performanceCapture.saveGame;
    if (string.IsNullOrEmpty(path))
      return;
    KCrashReporter.MOST_RECENT_SAVEFILE = path;
    SaveLoader.SetActiveSaveFilePath(path);
    LoadingOverlay.Load((System.Action) (() => App.LoadScene("backend")));
  }

  private void NewGame()
  {
    WorldGen.WaitForPendingLoadSettings();
    this.GetComponent<NewGameFlow>().BeginFlow();
  }

  private void InitLoadScreen()
  {
    if (!((UnityEngine.Object) LoadScreen.Instance == (UnityEngine.Object) null))
      return;
    Util.KInstantiateUI(ScreenPrefabs.Instance.LoadScreen.gameObject, this.gameObject, true).GetComponent<LoadScreen>();
  }

  private void LoadGame()
  {
    this.InitLoadScreen();
    LoadScreen.Instance.Activate();
  }

  public static void ActivateRetiredColoniesScreen(GameObject parent, string colonyID = "")
  {
    if ((UnityEngine.Object) RetiredColonyInfoScreen.Instance == (UnityEngine.Object) null)
      Util.KInstantiateUI(ScreenPrefabs.Instance.RetiredColonyInfoScreen.gameObject, parent, true);
    RetiredColonyInfoScreen.Instance.Show(true);
    if (string.IsNullOrEmpty(colonyID))
      return;
    if ((UnityEngine.Object) SaveGame.Instance != (UnityEngine.Object) null)
      RetireColonyUtility.SaveColonySummaryData();
    RetiredColonyInfoScreen.Instance.LoadColony(RetiredColonyInfoScreen.Instance.GetColonyDataByBaseName(colonyID));
  }

  public static void ActivateRetiredColoniesScreenFromData(
    GameObject parent,
    RetiredColonyData data)
  {
    if ((UnityEngine.Object) RetiredColonyInfoScreen.Instance == (UnityEngine.Object) null)
      Util.KInstantiateUI(ScreenPrefabs.Instance.RetiredColonyInfoScreen.gameObject, parent, true);
    RetiredColonyInfoScreen.Instance.Show(true);
    RetiredColonyInfoScreen.Instance.LoadColony(data);
  }

  public static void ActivateInventoyScreen()
  {
    LockerNavigator.Instance.PushScreen(LockerNavigator.Instance.kleiInventoryScreen);
  }

  public static void ActivateLockerMenu() => LockerMenuScreen.Instance.Show(true);

  private void SpawnVideoScreen()
  {
    VideoScreen.Instance = Util.KInstantiateUI(ScreenPrefabs.Instance.VideoScreen.gameObject, this.gameObject).GetComponent<VideoScreen>();
  }

  private void Update()
  {
  }

  public void RefreshResumeButton(bool simpleCheck = false)
  {
    string saveForCurrentDlc = SaveLoader.GetLatestSaveForCurrentDLC();
    bool flag = !string.IsNullOrEmpty(saveForCurrentDlc) && File.Exists(saveForCurrentDlc);
    if (flag)
    {
      try
      {
        if (GenericGameSettings.instance.demoMode)
          flag = false;
        System.DateTime lastWriteTime = File.GetLastWriteTime(saveForCurrentDlc);
        MainMenu.SaveFileEntry saveFileEntry1 = new MainMenu.SaveFileEntry();
        SaveGame.Header header = new SaveGame.Header();
        SaveGame.GameInfo gameInfo1 = new SaveGame.GameInfo();
        SaveGame.GameInfo gameInfo2;
        if (!this.saveFileEntries.TryGetValue(saveForCurrentDlc, out saveFileEntry1) || saveFileEntry1.timeStamp != lastWriteTime)
        {
          gameInfo2 = SaveLoader.LoadHeader(saveForCurrentDlc, out header);
          MainMenu.SaveFileEntry saveFileEntry2 = new MainMenu.SaveFileEntry()
          {
            timeStamp = lastWriteTime,
            header = header,
            headerData = gameInfo2
          };
          this.saveFileEntries[saveForCurrentDlc] = saveFileEntry2;
        }
        else
        {
          header = saveFileEntry1.header;
          gameInfo2 = saveFileEntry1.headerData;
        }
        if (header.buildVersion > 679336U || gameInfo2.saveMajorVersion != 7 || gameInfo2.saveMinorVersion > 36)
          flag = false;
        if (!gameInfo2.IsCompatableWithCurrentDlcConfiguration(out HashSet<string> _, out HashSet<string> _))
          flag = false;
        string withoutExtension = System.IO.Path.GetFileNameWithoutExtension(saveForCurrentDlc);
        if (!string.IsNullOrEmpty(gameInfo2.baseName))
          this.Button_ResumeGame.GetComponentsInChildren<LocText>()[1].text = string.Format((string) STRINGS.UI.FRONTEND.MAINMENU.RESUMEBUTTON_BASENAME, (object) gameInfo2.baseName, (object) (gameInfo2.numberOfCycles + 1));
        else
          this.Button_ResumeGame.GetComponentsInChildren<LocText>()[1].text = withoutExtension;
      }
      catch (Exception ex)
      {
        Debug.LogWarning((object) ex);
        flag = false;
      }
    }
    if ((UnityEngine.Object) this.Button_ResumeGame != (UnityEngine.Object) null && (UnityEngine.Object) this.Button_ResumeGame.gameObject != (UnityEngine.Object) null)
    {
      this.Button_ResumeGame.gameObject.SetActive(flag);
      KImage component = this.Button_NewGame.GetComponent<KImage>();
      component.colorStyleSetting = flag ? this.normalButtonStyle : this.topButtonStyle;
      component.ApplyColorStyleSetting();
    }
    else
      Debug.LogWarning((object) "Why is the resume game button null?");
  }

  private void Translations()
  {
    Util.KInstantiateUI<LanguageOptionsScreen>(ScreenPrefabs.Instance.languageOptionsScreen.gameObject, this.transform.parent.gameObject);
  }

  private void Mods()
  {
    Util.KInstantiateUI<ModsScreen>(ScreenPrefabs.Instance.modsMenu.gameObject, this.transform.parent.gameObject);
  }

  private void Options()
  {
    Util.KInstantiateUI<OptionsMenuScreen>(ScreenPrefabs.Instance.OptionsScreen.gameObject, this.gameObject, true);
  }

  private void QuitGame() => App.Quit();

  public void StartFEAudio()
  {
    AudioMixer.instance.Reset();
    MusicManager.instance.KillAllSongs(STOP_MODE.ALLOWFADEOUT);
    MusicManager.instance.ConfigureSongs();
    AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndSnapshot);
    if (!AudioMixer.instance.SnapshotIsActive(AudioMixerSnapshots.Get().UserVolumeSettingsSnapshot))
      AudioMixer.instance.StartUserVolumesSnapshot();
    if (AudioDebug.Get().musicEnabled && !MusicManager.instance.SongIsPlaying(this.menuMusicEventName))
      MusicManager.instance.PlaySong(this.menuMusicEventName);
    this.CheckForAudioDriverIssue();
  }

  public void StopAmbience()
  {
    if (!this.ambientLoop.isValid())
      return;
    int num1 = (int) this.ambientLoop.stop(STOP_MODE.ALLOWFADEOUT);
    int num2 = (int) this.ambientLoop.release();
    this.ambientLoop.clearHandle();
  }

  public void StopMainMenuMusic()
  {
    if (!MusicManager.instance.SongIsPlaying(this.menuMusicEventName))
      return;
    MusicManager.instance.StopSong(this.menuMusicEventName);
    AudioMixer.instance.Stop(AudioMixerSnapshots.Get().FrontEndSnapshot);
  }

  private void CheckForAudioDriverIssue()
  {
    if (KFMOD.didFmodInitializeSuccessfully)
      return;
    Util.KInstantiateUI<ConfirmDialogScreen>(ScreenPrefabs.Instance.ConfirmDialogScreen.gameObject, this.gameObject, true).PopupConfirmDialog((string) STRINGS.UI.FRONTEND.SUPPORTWARNINGS.AUDIO_DRIVERS, (System.Action) null, (System.Action) null, (string) STRINGS.UI.FRONTEND.SUPPORTWARNINGS.AUDIO_DRIVERS_MORE_INFO, (System.Action) (() => App.OpenWebURL("http://support.kleientertainment.com/customer/en/portal/articles/2947881-no-audio-when-playing-oxygen-not-included")), image_sprite: GlobalResources.Instance().sadDupeAudio);
  }

  private void CheckPlayerPrefsCorruption()
  {
    if (!KPlayerPrefs.HasCorruptedFlag())
      return;
    KPlayerPrefs.ResetCorruptedFlag();
    Util.KInstantiateUI<ConfirmDialogScreen>(ScreenPrefabs.Instance.ConfirmDialogScreen.gameObject, this.gameObject, true).PopupConfirmDialog((string) STRINGS.UI.FRONTEND.SUPPORTWARNINGS.PLAYER_PREFS_CORRUPTED, (System.Action) null, (System.Action) null, image_sprite: GlobalResources.Instance().sadDupe);
  }

  private void CheckDoubleBoundKeys()
  {
    string str = "";
    HashSet<BindingEntry> bindingEntrySet = new HashSet<BindingEntry>();
    for (int index1 = 0; index1 < GameInputMapping.KeyBindings.Length; ++index1)
    {
      if (GameInputMapping.KeyBindings[index1].mKeyCode != KKeyCode.Mouse1)
      {
        for (int index2 = 0; index2 < GameInputMapping.KeyBindings.Length; ++index2)
        {
          if (index1 != index2)
          {
            BindingEntry keyBinding1 = GameInputMapping.KeyBindings[index2];
            if (!bindingEntrySet.Contains(keyBinding1))
            {
              BindingEntry keyBinding2 = GameInputMapping.KeyBindings[index1];
              if (keyBinding2.mKeyCode != KKeyCode.None && keyBinding2.mKeyCode == keyBinding1.mKeyCode && keyBinding2.mModifier == keyBinding1.mModifier && keyBinding2.mRebindable && keyBinding1.mRebindable)
              {
                string mGroup1 = GameInputMapping.KeyBindings[index1].mGroup;
                string mGroup2 = GameInputMapping.KeyBindings[index2].mGroup;
                if ((mGroup1 == "Root" || mGroup2 == "Root" || mGroup1 == mGroup2) && (!(mGroup1 == "Root") || !keyBinding1.mIgnoreRootConflics) && (!(mGroup2 == "Root") || !keyBinding2.mIgnoreRootConflics))
                {
                  str = $"{str}\n\n{keyBinding2.mAction.ToString()}: <b>{keyBinding2.mKeyCode.ToString()}</b>\n{keyBinding1.mAction.ToString()}: <b>{keyBinding1.mKeyCode.ToString()}</b>";
                  BindingEntry bindingEntry1 = keyBinding2 with
                  {
                    mKeyCode = KKeyCode.None,
                    mModifier = Modifier.None
                  };
                  GameInputMapping.KeyBindings[index1] = bindingEntry1;
                  BindingEntry bindingEntry2 = keyBinding1 with
                  {
                    mKeyCode = KKeyCode.None,
                    mModifier = Modifier.None
                  };
                  GameInputMapping.KeyBindings[index2] = bindingEntry2;
                }
              }
            }
          }
        }
        bindingEntrySet.Add(GameInputMapping.KeyBindings[index1]);
      }
    }
    if (!(str != ""))
      return;
    Util.KInstantiateUI<ConfirmDialogScreen>(ScreenPrefabs.Instance.ConfirmDialogScreen.gameObject, this.gameObject, true).PopupConfirmDialog(string.Format((string) STRINGS.UI.FRONTEND.SUPPORTWARNINGS.DUPLICATE_KEY_BINDINGS, (object) str), (System.Action) null, (System.Action) null, image_sprite: GlobalResources.Instance().sadDupe);
  }

  private void RestartGame() => App.instance.Restart();

  private struct ButtonInfo(LocString text, System.Action action, int font_size, ColorStyleSetting style)
  {
    public LocString text = text;
    public System.Action action = action;
    public int fontSize = font_size;
    public ColorStyleSetting style = style;
  }

  private struct SaveFileEntry
  {
    public System.DateTime timeStamp;
    public SaveGame.Header header;
    public SaveGame.GameInfo headerData;
  }
}
