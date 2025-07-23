// Decompiled with JetBrains decompiler
// Type: ResearchButtonImageToggleState
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ResearchButtonImageToggleState : ImageToggleState
{
  public Image progressBar;
  private KToggle toggle;
  [Header("Scroll Options")]
  public float researchLogoDuration = 5f;
  public float durationPerResearchItemIcon = 0.6f;
  public float fadingDuration = 0.2f;
  private Coroutine scrollIconCoroutine;
  private Sprite[] currentResearchIcons;
  private float mainIconScreenTime;
  private float itemScreenTime;
  private int item_idx = -1;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    Research.Instance.Subscribe(-1914338957, new Action<object>(this.UpdateActiveResearch));
    Research.Instance.Subscribe(-125623018, new Action<object>(this.RefreshProgressBar));
    this.toggle = this.GetComponent<KToggle>();
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.UpdateActiveResearch((object) null);
    this.RestartCoroutine();
  }

  protected override void OnCleanUp()
  {
    this.AbortCoroutine();
    Research.Instance.Unsubscribe(-1914338957, new Action<object>(this.UpdateActiveResearch));
    Research.Instance.Unsubscribe(-125623018, new Action<object>(this.RefreshProgressBar));
    base.OnCleanUp();
  }

  protected override void OnCmpEnable()
  {
    base.OnCmpEnable();
    this.RestartCoroutine();
  }

  protected override void OnCmpDisable()
  {
    base.OnCmpDisable();
    this.AbortCoroutine();
  }

  private void AbortCoroutine()
  {
    if (this.scrollIconCoroutine != null)
      this.StopCoroutine(this.scrollIconCoroutine);
    this.scrollIconCoroutine = (Coroutine) null;
  }

  private void RestartCoroutine()
  {
    this.AbortCoroutine();
    if (!this.gameObject.activeInHierarchy)
      return;
    this.scrollIconCoroutine = this.StartCoroutine(this.ScrollIcon());
  }

  private void UpdateActiveResearch(object o)
  {
    TechInstance activeResearch = Research.Instance.GetActiveResearch();
    if (activeResearch == null)
    {
      this.currentResearchIcons = (Sprite[]) null;
    }
    else
    {
      this.currentResearchIcons = new Sprite[activeResearch.tech.unlockedItems.Count];
      for (int index = 0; index < activeResearch.tech.unlockedItems.Count; ++index)
      {
        TechItem unlockedItem = activeResearch.tech.unlockedItems[index];
        this.currentResearchIcons[index] = unlockedItem.UISprite();
      }
    }
    this.ResetCoroutineTimers();
    this.RefreshProgressBar(o);
  }

  public void RefreshProgressBar(object o)
  {
    TechInstance activeResearch = Research.Instance.GetActiveResearch();
    if (activeResearch == null)
      this.progressBar.fillAmount = 0.0f;
    else
      this.progressBar.fillAmount = activeResearch.GetTotalPercentageComplete();
  }

  public void SetProgressBarVisibility(bool viisble) => this.progressBar.enabled = viisble;

  public override void SetActive()
  {
    base.SetActive();
    this.SetProgressBarVisibility(false);
  }

  public override void SetDisabledActive()
  {
    base.SetDisabledActive();
    this.SetProgressBarVisibility(false);
  }

  public override void SetDisabled()
  {
    base.SetDisabled();
    this.SetProgressBarVisibility(false);
  }

  public override void SetInactive()
  {
    base.SetInactive();
    this.SetProgressBarVisibility(true);
    this.RefreshProgressBar((object) null);
  }

  private void ResetCoroutineTimers()
  {
    this.mainIconScreenTime = 0.0f;
    this.itemScreenTime = 0.0f;
    this.item_idx = -1;
  }

  private bool ReadyToDisplayIcons
  {
    get
    {
      return this.progressBar.enabled && this.currentResearchIcons != null && this.item_idx >= 0 && this.item_idx < this.currentResearchIcons.Length;
    }
  }

  private IEnumerator ScrollIcon()
  {
    ResearchButtonImageToggleState imageToggleState = this;
    while (Application.isPlaying)
    {
      if ((double) imageToggleState.mainIconScreenTime < (double) imageToggleState.researchLogoDuration)
      {
        imageToggleState.toggle.fgImage.Opacity(1f);
        if ((UnityEngine.Object) imageToggleState.toggle.fgImage.overrideSprite != (UnityEngine.Object) null)
          imageToggleState.toggle.fgImage.overrideSprite = (Sprite) null;
        imageToggleState.item_idx = 0;
        imageToggleState.itemScreenTime = 0.0f;
        imageToggleState.mainIconScreenTime += Time.unscaledDeltaTime;
        if (imageToggleState.progressBar.enabled && (double) imageToggleState.mainIconScreenTime >= (double) imageToggleState.researchLogoDuration && imageToggleState.ReadyToDisplayIcons)
        {
          // ISSUE: reference to a compiler-generated method
          yield return (object) imageToggleState.toggle.fgImage.FadeAway(imageToggleState.fadingDuration, new Func<bool>(imageToggleState.\u003CScrollIcon\u003Eb__27_0));
        }
        yield return (object) null;
      }
      else if (imageToggleState.ReadyToDisplayIcons)
      {
        if ((UnityEngine.Object) imageToggleState.toggle.fgImage.overrideSprite != (UnityEngine.Object) imageToggleState.currentResearchIcons[imageToggleState.item_idx])
          imageToggleState.toggle.fgImage.overrideSprite = imageToggleState.currentResearchIcons[imageToggleState.item_idx];
        // ISSUE: reference to a compiler-generated method
        yield return (object) imageToggleState.toggle.fgImage.FadeToVisible(imageToggleState.fadingDuration, new Func<bool>(imageToggleState.\u003CScrollIcon\u003Eb__27_1));
        while ((double) imageToggleState.itemScreenTime < (double) imageToggleState.durationPerResearchItemIcon && imageToggleState.ReadyToDisplayIcons)
        {
          imageToggleState.itemScreenTime += Time.unscaledDeltaTime;
          yield return (object) null;
        }
        // ISSUE: reference to a compiler-generated method
        yield return (object) imageToggleState.toggle.fgImage.FadeAway(imageToggleState.fadingDuration, new Func<bool>(imageToggleState.\u003CScrollIcon\u003Eb__27_2));
        if (imageToggleState.ReadyToDisplayIcons)
        {
          imageToggleState.itemScreenTime = 0.0f;
          ++imageToggleState.item_idx;
        }
        yield return (object) null;
      }
      else
      {
        imageToggleState.mainIconScreenTime = 0.0f;
        yield return (object) null;
      }
    }
  }
}
