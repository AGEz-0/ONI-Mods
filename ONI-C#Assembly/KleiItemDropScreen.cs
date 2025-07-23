// Decompiled with JetBrains decompiler
// Type: KleiItemDropScreen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class KleiItemDropScreen : KModalScreen
{
  [SerializeField]
  private RectTransform shieldMaskRect;
  [SerializeField]
  private KButton closeButton;
  [Header("Animated Item")]
  [SerializeField]
  private KleiItemDropScreen_PermitVis permitVisualizer;
  [SerializeField]
  private KBatchedAnimController animatedPod;
  [SerializeField]
  private LocText userMessageLabel;
  [SerializeField]
  private LocText unopenedItemCountLabel;
  [Header("Item Info")]
  [SerializeField]
  private RectTransform itemTextContainer;
  [SerializeField]
  private LocText itemNameLabel;
  [SerializeField]
  private LocText itemDescriptionLabel;
  [SerializeField]
  private LocText itemRarityLabel;
  [SerializeField]
  private LocText itemCategoryLabel;
  [Header("Accept Button")]
  [SerializeField]
  private RectTransform acceptButtonRect;
  [SerializeField]
  private KButton acceptButton;
  [SerializeField]
  private KBatchedAnimController animatedLoadingIcon;
  [SerializeField]
  private KButton acknowledgeButton;
  [SerializeField]
  private LocText errorMessage;
  private Coroutine activePresentationRoutine;
  private KleiItemDropScreen.ServerRequestState serverRequestState;
  private bool giftAcknowledged;
  private bool noItemAvailableAcknowledged;
  public static KleiItemDropScreen Instance;
  private bool shouldDoCloseRoutine;
  private const float TEXT_AND_BUTTON_ANIMATE_OFFSET_Y = -30f;
  private PrefabDefinedUIPosition acceptButtonPosition = new PrefabDefinedUIPosition();
  private PrefabDefinedUIPosition itemTextContainerPosition = new PrefabDefinedUIPosition();

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    KleiItemDropScreen.Instance = this;
    this.closeButton.onClick += (System.Action) (() => this.Show(false));
    if (!string.IsNullOrEmpty(KleiAccount.KleiToken))
      return;
    base.Show(false);
  }

  protected override void OnActivate()
  {
    KleiItemDropScreen.Instance = this;
    this.Show(false);
  }

  public override void Show(bool show = true)
  {
    this.serverRequestState.Reset();
    if (!show)
    {
      this.animatedLoadingIcon.gameObject.SetActive(false);
      if (this.activePresentationRoutine != null)
        this.StopCoroutine(this.activePresentationRoutine);
      if (this.shouldDoCloseRoutine)
      {
        this.closeButton.gameObject.SetActive(false);
        Updater.RunRoutine((MonoBehaviour) this, this.AnimateScreenOutRoutine()).Then((System.Action) (() => base.Show(false)));
        this.shouldDoCloseRoutine = false;
      }
      else
        base.Show(false);
      AudioMixer.instance.Stop(AudioMixerSnapshots.Get().FrontEndItemDropScreenSnapshot);
    }
    else
    {
      AudioMixer.instance.Start(AudioMixerSnapshots.Get().FrontEndItemDropScreenSnapshot);
      base.Show();
    }
  }

  public override void OnKeyDown(KButtonEvent e)
  {
    if (e.TryConsume(Action.Escape) || e.TryConsume(Action.MouseRight))
      this.Show(false);
    base.OnKeyDown(e);
  }

  protected override void OnShow(bool show)
  {
    base.OnShow(show);
    if (!show)
      return;
    if (PermitItems.HasUnopenedItem())
    {
      this.PresentNextUnopenedItem();
      this.shouldDoCloseRoutine = true;
    }
    else
    {
      this.userMessageLabel.SetText((string) STRINGS.UI.ITEM_DROP_SCREEN.NOTHING_AVAILABLE);
      this.PresentNoItemAvailablePrompt(true);
      this.shouldDoCloseRoutine = true;
    }
  }

  public void PresentNextUnopenedItem(bool firstItemPresentation = true)
  {
    int num = 0;
    foreach (KleiItems.ItemData itemData in PermitItems.IterateInventory())
    {
      if (!itemData.IsOpened)
        ++num;
    }
    this.RefreshUnopenedItemsLabel();
    foreach (KleiItems.ItemData itemData in PermitItems.IterateInventory())
    {
      if (!itemData.IsOpened)
      {
        this.PresentItem(itemData, firstItemPresentation, num == 1);
        return;
      }
    }
    this.PresentNoItemAvailablePrompt(false);
  }

  private void RefreshUnopenedItemsLabel()
  {
    int num = 0;
    foreach (KleiItems.ItemData itemData in PermitItems.IterateInventory())
    {
      if (!itemData.IsOpened)
        ++num;
    }
    if (num > 1)
    {
      this.unopenedItemCountLabel.gameObject.SetActive(true);
      this.unopenedItemCountLabel.SetText((string) STRINGS.UI.ITEM_DROP_SCREEN.UNOPENED_ITEM_COUNT, (float) num);
    }
    else if (num == 1)
    {
      this.unopenedItemCountLabel.gameObject.SetActive(true);
      this.unopenedItemCountLabel.SetText((string) STRINGS.UI.ITEM_DROP_SCREEN.UNOPENED_ITEM, (float) num);
    }
    else
      this.unopenedItemCountLabel.gameObject.SetActive(false);
  }

  public void PresentItem(
    KleiItems.ItemData item,
    bool firstItemPresentation,
    bool lastItemPresentation)
  {
    this.userMessageLabel.SetText((string) STRINGS.UI.ITEM_DROP_SCREEN.THANKS_FOR_PLAYING);
    this.giftAcknowledged = false;
    this.serverRequestState.revealConfirmedByServer = false;
    this.serverRequestState.revealRejectedByServer = false;
    if (this.activePresentationRoutine != null)
      this.StopCoroutine(this.activePresentationRoutine);
    this.activePresentationRoutine = this.StartCoroutine(this.PresentItemRoutine(item, firstItemPresentation, lastItemPresentation));
    this.acceptButton.ClearOnClick();
    this.acknowledgeButton.ClearOnClick();
    this.acceptButton.GetComponentInChildren<LocText>().SetText((string) STRINGS.UI.ITEM_DROP_SCREEN.PRINT_ITEM_BUTTON);
    this.acceptButton.onClick += (System.Action) (() => this.RequestReveal(item));
    this.acknowledgeButton.onClick += (System.Action) (() =>
    {
      if (!this.serverRequestState.revealConfirmedByServer)
        return;
      this.giftAcknowledged = true;
    });
  }

  private void RequestReveal(KleiItems.ItemData item)
  {
    this.serverRequestState.revealRequested = true;
    PermitItems.QueueRequestOpenOrUnboxItem(item, new KleiItems.ResponseCallback(this.OnOpenItemRequestResponse));
  }

  public void OnOpenItemRequestResponse(KleiItems.Result result)
  {
    if (!this.serverRequestState.revealRequested)
      return;
    this.serverRequestState.revealRequested = false;
    if (result.Success)
    {
      this.serverRequestState.revealRejectedByServer = false;
      this.serverRequestState.revealConfirmedByServer = true;
    }
    else
    {
      this.serverRequestState.revealRejectedByServer = true;
      this.serverRequestState.revealConfirmedByServer = false;
    }
  }

  public void PresentNoItemAvailablePrompt(bool firstItemPresentation)
  {
    this.userMessageLabel.SetText((string) STRINGS.UI.ITEM_DROP_SCREEN.NOTHING_AVAILABLE);
    this.noItemAvailableAcknowledged = false;
    this.acknowledgeButton.ClearOnClick();
    this.acceptButton.ClearOnClick();
    this.acceptButton.GetComponentInChildren<LocText>().SetText((string) STRINGS.UI.ITEM_DROP_SCREEN.DISMISS_BUTTON);
    this.acceptButton.onClick += (System.Action) (() => this.noItemAvailableAcknowledged = true);
    if (this.activePresentationRoutine != null)
      this.StopCoroutine(this.activePresentationRoutine);
    this.activePresentationRoutine = this.StartCoroutine(this.PresentNoItemAvailableRoutine(firstItemPresentation));
  }

  private IEnumerator AnimateScreenInRoutine()
  {
    KleiItemDropScreen kleiItemDropScreen = this;
    // ISSUE: explicit non-virtual call
    float scaleFactor = __nonvirtual (kleiItemDropScreen.transform).parent.GetComponent<CanvasScaler>().scaleFactor;
    float OPEN_WIDTH = (float) Screen.width / scaleFactor;
    float y = Mathf.Clamp((float) Screen.height / scaleFactor, 720f, 900f);
    KFMOD.PlayUISound(GlobalAssets.GetSound("GiftItemDrop_Screen_Open"));
    kleiItemDropScreen.userMessageLabel.gameObject.SetActive(false);
    // ISSUE: reference to a compiler-generated method
    yield return (object) Updater.Ease(new Action<Vector2>(kleiItemDropScreen.\u003CAnimateScreenInRoutine\u003Eb__34_0), kleiItemDropScreen.shieldMaskRect.sizeDelta, new Vector2(kleiItemDropScreen.shieldMaskRect.sizeDelta.x, y), 0.5f, Easing.CircInOut);
    // ISSUE: reference to a compiler-generated method
    yield return (object) Updater.Ease(new Action<Vector2>(kleiItemDropScreen.\u003CAnimateScreenInRoutine\u003Eb__34_1), kleiItemDropScreen.shieldMaskRect.sizeDelta, new Vector2(OPEN_WIDTH, kleiItemDropScreen.shieldMaskRect.sizeDelta.y), 0.25f, Easing.CircInOut);
    kleiItemDropScreen.userMessageLabel.gameObject.SetActive(true);
  }

  private IEnumerator AnimateScreenOutRoutine()
  {
    KleiItemDropScreen kleiItemDropScreen = this;
    KFMOD.PlayUISound(GlobalAssets.GetSound("GiftItemDrop_Screen_Close"));
    kleiItemDropScreen.userMessageLabel.gameObject.SetActive(false);
    // ISSUE: reference to a compiler-generated method
    yield return (object) Updater.Ease(new Action<Vector2>(kleiItemDropScreen.\u003CAnimateScreenOutRoutine\u003Eb__35_0), kleiItemDropScreen.shieldMaskRect.sizeDelta, new Vector2(8f, kleiItemDropScreen.shieldMaskRect.sizeDelta.y), 0.25f, Easing.CircInOut);
    // ISSUE: reference to a compiler-generated method
    yield return (object) Updater.Ease(new Action<Vector2>(kleiItemDropScreen.\u003CAnimateScreenOutRoutine\u003Eb__35_1), kleiItemDropScreen.shieldMaskRect.sizeDelta, new Vector2(kleiItemDropScreen.shieldMaskRect.sizeDelta.x, 0.0f), 0.25f, Easing.CircInOut);
  }

  private IEnumerator PresentNoItemAvailableRoutine(bool firstItem)
  {
    KleiItemDropScreen kleiItemDropScreen = this;
    yield return (object) null;
    kleiItemDropScreen.itemNameLabel.SetText("");
    kleiItemDropScreen.itemDescriptionLabel.SetText("");
    kleiItemDropScreen.itemRarityLabel.SetText("");
    kleiItemDropScreen.itemCategoryLabel.SetText("");
    if (firstItem)
    {
      kleiItemDropScreen.animatedPod.Play((HashedString) "idle", KAnim.PlayMode.Loop);
      kleiItemDropScreen.acceptButtonRect.gameObject.SetActive(false);
      kleiItemDropScreen.shieldMaskRect.sizeDelta = new Vector2(8f, 0.0f);
      kleiItemDropScreen.shieldMaskRect.gameObject.SetActive(true);
    }
    if (firstItem)
    {
      kleiItemDropScreen.closeButton.gameObject.SetActive(false);
      yield return (object) Updater.WaitForSeconds(0.5f);
      yield return (object) kleiItemDropScreen.AnimateScreenInRoutine();
      yield return (object) Updater.WaitForSeconds(0.125f);
      kleiItemDropScreen.closeButton.gameObject.SetActive(true);
    }
    else
      yield return (object) Updater.WaitForSeconds(0.25f);
    Vector2 animate_offset = new Vector2(0.0f, -30f);
    kleiItemDropScreen.acceptButtonRect.FindOrAddComponent<CanvasGroup>().alpha = 0.0f;
    kleiItemDropScreen.acceptButtonRect.gameObject.SetActive(true);
    kleiItemDropScreen.acceptButtonPosition.SetOn((Component) kleiItemDropScreen.acceptButtonRect);
    yield return (object) Updater.WaitForSeconds(0.75f);
    yield return (object) PresUtil.OffsetToAndFade(kleiItemDropScreen.acceptButton.rectTransform(), animate_offset, 1f, 0.125f, Easing.ExpoOut);
    // ISSUE: reference to a compiler-generated method
    yield return (object) Updater.Until(new Func<bool>(kleiItemDropScreen.\u003CPresentNoItemAvailableRoutine\u003Eb__39_0));
    yield return (object) PresUtil.OffsetFromAndFade(kleiItemDropScreen.acceptButton.rectTransform(), animate_offset, 0.0f, 0.125f, Easing.SmoothStep);
    kleiItemDropScreen.Show(false);
  }

  private IEnumerator PresentItemRoutine(KleiItems.ItemData item, bool firstItem, bool lastItem)
  {
    KleiItemDropScreen kleiItemDropScreen = this;
    yield return (object) null;
    if (item.ItemId == 0UL)
    {
      Debug.LogError((object) "Could not find dropped item inventory.");
    }
    else
    {
      kleiItemDropScreen.itemNameLabel.SetText("");
      kleiItemDropScreen.itemDescriptionLabel.SetText("");
      kleiItemDropScreen.itemRarityLabel.SetText("");
      kleiItemDropScreen.itemCategoryLabel.SetText("");
      kleiItemDropScreen.permitVisualizer.ResetState();
      if (firstItem)
      {
        kleiItemDropScreen.animatedPod.Play((HashedString) "idle", KAnim.PlayMode.Loop);
        kleiItemDropScreen.acceptButtonRect.gameObject.SetActive(false);
        kleiItemDropScreen.shieldMaskRect.sizeDelta = new Vector2(8f, 0.0f);
        kleiItemDropScreen.shieldMaskRect.gameObject.SetActive(true);
      }
      if (firstItem)
      {
        kleiItemDropScreen.closeButton.gameObject.SetActive(false);
        yield return (object) Updater.WaitForSeconds(0.5f);
        yield return (object) kleiItemDropScreen.AnimateScreenInRoutine();
        yield return (object) Updater.WaitForSeconds(0.125f);
        kleiItemDropScreen.closeButton.gameObject.SetActive(true);
      }
      Vector2 animate_offset = new Vector2(0.0f, -30f);
      if (firstItem)
      {
        kleiItemDropScreen.acceptButtonRect.FindOrAddComponent<CanvasGroup>().alpha = 0.0f;
        kleiItemDropScreen.acceptButtonRect.gameObject.SetActive(true);
        kleiItemDropScreen.acceptButtonPosition.SetOn((Component) kleiItemDropScreen.acceptButtonRect);
        kleiItemDropScreen.animatedPod.Play((HashedString) "powerup");
        kleiItemDropScreen.animatedPod.Queue((HashedString) "working_loop", KAnim.PlayMode.Loop);
        yield return (object) Updater.WaitForSeconds(1.25f);
        yield return (object) PresUtil.OffsetToAndFade(kleiItemDropScreen.acceptButton.rectTransform(), animate_offset, 1f, 0.125f, Easing.ExpoOut);
        // ISSUE: reference to a compiler-generated method
        yield return (object) Updater.Until(new Func<bool>(kleiItemDropScreen.\u003CPresentItemRoutine\u003Eb__40_1));
        yield return (object) PresUtil.OffsetFromAndFade(kleiItemDropScreen.acceptButton.rectTransform(), animate_offset, 0.0f, 0.125f, Easing.SmoothStep);
      }
      else
        kleiItemDropScreen.RequestReveal(item);
      kleiItemDropScreen.animatedLoadingIcon.gameObject.rectTransform().anchoredPosition = new Vector2(0.0f, -352f);
      if ((UnityEngine.Object) kleiItemDropScreen.animatedLoadingIcon.GetComponent<CanvasGroup>() != (UnityEngine.Object) null)
        kleiItemDropScreen.animatedLoadingIcon.GetComponent<CanvasGroup>().alpha = 1f;
      yield return (object) new WaitForSecondsRealtime(0.3f);
      if (!kleiItemDropScreen.serverRequestState.revealConfirmedByServer && !kleiItemDropScreen.serverRequestState.revealRejectedByServer)
      {
        kleiItemDropScreen.animatedLoadingIcon.gameObject.SetActive(true);
        kleiItemDropScreen.animatedLoadingIcon.Play((HashedString) "loading_rocket", KAnim.PlayMode.Loop);
        // ISSUE: reference to a compiler-generated method
        yield return (object) Updater.Until(new Func<bool>(kleiItemDropScreen.\u003CPresentItemRoutine\u003Eb__40_0));
        yield return (object) new WaitForSecondsRealtime(2f);
        yield return (object) PresUtil.OffsetFromAndFade(kleiItemDropScreen.animatedLoadingIcon.gameObject.rectTransform(), new Vector2(0.0f, -512f), 0.0f, 0.25f, Easing.SmoothStep);
        kleiItemDropScreen.animatedLoadingIcon.gameObject.SetActive(false);
      }
      if (kleiItemDropScreen.serverRequestState.revealRejectedByServer)
      {
        kleiItemDropScreen.animatedPod.Play((HashedString) "idle", KAnim.PlayMode.Loop);
        kleiItemDropScreen.errorMessage.gameObject.SetActive(true);
        yield return (object) Updater.WaitForSeconds(3f);
        kleiItemDropScreen.errorMessage.gameObject.SetActive(false);
      }
      else if (kleiItemDropScreen.serverRequestState.revealConfirmedByServer)
      {
        float num = 1f;
        kleiItemDropScreen.animatedPod.PlaySpeedMultiplier = firstItem ? 1f : 1f * num;
        kleiItemDropScreen.animatedPod.Play((HashedString) "additional_pre");
        kleiItemDropScreen.animatedPod.Queue((HashedString) "working_loop", KAnim.PlayMode.Loop);
        yield return (object) Updater.WaitForSeconds(firstItem ? 1f : 1f / num);
        kleiItemDropScreen.animatedPod.PlaySpeedMultiplier = 1f;
        kleiItemDropScreen.RefreshUnopenedItemsLabel();
        DropScreenPresentationInfo info;
        info.UseEquipmentVis = false;
        info.BuildOverride = (string) null;
        info.Sprite = (Sprite) null;
        string name = "";
        string desc = "";
        PermitRarity rarity = PermitRarity.Unknown;
        string categoryString = "";
        string icon_name;
        if (PermitItems.TryGetBoxInfo(item, out name, out desc, out icon_name))
        {
          info.UseEquipmentVis = false;
          info.BuildOverride = (string) null;
          info.Sprite = Assets.GetSprite((HashedString) icon_name);
          rarity = PermitRarity.Loyalty;
        }
        else
        {
          PermitResource permitResource = Db.Get().Permits.Get(item.Id);
          info.Sprite = permitResource.GetPermitPresentationInfo().sprite;
          info.UseEquipmentVis = permitResource.Category == PermitCategory.Equipment;
          if (permitResource is EquippableFacadeResource)
            info.BuildOverride = (permitResource as EquippableFacadeResource).BuildOverride;
          name = permitResource.Name;
          desc = permitResource.Description;
          rarity = permitResource.Rarity;
          switch (permitResource.Category)
          {
            case PermitCategory.Building:
              categoryString = Assets.GetPrefab((Tag) (permitResource as BuildingFacadeResource).PrefabID).GetProperName();
              break;
            case PermitCategory.Artwork:
              categoryString = PermitCategories.GetDisplayName(permitResource.Category);
              if (permitResource is ArtableStage)
              {
                categoryString = Assets.GetPrefab((Tag) (permitResource as ArtableStage).prefabId).GetProperName();
                break;
              }
              break;
            case PermitCategory.JoyResponse:
              categoryString = PermitCategories.GetDisplayName(permitResource.Category);
              if (permitResource is BalloonArtistFacadeResource)
              {
                categoryString = $"{PermitCategories.GetDisplayName(permitResource.Category)}: {(string) STRINGS.UI.KLEI_INVENTORY_SCREEN.CATEGORIES.JOY_RESPONSES.BALLOON_ARTIST}";
                break;
              }
              break;
            default:
              categoryString = PermitCategories.GetDisplayName(permitResource.Category);
              break;
          }
        }
        kleiItemDropScreen.permitVisualizer.ConfigureWith(info);
        yield return (object) kleiItemDropScreen.permitVisualizer.AnimateIn();
        KFMOD.PlayUISoundWithLabeledParameter(GlobalAssets.GetSound("GiftItemDrop_Rarity"), "GiftItemRarity", $"{rarity}");
        kleiItemDropScreen.itemNameLabel.SetText(name);
        kleiItemDropScreen.itemDescriptionLabel.SetText(desc);
        kleiItemDropScreen.itemRarityLabel.SetText(rarity.GetLocStringName());
        kleiItemDropScreen.itemCategoryLabel.SetText(categoryString);
        kleiItemDropScreen.itemTextContainerPosition.SetOn((Component) kleiItemDropScreen.itemTextContainer);
        yield return (object) Updater.Parallel((Updater) PresUtil.OffsetToAndFade(kleiItemDropScreen.itemTextContainer.rectTransform(), animate_offset, 1f, 0.125f, Easing.CircInOut));
        // ISSUE: reference to a compiler-generated method
        yield return (object) Updater.Until(new Func<bool>(kleiItemDropScreen.\u003CPresentItemRoutine\u003Eb__40_2));
        if (lastItem)
        {
          kleiItemDropScreen.animatedPod.Play((HashedString) "working_pst");
          kleiItemDropScreen.animatedPod.Queue((HashedString) "idle", KAnim.PlayMode.Loop);
          yield return (object) Updater.Parallel((Updater) PresUtil.OffsetFromAndFade(kleiItemDropScreen.itemTextContainer.rectTransform(), animate_offset, 0.0f, 0.125f, Easing.CircInOut));
          kleiItemDropScreen.itemNameLabel.SetText("");
          kleiItemDropScreen.itemDescriptionLabel.SetText("");
          kleiItemDropScreen.itemRarityLabel.SetText("");
          kleiItemDropScreen.itemCategoryLabel.SetText("");
          yield return (object) kleiItemDropScreen.permitVisualizer.AnimateOut();
        }
        else
        {
          kleiItemDropScreen.itemNameLabel.SetText("");
          kleiItemDropScreen.itemDescriptionLabel.SetText("");
          kleiItemDropScreen.itemRarityLabel.SetText("");
          kleiItemDropScreen.itemCategoryLabel.SetText("");
        }
        name = (string) null;
        desc = (string) null;
        categoryString = (string) null;
      }
      kleiItemDropScreen.PresentNextUnopenedItem(false);
    }
  }

  public static bool HasItemsToShow() => PermitItems.HasUnopenedItem();

  private struct ServerRequestState
  {
    public bool revealRequested;
    public bool revealConfirmedByServer;
    public bool revealRejectedByServer;

    public void Reset()
    {
      this.revealRequested = false;
      this.revealConfirmedByServer = false;
      this.revealRejectedByServer = false;
    }
  }
}
