﻿// Decompiled with JetBrains decompiler
// Type: SelectMarker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SelectMarker")]
public class SelectMarker : KMonoBehaviour
{
  public float animationOffset = 0.1f;
  private Transform targetTransform;

  public void SetTargetTransform(Transform target_transform)
  {
    this.targetTransform = target_transform;
    this.LateUpdate();
  }

  private void LateUpdate()
  {
    if ((Object) this.targetTransform == (Object) null)
    {
      this.gameObject.SetActive(false);
    }
    else
    {
      Vector3 position = this.targetTransform.GetPosition();
      KCollider2D component = this.targetTransform.GetComponent<KCollider2D>();
      if ((Object) component != (Object) null)
      {
        ref Vector3 local1 = ref position;
        Bounds bounds = component.bounds;
        double x = (double) bounds.center.x;
        local1.x = (float) x;
        ref Vector3 local2 = ref position;
        bounds = component.bounds;
        double y = (double) bounds.center.y;
        bounds = component.bounds;
        double num1 = (double) bounds.size.y / 2.0;
        double num2 = y + num1 + 0.10000000149011612;
        local2.y = (float) num2;
      }
      else
        position.y += 2f;
      Vector3 vector3 = new Vector3(0.0f, (Mathf.Sin(Time.unscaledTime * 4f) + 1f) * this.animationOffset, 0.0f);
      this.transform.SetPosition(position + vector3);
    }
  }
}
