﻿// Decompiled with JetBrains decompiler
// Type: AchievementWidget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using FMOD.Studio;
using Klei.AI;
using STRINGS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/AchievementWidget")]
public class AchievementWidget : KMonoBehaviour
{
  private Color color_dark_red = new Color(0.282352954f, 0.160784319f, 0.149019614f);
  private Color color_gold = new Color(1f, 0.635294139f, 0.286274523f);
  private Color color_dark_grey = new Color(0.215686277f, 0.215686277f, 0.215686277f);
  private Color color_grey = new Color(0.6901961f, 0.6901961f, 0.6901961f);
  [SerializeField]
  private RectTransform sheenTransform;
  public AnimationCurve flourish_iconScaleCurve;
  public AnimationCurve flourish_sheenPositionCurve;
  public KBatchedAnimController[] sparks;
  [SerializeField]
  private RectTransform progressParent;
  [SerializeField]
  private GameObject requirementPrefab;
  [SerializeField]
  private Sprite statusSuccessIcon;
  [SerializeField]
  private Sprite statusFailureIcon;
  private int numRequirementsDisplayed;
  public string dlcIdFrom;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.GetComponent<MultiToggle>().onClick += (System.Action) (() => this.ExpandAchievement());
  }

  private void Update()
  {
  }

  private void ExpandAchievement()
  {
    if (!((UnityEngine.Object) SaveGame.Instance != (UnityEngine.Object) null))
      return;
    this.progressParent.gameObject.SetActive(!this.progressParent.gameObject.activeSelf);
  }

  public void ActivateNewlyAchievedFlourish(float delay = 1f)
  {
    this.StartCoroutine(this.Flourish(delay));
  }

  private IEnumerator Flourish(float startDelay)
  {
    AchievementWidget achievementWidget = this;
    achievementWidget.SetNeverAchieved();
    Canvas canvas = achievementWidget.GetComponent<Canvas>();
    if ((UnityEngine.Object) canvas == (UnityEngine.Object) null)
      canvas = achievementWidget.gameObject.AddComponent<Canvas>();
    yield return (object) SequenceUtil.WaitForSecondsRealtime(startDelay);
    // ISSUE: explicit non-virtual call
    KScrollRect component1 = __nonvirtual (achievementWidget.transform).parent.parent.GetComponent<KScrollRect>();
    float num1 = 1.1f;
    // ISSUE: explicit non-virtual call
    float normalizedVerticalPos = (float) (1.0 + (double) __nonvirtual (achievementWidget.transform).localPosition.y * (double) num1 / (double) component1.content.rect.height);
    component1.SetSmoothAutoScrollTarget(normalizedVerticalPos);
    yield return (object) SequenceUtil.WaitForSecondsRealtime(0.5f);
    canvas.overrideSorting = true;
    canvas.sortingOrder = 30;
    GameObject icon = achievementWidget.GetComponent<HierarchyReferences>().GetReference<Image>("icon").transform.parent.gameObject;
    foreach (KBatchedAnimController spark in achievementWidget.sparks)
    {
      if ((UnityEngine.Object) spark.transform.parent != (UnityEngine.Object) icon.transform.parent)
      {
        spark.GetComponent<KBatchedAnimController>().TintColour = (Color32) new Color(1f, 0.86f, 0.56f, 1f);
        spark.transform.SetParent(icon.transform.parent);
        spark.transform.SetSiblingIndex(icon.transform.GetSiblingIndex());
        spark.GetComponent<KBatchedAnimCanvasRenderer>().compare = CompareFunction.Always;
      }
    }
    HierarchyReferences component2 = achievementWidget.GetComponent<HierarchyReferences>();
    component2.GetReference<Image>("iconBG").color = achievementWidget.color_dark_red;
    component2.GetReference<Image>("iconBorder").color = achievementWidget.color_gold;
    component2.GetReference<Image>("icon").color = achievementWidget.color_gold;
    bool colorChanged = false;
    EventInstance instance = KFMOD.BeginOneShot(GlobalAssets.GetSound("AchievementUnlocked"), Vector3.zero);
    int num2 = Mathf.RoundToInt(MathUtil.Clamp(1f, 7f, startDelay - (float) ((double) startDelay % 1.0 / 1.0))) - 1;
    int num3 = (int) instance.setParameterByName("num_achievements", (float) num2);
    KFMOD.EndOneShot(instance);
    float i;
    for (i = 0.0f; (double) i < 1.2000000476837158; i += Time.unscaledDeltaTime)
    {
      icon.transform.localScale = Vector3.one * achievementWidget.flourish_iconScaleCurve.Evaluate(i);
      achievementWidget.sheenTransform.anchoredPosition = new Vector2(achievementWidget.flourish_sheenPositionCurve.Evaluate(i), achievementWidget.sheenTransform.anchoredPosition.y);
      if ((double) i > 1.0 && !colorChanged)
      {
        colorChanged = true;
        foreach (KAnimControllerBase spark in achievementWidget.sparks)
          spark.Play((HashedString) "spark");
        achievementWidget.SetAchievedNow();
      }
      yield return (object) SequenceUtil.WaitForNextFrame;
    }
    icon.transform.localScale = Vector3.one;
    achievementWidget.CompleteFlourish();
    for (i = 0.0f; (double) i < 0.60000002384185791; i += Time.unscaledDeltaTime)
      yield return (object) SequenceUtil.WaitForNextFrame;
    // ISSUE: explicit non-virtual call
    __nonvirtual (achievementWidget.transform).localScale = Vector3.one;
  }

  public void CompleteFlourish()
  {
    Canvas canvas = this.GetComponent<Canvas>();
    if ((UnityEngine.Object) canvas == (UnityEngine.Object) null)
      canvas = this.gameObject.AddComponent<Canvas>();
    canvas.overrideSorting = false;
  }

  public void SetAchievedNow()
  {
    this.GetComponent<MultiToggle>().ChangeState(1);
    HierarchyReferences component = this.GetComponent<HierarchyReferences>();
    component.GetReference<Image>("iconBG").color = this.color_dark_red;
    component.GetReference<Image>("iconBorder").color = this.color_gold;
    component.GetReference<Image>("icon").color = this.color_gold;
    foreach (Graphic componentsInChild in this.GetComponentsInChildren<LocText>())
      componentsInChild.color = Color.white;
    this.ConfigureToolTip(this.GetComponent<ToolTip>(), (string) COLONY_ACHIEVEMENTS.ACHIEVED_THIS_COLONY_TOOLTIP);
  }

  public void SetAchievedBefore()
  {
    this.GetComponent<MultiToggle>().ChangeState(1);
    HierarchyReferences component = this.GetComponent<HierarchyReferences>();
    component.GetReference<Image>("iconBG").color = this.color_dark_red;
    component.GetReference<Image>("iconBorder").color = this.color_gold;
    component.GetReference<Image>("icon").color = this.color_gold;
    foreach (Graphic componentsInChild in this.GetComponentsInChildren<LocText>())
      componentsInChild.color = Color.white;
    this.ConfigureToolTip(this.GetComponent<ToolTip>(), (string) COLONY_ACHIEVEMENTS.ACHIEVED_OTHER_COLONY_TOOLTIP);
  }

  public void SetNeverAchieved()
  {
    this.GetComponent<MultiToggle>().ChangeState(2);
    HierarchyReferences component = this.GetComponent<HierarchyReferences>();
    component.GetReference<Image>("iconBG").color = this.color_dark_grey;
    component.GetReference<Image>("iconBorder").color = this.color_grey;
    component.GetReference<Image>("icon").color = this.color_grey;
    foreach (LocText componentsInChild in this.GetComponentsInChildren<LocText>())
      componentsInChild.color = new Color(componentsInChild.color.r, componentsInChild.color.g, componentsInChild.color.b, 0.6f);
    this.ConfigureToolTip(this.GetComponent<ToolTip>(), (string) COLONY_ACHIEVEMENTS.NOT_ACHIEVED_EVER);
  }

  public void SetNotAchieved()
  {
    this.GetComponent<MultiToggle>().ChangeState(2);
    HierarchyReferences component = this.GetComponent<HierarchyReferences>();
    component.GetReference<Image>("iconBG").color = this.color_dark_grey;
    component.GetReference<Image>("iconBorder").color = this.color_grey;
    component.GetReference<Image>("icon").color = this.color_grey;
    foreach (LocText componentsInChild in this.GetComponentsInChildren<LocText>())
      componentsInChild.color = new Color(componentsInChild.color.r, componentsInChild.color.g, componentsInChild.color.b, 0.6f);
    this.ConfigureToolTip(this.GetComponent<ToolTip>(), (string) COLONY_ACHIEVEMENTS.NOT_ACHIEVED_THIS_COLONY);
  }

  public void SetFailed()
  {
    this.GetComponent<MultiToggle>().ChangeState(2);
    HierarchyReferences component = this.GetComponent<HierarchyReferences>();
    component.GetReference<Image>("iconBG").color = this.color_dark_grey;
    component.GetReference<Image>("iconBG").SetAlpha(0.5f);
    component.GetReference<Image>("iconBorder").color = this.color_grey;
    component.GetReference<Image>("iconBorder").SetAlpha(0.5f);
    component.GetReference<Image>("icon").color = this.color_grey;
    component.GetReference<Image>("icon").SetAlpha(0.5f);
    foreach (LocText componentsInChild in this.GetComponentsInChildren<LocText>())
      componentsInChild.color = new Color(componentsInChild.color.r, componentsInChild.color.g, componentsInChild.color.b, 0.25f);
    this.ConfigureToolTip(this.GetComponent<ToolTip>(), (string) COLONY_ACHIEVEMENTS.FAILED_THIS_COLONY);
  }

  private void ConfigureToolTip(ToolTip tooltip, string status)
  {
    tooltip.ClearMultiStringTooltip();
    tooltip.AddMultiStringTooltip(status, (TextStyleSetting) null);
    if ((UnityEngine.Object) SaveGame.Instance != (UnityEngine.Object) null && !this.progressParent.gameObject.activeSelf)
      tooltip.AddMultiStringTooltip((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.EXPAND_TOOLTIP, (TextStyleSetting) null);
    if (!DlcManager.IsDlcId(this.dlcIdFrom))
      return;
    tooltip.AddMultiStringTooltip(string.Format((string) COLONY_ACHIEVEMENTS.DLC_ACHIEVEMENT, (object) DlcManager.GetDlcTitle(this.dlcIdFrom)), (TextStyleSetting) null);
  }

  public void ShowProgress(ColonyAchievementStatus achievement)
  {
    if ((UnityEngine.Object) this.progressParent == (UnityEngine.Object) null)
      return;
    this.numRequirementsDisplayed = 0;
    for (int index = 0; index < achievement.Requirements.Count; ++index)
    {
      ColonyAchievementRequirement requirement = achievement.Requirements[index];
      switch (requirement)
      {
        case CritterTypesWithTraits _:
          this.ShowCritterChecklist(requirement);
          break;
        case DupesCompleteChoreInExoSuitForCycles _:
          this.ShowDupesInExoSuitsRequirement(achievement.success, requirement);
          break;
        case DupesVsSolidTransferArmFetch _:
          this.ShowArmsOutPeformingDupesRequirement(achievement.success, requirement);
          break;
        case ProduceXEngeryWithoutUsingYList _:
          this.ShowEngeryWithoutUsing(achievement.success, requirement);
          break;
        case MinimumMorale _:
          this.ShowMinimumMoraleRequirement(achievement.success, requirement);
          break;
        case SurviveARocketWithMinimumMorale _:
          this.ShowRocketMoraleRequirement(achievement.success, requirement);
          break;
        default:
          this.ShowRequirement(achievement.success, requirement);
          break;
      }
    }
  }

  private HierarchyReferences GetNextRequirementWidget()
  {
    GameObject gameObject;
    if (this.progressParent.childCount <= this.numRequirementsDisplayed)
    {
      gameObject = Util.KInstantiateUI(this.requirementPrefab, this.progressParent.gameObject, true);
    }
    else
    {
      gameObject = this.progressParent.GetChild(this.numRequirementsDisplayed).gameObject;
      gameObject.SetActive(true);
    }
    ++this.numRequirementsDisplayed;
    return gameObject.GetComponent<HierarchyReferences>();
  }

  private void SetDescription(string str, HierarchyReferences refs)
  {
    refs.GetReference<LocText>("Desc").SetText(str);
  }

  private void SetIcon(Sprite sprite, Color color, HierarchyReferences refs)
  {
    Image reference = refs.GetReference<Image>("Icon");
    reference.sprite = sprite;
    reference.color = color;
    reference.gameObject.SetActive(true);
  }

  private void ShowIcon(bool show, HierarchyReferences refs)
  {
    refs.GetReference<Image>("Icon").gameObject.SetActive(show);
  }

  private void ShowRequirement(bool succeed, ColonyAchievementRequirement req)
  {
    HierarchyReferences requirementWidget = this.GetNextRequirementWidget();
    bool complete = req.Success() | succeed;
    bool flag = req.Fail();
    if (complete && !flag)
      this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget);
    else if (flag)
      this.SetIcon(this.statusFailureIcon, Color.red, requirementWidget);
    else
      this.ShowIcon(false, requirementWidget);
    this.SetDescription(req.GetProgress(complete), requirementWidget);
  }

  private void ShowCritterChecklist(ColonyAchievementRequirement req)
  {
    CritterTypesWithTraits critterTypesWithTraits = req as CritterTypesWithTraits;
    if (req == null)
      return;
    foreach (KeyValuePair<Tag, bool> keyValuePair in critterTypesWithTraits.critterTypesToCheck)
    {
      HierarchyReferences requirementWidget = this.GetNextRequirementWidget();
      if (keyValuePair.Value)
        this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget);
      else
        this.ShowIcon(false, requirementWidget);
      this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.TAME_A_CRITTER, (object) ((Tag) keyValuePair.Key.Name).ProperName()), requirementWidget);
    }
  }

  private void ShowArmsOutPeformingDupesRequirement(bool succeed, ColonyAchievementRequirement req)
  {
    if (!(req is DupesVsSolidTransferArmFetch transferArmFetch))
      return;
    HierarchyReferences requirementWidget1 = this.GetNextRequirementWidget();
    if (succeed)
      this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget1);
    this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.ARM_PERFORMANCE, (object) (succeed ? transferArmFetch.numCycles : transferArmFetch.currentCycleCount), (object) transferArmFetch.numCycles), requirementWidget1);
    if (succeed)
      return;
    Dictionary<int, int> dupeChoreDeliveries = SaveGame.Instance.ColonyAchievementTracker.fetchDupeChoreDeliveries;
    Dictionary<int, int> automatedChoreDeliveries = SaveGame.Instance.ColonyAchievementTracker.fetchAutomatedChoreDeliveries;
    int num1 = 0;
    int cycle = GameClock.Instance.GetCycle();
    ref int local = ref num1;
    dupeChoreDeliveries.TryGetValue(cycle, out local);
    int num2 = 0;
    automatedChoreDeliveries.TryGetValue(GameClock.Instance.GetCycle(), out num2);
    HierarchyReferences requirementWidget2 = this.GetNextRequirementWidget();
    if ((double) num1 < (double) num2 * (double) transferArmFetch.percentage)
      this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget2);
    else
      this.ShowIcon(false, requirementWidget2);
    this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.ARM_VS_DUPE_FETCHES, (object) "SolidTransferArm", (object) num2, (object) num1), requirementWidget2);
  }

  private void ShowDupesInExoSuitsRequirement(bool succeed, ColonyAchievementRequirement req)
  {
    if (!(req is DupesCompleteChoreInExoSuitForCycles exoSuitForCycles))
      return;
    HierarchyReferences requirementWidget1 = this.GetNextRequirementWidget();
    if (succeed)
      this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget1);
    else
      this.ShowIcon(false, requirementWidget1);
    this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.EXOSUIT_CYCLES, (object) (succeed ? exoSuitForCycles.numCycles : exoSuitForCycles.currentCycleStreak), (object) exoSuitForCycles.numCycles), requirementWidget1);
    if (succeed)
      return;
    HierarchyReferences requirementWidget2 = this.GetNextRequirementWidget();
    int num = exoSuitForCycles.GetNumberOfDupesForCycle(GameClock.Instance.GetCycle());
    if (num >= Components.LiveMinionIdentities.Count)
    {
      num = Components.LiveMinionIdentities.Count;
      this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget2);
    }
    this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.EXOSUIT_THIS_CYCLE, (object) num, (object) Components.LiveMinionIdentities.Count), requirementWidget2);
  }

  private void ShowEngeryWithoutUsing(bool succeed, ColonyAchievementRequirement req)
  {
    ProduceXEngeryWithoutUsingYList withoutUsingYlist = req as ProduceXEngeryWithoutUsingYList;
    if (req == null)
      return;
    HierarchyReferences requirementWidget1 = this.GetNextRequirementWidget();
    float productionAmount = withoutUsingYlist.GetProductionAmount(succeed);
    this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.GENERATE_POWER, (object) GameUtil.GetFormattedRoundedJoules(productionAmount), (object) GameUtil.GetFormattedRoundedJoules(withoutUsingYlist.amountToProduce * 1000f)), requirementWidget1);
    if (succeed)
      this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget1);
    else
      this.ShowIcon(false, requirementWidget1);
    foreach (Tag disallowedBuilding in withoutUsingYlist.disallowedBuildings)
    {
      BuildingDef buildingDef = Assets.GetBuildingDef(disallowedBuilding.Name);
      if (!((UnityEngine.Object) buildingDef == (UnityEngine.Object) null))
      {
        HierarchyReferences requirementWidget2 = this.GetNextRequirementWidget();
        if (Game.Instance.savedInfo.powerCreatedbyGeneratorType.ContainsKey(disallowedBuilding))
          this.SetIcon(this.statusFailureIcon, Color.red, requirementWidget2);
        else
          this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget2);
        this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.NO_BUILDING, (object) buildingDef.Name), requirementWidget2);
      }
    }
  }

  private void ShowMinimumMoraleRequirement(bool success, ColonyAchievementRequirement req)
  {
    if (!(req is MinimumMorale minimumMorale))
      return;
    if (success)
    {
      this.ShowRequirement(success, req);
    }
    else
    {
      foreach (MinionAssignablesProxy assignablesProxy in Components.MinionAssignablesProxy)
      {
        GameObject targetGameObject = assignablesProxy.GetTargetGameObject();
        if ((UnityEngine.Object) targetGameObject != (UnityEngine.Object) null && !targetGameObject.HasTag(GameTags.Dead))
        {
          AttributeInstance attributeInstance = Db.Get().Attributes.QualityOfLife.Lookup((Component) targetGameObject.GetComponent<MinionModifiers>());
          if (attributeInstance != null)
          {
            HierarchyReferences requirementWidget = this.GetNextRequirementWidget();
            if ((double) attributeInstance.GetTotalValue() >= (double) minimumMorale.minimumMorale)
              this.SetIcon(this.statusSuccessIcon, Color.green, requirementWidget);
            else
              this.ShowIcon(false, requirementWidget);
            this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.MORALE, (object) targetGameObject.GetProperName(), (object) attributeInstance.GetTotalDisplayValue()), requirementWidget);
          }
        }
      }
    }
  }

  private void ShowRocketMoraleRequirement(bool success, ColonyAchievementRequirement req)
  {
    if (!(req is SurviveARocketWithMinimumMorale withMinimumMorale))
      return;
    if (success)
    {
      this.ShowRequirement(success, req);
    }
    else
    {
      foreach (KeyValuePair<int, int> keyValuePair in SaveGame.Instance.ColonyAchievementTracker.cyclesRocketDupeMoraleAboveRequirement)
      {
        WorldContainer world = ClusterManager.Instance.GetWorld(keyValuePair.Key);
        if ((UnityEngine.Object) world != (UnityEngine.Object) null)
        {
          HierarchyReferences requirementWidget = this.GetNextRequirementWidget();
          this.SetDescription(string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.SURVIVE_SPACE, (object) withMinimumMorale.minimumMorale, (object) keyValuePair.Value, (object) withMinimumMorale.numberOfCycles, (object) world.GetProperName()), requirementWidget);
        }
      }
    }
  }
}
