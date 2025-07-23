// Decompiled with JetBrains decompiler
// Type: RationBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/RationBox")]
public class RationBox : KMonoBehaviour, IUserControlledCapacity, IRender1000ms, IRottable
{
  [MyCmpReq]
  private Storage storage;
  [Serialize]
  private float userMaxCapacity = float.PositiveInfinity;
  private FilteredStorage filteredStorage;
  private static readonly EventSystem.IntraObjectHandler<RationBox> OnOperationalChangedDelegate = new EventSystem.IntraObjectHandler<RationBox>((Action<RationBox, object>) ((component, data) => component.OnOperationalChanged(data)));
  private static readonly EventSystem.IntraObjectHandler<RationBox> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<RationBox>((Action<RationBox, object>) ((component, data) => component.OnCopySettings(data)));

  protected override void OnPrefabInit()
  {
    this.filteredStorage = new FilteredStorage((KMonoBehaviour) this, new Tag[1]
    {
      GameTags.Compostable
    }, (IUserControlledCapacity) this, false, Db.Get().ChoreTypes.FoodFetch);
    this.Subscribe<RationBox>(-592767678, RationBox.OnOperationalChangedDelegate);
    this.Subscribe<RationBox>(-905833192, RationBox.OnCopySettingsDelegate);
    DiscoveredResources.Instance.Discover("FieldRation".ToTag(), GameTags.Edible);
  }

  protected override void OnSpawn()
  {
    Operational component = this.GetComponent<Operational>();
    component.SetActive(component.IsOperational);
    this.filteredStorage.FilterChanged();
  }

  protected override void OnCleanUp() => this.filteredStorage.CleanUp();

  private void OnOperationalChanged(object data)
  {
    Operational component = this.GetComponent<Operational>();
    component.SetActive(component.IsOperational);
  }

  private void OnCopySettings(object data)
  {
    GameObject gameObject = (GameObject) data;
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
      return;
    RationBox component = gameObject.GetComponent<RationBox>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return;
    this.UserMaxCapacity = component.UserMaxCapacity;
  }

  public void Render1000ms(float dt) => Rottable.SetStatusItems((IRottable) this);

  public float UserMaxCapacity
  {
    get => Mathf.Min(this.userMaxCapacity, this.storage.capacityKg);
    set
    {
      this.userMaxCapacity = value;
      this.filteredStorage.FilterChanged();
    }
  }

  public float AmountStored => this.storage.MassStored();

  public float MinCapacity => 0.0f;

  public float MaxCapacity => this.storage.capacityKg;

  public bool WholeValues => false;

  public LocString CapacityUnits => GameUtil.GetCurrentMassUnit();

  public float RotTemperature => 277.15f;

  public float PreserveTemperature => 255.15f;

  GameObject IRottable.get_gameObject() => this.gameObject;
}
