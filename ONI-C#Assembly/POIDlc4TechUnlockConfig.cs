// Decompiled with JetBrains decompiler
// Type: POIDlc4TechUnlockConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class POIDlc4TechUnlockConfig : IEntityConfig, IHasDlcRestrictions
{
  public const string ID = "POIDlc4TechUnlock";

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    string name = (string) STRINGS.BUILDINGS.PREFABS.DLC4POITECHUNLOCKS.NAME;
    string desc = (string) STRINGS.BUILDINGS.PREFABS.DLC4POITECHUNLOCKS.DESC;
    EffectorValues tieR0_1 = TUNING.BUILDINGS.DECOR.BONUS.TIER0;
    EffectorValues tieR0_2 = NOISE_POLLUTION.NOISY.TIER0;
    KAnimFile anim = Assets.GetAnim((HashedString) "research_unlock_dino_kanim");
    EffectorValues decor = tieR0_1;
    EffectorValues noise = tieR0_2;
    GameObject placedEntity = EntityTemplates.CreatePlacedEntity("POIDlc4TechUnlock", name, desc, 100f, anim, "on", Grid.SceneLayer.Building, 3, 3, decor, noise, additionalTags: new List<Tag>()
    {
      GameTags.Gravitas,
      RoomConstraints.ConstraintTags.LightSource,
      GameTags.RoomProberBuilding
    });
    PrimaryElement component = placedEntity.GetComponent<PrimaryElement>();
    component.SetElement(SimHashes.Unobtanium);
    component.Temperature = 294.15f;
    placedEntity.AddOrGet<OccupyArea>().objectLayers = new ObjectLayer[1]
    {
      ObjectLayer.Building
    };
    placedEntity.AddOrGet<Demolishable>();
    POITechItemUnlockWorkable itemUnlockWorkable = placedEntity.AddOrGet<POITechItemUnlockWorkable>();
    itemUnlockWorkable.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_research_unlock_dino_kanim")
    };
    itemUnlockWorkable.workTime = 5f;
    POITechItemUnlocks.Def def = placedEntity.AddOrGetDef<POITechItemUnlocks.Def>();
    def.POITechUnlockIDs = new List<string>()
    {
      "MissileFabricator",
      "MissileLauncher"
    };
    def.PopUpName = STRINGS.BUILDINGS.PREFABS.DLC4POITECHUNLOCKS.NAME;
    def.animName = "meteor_blast_kanim";
    Light2D light2D = placedEntity.AddComponent<Light2D>();
    light2D.Color = LIGHT2D.POI_TECH_UNLOCK_COLOR;
    light2D.Range = 5f;
    light2D.Angle = 2.6f;
    light2D.Direction = LIGHT2D.POI_TECH_DIRECTION;
    light2D.Offset = LIGHT2D.POI_TECH_UNLOCK_OFFSET;
    light2D.overlayColour = LIGHT2D.POI_TECH_UNLOCK_OVERLAYCOLOR;
    light2D.shape = LightShape.Cone;
    light2D.drawOverlay = true;
    light2D.Lux = 1800;
    placedEntity.AddOrGet<Prioritizable>();
    return placedEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
