// Decompiled with JetBrains decompiler
// Type: FeatherFabricConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System.Collections.Generic;
using TUNING;
using UnityEngine;

#nullable disable
public class FeatherFabricConfig : IEntityConfig, IHasDlcRestrictions
{
  public static string ID = "FeatherFabric";
  private AttributeModifier decorModifier = new AttributeModifier("Decor", 0.1f, (string) STRINGS.ITEMS.INDUSTRIAL_PRODUCTS.BASIC_FABRIC.NAME, true);

  public string[] GetRequiredDlcIds() => DlcManager.DLC4;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public GameObject CreatePrefab()
  {
    GameObject looseEntity = EntityTemplates.CreateLooseEntity(FeatherFabricConfig.ID, (string) STRINGS.ITEMS.INDUSTRIAL_PRODUCTS.FEATHER_FABRIC.NAME, (string) STRINGS.ITEMS.INDUSTRIAL_PRODUCTS.FEATHER_FABRIC.DESC, 1f, true, Assets.GetAnim((HashedString) "feather_kanim"), "object", Grid.SceneLayer.BuildingBack, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.45f, true, SORTORDER.BUILDINGELEMENTS + BasicFabricTuning.SORTORDER, additionalTags: new List<Tag>()
    {
      GameTags.IndustrialIngredient,
      GameTags.BuildingFiber
    });
    looseEntity.AddOrGet<EntitySplitter>();
    KBoxCollider2D kboxCollider2D = looseEntity.AddOrGet<KBoxCollider2D>();
    kboxCollider2D.offset = (Vector2) new Vector2f(0.0f, 0.3f);
    kboxCollider2D.size = (Vector2) new Vector2f(0.8f, 0.8f);
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
