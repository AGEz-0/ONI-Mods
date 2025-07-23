﻿// Decompiled with JetBrains decompiler
// Type: Edible
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using KSerialization;
using STRINGS;
using System;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/Edible")]
public class Edible : Workable, IGameObjectEffectDescriptor, ISaveLoadable, IExtendSplitting
{
  private PrimaryElement primaryElement;
  public string FoodID;
  private EdiblesManager.FoodInfo foodInfo;
  public float unitsConsumed = float.NaN;
  public float caloriesConsumed = float.NaN;
  private float totalFeedingTime = float.NaN;
  private float totalUnits = float.NaN;
  private float totalConsumableCalories = float.NaN;
  [Serialize]
  private List<SpiceInstance> spices = new List<SpiceInstance>();
  private AttributeModifier caloriesModifier = new AttributeModifier("CaloriesDelta", 50000f, (string) DUPLICANTS.MODIFIERS.EATINGCALORIES.NAME, uiOnly: true);
  private AttributeModifier caloriesLitSpaceModifier = new AttributeModifier("CaloriesDelta", (float) ((1.0 + (double) DUPLICANTSTATS.STANDARD.Light.LIGHT_WORK_EFFICIENCY_BONUS) / 1.9999999494757503E-05), (string) DUPLICANTS.MODIFIERS.EATINGCALORIES.NAME, uiOnly: true);
  private AttributeModifier currentModifier;
  private static readonly EventSystem.IntraObjectHandler<Edible> OnCraftDelegate = new EventSystem.IntraObjectHandler<Edible>((Action<Edible, object>) ((component, data) => component.OnCraft(data)));
  private static readonly HashedString[] normalWorkAnims = new HashedString[2]
  {
    (HashedString) "working_pre",
    (HashedString) "working_loop"
  };
  private static readonly HashedString[] hatWorkAnims = new HashedString[2]
  {
    (HashedString) "hat_pre",
    (HashedString) "working_loop"
  };
  private static readonly HashedString[] saltWorkAnims = new HashedString[2]
  {
    (HashedString) "salt_pre",
    (HashedString) "salt_loop"
  };
  private static readonly HashedString[] saltHatWorkAnims = new HashedString[2]
  {
    (HashedString) "salt_hat_pre",
    (HashedString) "salt_hat_loop"
  };
  private static readonly HashedString[] normalWorkPstAnim = new HashedString[1]
  {
    (HashedString) "working_pst"
  };
  private static readonly HashedString[] hatWorkPstAnim = new HashedString[1]
  {
    (HashedString) "hat_pst"
  };
  private static readonly HashedString[] saltWorkPstAnim = new HashedString[1]
  {
    (HashedString) "salt_pst"
  };
  private static readonly HashedString[] saltHatWorkPstAnim = new HashedString[1]
  {
    (HashedString) "salt_hat_pst"
  };
  private static Dictionary<int, string> qualityEffects = new Dictionary<int, string>()
  {
    {
      -1,
      "EdibleMinus3"
    },
    {
      0,
      "EdibleMinus2"
    },
    {
      1,
      "EdibleMinus1"
    },
    {
      2,
      "Edible0"
    },
    {
      3,
      "Edible1"
    },
    {
      4,
      "Edible2"
    },
    {
      5,
      "Edible3"
    }
  };

  public float Units
  {
    get => this.primaryElement.Units;
    set => this.primaryElement.Units = value;
  }

  public float MassPerUnit => this.primaryElement.MassPerUnit;

  public float Calories
  {
    get => this.Units * this.foodInfo.CaloriesPerUnit;
    set => this.Units = value / this.foodInfo.CaloriesPerUnit;
  }

  public EdiblesManager.FoodInfo FoodInfo
  {
    get => this.foodInfo;
    set
    {
      this.foodInfo = value;
      this.FoodID = this.foodInfo.Id;
    }
  }

  public bool isBeingConsumed { get; private set; }

  public List<SpiceInstance> Spices => this.spices;

