// Decompiled with JetBrains decompiler
// Type: MinionSelectScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.CustomSettings;
using ProcGen;
using STRINGS;
using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class MinionSelectScreen : CharacterSelectionController
{
  [SerializeField]
  private NewBaseScreen newBasePrefab;
  [SerializeField]
  private WattsonMessage wattsonMessagePrefab;
  public const string WattsonGameObjName = "WattsonMessage";
  public KButton backButton;

  protected override void OnPrefabInit()
  {
    this.IsStarterMinion = true;
    base.OnPrefabInit();
    if (MusicManager.instance.SongIsPlaying("Music_FrontEnd"))
      MusicManager.instance.SetSongParameter("Music_FrontEnd", "songSection", 2f);
    GameObject gameObject = Util.KInstantiateUI(this.wattsonMessagePrefab.gameObject, GameObject.Find("ScreenSpaceOverlayCanvas"));
    gameObject.name = "WattsonMessage";
    gameObject.SetActive(false);
    Game.Instance.Subscribe(-1992507039, new Action<object>(this.OnBaseAlreadyCreated));
    this.backButton.onClick += (System.Action) (() =>
    {
      LoadScreen.ForceStopGame();
      App.LoadScene("frontend");
    });
    this.InitializeContainers();
    this.StartCoroutine(this.SetDefaultMinionsRoutine());
  }

  private IEnumerator SetDefaultMinionsRoutine()
  {
    MinionSelectScreen minionSelectScreen = this;
    yield return (object) SequenceUtil.WaitForNextFrame;
    SettingLevel currentQualitySetting = CustomGameSettings.Instance.GetCurrentQualitySetting((SettingConfig) CustomGameSettingConfigs.ClusterLayout);
    ClusterLayout clusterData = SettingsCache.clusterLayouts.GetClusterData(currentQualitySetting.id);
    bool flag1 = clusterData.clusterTags.Contains("CeresCluster");
    bool flag2 = clusterData.clusterTags.Contains("PrehistoricCluster");
    if (flag1)
    {
      ((CharacterContainer) minionSelectScreen.containers[2]).SetMinion(new MinionStartingStats(Db.Get().Personalities.Get("FREYJA")));
      ((CharacterContainer) minionSelectScreen.containers[1]).GenerateCharacter(true);
      ((CharacterContainer) minionSelectScreen.containers[0]).GenerateCharacter(true);
    }
    else if (flag2)
    {
      ((CharacterContainer) minionSelectScreen.containers[2]).SetMinion(new MinionStartingStats(Db.Get().Personalities.Get("MAYA")));
      ((CharacterContainer) minionSelectScreen.containers[1]).SetMinion(new MinionStartingStats(Db.Get().Personalities.Get("HIGBY")));
      ((CharacterContainer) minionSelectScreen.containers[0]).GenerateCharacter(true);
    }
  }

  public void SetProceedButtonActive(bool state, string tooltip = null)
  {
    if (state)
      this.EnableProceedButton();
    else
      this.DisableProceedButton();
    ToolTip component = this.proceedButton.GetComponent<ToolTip>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    if (tooltip != null)
      component.toolTip = tooltip;
    else
      component.ClearMultiStringTooltip();
  }

  protected override void OnSpawn()
  {
    this.OnDeliverableAdded();
    this.EnableProceedButton();
    this.proceedButton.GetComponentInChildren<LocText>().text = (string) UI.IMMIGRANTSCREEN.EMBARK;
    this.containers.ForEach((Action<ITelepadDeliverableContainer>) (container =>
    {
      CharacterContainer characterContainer = container as CharacterContainer;
      if (!((UnityEngine.Object) characterContainer != (UnityEngine.Object) null))
        return;
      characterContainer.DisableSelectButton();
    }));
  }

  protected override void OnProceed()
  {
    Util.KInstantiateUI(this.newBasePrefab.gameObject, GameScreenManager.Instance.ssOverlayCanvas);
    MusicManager.instance.StopSong("Music_FrontEnd");
    AudioMixer.instance.Start(AudioMixerSnapshots.Get().NewBaseSetupSnapshot);
    AudioMixer.instance.Stop(AudioMixerSnapshots.Get().FrontEndWorldGenerationSnapshot);
    int num = 0;
    this.selectedDeliverables.Clear();
    foreach (CharacterContainer container in this.containers)
    {
      this.selectedDeliverables.Add((ITelepadDeliverable) container.Stats);
      if (container.Stats.personality.model == BionicMinionConfig.MODEL)
        ++num;
    }
    NewBaseScreen.Instance.Init(SaveLoader.Instance.Cluster, this.selectedDeliverables.ToArray());
    if (this.OnProceedEvent != null)
      this.OnProceedEvent();
    if (Game.IsDlcActiveForCurrentSave("DLC3_ID") && Components.RoleStations.Count > 0)
    {
      BuildingFacade component = Components.RoleStations[0].GetComponent<BuildingFacade>();
      bool flag = !component.IsOriginal;
      if (num == 3 || !flag && num > 0)
        component.ApplyBuildingFacade(Db.GetBuildingFacades().Get("permit_hqbase_cyberpunk"));
    }
    Game.Instance.Trigger(-838649377, (object) null);
    BuildWatermark.Instance.gameObject.SetActive(false);
    this.Deactivate();
  }

  private void OnBaseAlreadyCreated(object data)
  {
    Game.Instance.StopFE();
    Game.Instance.StartBE();
    Game.Instance.SetGameStarted();
    this.Deactivate();
  }

  private void ReshuffleAll()
  {
    if (this.OnReshuffleEvent == null)
      return;
    this.OnReshuffleEvent(this.IsStarterMinion);
  }

  public override void OnPressBack()
  {
    foreach (ITelepadDeliverableContainer container in this.containers)
    {
      CharacterContainer characterContainer = container as CharacterContainer;
      if ((UnityEngine.Object) characterContainer != (UnityEngine.Object) null)
        characterContainer.ForceStopEditingTitle();
    }
  }
}
