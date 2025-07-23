// Decompiled with JetBrains decompiler
// Type: EggCrackerConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class EggCrackerConfig : IBuildingConfig
{
  public const string ID = "EggCracker";
  private static Dictionary<Tag, List<EggCrackerConfig.EggData>> EggsBySpecies = new Dictionary<Tag, List<EggCrackerConfig.EggData>>();
  private static List<EggCrackerConfig.EggData> uncategorizedEggData = new List<EggCrackerConfig.EggData>();

  public static void RegisterEgg(
    Tag eggPrefabTag,
    string name,
    string description,
    float mass,
    string[] requiredDLC,
    string[] forbiddenDLC)
  {
    EggCrackerConfig.EggData eggData = new EggCrackerConfig.EggData(eggPrefabTag, name, description, mass, requiredDLC, forbiddenDLC);
    EggCrackerConfig.uncategorizedEggData.Add(eggData);
  }

  public static void CategorizeEggs()
  {
    foreach (EggCrackerConfig.EggData eggData in EggCrackerConfig.uncategorizedEggData)
    {
      Tag species = Assets.GetPrefab(Assets.GetPrefab(eggData.id).GetDef<IncubationMonitor.Def>().spawnedCreature).GetComponent<CreatureBrain>().species;
      if (!EggCrackerConfig.EggsBySpecies.ContainsKey(species))
        EggCrackerConfig.EggsBySpecies.Add(species, new List<EggCrackerConfig.EggData>());
      EggCrackerConfig.EggsBySpecies[species].Add(eggData);
    }
  }

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR1 = TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER1;
    string[] rawMetals = TUNING.MATERIALS.RAW_METALS;
    EffectorValues none = NOISE_POLLUTION.NONE;
    EffectorValues tieR0 = TUNING.BUILDINGS.DECOR.BONUS.TIER0;
    EffectorValues noise = none;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("EggCracker", 2, 2, "egg_cracker_kanim", 30, 10f, tieR1, rawMetals, 1600f, BuildLocationRule.OnFloor, tieR0, noise);
    buildingDef.AudioCategory = "Metal";
    buildingDef.SceneLayer = Grid.SceneLayer.Building;
    buildingDef.ForegroundLayer = Grid.SceneLayer.BuildingFront;
    buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
    buildingDef.AddSearchTerms((string) SEARCH_TERMS.FOOD);
    return buildingDef;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    go.AddOrGet<DropAllWorkable>();
    go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
    go.AddOrGet<KBatchedAnimController>().SetSymbolVisiblity((KAnimHashedString) "snapto_egg", false);
    ComplexFabricator fabricator = go.AddOrGet<ComplexFabricator>();
    fabricator.labelByResult = false;
    fabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
    fabricator.duplicantOperated = true;
    go.AddOrGet<FabricatorIngredientStatusManager>();
    go.AddOrGet<CopyBuildingSettings>();
    ComplexFabricatorWorkable fabricatorWorkable = go.AddOrGet<ComplexFabricatorWorkable>();
    BuildingTemplates.CreateComplexFabricatorStorage(go, fabricator);
    KAnimFile[] kanimFileArray = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_egg_cracker_kanim")
    };
    fabricatorWorkable.overrideAnims = kanimFileArray;
    fabricator.outputOffset = new Vector3(1f, 1f, 0.0f);
    Prioritizable.AddRef(go);
    go.AddOrGet<EggCracker>();
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGet<LogicOperationalController>();
  }

  public override void ConfigurePost(BuildingDef def)
  {
    base.ConfigurePost(def);
    this.MakeRecipes();
  }

  public void MakeRecipes()
  {
    EggCrackerConfig.CategorizeEggs();
    foreach (KeyValuePair<Tag, List<EggCrackerConfig.EggData>> eggsBySpecy in EggCrackerConfig.EggsBySpecies)
    {
      Tag[] materialOptions = new Tag[eggsBySpecy.Value.Count];
      for (int index = 0; index < materialOptions.Length; ++index)
        materialOptions[index] = eggsBySpecy.Value[index].id;
      EggCrackerConfig.EggData eggData = eggsBySpecy.Value[0];
      string str1 = string.Format((string) STRINGS.BUILDINGS.PREFABS.EGGCRACKER.RESULT_DESCRIPTION, (object) eggData.name);
      ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[1]
      {
        new ComplexRecipe.RecipeElement(materialOptions, 1f)
        {
          material = materialOptions[0]
        }
      };
      ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[2]
      {
        new ComplexRecipe.RecipeElement((Tag) "RawEgg", 0.5f * eggData.mass, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature),
        new ComplexRecipe.RecipeElement((Tag) "EggShell", 0.5f * eggData.mass, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
      };
      string obsolete_id = ComplexRecipeManager.MakeObsoleteRecipeID("EggCracker", (Tag) "RawEgg");
      string str2 = ComplexRecipeManager.MakeRecipeID("EggCracker", (IList<ComplexRecipe.RecipeElement>) recipeElementArray1, (IList<ComplexRecipe.RecipeElement>) recipeElementArray2);
      ComplexRecipe complexRecipe = new ComplexRecipe(str2, recipeElementArray1, recipeElementArray2, eggData.requiredDlcIds, eggData.forbiddenDlcIds)
      {
        description = string.Format((string) STRINGS.BUILDINGS.PREFABS.EGGCRACKER.RECIPE_DESCRIPTION, (object) eggData.name, (object) str1),
        fabricators = new List<Tag>() { (Tag) "EggCracker" },
        time = 5f,
        nameDisplay = ComplexRecipe.RecipeNameDisplay.Custom,
        customName = eggsBySpecy.Key.ProperName(),
        customSpritePrefabID = recipeElementArray1[0].material != (Tag) (string) null ? recipeElementArray1[0].material.Name : recipeElementArray1[0].possibleMaterials[0].Name
      };
      ComplexRecipeManager.Get().AddObsoleteIDMapping(obsolete_id, str2);
    }
  }

  private class EggData : IHasDlcRestrictions
  {
    public Tag id;
    public float mass;
    public string name;
    public string description;
    public string[] requiredDlcIds;
    public string[] forbiddenDlcIds;

    public EggData(
      Tag id,
      string name,
      string description,
      float mass,
      string[] requiredDLC,
      string[] forbiddenDLC)
    {
      this.id = id;
      this.name = name;
      this.description = description;
      this.mass = mass;
      this.requiredDlcIds = requiredDLC;
      this.forbiddenDlcIds = forbiddenDLC;
    }

    public string[] GetRequiredDlcIds() => this.requiredDlcIds;

    public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
  }
}