  protected override void OnPrefabInit()
  {
    this.primaryElement = this.GetComponent<PrimaryElement>();
    this.SetReportType(ReportManager.ReportType.PersonalTime);
    this.showProgressBar = false;
    this.SetOffsetTable(OffsetGroups.InvertedStandardTable);
    this.shouldTransferDiseaseWithWorker = false;
    base.OnPrefabInit();
    if (this.foodInfo == null)
    {
      if (this.FoodID == null)
        Debug.LogError((object) "No food FoodID");
      this.foodInfo = EdiblesManager.GetFoodInfo(this.FoodID);
    }
    this.Subscribe<Edible>(748399584, Edible.OnCraftDelegate);
    this.Subscribe<Edible>(1272413801, Edible.OnCraftDelegate);
    this.workerStatusItem = Db.Get().DuplicantStatusItems.Eating;
    this.synchronizeAnims = false;
    Components.Edibles.Add(this);
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.ToggleGenericSpicedTag(this.gameObject.HasTag(GameTags.SpicedFood));
    if (this.spices != null)
    {
      for (int index = 0; index < this.spices.Count; ++index)
        this.ApplySpiceEffects(this.spices[index], SpiceGrinderConfig.SpicedStatus);
    }
    if (this.GetComponent<KPrefabID>().HasTag(GameTags.Rehydrated))
      this.GetComponent<KSelectable>().AddStatusItem(Db.Get().MiscStatusItems.RehydratedFood);
    this.GetComponent<KSelectable>().SetStatusItem(Db.Get().StatusItemCategories.Main, Db.Get().MiscStatusItems.Edible, (object) this);
  }

  public override HashedString[] GetWorkAnims(WorkerBase worker)
  {
    EatChore.StatesInstance smi = worker.GetSMI<EatChore.StatesInstance>();
    bool flag = smi != null && smi.UseSalt();
    MinionResume component = worker.GetComponent<MinionResume>();
    return (UnityEngine.Object) component != (UnityEngine.Object) null && component.CurrentHat != null ? (!flag ? Edible.hatWorkAnims : Edible.saltHatWorkAnims) : (!flag ? Edible.normalWorkAnims : Edible.saltWorkAnims);
  }

  public override HashedString[] GetWorkPstAnims(WorkerBase worker, bool successfully_completed)
  {
    EatChore.StatesInstance smi = worker.GetSMI<EatChore.StatesInstance>();
    bool flag = smi != null && smi.UseSalt();
    MinionResume component = worker.GetComponent<MinionResume>();
    return (UnityEngine.Object) component != (UnityEngine.Object) null && component.CurrentHat != null ? (!flag ? Edible.hatWorkPstAnim : Edible.saltHatWorkPstAnim) : (!flag ? Edible.normalWorkPstAnim : Edible.saltWorkPstAnim);
  }

  private void OnCraft(object data)
  {
    WorldResourceAmountTracker<RationTracker>.Get().RegisterAmountProduced(this.Calories);
  }

  public float GetFeedingTime(WorkerBase worker)
  {
    float feedingTime = this.Calories * 2E-05f;
    if ((UnityEngine.Object) worker != (UnityEngine.Object) null)
    {
      BingeEatChore.StatesInstance smi = worker.GetSMI<BingeEatChore.StatesInstance>();
      if (smi != null && smi.IsBingeEating())
        feedingTime /= 2f;
    }
    return feedingTime;
  }

  protected override void OnStartWork(WorkerBase worker)
  {
    this.totalFeedingTime = this.GetFeedingTime(worker);
    this.SetWorkTime(this.totalFeedingTime);
    this.caloriesConsumed = 0.0f;
    this.unitsConsumed = 0.0f;
    this.totalUnits = this.Units;
    worker.GetComponent<KPrefabID>().AddTag(GameTags.AlwaysConverse);
    this.totalConsumableCalories = this.Units * this.foodInfo.CaloriesPerUnit;
    this.StartConsuming();
  }

  protected override bool OnWorkTick(WorkerBase worker, float dt)
  {
    if (this.currentlyLit)
    {
      if (this.currentModifier != this.caloriesLitSpaceModifier)
      {
        worker.GetAttributes().Remove(this.currentModifier);
        worker.GetAttributes().Add(this.caloriesLitSpaceModifier);
        this.currentModifier = this.caloriesLitSpaceModifier;
      }
    }
    else if (this.currentModifier != this.caloriesModifier)
    {
      worker.GetAttributes().Remove(this.currentModifier);
      worker.GetAttributes().Add(this.caloriesModifier);
      this.currentModifier = this.caloriesModifier;
    }
    return this.OnTickConsume(worker, dt);
  }

  protected override void OnStopWork(WorkerBase worker)
  {
    if (this.currentModifier != null)
    {
      worker.GetAttributes().Remove(this.currentModifier);
      this.currentModifier = (AttributeModifier) null;
    }
    worker.GetComponent<KPrefabID>().RemoveTag(GameTags.AlwaysConverse);
    this.StopConsuming(worker);
  }

