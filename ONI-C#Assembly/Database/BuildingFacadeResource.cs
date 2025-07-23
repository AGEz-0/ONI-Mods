// Decompiled with JetBrains decompiler
// Type: Database.BuildingFacadeResource
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Database;

public class BuildingFacadeResource : PermitResource
{
  public string PrefabID;
  public string AnimFile;
  public Dictionary<string, string> InteractFile;

  [Obsolete("Please use constructor with dlcIds parameter")]
  public BuildingFacadeResource(
    string Id,
    string Name,
    string Description,
    PermitRarity Rarity,
    string PrefabID,
    string AnimFile,
    Dictionary<string, string> workables = null)
    : this(Id, Name, Description, Rarity, PrefabID, AnimFile, workables, (string[]) null, (string[]) null)
  {
  }

  [Obsolete("Please use constructor with dlcIds parameter")]
  public BuildingFacadeResource(
    string Id,
    string Name,
    string Description,
    PermitRarity Rarity,
    string PrefabID,
    string AnimFile,
    string[] dlcIds,
    Dictionary<string, string> workables = null)
    : this(Id, Name, Description, Rarity, PrefabID, AnimFile, workables, (string[]) null, (string[]) null)
  {
  }

  public BuildingFacadeResource(
    string Id,
    string Name,
    string Description,
    PermitRarity Rarity,
    string PrefabID,
    string AnimFile,
    Dictionary<string, string> workables = null,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
    : base(Id, Name, Description, PermitCategory.Building, Rarity, requiredDlcIds, forbiddenDlcIds)
  {
    this.Id = Id;
    this.PrefabID = PrefabID;
    this.AnimFile = AnimFile;
    this.InteractFile = workables;
  }

  public void Init()
  {
    GameObject prefab = Assets.TryGetPrefab((Tag) this.PrefabID);
    if ((UnityEngine.Object) prefab == (UnityEngine.Object) null)
      return;
    prefab.AddOrGet<BuildingFacade>();
    BuildingDef def = prefab.GetComponent<Building>().Def;
    if (!((UnityEngine.Object) def != (UnityEngine.Object) null))
      return;
    def.AddFacade(this.Id);
  }

  public override PermitPresentationInfo GetPermitPresentationInfo()
  {
    PermitPresentationInfo presentationInfo = new PermitPresentationInfo();
    presentationInfo.sprite = Def.GetUISpriteFromMultiObjectAnim(Assets.GetAnim((HashedString) this.AnimFile));
    presentationInfo.SetFacadeForPrefabID(this.PrefabID);
    return presentationInfo;
  }
}
