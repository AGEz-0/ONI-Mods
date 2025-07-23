// Decompiled with JetBrains decompiler
// Type: SpaceScannerTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public readonly struct SpaceScannerTarget
{
  public readonly string id;

  private SpaceScannerTarget(string id) => this.id = id;

  public static SpaceScannerTarget MeteorShower() => new SpaceScannerTarget("meteor_shower");

  public static SpaceScannerTarget BallisticObject() => new SpaceScannerTarget("ballistic_object");

  public static SpaceScannerTarget RocketBaseGame(LaunchConditionManager rocket)
  {
    return new SpaceScannerTarget($"rocket_base_game::{rocket.GetComponent<KPrefabID>().InstanceID}");
  }

  public static SpaceScannerTarget RocketDlc1(Clustercraft rocket)
  {
    return new SpaceScannerTarget($"rocket_dlc1::{rocket.GetComponent<KPrefabID>().InstanceID}");
  }
}
