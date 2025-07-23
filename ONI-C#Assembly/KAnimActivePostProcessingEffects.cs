// Decompiled with JetBrains decompiler
// Type: KAnimActivePostProcessingEffects
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class KAnimActivePostProcessingEffects : KMonoBehaviour
{
  private KAnimConverter.PostProcessingEffects currentActiveEffects;

  public void EnableEffect(KAnimConverter.PostProcessingEffects effect_flag)
  {
    this.currentActiveEffects |= effect_flag;
  }

  public void DisableEffect(KAnimConverter.PostProcessingEffects effect_flag)
  {
    if (!this.IsEffectActive(effect_flag))
      return;
    this.currentActiveEffects ^= effect_flag;
  }

  public bool IsEffectActive(KAnimConverter.PostProcessingEffects effect_flag)
  {
    return (this.currentActiveEffects & effect_flag) != 0;
  }

  private void OnRenderImage(RenderTexture source, RenderTexture destination)
  {
    Graphics.Blit((Texture) source, destination);
    if (this.currentActiveEffects == (KAnimConverter.PostProcessingEffects) 0)
      return;
    KAnimBatchManager.Instance().RenderKAnimPostProcessingEffects(this.currentActiveEffects);
  }
}
