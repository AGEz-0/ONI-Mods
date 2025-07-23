// Decompiled with JetBrains decompiler
// Type: FishFeederConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class FishFeederConfig : IBuildingConfig
{
  public const string ID = "FishFeeder";
  private static HashSet<Tag> forbiddenTags = new HashSet<Tag>();

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR3 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
    string[] rawMetals = TUNING.MATERIALS.RAW_METALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR2 = TUNING.BUILDINGS.DECOR.PENALTY.TIER2;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("FishFeeder", 1, 3, "fishfeeder_kanim", 100, 120f, tieR3, rawMetals, 1600f, BuildLocationRule.Anywhere, tieR2, noise);
    buildingDef.AudioCategory = "Metal";
    buildingDef.Entombable = true;
    buildingDef.Floodable = true;
    buildingDef.ForegroundLayer = Grid.SceneLayer.TileMain;
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.RANCHING);
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.CRITTER);
    return buildingDef;
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    Prioritizable.AddRef(go);
    Storage storage1 = go.AddOrGet<Storage>();
    storage1.capacityKg = 200f;
    storage1.showInUI = true;
    storage1.showDescriptor = true;
    storage1.allowItemRemoval = false;
    storage1.allowSettingOnlyFetchMarkedItems = false;
    storage1.showCapacityStatusItem = true;
    storage1.showCapacityAsMainStatus = true;
    storage1.dropOffset = Vector2.up * 1f;
    storage1.storageID = new Tag("FishFeederTop");
    Storage storage2 = go.AddComponent<Storage>();
    storage2.capacityKg = 200f;
    storage2.showInUI = true;
    storage2.showDescriptor = true;
    storage2.allowItemRemoval = false;
    storage2.dropOffset = Vector2.up * 3.5f;
    storage2.storageID = new Tag("FishFeederBot");
    go.AddOrGet<StorageLocker>().choreTypeID = Db.Get().ChoreTypes.RanchingFetch.Id;
    go.AddOrGet<UserNameable>();
    Effect resource = new Effect("AteFromFeeder", (string) STRINGS.CREATURES.MODIFIERS.ATE_FROM_FEEDER.NAME, (string) STRINGS.CREATURES.MODIFIERS.ATE_FROM_FEEDER.TOOLTIP, 1200f, true, false, false);
    resource.Add(new AttributeModifier(Db.Get().Amounts.Wildness.deltaAttribute.Id, -0.0333333351f, (string) STRINGS.CREATURES.MODIFIERS.ATE_FROM_FEEDER.NAME));
    resource.Add(new AttributeModifier(Db.Get().CritterAttributes.Happiness.Id, 5f, (string) STRINGS.CREATURES.MODIFIERS.ATE_FROM_FEEDER.NAME));
    Db.Get().effects.Add(resource);
    go.AddOrGet<TreeFilterable>().filterAllStoragesOnBuilding = true;
    CreatureFeeder creatureFeeder = go.AddOrGet<CreatureFeeder>();
    creatureFeeder.effectId = resource.Id;
    creatureFeeder.feederOffset = new CellOffset(0, -2);
    go.GetComponent<KPrefabID>().prefabInitFn += new KPrefabID.PrefabFn(this.OnPrefabInit);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGetDef<StorageController.Def>();
    go.AddOrGetDef<FishFeeder.Def>();
    go.AddOrGetDef<MakeBaseSolid.Def>().solidOffsets = new CellOffset[1]
    {
      new CellOffset(0, 0)
    };
    SymbolOverrideControllerUtil.AddToPrefab(go);
  }

  public override void ConfigurePost(BuildingDef def)
  {
    List<Tag> tagList = new List<Tag>();
    Tag[] target_species = new Tag[2]
    {
      GameTags.Creatures.Species.PacuSpecies,
      GameTags.Creatures.Species.PrehistoricPacuSpecies
    };
    foreach (KeyValuePair<Tag, Diet> collectDiet in DietManager.CollectDiets(target_species))
    {
      Diet diet = collectDiet.Value;
      if (diet.CanEatPreyCritter)
      {
        foreach (Diet.Info preyInfo in diet.preyInfos)
        {
          foreach (Tag consumedTag in preyInfo.consumedTags)
            FishFeederConfig.forbiddenTags.Add(consumedTag);
        }
      }
      tagList.Add(collectDiet.Key);
    }
    def.BuildingComplete.GetComponent<Storage>().storageFilters = tagList;
  }

  private void OnPrefabInit(GameObject instance)
  {
    TreeFilterable component = instance.GetComponent<TreeFilterable>();
    foreach (Tag forbiddenTag in FishFeederConfig.forbiddenTags)
      component.ForbiddenTags.Add(forbiddenTag);
  }
}
