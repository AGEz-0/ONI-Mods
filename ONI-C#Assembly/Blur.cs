// Decompiled with JetBrains decompiler
// Type: Blur
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public static class Blur
{
  private static Material blurMaterial;

  public static RenderTexture Run(Texture2D image)
  {
    if ((Object) Blur.blurMaterial == (Object) null)
      Blur.blurMaterial = new Material(Shader.Find("Klei/PostFX/Blur"));
    return (RenderTexture) null;
  }
}
