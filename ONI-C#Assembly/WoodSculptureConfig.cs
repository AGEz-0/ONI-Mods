﻿// Decompiled with JetBrains decompiler
// Type: WoodSculptureConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class WoodSculptureConfig : IBuildingConfig
{
  public const string ID = "WoodSculpture";

  public override string[] GetRequiredDlcIds() => DlcManager.DLC2;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR4 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
    string[] woods = TUNING.MATERIALS.WOODS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues decor = new EffectorValues()
    {
      amount = 4,
      radius = 4
    };
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("WoodSculpture", 1, 1, "sculpture_wood_kanim", 10, 120f, tieR4, woods, 800f, BuildLocationRule.Anywhere, decor, noise);
    buildingDef.SceneLayer = Grid.SceneLayer.InteriorWall;
    buildingDef.Floodable = false;
    buildingDef.Overheatable = false;
    buildingDef.AudioCategory = "Metal";
    buildingDef.BaseTimeUntilRepair = -1f;
    buildingDef.ViewMode = OverlayModes.Decor.ID;
    buildingDef.DefaultAnimState = "slab";
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    buildingDef.RequiredSkillPerkID = Db.Get().SkillPerks.CanArt.Id;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.STATUE);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.ARTWORK);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.MORALE);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<BuildingComplete>().isArtable = true;
    go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddComponent<LongRangeSculpture>().defaultAnimName = "slab";
  }
}
