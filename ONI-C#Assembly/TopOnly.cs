﻿// Decompiled with JetBrains decompiler
// Type: TopOnly
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class TopOnly : SelectModuleCondition
{
  public override bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext)
  {
    Debug.Assert((Object) existingModule != (Object) null, (object) "Existing module is null in top only condition");
    if (selectionContext == SelectModuleCondition.SelectionContext.ReplaceModule)
    {
      Debug.Assert((Object) existingModule.GetComponent<LaunchPad>() == (Object) null, (object) "Trying to replace launch pad with rocket module");
      return (Object) existingModule.GetComponent<BuildingAttachPoint>() == (Object) null || (Object) existingModule.GetComponent<BuildingAttachPoint>().points[0].attachedBuilding == (Object) null;
    }
    if ((Object) existingModule.GetComponent<LaunchPad>() != (Object) null)
      return true;
    return (Object) existingModule.GetComponent<BuildingAttachPoint>() != (Object) null && (Object) existingModule.GetComponent<BuildingAttachPoint>().points[0].attachedBuilding == (Object) null;
  }

  public override string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart)
  {
    return ready ? (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.TOP_ONLY.COMPLETE : (string) UI.UISIDESCREENS.SELECTMODULESIDESCREEN.CONSTRAINTS.TOP_ONLY.FAILED;
  }
}
