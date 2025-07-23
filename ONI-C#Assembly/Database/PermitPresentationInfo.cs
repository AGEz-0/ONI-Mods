// Decompiled with JetBrains decompiler
// Type: Database.PermitPresentationInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
namespace Database;

public struct PermitPresentationInfo
{
  public Sprite sprite;

  public string facadeFor { get; private set; }

  public static Sprite GetUnknownSprite() => Assets.GetSprite((HashedString) "unknown");

  public void SetFacadeForPrefabName(string prefabName)
  {
    this.facadeFor = UI.KLEI_INVENTORY_SCREEN.ITEM_FACADE_FOR.Replace("{ConfigProperName}", prefabName);
  }

  public void SetFacadeForPrefabID(string prefabId)
  {
    if ((Object) Assets.TryGetPrefab((Tag) prefabId) == (Object) null)
      this.facadeFor = (string) UI.KLEI_INVENTORY_SCREEN.ITEM_DLC_REQUIRED;
    else
      this.facadeFor = UI.KLEI_INVENTORY_SCREEN.ITEM_FACADE_FOR.Replace("{ConfigProperName}", Assets.GetPrefab((Tag) prefabId).GetProperName());
  }

  public void SetFacadeForText(string text) => this.facadeFor = text;
}
