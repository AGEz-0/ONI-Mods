// Decompiled with JetBrains decompiler
// Type: CodexEntryGenerator_Elements
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
public class CodexEntryGenerator_Elements
{
  public static string ELEMENTS_ID = CodexCache.FormatLinkID("ELEMENTS");
  public static string ELEMENTS_SOLIDS_ID = CodexCache.FormatLinkID("ELEMENTS_SOLID");
  public static string ELEMENTS_LIQUIDS_ID = CodexCache.FormatLinkID("ELEMENTS_LIQUID");
  public static string ELEMENTS_GASES_ID = CodexCache.FormatLinkID("ELEMENTS_GAS");
  public static string ELEMENTS_OTHER_ID = CodexCache.FormatLinkID("ELEMENTS_OTHER");
  public static string ELEMENT_TYPES = CodexCache.FormatLinkID("ELEMENTTYPES");
  private static CodexEntryGenerator_Elements.ElementEntryContext contextInstance;

  public static Dictionary<string, CodexEntry> GenerateEntries()
  {
    Dictionary<string, CodexEntry> entriesElements = new Dictionary<string, CodexEntry>();
    Dictionary<string, CodexEntry> entries1 = new Dictionary<string, CodexEntry>();
    Dictionary<string, CodexEntry> entries2 = new Dictionary<string, CodexEntry>();
    Dictionary<string, CodexEntry> entries3 = new Dictionary<string, CodexEntry>();
    Dictionary<string, CodexEntry> entries4 = new Dictionary<string, CodexEntry>();
    Dictionary<string, CodexEntry> entries5 = new Dictionary<string, CodexEntry>();
    AddCategoryEntry(CodexEntryGenerator_Elements.ELEMENTS_SOLIDS_ID, (string) UI.CODEX.CATEGORYNAMES.ELEMENTSSOLID, Assets.GetSprite((HashedString) "ui_elements-solid"), entries1);
    AddCategoryEntry(CodexEntryGenerator_Elements.ELEMENTS_LIQUIDS_ID, (string) UI.CODEX.CATEGORYNAMES.ELEMENTSLIQUID, Assets.GetSprite((HashedString) "ui_elements-liquids"), entries2);
    AddCategoryEntry(CodexEntryGenerator_Elements.ELEMENTS_GASES_ID, (string) UI.CODEX.CATEGORYNAMES.ELEMENTSGAS, Assets.GetSprite((HashedString) "ui_elements-gases"), entries3);
    AddCategoryEntry(CodexEntryGenerator_Elements.ELEMENTS_OTHER_ID, (string) UI.CODEX.CATEGORYNAMES.ELEMENTSOTHER, Assets.GetSprite((HashedString) "ui_elements-other"), entries4);
    AddCategoryEntry(CodexEntryGenerator_Elements.ELEMENT_TYPES, (string) UI.CODEX.CATEGORYNAMES.ELEMENTTYPES, Assets.GetSprite((HashedString) "ui_elements-other"), entries5);
    foreach (Element element in ElementLoader.elements)
    {
      if (!element.disabled)
      {
        bool flag = false;
        foreach (Tag oreTag in element.oreTags)
        {
          if (oreTag == GameTags.HideFromCodex)
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          Tuple<Sprite, Color> tuple = Def.GetUISprite((object) element);
          if ((UnityEngine.Object) tuple.first == (UnityEngine.Object) null)
          {
            if (element.id == SimHashes.Void)
              tuple = new Tuple<Sprite, Color>(Assets.GetSprite((HashedString) "ui_elements-void"), Color.white);
            else if (element.id == SimHashes.Vacuum)
              tuple = new Tuple<Sprite, Color>(Assets.GetSprite((HashedString) "ui_elements-vacuum"), Color.white);
          }
          List<ContentContainer> contentContainerList = new List<ContentContainer>();
          CodexEntryGenerator.GenerateTitleContainers(element.name, contentContainerList);
          CodexEntryGenerator.GenerateImageContainers(new Tuple<Sprite, Color>[1]
          {
            tuple
          }, contentContainerList, ContentContainer.ContentLayout.Horizontal);
          CodexEntryGenerator_Elements.GenerateElementDescriptionContainers(element, contentContainerList);
          string category;
          Dictionary<string, CodexEntry> dictionary;
          if (element.IsSolid)
          {
            category = CodexEntryGenerator_Elements.ELEMENTS_SOLIDS_ID;
            dictionary = entries1;
          }
          else if (element.IsLiquid)
          {
            category = CodexEntryGenerator_Elements.ELEMENTS_LIQUIDS_ID;
            dictionary = entries2;
          }
          else if (element.IsGas)
          {
            category = CodexEntryGenerator_Elements.ELEMENTS_GASES_ID;
            dictionary = entries3;
          }
          else
          {
            category = CodexEntryGenerator_Elements.ELEMENTS_OTHER_ID;
            dictionary = entries4;
          }
          string str = element.id.ToString();
          CodexEntry entry = new CodexEntry(category, contentContainerList, element.name);
          entry.parentId = category;
          entry.icon = tuple.first;
          entry.iconColor = tuple.second;
          CodexCache.AddEntry(str, entry);
          dictionary.Add(str, entry);
        }
      }
    }
    string str1 = "IceBellyPoop";
    GameObject prefab = Assets.TryGetPrefab((Tag) str1);
    if ((UnityEngine.Object) prefab != (UnityEngine.Object) null)
    {
      string elementsSolidsId = CodexEntryGenerator_Elements.ELEMENTS_SOLIDS_ID;
      Dictionary<string, CodexEntry> dictionary = entries1;
      KPrefabID component1 = prefab.GetComponent<KPrefabID>();
      InfoDescription component2 = prefab.GetComponent<InfoDescription>();
      string properName = prefab.GetProperName();
      string description = component2.description;
      Tuple<Sprite, Color> uiSprite = Def.GetUISprite((object) prefab);
      List<ContentContainer> contentContainerList = new List<ContentContainer>();
      CodexEntryGenerator.GenerateTitleContainers(properName, contentContainerList);
      CodexEntryGenerator.GenerateImageContainers(new Tuple<Sprite, Color>[1]
      {
        uiSprite
      }, contentContainerList, ContentContainer.ContentLayout.Horizontal);
      CodexEntryGenerator_Elements.GenerateMadeAndUsedContainers(component1.PrefabTag, contentContainerList);
      contentContainerList.Add(new ContentContainer(new List<ICodexWidget>()
      {
        (ICodexWidget) new CodexSpacer(),
        (ICodexWidget) new CodexText(description),
        (ICodexWidget) new CodexSpacer()
      }, ContentContainer.ContentLayout.Vertical));
      CodexEntry entry = new CodexEntry(elementsSolidsId, contentContainerList, properName);
      entry.parentId = elementsSolidsId;
      entry.icon = uiSprite.first;
      entry.iconColor = uiSprite.second;
      CodexCache.AddEntry(str1, entry);
      dictionary.Add(str1, entry);
    }
    CodexEntryGenerator.PopulateCategoryEntries(entriesElements);
    return entriesElements;

    void AddCategoryEntry(
      string categoryId,
      string name,
      Sprite icon,
      Dictionary<string, CodexEntry> entries)
    {
      CodexEntry categoryEntry = (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(categoryId, name, entries, icon);
      categoryEntry.parentId = CodexEntryGenerator_Elements.ELEMENTS_ID;
      categoryEntry.category = CodexEntryGenerator_Elements.ELEMENTS_ID;
      entriesElements.Add(categoryId, categoryEntry);
    }
  }

  public static void GenerateElementDescriptionContainers(
    Element element,
    List<ContentContainer> containers)
  {
    List<ICodexWidget> content1 = new List<ICodexWidget>();
    List<ICodexWidget> content2 = new List<ICodexWidget>();
    if (element.highTempTransition != null)
      content1.Add((ICodexWidget) new CodexTemperatureTransitionPanel(element, CodexTemperatureTransitionPanel.TransitionType.HEAT));
    if (element.lowTempTransition != null)
      content1.Add((ICodexWidget) new CodexTemperatureTransitionPanel(element, CodexTemperatureTransitionPanel.TransitionType.COOL));
    foreach (Element element1 in ElementLoader.elements)
    {
      if (!element1.disabled)
      {
        if (element1.highTempTransition == element || ElementLoader.FindElementByHash(element1.highTempTransitionOreID) == element)
          content2.Add((ICodexWidget) new CodexTemperatureTransitionPanel(element1, CodexTemperatureTransitionPanel.TransitionType.HEAT));
        if (element1.lowTempTransition == element || ElementLoader.FindElementByHash(element1.lowTempTransitionOreID) == element)
          content2.Add((ICodexWidget) new CodexTemperatureTransitionPanel(element1, CodexTemperatureTransitionPanel.TransitionType.COOL));
      }
    }
    if (content1.Count > 0)
    {
      ContentContainer contents = new ContentContainer(content1, ContentContainer.ContentLayout.Vertical);
      containers.Add(new ContentContainer(new List<ICodexWidget>()
      {
        (ICodexWidget) new CodexSpacer(),
        (ICodexWidget) new CodexCollapsibleHeader((string) CODEX.HEADERS.ELEMENTTRANSITIONSTO, contents)
      }, ContentContainer.ContentLayout.Vertical));
      containers.Add(contents);
    }
    if (content2.Count > 0)
    {
      ContentContainer contents = new ContentContainer(content2, ContentContainer.ContentLayout.Vertical);
      containers.Add(new ContentContainer(new List<ICodexWidget>()
      {
        (ICodexWidget) new CodexSpacer(),
        (ICodexWidget) new CodexCollapsibleHeader((string) CODEX.HEADERS.ELEMENTTRANSITIONSFROM, contents)
      }, ContentContainer.ContentLayout.Vertical));
      containers.Add(contents);
    }
    CodexEntryGenerator_Elements.GenerateMadeAndUsedContainers(element.tag, containers);
    containers.Add(new ContentContainer(new List<ICodexWidget>()
    {
      (ICodexWidget) new CodexSpacer(),
      (ICodexWidget) new CodexText(element.FullDescription()),
      (ICodexWidget) new CodexSpacer()
    }, ContentContainer.ContentLayout.Vertical));
  }

  public static void GenerateMadeAndUsedContainers(Tag tag, List<ContentContainer> containers)
  {
    List<ICodexWidget> content1 = new List<ICodexWidget>();
    List<ICodexWidget> content2 = new List<ICodexWidget>();
    foreach (ComplexRecipe recipe in ComplexRecipeManager.Get().recipes)
    {
      if (Game.IsCorrectDlcActiveForCurrentSave((IHasDlcRestrictions) recipe))
      {
        if (((IEnumerable<ComplexRecipe.RecipeElement>) recipe.ingredients).Any<ComplexRecipe.RecipeElement>((Func<ComplexRecipe.RecipeElement, bool>) (i => i.material == tag)))
          content1.Add((ICodexWidget) new CodexRecipePanel(recipe));
        if (((IEnumerable<ComplexRecipe.RecipeElement>) recipe.results).Any<ComplexRecipe.RecipeElement>((Func<ComplexRecipe.RecipeElement, bool>) (i => i.material == tag)))
          content2.Add((ICodexWidget) new CodexRecipePanel(recipe, true));
      }
    }
    List<CodexEntryGenerator_Elements.ConversionEntry> conversionEntryList1;
    if (CodexEntryGenerator_Elements.GetElementEntryContext().usedMap.map.TryGetValue(tag, out conversionEntryList1))
    {
      foreach (CodexEntryGenerator_Elements.ConversionEntry conversionEntry in conversionEntryList1)
        content1.Add((ICodexWidget) new CodexConversionPanel(conversionEntry.title, conversionEntry.inSet.ToArray<ElementUsage>(), conversionEntry.outSet.ToArray<ElementUsage>(), conversionEntry.prefab));
    }
    List<CodexEntryGenerator_Elements.ConversionEntry> conversionEntryList2;
    if (CodexEntryGenerator_Elements.GetElementEntryContext().madeMap.map.TryGetValue(tag, out conversionEntryList2))
    {
      foreach (CodexEntryGenerator_Elements.ConversionEntry conversionEntry in conversionEntryList2)
        content2.Add((ICodexWidget) new CodexConversionPanel(conversionEntry.title, conversionEntry.inSet.ToArray<ElementUsage>(), conversionEntry.outSet.ToArray<ElementUsage>(), conversionEntry.prefab));
    }
    ContentContainer contents1 = new ContentContainer(content1, ContentContainer.ContentLayout.Vertical);
    ContentContainer contents2 = new ContentContainer(content2, ContentContainer.ContentLayout.Vertical);
    if (content1.Count > 0)
    {
      containers.Add(new ContentContainer(new List<ICodexWidget>()
      {
        (ICodexWidget) new CodexSpacer(),
        (ICodexWidget) new CodexCollapsibleHeader((string) CODEX.HEADERS.ELEMENTCONSUMEDBY, contents1)
      }, ContentContainer.ContentLayout.Vertical));
      containers.Add(contents1);
    }
    if (content2.Count <= 0)
      return;
    containers.Add(new ContentContainer(new List<ICodexWidget>()
    {
      (ICodexWidget) new CodexSpacer(),
      (ICodexWidget) new CodexCollapsibleHeader((string) CODEX.HEADERS.ELEMENTPRODUCEDBY, contents2)
    }, ContentContainer.ContentLayout.Vertical));
    containers.Add(contents2);
  }

  public static CodexEntryGenerator_Elements.ElementEntryContext GetElementEntryContext()
  {
    if (CodexEntryGenerator_Elements.contextInstance == null)
    {
      CodexEntryGenerator_Elements.CodexElementMap usedMap = new CodexEntryGenerator_Elements.CodexElementMap();
      CodexEntryGenerator_Elements.CodexElementMap madeMap = new CodexEntryGenerator_Elements.CodexElementMap();
      Tag waterTag = ElementLoader.FindElementByHash(SimHashes.Water).tag;
      Tag dirtyWaterTag = ElementLoader.FindElementByHash(SimHashes.DirtyWater).tag;
      foreach (PlanScreen.PlanInfo planInfo in TUNING.BUILDINGS.PLANORDER)
      {
        foreach (KeyValuePair<string, string> keyValuePair in planInfo.buildingAndSubcategoryData)
        {
          BuildingDef buildingDef = Assets.GetBuildingDef(keyValuePair.Key);
          if ((UnityEngine.Object) buildingDef == (UnityEngine.Object) null)
            Debug.LogError((object) $"Building def for id {keyValuePair.Key} is null");
          if (!buildingDef.Deprecated && !buildingDef.BuildingComplete.HasTag(GameTags.DevBuilding))
            CheckPrefab(buildingDef.BuildingComplete, usedMap, madeMap);
        }
      }
      HashSet<GameObject> gameObjectSet = new HashSet<GameObject>((IEnumerable<GameObject>) Assets.GetPrefabsWithComponent<Harvestable>());
      foreach (GameObject gameObject in Assets.GetPrefabsWithComponent<WiltCondition>())
        gameObjectSet.Add(gameObject);
      foreach (GameObject gameObject in gameObjectSet)
      {
        if (!gameObject.HasTag(GameTags.HideFromCodex))
          CheckPrefab(gameObject, usedMap, madeMap);
      }
      foreach (GameObject gameObject in Assets.GetPrefabsWithComponent<CreatureBrain>())
      {
        if (gameObject.GetDef<BabyMonitor.Def>() == null)
          CheckPrefab(gameObject, usedMap, madeMap);
      }
      foreach (KeyValuePair<Tag, Diet> collectSaveDiet in DietManager.CollectSaveDiets((Tag[]) null))
      {
        GameObject gameObject = Assets.GetPrefab(collectSaveDiet.Key).gameObject;
        if (gameObject.GetDef<BabyMonitor.Def>() == null)
        {
          float num1 = 0.0f;
          foreach (AttributeModifier selfModifier in Db.Get().traits.Get(gameObject.GetComponent<Modifiers>().initialTraits[0]).SelfModifiers)
          {
            if (selfModifier.AttributeId == Db.Get().Amounts.Calories.deltaAttribute.Id)
              num1 = selfModifier.Value;
          }
          Diet diet = collectSaveDiet.Value;
          foreach (Diet.Info info in diet.infos)
          {
            foreach (Tag consumedTag in info.consumedTags)
            {
              float amount1 = -num1 / info.caloriesPerKg;
              float amount2 = amount1 * info.producedConversionRate;
              int num2 = diet.IsConsumedTagAbleToBeEatenDirectly(consumedTag) ? 1 : 0;
              ElementUsage elementUsage = (ElementUsage) null;
              if (num2 != 0)
              {
                if (info.foodType == Diet.Info.FoodType.EatPlantDirectly)
                  elementUsage = new ElementUsage(consumedTag, amount1, true, new Func<Tag, float, bool, string>(GameUtil.GetFormattedDirectPlantConsumptionValuePerCycle));
                else if (info.foodType == Diet.Info.FoodType.EatPlantStorage)
                  elementUsage = new ElementUsage(consumedTag, amount1, true, new Func<Tag, float, bool, string>(GameUtil.GetFormattedPlantStorageConsumptionValuePerCycle));
                else if (info.foodType == Diet.Info.FoodType.EatPrey || info.foodType == Diet.Info.FoodType.EatButcheredPrey)
                {
                  float num3 = diet.AvailableCaloriesInPrey(consumedTag);
                  float amount3 = -num1 / num3;
                  amount2 = amount3 * info.producedConversionRate * num3 / info.caloriesPerKg;
                  elementUsage = new ElementUsage(consumedTag, amount3, true, new Func<Tag, float, bool, string>(GameUtil.GetFormattedPreyConsumptionValuePerCycle));
                }
              }
              else
                elementUsage = new ElementUsage(consumedTag, amount1, true);
              CodexEntryGenerator_Elements.ConversionEntry ce = new CodexEntryGenerator_Elements.ConversionEntry()
              {
                title = gameObject.GetProperName(),
                prefab = gameObject,
                inSet = new HashSet<ElementUsage>()
              };
              ce.inSet.Add(elementUsage);
              ce.outSet = new HashSet<ElementUsage>();
              ce.outSet.Add(new ElementUsage(info.producedElement, amount2, true));
              usedMap.Add(consumedTag, ce);
              madeMap.Add(info.producedElement, ce);
            }
          }
        }
      }
      CodexEntryGenerator_Elements.contextInstance = new CodexEntryGenerator_Elements.ElementEntryContext()
      {
        usedMap = usedMap,
        madeMap = madeMap
      };

      void CheckPrefab(
        GameObject prefab,
        CodexEntryGenerator_Elements.CodexElementMap usedMap,
        CodexEntryGenerator_Elements.CodexElementMap made)
      {
        HashSet<ElementUsage> elementUsageSet1 = new HashSet<ElementUsage>();
        HashSet<ElementUsage> elementUsageSet2 = new HashSet<ElementUsage>();
        EnergyGenerator component1 = prefab.GetComponent<EnergyGenerator>();
        if ((bool) (UnityEngine.Object) component1)
        {
          foreach (EnergyGenerator.InputItem inputItem in (IEnumerable<EnergyGenerator.InputItem>) component1.formula.inputs ?? Enumerable.Empty<EnergyGenerator.InputItem>())
            elementUsageSet1.Add(new ElementUsage(inputItem.tag, inputItem.consumptionRate, true));
          foreach (EnergyGenerator.OutputItem outputItem in (IEnumerable<EnergyGenerator.OutputItem>) component1.formula.outputs ?? Enumerable.Empty<EnergyGenerator.OutputItem>())
          {
            Tag tag = ElementLoader.FindElementByHash(outputItem.element).tag;
            elementUsageSet2.Add(new ElementUsage(tag, outputItem.creationRate, true));
          }
        }
        foreach (ElementConverter elementConverter in (IEnumerable<ElementConverter>) prefab.GetComponents<ElementConverter>() ?? Enumerable.Empty<ElementConverter>())
        {
          List<CodexEntryGenerator_Elements.ConversionEntry> conversionEntryList = new List<CodexEntryGenerator_Elements.ConversionEntry>();
          foreach (ElementConverter.ConsumedElement consumedElement in (IEnumerable<ElementConverter.ConsumedElement>) elementConverter.consumedElements ?? Enumerable.Empty<ElementConverter.ConsumedElement>())
          {
            ElementConverter.ConsumedElement c = consumedElement;
            if (elementConverter.inputIsCategory)
            {
              foreach (Element element in ElementLoader.FindElements((Func<Element, bool>) (e => e.HasTag(c.Tag))))
                conversionEntryList.Add(new CodexEntryGenerator_Elements.ConversionEntry()
                {
                  title = prefab.GetProperName(),
                  prefab = prefab,
                  inSet = {
                    new ElementUsage(element.tag, c.MassConsumptionRate, true)
                  }
                });
            }
            else
              elementUsageSet1.Add(new ElementUsage(c.Tag, c.MassConsumptionRate, true));
          }
          foreach (ElementConverter.OutputElement outputElement in (IEnumerable<ElementConverter.OutputElement>) elementConverter.outputElements ?? Enumerable.Empty<ElementConverter.OutputElement>())
          {
            ElementUsage elementUsage = new ElementUsage(ElementLoader.FindElementByHash(outputElement.elementHash).tag, outputElement.massGenerationRate, true);
            if (elementConverter.inputIsCategory)
            {
              foreach (CodexEntryGenerator_Elements.ConversionEntry conversionEntry in conversionEntryList)
                conversionEntry.outSet.Add(elementUsage);
            }
            else
              elementUsageSet2.Add(elementUsage);
          }
          foreach (CodexEntryGenerator_Elements.ConversionEntry ce in conversionEntryList)
          {
            if (ce.inSet.Count > 0 && ce.outSet.Count > 0)
              usedMap.Add(prefab.PrefabID(), ce);
            foreach (ElementUsage elementUsage in ce.inSet)
              usedMap.Add(elementUsage.tag, ce);
            foreach (ElementUsage elementUsage in ce.outSet)
              madeMap.Add(elementUsage.tag, ce);
          }
        }
        foreach (ElementConsumer elementConsumer in (IEnumerable<ElementConsumer>) prefab.GetComponents<ElementConsumer>() ?? Enumerable.Empty<ElementConsumer>())
        {
          if (!elementConsumer.storeOnConsume)
          {
            Tag tag = ElementLoader.FindElementByHash(elementConsumer.elementToConsume).tag;
            elementUsageSet1.Add(new ElementUsage(tag, elementConsumer.consumptionRate, true));
          }
        }
        IrrigationMonitor.Def def1 = prefab.GetDef<IrrigationMonitor.Def>();
        if (def1 != null)
        {
          foreach (PlantElementAbsorber.ConsumeInfo consumedElement in def1.consumedElements)
            elementUsageSet1.Add(new ElementUsage(consumedElement.tag, consumedElement.massConsumptionRate, true));
        }
        FertilizationMonitor.Def def2 = prefab.GetDef<FertilizationMonitor.Def>();
        if (def2 != null)
        {
          foreach (PlantElementAbsorber.ConsumeInfo consumedElement in def2.consumedElements)
            elementUsageSet1.Add(new ElementUsage(consumedElement.tag, consumedElement.massConsumptionRate, true));
        }
        IPlantConsumeEntities component2 = prefab.GetComponent<IPlantConsumeEntities>();
        Crop component3 = prefab.GetComponent<Crop>();
        if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && component2 == null)
          elementUsageSet2.Add(new ElementUsage((Tag) component3.cropId, (float) component3.cropVal.numProduced / component3.cropVal.cropDuration, true));
        FlushToilet component4 = prefab.GetComponent<FlushToilet>();
        if ((bool) (UnityEngine.Object) component4)
        {
          elementUsageSet1.Add(new ElementUsage(waterTag, component4.massConsumedPerUse, false));
          elementUsageSet2.Add(new ElementUsage(dirtyWaterTag, component4.massEmittedPerUse, false));
        }
        HandSanitizer component5 = prefab.GetComponent<HandSanitizer>();
        if ((bool) (UnityEngine.Object) component5)
        {
          Tag tag1 = ElementLoader.FindElementByHash(component5.consumedElement).tag;
          elementUsageSet1.Add(new ElementUsage(tag1, component5.massConsumedPerUse, false));
          if (component5.outputElement != SimHashes.Vacuum)
          {
            Tag tag2 = ElementLoader.FindElementByHash(component5.outputElement).tag;
            elementUsageSet2.Add(new ElementUsage(tag2, component5.massConsumedPerUse, false));
          }
        }
        if (prefab.IsPrefabID((Tag) "Moo"))
        {
          elementUsageSet1.Add(new ElementUsage((Tag) "GasGrass", MooConfig.DAYS_PLANT_GROWTH_EATEN_PER_CYCLE, false));
          elementUsageSet2.Add(new ElementUsage(ElementLoader.FindElementByHash(SimHashes.Milk).tag, MooTuning.MILK_PER_CYCLE, false));
        }
        CodexEntryGenerator_Elements.ConversionEntry ce1 = new CodexEntryGenerator_Elements.ConversionEntry();
        ce1.title = prefab.GetProperName();
        ce1.prefab = prefab;
        ce1.inSet = elementUsageSet1;
        ce1.outSet = elementUsageSet2;
        if (elementUsageSet1.Count > 0 && elementUsageSet2.Count > 0)
          usedMap.Add(prefab.PrefabID(), ce1);
        foreach (ElementUsage elementUsage in elementUsageSet1)
          usedMap.Add(elementUsage.tag, ce1);
        foreach (ElementUsage elementUsage in elementUsageSet2)
          madeMap.Add(elementUsage.tag, ce1);
        IPlantBranchGrower implementingInterface = prefab.GetDefImplementingInterface<IPlantBranchGrower>();
        if (implementingInterface != null)
        {
          GameObject prefab1 = Assets.GetPrefab((Tag) implementingInterface.GetPlantBranchPrefabName());
          if ((UnityEngine.Object) prefab1 != (UnityEngine.Object) null)
          {
            Crop component6 = prefab1.GetComponent<Crop>();
            if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((UnityEngine.Object) component3 == (UnityEngine.Object) null || component6.cropId != component3.cropId || component6.cropVal.numProduced != component3.cropVal.numProduced))
            {
              CodexEntryGenerator_Elements.ConversionEntry ce2 = new CodexEntryGenerator_Elements.ConversionEntry();
              ce2.title = prefab1.GetProperName();
              ce2.prefab = prefab;
              usedMap.Add(prefab.PrefabID(), ce2);
              ce2.inSet = new HashSet<ElementUsage>();
              IrrigationMonitor.Def def3 = prefab.GetDef<IrrigationMonitor.Def>();
              if (def3 != null)
              {
                foreach (PlantElementAbsorber.ConsumeInfo consumedElement in def3.consumedElements)
                  ce2.inSet.Add(new ElementUsage(consumedElement.tag, consumedElement.massConsumptionRate, true));
              }
              FertilizationMonitor.Def def4 = prefab.GetDef<FertilizationMonitor.Def>();
              if (def4 != null)
              {
                foreach (PlantElementAbsorber.ConsumeInfo consumedElement in def4.consumedElements)
                  ce2.inSet.Add(new ElementUsage(consumedElement.tag, consumedElement.massConsumptionRate, true));
              }
              ce2.outSet = new HashSet<ElementUsage>();
              int branchCount = implementingInterface.GetMaxBranchCount();
              ce2.outSet.Add(new ElementUsage((Tag) component6.cropId, (float) component6.cropVal.numProduced / component6.cropVal.cropDuration, true, (Func<Tag, float, bool, string>) ((t, a, b) => GameUtil.GetFormattedBranchGrowerPlantProductionValuePerCycle(t, a, branchCount))));
              madeMap.Add((Tag) component6.cropId, ce2);
            }
          }
        }
        if (component2 != null)
        {
          List<KPrefabID> prefabsOfPossiblePrey = component2.GetPrefabsOfPossiblePrey();
          List<string> stringList = new List<string>();
          foreach (KPrefabID kprefabId in prefabsOfPossiblePrey)
          {
            CreatureBrain component7 = kprefabId.GetComponent<CreatureBrain>();
            Tag tag = (UnityEngine.Object) component7 == (UnityEngine.Object) null ? kprefabId.PrefabID() : component7.species;
            string str = tag.ProperName();
            if (!stringList.Contains(str))
            {
              CodexEntryGenerator_Elements.ConversionEntry ce3 = new CodexEntryGenerator_Elements.ConversionEntry();
              ce3.title = $"{component2.GetConsumableEntitiesCategoryName()}: {str}";
              ce3.prefab = prefab;
              ce3.inSet.Add(new ElementUsage(tag, (UnityEngine.Object) component3 == (UnityEngine.Object) null ? 1f : 1f / component3.cropVal.cropDuration, (UnityEngine.Object) component3 != (UnityEngine.Object) null, (Func<Tag, float, bool, string>) ((t, amount, c) => GameUtil.GetFormattedUnits(amount, c ? GameUtil.TimeSlice.PerCycle : GameUtil.TimeSlice.None))));
              if ((UnityEngine.Object) component3 != (UnityEngine.Object) null)
              {
                ce3.outSet.Add(new ElementUsage((Tag) component3.cropId, (float) component3.cropVal.numProduced / component3.cropVal.cropDuration, true));
                madeMap.Add((Tag) component3.cropId, ce3);
              }
              usedMap.Add(prefab.PrefabID(), ce3);
              stringList.Add(str);
            }
          }
        }
        ScaleGrowthMonitor.Def def5 = prefab.GetDef<ScaleGrowthMonitor.Def>();
        if (def5 != null)
        {
          CodexEntryGenerator_Elements.ConversionEntry ce4 = new CodexEntryGenerator_Elements.ConversionEntry()
          {
            title = Assets.GetPrefab((Tag) "ShearingStation").GetProperName(),
            prefab = Assets.GetPrefab((Tag) "ShearingStation"),
            inSet = new HashSet<ElementUsage>()
          };
          ce4.inSet.Add(new ElementUsage(prefab.PrefabID(), 1f, false));
          usedMap.Add(prefab.PrefabID(), ce4);
          ce4.outSet = new HashSet<ElementUsage>();
          ce4.outSet.Add(new ElementUsage(def5.itemDroppedOnShear, def5.dropMass, false));
          madeMap.Add(def5.itemDroppedOnShear, ce4);
        }
        WellFedShearable.Def def6 = prefab.GetDef<WellFedShearable.Def>();
        if (def6 != null)
        {
          CodexEntryGenerator_Elements.ConversionEntry ce5 = new CodexEntryGenerator_Elements.ConversionEntry()
          {
            title = Assets.GetPrefab((Tag) "ShearingStation").GetProperName(),
            prefab = Assets.GetPrefab((Tag) "ShearingStation"),
            inSet = new HashSet<ElementUsage>()
          };
          ce5.inSet.Add(new ElementUsage(prefab.PrefabID(), 1f, false));
          usedMap.Add(prefab.PrefabID(), ce5);
          ce5.outSet = new HashSet<ElementUsage>();
          ce5.outSet.Add(new ElementUsage(def6.itemDroppedOnShear, def6.dropMass, false));
          madeMap.Add(def6.itemDroppedOnShear, ce5);
        }
        Butcherable component8 = prefab.GetComponent<Butcherable>();
        if (!((UnityEngine.Object) component8 != (UnityEngine.Object) null))
          return;
        CodexEntryGenerator_Elements.ConversionEntry ce6 = new CodexEntryGenerator_Elements.ConversionEntry();
        ce6.title = prefab.GetProperName();
        ce6.prefab = prefab;
        usedMap.Add(prefab.PrefabID(), ce6);
        ce6.outSet = new HashSet<ElementUsage>();
        Dictionary<string, float> dictionary = new Dictionary<string, float>();
        foreach (KeyValuePair<string, float> drop in component8.drops)
        {
          float num;
          dictionary.TryGetValue(drop.Key, out num);
          dictionary[drop.Key] = num + Assets.GetPrefab((Tag) drop.Key).GetComponent<PrimaryElement>().Mass * drop.Value;
        }
        foreach (KeyValuePair<string, float> keyValuePair in dictionary)
        {
          string str;
          float num;
          keyValuePair.Deconstruct(ref str, ref num);
          string t = str;
          float amount = num;
          ce6.outSet.Add(new ElementUsage((Tag) t, amount, false));
          madeMap.Add((Tag) t, ce6);
        }
      }
    }
    return CodexEntryGenerator_Elements.contextInstance;
  }

  public class ConversionEntry
  {
    public string title;
    public GameObject prefab;
    public HashSet<ElementUsage> inSet = new HashSet<ElementUsage>();
    public HashSet<ElementUsage> outSet = new HashSet<ElementUsage>();
  }

  public class CodexElementMap
  {
    public Dictionary<Tag, List<CodexEntryGenerator_Elements.ConversionEntry>> map = new Dictionary<Tag, List<CodexEntryGenerator_Elements.ConversionEntry>>();

    public void Add(Tag t, CodexEntryGenerator_Elements.ConversionEntry ce)
    {
      List<CodexEntryGenerator_Elements.ConversionEntry> conversionEntryList;
      if (this.map.TryGetValue(t, out conversionEntryList))
        conversionEntryList.Add(ce);
      else
        this.map[t] = new List<CodexEntryGenerator_Elements.ConversionEntry>()
        {
          ce
        };
    }
  }

  public class ElementEntryContext
  {
    public CodexEntryGenerator_Elements.CodexElementMap madeMap = new CodexEntryGenerator_Elements.CodexElementMap();
    public CodexEntryGenerator_Elements.CodexElementMap usedMap = new CodexEntryGenerator_Elements.CodexElementMap();
  }
}
