// Decompiled with JetBrains decompiler
// Type: MorbRoverConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class MorbRoverConfig : IEntityConfig
{
  public const string ID = "MorbRover";
  public const SimHashes MATERIAL = SimHashes.Steel;
  public const float MASS = 300f;
  private const float WIDTH = 1f;
  private const float HEIGHT = 2f;

  public GameObject CreatePrefab()
  {
    GameObject prefab = BaseRoverConfig.BaseRover("MorbRover", (string) STRINGS.ROBOTS.MODELS.MORB.NAME, GameTags.Robots.Models.MorbRover, (string) STRINGS.ROBOTS.MODELS.MORB.DESC, "morbRover_kanim", 300f, 1f, 2f, TUNING.ROBOTS.MORBBOT.CARRY_CAPACITY, 1f, 1f, 3f, TUNING.ROBOTS.MORBBOT.HIT_POINTS, 180000f, 30f, Db.Get().Amounts.InternalBioBattery, false);
    prefab.GetComponent<PrimaryElement>().SetElement(SimHashes.Steel, false);
    prefab.GetComponent<Deconstructable>().customWorkTime = 10f;
    return prefab;
  }

  public void OnPrefabInit(GameObject inst)
  {
    BaseRoverConfig.OnPrefabInit(inst, Db.Get().Amounts.InternalBioBattery);
  }

  public void OnSpawn(GameObject inst)
  {
    BaseRoverConfig.OnSpawn(inst);
    inst.Subscribe(1623392196, new Action<object>(this.TriggerDeconstructChoreOnDeath));
  }

  public void TriggerDeconstructChoreOnDeath(object obj)
  {
    if (obj == null)
      return;
    Deconstructable component = ((GameObject) obj).GetComponent<Deconstructable>();
    if (component.IsMarkedForDeconstruction())
      return;
    component.QueueDeconstruction(false);
  }
}
