// Decompiled with JetBrains decompiler
// Type: RocketModuleSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class RocketModuleSideScreen : SideScreenContent
{
  public static RocketModuleSideScreen instance;
  private ReorderableBuilding reorderable;
  public KScreen changeModuleSideScreen;
  public Image moduleIcon;
  [Header("Buttons")]
  public KButton addNewModuleButton;
  public KButton removeModuleButton;
  public KButton changeModuleButton;
  public KButton moveModuleUpButton;
  public KButton moveModuleDownButton;
  public KButton viewInteriorButton;
  [Header("Labels")]
  public LocText moduleNameLabel;
  public LocText moduleDescriptionLabel;
  public TextStyleSetting nameSetting;
  public TextStyleSetting descriptionSetting;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    RocketModuleSideScreen.instance = this;
  }

  protected override void OnForcedCleanUp()
  {
    RocketModuleSideScreen.instance = (RocketModuleSideScreen) null;
    base.OnForcedCleanUp();
  }

  public override int GetSideScreenSortOrder() => 500;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.addNewModuleButton.onClick += (System.Action) (() =>
    {
      Vector2 vector2 = Vector2.zero;
      if ((UnityEngine.Object) SelectModuleSideScreen.Instance != (UnityEngine.Object) null)
        vector2 = SelectModuleSideScreen.Instance.mainContents.GetComponent<KScrollRect>().content.rectTransform().anchoredPosition;
      this.ClickAddNew(vector2.y);
    });
    this.removeModuleButton.onClick += new System.Action(this.ClickRemove);
    this.moveModuleUpButton.onClick += new System.Action(this.ClickSwapUp);
    this.moveModuleDownButton.onClick += new System.Action(this.ClickSwapDown);
    this.changeModuleButton.onClick += (System.Action) (() =>
    {
      Vector2 vector2 = Vector2.zero;
      if ((UnityEngine.Object) SelectModuleSideScreen.Instance != (UnityEngine.Object) null)
        vector2 = SelectModuleSideScreen.Instance.mainContents.GetComponent<KScrollRect>().content.rectTransform().anchoredPosition;
      this.ClickChangeModule(vector2.y);
    });
    this.viewInteriorButton.onClick += new System.Action(this.ClickViewInterior);
    this.moduleNameLabel.textStyleSetting = this.nameSetting;
    this.moduleDescriptionLabel.textStyleSetting = this.descriptionSetting;
    this.moduleNameLabel.ApplySettings();
    this.moduleDescriptionLabel.ApplySettings();
  }

  protected override void OnCmpDisable()
  {
    base.OnCmpDisable();
    DetailsScreen.Instance.ClearSecondarySideScreen();
  }

  protected override void OnCleanUp() => base.OnCleanUp();

  public override bool IsValidForTarget(GameObject target)
  {
    return (UnityEngine.Object) target.GetComponent<ReorderableBuilding>() != (UnityEngine.Object) null;
  }

  public override void SetTarget(GameObject new_target)
  {
    if ((UnityEngine.Object) new_target == (UnityEngine.Object) null)
    {
      Debug.LogError((object) "Invalid gameObject received");
    }
    else
    {
      this.reorderable = new_target.GetComponent<ReorderableBuilding>();
      this.moduleIcon.sprite = Def.GetUISprite((object) this.reorderable.gameObject).first;
      this.moduleNameLabel.SetText(this.reorderable.GetProperName());
      this.moduleDescriptionLabel.SetText(this.reorderable.GetComponent<Building>().Desc);
      this.UpdateButtonStates();
    }
  }

  public void UpdateButtonStates()
  {
    this.changeModuleButton.isInteractable = this.reorderable.CanChangeModule();
    this.changeModuleButton.GetComponent<ToolTip>().SetSimpleTooltip(this.changeModuleButton.isInteractable ? STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONCHANGEMODULE.DESC.text : STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONCHANGEMODULE.INVALID.text);
    this.addNewModuleButton.isInteractable = true;
    this.addNewModuleButton.GetComponent<ToolTip>().SetSimpleTooltip(STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.ADDMODULE.DESC.text);
    this.removeModuleButton.isInteractable = this.reorderable.CanRemoveModule();
    this.removeModuleButton.GetComponent<ToolTip>().SetSimpleTooltip(this.removeModuleButton.isInteractable ? STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONREMOVEMODULE.DESC.text : STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONREMOVEMODULE.INVALID.text);
    this.moveModuleDownButton.isInteractable = this.reorderable.CanSwapDown();
    this.moveModuleDownButton.GetComponent<ToolTip>().SetSimpleTooltip(this.moveModuleDownButton.isInteractable ? STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONSWAPMODULEDOWN.DESC.text : STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONSWAPMODULEDOWN.INVALID.text);
    this.moveModuleUpButton.isInteractable = this.reorderable.CanSwapUp();
    this.moveModuleUpButton.GetComponent<ToolTip>().SetSimpleTooltip(this.moveModuleUpButton.isInteractable ? STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONSWAPMODULEUP.DESC.text : STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONSWAPMODULEUP.INVALID.text);
    ClustercraftExteriorDoor component = this.reorderable.GetComponent<ClustercraftExteriorDoor>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.HasTargetWorld())
    {
      if ((UnityEngine.Object) ClusterManager.Instance.activeWorld == (UnityEngine.Object) component.GetTargetWorld())
      {
        this.changeModuleButton.isInteractable = false;
        this.addNewModuleButton.isInteractable = false;
        this.removeModuleButton.isInteractable = false;
        this.moveModuleDownButton.isInteractable = false;
        this.moveModuleUpButton.isInteractable = false;
        this.viewInteriorButton.isInteractable = component.GetMyWorldId() != (int) byte.MaxValue;
        this.viewInteriorButton.GetComponentInChildren<LocText>().SetText((string) STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWEXTERIOR.LABEL);
        this.viewInteriorButton.GetComponent<ToolTip>().SetSimpleTooltip(this.viewInteriorButton.isInteractable ? STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWEXTERIOR.DESC.text : STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWEXTERIOR.INVALID.text);
      }
      else
      {
        this.viewInteriorButton.isInteractable = (UnityEngine.Object) this.reorderable.GetComponent<PassengerRocketModule>() != (UnityEngine.Object) null;
        this.viewInteriorButton.GetComponentInChildren<LocText>().SetText((string) STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWINTERIOR.LABEL);
        this.viewInteriorButton.GetComponent<ToolTip>().SetSimpleTooltip(this.viewInteriorButton.isInteractable ? STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWINTERIOR.DESC.text : STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWINTERIOR.INVALID.text);
      }
    }
    else
    {
      this.viewInteriorButton.isInteractable = false;
      this.viewInteriorButton.GetComponentInChildren<LocText>().SetText((string) STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWINTERIOR.LABEL);
      this.viewInteriorButton.GetComponent<ToolTip>().SetSimpleTooltip(this.viewInteriorButton.isInteractable ? STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWINTERIOR.DESC.text : STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.BUTTONVIEWINTERIOR.INVALID.text);
    }
  }

  public void ClickAddNew(float scrollViewPosition, BuildingDef autoSelectDef = null)
  {
    SelectModuleSideScreen moduleSideScreen = (SelectModuleSideScreen) DetailsScreen.Instance.SetSecondarySideScreen(this.changeModuleSideScreen, (string) STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.CHANGEMODULEPANEL);
    moduleSideScreen.addingNewModule = true;
    moduleSideScreen.SetTarget(this.reorderable.gameObject);
    if ((UnityEngine.Object) autoSelectDef != (UnityEngine.Object) null)
      moduleSideScreen.SelectModule(autoSelectDef);
    this.ScrollToTargetPoint(scrollViewPosition);
  }

  private void ScrollToTargetPoint(float scrollViewPosition)
  {
    if (!((UnityEngine.Object) SelectModuleSideScreen.Instance != (UnityEngine.Object) null))
      return;
    SelectModuleSideScreen.Instance.mainContents.GetComponent<KScrollRect>().content.anchoredPosition = new Vector2(0.0f, scrollViewPosition);
    if (!this.gameObject.activeInHierarchy)
      return;
    this.StartCoroutine(this.DelayedScrollToTargetPoint(scrollViewPosition));
  }

  private IEnumerator DelayedScrollToTargetPoint(float scrollViewPosition)
  {
    if ((UnityEngine.Object) SelectModuleSideScreen.Instance != (UnityEngine.Object) null)
    {
      yield return (object) SequenceUtil.WaitForEndOfFrame;
      SelectModuleSideScreen.Instance.mainContents.GetComponent<KScrollRect>().content.anchoredPosition = new Vector2(0.0f, scrollViewPosition);
    }
  }

  private void ClickRemove()
  {
    this.reorderable.Trigger(-790448070, (object) null);
    this.UpdateButtonStates();
  }

  private void ClickSwapUp()
  {
    this.reorderable.SwapWithAbove();
    this.UpdateButtonStates();
  }

  private void ClickSwapDown()
  {
    this.reorderable.SwapWithBelow();
    this.UpdateButtonStates();
  }

  private void ClickChangeModule(float scrollViewPosition)
  {
    SelectModuleSideScreen moduleSideScreen = (SelectModuleSideScreen) DetailsScreen.Instance.SetSecondarySideScreen(this.changeModuleSideScreen, (string) STRINGS.UI.UISIDESCREENS.ROCKETMODULESIDESCREEN.CHANGEMODULEPANEL);
    moduleSideScreen.addingNewModule = false;
    moduleSideScreen.SetTarget(this.reorderable.gameObject);
    this.ScrollToTargetPoint(scrollViewPosition);
  }

  private void ClickViewInterior()
  {
    ClustercraftExteriorDoor component1 = this.reorderable.GetComponent<ClustercraftExteriorDoor>();
    PassengerRocketModule component2 = this.reorderable.GetComponent<PassengerRocketModule>();
    WorldContainer targetWorld = component1.GetTargetWorld();
    WorldContainer myWorld = component1.GetMyWorld();
    if ((UnityEngine.Object) ClusterManager.Instance.activeWorld == (UnityEngine.Object) targetWorld)
    {
      if (myWorld.id != (int) byte.MaxValue)
      {
        AudioMixer.instance.Stop(component2.interiorReverbSnapshot);
        AudioMixer.instance.PauseSpaceVisibleSnapshot(false);
        ClusterManager.Instance.SetActiveWorld(myWorld.id);
      }
    }
    else
    {
      AudioMixer.instance.Start(component2.interiorReverbSnapshot);
      AudioMixer.instance.PauseSpaceVisibleSnapshot(true);
      ClusterManager.Instance.SetActiveWorld(targetWorld.id);
    }
    DetailsScreen.Instance.ClearSecondarySideScreen();
    this.UpdateButtonStates();
  }
}
