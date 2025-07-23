// Decompiled with JetBrains decompiler
// Type: EntityPrefabs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/EntityPrefabs")]
public class EntityPrefabs : KMonoBehaviour
{
  public GameObject SelectMarker;
  public GameObject ForegroundLayer;

  public static EntityPrefabs Instance { get; private set; }

  public static void DestroyInstance() => EntityPrefabs.Instance = (EntityPrefabs) null;

  protected override void OnPrefabInit() => EntityPrefabs.Instance = this;
}
