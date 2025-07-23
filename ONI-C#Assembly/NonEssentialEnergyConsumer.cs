// Decompiled with JetBrains decompiler
// Type: NonEssentialEnergyConsumer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class NonEssentialEnergyConsumer : EnergyConsumer
{
  public Action<bool> PoweredStateChanged;
  private bool isPowered;

  public override bool IsPowered
  {
    get => this.isPowered;
    protected set
    {
      if (value == this.isPowered)
        return;
      this.isPowered = value;
      Action<bool> poweredStateChanged = this.PoweredStateChanged;
      if (poweredStateChanged == null)
        return;
      poweredStateChanged(this.isPowered);
    }
  }
}
