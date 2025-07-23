// Decompiled with JetBrains decompiler
// Type: AdvancedCureConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class AdvancedCureConfig : IEntityConfig
{
  public const string ID = "AdvancedCure";
  public static ComplexRecipe recipe;

  public GameObject CreatePrefab()
  {
    GameObject medicine = EntityTemplates.ExtendEntityToMedicine(EntityTemplates.CreateLooseEntity("AdvancedCure", (string) STRINGS.ITEMS.PILLS.ADVANCEDCURE.NAME, (string) STRINGS.ITEMS.PILLS.ADVANCEDCURE.DESC, 1f, true, Assets.GetAnim((HashedString) "vial_spore_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.4f, true), TUNING.MEDICINE.ADVANCEDCURE);
    ComplexRecipe.RecipeElement[] recipeElementArray1 = new ComplexRecipe.RecipeElement[2]
    {
      new ComplexRecipe.RecipeElement(SimHashes.Steel.CreateTag(), 1f),
      new ComplexRecipe.RecipeElement((Tag) "LightBugOrangeEgg", 1f)
    };
    ComplexRecipe.RecipeElement[] recipeElementArray2 = new ComplexRecipe.RecipeElement[1]
    {
      new ComplexRecipe.RecipeElement((Tag) "AdvancedCure", 1f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature)
    };
    string fabricator = "Apothecary";
    AdvancedCureConfig.recipe = new ComplexRecipe(ComplexRecipeManager.MakeRecipeID(fabricator, (IList<ComplexRecipe.RecipeElement>) recipeElementArray1, (IList<ComplexRecipe.RecipeElement>) recipeElementArray2), recipeElementArray1, recipeElementArray2)
    {
      time = 200f,
      description = (string) STRINGS.ITEMS.PILLS.ADVANCEDCURE.RECIPEDESC,
      nameDisplay = ComplexRecipe.RecipeNameDisplay.Result,
      fabricators = new List<Tag>() { (Tag) fabricator },
      sortOrder = 20,
      requiredTech = "MedicineIV"
    };
    return medicine;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
