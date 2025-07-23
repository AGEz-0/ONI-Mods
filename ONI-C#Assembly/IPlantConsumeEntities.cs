// Decompiled with JetBrains decompiler
// Type: IPlantConsumeEntities
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public interface IPlantConsumeEntities
{
  string GetConsumableEntitiesCategoryName();

  string GetRequirementText();

  List<KPrefabID> GetPrefabsOfPossiblePrey();

  string[] GetFormattedPossiblePreyList();

  bool IsEntityEdible(GameObject entity);

  string GetConsumedEntityName();

  bool AreEntitiesConsumptionRequirementsSatisfied();
}
