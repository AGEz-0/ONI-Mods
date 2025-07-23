// Decompiled with JetBrains decompiler
// Type: ArtifactModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class ArtifactModule : SingleEntityReceptacle, IRenderEveryTick
{
  [MyCmpReq]
  private KBatchedAnimController animController;
  [MyCmpReq]
  private RocketModuleCluster module;
  private Clustercraft craft;

  protected override void OnSpawn()
  {
    this.craft = this.module.CraftInterface.GetComponent<Clustercraft>();
    if (this.craft.Status == Clustercraft.CraftStatus.InFlight && (UnityEngine.Object) this.occupyingObject != (UnityEngine.Object) null)
      this.occupyingObject.SetActive(false);
    base.OnSpawn();
    this.Subscribe(705820818, new Action<object>(this.OnEnterSpace));
    this.Subscribe(-1165815793, new Action<object>(this.OnExitSpace));
  }

  public void RenderEveryTick(float dt) => this.ArtifactTrackModulePosition();

  private void ArtifactTrackModulePosition()
  {
    this.occupyingObjectRelativePosition = this.animController.Offset + Vector3.up * 0.5f + new Vector3(0.0f, 0.0f, -1f);
    if (!((UnityEngine.Object) this.occupyingObject != (UnityEngine.Object) null))
      return;
    this.PositionOccupyingObject();
  }

  private void OnEnterSpace(object data)
  {
    if (!((UnityEngine.Object) this.occupyingObject != (UnityEngine.Object) null))
      return;
    this.occupyingObject.SetActive(false);
  }

  private void OnExitSpace(object data)
  {
    if (!((UnityEngine.Object) this.occupyingObject != (UnityEngine.Object) null))
      return;
    this.occupyingObject.SetActive(true);
  }
}
