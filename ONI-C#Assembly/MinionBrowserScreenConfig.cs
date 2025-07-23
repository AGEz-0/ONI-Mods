// Decompiled with JetBrains decompiler
// Type: MinionBrowserScreenConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
public readonly struct MinionBrowserScreenConfig(
  MinionBrowserScreen.GridItem[] items,
  Option<MinionBrowserScreen.GridItem> defaultSelectedItem)
{
  public readonly MinionBrowserScreen.GridItem[] items = items;
  public readonly Option<MinionBrowserScreen.GridItem> defaultSelectedItem = defaultSelectedItem;
  public readonly bool isValid = true;

  public static MinionBrowserScreenConfig Personalities(
    Option<Personality> defaultSelectedPersonality = default (Option<Personality>))
  {
    MinionBrowserScreen.GridItem.PersonalityTarget[] items = Db.Get().Personalities.GetAll(true, false).Select<Personality, MinionBrowserScreen.GridItem.PersonalityTarget>((Func<Personality, MinionBrowserScreen.GridItem.PersonalityTarget>) (personality => MinionBrowserScreen.GridItem.Of(personality))).ToArray<MinionBrowserScreen.GridItem.PersonalityTarget>();
    Option<MinionBrowserScreen.GridItem> defaultSelectedItem = defaultSelectedPersonality.AndThen<MinionBrowserScreen.GridItem>((Func<Personality, MinionBrowserScreen.GridItem>) (personality => (MinionBrowserScreen.GridItem) ((IEnumerable<MinionBrowserScreen.GridItem.PersonalityTarget>) items).FirstOrDefault<MinionBrowserScreen.GridItem.PersonalityTarget>((Func<MinionBrowserScreen.GridItem.PersonalityTarget, bool>) (item => item.personality == personality))));
    if (defaultSelectedItem.IsNone() && items.Length != 0)
      defaultSelectedItem = (Option<MinionBrowserScreen.GridItem>) (MinionBrowserScreen.GridItem) items[0];
    return new MinionBrowserScreenConfig((MinionBrowserScreen.GridItem[]) items, defaultSelectedItem);
  }

  public static MinionBrowserScreenConfig MinionInstances(
    Option<GameObject> defaultSelectedMinionInstance = default (Option<GameObject>))
  {
    MinionBrowserScreen.GridItem.MinionInstanceTarget[] items = Components.MinionIdentities.Items.Select<MinionIdentity, MinionBrowserScreen.GridItem.MinionInstanceTarget>((Func<MinionIdentity, MinionBrowserScreen.GridItem.MinionInstanceTarget>) (minionIdentity => MinionBrowserScreen.GridItem.Of(minionIdentity.gameObject))).ToArray<MinionBrowserScreen.GridItem.MinionInstanceTarget>();
    Option<MinionBrowserScreen.GridItem> defaultSelectedItem = defaultSelectedMinionInstance.AndThen<MinionBrowserScreen.GridItem>((Func<GameObject, MinionBrowserScreen.GridItem>) (minionInstance => (MinionBrowserScreen.GridItem) ((IEnumerable<MinionBrowserScreen.GridItem.MinionInstanceTarget>) items).FirstOrDefault<MinionBrowserScreen.GridItem.MinionInstanceTarget>((Func<MinionBrowserScreen.GridItem.MinionInstanceTarget, bool>) (item => (UnityEngine.Object) item.minionInstance == (UnityEngine.Object) minionInstance))));
    if (defaultSelectedItem.IsNone() && items.Length != 0)
      defaultSelectedItem = (Option<MinionBrowserScreen.GridItem>) (MinionBrowserScreen.GridItem) items[0];
    return new MinionBrowserScreenConfig((MinionBrowserScreen.GridItem[]) items, defaultSelectedItem);
  }

  public void ApplyAndOpenScreen(System.Action onClose = null)
  {
    LockerNavigator.Instance.duplicantCatalogueScreen.GetComponent<MinionBrowserScreen>().Configure(this);
    LockerNavigator.Instance.PushScreen(LockerNavigator.Instance.duplicantCatalogueScreen, onClose);
  }
}
