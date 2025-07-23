// Decompiled with JetBrains decompiler
// Type: BubbleSpawner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/BubbleSpawner")]
public class BubbleSpawner : KMonoBehaviour
{
  public SimHashes element;
  public float emitMass;
  public float emitVariance;
  public Vector3 emitOffset = Vector3.zero;
  public Vector2 initialVelocity;
  [MyCmpGet]
  private Storage storage;
  private static readonly EventSystem.IntraObjectHandler<BubbleSpawner> OnStorageChangedDelegate = new EventSystem.IntraObjectHandler<BubbleSpawner>((Action<BubbleSpawner, object>) ((component, data) => component.OnStorageChanged(data)));

  protected override void OnSpawn()
  {
    this.emitMass += (UnityEngine.Random.value - 0.5f) * this.emitVariance * this.emitMass;
    base.OnSpawn();
    this.Subscribe<BubbleSpawner>(-1697596308, BubbleSpawner.OnStorageChangedDelegate);
  }

  private void OnStorageChanged(object data)
  {
    GameObject first = this.storage.FindFirst(ElementLoader.FindElementByHash(this.element).tag);
    if ((UnityEngine.Object) first == (UnityEngine.Object) null)
      return;
    PrimaryElement component = first.GetComponent<PrimaryElement>();
    if ((double) component.Mass < (double) this.emitMass)
      return;
    first.GetComponent<PrimaryElement>().Mass -= this.emitMass;
    BubbleManager.instance.SpawnBubble((Vector2) this.transform.GetPosition(), this.initialVelocity, component.ElementID, this.emitMass, component.Temperature);
  }
}
