// Decompiled with JetBrains decompiler
// Type: CoroutineRunner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class CoroutineRunner : MonoBehaviour
{
  public Promise Run(IEnumerator routine)
  {
    return new Promise((Action<System.Action>) (resolve => this.StartCoroutine(this.RunRoutine(routine, resolve))));
  }

  public (Promise, System.Action) RunCancellable(IEnumerator routine)
  {
    Promise promise = new Promise();
    Coroutine coroutine = this.StartCoroutine(this.RunRoutine(routine, new System.Action(promise.Resolve)));
    System.Action action = (System.Action) (() => this.StopCoroutine(coroutine));
    return (promise, action);
  }

  private IEnumerator RunRoutine(IEnumerator routine, System.Action completedCallback)
  {
    yield return (object) routine;
    completedCallback();
  }

  public static CoroutineRunner Create()
  {
    return new GameObject(nameof (CoroutineRunner)).AddComponent<CoroutineRunner>();
  }

  public static Promise RunOne(IEnumerator routine)
  {
    CoroutineRunner runner = CoroutineRunner.Create();
    return runner.Run(routine).Then((System.Action) (() => UnityEngine.Object.Destroy((UnityEngine.Object) runner.gameObject)));
  }
}
