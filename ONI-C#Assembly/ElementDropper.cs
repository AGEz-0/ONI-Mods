﻿// Decompiled with JetBrains decompiler
// Type: ElementDropper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ElementDropper")]
public class ElementDropper : KMonoBehaviour
{
  [SerializeField]
  public Tag emitTag;
  [SerializeField]
  public float emitMass;
  [SerializeField]
  public Vector3 emitOffset = Vector3.zero;
  [MyCmpGet]
  private Storage storage;
  private static readonly EventSystem.IntraObjectHandler<ElementDropper> OnStorageChangedDelegate = new EventSystem.IntraObjectHandler<ElementDropper>((Action<ElementDropper, object>) ((component, data) => component.OnStorageChanged(data)));

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.Subscribe<ElementDropper>(-1697596308, ElementDropper.OnStorageChangedDelegate);
  }

  private void OnStorageChanged(object data)
  {
    if ((double) this.storage.GetMassAvailable(this.emitTag) < (double) this.emitMass)
      return;
    this.storage.DropSome(this.emitTag, this.emitMass, offset: this.emitOffset, showInWorldNotification: true);
  }
}
