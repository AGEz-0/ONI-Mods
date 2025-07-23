// Decompiled with JetBrains decompiler
// Type: Cancellable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
[AddComponentMenu("KMonoBehaviour/scripts/Cancellable")]
public class Cancellable : KMonoBehaviour
{
  private static readonly EventSystem.IntraObjectHandler<Cancellable> OnCancelDelegate = new EventSystem.IntraObjectHandler<Cancellable>((Action<Cancellable, object>) ((component, data) => component.OnCancel(data)));

  protected override void OnPrefabInit()
  {
    this.Subscribe<Cancellable>(2127324410, Cancellable.OnCancelDelegate);
  }

  protected virtual void OnCancel(object data) => this.DeleteObject();
}
