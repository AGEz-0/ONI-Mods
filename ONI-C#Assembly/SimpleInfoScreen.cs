﻿// Decompiled with JetBrains decompiler
// Type: SimpleInfoScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using ProcGen;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class SimpleInfoScreen : DetailScreenTab, ISim4000ms, ISim1000ms
{
  public GameObject iconLabelRow;
  public GameObject spacerRow;
  [SerializeField]
  private GameObject attributesLabelTemplate;
  [SerializeField]
  private GameObject attributesLabelButtonTemplate;
  [SerializeField]
  private DescriptorPanel DescriptorContentPrefab;
  [SerializeField]
  private GameObject VitalsPanelTemplate;
  [SerializeField]
  private GameObject StatusItemPrefab;
  [SerializeField]
  private Sprite statusWarningIcon;
  [SerializeField]
  private HierarchyReferences processConditionHeader;
  [SerializeField]
  private GameObject processConditionRow;
  [SerializeField]
  private Text StatusPanelCurrentActionLabel;
  [SerializeField]
  private GameObject bigIconLabelRow;
  [SerializeField]
  private TextStyleSetting ToolTipStyle_Property;
  [SerializeField]
  private TextStyleSetting StatusItemStyle_Main;
  [SerializeField]
  private TextStyleSetting StatusItemStyle_Other;
  [SerializeField]
  private Color statusItemTextColor_regular = Color.black;
  [SerializeField]
  private Color statusItemTextColor_old = new Color(0.8235294f, 0.8235294f, 0.8235294f);
  private CollapsibleDetailContentPanel statusItemPanel;
  private MinionVitalsPanel vitalsPanel;
  private CollapsibleDetailContentPanel fertilityPanel;
  private CollapsibleDetailContentPanel rocketStatusContainer;
  private CollapsibleDetailContentPanel worldLifePanel;
  private CollapsibleDetailContentPanel worldElementsPanel;
  private CollapsibleDetailContentPanel worldBiomesPanel;
  private CollapsibleDetailContentPanel worldGeysersPanel;
  private CollapsibleDetailContentPanel worldMeteorShowersPanel;
  private CollapsibleDetailContentPanel spacePOIPanel;
  private CollapsibleDetailContentPanel worldTraitsPanel;
  private CollapsibleDetailContentPanel processConditionContainer;
  private CollapsibleDetailContentPanel requirementsPanel;
  private CollapsibleDetailContentPanel effectsPanel;
  private CollapsibleDetailContentPanel stressPanel;
  private CollapsibleDetailContentPanel infoPanel;
  private CollapsibleDetailContentPanel movePanel;
  private DescriptorPanel effectsContent;
  private DescriptorPanel requirementContent;
  private RocketSimpleInfoPanel rocketSimpleInfoPanel;
  private SpacePOISimpleInfoPanel spaceSimpleInfoPOIPanel;
  private DetailsPanelDrawer stressDrawer;
  private bool TargetIsMinion;
  private GameObject lastTarget;
  private GameObject statusItemsFolder;
  private Dictionary<Tag, GameObject> lifeformRows = new Dictionary<Tag, GameObject>();
  private Dictionary<Tag, GameObject> biomeRows = new Dictionary<Tag, GameObject>();
  private Dictionary<Tag, GameObject> geyserRows = new Dictionary<Tag, GameObject>();
  private Dictionary<Tag, GameObject> meteorShowerRows = new Dictionary<Tag, GameObject>();
  private List<GameObject> worldTraitRows = new List<GameObject>();
  private List<GameObject> surfaceConditionRows = new List<GameObject>();
  private List<SimpleInfoScreen.StatusItemEntry> statusItems = new List<SimpleInfoScreen.StatusItemEntry>();
  private List<SimpleInfoScreen.StatusItemEntry> oldStatusItems = new List<SimpleInfoScreen.StatusItemEntry>();
  private List<GameObject> processConditionRows = new List<GameObject>();
  private static readonly EventSystem.IntraObjectHandler<SimpleInfoScreen> OnRefreshDataDelegate = new EventSystem.IntraObjectHandler<SimpleInfoScreen>((Action<SimpleInfoScreen, object>) ((component, data) => component.OnRefreshData(data)));

  public CollapsibleDetailContentPanel StoragePanel { get; private set; }

  public override bool IsValidForTarget(GameObject target) => true;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.processConditionContainer = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.PROCESS_CONDITIONS.NAME);
    this.statusItemPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_STATUS);
    this.statusItemPanel.Content.GetComponent<VerticalLayoutGroup>().padding.bottom = 10;
    this.statusItemPanel.scalerMask.hoverLock = true;
    this.statusItemsFolder = this.statusItemPanel.Content.gameObject;
    this.spaceSimpleInfoPOIPanel = new SpacePOISimpleInfoPanel(this);
    this.spacePOIPanel = this.CreateCollapsableSection();
    this.rocketSimpleInfoPanel = new RocketSimpleInfoPanel(this);
    this.rocketStatusContainer = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_ROCKET);
    this.vitalsPanel = Util.KInstantiateUI(this.VitalsPanelTemplate, this.gameObject).GetComponent<MinionVitalsPanel>();
    this.fertilityPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_FERTILITY);
    this.infoPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_DESCRIPTION);
    this.requirementsPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_REQUIREMENTS);
    this.requirementContent = Util.KInstantiateUI<DescriptorPanel>(this.DescriptorContentPrefab.gameObject, this.requirementsPanel.Content.gameObject);
    this.effectsPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_EFFECTS);
    this.effectsContent = Util.KInstantiateUI<DescriptorPanel>(this.DescriptorContentPrefab.gameObject, this.effectsPanel.Content.gameObject);
    this.worldMeteorShowersPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_METEORSHOWERS);
    this.worldElementsPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_ELEMENTS);
    this.worldGeysersPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_GEYSERS);
    this.worldTraitsPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_WORLDTRAITS);
    this.worldBiomesPanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_BIOMES);
    this.worldLifePanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_LIFE);
    this.StoragePanel = this.CreateCollapsableSection();
    this.stressPanel = this.CreateCollapsableSection();
    this.stressDrawer = new DetailsPanelDrawer(this.attributesLabelTemplate, this.stressPanel.Content.gameObject);
    this.movePanel = this.CreateCollapsableSection((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.GROUPNAME_MOVABLE);
    this.Subscribe<SimpleInfoScreen>(-1514841199, SimpleInfoScreen.OnRefreshDataDelegate);
  }

  protected override void OnSelectTarget(GameObject target)
  {
    base.OnSelectTarget(target);
    this.Subscribe(target, -1697596308, new Action<object>(this.TriggerRefreshStorage));
    this.Subscribe(target, -1197125120, new Action<object>(this.TriggerRefreshStorage));
    this.Subscribe(target, 1059811075, new Action<object>(this.OnBreedingChanceChanged));
    KSelectable component = target.GetComponent<KSelectable>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
    {
      StatusItemGroup statusItemGroup = component.GetStatusItemGroup();
      if (statusItemGroup != null)
      {
        statusItemGroup.OnAddStatusItem += new Action<StatusItemGroup.Entry, StatusItemCategory>(this.OnAddStatusItem);
        statusItemGroup.OnRemoveStatusItem += new Action<StatusItemGroup.Entry, bool>(this.OnRemoveStatusItem);
        foreach (StatusItemGroup.Entry status_item in statusItemGroup)
        {
          if (status_item.category != null && status_item.category.Id == "Main")
            this.DoAddStatusItem(status_item, status_item.category);
        }
        foreach (StatusItemGroup.Entry status_item in statusItemGroup)
        {
          if (status_item.category == null || status_item.category.Id != "Main")
            this.DoAddStatusItem(status_item, status_item.category);
        }
      }
    }
    this.statusItemPanel.gameObject.SetActive(true);
    this.statusItemPanel.scalerMask.UpdateSize();
    this.Refresh(true);
    this.RefreshWorldPanel();
    this.RefreshProcessConditionsPanel();
    this.spaceSimpleInfoPOIPanel.Refresh(this.spacePOIPanel, this.selectedTarget);
  }

  public override void OnDeselectTarget(GameObject target)
  {
    base.OnDeselectTarget(target);
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      this.Unsubscribe(target, -1697596308, new Action<object>(this.TriggerRefreshStorage));
      this.Unsubscribe(target, -1197125120, new Action<object>(this.TriggerRefreshStorage));
      this.Unsubscribe(target, 1059811075, new Action<object>(this.OnBreedingChanceChanged));
    }
    KSelectable component = target.GetComponent<KSelectable>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    StatusItemGroup statusItemGroup = component.GetStatusItemGroup();
    if (statusItemGroup == null)
      return;
    statusItemGroup.OnAddStatusItem -= new Action<StatusItemGroup.Entry, StatusItemCategory>(this.OnAddStatusItem);
    statusItemGroup.OnRemoveStatusItem -= new Action<StatusItemGroup.Entry, bool>(this.OnRemoveStatusItem);
    foreach (SimpleInfoScreen.StatusItemEntry statusItem in this.statusItems)
      statusItem.Destroy(true);
    this.statusItems.Clear();
    foreach (SimpleInfoScreen.StatusItemEntry oldStatusItem in this.oldStatusItems)
    {
      oldStatusItem.onDestroy = (Action<SimpleInfoScreen.StatusItemEntry>) null;
      oldStatusItem.Destroy(true);
    }
    this.oldStatusItems.Clear();
  }

  private void OnStorageChange(object data)
  {
    SimpleInfoScreen.RefreshStoragePanel(this.StoragePanel, this.selectedTarget);
  }

  private void OnBreedingChanceChanged(object data)
  {
    SimpleInfoScreen.RefreshFertilityPanel(this.fertilityPanel, this.selectedTarget);
  }

  private void OnAddStatusItem(StatusItemGroup.Entry status_item, StatusItemCategory category)
  {
    this.DoAddStatusItem(status_item, category);
  }

  private void DoAddStatusItem(
    StatusItemGroup.Entry status_item,
    StatusItemCategory category,
    bool show_immediate = false)
  {
    GameObject statusItemsFolder = this.statusItemsFolder;
    Color color = status_item.item.notificationType == NotificationType.BadMinor || status_item.item.notificationType == NotificationType.Bad || status_item.item.notificationType == NotificationType.DuplicantThreatening ? (Color) GlobalAssets.Instance.colorSet.statusItemBad : (status_item.item.notificationType != NotificationType.Event ? (status_item.item.notificationType != NotificationType.MessageImportant ? this.statusItemTextColor_regular : (Color) GlobalAssets.Instance.colorSet.statusItemMessageImportant) : (Color) GlobalAssets.Instance.colorSet.statusItemEvent);
    TextStyleSetting style = category == Db.Get().StatusItemCategories.Main ? this.StatusItemStyle_Main : this.StatusItemStyle_Other;
    SimpleInfoScreen.StatusItemEntry statusItemEntry1 = new SimpleInfoScreen.StatusItemEntry(status_item, category, this.StatusItemPrefab, statusItemsFolder.transform, this.ToolTipStyle_Property, color, style, show_immediate, new Action<SimpleInfoScreen.StatusItemEntry>(this.OnStatusItemDestroy));
    statusItemEntry1.SetSprite(status_item.item.sprite);
    if (category != null)
    {
      int index = -1;
      foreach (SimpleInfoScreen.StatusItemEntry statusItemEntry2 in this.oldStatusItems.FindAll((Predicate<SimpleInfoScreen.StatusItemEntry>) (e => e.category == category)))
      {
        index = statusItemEntry2.GetIndex();
        statusItemEntry2.Destroy(true);
        this.oldStatusItems.Remove(statusItemEntry2);
      }
      if (category == Db.Get().StatusItemCategories.Main)
        index = 0;
      if (index != -1)
        statusItemEntry1.SetIndex(index);
    }
    this.statusItems.Add(statusItemEntry1);
  }

  private void OnRemoveStatusItem(StatusItemGroup.Entry status_item, bool immediate = false)
  {
    this.DoRemoveStatusItem(status_item, immediate);
  }

  private void DoRemoveStatusItem(StatusItemGroup.Entry status_item, bool destroy_immediate = false)
  {
    for (int index = 0; index < this.statusItems.Count; ++index)
    {
      if (this.statusItems[index].item.item == status_item.item)
      {
        SimpleInfoScreen.StatusItemEntry statusItem = this.statusItems[index];
        this.statusItems.RemoveAt(index);
        this.oldStatusItems.Add(statusItem);
        statusItem.Destroy(destroy_immediate);
        break;
      }
    }
  }

  private void OnStatusItemDestroy(SimpleInfoScreen.StatusItemEntry item)
  {
    this.oldStatusItems.Remove(item);
  }

  private void OnRefreshData(object obj) => this.Refresh(false);

  protected override void Refresh(bool force = false)
  {
    if ((UnityEngine.Object) this.selectedTarget != (UnityEngine.Object) this.lastTarget || force)
      this.lastTarget = this.selectedTarget;
    int count = this.statusItems.Count;
    this.statusItemPanel.gameObject.SetActive(count > 0);
    for (int index = 0; index < count; ++index)
      this.statusItems[index].Refresh();
    SimpleInfoScreen.RefreshStressPanel(this.stressPanel, this.selectedTarget);
    SimpleInfoScreen.RefreshStoragePanel(this.StoragePanel, this.selectedTarget);
    SimpleInfoScreen.RefreshMovePanel(this.movePanel, this.selectedTarget);
    SimpleInfoScreen.RefreshFertilityPanel(this.fertilityPanel, this.selectedTarget);
    SimpleInfoScreen.RefreshEffectsPanel(this.effectsPanel, this.selectedTarget, this.effectsContent);
    SimpleInfoScreen.RefreshRequirementsPanel(this.requirementsPanel, this.selectedTarget, this.requirementContent);
    SimpleInfoScreen.RefreshInfoPanel(this.infoPanel, this.selectedTarget);
    this.vitalsPanel.Refresh(this.selectedTarget);
    this.rocketSimpleInfoPanel.Refresh(this.rocketStatusContainer, this.selectedTarget);
  }

  public void Sim1000ms(float dt)
  {
    if (!((UnityEngine.Object) this.selectedTarget != (UnityEngine.Object) null) || this.selectedTarget.GetComponent<IProcessConditionSet>() == null)
      return;
    this.RefreshProcessConditionsPanel();
  }

  public void Sim4000ms(float dt)
  {
    this.RefreshWorldPanel();
    this.spaceSimpleInfoPOIPanel.Refresh(this.spacePOIPanel, this.selectedTarget);
  }

  private static void RefreshInfoPanel(
    CollapsibleDetailContentPanel targetPanel,
    GameObject targetEntity)
  {
    string text1 = "";
    string str1 = "";
    MinionIdentity component1 = targetEntity.GetComponent<MinionIdentity>();
    InfoDescription component2 = targetEntity.GetComponent<InfoDescription>();
    BuildingComplete component3 = targetEntity.GetComponent<BuildingComplete>();
    BuildingUnderConstruction component4 = targetEntity.GetComponent<BuildingUnderConstruction>();
    Edible component5 = targetEntity.GetComponent<Edible>();
    PrimaryElement component6 = targetEntity.GetComponent<PrimaryElement>();
    CellSelectionObject component7 = targetEntity.GetComponent<CellSelectionObject>();
    if (!(bool) (UnityEngine.Object) component1)
    {
      if ((bool) (UnityEngine.Object) component2)
      {
        text1 = component2.description;
        str1 = component2.effect;
      }
      else if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
        text1 = $"{component3.DescEffect}\n\n{component3.Desc}";
      else if ((UnityEngine.Object) component4 != (UnityEngine.Object) null)
        text1 = $"{component4.DescEffect}\n\n{component4.Desc}";
      else if ((UnityEngine.Object) component5 != (UnityEngine.Object) null)
      {
        EdiblesManager.FoodInfo foodInfo = component5.FoodInfo;
        text1 += string.Format((string) STRINGS.UI.GAMEOBJECTEFFECTS.CALORIES, (object) GameUtil.GetFormattedCalories(foodInfo.CaloriesPerUnit));
      }
      else if ((UnityEngine.Object) component7 != (UnityEngine.Object) null)
        text1 = component7.element.FullDescription(false);
      else if ((UnityEngine.Object) component6 != (UnityEngine.Object) null)
      {
        Element elementByHash = ElementLoader.FindElementByHash(component6.ElementID);
        text1 = elementByHash != null ? elementByHash.FullDescription(false) : "";
      }
      if (!string.IsNullOrEmpty(text1))
        targetPanel.SetLabel("Description", text1, "");
      int num = string.IsNullOrEmpty(str1) ? 0 : (str1 != "\n" ? 1 : 0);
      string text2 = "\n" + str1;
      if (num != 0)
        targetPanel.SetLabel("Flavour", text2, "");
      string[] roomClassForObject = CodexEntryGenerator.GetRoomClassForObject(targetEntity);
      if (roomClassForObject != null)
      {
        string text3 = $"\n{(string) CODEX.HEADERS.BUILDINGTYPE}:";
        for (int index = 0; index < roomClassForObject.Length; ++index)
        {
          string str2 = roomClassForObject[index];
          text3 = $"{text3}\n    • {str2}";
        }
        targetPanel.SetLabel("RoomClass", text3, "");
      }
    }
    targetPanel.Commit();
  }

  private static void RefreshEffectsPanel(
    CollapsibleDetailContentPanel targetPanel,
    GameObject targetEntity,
    DescriptorPanel effectsContent)
  {
    if ((UnityEngine.Object) targetEntity.GetComponent<MinionIdentity>() != (UnityEngine.Object) null)
    {
      targetPanel.SetActive(false);
    }
    else
    {
      targetEntity.GetComponent<BuildingComplete>();
      BuildingUnderConstruction component = targetEntity.GetComponent<BuildingUnderConstruction>();
      List<Descriptor> gameObjectEffects = GameUtil.GetGameObjectEffects((bool) (UnityEngine.Object) component ? component.Def.BuildingComplete : targetEntity, true);
      bool flag = gameObjectEffects.Count > 0;
      effectsContent.gameObject.SetActive(flag);
      if (flag)
        effectsContent.SetDescriptors((IList<Descriptor>) gameObjectEffects);
      targetPanel.SetActive((UnityEngine.Object) targetEntity != (UnityEngine.Object) null & flag);
    }
  }

  private static void RefreshRequirementsPanel(
    CollapsibleDetailContentPanel targetPanel,
    GameObject targetEntity,
    DescriptorPanel requirementContent)
  {
    MinionIdentity component1 = targetEntity.GetComponent<MinionIdentity>();
    WiltCondition component2 = targetEntity.GetComponent<WiltCondition>();
    CreatureBrain component3 = targetEntity.GetComponent<CreatureBrain>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null || (UnityEngine.Object) component1 != (UnityEngine.Object) null || (UnityEngine.Object) component3 != (UnityEngine.Object) null)
    {
      targetPanel.SetActive(false);
    }
    else
    {
      targetPanel.SetActive(true);
      BuildingUnderConstruction component4 = targetEntity.GetComponent<BuildingUnderConstruction>();
      List<Descriptor> requirementDescriptors = GameUtil.GetRequirementDescriptors(GameUtil.GetAllDescriptors((bool) (UnityEngine.Object) component4 ? component4.Def.BuildingComplete : targetEntity, true), false);
      bool active = requirementDescriptors.Count > 0;
      requirementContent.gameObject.SetActive(active);
      if (active)
        requirementContent.SetDescriptors((IList<Descriptor>) requirementDescriptors);
      targetPanel.SetActive(active);
    }
  }

  private static void RefreshFertilityPanel(
    CollapsibleDetailContentPanel targetPanel,
    GameObject targetEntity)
  {
    FertilityMonitor.Instance smi = targetEntity.GetSMI<FertilityMonitor.Instance>();
    if (smi != null)
    {
      int num = 0;
      foreach (FertilityMonitor.BreedingChance breedingChance in smi.breedingChances)
      {
        List<FertilityModifier> forTag = Db.Get().FertilityModifiers.GetForTag(breedingChance.egg);
        if (forTag.Count > 0)
        {
          string str = "";
          foreach (FertilityModifier fertilityModifier in forTag)
            str += string.Format((string) STRINGS.UI.DETAILTABS.EGG_CHANCES.CHANCE_MOD_FORMAT, (object) fertilityModifier.GetTooltip());
          targetPanel.SetLabel("breeding_" + num++.ToString(), string.Format((string) STRINGS.UI.DETAILTABS.EGG_CHANCES.CHANCE_FORMAT, (object) breedingChance.egg.ProperName(), (object) GameUtil.GetFormattedPercent(breedingChance.weight * 100f)), string.Format((string) STRINGS.UI.DETAILTABS.EGG_CHANCES.CHANCE_FORMAT_TOOLTIP, (object) breedingChance.egg.ProperName(), (object) GameUtil.GetFormattedPercent(breedingChance.weight * 100f), (object) str));
        }
        else
          targetPanel.SetLabel("breeding_" + num++.ToString(), string.Format((string) STRINGS.UI.DETAILTABS.EGG_CHANCES.CHANCE_FORMAT, (object) breedingChance.egg.ProperName(), (object) GameUtil.GetFormattedPercent(breedingChance.weight * 100f)), string.Format((string) STRINGS.UI.DETAILTABS.EGG_CHANCES.CHANCE_FORMAT_TOOLTIP_NOMOD, (object) breedingChance.egg.ProperName(), (object) GameUtil.GetFormattedPercent(breedingChance.weight * 100f)));
      }
    }
    targetPanel.Commit();
  }

  private void TriggerRefreshStorage(object data = null)
  {
    SimpleInfoScreen.RefreshStoragePanel(this.StoragePanel, this.selectedTarget);
  }

  private static void RefreshStoragePanel(
    CollapsibleDetailContentPanel targetPanel,
    GameObject targetEntity)
  {
    if ((UnityEngine.Object) targetEntity == (UnityEngine.Object) null)
    {
      targetPanel.gameObject.SetActive(false);
      targetPanel.Commit();
    }
    else
    {
      IStorage[] componentsInChildren = targetEntity.GetComponentsInChildren<IStorage>();
      if (componentsInChildren == null)
      {
        targetPanel.gameObject.SetActive(false);
        targetPanel.Commit();
      }
      else
      {
        IStorage[] all = Array.FindAll<IStorage>(componentsInChildren, (Predicate<IStorage>) (n => n.ShouldShowInUI()));
        if (all.Length == 0)
        {
          targetPanel.gameObject.SetActive(false);
          targetPanel.Commit();
        }
        else
        {
          string title = (string) ((UnityEngine.Object) targetEntity.GetComponent<MinionIdentity>() != (UnityEngine.Object) null ? STRINGS.UI.DETAILTABS.DETAILS.GROUPNAME_MINION_CONTENTS : STRINGS.UI.DETAILTABS.DETAILS.GROUPNAME_CONTENTS);
          targetPanel.gameObject.SetActive(true);
          targetPanel.SetTitle(title);
          int num = 0;
          foreach (IStorage storage in all)
          {
            foreach (GameObject gameObject in storage.GetItems())
            {
              GameObject go = gameObject;
              if (!((UnityEngine.Object) go == (UnityEngine.Object) null))
              {
                PrimaryElement component1 = go.GetComponent<PrimaryElement>();
                if (!((UnityEngine.Object) component1 != (UnityEngine.Object) null) || (double) component1.Mass != 0.0)
                {
                  Rottable.Instance smi = go.GetSMI<Rottable.Instance>();
                  HighEnergyParticleStorage component2 = go.GetComponent<HighEnergyParticleStorage>();
                  string text = "";
                  string tooltip = "";
                  if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && (UnityEngine.Object) component2 == (UnityEngine.Object) null)
                  {
                    string unitFormattedName = GameUtil.GetUnitFormattedName(go);
                    string str = string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_MASS, (object) unitFormattedName, (object) GameUtil.GetFormattedMass(component1.Mass));
                    text = string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_TEMPERATURE, (object) str, (object) GameUtil.GetFormattedTemperature(component1.Temperature));
                  }
                  if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
                  {
                    string name = (string) ITEMS.RADIATION.HIGHENERGYPARITCLE.NAME;
                    text = string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_MASS, (object) name, (object) GameUtil.GetFormattedHighEnergyParticles(component2.Particles));
                  }
                  if (smi != null)
                  {
                    string str = smi.StateString();
                    if (!string.IsNullOrEmpty(str))
                      text += string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_ROTTABLE, (object) str);
                    tooltip += smi.GetToolTip();
                  }
                  if (component1.DiseaseIdx != byte.MaxValue)
                  {
                    text += string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_DISEASED, (object) GameUtil.GetFormattedDisease(component1.DiseaseIdx, component1.DiseaseCount));
                    tooltip += GameUtil.GetFormattedDisease(component1.DiseaseIdx, component1.DiseaseCount, true);
                  }
                  targetPanel.SetLabelWithButton("storage_" + num.ToString(), text, tooltip, (System.Action) (() => SelectTool.Instance.Select(go.GetComponent<KSelectable>())));
                  ++num;
                }
              }
            }
          }
          if (num == 0)
            targetPanel.SetLabel("storage_empty", (string) STRINGS.UI.DETAILTABS.DETAILS.STORAGE_EMPTY, "");
          targetPanel.Commit();
        }
      }
    }
  }

  private void CreateWorldTraitRow()
  {
    GameObject gameObject = Util.KInstantiateUI(this.iconLabelRow, this.worldTraitsPanel.Content.gameObject, true);
    this.worldTraitRows.Add(gameObject);
    HierarchyReferences component = gameObject.GetComponent<HierarchyReferences>();
    component.GetReference<Image>("Icon").gameObject.SetActive(false);
    component.GetReference<LocText>("ValueLabel").gameObject.SetActive(false);
  }

  private static void RefreshMovePanel(
    CollapsibleDetailContentPanel targetPanel,
    GameObject targetEntity)
  {
    CancellableMove component1 = targetEntity.GetComponent<CancellableMove>();
    Movable moving = targetEntity.GetComponent<Movable>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
    {
      List<Ref<Movable>> movingObjects = component1.movingObjects;
      int num = 0;
      foreach (Ref<Movable> @ref in movingObjects)
      {
        Movable movable = @ref.Get();
        GameObject go = (UnityEngine.Object) movable != (UnityEngine.Object) null ? movable.gameObject : (GameObject) null;
        if (!((UnityEngine.Object) go == (UnityEngine.Object) null))
        {
          PrimaryElement component2 = go.GetComponent<PrimaryElement>();
          if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null) || (double) component2.Mass != 0.0)
          {
            Rottable.Instance smi = go.GetSMI<Rottable.Instance>();
            HighEnergyParticleStorage component3 = go.GetComponent<HighEnergyParticleStorage>();
            string text = "";
            string tooltip = "";
            if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && (UnityEngine.Object) component3 == (UnityEngine.Object) null)
            {
              string unitFormattedName = GameUtil.GetUnitFormattedName(go);
              string str = string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_MASS, (object) unitFormattedName, (object) GameUtil.GetFormattedMass(component2.Mass));
              text = string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_TEMPERATURE, (object) str, (object) GameUtil.GetFormattedTemperature(component2.Temperature));
            }
            if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
            {
              string name = (string) ITEMS.RADIATION.HIGHENERGYPARITCLE.NAME;
              text = string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_MASS, (object) name, (object) GameUtil.GetFormattedHighEnergyParticles(component3.Particles));
            }
            if (smi != null)
            {
              string str = smi.StateString();
              if (!string.IsNullOrEmpty(str))
                text += string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_ROTTABLE, (object) str);
              tooltip += smi.GetToolTip();
            }
            if (component2.DiseaseIdx != byte.MaxValue)
            {
              text += string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.CONTENTS_DISEASED, (object) GameUtil.GetFormattedDisease(component2.DiseaseIdx, component2.DiseaseCount));
              string formattedDisease = GameUtil.GetFormattedDisease(component2.DiseaseIdx, component2.DiseaseCount, true);
              tooltip += formattedDisease;
            }
            targetPanel.SetLabelWithButton("move_" + num.ToString(), text, tooltip, (System.Action) (() => SelectTool.Instance.SelectAndFocus(go.transform.GetPosition(), go.GetComponent<KSelectable>(), new Vector3(5f, 0.0f, 0.0f))));
            ++num;
          }
        }
      }
    }
    else if ((UnityEngine.Object) moving != (UnityEngine.Object) null && moving.IsMarkedForMove)
      targetPanel.SetLabelWithButton("moveplacer", (string) MISC.PLACERS.MOVEPICKUPABLEPLACER.PLACER_STATUS, (string) MISC.PLACERS.MOVEPICKUPABLEPLACER.PLACER_STATUS_TOOLTIP, (System.Action) (() => SelectTool.Instance.SelectAndFocus(moving.StorageProxy.transform.GetPosition(), moving.StorageProxy.GetComponent<KSelectable>(), new Vector3(5f, 0.0f, 0.0f))));
    targetPanel.Commit();
  }

  private void RefreshWorldPanel()
  {
    WorldContainer component1 = (UnityEngine.Object) this.selectedTarget == (UnityEngine.Object) null ? (WorldContainer) null : this.selectedTarget.GetComponent<WorldContainer>();
    AsteroidGridEntity component2 = (UnityEngine.Object) this.selectedTarget == (UnityEngine.Object) null ? (AsteroidGridEntity) null : this.selectedTarget.GetComponent<AsteroidGridEntity>();
    bool flag1 = ManagementMenu.Instance.IsScreenOpen((KScreen) ClusterMapScreen.Instance) && (UnityEngine.Object) component1 != (UnityEngine.Object) null && (UnityEngine.Object) component2 != (UnityEngine.Object) null;
    this.worldBiomesPanel.gameObject.SetActive(flag1);
    this.worldGeysersPanel.gameObject.SetActive(flag1);
    this.worldMeteorShowersPanel.gameObject.SetActive(flag1);
    this.worldTraitsPanel.gameObject.SetActive(flag1);
    if (!flag1)
      return;
    foreach (KeyValuePair<Tag, GameObject> biomeRow in this.biomeRows)
      biomeRow.Value.SetActive(false);
    if (component1.Biomes != null)
    {
      foreach (string biome in component1.Biomes)
      {
        Sprite biomeSprite = GameUtil.GetBiomeSprite(biome);
        if (!this.biomeRows.ContainsKey((Tag) biome))
        {
          this.biomeRows.Add((Tag) biome, Util.KInstantiateUI(this.bigIconLabelRow, this.worldBiomesPanel.Content.gameObject, true));
          HierarchyReferences component3 = this.biomeRows[(Tag) biome].GetComponent<HierarchyReferences>();
          component3.GetReference<Image>("Icon").sprite = biomeSprite;
          component3.GetReference<LocText>("NameLabel").SetText(STRINGS.UI.FormatAsLink((string) Strings.Get($"STRINGS.SUBWORLDS.{biome.ToUpper()}.NAME"), "BIOME" + biome.ToUpper()));
          component3.GetReference<LocText>("DescriptionLabel").SetText((string) Strings.Get($"STRINGS.SUBWORLDS.{biome.ToUpper()}.DESC"));
        }
        this.biomeRows[(Tag) biome].SetActive(true);
      }
    }
    else
      this.worldBiomesPanel.gameObject.SetActive(false);
    List<Tag> tagList = new List<Tag>();
    foreach (Geyser cmp in Components.Geysers.GetItems(component1.id))
      tagList.Add(cmp.PrefabID());
    tagList.AddRange((IEnumerable<Tag>) SaveGame.Instance.worldGenSpawner.GetUnspawnedWithType<Geyser>(component1.id));
    tagList.AddRange((IEnumerable<Tag>) SaveGame.Instance.worldGenSpawner.GetSpawnersWithTag((Tag) "OilWell", component1.id, true));
    foreach (KeyValuePair<Tag, GameObject> geyserRow in this.geyserRows)
      geyserRow.Value.SetActive(false);
    foreach (Tag tag in tagList)
    {
      Tuple<Sprite, Color> uiSprite = Def.GetUISprite((object) tag);
      if (!this.geyserRows.ContainsKey(tag))
      {
        this.geyserRows.Add(tag, Util.KInstantiateUI(this.iconLabelRow, this.worldGeysersPanel.Content.gameObject, true));
        HierarchyReferences component4 = this.geyserRows[tag].GetComponent<HierarchyReferences>();
        component4.GetReference<Image>("Icon").sprite = uiSprite.first;
        component4.GetReference<Image>("Icon").color = uiSprite.second;
        component4.GetReference<LocText>("NameLabel").SetText(Assets.GetPrefab(tag).GetProperName());
        component4.GetReference<LocText>("ValueLabel").gameObject.SetActive(false);
      }
      this.geyserRows[tag].SetActive(true);
    }
    int count = SaveGame.Instance.worldGenSpawner.GetSpawnersWithTag((Tag) "GeyserGeneric", component1.id).Count;
    if (count > 0)
    {
      Tuple<Sprite, Color> uiSprite = Def.GetUISprite((object) "GeyserGeneric");
      Tag key = (Tag) "GeyserGeneric";
      if (!this.geyserRows.ContainsKey(key))
        this.geyserRows.Add(key, Util.KInstantiateUI(this.iconLabelRow, this.worldGeysersPanel.Content.gameObject, true));
      HierarchyReferences component5 = this.geyserRows[key].GetComponent<HierarchyReferences>();
      component5.GetReference<Image>("Icon").sprite = uiSprite.first;
      component5.GetReference<Image>("Icon").color = uiSprite.second;
      component5.GetReference<LocText>("NameLabel").SetText(STRINGS.UI.DETAILTABS.SIMPLEINFO.UNKNOWN_GEYSERS.Replace("{num}", count.ToString()));
      component5.GetReference<LocText>("ValueLabel").gameObject.SetActive(false);
      this.geyserRows[key].SetActive(true);
    }
    Tag key1 = (Tag) "NoGeysers";
    if (!this.geyserRows.ContainsKey(key1))
    {
      this.geyserRows.Add(key1, Util.KInstantiateUI(this.iconLabelRow, this.worldGeysersPanel.Content.gameObject, true));
      HierarchyReferences component6 = this.geyserRows[key1].GetComponent<HierarchyReferences>();
      component6.GetReference<Image>("Icon").sprite = Assets.GetSprite((HashedString) "icon_action_cancel");
      component6.GetReference<LocText>("NameLabel").SetText((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.NO_GEYSERS);
      component6.GetReference<LocText>("ValueLabel").gameObject.SetActive(false);
    }
    this.geyserRows[key1].gameObject.SetActive(tagList.Count == 0 && count == 0);
    foreach (KeyValuePair<Tag, GameObject> meteorShowerRow in this.meteorShowerRows)
      meteorShowerRow.Value.SetActive(false);
    bool flag2 = false;
    foreach (string seasonId in component1.GetSeasonIds())
    {
      GameplaySeason gameplaySeason = Db.Get().GameplaySeasons.TryGet(seasonId);
      if (gameplaySeason != null)
      {
        foreach (GameplayEvent gameplayEvent in gameplaySeason.events)
        {
          if (gameplayEvent.tags.Contains(GameTags.SpaceDanger) && gameplayEvent is MeteorShowerEvent)
          {
            flag2 = true;
            MeteorShowerEvent meteorShowerEvent = gameplayEvent as MeteorShowerEvent;
            string id = meteorShowerEvent.Id;
            Tuple<Sprite, Color> uiSprite = Def.GetUISprite((object) meteorShowerEvent.GetClusterMapMeteorShowerID());
            if (!this.meteorShowerRows.ContainsKey((Tag) id))
            {
              this.meteorShowerRows.Add((Tag) id, Util.KInstantiateUI(this.iconLabelRow, this.worldMeteorShowersPanel.Content.gameObject, true));
              HierarchyReferences component7 = this.meteorShowerRows[(Tag) id].GetComponent<HierarchyReferences>();
              component7.GetReference<Image>("Icon").sprite = uiSprite.first;
              component7.GetReference<Image>("Icon").color = uiSprite.second;
              component7.GetReference<LocText>("NameLabel").SetText(Assets.GetPrefab((Tag) meteorShowerEvent.GetClusterMapMeteorShowerID()).GetProperName());
              component7.GetReference<LocText>("ValueLabel").gameObject.SetActive(false);
            }
            this.meteorShowerRows[(Tag) id].SetActive(true);
          }
        }
      }
    }
    Tag key2 = (Tag) "NoMeteorShowers";
    if (!this.meteorShowerRows.ContainsKey(key2))
    {
      this.meteorShowerRows.Add(key2, Util.KInstantiateUI(this.iconLabelRow, this.worldMeteorShowersPanel.Content.gameObject, true));
      HierarchyReferences component8 = this.meteorShowerRows[key2].GetComponent<HierarchyReferences>();
      component8.GetReference<Image>("Icon").sprite = Assets.GetSprite((HashedString) "icon_action_cancel");
      component8.GetReference<LocText>("NameLabel").SetText((string) STRINGS.UI.DETAILTABS.SIMPLEINFO.NO_METEORSHOWERS);
      component8.GetReference<LocText>("ValueLabel").gameObject.SetActive(false);
    }
    this.meteorShowerRows[key2].gameObject.SetActive(!flag2);
    List<string> worldTraitIds = component1.WorldTraitIds;
    if (worldTraitIds != null)
    {
      for (int index = 0; index < worldTraitIds.Count; ++index)
      {
        if (index > this.worldTraitRows.Count - 1)
          this.CreateWorldTraitRow();
        WorldTrait cachedWorldTrait = SettingsCache.GetCachedWorldTrait(worldTraitIds[index], false);
        Image reference = this.worldTraitRows[index].GetComponent<HierarchyReferences>().GetReference<Image>("Icon");
        if (cachedWorldTrait != null)
        {
          Sprite sprite = Assets.GetSprite((HashedString) cachedWorldTrait.filePath.Substring(cachedWorldTrait.filePath.LastIndexOf("/") + 1));
          reference.gameObject.SetActive(true);
          reference.sprite = (UnityEngine.Object) sprite == (UnityEngine.Object) null ? Assets.GetSprite((HashedString) "unknown") : sprite;
          reference.color = Util.ColorFromHex(cachedWorldTrait.colorHex);
          this.worldTraitRows[index].GetComponent<HierarchyReferences>().GetReference<LocText>("NameLabel").SetText((string) Strings.Get(cachedWorldTrait.name));
          this.worldTraitRows[index].AddOrGet<ToolTip>().SetSimpleTooltip((string) Strings.Get(cachedWorldTrait.description));
        }
        else
        {
          Sprite sprite = Assets.GetSprite((HashedString) "NoTraits");
          reference.gameObject.SetActive(true);
          reference.sprite = sprite;
          reference.color = Color.white;
          this.worldTraitRows[index].GetComponent<HierarchyReferences>().GetReference<LocText>("NameLabel").SetText((string) WORLD_TRAITS.MISSING_TRAIT);
          this.worldTraitRows[index].AddOrGet<ToolTip>().SetSimpleTooltip("");
        }
      }
      for (int index = 0; index < this.worldTraitRows.Count; ++index)
        this.worldTraitRows[index].SetActive(index < worldTraitIds.Count);
      if (worldTraitIds.Count == 0)
      {
        if (this.worldTraitRows.Count < 1)
          this.CreateWorldTraitRow();
        Image reference = this.worldTraitRows[0].GetComponent<HierarchyReferences>().GetReference<Image>("Icon");
        Sprite sprite = Assets.GetSprite((HashedString) "NoTraits");
        reference.gameObject.SetActive(true);
        reference.sprite = sprite;
        reference.color = Color.black;
        this.worldTraitRows[0].GetComponent<HierarchyReferences>().GetReference<LocText>("NameLabel").SetText((string) WORLD_TRAITS.NO_TRAITS.NAME_SHORTHAND);
        this.worldTraitRows[0].AddOrGet<ToolTip>().SetSimpleTooltip((string) WORLD_TRAITS.NO_TRAITS.DESCRIPTION);
        this.worldTraitRows[0].SetActive(true);
      }
    }
    for (int index = this.surfaceConditionRows.Count - 1; index >= 0; --index)
      Util.KDestroyGameObject(this.surfaceConditionRows[index]);
    this.surfaceConditionRows.Clear();
    GameObject gameObject1 = Util.KInstantiateUI(this.iconLabelRow, this.worldTraitsPanel.Content.gameObject, true);
    HierarchyReferences component9 = gameObject1.GetComponent<HierarchyReferences>();
    component9.GetReference<Image>("Icon").sprite = Assets.GetSprite((HashedString) "overlay_lights");
    component9.GetReference<LocText>("NameLabel").SetText((string) STRINGS.UI.CLUSTERMAP.ASTEROIDS.SURFACE_CONDITIONS.LIGHT);
    component9.GetReference<LocText>("ValueLabel").SetText(GameUtil.GetFormattedLux(component1.SunlightFixedTraits[component1.sunlightFixedTrait]));
    component9.GetReference<LocText>("ValueLabel").alignment = TextAlignmentOptions.MidlineRight;
    this.surfaceConditionRows.Add(gameObject1);
    GameObject gameObject2 = Util.KInstantiateUI(this.iconLabelRow, this.worldTraitsPanel.Content.gameObject, true);
    HierarchyReferences component10 = gameObject2.GetComponent<HierarchyReferences>();
    component10.GetReference<Image>("Icon").sprite = Assets.GetSprite((HashedString) "overlay_radiation");
    component10.GetReference<LocText>("NameLabel").SetText((string) STRINGS.UI.CLUSTERMAP.ASTEROIDS.SURFACE_CONDITIONS.RADIATION);
    component10.GetReference<LocText>("ValueLabel").SetText(GameUtil.GetFormattedRads((float) component1.CosmicRadiationFixedTraits[component1.cosmicRadiationFixedTrait]));
    component10.GetReference<LocText>("ValueLabel").alignment = TextAlignmentOptions.MidlineRight;
    this.surfaceConditionRows.Add(gameObject2);
  }

  private void RefreshProcessConditionsPanel()
  {
    foreach (GameObject processConditionRow in this.processConditionRows)
      Util.KDestroyGameObject(processConditionRow);
    this.processConditionRows.Clear();
    this.processConditionContainer.SetActive(this.selectedTarget.GetComponent<IProcessConditionSet>() != null);
    if (!DlcManager.FeatureClusterSpaceEnabled())
    {
      if ((UnityEngine.Object) this.selectedTarget.GetComponent<LaunchableRocket>() != (UnityEngine.Object) null)
      {
        this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.RocketPrep);
        this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.RocketStorage);
        this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.RocketBoard);
      }
      else
        this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.All);
    }
    else if ((UnityEngine.Object) this.selectedTarget.GetComponent<LaunchPad>() != (UnityEngine.Object) null || (UnityEngine.Object) this.selectedTarget.GetComponent<RocketProcessConditionDisplayTarget>() != (UnityEngine.Object) null)
    {
      this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.RocketFlight);
      this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.RocketPrep);
      this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.RocketStorage);
      this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.RocketBoard);
    }
    else
      this.RefreshProcessConditionsForType(this.selectedTarget, ProcessCondition.ProcessConditionType.All);
  }

  private static void RefreshStressPanel(
    CollapsibleDetailContentPanel targetPanel,
    GameObject targetEntity)
  {
    MinionIdentity identity = (UnityEngine.Object) targetEntity != (UnityEngine.Object) null ? targetEntity.GetComponent<MinionIdentity>() : (MinionIdentity) null;
    if ((UnityEngine.Object) identity != (UnityEngine.Object) null)
    {
      List<ReportManager.ReportEntry.Note> stressNotes = new List<ReportManager.ReportEntry.Note>();
      targetPanel.gameObject.SetActive(true);
      targetPanel.SetTitle((string) STRINGS.UI.DETAILTABS.STATS.GROUPNAME_STRESS);
      ReportManager.ReportEntry reportEntry = ReportManager.Instance.TodaysReport.reportEntries.Find((Predicate<ReportManager.ReportEntry>) (entry => entry.reportType == ReportManager.ReportType.StressDelta));
      float f = 0.0f;
      stressNotes.Clear();
      int index1 = reportEntry.contextEntries.FindIndex((Predicate<ReportManager.ReportEntry>) (entry => entry.context == identity.GetProperName()));
      ReportManager.ReportEntry contextEntry = index1 != -1 ? reportEntry.contextEntries[index1] : (ReportManager.ReportEntry) null;
      if (contextEntry != null)
      {
        contextEntry.IterateNotes((Action<ReportManager.ReportEntry.Note>) (note => stressNotes.Add(note)));
        stressNotes.Sort((Comparison<ReportManager.ReportEntry.Note>) ((a, b) => a.value.CompareTo(b.value)));
        for (int index2 = 0; index2 < stressNotes.Count; ++index2)
        {
          string str = float.IsNegativeInfinity(stressNotes[index2].value) ? STRINGS.UI.NEG_INFINITY.ToString() : Util.FormatTwoDecimalPlace(stressNotes[index2].value);
          targetPanel.SetLabel("stressNotes_" + index2.ToString(), $"{((double) stressNotes[index2].value > 0.0 ? UIConstants.ColorPrefixRed : "")}{stressNotes[index2].note}: {str}%{((double) stressNotes[index2].value > 0.0 ? UIConstants.ColorSuffix : "")}", "");
          f += stressNotes[index2].value;
        }
      }
      string str1 = float.IsNegativeInfinity(f) ? STRINGS.UI.NEG_INFINITY.ToString() : Util.FormatTwoDecimalPlace(f);
      targetPanel.SetLabel("net_stress", ((double) f > 0.0 ? UIConstants.ColorPrefixRed : "") + string.Format((string) STRINGS.UI.DETAILTABS.DETAILS.NET_STRESS, (object) str1) + ((double) f > 0.0 ? UIConstants.ColorSuffix : ""), "");
    }
    targetPanel.Commit();
  }

  private void RefreshProcessConditionsForType(
    GameObject target,
    ProcessCondition.ProcessConditionType conditionType)
  {
    IProcessConditionSet component = target.GetComponent<IProcessConditionSet>();
    if (component == null)
      return;
    List<ProcessCondition> conditionSet = component.GetConditionSet(conditionType);
    if (conditionSet.Count == 0)
      return;
    HierarchyReferences hierarchyReferences = Util.KInstantiateUI<HierarchyReferences>(this.processConditionHeader.gameObject, this.processConditionContainer.Content.gameObject, true);
    hierarchyReferences.GetReference<LocText>("Label").text = (string) Strings.Get("STRINGS.UI.DETAILTABS.PROCESS_CONDITIONS." + conditionType.ToString().ToUpper());
    hierarchyReferences.GetComponent<ToolTip>().toolTip = (string) Strings.Get($"STRINGS.UI.DETAILTABS.PROCESS_CONDITIONS.{conditionType.ToString().ToUpper()}_TOOLTIP");
    this.processConditionRows.Add(hierarchyReferences.gameObject);
    List<ProcessCondition> processConditionList = new List<ProcessCondition>();
    foreach (ProcessCondition processCondition in conditionSet)
    {
      ProcessCondition condition = processCondition;
      if (condition.ShowInUI() && (condition.GetType() == typeof (RequireAttachedComponent) || processConditionList.Find((Predicate<ProcessCondition>) (match => match.GetType() == condition.GetType())) == null))
      {
        processConditionList.Add(condition);
        GameObject row = Util.KInstantiateUI(this.processConditionRow, this.processConditionContainer.Content.gameObject, true);
        this.processConditionRows.Add(row);
        ConditionListSideScreen.SetRowState(row, condition);
      }
    }
  }

  [DebuggerDisplay("{item.item.Name}")]
  public class StatusItemEntry : IRenderEveryTick
  {
    public StatusItemGroup.Entry item;
    public StatusItemCategory category;
    public Color color;
    public TextStyleSetting style;
    public Action<SimpleInfoScreen.StatusItemEntry> onDestroy;
    private LayoutElement spacerLayout;
    private GameObject widget;
    private ToolTip toolTip;
    private TextStyleSetting tooltipStyle;
    private Image image;
    private LocText text;
    private KButton button;
    private SimpleInfoScreen.StatusItemEntry.FadeStage fadeStage;
    private float fade;
    private float fadeInTime;
    private float fadeOutTime = 1.8f;

    public Image GetImage => this.image;

    public StatusItemEntry(
      StatusItemGroup.Entry item,
      StatusItemCategory category,
      GameObject status_item_prefab,
      Transform parent,
      TextStyleSetting tooltip_style,
      Color color,
      TextStyleSetting style,
      bool skip_fade,
      Action<SimpleInfoScreen.StatusItemEntry> onDestroy)
    {
      this.item = item;
      this.category = category;
      this.tooltipStyle = tooltip_style;
      this.onDestroy = onDestroy;
      this.color = color;
      this.style = style;
      this.widget = Util.KInstantiateUI(status_item_prefab, parent.gameObject);
      this.text = this.widget.GetComponentInChildren<LocText>(true);
      SetTextStyleSetting.ApplyStyle((TextMeshProUGUI) this.text, style);
      this.toolTip = this.widget.GetComponentInChildren<ToolTip>(true);
      this.image = this.widget.GetComponentInChildren<Image>(true);
      item.SetIcon(this.image);
      this.widget.SetActive(true);
      this.toolTip.OnToolTip = new Func<string>(this.OnToolTip);
      this.button = this.widget.GetComponentInChildren<KButton>();
      if (item.item.statusItemClickCallback != null)
        this.button.onClick += new System.Action(this.OnClick);
      else
        this.button.enabled = false;
      this.fadeStage = skip_fade ? SimpleInfoScreen.StatusItemEntry.FadeStage.WAIT : SimpleInfoScreen.StatusItemEntry.FadeStage.IN;
      SimAndRenderScheduler.instance.Add((object) this);
      this.Refresh();
      this.SetColor();
    }

    internal void SetSprite(TintedSprite sprite)
    {
      if (sprite == null)
        return;
      this.image.sprite = sprite.sprite;
    }

    public int GetIndex() => this.widget.transform.GetSiblingIndex();

    public void SetIndex(int index) => this.widget.transform.SetSiblingIndex(index);

    public void RenderEveryTick(float dt)
    {
      switch (this.fadeStage)
      {
        case SimpleInfoScreen.StatusItemEntry.FadeStage.IN:
          this.fade = Mathf.Min(this.fade + Time.deltaTime / this.fadeInTime, 1f);
          this.SetColor(this.fade);
          if ((double) this.fade < 1.0)
            break;
          this.fadeStage = SimpleInfoScreen.StatusItemEntry.FadeStage.WAIT;
          break;
        case SimpleInfoScreen.StatusItemEntry.FadeStage.OUT:
          this.SetColor(this.fade);
          this.fade = Mathf.Max(this.fade - Time.deltaTime / this.fadeOutTime, 0.0f);
          if ((double) this.fade > 0.0)
            break;
          this.Destroy(true);
          break;
      }
    }

    private string OnToolTip()
    {
      this.item.ShowToolTip(this.toolTip, this.tooltipStyle);
      return "";
    }

    private void OnClick() => this.item.OnClick();

    public void Refresh()
    {
      string name = this.item.GetName();
      if (!(name != this.text.text))
        return;
      this.text.text = name;
      this.SetColor();
    }

    private void SetColor(float alpha = 1f)
    {
      Color color = new Color(this.color.r, this.color.g, this.color.b, alpha);
      this.image.color = color;
      this.text.color = color;
    }

    public void Destroy(bool immediate)
    {
      if ((UnityEngine.Object) this.toolTip != (UnityEngine.Object) null)
        this.toolTip.OnToolTip = (Func<string>) null;
      if ((UnityEngine.Object) this.button != (UnityEngine.Object) null && this.button.enabled)
        this.button.onClick -= new System.Action(this.OnClick);
      if (immediate)
      {
        if (this.onDestroy != null)
          this.onDestroy(this);
        SimAndRenderScheduler.instance.Remove((object) this);
        UnityEngine.Object.Destroy((UnityEngine.Object) this.widget);
      }
      else
      {
        this.fade = 0.5f;
        this.fadeStage = SimpleInfoScreen.StatusItemEntry.FadeStage.OUT;
      }
    }

    private enum FadeStage
    {
      IN,
      WAIT,
      OUT,
    }
  }
}
