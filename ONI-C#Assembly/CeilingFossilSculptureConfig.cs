﻿// Decompiled with JetBrains decompiler
// Type: CeilingFossilSculptureConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using TUNING;
using UnityEngine;

#nullable disable
public class CeilingFossilSculptureConfig : IBuildingConfig
{
  public const string ID = "CeilingFossilSculpture";

  public override string[] GetRequiredDlcIds()
  {
    return new string[1]{ "DLC4_ID" };
  }

  public override BuildingDef CreateBuildingDef()
  {
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("CeilingFossilSculpture", 3, 2, "fossilsculpture_hanging_kanim", 100, 240f, TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER4, TUNING.MATERIALS.FOSSILS, 800f, BuildLocationRule.OnCeiling, TUNING.DECOR.BONUS.TIER5, NOISE_POLLUTION.NONE);
    buildingDef.InputConduitType = ConduitType.None;
    buildingDef.OutputConduitType = ConduitType.None;
    buildingDef.UtilityInputOffset = new CellOffset(0, 0);
    buildingDef.UtilityOutputOffset = new CellOffset(0, 0);
    buildingDef.RequiresPowerInput = false;
    buildingDef.RequiresPowerOutput = false;
    buildingDef.PowerInputOffset = new CellOffset(0, 1);
    buildingDef.PowerOutputOffset = new CellOffset(0, 0);
    buildingDef.UseHighEnergyParticleInputPort = false;
    buildingDef.UseHighEnergyParticleOutputPort = false;
    buildingDef.HighEnergyParticleInputOffset = new CellOffset(0, 0);
    buildingDef.HighEnergyParticleOutputOffset = new CellOffset(0, 0);
    buildingDef.PermittedRotations = PermittedRotations.FlipH;
    buildingDef.DragBuild = false;
    buildingDef.Replaceable = true;
    buildingDef.ExhaustKilowattsWhenActive = 0.0f;
    buildingDef.SelfHeatKilowattsWhenActive = 0.0f;
    buildingDef.EnergyConsumptionWhenActive = 0.0f;
    buildingDef.RequiredSkillPerkID = Db.Get().SkillPerks.CanArtGreat.Id;
    buildingDef.ViewMode = OverlayModes.Decor.ID;
    buildingDef.DefaultAnimState = "slab";
    buildingDef.UseStructureTemperature = true;
    buildingDef.Overheatable = false;
    buildingDef.Floodable = false;
    buildingDef.Disinfectable = true;
    buildingDef.Entombable = true;
    buildingDef.Invincible = false;
    buildingDef.Repairable = false;
    buildingDef.IsFoundation = false;
    buildingDef.AudioCategory = "Metal";
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.DINOSAUR);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.STATUE);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.ARTWORK);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.MORALE);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.GetComponent<KPrefabID>().AddTag(GameTags.Decoration);
    go.AddOrGet<BuildingComplete>().isArtable = true;
    go.AddOrGet<LoopingSounds>();
  }

  public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
  {
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    LongRangeSculpture longRangeSculpture = go.AddOrGet<LongRangeSculpture>();
    longRangeSculpture.requiredSkillPerk = Db.Get().SkillPerks.CanArtGreat.Id;
    longRangeSculpture.defaultAnimName = "slab";
  }
}
