// Decompiled with JetBrains decompiler
// Type: CodexCache
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei;
using STRINGS;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#nullable disable
public static class CodexCache
{
  private static string baseEntryPath;
  public static Dictionary<string, CodexEntry> entries;
  public static Dictionary<string, SubEntry> subEntries;
  private static Dictionary<string, List<string>> unlockedEntryLookup;
  private static List<Tuple<string, System.Type>> widgetTagMappings;

  public static string FormatLinkID(string linkID)
  {
    linkID = linkID.ToUpper();
    linkID = linkID.Replace("_", "");
    return linkID;
  }

  public static void CodexCacheInit()
  {
    CodexCache.entries = new Dictionary<string, CodexEntry>();
    CodexCache.subEntries = new Dictionary<string, SubEntry>();
    CodexCache.unlockedEntryLookup = new Dictionary<string, List<string>>();
    Dictionary<string, CodexEntry> entries = new Dictionary<string, CodexEntry>();
    if (CodexCache.widgetTagMappings == null)
      CodexCache.widgetTagMappings = new List<Tuple<string, System.Type>>()
      {
        new Tuple<string, System.Type>("!CodexText", typeof (CodexText)),
        new Tuple<string, System.Type>("!CodexImage", typeof (CodexImage)),
        new Tuple<string, System.Type>("!CodexDividerLine", typeof (CodexDividerLine)),
        new Tuple<string, System.Type>("!CodexSpacer", typeof (CodexSpacer)),
        new Tuple<string, System.Type>("!CodexLabelWithIcon", typeof (CodexLabelWithIcon)),
        new Tuple<string, System.Type>("!CodexLabelWithLargeIcon", typeof (CodexLabelWithLargeIcon)),
        new Tuple<string, System.Type>("!CodexContentLockedIndicator", typeof (CodexContentLockedIndicator)),
        new Tuple<string, System.Type>("!CodexLargeSpacer", typeof (CodexLargeSpacer)),
        new Tuple<string, System.Type>("!CodexVideo", typeof (CodexVideo)),
        new Tuple<string, System.Type>("!CodexElementCategoryList", typeof (CodexElementCategoryList))
      };
    string str1 = CodexCache.FormatLinkID("DUPLICANTSCATEGORY");
    entries.Add(str1, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str1, (string) UI.CODEX.CATEGORYNAMES.DUPLICANTS, CodexEntryGenerator.GenerateDuplicantEntries(), Assets.GetSprite((HashedString) "codexIconDupes"), sort: false, overrideHeader: (string) UI.CODEX.CATEGORYNAMES.DUPLICANTS));
    string str2 = CodexCache.FormatLinkID("LESSONS");
    entries.Add(str2, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str2, (string) UI.CODEX.CATEGORYNAMES.TIPS, CodexEntryGenerator.GenerateTutorialNotificationEntries(), Assets.GetSprite((HashedString) "codexIconLessons"), overrideHeader: (string) UI.CODEX.CATEGORYNAMES.VIDEOS));
    string str3 = CodexCache.FormatLinkID("creatures");
    entries.Add(str3, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str3, (string) UI.CODEX.CATEGORYNAMES.CREATURES, CodexEntryGenerator_Creatures.GenerateEntries(), Assets.GetSprite((HashedString) "codexIconCritters"), sort: false));
    DebugUtil.DevAssert(str3 == "CREATURES", string.Empty);
    string str4 = CodexCache.FormatLinkID("plants");
    entries.Add(str4, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str4, (string) UI.CODEX.CATEGORYNAMES.PLANTS, CodexEntryGenerator.GeneratePlantEntries()));
    string str5 = CodexCache.FormatLinkID("food");
    entries.Add(str5, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str5, (string) UI.CODEX.CATEGORYNAMES.FOOD, CodexEntryGenerator.GenerateFoodEntries(), Assets.GetSprite((HashedString) "codexIconFood")));
    string str6 = CodexCache.FormatLinkID("buildings");
    entries.Add(str6, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str6, (string) UI.CODEX.CATEGORYNAMES.BUILDINGS, CodexEntryGenerator.GenerateBuildingEntries(), Assets.GetSprite((HashedString) "codexIconBuildings")));
    string str7 = CodexCache.FormatLinkID("tech");
    entries.Add(str7, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str7, (string) UI.CODEX.CATEGORYNAMES.TECH, CodexEntryGenerator.GenerateTechEntries(), Assets.GetSprite((HashedString) "codexIconResearch")));
    string str8 = CodexCache.FormatLinkID("roles");
    entries.Add(str8, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str8, (string) UI.CODEX.CATEGORYNAMES.ROLES, CodexEntryGenerator.GenerateRoleEntries(), Assets.GetSprite((HashedString) "codexIconSkills")));
    string str9 = CodexCache.FormatLinkID("disease");
    entries.Add(str9, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str9, (string) UI.CODEX.CATEGORYNAMES.DISEASE, CodexEntryGenerator.GenerateDiseaseEntries(), Assets.GetSprite((HashedString) "codexIconDisease"), false));
    string str10 = CodexCache.FormatLinkID("elements");
    entries.Add(str10, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str10, (string) UI.CODEX.CATEGORYNAMES.ELEMENTS, CodexEntryGenerator_Elements.GenerateEntries(), Assets.GetSprite((HashedString) "codexIconElements"), sort: false));
    string str11 = CodexCache.FormatLinkID("BUILDINGMATERIALCLASSES");
    entries.Add(str11, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str11, (string) UI.CODEX.CATEGORYNAMES.BUILDINGMATERIALCLASSES, CodexEntryGenerator.GenerateConstructionMaterialEntries(), Assets.GetSprite((HashedString) "ui_elements_classes"), sort: false));
    string str12 = CodexCache.FormatLinkID("geysers");
    entries.Add(str12, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str12, (string) UI.CODEX.CATEGORYNAMES.GEYSERS, CodexEntryGenerator.GenerateGeyserEntries(), Assets.GetSprite((HashedString) "codexIconGeysers")));
    string str13 = CodexCache.FormatLinkID("equipment");
    entries.Add(str13, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str13, (string) UI.CODEX.CATEGORYNAMES.EQUIPMENT, CodexEntryGenerator.GenerateEquipmentEntries(), Assets.GetSprite((HashedString) "codexIconEquipment")));
    string str14 = CodexCache.FormatLinkID("biomes");
    entries.Add(str14, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str14, (string) UI.CODEX.CATEGORYNAMES.BIOMES, CodexEntryGenerator.GenerateBiomeEntries(), Assets.GetSprite((HashedString) "codexIconGeysers")));
    string str15 = CodexCache.FormatLinkID("rooms");
    entries.Add(str15, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str15, (string) UI.CODEX.CATEGORYNAMES.ROOMS, CodexEntryGenerator.GenerateRoomsEntries(), Assets.GetSprite((HashedString) "codexIconRooms")));
    string str16 = CodexCache.FormatLinkID("STORYTRAITS");
    entries.Add(str16, (CodexEntry) CodexEntryGenerator.GenerateCategoryEntry(str16, (string) UI.CODEX.CATEGORYNAMES.STORYTRAITS, new Dictionary<string, CodexEntry>(), Assets.GetSprite((HashedString) "codexIconStoryTraits")));
    if (Game.IsDlcActiveForCurrentSave("DLC3_ID"))
    {
      CodexEntryGenerator.GenerateBionicUpgradeEntries();
      CodexEntryGenerator.GenerateElectrobankEntries();
    }
    CategoryEntry categoryEntry = CodexEntryGenerator.GenerateCategoryEntry(CodexCache.FormatLinkID("HOME"), (string) UI.CODEX.CATEGORYNAMES.ROOT, entries);
    CodexEntryGenerator.GeneratePageNotFound();
    List<CategoryEntry> categoryEntryList = new List<CategoryEntry>();
    foreach (KeyValuePair<string, CodexEntry> keyValuePair in entries)
      categoryEntryList.Add(keyValuePair.Value as CategoryEntry);
    CodexCache.CollectYAMLEntries(categoryEntryList);
    CodexCache.CollectYAMLSubEntries(categoryEntryList);
    CodexCache.CheckUnlockableContent();
    categoryEntryList.Add(categoryEntry);
    foreach (KeyValuePair<string, CodexEntry> entry in CodexCache.entries)
    {
      if (entry.Value.contentMadeAndUsed.Count > 0)
      {
        foreach (CodexEntry_MadeAndUsed entryMadeAndUsed in entry.Value.contentMadeAndUsed)
        {
          List<ContentContainer> contentContainerList = new List<ContentContainer>();
          Element element = ElementLoader.GetElement((Tag) entryMadeAndUsed.tag);
          if (element != null)
            CodexEntryGenerator_Elements.GenerateElementDescriptionContainers(element, contentContainerList);
          else
            CodexEntryGenerator_Elements.GenerateMadeAndUsedContainers((Tag) entryMadeAndUsed.tag, contentContainerList);
          entry.Value.contentContainers.InsertRange(entry.Value.contentContainers.Count, (IEnumerable<ContentContainer>) contentContainerList);
        }
      }
      if (entry.Value.subEntries.Count > 0)
      {
        entry.Value.subEntries.Sort((Comparison<SubEntry>) ((a, b) => a.layoutPriority.CompareTo(b.layoutPriority)));
        if ((UnityEngine.Object) entry.Value.icon == (UnityEngine.Object) null)
        {
          entry.Value.icon = entry.Value.subEntries[0].icon;
          entry.Value.iconColor = entry.Value.subEntries[0].iconColor;
        }
        int num = 0;
        foreach (SubEntry subEntry in entry.Value.subEntries)
        {
          if (subEntry.lockID != null && !Game.Instance.unlocks.IsUnlocked(subEntry.lockID))
            ++num;
        }
        if (entry.Value.subEntries.Count > 1)
        {
          List<ICodexWidget> content = new List<ICodexWidget>();
          content.Add((ICodexWidget) new CodexSpacer());
          content.Add((ICodexWidget) new CodexText(string.Format((string) CODEX.HEADERS.SUBENTRIES, (object) (entry.Value.subEntries.Count - num), (object) entry.Value.subEntries.Count), CodexTextStyle.Subtitle));
          foreach (SubEntry subEntry in entry.Value.subEntries)
          {
            if (subEntry.lockID != null && !Game.Instance.unlocks.IsUnlocked(subEntry.lockID))
            {
              content.Add((ICodexWidget) new CodexText(UI.FormatAsLink((string) CODEX.HEADERS.CONTENTLOCKED, UI.ExtractLinkID(subEntry.name))));
            }
            else
            {
              string text = UI.FormatAsLink(UI.StripLinkFormatting(subEntry.name == null ? (string) Strings.Get(subEntry.title) : subEntry.name), subEntry.id);
              content.Add((ICodexWidget) new CodexText(text));
            }
          }
          content.Add((ICodexWidget) new CodexSpacer());
          entry.Value.contentContainers.Insert(entry.Value.customContentLength, new ContentContainer(content, ContentContainer.ContentLayout.Vertical));
        }
      }
      for (int index = 0; index < entry.Value.subEntries.Count; ++index)
        entry.Value.AddContentContainerRange((IEnumerable<ContentContainer>) entry.Value.subEntries[index].contentContainers);
    }
    CodexEntryGenerator.PopulateCategoryEntries(categoryEntryList, (Comparison<CodexEntry>) ((a, b) =>
    {
      if (a.name == (string) UI.CODEX.CATEGORYNAMES.TIPS)
        return -1;
      return b.name == (string) UI.CODEX.CATEGORYNAMES.TIPS ? 1 : UI.StripLinkFormatting(a.name).CompareTo(UI.StripLinkFormatting(b.name));
    }));
  }

  public static CodexEntry FindEntry(string id)
  {
    if (CodexCache.entries == null)
    {
      Debug.LogWarning((object) "Can't search Codex cache while it's stil null");
      return (CodexEntry) null;
    }
    if (CodexCache.entries.ContainsKey(id))
      return CodexCache.entries[id];
    Debug.LogWarning((object) ("Could not find codex entry with id: " + id));
    return (CodexEntry) null;
  }

  public static SubEntry FindSubEntry(string id)
  {
    foreach (KeyValuePair<string, CodexEntry> entry in CodexCache.entries)
    {
      foreach (SubEntry subEntry in entry.Value.subEntries)
      {
        if (subEntry.id.ToUpper() == id.ToUpper())
          return subEntry;
      }
    }
    return (SubEntry) null;
  }

  private static void CheckUnlockableContent()
  {
    foreach (KeyValuePair<string, CodexEntry> entry in CodexCache.entries)
    {
      foreach (SubEntry subEntry in entry.Value.subEntries)
      {
        if (subEntry.lockedContentContainer != null)
        {
          subEntry.lockedContentContainer.content.Clear();
          subEntry.contentContainers.Remove(subEntry.lockedContentContainer);
        }
      }
    }
  }

  private static void CollectYAMLEntries(List<CategoryEntry> categories)
  {
    CodexCache.baseEntryPath = Application.streamingAssetsPath + "/codex";
    foreach (CodexEntry collectEntry in CodexCache.CollectEntries(""))
    {
      if (collectEntry != null && collectEntry.id != null && collectEntry.contentContainers != null && Game.IsCorrectDlcActiveForCurrentSave((IHasDlcRestrictions) collectEntry))
      {
        if (CodexCache.entries.ContainsKey(CodexCache.FormatLinkID(collectEntry.id)))
        {
          CodexCache.MergeEntry(collectEntry.id, collectEntry);
        }
        else
        {
          CodexCache.AddEntry(collectEntry.id, collectEntry, categories);
          collectEntry.customContentLength = collectEntry.contentContainers.Count;
        }
      }
    }
    foreach (string directory in Directory.GetDirectories(CodexCache.baseEntryPath))
    {
      foreach (CodexEntry collectEntry in CodexCache.CollectEntries(System.IO.Path.GetFileNameWithoutExtension(directory)))
      {
        if (collectEntry != null && collectEntry.id != null && collectEntry.contentContainers != null && Game.IsCorrectDlcActiveForCurrentSave((IHasDlcRestrictions) collectEntry))
        {
          if (CodexCache.entries.ContainsKey(CodexCache.FormatLinkID(collectEntry.id)))
          {
            CodexCache.MergeEntry(collectEntry.id, collectEntry);
          }
          else
          {
            CodexCache.AddEntry(collectEntry.id, collectEntry, categories);
            collectEntry.customContentLength = collectEntry.contentContainers.Count;
          }
        }
      }
    }
  }

  private static void CollectYAMLSubEntries(List<CategoryEntry> categories)
  {
    CodexCache.baseEntryPath = Application.streamingAssetsPath + "/codex";
    foreach (SubEntry collectSubEntry in CodexCache.CollectSubEntries(""))
    {
      SubEntry v = collectSubEntry;
      if (v.parentEntryID != null && v.id != null && Game.IsCorrectDlcActiveForCurrentSave((IHasDlcRestrictions) v))
      {
        if (CodexCache.entries.ContainsKey(v.parentEntryID.ToUpper()))
        {
          SubEntry subEntry = CodexCache.entries[v.parentEntryID.ToUpper()].subEntries.Find((Predicate<SubEntry>) (match => match.id == v.id));
          if (!string.IsNullOrEmpty(v.lockID))
          {
            foreach (ContentContainer contentContainer in v.contentContainers)
              contentContainer.lockID = v.lockID;
          }
          if (subEntry != null)
          {
            if (!string.IsNullOrEmpty(v.lockID))
            {
              foreach (ContentContainer contentContainer in subEntry.contentContainers)
                contentContainer.lockID = v.lockID;
              subEntry.lockID = v.lockID;
            }
            for (int index = 0; index < v.contentContainers.Count; ++index)
            {
              if (Game.IsCorrectDlcActiveForCurrentSave((IHasDlcRestrictions) v.contentContainers[index]))
              {
                if (!string.IsNullOrEmpty(v.contentContainers[index].lockID))
                {
                  int num = subEntry.contentContainers.IndexOf(subEntry.lockedContentContainer);
                  subEntry.contentContainers.Insert(num + 1, v.contentContainers[index]);
                }
                else if (v.contentContainers[index].showBeforeGeneratedContent)
                  subEntry.contentContainers.Insert(0, v.contentContainers[index]);
                else
                  subEntry.contentContainers.Add(v.contentContainers[index]);
              }
            }
            subEntry.contentContainers.Add(new ContentContainer(new List<ICodexWidget>()
            {
              (ICodexWidget) new CodexLargeSpacer()
            }, ContentContainer.ContentLayout.Vertical));
            subEntry.layoutPriority = v.layoutPriority;
          }
          else
            CodexCache.entries[v.parentEntryID.ToUpper()].subEntries.Add(v);
        }
        else
          Debug.LogWarningFormat("Codex SubEntry {0} cannot find parent codex entry with id {1}", (object) v.name, (object) v.parentEntryID);
      }
    }
  }

  private static void AddLockLookup(string lockId, string articleId)
  {
    if (!CodexCache.unlockedEntryLookup.ContainsKey(lockId))
      CodexCache.unlockedEntryLookup[lockId] = new List<string>();
    CodexCache.unlockedEntryLookup[lockId].Add(articleId);
  }

  public static string GetEntryForLock(string lockId)
  {
    if (CodexCache.unlockedEntryLookup == null)
    {
      Debug.LogWarningFormat("Trying to get lock entry {0} before codex cache has been initialized.", (object) lockId);
      return (string) null;
    }
    if (string.IsNullOrEmpty(lockId))
      return (string) null;
    return CodexCache.unlockedEntryLookup.ContainsKey(lockId) && CodexCache.unlockedEntryLookup[lockId] != null && CodexCache.unlockedEntryLookup[lockId].Count > 0 ? CodexCache.unlockedEntryLookup[lockId][0] : (string) null;
  }

  public static void AddEntry(string id, CodexEntry entry, List<CategoryEntry> categoryEntries = null)
  {
    id = CodexCache.FormatLinkID(id);
    if (CodexCache.entries.ContainsKey(id))
      Debug.LogError((object) $"Tried to add {id} to the Codex screen multiple times");
    CodexCache.entries.Add(id, entry);
    entry.id = id;
    if (entry.name == null)
      entry.name = (string) Strings.Get(entry.title);
    if (!string.IsNullOrEmpty(entry.iconAssetName))
    {
      try
      {
        entry.icon = Assets.GetSprite((HashedString) entry.iconAssetName);
        if (!entry.iconLockID.IsNullOrWhiteSpace())
          entry.iconColor = Game.Instance.unlocks.IsUnlocked(entry.iconLockID) ? Color.white : Color.black;
      }
      catch
      {
        Debug.LogWarningFormat("Unable to get icon for asset name {0}", (object) entry.iconAssetName);
      }
    }
    else if (!string.IsNullOrEmpty(entry.iconPrefabID))
    {
      try
      {
        entry.icon = Def.GetUISpriteFromMultiObjectAnim(Assets.GetPrefab((Tag) entry.iconPrefabID).GetComponent<KBatchedAnimController>().AnimFiles[0]);
        if (!entry.iconLockID.IsNullOrWhiteSpace())
          entry.iconColor = Game.Instance.unlocks.IsUnlocked(entry.iconLockID) ? Color.white : Color.black;
      }
      catch
      {
        Debug.LogWarningFormat("Unable to get icon for prefabID {0}", (object) entry.iconPrefabID);
      }
    }
    if (!entry.parentId.IsNullOrWhiteSpace() && CodexCache.entries.ContainsKey(entry.parentId))
      (CodexCache.entries[entry.parentId] as CategoryEntry).entriesInCategory.Add(entry);
    foreach (ContentContainer contentContainer in entry.contentContainers)
    {
      if (contentContainer.lockID != null)
        CodexCache.AddLockLookup(contentContainer.lockID, entry.id);
    }
    entry.contentContainers.RemoveAll((Predicate<ContentContainer>) (x => !Game.IsCorrectDlcActiveForCurrentSave((IHasDlcRestrictions) x)));
  }

  public static void AddSubEntry(string id, SubEntry entry)
  {
  }

  public static void MergeSubEntry(string id, SubEntry entry)
  {
  }

  public static void MergeEntry(string id, CodexEntry entry)
  {
    id = CodexCache.FormatLinkID(entry.id);
    entry.id = id;
    CodexEntry entry1 = CodexCache.entries[id];
    if (entry1.GetRequiredDlcIds() != null && entry.GetForbiddenDlcIds() != null)
      DebugUtil.DevLogError($"Codex Entry with id={id} defines requiredDlcIds but the existing entry also specifies requiredDlcIds. This is currently not handled, please investigate.");
    if (entry1.GetRequiredDlcIds() != null && entry.GetForbiddenDlcIds() != null)
      DebugUtil.DevLogError($"Codex Entry with id={id} defines forbiddenDlcIds but the existing entry also specifies forbiddenDlcIds. This is currently not handled, please investigate.");
    if (entry.requiredDlcIds != null)
      entry1.requiredDlcIds = entry.requiredDlcIds;
    if (entry.forbiddenDlcIds != null)
      entry1.forbiddenDlcIds = entry.forbiddenDlcIds;
    int num = 0;
    while (num < entry.log.modificationRecords.Count)
      ++num;
    entry1.customContentLength = entry.contentContainers.Count;
    for (int index = entry.contentContainers.Count - 1; index >= 0; --index)
      entry1.InsertContentContainer(0, entry.contentContainers[index]);
    if (entry.disabled)
      entry1.disabled = entry.disabled;
    entry1.showBeforeGeneratedCategoryLinks = entry.showBeforeGeneratedCategoryLinks;
    if (!string.IsNullOrEmpty(entry.category))
      entry1.category = entry.category;
    if (!string.IsNullOrEmpty(entry.parentId))
      entry1.parentId = entry.parentId;
    foreach (ContentContainer contentContainer in entry.contentContainers)
    {
      if (contentContainer.lockID != null)
        CodexCache.AddLockLookup(contentContainer.lockID, entry.id);
    }
  }

  public static void Clear()
  {
    CodexCache.entries = (Dictionary<string, CodexEntry>) null;
    CodexCache.baseEntryPath = (string) null;
  }

  public static string GetEntryPath() => CodexCache.baseEntryPath;

  public static CodexEntry GetTemplate(string templatePath)
  {
    if (!CodexCache.entries.ContainsKey(templatePath))
      CodexCache.entries.Add(templatePath, (CodexEntry) null);
    if (CodexCache.entries[templatePath] == null)
    {
      string str = System.IO.Path.Combine(CodexCache.baseEntryPath, templatePath);
      CodexEntry codexEntry = YamlIO.LoadFile<CodexEntry>(str + ".yaml", tagMappings: CodexCache.widgetTagMappings);
      if (codexEntry == null)
        Debug.LogWarning((object) $"Missing template [{str}.yaml]");
      CodexCache.entries[templatePath] = codexEntry;
    }
    return CodexCache.entries[templatePath];
  }

  private static void YamlParseErrorCB(YamlIO.Error error, bool force_log_as_warning)
  {
    throw new Exception($"{error.severity} parse error in {error.file.full_path}\n{error.message}", error.inner_exception);
  }

  public static List<CodexEntry> CollectEntries(string folder)
  {
    List<CodexEntry> codexEntryList = new List<CodexEntry>();
    string path = folder == "" ? CodexCache.baseEntryPath : System.IO.Path.Combine(CodexCache.baseEntryPath, folder);
    string[] strArray = new string[0];
    try
    {
      strArray = Directory.GetFiles(path, "*.yaml");
    }
    catch (UnauthorizedAccessException ex)
    {
      Debug.LogWarning((object) ex);
    }
    string upper = folder.ToUpper();
    foreach (string str in strArray)
    {
      if (!CodexCache.IsSubEntryAtPath(str))
      {
        try
        {
          CodexEntry codexEntry = YamlIO.LoadFile<CodexEntry>(str, new YamlIO.ErrorHandler(CodexCache.YamlParseErrorCB), CodexCache.widgetTagMappings);
          if (codexEntry != null)
          {
            codexEntry.category = upper;
            codexEntryList.Add(codexEntry);
          }
        }
        catch (Exception ex)
        {
          DebugUtil.DevLogErrorFormat("CodexCache.CollectEntries failed to load [{0}]: {1}", (object) str, (object) ex.ToString());
        }
      }
    }
    foreach (CodexEntry codexEntry in codexEntryList)
    {
      if (string.IsNullOrEmpty(codexEntry.sortString))
        codexEntry.sortString = (string) Strings.Get(codexEntry.title);
    }
    codexEntryList.Sort((Comparison<CodexEntry>) ((x, y) => x.sortString.CompareTo(y.sortString)));
    return codexEntryList;
  }

  public static List<SubEntry> CollectSubEntries(string folder)
  {
    List<SubEntry> subEntryList = new List<SubEntry>();
    string path = folder == "" ? CodexCache.baseEntryPath : System.IO.Path.Combine(CodexCache.baseEntryPath, folder);
    string[] strArray = new string[0];
    try
    {
      strArray = Directory.GetFiles(path, "*.yaml", SearchOption.AllDirectories);
    }
    catch (UnauthorizedAccessException ex)
    {
      Debug.LogWarning((object) ex);
    }
    foreach (string str in strArray)
    {
      if (CodexCache.IsSubEntryAtPath(str))
      {
        try
        {
          SubEntry subEntry = YamlIO.LoadFile<SubEntry>(str, new YamlIO.ErrorHandler(CodexCache.YamlParseErrorCB), CodexCache.widgetTagMappings);
          if (subEntry != null)
            subEntryList.Add(subEntry);
        }
        catch (Exception ex)
        {
          DebugUtil.DevLogErrorFormat("CodexCache.CollectSubEntries failed to load [{0}]: {1}", (object) str, (object) ex.ToString());
        }
      }
    }
    subEntryList.Sort((Comparison<SubEntry>) ((x, y) => x.title.CompareTo(y.title)));
    return subEntryList;
  }

  public static bool IsSubEntryAtPath(string path) => System.IO.Path.GetFileName(path).Contains("SubEntry");
}
