// Decompiled with JetBrains decompiler
// Type: FossilBitsSmallConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class FossilBitsSmallConfig : IEntityConfig
{
  public const string ID = "FossilBitsSmall";

  public GameObject CreatePrefab()
  {
    string name = (string) CODEX.STORY_TRAITS.FOSSILHUNT.ENTITIES.FOSSIL_BITS.NAME;
    string desc = (string) CODEX.STORY_TRAITS.FOSSILHUNT.ENTITIES.FOSSIL_BITS.DESC;
    EffectorValues tieR0 = TUNING.BUILDINGS.DECOR.BONUS.TIER0;
    EffectorValues tieR1 = NOISE_POLLUTION.NOISY.TIER1;
    KAnimFile anim = Assets.GetAnim((HashedString) "fossil_bits1x2_kanim");
    EffectorValues decor = tieR0;
    EffectorValues noise = tieR1;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity("FossilBitsSmall", name, desc, 1500f, anim, "object", Grid.SceneLayer.BuildingBack, 1, 2, decor, noise, additionalTags: new List<Tag>()
    {
      GameTags.Gravitas
    });
    PrimaryElement component = placedEntity.GetComponent<PrimaryElement>();
    component.SetElement(SimHashes.Fossil);
    component.Temperature = 315f;
    placedEntity.AddOrGet<Operational>();
    placedEntity.AddOrGet<EntombVulnerable>();
    placedEntity.AddOrGet<FossilBits>();
    placedEntity.AddOrGet<Prioritizable>();
    Prioritizable.AddRef(placedEntity);
    placedEntity.AddOrGet<LoopingSounds>();
    return placedEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
    inst.GetComponent<OccupyArea>().objectLayers = new ObjectLayer[1]
    {
      ObjectLayer.Building
    };
    EntombVulnerable component = inst.GetComponent<EntombVulnerable>();
    component.SetStatusItem(Db.Get().BuildingStatusItems.FossilEntombed);
    component.SetShowStatusItemOnEntombed(false);
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
