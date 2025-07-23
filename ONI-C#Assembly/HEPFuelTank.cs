﻿// Decompiled with JetBrains decompiler
// Type: HEPFuelTank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class HEPFuelTank : KMonoBehaviour, IFuelTank, IUserControlledCapacity
{
  [MyCmpReq]
  public HighEnergyParticleStorage hepStorage;
  [Serialize]
  public float userMaxCapacity;
  public float physicalFuelCapacity;
  private MeterController m_meter;
  public bool consumeFuelOnLand;
  private static readonly EventSystem.IntraObjectHandler<HEPFuelTank> OnStorageChangedDelegate = new EventSystem.IntraObjectHandler<HEPFuelTank>((Action<HEPFuelTank, object>) ((component, data) => component.OnStorageChange(data)));
  [MyCmpAdd]
  private CopyBuildingSettings copyBuildingSettings;
  private static readonly EventSystem.IntraObjectHandler<HEPFuelTank> OnCopySettingsDelegate = new EventSystem.IntraObjectHandler<HEPFuelTank>((Action<HEPFuelTank, object>) ((component, data) => component.OnCopySettings(data)));

  public IStorage Storage => (IStorage) this.hepStorage;

  public bool ConsumeFuelOnLand => this.consumeFuelOnLand;

  public void DEBUG_FillTank()
  {
    double num = (double) this.hepStorage.Store(this.hepStorage.RemainingCapacity());
  }

  public float UserMaxCapacity
  {
    get => this.hepStorage.capacity;
    set
    {
      this.hepStorage.capacity = value;
      this.Trigger(-795826715, (object) this);
    }
  }

  public float MinCapacity => 0.0f;

  public float MaxCapacity => this.physicalFuelCapacity;

  public float AmountStored => this.hepStorage.Particles;

  public bool WholeValues => false;

  public LocString CapacityUnits => UI.UNITSUFFIXES.HIGHENERGYPARTICLES.PARTRICLES;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.GetComponent<RocketModule>().AddModuleCondition(ProcessCondition.ProcessConditionType.RocketStorage, (ProcessCondition) new ConditionProperlyFueled((IFuelTank) this));
    this.m_meter = new MeterController((KAnimControllerBase) this.GetComponent<KBatchedAnimController>(), "meter_target", "meter", Meter.Offset.Infront, Grid.SceneLayer.NoLayer, new string[4]
    {
      "meter_target",
      "meter_fill",
      "meter_frame",
      "meter_OL"
    });
    this.m_meter.gameObject.GetComponent<KBatchedAnimTracker>().matchParentOffset = true;
    this.OnStorageChange((object) null);
    this.Subscribe<HEPFuelTank>(-795826715, HEPFuelTank.OnStorageChangedDelegate);
    this.Subscribe<HEPFuelTank>(-1837862626, HEPFuelTank.OnStorageChangedDelegate);
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe<HEPFuelTank>(-905833192, HEPFuelTank.OnCopySettingsDelegate);
  }

  private void OnStorageChange(object data)
  {
    this.m_meter.SetPositionPercent(this.hepStorage.Particles / Mathf.Max(1f, this.hepStorage.capacity));
  }

  private void OnCopySettings(object data)
  {
    HEPFuelTank component = ((GameObject) data).GetComponent<HEPFuelTank>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    this.UserMaxCapacity = component.UserMaxCapacity;
  }
}
