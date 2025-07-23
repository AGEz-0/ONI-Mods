// Decompiled with JetBrains decompiler
// Type: MouthAnimation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MouthAnimation : IEntityConfig
{
  public static string ID = nameof (MouthAnimation);

  public GameObject CreatePrefab()
  {
    GameObject entity = EntityTemplates.CreateEntity(MouthAnimation.ID, MouthAnimation.ID, false);
    entity.AddOrGet<KBatchedAnimController>().AnimFiles = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_mouth_flap_kanim")
    };
    return entity;
  }

  public void OnPrefabInit(GameObject go)
  {
  }

  public void OnSpawn(GameObject go)
  {
  }
}
