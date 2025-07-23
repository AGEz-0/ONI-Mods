﻿// Decompiled with JetBrains decompiler
// Type: LightBugBabyConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
[EntityConfigOrder(2)]
public class LightBugBabyConfig : IEntityConfig
{
  public const string ID = "LightBugBaby";

  public GameObject CreatePrefab()
  {
    GameObject lightBug = LightBugConfig.CreateLightBug("LightBugBaby", (string) CREATURES.SPECIES.LIGHTBUG.BABY.NAME, (string) CREATURES.SPECIES.LIGHTBUG.BABY.DESC, "baby_lightbug_kanim", true);
    EntityTemplates.ExtendEntityToBeingABaby(lightBug, (Tag) "LightBug");
    lightBug.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.LightSource);
    return lightBug;
  }

  public void OnPrefabInit(GameObject prefab)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
