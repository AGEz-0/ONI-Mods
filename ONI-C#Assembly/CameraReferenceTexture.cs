// Decompiled with JetBrains decompiler
// Type: CameraReferenceTexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class CameraReferenceTexture : MonoBehaviour
{
  public Camera referenceCamera;
  private FullScreenQuad quad;

  private void OnPreCull()
  {
    if (this.quad == null)
      this.quad = new FullScreenQuad(nameof (CameraReferenceTexture), this.GetComponent<Camera>(), this.referenceCamera.GetComponent<CameraRenderTexture>().ShouldFlip());
    if (!((Object) this.referenceCamera != (Object) null))
      return;
    this.quad.Draw((Texture) this.referenceCamera.GetComponent<CameraRenderTexture>().GetTexture());
  }
}
