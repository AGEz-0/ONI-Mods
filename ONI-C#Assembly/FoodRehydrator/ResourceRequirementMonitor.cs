// Decompiled with JetBrains decompiler
// Type: FoodRehydrator.ResourceRequirementMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace FoodRehydrator;

public class ResourceRequirementMonitor : KMonoBehaviour
{
  [MyCmpReq]
  private Operational operational;
  private Storage packages;
  private Storage water;
  private static readonly Operational.Flag flag = new Operational.Flag("HasSufficientResources", Operational.Flag.Type.Requirement);
  private static readonly EventSystem.IntraObjectHandler<ResourceRequirementMonitor> OnStorageChangedDelegate = new EventSystem.IntraObjectHandler<ResourceRequirementMonitor>((Action<ResourceRequirementMonitor, object>) ((component, data) => component.OnStorageChanged(data)));

  protected override void OnSpawn()
  {
    base.OnSpawn();
    Storage[] components = this.GetComponents<Storage>();
    DebugUtil.DevAssert(components.Length == 2, "Incorrect number of storages on foodrehydrator");
    this.packages = components[0];
    this.water = components[1];
    this.Subscribe<ResourceRequirementMonitor>(-1697596308, ResourceRequirementMonitor.OnStorageChangedDelegate);
  }

  protected float GetAvailableWater() => this.water.GetMassAvailable(GameTags.Water);

  protected bool HasSufficientResources()
  {
    return this.packages.items.Count > 0 && (double) this.GetAvailableWater() > 1.0;
  }

  protected void OnStorageChanged(object _)
  {
    this.operational.SetFlag(ResourceRequirementMonitor.flag, this.HasSufficientResources());
  }
}
