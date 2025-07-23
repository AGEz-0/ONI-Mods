﻿// Decompiled with JetBrains decompiler
// Type: GravityComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public struct GravityComponent
{
  public Transform transform;
  public Vector2 velocity;
  public float elapsedTime;
  public System.Action onLanded;
  public bool landOnFakeFloors;
  public bool mayLeaveWorld;
  public Vector2 extents;
  public KCollider2D collider2D;

  public GravityComponent(
    Transform transform,
    System.Action on_landed,
    Vector2 initial_velocity,
    bool land_on_fake_floors,
    bool mayLeaveWorld)
  {
    this.transform = transform;
    this.elapsedTime = 0.0f;
    this.velocity = initial_velocity;
    this.onLanded = on_landed;
    this.landOnFakeFloors = land_on_fake_floors;
    this.mayLeaveWorld = mayLeaveWorld;
    this.collider2D = transform.GetComponent<KCollider2D>();
    this.extents = GravityComponent.GetExtents(this.collider2D);
  }

  public static float GetGroundOffset(KCollider2D collider)
  {
    return (UnityEngine.Object) collider != (UnityEngine.Object) null ? collider.bounds.extents.y - collider.offset.y : 0.0f;
  }

  public static float GetGroundOffset(GravityComponent gravityComponent)
  {
    return (UnityEngine.Object) gravityComponent.collider2D != (UnityEngine.Object) null ? gravityComponent.extents.y - gravityComponent.collider2D.offset.y : 0.0f;
  }

  public static Vector2 GetExtents(KCollider2D collider)
  {
    return (UnityEngine.Object) collider != (UnityEngine.Object) null ? (Vector2) collider.bounds.extents : Vector2.zero;
  }

  public static Vector2 GetOffset(KCollider2D collider)
  {
    return (UnityEngine.Object) collider != (UnityEngine.Object) null ? collider.offset : Vector2.zero;
  }
}
