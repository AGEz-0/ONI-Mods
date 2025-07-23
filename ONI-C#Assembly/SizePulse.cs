﻿// Decompiled with JetBrains decompiler
// Type: SizePulse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class SizePulse : MonoBehaviour
{
  public System.Action onComplete;
  public Vector2 from = Vector2.one;
  public Vector2 to = Vector2.one;
  public float multiplier = 1.25f;
  public float speed = 1f;
  public bool updateWhenPaused;
  private Vector2 cur;
  private SizePulse.State state;

  private void Start()
  {
    if (this.GetComponents<SizePulse>().Length > 1)
      UnityEngine.Object.Destroy((UnityEngine.Object) this);
    this.from = (Vector2) this.transform.localScale;
    this.cur = this.from;
    this.to = this.from * this.multiplier;
  }

  private void Update()
  {
    float t = (this.updateWhenPaused ? Time.unscaledDeltaTime : Time.deltaTime) * this.speed;
    switch (this.state)
    {
      case SizePulse.State.Up:
        this.cur = Vector2.Lerp(this.cur, this.to, t);
        if ((double) (this.to - this.cur).sqrMagnitude < 9.9999997473787516E-05)
        {
          this.cur = this.to;
          this.state = SizePulse.State.Down;
          break;
        }
        break;
      case SizePulse.State.Down:
        this.cur = Vector2.Lerp(this.cur, this.from, t);
        if ((double) (this.from - this.cur).sqrMagnitude < 9.9999997473787516E-05)
        {
          this.cur = this.from;
          this.state = SizePulse.State.Finished;
          if (this.onComplete != null)
          {
            this.onComplete();
            break;
          }
          break;
        }
        break;
    }
    this.transform.localScale = new Vector3(this.cur.x, this.cur.y, 1f);
  }

  private enum State
  {
    Up,
    Down,
    Finished,
  }
}
