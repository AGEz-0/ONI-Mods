// Decompiled with JetBrains decompiler
// Type: ReceptacleSideScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ReceptacleSideScreen : SideScreenContent, IRender1000ms
{
  protected bool ALLOW_ORDER_IGNORING_WOLRD_NEED = true;
  [SerializeField]
  protected KButton requestSelectedEntityBtn;
  [SerializeField]
  private string requestStringDeposit;
  [SerializeField]
  private string requestStringCancelDeposit;
  [SerializeField]
  private string requestStringRemove;
  [SerializeField]
  private string requestStringCancelRemove;
  public GameObject activeEntityContainer;
  public GameObject nothingDiscoveredContainer;
  [SerializeField]
  protected LocText descriptionLabel;
  protected Dictionary<SingleEntityReceptacle, int> entityPreviousSelectionMap = new Dictionary<SingleEntityReceptacle, int>();
  [SerializeField]
  private string subtitleStringSelect;
  [SerializeField]
  private string subtitleStringSelectDescription;
  [SerializeField]
  private string subtitleStringAwaitingSelection;
  [SerializeField]
  private string subtitleStringAwaitingDelivery;
  [SerializeField]
  private string subtitleStringEntityDeposited;
  [SerializeField]
  private string subtitleStringAwaitingRemoval;
  [SerializeField]
  private LocText subtitleLabel;
  [SerializeField]
  private List<DescriptorPanel> descriptorPanels;
  public Material defaultMaterial;
  public Material desaturatedMaterial;
  [SerializeField]
  private GameObject requestObjectList;
  [SerializeField]
  private GameObject requestObjectListContainer;
  [SerializeField]
  private GameObject scrollBarContainer;
  [SerializeField]
  private GameObject entityToggle;
  [SerializeField]
  private Sprite buttonSelectedBG;
  [SerializeField]
  private Sprite buttonNormalBG;
  [SerializeField]
  private Sprite elementPlaceholderSpr;
  [SerializeField]
  private bool hideUndiscoveredEntities;
  protected ReceptacleToggle selectedEntityToggle;
  protected SingleEntityReceptacle targetReceptacle;
  protected Tag selectedDepositObjectTag;
  protected Tag selectedDepositObjectAdditionalTag;
  protected Dictionary<ReceptacleToggle, ReceptacleSideScreen.SelectableEntity> depositObjectMap;
  protected List<ReceptacleToggle> entityToggles = new List<ReceptacleToggle>();
  private int onObjectDestroyedHandle = -1;
  private int onOccupantValidChangedHandle = -1;
  private int onStorageChangedHandle = -1;

  public override string GetTitle()
  {
    return (UnityEngine.Object) this.targetReceptacle == (UnityEngine.Object) null ? Strings.Get(this.titleKey).ToString().Replace("{0}", "") : string.Format((string) Strings.Get(this.titleKey), (object) this.targetReceptacle.GetProperName());
  }

  public void Initialize(SingleEntityReceptacle target)
  {
    if ((UnityEngine.Object) target == (UnityEngine.Object) null)
    {
      Debug.LogError((object) "SingleObjectReceptacle provided was null.");
    }
    else
    {
      this.targetReceptacle = target;
      this.gameObject.SetActive(true);
      this.depositObjectMap = new Dictionary<ReceptacleToggle, ReceptacleSideScreen.SelectableEntity>();
      this.entityToggles.ForEach((Action<ReceptacleToggle>) (rbi => UnityEngine.Object.Destroy((UnityEngine.Object) rbi.gameObject)));
      this.entityToggles.Clear();
      foreach (Tag depositObjectTag in (IEnumerable<Tag>) this.targetReceptacle.possibleDepositObjectTags)
      {
        List<GameObject> prefabsWithTag = Assets.GetPrefabsWithTag(depositObjectTag);
        int count = prefabsWithTag.Count;
        List<IHasSortOrder> hasSortOrderList = new List<IHasSortOrder>();
        foreach (GameObject candidate in prefabsWithTag)
        {
          if (!this.targetReceptacle.IsValidEntity(candidate))
          {
            --count;
          }
          else
          {
            IHasSortOrder component = candidate.GetComponent<IHasSortOrder>();
            if (component != null)
              hasSortOrderList.Add(component);
          }
        }
        Debug.Assert(hasSortOrderList.Count == count, (object) "Not all entities in this receptacle implement IHasSortOrder!");
        hasSortOrderList.Sort((Comparison<IHasSortOrder>) ((a, b) => a.sortOrder - b.sortOrder));
        foreach (IHasSortOrder hasSortOrder in hasSortOrderList)
        {
          GameObject gameObject1 = (hasSortOrder as MonoBehaviour).gameObject;
          GameObject gameObject2 = Util.KInstantiateUI(this.entityToggle, this.requestObjectList);
          gameObject2.SetActive(true);
          ReceptacleToggle newToggle = gameObject2.GetComponent<ReceptacleToggle>();
          IReceptacleDirection component1 = gameObject1.GetComponent<IReceptacleDirection>();
          string entityName = this.GetEntityName(gameObject1.PrefabID());
          newToggle.title.text = entityName;
          Sprite sprite = this.GetEntityIcon(gameObject1.PrefabID());
          if ((UnityEngine.Object) sprite == (UnityEngine.Object) null)
            sprite = this.elementPlaceholderSpr;
          newToggle.image.sprite = sprite;
          newToggle.toggle.onClick += (System.Action) (() => this.ToggleClicked(newToggle));
          newToggle.toggle.onPointerEnter += (KToggle.PointerEvent) (() => this.CheckAmountsAndUpdate((object) null));
          ToolTip component2 = newToggle.GetComponent<ToolTip>();
          if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
            component2.SetSimpleTooltip(this.GetEntityTooltip(gameObject1.PrefabID()));
          this.depositObjectMap.Add(newToggle, new ReceptacleSideScreen.SelectableEntity()
          {
            tag = gameObject1.PrefabID(),
            direction = component1 != null ? component1.Direction : SingleEntityReceptacle.ReceptacleDirection.Top,
            asset = gameObject1
          });
          this.entityToggles.Add(newToggle);
        }
      }
      this.RestoreSelectionFromOccupant();
      this.selectedEntityToggle = (ReceptacleToggle) null;
      if (this.entityToggles.Count > 0)
      {
        if (this.entityPreviousSelectionMap.ContainsKey(this.targetReceptacle))
        {
          this.ToggleClicked(this.entityToggles[this.entityPreviousSelectionMap[this.targetReceptacle]]);
        }
        else
        {
          this.subtitleLabel.SetText(Strings.Get(this.subtitleStringSelect).ToString());
          this.requestSelectedEntityBtn.isInteractable = false;
          this.descriptionLabel.SetText(Strings.Get(this.subtitleStringSelectDescription).ToString());
          this.HideAllDescriptorPanels();
        }
      }
      this.onStorageChangedHandle = this.targetReceptacle.gameObject.Subscribe(-1697596308, new Action<object>(this.CheckAmountsAndUpdate));
      this.onOccupantValidChangedHandle = this.targetReceptacle.gameObject.Subscribe(-1820564715, new Action<object>(this.OnOccupantValidChanged));
      this.UpdateState((object) null);
      SimAndRenderScheduler.instance.Add((object) this);
    }
  }

  protected virtual void UpdateState(object data)
  {
    this.requestSelectedEntityBtn.ClearOnClick();
    if ((UnityEngine.Object) this.targetReceptacle == (UnityEngine.Object) null)
      return;
    if (this.CheckReceptacleOccupied())
    {
      Uprootable uprootable = this.targetReceptacle.Occupant.GetComponent<Uprootable>();
      if ((UnityEngine.Object) uprootable != (UnityEngine.Object) null && uprootable.IsMarkedForUproot)
      {
        this.requestSelectedEntityBtn.onClick += (System.Action) (() =>
        {
          uprootable.ForceCancelUproot();
          this.UpdateState((object) null);
        });
        this.requestSelectedEntityBtn.GetComponentInChildren<LocText>().text = Strings.Get(this.requestStringCancelRemove).ToString();
        this.subtitleLabel.SetText(string.Format(Strings.Get(this.subtitleStringAwaitingRemoval).ToString(), (object) this.targetReceptacle.Occupant.GetProperName()));
      }
      else
      {
        this.requestSelectedEntityBtn.onClick += (System.Action) (() =>
        {
          this.targetReceptacle.OrderRemoveOccupant();
          this.UpdateState((object) null);
        });
        this.requestSelectedEntityBtn.GetComponentInChildren<LocText>().text = Strings.Get(this.requestStringRemove).ToString();
        this.subtitleLabel.SetText(string.Format(Strings.Get(this.subtitleStringEntityDeposited).ToString(), (object) this.targetReceptacle.Occupant.GetProperName()));
      }
      this.requestSelectedEntityBtn.isInteractable = true;
      this.ToggleObjectPicker(false);
      this.ConfigureActiveEntity(this.targetReceptacle.Occupant.GetComponent<KSelectable>().PrefabID());
      this.SetResultDescriptions(this.targetReceptacle.Occupant);
    }
    else if (this.targetReceptacle.GetActiveRequest != null)
    {
      this.requestSelectedEntityBtn.onClick += (System.Action) (() =>
      {
        this.targetReceptacle.CancelActiveRequest();
        this.ClearSelection();
        this.UpdateAvailableAmounts((object) null);
        this.UpdateState((object) null);
      });
      this.requestSelectedEntityBtn.GetComponentInChildren<LocText>().text = Strings.Get(this.requestStringCancelDeposit).ToString();
      this.requestSelectedEntityBtn.isInteractable = true;
      this.ToggleObjectPicker(false);
      this.ConfigureActiveEntity(this.targetReceptacle.GetActiveRequest.tagsFirst);
      GameObject prefab = Assets.GetPrefab(this.targetReceptacle.GetActiveRequest.tagsFirst);
      if ((UnityEngine.Object) prefab != (UnityEngine.Object) null)
      {
        this.subtitleLabel.SetText(string.Format(Strings.Get(this.subtitleStringAwaitingDelivery).ToString(), (object) prefab.GetProperName()));
        this.SetResultDescriptions(prefab);
      }
    }
    else if ((UnityEngine.Object) this.selectedEntityToggle != (UnityEngine.Object) null)
    {
      this.requestSelectedEntityBtn.onClick += (System.Action) (() =>
      {
        this.targetReceptacle.CreateOrder(this.selectedDepositObjectTag, this.selectedDepositObjectAdditionalTag);
        this.UpdateAvailableAmounts((object) null);
        this.UpdateState((object) null);
      });
      this.requestSelectedEntityBtn.GetComponentInChildren<LocText>().text = Strings.Get(this.requestStringDeposit).ToString();
      this.targetReceptacle.SetPreview(this.depositObjectMap[this.selectedEntityToggle].tag);
      bool flag = this.CanDepositEntity(this.depositObjectMap[this.selectedEntityToggle]);
      this.requestSelectedEntityBtn.isInteractable = flag;
      this.SetImageToggleState(this.selectedEntityToggle.toggle, flag ? ImageToggleState.State.Active : ImageToggleState.State.DisabledActive);
      this.ToggleObjectPicker(true);
      GameObject prefab = Assets.GetPrefab(this.selectedDepositObjectTag);
      if ((UnityEngine.Object) prefab != (UnityEngine.Object) null)
      {
        this.subtitleLabel.SetText(string.Format(Strings.Get(this.subtitleStringAwaitingSelection).ToString(), (object) prefab.GetProperName()));
        this.SetResultDescriptions(prefab);
      }
    }
    else
    {
      this.requestSelectedEntityBtn.GetComponentInChildren<LocText>().text = Strings.Get(this.requestStringDeposit).ToString();
      this.requestSelectedEntityBtn.isInteractable = false;
      this.ToggleObjectPicker(true);
    }
    this.UpdateAvailableAmounts((object) null);
    this.UpdateListeners();
  }

  private void UpdateListeners()
  {
    if (this.CheckReceptacleOccupied())
    {
      if (this.onObjectDestroyedHandle != -1)
        return;
      this.onObjectDestroyedHandle = this.targetReceptacle.Occupant.gameObject.Subscribe(1969584890, (Action<object>) (d => this.UpdateState((object) null)));
    }
    else
    {
      if (this.onObjectDestroyedHandle == -1)
        return;
      this.onObjectDestroyedHandle = -1;
    }
  }

  private void OnOccupantValidChanged(object obj)
  {
    if ((UnityEngine.Object) this.targetReceptacle == (UnityEngine.Object) null || this.CheckReceptacleOccupied() || this.targetReceptacle.GetActiveRequest == null)
      return;
    bool flag = false;
    ReceptacleSideScreen.SelectableEntity entity;
    if (this.depositObjectMap.TryGetValue(this.selectedEntityToggle, out entity))
      flag = this.CanDepositEntity(entity);
    if (flag)
      return;
    this.targetReceptacle.CancelActiveRequest();
    this.ClearSelection();
    this.UpdateState((object) null);
    this.UpdateAvailableAmounts((object) null);
  }

  private bool CanDepositEntity(ReceptacleSideScreen.SelectableEntity entity)
  {
    return this.ValidRotationForDeposit(entity.direction) && (!this.RequiresAvailableAmountToDeposit() || (double) this.GetAvailableAmount(entity.tag) > 0.0) && this.AdditionalCanDepositTest();
  }

  protected virtual bool AdditionalCanDepositTest() => true;

  protected virtual bool RequiresAvailableAmountToDeposit() => true;

  private void ClearSelection()
  {
    foreach (KeyValuePair<ReceptacleToggle, ReceptacleSideScreen.SelectableEntity> depositObject in this.depositObjectMap)
      depositObject.Key.toggle.Deselect();
  }

  private void ToggleObjectPicker(bool Show)
  {
    this.requestObjectListContainer.SetActive(Show);
    if ((UnityEngine.Object) this.scrollBarContainer != (UnityEngine.Object) null)
      this.scrollBarContainer.SetActive(Show);
    this.requestObjectList.SetActive(Show);
    this.activeEntityContainer.SetActive(!Show);
  }

  private void ConfigureActiveEntity(Tag tag)
  {
    string properName = Assets.GetPrefab(tag).GetProperName();
    this.activeEntityContainer.GetComponentInChildrenOnly<LocText>().text = properName;
    this.activeEntityContainer.transform.GetChild(0).gameObject.GetComponentInChildrenOnly<Image>().sprite = this.GetEntityIcon(tag);
  }

  protected virtual string GetEntityName(Tag prefabTag)
  {
    return Assets.GetPrefab(prefabTag).GetProperName();
  }

  protected virtual string GetEntityTooltip(Tag prefabTag)
  {
    InfoDescription component = Assets.GetPrefab(prefabTag).GetComponent<InfoDescription>();
    string entityTooltip = this.GetEntityName(prefabTag);
    if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      entityTooltip = $"{entityTooltip}\n\n{component.description}";
    return entityTooltip;
  }

  protected virtual Sprite GetEntityIcon(Tag prefabTag)
  {
    return Def.GetUISprite((object) Assets.GetPrefab(prefabTag)).first;
  }

  public override bool IsValidForTarget(GameObject target)
  {
    SingleEntityReceptacle component = target.GetComponent<SingleEntityReceptacle>();
    return (UnityEngine.Object) component != (UnityEngine.Object) null && component.enabled && (UnityEngine.Object) target.GetComponent<PlantablePlot>() == (UnityEngine.Object) null && (UnityEngine.Object) target.GetComponent<EggIncubator>() == (UnityEngine.Object) null && (UnityEngine.Object) target.GetComponent<SpecialCargoBayClusterReceptacle>() == (UnityEngine.Object) null;
  }

  public override void SetTarget(GameObject target)
  {
    SingleEntityReceptacle component = target.GetComponent<SingleEntityReceptacle>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
    {
      Debug.LogError((object) "The object selected doesn't have a SingleObjectReceptacle!");
    }
    else
    {
      this.Initialize(component);
      this.UpdateState((object) null);
    }
  }

  protected virtual void RestoreSelectionFromOccupant()
  {
  }

  public override void ClearTarget()
  {
    if (!((UnityEngine.Object) this.targetReceptacle != (UnityEngine.Object) null))
      return;
    if (this.CheckReceptacleOccupied())
    {
      this.targetReceptacle.Occupant.gameObject.Unsubscribe(this.onObjectDestroyedHandle);
      this.onObjectDestroyedHandle = -1;
    }
    this.targetReceptacle.Unsubscribe(this.onStorageChangedHandle);
    this.onStorageChangedHandle = -1;
    this.targetReceptacle.Unsubscribe(this.onOccupantValidChangedHandle);
    this.onOccupantValidChangedHandle = -1;
    if (this.targetReceptacle.GetActiveRequest == null)
      this.targetReceptacle.SetPreview(Tag.Invalid);
    SimAndRenderScheduler.instance.Remove((object) this);
    this.targetReceptacle = (SingleEntityReceptacle) null;
  }

  protected void SetImageToggleState(KToggle toggle, ImageToggleState.State state)
  {
    switch (state)
    {
      case ImageToggleState.State.Disabled:
        toggle.GetComponent<ImageToggleState>().SetDisabled();
        toggle.gameObject.GetComponentInChildrenOnly<Image>().material = this.desaturatedMaterial;
        break;
      case ImageToggleState.State.Inactive:
        toggle.GetComponent<ImageToggleState>().SetInactive();
        toggle.gameObject.GetComponentInChildrenOnly<Image>().material = this.defaultMaterial;
        break;
      case ImageToggleState.State.Active:
        toggle.GetComponent<ImageToggleState>().SetActive();
        toggle.gameObject.GetComponentInChildrenOnly<Image>().material = this.defaultMaterial;
        break;
      case ImageToggleState.State.DisabledActive:
        toggle.GetComponent<ImageToggleState>().SetDisabledActive();
        toggle.gameObject.GetComponentInChildrenOnly<Image>().material = this.desaturatedMaterial;
        break;
    }
  }

  public void Render1000ms(float dt) => this.CheckAmountsAndUpdate((object) null);

  private void CheckAmountsAndUpdate(object data)
  {
    if ((UnityEngine.Object) this.targetReceptacle == (UnityEngine.Object) null || !this.UpdateAvailableAmounts((object) null))
      return;
    this.UpdateState((object) null);
  }

  private bool UpdateAvailableAmounts(object data)
  {
    bool flag = false;
    foreach (KeyValuePair<ReceptacleToggle, ReceptacleSideScreen.SelectableEntity> depositObject in this.depositObjectMap)
    {
      if (!DebugHandler.InstantBuildMode && this.hideUndiscoveredEntities && !DiscoveredResources.Instance.IsDiscovered(depositObject.Value.tag))
        depositObject.Key.gameObject.SetActive(false);
      else if (!depositObject.Key.gameObject.activeSelf)
        depositObject.Key.gameObject.SetActive(true);
      float availableAmount = this.GetAvailableAmount(depositObject.Value.tag);
      if ((double) depositObject.Value.lastAmount != (double) availableAmount)
      {
        flag = true;
        depositObject.Value.lastAmount = availableAmount;
        depositObject.Key.amount.text = availableAmount.ToString();
      }
      if (!this.ValidRotationForDeposit(depositObject.Value.direction) || (double) availableAmount <= 0.0)
      {
        if ((UnityEngine.Object) this.selectedEntityToggle != (UnityEngine.Object) depositObject.Key)
          this.SetImageToggleState(depositObject.Key.toggle, ImageToggleState.State.Disabled);
        else
          this.SetImageToggleState(depositObject.Key.toggle, ImageToggleState.State.DisabledActive);
      }
      else if ((UnityEngine.Object) this.selectedEntityToggle != (UnityEngine.Object) depositObject.Key)
        this.SetImageToggleState(depositObject.Key.toggle, ImageToggleState.State.Inactive);
      else
        this.SetImageToggleState(depositObject.Key.toggle, ImageToggleState.State.Active);
    }
    return flag;
  }

  protected float GetAvailableAmount(Tag tag)
  {
    if (!this.ALLOW_ORDER_IGNORING_WOLRD_NEED)
      return this.targetReceptacle.GetMyWorld().worldInventory.GetAmount(tag, true);
    ICollection<Pickupable> pickupables = this.targetReceptacle.GetMyWorld().worldInventory.GetPickupables(tag, true);
    float availableAmount = 0.0f;
    foreach (Pickupable pickupable in (IEnumerable<Pickupable>) pickupables)
      availableAmount += (float) Mathf.CeilToInt(pickupable.TotalAmount);
    return availableAmount;
  }

  private bool ValidRotationForDeposit(
    SingleEntityReceptacle.ReceptacleDirection depositDir)
  {
    return (UnityEngine.Object) this.targetReceptacle.rotatable == (UnityEngine.Object) null || depositDir == this.targetReceptacle.Direction;
  }

  protected virtual void ToggleClicked(ReceptacleToggle toggle)
  {
    if (!this.depositObjectMap.ContainsKey(toggle))
    {
      Debug.LogError((object) "Recipe not found on recipe list.");
    }
    else
    {
      if ((UnityEngine.Object) this.selectedEntityToggle != (UnityEngine.Object) null)
      {
        bool flag = this.CanDepositEntity(this.depositObjectMap[this.selectedEntityToggle]);
        this.requestSelectedEntityBtn.isInteractable = flag;
        this.SetImageToggleState(this.selectedEntityToggle.toggle, flag ? ImageToggleState.State.Inactive : ImageToggleState.State.Disabled);
      }
      this.selectedEntityToggle = toggle;
      this.entityPreviousSelectionMap[this.targetReceptacle] = this.entityToggles.IndexOf(toggle);
      this.selectedDepositObjectTag = this.depositObjectMap[toggle].tag;
      MutantPlant component = this.depositObjectMap[toggle].asset.GetComponent<MutantPlant>();
      this.selectedDepositObjectAdditionalTag = (bool) (UnityEngine.Object) component ? component.SubSpeciesID : Tag.Invalid;
      this.UpdateAvailableAmounts((object) null);
      this.UpdateState((object) null);
    }
  }

  private void CreateOrder(bool isInfinite)
  {
    this.targetReceptacle.CreateOrder(this.selectedDepositObjectTag, this.selectedDepositObjectAdditionalTag);
  }

  protected bool CheckReceptacleOccupied()
  {
    return (UnityEngine.Object) this.targetReceptacle != (UnityEngine.Object) null && (UnityEngine.Object) this.targetReceptacle.Occupant != (UnityEngine.Object) null;
  }

  protected virtual void SetResultDescriptions(GameObject go)
  {
    string text = "";
    InfoDescription component1 = go.GetComponent<InfoDescription>();
    if ((bool) (UnityEngine.Object) component1)
    {
      text = component1.description;
    }
    else
    {
      KPrefabID component2 = go.GetComponent<KPrefabID>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      {
        Element element = ElementLoader.GetElement(component2.PrefabID());
        if (element != null)
          text = element.Description();
      }
      else
        text = go.GetProperName();
    }
    this.descriptionLabel.SetText(text);
  }

  protected virtual void HideAllDescriptorPanels()
  {
    for (int index = 0; index < this.descriptorPanels.Count; ++index)
      this.descriptorPanels[index].gameObject.SetActive(false);
  }

  protected class SelectableEntity
  {
    public Tag tag;
    public SingleEntityReceptacle.ReceptacleDirection direction;
    public GameObject asset;
    public float lastAmount = -1f;
  }
}
