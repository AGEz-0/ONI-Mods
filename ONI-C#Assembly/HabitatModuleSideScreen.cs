// Decompiled with JetBrains decompiler
// Type: HabitatModuleSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class HabitatModuleSideScreen : SideScreenContent
{
  private Clustercraft targetCraft;
  public GameObject moduleContentContainer;
  public GameObject modulePanelPrefab;

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
    return (UnityEngine.Object) target.GetComponent<Clustercraft>() != (UnityEngine.Object) null && (UnityEngine.Object) this.GetPassengerModule(target.GetComponent<Clustercraft>()) != (UnityEngine.Object) null;
  }

  public override void SetTarget(GameObject target)
  {
    base.SetTarget(target);
    this.targetCraft = target.GetComponent<Clustercraft>();
    this.RefreshModulePanel(this.GetPassengerModule(this.targetCraft));
  }

  private PassengerRocketModule GetPassengerModule(Clustercraft craft)
  {
    foreach (Ref<RocketModuleCluster> clusterModule in (IEnumerable<Ref<RocketModuleCluster>>) craft.GetComponent<CraftModuleInterface>().ClusterModules)
    {
      PassengerRocketModule component = clusterModule.Get().GetComponent<PassengerRocketModule>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        return component;
    }
    return (PassengerRocketModule) null;
  }

  private void RefreshModulePanel(PassengerRocketModule module)
  {
    HierarchyReferences component = this.GetComponent<HierarchyReferences>();
    component.GetReference<Image>("icon").sprite = Def.GetUISprite((object) module.gameObject).first;
    KButton reference = component.GetReference<KButton>("button");
    reference.ClearOnClick();
    reference.onClick += (System.Action) (() =>
    {
      AudioMixer.instance.Start(module.interiorReverbSnapshot);
      AudioMixer.instance.PauseSpaceVisibleSnapshot(true);
      ClusterManager.Instance.SetActiveWorld(module.GetComponent<ClustercraftExteriorDoor>().GetTargetWorld().id);
      ManagementMenu.Instance.CloseAll();
    });
    component.GetReference<LocText>("label").SetText(module.gameObject.GetProperName());
  }
}
