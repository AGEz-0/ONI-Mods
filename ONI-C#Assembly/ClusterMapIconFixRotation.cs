// Decompiled with JetBrains decompiler
// Type: ClusterMapIconFixRotation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ClusterMapIconFixRotation : KMonoBehaviour
{
  [MyCmpGet]
  private KBatchedAnimController animController;
  private float rotation;

  private void Update()
  {
    if (!((Object) this.transform.parent != (Object) null))
      return;
    this.rotation = -this.transform.parent.rotation.eulerAngles.z;
    this.animController.Rotation = this.rotation;
  }
}
