// Decompiled with JetBrains decompiler
// Type: DewDripConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DewDripConfig : IEntityConfig, IHasDlcRestrictions
{
  public static string ID = "DewDrip";
  private AttributeModifier decorModifier = new AttributeModifier("Decor", 0.1f, (string) ITEMS.INDUSTRIAL_PRODUCTS.DEWDRIP.NAME, true);

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity(DewDripConfig.ID, (string) ITEMS.INDUSTRIAL_PRODUCTS.DEWDRIP.NAME, (string) ITEMS.INDUSTRIAL_PRODUCTS.DEWDRIP.DESC, 1f, true, Assets.GetAnim((HashedString) "brackorb_kanim"), "object", Grid.SceneLayer.BuildingBack, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.45f, true, additionalTags: new List<Tag>()
    {
      GameTags.IndustrialIngredient
    });
    looseEntity.AddOrGet<EntitySplitter>();
    looseEntity.AddOrGet<PrefabAttributeModifiers>().AddAttributeDescriptor(this.decorModifier);
    return looseEntity;
  }

  public void OnPrefabInit(GameObject inst)
  {
  }

  public void OnSpawn(GameObject inst)
  {
  }
}
