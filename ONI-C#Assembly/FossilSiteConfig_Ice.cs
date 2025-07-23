﻿// Decompiled with JetBrains decompiler
// Type: FossilSiteConfig_Ice
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class FossilSiteConfig_Ice : IEntityConfig
{
  public static readonly HashedString FossilQuestCriteriaID = (HashedString) "LostIceFossil";
  public const string ID = "FossilIce";

  public GameObject CreatePrefab()
  {
    string name = (string) CODEX.STORY_TRAITS.FOSSILHUNT.ENTITIES.FOSSIL_ICE.NAME;
    string desc = (string) CODEX.STORY_TRAITS.FOSSILHUNT.ENTITIES.FOSSIL_ICE.DESC;
    EffectorValues tieR4 = TUNING.BUILDINGS.DECOR.BONUS.TIER4;
    EffectorValues tieR3 = NOISE_POLLUTION.NOISY.TIER3;
    KAnimFile anim = Assets.GetAnim((HashedString) "fossil_ice_kanim");
    EffectorValues decor = tieR4;
    EffectorValues noise = tieR3;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity("FossilIce", name, desc, 4000f, anim, "object", Grid.SceneLayer.BuildingBack, 2, 2, decor, noise, additionalTags: new List<Tag>()
    {
      GameTags.Gravitas
    });
    PrimaryElement component = placedEntity.GetComponent<PrimaryElement>();
    component.SetElement(SimHashes.Fossil);
    component.Temperature = 230f;
    placedEntity.AddOrGet<Operational>();
    placedEntity.AddOrGet<EntombVulnerable>();
    placedEntity.AddOrGet<Demolishable>().allowDemolition = false;
    placedEntity.AddOrGetDef<MinorFossilDigSite.Def>().fossilQuestCriteriaID = FossilSiteConfig_Ice.FossilQuestCriteriaID;
    placedEntity.AddOrGetDef<FossilHuntInitializer.Def>();
    placedEntity.AddOrGet<MinorDigSiteWorkable>();
    placedEntity.AddOrGet<Prioritizable>();
    Prioritizable.AddRef(placedEntity);
    placedEntity.AddOrGet<LoopingSounds>();
    return placedEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
    inst.GetComponent<EntombVulnerable>().SetStatusItem(Db.Get().BuildingStatusItems.FossilEntombed);
    inst.GetComponent<OccupyArea>().objectLayers = new ObjectLayer[1]
    {
      ObjectLayer.Building
    };
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
