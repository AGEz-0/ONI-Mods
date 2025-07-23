// Decompiled with JetBrains decompiler
// Type: ClusterDestinationSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ClusterDestinationSideScreen : SideScreenContent
{
  public Image destinationImage;
  public LocText destinationLabel;
  public KButton changeDestinationButton;
  public KButton clearDestinationButton;
  public DropDown launchPadDropDown;
  public KButton repeatButton;
  public ColorStyleSetting repeatOff;
  public ColorStyleSetting repeatOn;
  public ColorStyleSetting defaultButton;
  public ColorStyleSetting highlightButton;
  private int m_refreshHandle = -1;

  private ClusterDestinationSelector targetSelector { get; set; }

  private RocketClusterDestinationSelector targetRocketSelector { get; set; }

  protected override void OnSpawn()
  {
    this.changeDestinationButton.onClick += new System.Action(this.OnClickChangeDestination);
    this.clearDestinationButton.onClick += new System.Action(this.OnClickClearDestination);
    this.launchPadDropDown.targetDropDownContainer = GameScreenManager.Instance.ssOverlayCanvas;
    this.launchPadDropDown.CustomizeEmptyRow((string) STRINGS.UI.UISIDESCREENS.CLUSTERDESTINATIONSIDESCREEN.FIRSTAVAILABLE, (Sprite) null);
    this.repeatButton.onClick += new System.Action(this.OnRepeatClicked);
  }

  public override int GetSideScreenSortOrder() => 300;

  protected override void OnShow(bool show)
  {
    base.OnShow(show);
    if (show)
    {
      this.Refresh();
      this.m_refreshHandle = this.targetSelector.Subscribe(543433792, (Action<object>) (data => this.Refresh()));
    }
    else
    {
      if (this.m_refreshHandle == -1)
        return;
      this.targetSelector.Unsubscribe(this.m_refreshHandle);
      this.m_refreshHandle = -1;
      this.launchPadDropDown.Close();
    }
  }

  public override bool IsValidForTarget(GameObject target)
  {
    ClusterDestinationSelector component = target.GetComponent<ClusterDestinationSelector>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.assignable || (UnityEngine.Object) target.GetComponent<RocketModule>() != (UnityEngine.Object) null && target.HasTag(GameTags.LaunchButtonRocketModule))
      return true;
    return (UnityEngine.Object) target.GetComponent<RocketControlStation>() != (UnityEngine.Object) null && target.GetComponent<RocketControlStation>().GetMyWorld().GetComponent<Clustercraft>().Status != Clustercraft.CraftStatus.Launching;
  }

  public override void SetTarget(GameObject target)
  {
    this.targetSelector = target.GetComponent<ClusterDestinationSelector>();
    if ((UnityEngine.Object) this.targetSelector == (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) target.GetComponent<RocketModuleCluster>() != (UnityEngine.Object) null)
        this.targetSelector = (ClusterDestinationSelector) target.GetComponent<RocketModuleCluster>().CraftInterface.GetClusterDestinationSelector();
      else if ((UnityEngine.Object) target.GetComponent<RocketControlStation>() != (UnityEngine.Object) null)
        this.targetSelector = (ClusterDestinationSelector) target.GetMyWorld().GetComponent<Clustercraft>().ModuleInterface.GetClusterDestinationSelector();
    }
    this.targetRocketSelector = this.targetSelector as RocketClusterDestinationSelector;
    this.changeDestinationButton.GetComponent<ToolTip>().SetSimpleTooltip(this.targetSelector.changeTargetButtonTooltipString);
    this.clearDestinationButton.GetComponent<ToolTip>().SetSimpleTooltip(this.targetSelector.clearTargetButtonTooltipString);
  }

  private void Refresh(object data = null)
  {
    if (!this.targetSelector.IsAtDestination())
    {
      ClusterGridEntity clusterEntityTarget = this.targetSelector.GetClusterEntityTarget();
      if ((UnityEngine.Object) clusterEntityTarget != (UnityEngine.Object) null)
      {
        this.destinationImage.sprite = clusterEntityTarget.GetUISprite();
        this.destinationLabel.text = $"{this.targetSelector.sidescreenTitleString}: {clusterEntityTarget.GetProperName()}";
      }
      else
      {
        Sprite sprite;
        string label;
        ClusterGrid.Instance.GetLocationDescription(this.targetSelector.GetDestination(), out sprite, out label, out string _);
        this.destinationImage.sprite = sprite;
        this.destinationLabel.text = $"{this.targetSelector.sidescreenTitleString}: {label}";
      }
      this.clearDestinationButton.isInteractable = true;
    }
    else
    {
      this.destinationImage.sprite = Assets.GetSprite((HashedString) "hex_unknown");
      this.destinationLabel.text = $"{this.targetSelector.sidescreenTitleString}: {(string) STRINGS.UI.SPACEDESTINATIONS.NONE.NAME}";
      this.clearDestinationButton.isInteractable = false;
    }
    if ((UnityEngine.Object) this.targetRocketSelector != (UnityEngine.Object) null)
    {
      List<LaunchPad> padsForDestination = LaunchPad.GetLaunchPadsForDestination(this.targetRocketSelector.GetDestination());
      this.launchPadDropDown.gameObject.SetActive(true);
      this.repeatButton.gameObject.SetActive(true);
      this.launchPadDropDown.Initialize((IEnumerable<IListableOption>) padsForDestination, new Action<IListableOption, object>(this.OnLaunchPadEntryClick), new Func<IListableOption, IListableOption, object, int>(this.PadDropDownSort), new Action<DropDownEntry, object>(this.PadDropDownEntryRefreshAction), targetData: (object) this.targetRocketSelector);
      if (!this.targetRocketSelector.IsAtDestination() && padsForDestination.Count > 0)
      {
        this.launchPadDropDown.openButton.isInteractable = true;
        LaunchPad destinationPad = this.targetRocketSelector.GetDestinationPad();
        if ((UnityEngine.Object) destinationPad != (UnityEngine.Object) null)
          this.launchPadDropDown.selectedLabel.text = destinationPad.GetProperName();
        else
          this.launchPadDropDown.selectedLabel.text = (string) STRINGS.UI.UISIDESCREENS.CLUSTERDESTINATIONSIDESCREEN.FIRSTAVAILABLE;
      }
      else
      {
        this.launchPadDropDown.selectedLabel.text = (string) STRINGS.UI.UISIDESCREENS.CLUSTERDESTINATIONSIDESCREEN.FIRSTAVAILABLE;
        this.launchPadDropDown.openButton.isInteractable = false;
      }
      this.StyleRepeatButton();
    }
    else
    {
      this.launchPadDropDown.gameObject.SetActive(false);
      this.repeatButton.gameObject.SetActive(false);
    }
    this.StyleChangeDestinationButton();
  }

  private void OnClickChangeDestination()
  {
    if (this.targetSelector.assignable)
      ClusterMapScreen.Instance.ShowInSelectDestinationMode(this.targetSelector);
    this.StyleChangeDestinationButton();
  }

  private void StyleChangeDestinationButton()
  {
  }

  private void OnClickClearDestination()
  {
    this.targetSelector.SetDestination(this.targetSelector.GetMyWorldLocation());
  }

  private void OnLaunchPadEntryClick(IListableOption option, object data)
  {
    this.targetRocketSelector.SetDestinationPad((LaunchPad) option);
  }

  private void PadDropDownEntryRefreshAction(DropDownEntry entry, object targetData)
  {
    LaunchPad entryData = (LaunchPad) entry.entryData;
    Clustercraft component = this.targetRocketSelector.GetComponent<Clustercraft>();
    if ((UnityEngine.Object) entryData != (UnityEngine.Object) null)
    {
      string failReason;
      if (component.CanLandAtPad(entryData, out failReason) == Clustercraft.PadLandingStatus.CanNeverLand)
      {
        entry.button.isInteractable = false;
        entry.image.sprite = Assets.GetSprite((HashedString) "iconWarning");
        entry.tooltip.SetSimpleTooltip(failReason);
      }
      else
      {
        entry.button.isInteractable = true;
        entry.image.sprite = entryData.GetComponent<Building>().Def.GetUISprite();
        entry.tooltip.SetSimpleTooltip(string.Format((string) STRINGS.UI.UISIDESCREENS.CLUSTERDESTINATIONSIDESCREEN.DROPDOWN_TOOLTIP_VALID_SITE, (object) entryData.GetProperName()));
      }
    }
    else
    {
      entry.button.isInteractable = true;
      entry.image.sprite = Assets.GetBuildingDef("LaunchPad").GetUISprite();
      entry.tooltip.SetSimpleTooltip((string) STRINGS.UI.UISIDESCREENS.CLUSTERDESTINATIONSIDESCREEN.DROPDOWN_TOOLTIP_FIRST_AVAILABLE);
    }
  }

  private int PadDropDownSort(IListableOption a, IListableOption b, object targetData) => 0;

  private void OnRepeatClicked()
  {
    this.targetRocketSelector.Repeat = !this.targetRocketSelector.Repeat;
    this.StyleRepeatButton();
  }

  private void StyleRepeatButton()
  {
    this.repeatButton.bgImage.colorStyleSetting = this.targetRocketSelector.Repeat ? this.repeatOn : this.repeatOff;
    this.repeatButton.bgImage.ApplyColorStyleSetting();
  }
}
