﻿// Decompiled with JetBrains decompiler
// Type: SelectModuleCondition
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public abstract class SelectModuleCondition
{
  public abstract bool EvaluateCondition(
    GameObject existingModule,
    BuildingDef selectedPart,
    SelectModuleCondition.SelectionContext selectionContext);

  public abstract string GetStatusTooltip(
    bool ready,
    GameObject moduleBase,
    BuildingDef selectedPart);

  public virtual bool IgnoreInSanboxMode() => false;

  public enum SelectionContext
  {
    AddModuleAbove,
    AddModuleBelow,
    ReplaceModule,
  }
}
