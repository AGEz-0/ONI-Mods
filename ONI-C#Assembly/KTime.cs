// Decompiled with JetBrains decompiler
// Type: KTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/KTime")]
public class KTime : KMonoBehaviour
{
  public float UnscaledGameTime { get; set; }

  public static KTime Instance { get; private set; }

  public static void DestroyInstance() => KTime.Instance = (KTime) null;

  protected override void OnPrefabInit()
  {
    KTime.Instance = this;
    this.UnscaledGameTime = Time.unscaledTime;
  }

  protected override void OnCleanUp() => KTime.Instance = (KTime) null;

  public void Update()
  {
    if (SpeedControlScreen.Instance.IsPaused)
      return;
    this.UnscaledGameTime += Time.unscaledDeltaTime;
  }
}
