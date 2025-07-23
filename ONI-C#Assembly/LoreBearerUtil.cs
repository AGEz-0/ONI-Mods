﻿// Decompiled with JetBrains decompiler
// Type: LoreBearerUtil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using UnityEngine;

#nullable disable
public static class LoreBearerUtil
{
  public static void AddLoreTo(GameObject prefabOrGameObject)
  {
    prefabOrGameObject.AddOrGet<LoreBearer>();
  }

  public static void AddLoreTo(GameObject prefabOrGameObject, LoreBearerAction unlockLoreFn)
  {
    KPrefabID component = prefabOrGameObject.GetComponent<KPrefabID>();
    if (component.IsInitialized())
    {
      prefabOrGameObject.AddOrGet<LoreBearer>().Internal_SetContent(unlockLoreFn);
    }
    else
    {
      prefabOrGameObject.AddComponent<LoreBearer>();
      component.prefabInitFn += (KPrefabID.PrefabFn) (gameObject => gameObject.GetComponent<LoreBearer>().Internal_SetContent(unlockLoreFn));
    }
  }

  public static void AddLoreTo(GameObject prefabOrGameObject, string[] collectionsToUnlockFrom)
  {
    KPrefabID component = prefabOrGameObject.GetComponent<KPrefabID>();
    if (component.IsInitialized())
    {
      prefabOrGameObject.AddOrGet<LoreBearer>().Internal_SetContent(LoreBearerUtil.UnlockNextInCollections(collectionsToUnlockFrom));
    }
    else
    {
      prefabOrGameObject.AddComponent<LoreBearer>();
      component.prefabInitFn += (KPrefabID.PrefabFn) (gameObject => gameObject.GetComponent<LoreBearer>().Internal_SetContent(LoreBearerUtil.UnlockNextInCollections(collectionsToUnlockFrom)));
    }
  }

  public static LoreBearerAction UnlockSpecificEntry(string unlockId, string searchDisplayText)
  {
    return (LoreBearerAction) (screen =>
    {
      Game.Instance.unlocks.Unlock(unlockId);
      screen.AddPlainText(searchDisplayText);
      screen.AddOption((string) UI.USERMENUACTIONS.READLORE.GOTODATABASE, LoreBearerUtil.OpenCodexByLockKeyID(unlockId));
    });
  }

  public static void UnlockNextEmail(InfoDialogScreen screen)
  {
    string key = Game.Instance.unlocks.UnlockNext("emails");
    if (key != null)
    {
      string str = "SEARCH" + UnityEngine.Random.Range(1, 6).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_COMPUTER_SUCCESS." + str));
      screen.AddOption((string) UI.USERMENUACTIONS.READLORE.GOTODATABASE, LoreBearerUtil.OpenCodexByLockKeyID(key));
    }
    else
    {
      string str = "SEARCH" + UnityEngine.Random.Range(1, 8).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_COMPUTER_FAIL." + str));
    }
  }

  public static void UnlockNextResearchNote(InfoDialogScreen screen)
  {
    string key = Game.Instance.unlocks.UnlockNext("researchnotes");
    if (key != null)
    {
      string str = "SEARCH" + UnityEngine.Random.Range(1, 3).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_TECHNOLOGY_SUCCESS." + str));
      screen.AddOption((string) UI.USERMENUACTIONS.READLORE.GOTODATABASE, LoreBearerUtil.OpenCodexByLockKeyID(key));
    }
    else
    {
      string str = "SEARCH1";
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_OBJECT_FAIL." + str));
    }
  }

  public static void UnlockNextJournalEntry(InfoDialogScreen screen)
  {
    string key = Game.Instance.unlocks.UnlockNext("journals");
    if (key != null)
    {
      string str = "SEARCH" + UnityEngine.Random.Range(1, 6).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_OBJECT_SUCCESS." + str));
      screen.AddOption((string) UI.USERMENUACTIONS.READLORE.GOTODATABASE, LoreBearerUtil.OpenCodexByLockKeyID(key));
    }
    else
    {
      string str = "SEARCH1";
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_OBJECT_FAIL." + str));
    }
  }

