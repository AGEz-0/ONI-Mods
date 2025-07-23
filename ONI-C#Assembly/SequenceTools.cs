// Decompiled with JetBrains decompiler
// Type: SequenceTools
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

#nullable disable
public static class SequenceTools
{
  public static WaitUntil Interpolate(
    this MonoBehaviour owner,
    Action<float> action,
    float duration,
    System.Action then = null)
  {
    return owner.Interpolate(action, duration, out Coroutine _, then);
  }

  public static WaitUntil Interpolate(
    this MonoBehaviour owner,
    Action<float> action,
    float duration,
    out Coroutine coroutineOut,
    System.Action then = null)
  {
    bool completed = false;
    System.Action then1 = (System.Action) (() =>
    {
      if (then != null)
        then();
      completed = true;
    });
    coroutineOut = owner.StartCoroutine(SequenceTools.InterpolateCoroutineLogic(action, duration, then1));
    return new WaitUntil((Func<bool>) (() => completed));
  }

  private static IEnumerator InterpolateCoroutineLogic(
    Action<float> action,
    float duration,
    System.Action then)
  {
    float timer = 0.0f;
    while ((double) timer < (double) duration)
    {
      action(timer / duration);
      timer += Time.unscaledDeltaTime;
      yield return (object) null;
    }
    action(1f);
    yield return (object) null;
    if (then != null)
      then();
  }

  public static void TextEraser(LocText label, string text, float progress)
  {
    string text1 = text.Substring(0, Mathf.CeilToInt((float) text.Length * (1f - progress)));
    label.SetText(text1);
    label.ForceMeshUpdate();
  }

  public static void TextWriter(LocText label, string text, float progress)
  {
    string text1 = (double) progress == 1.0 ? text : text.Substring(0, Mathf.CeilToInt((float) text.Length * progress));
    label.SetText(text1);
    label.ForceMeshUpdate();
  }
}
