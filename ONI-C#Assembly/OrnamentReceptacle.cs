// Decompiled with JetBrains decompiler
// Type: OrnamentReceptacle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class OrnamentReceptacle : SingleEntityReceptacle
{
  [MyCmpReq]
  private SnapOn snapOn;
  private KBatchedAnimTracker occupyingTracker;
  private KAnimLink animLink;

  protected override void OnPrefabInit() => base.OnPrefabInit();

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.GetComponent<KBatchedAnimController>().SetSymbolVisiblity((KAnimHashedString) "snapTo_ornament", false);
  }

  protected override void PositionOccupyingObject()
  {
    KBatchedAnimController component = this.occupyingObject.GetComponent<KBatchedAnimController>();
    component.transform.SetLocalPosition(new Vector3(0.0f, 0.0f, -0.1f));
    this.occupyingTracker = this.occupyingObject.AddComponent<KBatchedAnimTracker>();
    this.occupyingTracker.symbol = new HashedString("snapTo_ornament");
    this.occupyingTracker.forceAlwaysVisible = true;
    this.animLink = new KAnimLink((KAnimControllerBase) this.GetComponent<KBatchedAnimController>(), (KAnimControllerBase) component);
  }

  protected override void ClearOccupant()
  {
    if ((Object) this.occupyingTracker != (Object) null)
    {
      Object.Destroy((Object) this.occupyingTracker);
      this.occupyingTracker = (KBatchedAnimTracker) null;
    }
    if (this.animLink != null)
    {
      this.animLink.Unregister();
      this.animLink = (KAnimLink) null;
    }
    base.ClearOccupant();
  }
}
