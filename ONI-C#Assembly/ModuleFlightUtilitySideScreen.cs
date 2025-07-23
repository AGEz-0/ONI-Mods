// Decompiled with JetBrains decompiler
// Type: ModuleFlightUtilitySideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ModuleFlightUtilitySideScreen : SideScreenContent
{
  private Clustercraft targetCraft;
  public GameObject moduleContentContainer;
  public GameObject modulePanelPrefab;
  public ColorStyleSetting repeatOff;
  public ColorStyleSetting repeatOn;
  private Dictionary<IEmptyableCargo, HierarchyReferences> modulePanels = new Dictionary<IEmptyableCargo, HierarchyReferences>();
  private List<int> refreshHandle = new List<int>();

  private CraftModuleInterface craftModuleInterface
  {
    get => this.targetCraft.GetComponent<CraftModuleInterface>();
  }

  protected override void OnShow(bool show)
  {
    base.OnShow(show);
    this.ConsumeMouseScroll = true;
  }

  public override float GetSortKey() => 21f;

  public override bool IsValidForTarget(GameObject target)
  {
    if ((UnityEngine.Object) target.GetComponent<Clustercraft>() != (UnityEngine.Object) null && this.HasFlightUtilityModule(target.GetComponent<CraftModuleInterface>()))
      return true;
    RocketControlStation component = target.GetComponent<RocketControlStation>();
    return (UnityEngine.Object) component != (UnityEngine.Object) null && this.HasFlightUtilityModule(component.GetMyWorld().GetComponent<Clustercraft>().ModuleInterface);
  }

  private bool HasFlightUtilityModule(CraftModuleInterface craftModuleInterface)
  {
    foreach (Ref<RocketModuleCluster> clusterModule in (IEnumerable<Ref<RocketModuleCluster>>) craftModuleInterface.ClusterModules)
    {
      if (clusterModule.Get().GetSMI<IEmptyableCargo>() != null)
        return true;
    }
    return false;
  }

  public override void SetTarget(GameObject target)
  {
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      foreach (int id in this.refreshHandle)
        target.Unsubscribe(id);
      this.refreshHandle.Clear();
    }
    base.SetTarget(target);
    this.targetCraft = target.GetComponent<Clustercraft>();
    if ((UnityEngine.Object) this.targetCraft == (UnityEngine.Object) null && (UnityEngine.Object) target.GetComponent<RocketControlStation>() != (UnityEngine.Object) null)
      this.targetCraft = target.GetMyWorld().GetComponent<Clustercraft>();
    this.refreshHandle.Add(this.targetCraft.gameObject.Subscribe(-1298331547, new Action<object>(this.RefreshAll)));
    this.refreshHandle.Add(this.targetCraft.gameObject.Subscribe(1792516731, new Action<object>(this.RefreshAll)));
    this.BuildModules();
  }

  private void ClearModules()
  {
    foreach (KeyValuePair<IEmptyableCargo, HierarchyReferences> modulePanel in this.modulePanels)
      Util.KDestroyGameObject(modulePanel.Value.gameObject);
    this.modulePanels.Clear();
  }

  private void BuildModules()
  {
    this.ClearModules();
    foreach (Ref<RocketModuleCluster> clusterModule in (IEnumerable<Ref<RocketModuleCluster>>) this.craftModuleInterface.ClusterModules)
    {
      IEmptyableCargo smi = clusterModule.Get().GetSMI<IEmptyableCargo>();
      if (smi != null)
      {
        HierarchyReferences hierarchyReferences = Util.KInstantiateUI<HierarchyReferences>(this.modulePanelPrefab, this.moduleContentContainer, true);
        this.modulePanels.Add(smi, hierarchyReferences);
        this.RefreshModulePanel(smi);
      }
    }
  }

  private void RefreshAll(object data = null) => this.BuildModules();

  private void RefreshModulePanel(IEmptyableCargo module)
  {
    HierarchyReferences modulePanel = this.modulePanels[module];
    modulePanel.GetReference<Image>("icon").sprite = Def.GetUISprite((object) module.master.gameObject).first;
    KButton reference1 = modulePanel.GetReference<KButton>("button");
    reference1.isInteractable = module.CanEmptyCargo();
    reference1.ClearOnClick();
    reference1.onClick += new System.Action(module.EmptyCargo);
    KButton reference2 = modulePanel.GetReference<KButton>("repeatButton");
    if (module.CanAutoDeploy)
    {
      this.StyleRepeatButton(module);
      reference2.ClearOnClick();
      reference2.onClick += (System.Action) (() => this.OnRepeatClicked(module));
      reference2.gameObject.SetActive(true);
    }
    else
      reference2.gameObject.SetActive(false);
    DropDown reference3 = modulePanel.GetReference<DropDown>("dropDown");
    reference3.targetDropDownContainer = GameScreenManager.Instance.ssOverlayCanvas;
    reference3.Close();
    CrewPortrait reference4 = modulePanel.GetReference<CrewPortrait>("selectedPortrait");
    WorldContainer component = (module as StateMachine.Instance).GetMaster().GetComponent<RocketModuleCluster>().CraftInterface.GetComponent<WorldContainer>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null && module.ChooseDuplicant)
    {
      if ((UnityEngine.Object) module.ChosenDuplicant != (UnityEngine.Object) null && module.ChosenDuplicant.HasTag(GameTags.Dead))
        module.ChosenDuplicant = (MinionIdentity) null;
      int id = component.id;
      reference3.gameObject.SetActive(true);
      reference3.Initialize((IEnumerable<IListableOption>) Components.LiveMinionIdentities.GetWorldItems(id), new Action<IListableOption, object>(this.OnDuplicantEntryClick), refreshAction: new Action<DropDownEntry, object>(this.DropDownEntryRefreshAction), targetData: (object) module);
      reference3.selectedLabel.text = (UnityEngine.Object) module.ChosenDuplicant != (UnityEngine.Object) null ? this.GetDuplicantRowName(module.ChosenDuplicant) : STRINGS.UI.UISIDESCREENS.MODULEFLIGHTUTILITYSIDESCREEN.SELECT_DUPLICANT.ToString();
      reference4.gameObject.SetActive(true);
      reference4.SetIdentityObject((IAssignableIdentity) module.ChosenDuplicant, false);
      reference3.openButton.isInteractable = !module.ModuleDeployed;
    }
    else
    {
      reference3.gameObject.SetActive(false);
      reference4.gameObject.SetActive(false);
    }
    modulePanel.GetReference<LocText>("label").SetText(module.master.gameObject.GetProperName());
  }

  private string GetDuplicantRowName(MinionIdentity minion)
  {
    MinionResume component = minion.GetComponent<MinionResume>();
    return (UnityEngine.Object) component != (UnityEngine.Object) null && component.HasPerk(Db.Get().SkillPerks.CanUseRocketControlStation) ? string.Format((string) STRINGS.UI.UISIDESCREENS.MODULEFLIGHTUTILITYSIDESCREEN.PILOT_FMT, (object) minion.GetProperName()) : minion.GetProperName();
  }

  private void OnRepeatClicked(IEmptyableCargo module)
  {
    module.AutoDeploy = !module.AutoDeploy;
    this.StyleRepeatButton(module);
  }

  private void OnDuplicantEntryClick(IListableOption option, object data)
  {
    MinionIdentity minionIdentity = (MinionIdentity) option;
    IEmptyableCargo key = (IEmptyableCargo) data;
    key.ChosenDuplicant = minionIdentity;
    HierarchyReferences modulePanel = this.modulePanels[key];
    modulePanel.GetReference<DropDown>("dropDown").selectedLabel.text = (UnityEngine.Object) key.ChosenDuplicant != (UnityEngine.Object) null ? this.GetDuplicantRowName(key.ChosenDuplicant) : STRINGS.UI.UISIDESCREENS.MODULEFLIGHTUTILITYSIDESCREEN.SELECT_DUPLICANT.ToString();
    modulePanel.GetReference<CrewPortrait>("selectedPortrait").SetIdentityObject((IAssignableIdentity) key.ChosenDuplicant, false);
    this.RefreshAll();
  }

  private void DropDownEntryRefreshAction(DropDownEntry entry, object targetData)
  {
    MinionIdentity entryData = (MinionIdentity) entry.entryData;
    entry.label.text = this.GetDuplicantRowName(entryData);
    entry.portrait.SetIdentityObject((IAssignableIdentity) entryData, false);
    bool flag = false;
    foreach (Ref<RocketModuleCluster> clusterModule in (IEnumerable<Ref<RocketModuleCluster>>) this.targetCraft.ModuleInterface.ClusterModules)
    {
      RocketModuleCluster cmp = clusterModule.Get();
      if (!((UnityEngine.Object) cmp == (UnityEngine.Object) null))
      {
        IEmptyableCargo smi = cmp.GetSMI<IEmptyableCargo>();
        if (smi != null && !((UnityEngine.Object) ((IEmptyableCargo) targetData).ChosenDuplicant == (UnityEngine.Object) entryData))
          flag = flag || (UnityEngine.Object) smi.ChosenDuplicant == (UnityEngine.Object) entryData;
      }
    }
    entry.button.isInteractable = !flag;
  }

  private void StyleRepeatButton(IEmptyableCargo module)
  {
    KButton reference = this.modulePanels[module].GetReference<KButton>("repeatButton");
    reference.bgImage.colorStyleSetting = module.AutoDeploy ? this.repeatOn : this.repeatOff;
    reference.bgImage.ApplyColorStyleSetting();
  }
}
