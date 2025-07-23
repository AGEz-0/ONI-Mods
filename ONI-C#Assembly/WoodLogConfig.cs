// Decompiled with JetBrains decompiler
// Type: WoodLogConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class WoodLogConfig : IOreConfig
{
  public const string ID = "WoodLog";
  public const float C02MassEmissionWhenBurned = 0.142f;
  public const float HeatWhenBurned = 7500f;
  public const float EnergyWhenBurned = 250f;
  public static readonly Tag TAG = TagManager.Create("WoodLog");

  public SimHashes ElementID => SimHashes.WoodLog;

  public GameObject CreatePrefab()
  {
    GameObject solidOreEntity = EntityTemplates.CreateSolidOreEntity(this.ElementID);
    KPrefabID component = solidOreEntity.GetComponent<KPrefabID>();
    component.prefabInitFn += new KPrefabID.PrefabFn(this.OnInit);
    component.prefabSpawnFn += new KPrefabID.PrefabFn(this.OnSpawn);
    component.RemoveTag(GameTags.HideFromSpawnTool);
    return solidOreEntity;
  }

  public void OnInit(GameObject inst)
  {
    PrimaryElement component = inst.GetComponent<PrimaryElement>();
    component.SetElement(this.ElementID);
    Element element = component.Element;
  }

  public void OnSpawn(GameObject inst)
  {
    inst.GetComponent<PrimaryElement>().SetElement(this.ElementID);
  }
}
