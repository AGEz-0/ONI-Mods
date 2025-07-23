// Decompiled with JetBrains decompiler
// Type: TemporalTearSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class TemporalTearSideScreen : SideScreenContent
{
  private Clustercraft targetCraft;

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
    Clustercraft component = target.GetComponent<Clustercraft>();
    TemporalTear temporalTear = ClusterManager.Instance.GetComponent<ClusterPOIManager>().GetTemporalTear();
    return (UnityEngine.Object) component != (UnityEngine.Object) null && (UnityEngine.Object) temporalTear != (UnityEngine.Object) null && temporalTear.Location == component.Location;
  }

  public override void SetTarget(GameObject target)
  {
    base.SetTarget(target);
    this.targetCraft = target.GetComponent<Clustercraft>();
    KButton reference = this.GetComponent<HierarchyReferences>().GetReference<KButton>("button");
    reference.ClearOnClick();
    reference.onClick += (System.Action) (() =>
    {
      target.GetComponent<Clustercraft>();
      ClusterManager.Instance.GetComponent<ClusterPOIManager>().GetTemporalTear().ConsumeCraft(this.targetCraft);
    });
    this.RefreshPanel();
  }

  private void RefreshPanel(object data = null)
  {
    TemporalTear temporalTear = ClusterManager.Instance.GetComponent<ClusterPOIManager>().GetTemporalTear();
    HierarchyReferences component = this.GetComponent<HierarchyReferences>();
    bool flag = temporalTear.IsOpen();
    component.GetReference<LocText>("label").SetText((string) (flag ? UI.UISIDESCREENS.TEMPORALTEARSIDESCREEN.BUTTON_OPEN : UI.UISIDESCREENS.TEMPORALTEARSIDESCREEN.BUTTON_CLOSED));
    component.GetReference<KButton>("button").isInteractable = flag;
  }
}
