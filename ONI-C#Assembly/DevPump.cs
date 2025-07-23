// Decompiled with JetBrains decompiler
// Type: DevPump
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class DevPump : Filterable, ISim1000ms
{
  public Filterable.ElementState elementState = Filterable.ElementState.Liquid;
  [MyCmpReq]
  private Storage storage;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    if (this.elementState == Filterable.ElementState.Liquid)
    {
      this.SelectedTag = ElementLoader.FindElementByHash(SimHashes.Water).tag;
    }
    else
    {
      if (this.elementState != Filterable.ElementState.Gas)
        return;
      this.SelectedTag = ElementLoader.FindElementByHash(SimHashes.Oxygen).tag;
    }
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.filterElementState = this.elementState;
  }

  public void Sim1000ms(float dt)
  {
    if (!this.SelectedTag.IsValid)
      return;
    float mass = 10f - this.storage.GetAmountAvailable(this.SelectedTag);
    if ((double) mass <= 0.0)
      return;
    Element element = ElementLoader.GetElement(this.SelectedTag);
    GameObject prefab = Assets.TryGetPrefab(this.SelectedTag);
    if (element != null)
    {
      this.storage.AddElement(element.id, mass, element.defaultValues.temperature, byte.MaxValue, 0, do_disease_transfer: false);
    }
    else
    {
      if (!((Object) prefab != (Object) null))
        return;
      Grid.SceneLayer sceneLayer = prefab.GetComponent<KBatchedAnimController>().sceneLayer;
      GameObject go = GameUtil.KInstantiate(prefab, sceneLayer);
      go.GetComponent<PrimaryElement>().Units = mass;
      go.SetActive(true);
      this.storage.Store(go, true);
    }
  }
}
