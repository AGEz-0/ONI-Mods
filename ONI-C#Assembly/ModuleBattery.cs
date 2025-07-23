// Decompiled with JetBrains decompiler
// Type: ModuleBattery
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class ModuleBattery : Battery
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.connectedTags = new Tag[0];
    this.IsVirtual = true;
  }

  protected override void OnSpawn()
  {
    this.VirtualCircuitKey = (object) this.GetComponent<RocketModuleCluster>().CraftInterface;
    base.OnSpawn();
    this.meter.gameObject.GetComponent<KBatchedAnimTracker>().matchParentOffset = true;
  }
}
