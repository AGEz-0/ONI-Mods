﻿// Decompiled with JetBrains decompiler
// Type: ChoreGroupManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
[AddComponentMenu("KMonoBehaviour/scripts/ChoreGroupManager")]
public class ChoreGroupManager : KMonoBehaviour, ISaveLoadable
{
  public static ChoreGroupManager instance;
  [Serialize]
  private List<Tag> defaultForbiddenTagsList = new List<Tag>();
  [Serialize]
  private Dictionary<Tag, int> defaultChorePermissions = new Dictionary<Tag, int>();

  public static void DestroyInstance() => ChoreGroupManager.instance = (ChoreGroupManager) null;

  public List<Tag> DefaultForbiddenTagsList => this.defaultForbiddenTagsList;

  public Dictionary<Tag, int> DefaultChorePermission => this.defaultChorePermissions;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    ChoreGroupManager.instance = this;
    this.ConvertOldVersion();
    foreach (ChoreGroup resource in Db.Get().ChoreGroups.resources)
    {
      if (!this.defaultChorePermissions.ContainsKey(resource.Id.ToTag()))
        this.defaultChorePermissions.Add(resource.Id.ToTag(), 2);
    }
  }

  private void ConvertOldVersion()
  {
    foreach (Tag defaultForbiddenTags in this.defaultForbiddenTagsList)
    {
      if (!this.defaultChorePermissions.ContainsKey(defaultForbiddenTags))
        this.defaultChorePermissions.Add(defaultForbiddenTags, -1);
      this.defaultChorePermissions[defaultForbiddenTags] = 0;
    }
    this.defaultForbiddenTagsList.Clear();
  }
}
