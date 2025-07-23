// Decompiled with JetBrains decompiler
// Type: AmbientSoundManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/AmbientSoundManager")]
public class AmbientSoundManager : KMonoBehaviour
{
  [MyCmpAdd]
  private LoopingSounds loopingSounds;

  public static AmbientSoundManager Instance { get; private set; }

  public static void Destroy() => AmbientSoundManager.Instance = (AmbientSoundManager) null;

  protected override void OnPrefabInit() => AmbientSoundManager.Instance = this;

  protected override void OnSpawn() => base.OnSpawn();

  protected override void OnCleanUp()
  {
    base.OnCleanUp();
    AmbientSoundManager.Instance = (AmbientSoundManager) null;
  }
}