  private bool OnTickConsume(WorkerBase worker, float dt)
  {
    if (!this.isBeingConsumed)
    {
      DebugUtil.DevLogError("OnTickConsume while we're not eating, this would set a NaN mass on this Edible");
      return true;
    }
    bool flag = false;
    float num1 = dt / this.totalFeedingTime;
    float num2 = num1 * this.totalConsumableCalories;
    if ((double) this.caloriesConsumed + (double) num2 > (double) this.totalConsumableCalories)
      num2 = this.totalConsumableCalories - this.caloriesConsumed;
    this.caloriesConsumed += num2;
    worker.GetAmounts().Get("Calories").value += num2;
    float num3 = this.totalUnits * num1;
    if ((double) this.Units - (double) num3 < 0.0)
      num3 = this.Units;
    this.Units -= num3;
    this.unitsConsumed += num3;
    if ((double) this.Units <= 0.0)
      flag = true;
    return flag;
  }

  public void SpiceEdible(SpiceInstance spice, StatusItem status)
  {
    this.spices.Add(spice);
    this.ApplySpiceEffects(spice, status);
  }

  protected virtual void ApplySpiceEffects(SpiceInstance spice, StatusItem status)
  {
    this.GetComponent<KPrefabID>().AddTag(spice.Id, true);
    this.ToggleGenericSpicedTag(true);
    this.GetComponent<KSelectable>().AddStatusItem(status, (object) this.spices);
    if (spice.FoodModifier != null)
      this.gameObject.GetAttributes().Add(spice.FoodModifier);
    if (spice.CalorieModifier == null)
      return;
    this.Calories += spice.CalorieModifier.Value;
  }

  private void ToggleGenericSpicedTag(bool isSpiced)
  {
    KPrefabID component = this.GetComponent<KPrefabID>();
    if (isSpiced)
    {
      component.RemoveTag(GameTags.UnspicedFood);
      component.AddTag(GameTags.SpicedFood, true);
    }
    else
    {
      component.RemoveTag(GameTags.SpicedFood);
      component.AddTag(GameTags.UnspicedFood);
    }
  }

  public bool CanAbsorb(Edible other)
  {
    bool flag = ((this.spices.Count == other.spices.Count & this.gameObject.HasTag(GameTags.Rehydrated) == other.gameObject.HasTag(GameTags.Rehydrated) ? 1 : 0) & (this.gameObject.HasTag(GameTags.Dehydrated) ? 0 : (!other.gameObject.HasTag(GameTags.Dehydrated) ? 1 : 0))) != 0;
    for (int index1 = 0; flag && index1 < this.spices.Count; ++index1)
    {
      for (int index2 = 0; flag && index2 < other.spices.Count; ++index2)
        flag = this.spices[index1].Id == other.spices[index2].Id;
    }
    return flag;
  }

  private void StartConsuming()
  {
    DebugUtil.DevAssert(!this.isBeingConsumed, "Can't StartConsuming()...we've already started");
    this.isBeingConsumed = true;
    this.worker.Trigger(1406130139, (object) this);
  }

  private void StopConsuming(WorkerBase worker)
  {
    DebugUtil.DevAssert(this.isBeingConsumed, "StopConsuming() called without StartConsuming()");
    this.isBeingConsumed = false;
    for (int index = 0; index < this.foodInfo.Effects.Count; ++index)
      worker.GetComponent<Effects>().Add(this.foodInfo.Effects[index], true);
    ReportManager.Instance.ReportValue(ReportManager.ReportType.CaloriesCreated, -this.caloriesConsumed, StringFormatter.Replace((string) UI.ENDOFDAYREPORT.NOTES.EATEN, "{0}", this.GetProperName()), worker.GetProperName());
    this.AddOnConsumeEffects(worker);
    worker.Trigger(1121894420, (object) this);
    this.Trigger(-10536414, (object) worker.gameObject);
    this.unitsConsumed = float.NaN;
    this.caloriesConsumed = float.NaN;
    this.totalUnits = float.NaN;
    if ((double) this.Units >= 1.0 / 1000.0)
      return;
    this.gameObject.DeleteObject();
  }

  public static string GetEffectForFoodQuality(int qualityLevel)
  {
    qualityLevel = Mathf.Clamp(qualityLevel, -1, 5);
    return Edible.qualityEffects[qualityLevel];
  }

