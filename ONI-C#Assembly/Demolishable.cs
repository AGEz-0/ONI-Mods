﻿// Decompiled with JetBrains decompiler
// Type: Demolishable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System;
using TUNING;
using UnityEngine;

#nullable disable
[RequireComponent(typeof (Prioritizable))]
public class Demolishable : Workable
{
  public Chore chore;
  public bool allowDemolition = true;
  [Serialize]
  private bool isMarkedForDemolition;
  private bool destroyed;
  private static readonly EventSystem.IntraObjectHandler<Demolishable> OnRefreshUserMenuDelegate = new EventSystem.IntraObjectHandler<Demolishable>((Action<Demolishable, object>) ((component, data) => component.OnRefreshUserMenu(data)));
  private static readonly EventSystem.IntraObjectHandler<Demolishable> OnCancelDelegate = new EventSystem.IntraObjectHandler<Demolishable>((Action<Demolishable, object>) ((component, data) => component.OnCancel(data)));
  private static readonly EventSystem.IntraObjectHandler<Demolishable> OnDeconstructDelegate = new EventSystem.IntraObjectHandler<Demolishable>((Action<Demolishable, object>) ((component, data) => component.OnDemolish(data)));

  public bool HasBeenDestroyed => this.destroyed;

  private CellOffset[] placementOffsets
  {
    get
    {
      Building component1 = this.GetComponent<Building>();
      if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        return component1.Def.PlacementOffsets;
      OccupyArea component2 = this.GetComponent<OccupyArea>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
        return component2.OccupiedCellsOffsets;
      Debug.Assert(false, (object) "Ack! We put a Demolishable on something that's neither a Building nor OccupyArea!", (UnityEngine.Object) this);
      return (CellOffset[]) null;
    }
  }

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.requiredSkillPerk = Db.Get().SkillPerks.CanDemolish.Id;
    this.faceTargetWhenWorking = true;
    this.synchronizeAnims = false;
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Deconstructing;
    this.attributeConverter = Db.Get().AttributeConverters.ConstructionSpeed;
    this.attributeExperienceMultiplier = DUPLICANTSTATS.ATTRIBUTE_LEVELING.MOST_DAY_EXPERIENCE;
    this.minimumAttributeMultiplier = 0.75f;
    this.skillExperienceSkillGroup = Db.Get().SkillGroups.Building.Id;
    this.skillExperienceMultiplier = SKILLS.MOST_DAY_EXPERIENCE;
    this.multitoolContext = (HashedString) "demolish";
    this.multitoolHitEffectTag = (Tag) EffectConfigs.DemolishSplashId;
    this.workingPstComplete = (HashedString[]) null;
    this.workingPstFailed = (HashedString[]) null;
    Building component = this.GetComponent<Building>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.Def.IsTilePiece)
      this.SetWorkTime(component.Def.ConstructionTime * 0.5f);
    else
      this.SetWorkTime(30f);
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.Subscribe<Demolishable>(493375141, Demolishable.OnRefreshUserMenuDelegate);
    this.Subscribe<Demolishable>(-111137758, Demolishable.OnRefreshUserMenuDelegate);
    this.Subscribe<Demolishable>(2127324410, Demolishable.OnCancelDelegate);
    this.Subscribe<Demolishable>(-790448070, Demolishable.OnDeconstructDelegate);
    CellOffset[][] table = OffsetGroups.InvertedStandardTable;
    CellOffset[] filter = (CellOffset[]) null;
    Building component = this.GetComponent<Building>();
    if ((UnityEngine.Object) component != (UnityEngine.Object) null && component.Def.IsTilePiece)
    {
      table = OffsetGroups.InvertedStandardTableWithCorners;
      filter = component.Def.ConstructionOffsetFilter;
    }
    this.SetOffsetTable(OffsetGroups.BuildReachabilityTable(this.placementOffsets, table, filter));
    if (!this.isMarkedForDemolition)
      return;
    this.QueueDemolition();
  }

  protected override void OnStartWork(WorkerBase worker)
  {
    this.progressBar.barColor = ProgressBarsConfig.Instance.GetBarColor("DeconstructBar");
    this.GetComponent<KSelectable>().RemoveStatusItem(Db.Get().BuildingStatusItems.PendingDemolition);
  }

  protected override void OnCompleteWork(WorkerBase worker) => this.TriggerDestroy();

  private void TriggerDestroy()
  {
    if ((UnityEngine.Object) this == (UnityEngine.Object) null || this.destroyed)
      return;
    this.destroyed = true;
    this.isMarkedForDemolition = false;
    this.gameObject.DeleteObject();
  }

  private void QueueDemolition()
  {
    if (DebugHandler.InstantBuildMode)
    {
      this.OnCompleteWork((WorkerBase) null);
    }
    else
    {
      if (this.chore == null)
      {
        Prioritizable.AddRef(this.gameObject);
        this.requiredSkillPerk = Db.Get().SkillPerks.CanDemolish.Id;
        this.chore = (Chore) new WorkChore<Demolishable>(Db.Get().ChoreTypes.Demolish, (IStateMachineTarget) this, only_when_operational: false, override_anims: Assets.GetAnim((HashedString) "anim_interacts_clothingfactory_kanim"), is_preemptable: true, ignore_building_assignment: true);
        this.GetComponent<KSelectable>().AddStatusItem(Db.Get().BuildingStatusItems.PendingDemolition, (object) this);
        this.isMarkedForDemolition = true;
        this.Trigger(2108245096, (object) "Demolish");
      }
      this.UpdateStatusItem((object) null);
    }
  }

  private void OnRefreshUserMenu(object data)
  {
    if (!this.allowDemolition)
      return;
    Game.Instance.userMenu.AddButton(this.gameObject, this.chore == null ? new KIconButtonMenu.ButtonInfo("action_deconstruct", (string) UI.USERMENUACTIONS.DEMOLISH.NAME, new System.Action(this.OnDemolish), tooltipText: (string) UI.USERMENUACTIONS.DEMOLISH.TOOLTIP) : new KIconButtonMenu.ButtonInfo("action_deconstruct", (string) UI.USERMENUACTIONS.DEMOLISH.NAME_OFF, new System.Action(this.OnDemolish), tooltipText: (string) UI.USERMENUACTIONS.DEMOLISH.TOOLTIP_OFF), 0.0f);
  }

  public void CancelDemolition()
  {
    if (this.chore != null)
    {
      this.chore.Cancel("Cancelled demolition");
      this.chore = (Chore) null;
      this.GetComponent<KSelectable>().RemoveStatusItem(Db.Get().BuildingStatusItems.PendingDemolition);
      this.ShowProgressBar(false);
      this.isMarkedForDemolition = false;
      Prioritizable.RemoveRef(this.gameObject);
    }
    this.UpdateStatusItem((object) null);
  }

  private void OnCancel(object data) => this.CancelDemolition();

  private void OnDemolish(object data)
  {
    if (!this.allowDemolition && !DebugHandler.InstantBuildMode)
      return;
    this.QueueDemolition();
  }

  private void OnDemolish()
  {
    if (this.chore == null)
      this.QueueDemolition();
    else
      this.CancelDemolition();
  }

  protected override void UpdateStatusItem(object data = null)
  {
    this.shouldShowSkillPerkStatusItem = this.isMarkedForDemolition;
    base.UpdateStatusItem(data);
  }
}
