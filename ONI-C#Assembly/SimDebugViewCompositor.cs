// Decompiled with JetBrains decompiler
// Type: SimDebugViewCompositor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SimDebugViewCompositor : MonoBehaviour
{
  public Material material;
  public static SimDebugViewCompositor Instance;

  private void Awake() => SimDebugViewCompositor.Instance = this;

  private void OnDestroy() => SimDebugViewCompositor.Instance = (SimDebugViewCompositor) null;

  private void Start()
  {
    this.material = new Material(Shader.Find("Klei/PostFX/SimDebugViewCompositor"));
    this.Toggle(false);
  }

  private void OnRenderImage(RenderTexture src, RenderTexture dest)
  {
    Graphics.Blit((Texture) src, dest, this.material);
  }

  public void Toggle(bool is_on) => this.enabled = is_on;
}
