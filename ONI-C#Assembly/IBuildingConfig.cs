// Decompiled with JetBrains decompiler
// Type: IBuildingConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public abstract class IBuildingConfig : IHasDlcRestrictions
{
  public abstract BuildingDef CreateBuildingDef();

  public virtual void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
  }

  public abstract void DoPostConfigureComplete(GameObject go);

  public virtual void DoPostConfigurePreview(BuildingDef def, GameObject go)
  {
  }

  public virtual void DoPostConfigureUnderConstruction(GameObject go)
  {
  }

  public virtual void ConfigurePost(BuildingDef def)
  {
  }

  [Obsolete("Implement GetRequiredDlcIds and/or GetForbiddenDlcIds instead")]
  public virtual string[] GetDlcIds() => (string[]) null;

  public virtual string[] GetRequiredDlcIds() => (string[]) null;

  public virtual string[] GetForbiddenDlcIds() => (string[]) null;

  public virtual bool ForbidFromLoading() => false;
}
