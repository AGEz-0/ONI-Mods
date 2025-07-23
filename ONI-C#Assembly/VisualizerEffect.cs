// Decompiled with JetBrains decompiler
// Type: VisualizerEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class VisualizerEffect : MonoBehaviour
{
  protected Material material;
  protected Camera myCamera;
  protected Texture2D OcclusionTex;

  protected abstract void SetupMaterial();

  protected abstract void SetupOcclusionTex();

  protected abstract void OnPostRender();

  protected virtual void Start()
  {
    this.SetupMaterial();
    this.SetupOcclusionTex();
    this.myCamera = this.GetComponent<Camera>();
  }
}
