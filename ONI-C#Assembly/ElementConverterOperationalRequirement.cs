// Decompiled with JetBrains decompiler
// Type: ElementConverterOperationalRequirement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class ElementConverterOperationalRequirement : KMonoBehaviour
{
  [MyCmpReq]
  private ElementConverter converter;
  [MyCmpReq]
  private Operational operational;
  private Operational.Flag.Type operationalReq;
  private Operational.Flag sufficientResources;

  private void onStorageChanged(object _)
  {
    this.operational.SetFlag(this.sufficientResources, this.converter.HasEnoughMassToStartConverting());
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.sufficientResources = new Operational.Flag("sufficientResources", this.operationalReq);
    this.Subscribe(-1697596308, new Action<object>(this.onStorageChanged));
    this.onStorageChanged((object) null);
  }
}
