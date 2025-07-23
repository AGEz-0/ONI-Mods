// Decompiled with JetBrains decompiler
// Type: MaterialsAvailable
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class MaterialsAvailable : SelectModuleCondition
{
  public override bool IgnoreInSanboxMode() => true;

  public override bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext)
  {
    return (Object) existingModule == (Object) null || ProductInfoScreen.MaterialsMet(selectedPart.CraftRecipe);
  }

  public override string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart)
  {
    if (ready)
      return (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.MATERIALS_AVAILABLE.COMPLETE;
    string failed = (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.MATERIALS_AVAILABLE.FAILED;
    foreach (Recipe.Ingredient ingredient in selectedPart.CraftRecipe.Ingredients)
    {
      string str = "\n" + $"{"    • "}{ingredient.tag.ProperName()}: {GameUtil.GetFormattedMass(ingredient.amount)}";
      failed += str;
    }
    return failed;
  }
}