  public static void UnlockNextDimensionalLore(InfoDialogScreen screen)
  {
    string key = Game.Instance.unlocks.UnlockNext("dimensionallore", true);
    if (key != null)
    {
      string str = "SEARCH" + UnityEngine.Random.Range(1, 6).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_OBJECT_SUCCESS." + str));
      screen.AddOption((string) UI.USERMENUACTIONS.READLORE.GOTODATABASE, LoreBearerUtil.OpenCodexByLockKeyID(key));
    }
    else
    {
      string str = "SEARCH1";
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_OBJECT_FAIL." + str));
    }
  }

  public static void UnlockNextSpaceEntry(InfoDialogScreen screen)
  {
    string key = Game.Instance.unlocks.UnlockNext("space");
    if (key != null)
    {
      string str = "SEARCH" + UnityEngine.Random.Range(1, 7).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_SPACEPOI_SUCCESS." + str));
      screen.AddOption((string) UI.USERMENUACTIONS.READLORE.GOTODATABASE, LoreBearerUtil.OpenCodexByLockKeyID(key));
    }
    else
    {
      string str = "SEARCH" + UnityEngine.Random.Range(1, 4).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_SPACEPOI_FAIL." + str));
    }
  }

  public static void UnlockNextDeskPodiumEntry(InfoDialogScreen screen)
  {
    if (!Game.Instance.unlocks.IsUnlocked("story_trait_critter_manipulator_parking"))
    {
      Game.Instance.unlocks.Unlock("story_trait_critter_manipulator_parking");
      string str = "SEARCH" + UnityEngine.Random.Range(1, 1).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_COMPUTER_PODIUM." + str));
      screen.AddOption((string) UI.USERMENUACTIONS.READLORE.GOTODATABASE, LoreBearerUtil.OpenCodexByLockKeyID("story_trait_critter_manipulator_parking"));
    }
    else
    {
      string str = "SEARCH" + UnityEngine.Random.Range(1, 8).ToString();
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_COMPUTER_FAIL." + str));
    }
  }

  public static LoreBearerAction UnlockNextInCollections(string[] collectionsToUnlockFrom)
  {
    return (LoreBearerAction) (screen =>
    {
      foreach (string collectionID in collectionsToUnlockFrom)
      {
        string key = Game.Instance.unlocks.UnlockNext(collectionID);
        if (key != null)
        {
          screen.AddPlainText((string) UI.USERMENUACTIONS.READLORE.SEARCH_OBJECT_SUCCESS.SEARCH1);
          screen.AddOption((string) UI.USERMENUACTIONS.READLORE.GOTODATABASE, LoreBearerUtil.OpenCodexByLockKeyID(key));
          return;
        }
      }
      string str = "SEARCH1";
      screen.AddPlainText((string) Strings.Get("STRINGS.UI.USERMENUACTIONS.READLORE.SEARCH_OBJECT_FAIL." + str));
    });
  }

  public static void NerualVacillator(InfoDialogScreen screen)
  {
    Game.Instance.unlocks.Unlock("neuralvacillator");
    LoreBearerUtil.UnlockNextResearchNote(screen);
  }

  public static Action<InfoDialogScreen> OpenCodexByLockKeyID(string key, bool focusContent = false)
  {
    return (Action<InfoDialogScreen>) (dialog =>
    {
      dialog.Deactivate();
      ManagementMenu.Instance.OpenCodexToLockId(key, focusContent);
    });
  }

  public static Action<InfoDialogScreen> OpenCodexByEntryID(string id)
  {
    return (Action<InfoDialogScreen>) (dialog =>
    {
      dialog.Deactivate();
      ManagementMenu.Instance.OpenCodexToEntry(id);
    });
  }
}
