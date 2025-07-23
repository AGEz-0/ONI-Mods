﻿// Decompiled with JetBrains decompiler
// Type: PropSurfaceSatellite1Config
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class PropSurfaceSatellite1Config : IEntityConfig
{
  public const string ID = "PropSurfaceSatellite1";

  public GameObject CreatePrefab()
  {
    string name = (string) STRINGS.BUILDINGS.PREFABS.PROPSURFACESATELLITE1.NAME;
    string desc = (string) STRINGS.BUILDINGS.PREFABS.PROPSURFACESATELLITE1.DESC;
    EffectorValues tieR0_1 = TUNING.BUILDINGS.DECOR.BONUS.TIER0;
    EffectorValues tieR0_2 = NOISE_POLLUTION.NOISY.TIER0;
    KAnimFile anim = Assets.GetAnim((HashedString) "satellite1_kanim");
    EffectorValues decor = tieR0_1;
    EffectorValues noise = tieR0_2;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity("PropSurfaceSatellite1", name, desc, 50f, anim, "off", Grid.SceneLayer.Building, 3, 3, decor, noise, additionalTags: new List<Tag>()
    {
      GameTags.Gravitas
    });
    PrimaryElement component = placedEntity.GetComponent<PrimaryElement>();
    component.SetElement(SimHashes.Unobtanium);
    component.Temperature = 294.15f;
    Workable workable = placedEntity.AddOrGet<Workable>();
    workable.synchronizeAnims = false;
    workable.resetProgressOnStop = true;
    SetLocker setLocker = placedEntity.AddOrGet<SetLocker>();
    setLocker.overrideAnim = "anim_interacts_clothingfactory_kanim";
    setLocker.dropOffset = new Vector2I(0, 1);
    setLocker.numDataBanks = new int[2]{ 4, 9 };
    placedEntity.AddOrGet<Demolishable>();
    LoreBearerUtil.AddLoreTo(placedEntity);
    return placedEntity;
  }

  public static string[][] GetLockerBaseContents()
  {
    return new string[3][]
    {
      new string[3]
      {
        DatabankHelper.ID,
        DatabankHelper.ID,
        DatabankHelper.ID
      },
      new string[3]
      {
        "ColdBreatherSeed",
        "ColdBreatherSeed",
        "ColdBreatherSeed"
      },
      new string[4]{ "Atmo_Suit", "Glom", "Glom", "Glom" }
    };
  }

  public void OnPrefabInit(GameObject inst)
  {
    SetLocker component = inst.GetComponent<SetLocker>();
    component.possible_contents_ids = PropSurfaceSatellite1Config.GetLockerBaseContents();
    component.ChooseContents();
    inst.GetComponent<OccupyArea>().objectLayers = new ObjectLayer[1]
    {
      ObjectLayer.Building
    };
    RadiationEmitter radiationEmitter = inst.AddOrGet<RadiationEmitter>();
    radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
    radiationEmitter.radiusProportionalToRads = false;
    radiationEmitter.emitRadiusX = (short) 12;
    radiationEmitter.emitRadiusY = (short) 12;
    radiationEmitter.emitRads = (float) (2400.0 / ((double) radiationEmitter.emitRadiusX / 6.0));
  }

  public void OnSpawn(GameObject inst)
  {
    RadiationEmitter component = inst.GetComponent<RadiationEmitter>();
    if (!((Object) component != (Object) null))
      return;
    component.SetEmitting(true);
  }
}
