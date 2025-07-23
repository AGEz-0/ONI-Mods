// Decompiled with JetBrains decompiler
// Type: CustomActiveScreenPostProcessingEffects
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class CustomActiveScreenPostProcessingEffects : MonoBehaviour
{
  private List<Func<RenderTexture, Material>> ActiveEffects = new List<Func<RenderTexture, Material>>();
  private RenderTexture previousSource;
  private RenderTexture previousDestination;

  public void RegisterEffect(Func<RenderTexture, Material> effectFn)
  {
    this.ActiveEffects.Add(effectFn);
  }

  public void UnregisterEffect(Func<RenderTexture, Material> effectFn)
  {
    this.ActiveEffects.Remove(effectFn);
  }

  private void OnRenderImage(RenderTexture source, RenderTexture destination)
  {
    this.CheckTemporaryRenderTextureValidity(ref this.previousSource, source);
    this.CheckTemporaryRenderTextureValidity(ref this.previousDestination, source);
    Graphics.Blit((Texture) source, this.previousSource);
    foreach (Func<RenderTexture, Material> activeEffect in this.ActiveEffects)
    {
      Graphics.Blit((Texture) this.previousSource, this.previousDestination, activeEffect(source));
      this.previousSource.DiscardContents();
      Graphics.Blit((Texture) this.previousDestination, this.previousSource);
    }
    Graphics.Blit((Texture) this.previousSource, destination);
    this.previousSource.Release();
    this.previousDestination.Release();
  }

  private void CheckTemporaryRenderTextureValidity(
    ref RenderTexture temporaryTexture,
    RenderTexture source)
  {
    if (!((UnityEngine.Object) temporaryTexture == (UnityEngine.Object) null) && temporaryTexture.width == source.width && temporaryTexture.height == source.height && temporaryTexture.depth == source.depth && temporaryTexture.format == source.format)
      return;
    if ((UnityEngine.Object) temporaryTexture != (UnityEngine.Object) null)
      temporaryTexture.Release();
    temporaryTexture = RenderTexture.GetTemporary(source.width, source.height, source.depth, source.format);
  }
}
