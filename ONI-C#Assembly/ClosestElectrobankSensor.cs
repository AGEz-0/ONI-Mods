// Decompiled with JetBrains decompiler
// Type: ClosestElectrobankSensor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class ClosestElectrobankSensor : ClosestPickupableSensor<Electrobank>
{
  private Tag[] bionicIncompatiobleElectrobankTags;

  public ClosestElectrobankSensor(Sensors sensors, bool shouldStartActive)
    : base(sensors, GameTags.ChargedPortableBattery, shouldStartActive)
  {
    this.bionicIncompatiobleElectrobankTags = new Tag[GameTags.BionicIncompatibleBatteries.Count];
    GameTags.BionicIncompatibleBatteries.CopyTo(this.bionicIncompatiobleElectrobankTags, 0);
  }

  public override HashSet<Tag> GetForbbidenTags()
  {
    HashSet<Tag> forbbidenTags1 = base.GetForbbidenTags();
    if (this.bionicIncompatiobleElectrobankTags == null || this.bionicIncompatiobleElectrobankTags.Length == 0)
      return forbbidenTags1;
    HashSet<Tag> forbbidenTags2 = forbbidenTags1;
    foreach (Tag incompatiobleElectrobankTag in this.bionicIncompatiobleElectrobankTags)
    {
      if (!forbbidenTags1.Contains(incompatiobleElectrobankTag))
        forbbidenTags2.Add(incompatiobleElectrobankTag);
    }
    return forbbidenTags2;
  }
}
