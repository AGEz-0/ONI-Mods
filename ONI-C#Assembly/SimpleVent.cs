// Decompiled with JetBrains decompiler
// Type: SimpleVent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SimpleVent")]
public class SimpleVent : KMonoBehaviour
{
  [MyCmpGet]
  private Operational operational;
  private static readonly EventSystem.IntraObjectHandler<SimpleVent> OnChangedDelegate = new EventSystem.IntraObjectHandler<SimpleVent>((Action<SimpleVent, object>) ((component, data) => component.OnChanged(data)));

  protected override void OnPrefabInit()
  {
    this.Subscribe<SimpleVent>(-592767678, SimpleVent.OnChangedDelegate);
    this.Subscribe<SimpleVent>(-111137758, SimpleVent.OnChangedDelegate);
  }

  protected override void OnSpawn() => this.OnChanged((object) null);

  private void OnChanged(object data)
  {
    if (this.operational.IsFunctional)
      this.GetComponent<KSelectable>().SetStatusItem(Db.Get().StatusItemCategories.Main, Db.Get().BuildingStatusItems.Normal, (object) this);
    else
      this.GetComponent<KSelectable>().SetStatusItem(Db.Get().StatusItemCategories.Main, (StatusItem) null);
  }
}
