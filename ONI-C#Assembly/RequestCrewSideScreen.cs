// Decompiled with JetBrains decompiler
// Type: RequestCrewSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class RequestCrewSideScreen : SideScreenContent
{
  private PassengerRocketModule rocketModule;
  public KToggle crewReleaseButton;
  public KToggle crewRequestButton;
  private Dictionary<KToggle, PassengerRocketModule.RequestCrewState> toggleMap = new Dictionary<KToggle, PassengerRocketModule.RequestCrewState>();
  public KButton changeCrewButton;
  public KScreen changeCrewSideScreenPrefab;
  private AssignmentGroupControllerSideScreen activeChangeCrewSideScreen;

  protected override void OnSpawn()
  {
    this.changeCrewButton.onClick += new System.Action(this.OnChangeCrewButtonPressed);
    this.crewReleaseButton.onClick += new System.Action(this.CrewRelease);
    this.crewRequestButton.onClick += new System.Action(this.CrewRequest);
    this.toggleMap.Add(this.crewReleaseButton, PassengerRocketModule.RequestCrewState.Release);
    this.toggleMap.Add(this.crewRequestButton, PassengerRocketModule.RequestCrewState.Request);
    this.Refresh();
  }

  public override int GetSideScreenSortOrder() => 100;

  public override bool IsValidForTarget(GameObject target)
  {
    PassengerRocketModule component1 = target.GetComponent<PassengerRocketModule>();
    RocketControlStation component2 = target.GetComponent<RocketControlStation>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
      return (UnityEngine.Object) component1.GetMyWorld() != (UnityEngine.Object) null;
    if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
      return false;
    RocketControlStation.StatesInstance smi = component2.GetSMI<RocketControlStation.StatesInstance>();
    return !smi.sm.IsInFlight(smi) && !smi.sm.IsLaunching(smi);
  }

  public override void SetTarget(GameObject target)
  {
    this.rocketModule = !((UnityEngine.Object) target.GetComponent<RocketControlStation>() != (UnityEngine.Object) null) ? target.GetComponent<PassengerRocketModule>() : target.GetMyWorld().GetComponent<Clustercraft>().ModuleInterface.GetPassengerModule();
    this.Refresh();
  }

  private void Refresh() => this.RefreshRequestButtons();

  private void CrewRelease()
  {
    this.rocketModule.RequestCrewBoard(PassengerRocketModule.RequestCrewState.Release);
    this.RefreshRequestButtons();
  }

  private void CrewRequest()
  {
    this.rocketModule.RequestCrewBoard(PassengerRocketModule.RequestCrewState.Request);
    this.RefreshRequestButtons();
  }

  private void RefreshRequestButtons()
  {
    foreach (KeyValuePair<KToggle, PassengerRocketModule.RequestCrewState> toggle in this.toggleMap)
      this.RefreshRequestButton(toggle.Key);
  }

  private void RefreshRequestButton(KToggle button)
  {
    if (this.toggleMap[button] == this.rocketModule.PassengersRequested)
    {
      button.isOn = true;
      foreach (ImageToggleState componentsInChild in button.GetComponentsInChildren<ImageToggleState>())
        componentsInChild.SetActive();
      button.GetComponent<ImageToggleStateThrobber>().enabled = false;
    }
    else
    {
      button.isOn = false;
      foreach (ImageToggleState componentsInChild in button.GetComponentsInChildren<ImageToggleState>())
        componentsInChild.SetInactive();
      button.GetComponent<ImageToggleStateThrobber>().enabled = false;
    }
  }

  private void OnChangeCrewButtonPressed()
  {
    if ((UnityEngine.Object) this.activeChangeCrewSideScreen == (UnityEngine.Object) null)
    {
      this.activeChangeCrewSideScreen = (AssignmentGroupControllerSideScreen) DetailsScreen.Instance.SetSecondarySideScreen(this.changeCrewSideScreenPrefab, (string) UI.UISIDESCREENS.ASSIGNMENTGROUPCONTROLLER.TITLE);
      this.activeChangeCrewSideScreen.SetTarget(this.rocketModule.gameObject);
    }
    else
    {
      DetailsScreen.Instance.ClearSecondarySideScreen();
      this.activeChangeCrewSideScreen = (AssignmentGroupControllerSideScreen) null;
    }
  }

  protected override void OnShow(bool show)
  {
    base.OnShow(show);
    if (show)
      return;
    DetailsScreen.Instance.ClearSecondarySideScreen();
    this.activeChangeCrewSideScreen = (AssignmentGroupControllerSideScreen) null;
  }
}
