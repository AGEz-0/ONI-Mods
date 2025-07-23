﻿// Decompiled with JetBrains decompiler
// Type: ExpandRevealUIContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class ExpandRevealUIContent : MonoBehaviour
{
  private Coroutine activeRoutine;
  private Action<object> activeRoutineCompleteCallback;
  public AnimationCurve expandAnimation;
  public AnimationCurve collapseAnimation;
  public KRectStretcher MaskRectStretcher;
  public KRectStretcher BGRectStretcher;
  public KChildFitter MaskChildFitter;
  public KChildFitter BGChildFitter;
  public float speedScale = 1f;
  public bool Collapsing;
  public bool Expanding;

  private void OnDisable()
  {
    if ((bool) (UnityEngine.Object) this.BGChildFitter)
      this.BGChildFitter.WidthScale = this.BGChildFitter.HeightScale = 0.0f;
    if ((bool) (UnityEngine.Object) this.MaskChildFitter)
    {
      if (this.MaskChildFitter.fitWidth)
        this.MaskChildFitter.WidthScale = 0.0f;
      if (this.MaskChildFitter.fitHeight)
        this.MaskChildFitter.HeightScale = 0.0f;
    }
    if ((bool) (UnityEngine.Object) this.BGRectStretcher)
    {
      this.BGRectStretcher.XStretchFactor = this.BGRectStretcher.YStretchFactor = 0.0f;
      this.BGRectStretcher.UpdateStretching();
    }
    if (!(bool) (UnityEngine.Object) this.MaskRectStretcher)
      return;
    this.MaskRectStretcher.XStretchFactor = this.MaskRectStretcher.YStretchFactor = 0.0f;
    this.MaskRectStretcher.UpdateStretching();
  }

  public void Expand(Action<object> completeCallback)
  {
    if ((bool) (UnityEngine.Object) this.MaskChildFitter && (bool) (UnityEngine.Object) this.MaskRectStretcher)
      Debug.LogWarning((object) "ExpandRevealUIContent has references to both a MaskChildFitter and a MaskRectStretcher. It should have only one or the other. ChildFitter to match child size, RectStretcher to match parent size.");
    if ((bool) (UnityEngine.Object) this.BGChildFitter && (bool) (UnityEngine.Object) this.BGRectStretcher)
      Debug.LogWarning((object) "ExpandRevealUIContent has references to both a BGChildFitter and a BGRectStretcher . It should have only one or the other.  ChildFitter to match child size, RectStretcher to match parent size.");
    if (this.activeRoutine != null)
      this.StopCoroutine(this.activeRoutine);
    this.CollapsedImmediate();
    this.activeRoutineCompleteCallback = completeCallback;
    this.activeRoutine = this.StartCoroutine(this.ExpandRoutine((Action<object>) null));
  }

  public void Collapse(Action<object> completeCallback)
  {
    if (this.activeRoutine != null)
    {
      if (this.activeRoutineCompleteCallback != null)
        this.activeRoutineCompleteCallback((object) null);
      this.StopCoroutine(this.activeRoutine);
    }
    this.activeRoutineCompleteCallback = completeCallback;
    if (this.gameObject.activeInHierarchy)
    {
      this.activeRoutine = this.StartCoroutine(this.CollapseRoutine(completeCallback));
    }
    else
    {
      this.activeRoutine = (Coroutine) null;
      if (completeCallback == null)
        return;
      completeCallback((object) null);
    }
  }

  private IEnumerator ExpandRoutine(Action<object> completeCallback)
  {
    this.Collapsing = false;
    this.Expanding = true;
    float num = 0.0f;
    foreach (Keyframe key in this.expandAnimation.keys)
    {
      if ((double) key.time > (double) num)
        num = key.time;
    }
    float duration = num / this.speedScale;
    for (float remaining = duration; (double) remaining >= 0.0; remaining -= Time.unscaledDeltaTime * this.speedScale)
    {
      this.SetStretch(this.expandAnimation.Evaluate(duration - remaining));
      yield return (object) null;
    }
    this.SetStretch(this.expandAnimation.Evaluate(duration));
    if (completeCallback != null)
      completeCallback((object) null);
    this.activeRoutine = (Coroutine) null;
    this.Expanding = false;
  }

  private void SetStretch(float value)
  {
    if ((bool) (UnityEngine.Object) this.BGRectStretcher)
    {
      if (this.BGRectStretcher.StretchX)
        this.BGRectStretcher.XStretchFactor = value;
      if (this.BGRectStretcher.StretchY)
        this.BGRectStretcher.YStretchFactor = value;
    }
    if ((bool) (UnityEngine.Object) this.MaskRectStretcher)
    {
      if (this.MaskRectStretcher.StretchX)
        this.MaskRectStretcher.XStretchFactor = value;
      if (this.MaskRectStretcher.StretchY)
        this.MaskRectStretcher.YStretchFactor = value;
    }
    if ((bool) (UnityEngine.Object) this.BGChildFitter)
    {
      if (this.BGChildFitter.fitWidth)
        this.BGChildFitter.WidthScale = value;
      if (this.BGChildFitter.fitHeight)
        this.BGChildFitter.HeightScale = value;
    }
    if (!(bool) (UnityEngine.Object) this.MaskChildFitter)
      return;
    if (this.MaskChildFitter.fitWidth)
      this.MaskChildFitter.WidthScale = value;
    if (!this.MaskChildFitter.fitHeight)
      return;
    this.MaskChildFitter.HeightScale = value;
  }

  private IEnumerator CollapseRoutine(Action<object> completeCallback)
  {
    ExpandRevealUIContent expandRevealUiContent = this;
    expandRevealUiContent.Expanding = false;
    expandRevealUiContent.Collapsing = true;
    float num = 0.0f;
    foreach (Keyframe key in expandRevealUiContent.collapseAnimation.keys)
    {
      if ((double) key.time > (double) num)
        num = key.time;
    }
    float duration = num;
    for (float remaining = duration; (double) remaining >= 0.0; remaining -= Time.unscaledDeltaTime)
    {
      expandRevealUiContent.SetStretch(expandRevealUiContent.collapseAnimation.Evaluate(duration - remaining));
      yield return (object) null;
    }
    expandRevealUiContent.SetStretch(expandRevealUiContent.collapseAnimation.Evaluate(duration));
    if (completeCallback != null)
      completeCallback((object) null);
    expandRevealUiContent.activeRoutine = (Coroutine) null;
    expandRevealUiContent.Collapsing = false;
    expandRevealUiContent.gameObject.SetActive(false);
  }

  public void CollapsedImmediate()
  {
    this.SetStretch(this.collapseAnimation.Evaluate((float) this.collapseAnimation.length));
  }
}
