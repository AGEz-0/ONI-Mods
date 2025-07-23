﻿// Decompiled with JetBrains decompiler
// Type: InstantiateUIPrefabChild
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/InstantiateUIPrefabChild")]
public class InstantiateUIPrefabChild : KMonoBehaviour
{
  public GameObject[] prefabs;
  public bool InstantiateOnAwake = true;
  private bool alreadyInstantiated;
  public bool setAsFirstSibling;

  protected override void OnPrefabInit()
  {
    if (!this.InstantiateOnAwake)
      return;
    this.Instantiate();
  }

  public void Instantiate()
  {
    if (this.alreadyInstantiated)
    {
      Debug.LogWarning((object) (this.gameObject.name + "trying to instantiate UI prefabs multiple times."));
    }
    else
    {
      this.alreadyInstantiated = true;
      foreach (GameObject prefab in this.prefabs)
      {
        if (!((Object) prefab == (Object) null))
        {
          Vector3 anchoredPosition = (Vector3) prefab.rectTransform().anchoredPosition;
          GameObject go = Object.Instantiate<GameObject>(prefab);
          go.transform.SetParent(this.transform);
          go.rectTransform().anchoredPosition = (Vector2) anchoredPosition;
          go.rectTransform().localScale = Vector3.one;
          if (this.setAsFirstSibling)
            go.transform.SetAsFirstSibling();
        }
      }
    }
  }
}
