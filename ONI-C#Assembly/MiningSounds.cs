// Decompiled with JetBrains decompiler
// Type: MiningSounds
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using FMODUnity;
using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/MiningSounds")]
public class MiningSounds : KMonoBehaviour
{
  private static HashedString HASH_PERCENTCOMPLETE = (HashedString) "percentComplete";
  [MyCmpGet]
  private LoopingSounds loopingSounds;
  private FMODAsset miningSound;
  private EventReference miningSoundEvent;
  private static readonly EventSystem.IntraObjectHandler<MiningSounds> OnStartMiningSoundDelegate = new EventSystem.IntraObjectHandler<MiningSounds>((Action<MiningSounds, object>) ((component, data) => component.OnStartMiningSound(data)));
  private static readonly EventSystem.IntraObjectHandler<MiningSounds> OnStopMiningSoundDelegate = new EventSystem.IntraObjectHandler<MiningSounds>((Action<MiningSounds, object>) ((component, data) => component.OnStopMiningSound(data)));

  protected override void OnPrefabInit()
  {
    this.Subscribe<MiningSounds>(-1762453998, MiningSounds.OnStartMiningSoundDelegate);
    this.Subscribe<MiningSounds>(939543986, MiningSounds.OnStopMiningSoundDelegate);
  }

  private void OnStartMiningSound(object data)
  {
    if (!((UnityEngine.Object) this.miningSound == (UnityEngine.Object) null) || !(data is Element element))
      return;
    string miningSound = element.substance.GetMiningSound();
    switch (miningSound)
    {
      case null:
        break;
      case "":
        break;
      default:
        this.miningSoundEvent = RuntimeManager.PathToEventReference(GlobalAssets.GetSound("Mine_" + miningSound));
        if (this.miningSoundEvent.IsNull)
          break;
        this.loopingSounds.StartSound(this.miningSoundEvent);
        break;
    }
  }

  private void OnStopMiningSound(object data)
  {
    if (this.miningSoundEvent.IsNull)
      return;
    this.loopingSounds.StopSound(this.miningSoundEvent);
    this.miningSound = (FMODAsset) null;
  }

  public void SetPercentComplete(float progress)
  {
    if (this.miningSoundEvent.IsNull)
      return;
    this.loopingSounds.SetParameter(this.miningSoundEvent, MiningSounds.HASH_PERCENTCOMPLETE, progress);
  }
}