  private void AddOnConsumeEffects(WorkerBase worker)
  {
    int qualityLevel = this.FoodInfo.Quality + Mathf.RoundToInt(worker.GetAttributes().Add(Db.Get().Attributes.FoodExpectation).GetTotalValue());
    Effects component = worker.GetComponent<Effects>();
    component.Add(Edible.GetEffectForFoodQuality(qualityLevel), true);
    for (int index = 0; index < this.spices.Count; ++index)
    {
      Effect statBonus = this.spices[index].StatBonus;
      if (statBonus != null)
      {
        float duration = statBonus.duration;
        statBonus.duration = (float) ((double) this.caloriesConsumed * (1.0 / 1000.0) / 1000.0 * 600.0);
        component.Add(statBonus, true);
        statBonus.duration = duration;
      }
    }
    if (!this.gameObject.HasTag(GameTags.Rehydrated))
      return;
    component.Add(FoodRehydratorConfig.RehydrationEffect, true);
  }

  protected override void OnCleanUp()
  {
    base.OnCleanUp();
    Components.Edibles.Remove(this);
  }

  public int GetQuality() => this.foodInfo.Quality;

  public int GetMorale()
  {
    int morale = 0;
    string effectForFoodQuality = Edible.GetEffectForFoodQuality(this.foodInfo.Quality);
    foreach (AttributeModifier selfModifier in Db.Get().effects.Get(effectForFoodQuality).SelfModifiers)
    {
      if (selfModifier.AttributeId == Db.Get().Attributes.QualityOfLife.Id)
        morale += Mathf.RoundToInt(selfModifier.Value);
    }
    return morale;
  }

  public override List<Descriptor> GetDescriptors(GameObject go)
  {
    List<Descriptor> descriptors = new List<Descriptor>();
    descriptors.Add(new Descriptor(string.Format((string) UI.GAMEOBJECTEFFECTS.CALORIES, (object) GameUtil.GetFormattedCalories(this.foodInfo.CaloriesPerUnit)), string.Format((string) UI.GAMEOBJECTEFFECTS.TOOLTIPS.CALORIES, (object) GameUtil.GetFormattedCalories(this.foodInfo.CaloriesPerUnit)), Descriptor.DescriptorType.Information));
    descriptors.Add(new Descriptor(string.Format((string) UI.GAMEOBJECTEFFECTS.FOOD_QUALITY, (object) GameUtil.GetFormattedFoodQuality(this.foodInfo.Quality)), string.Format((string) UI.GAMEOBJECTEFFECTS.TOOLTIPS.FOOD_QUALITY, (object) GameUtil.GetFormattedFoodQuality(this.foodInfo.Quality))));
    int morale = this.GetMorale();
    descriptors.Add(new Descriptor(string.Format((string) UI.GAMEOBJECTEFFECTS.FOOD_MORALE, (object) GameUtil.AddPositiveSign(morale.ToString(), morale > 0)), string.Format((string) UI.GAMEOBJECTEFFECTS.TOOLTIPS.FOOD_MORALE, (object) GameUtil.AddPositiveSign(morale.ToString(), morale > 0))));
    foreach (string effect in this.foodInfo.Effects)
    {
      string str = "";
      foreach (AttributeModifier selfModifier in Db.Get().effects.Get(effect).SelfModifiers)
        str = $"{str}\n    • {(string) Strings.Get($"STRINGS.DUPLICANTS.ATTRIBUTES.{selfModifier.AttributeId.ToUpper()}.NAME")}: {selfModifier.GetFormattedString()}";
      descriptors.Add(new Descriptor((string) Strings.Get($"STRINGS.DUPLICANTS.MODIFIERS.{effect.ToUpper()}.NAME"), (string) Strings.Get($"STRINGS.DUPLICANTS.MODIFIERS.{effect.ToUpper()}.DESCRIPTION") + str));
    }
    return descriptors;
  }

  public void ApplySpicesToOtherEdible(Edible other)
  {
    if (this.spices == null || !((UnityEngine.Object) other != (UnityEngine.Object) null))
      return;
    for (int index = 0; index < this.spices.Count; ++index)
      other.SpiceEdible(this.spices[index], SpiceGrinderConfig.SpicedStatus);
  }

  public void OnSplitTick(Pickupable thePieceTaken)
  {
    Edible component = thePieceTaken.GetComponent<Edible>();
    this.ApplySpicesToOtherEdible(component);
    if (!this.GetComponent<KPrefabID>().HasTag(GameTags.Rehydrated))
      return;
    component.AddTag(GameTags.Rehydrated);
  }

  public class EdibleStartWorkInfo : WorkerBase.StartWorkInfo
  {
    public float amount { get; private set; }

    public EdibleStartWorkInfo(Workable workable, float amount)
      : base(workable)
    {
      this.amount = amount;
    }
  }
}
