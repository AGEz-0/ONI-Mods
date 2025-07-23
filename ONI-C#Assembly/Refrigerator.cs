// Decompiled with JetBrains decompiler
// Type: Refrigerator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/Refrigerator")]
public class Refrigerator : KMonoBehaviour, IUserControlledCapacity
{
  [MyCmpGet]
  private Storage storage;
  [MyCmpGet]
  private Operational operational;
  [MyCmpGet]
  private LogicPorts ports;
  [Serialize]
  private float userMaxCapacity = float.PositiveInfinity;
  private FilteredStorage filteredStorage;
  private static readonly EventSystem.IntraObjectHandler<Refrigerator> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<Refrigerator>((Action<Refrigerator, object>) ((component, data) => component.OnCopySettings(data)));
  private static readonly EventSystem.IntraObjectHandler<Refrigerator> UpdateLogicCircuitCBDelegate = new EventSystem.IntraObjectHandler<Refrigerator>((Action<Refrigerator, object>) ((component, data) => component.UpdateLogicCircuitCB(data)));

  protected override void OnPrefabInit()
  {
    this.filteredStorage = new FilteredStorage((KMonoBehaviour) this, new Tag[1]
    {
      GameTags.Compostable
    }, (IUserControlledCapacity) this, true, Db.Get().ChoreTypes.FoodFetch);
  }

  protected override void OnSpawn()
  {
    this.GetComponent<KAnimControllerBase>().Play((HashedString) "off");
    FoodStorage component = this.GetComponent<FoodStorage>();
    component.FilteredStorage = this.filteredStorage;
    component.SpicedFoodOnly = component.SpicedFoodOnly;
    this.filteredStorage.FilterChanged();
    this.UpdateLogicCircuit();
    this.Subscribe<Refrigerator>(-905833192, Refrigerator.OnCopySettingsDelegate);
    this.Subscribe<Refrigerator>(-1697596308, Refrigerator.UpdateLogicCircuitCBDelegate);
    this.Subscribe<Refrigerator>(-592767678, Refrigerator.UpdateLogicCircuitCBDelegate);
  }

  protected override void OnCleanUp() => this.filteredStorage.CleanUp();

  public bool IsActive() => this.operational.IsActive;

  private void OnCopySettings(object data)
  {
    GameObject gameObject = (GameObject) data;
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
      return;
    Refrigerator component = gameObject.GetComponent<Refrigerator>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return;
    this.UserMaxCapacity = component.UserMaxCapacity;
  }

  public float UserMaxCapacity
  {
    get => Mathf.Min(this.userMaxCapacity, this.storage.capacityKg);
    set
    {
      this.userMaxCapacity = value;
      this.filteredStorage.FilterChanged();
      this.UpdateLogicCircuit();
    }
  }

  public float AmountStored => this.storage.MassStored();

  public float MinCapacity => 0.0f;

  public float MaxCapacity => this.storage.capacityKg;

  public bool WholeValues => false;

  public LocString CapacityUnits => GameUtil.GetCurrentMassUnit();

  private void UpdateLogicCircuitCB(object data) => this.UpdateLogicCircuit();

  private void UpdateLogicCircuit()
  {
    bool on = this.filteredStorage.IsFull() & this.operational.IsOperational;
    this.ports.SendSignal(FilteredStorage.FULL_PORT_ID, on ? 1 : 0);
    this.filteredStorage.SetLogicMeter(on);
  }
}
