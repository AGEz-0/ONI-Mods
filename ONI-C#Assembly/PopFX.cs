// Decompiled with JetBrains decompiler
// Type: PopFX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/PopFX")]
public class PopFX : KMonoBehaviour
{
  private float Speed = 2f;
  private Sprite icon;
  private string text;
  private Transform targetTransform;
  private Vector3 offset;
  public Image IconDisplay;
  public LocText TextDisplay;
  public CanvasGroup canvasGroup;
  private Camera uiCamera;
  private float lifetime;
  private float lifeElapsed;
  private bool trackTarget;
  private Vector3 startPos;
  private bool isLive;
  private bool isActiveWorld;

  public void Recycle()
  {
    this.icon = (Sprite) null;
    this.text = "";
    this.targetTransform = (Transform) null;
    this.lifeElapsed = 0.0f;
    this.trackTarget = false;
    this.startPos = Vector3.zero;
    this.IconDisplay.color = Color.white;
    this.TextDisplay.color = Color.white;
    PopFXManager.Instance.RecycleFX(this);
    this.canvasGroup.alpha = 0.0f;
    this.gameObject.SetActive(false);
    this.isLive = false;
    this.isActiveWorld = false;
    Game.Instance.Unsubscribe(1983128072, new Action<object>(this.OnActiveWorldChanged));
  }

  public void Spawn(
    Sprite Icon,
    string Text,
    Transform TargetTransform,
    Vector3 Offset,
    float LifeTime = 1.5f,
    bool TrackTarget = false)
  {
    this.icon = Icon;
    this.text = Text;
    this.targetTransform = TargetTransform;
    this.trackTarget = TrackTarget;
    this.lifetime = LifeTime;
    this.offset = Offset;
    if ((UnityEngine.Object) this.targetTransform != (UnityEngine.Object) null)
    {
      this.startPos = this.targetTransform.GetPosition();
      int y;
      Grid.PosToXY(this.startPos, out int _, out y);
      if (y % 2 != 0)
        this.startPos.x += 0.5f;
    }
    this.TextDisplay.text = this.text;
    this.IconDisplay.sprite = this.icon;
    this.canvasGroup.alpha = 1f;
    this.isLive = true;
    Game.Instance.Subscribe(1983128072, new Action<object>(this.OnActiveWorldChanged));
    this.SetWorldActive(ClusterManager.Instance.activeWorldId);
    this.Update();
  }

  private void OnActiveWorldChanged(object data)
  {
    Tuple<int, int> tuple = (Tuple<int, int>) data;
    if (!this.isLive)
      return;
    this.SetWorldActive(tuple.first);
  }

  private void SetWorldActive(int worldId)
  {
    int cell = Grid.PosToCell(!this.trackTarget || !((UnityEngine.Object) this.targetTransform != (UnityEngine.Object) null) ? this.startPos + this.offset : this.targetTransform.position);
    this.isActiveWorld = !Grid.IsValidCell(cell) || (int) Grid.WorldIdx[cell] == worldId;
  }

  private void Update()
  {
    if (!this.isLive || !PopFXManager.Instance.Ready())
      return;
    this.lifeElapsed += Time.unscaledDeltaTime;
    if ((double) this.lifeElapsed >= (double) this.lifetime)
      this.Recycle();
    if (this.trackTarget && (UnityEngine.Object) this.targetTransform != (UnityEngine.Object) null)
    {
      Vector3 screen = PopFXManager.Instance.WorldToScreen(this.targetTransform.GetPosition() + this.offset + Vector3.up * this.lifeElapsed * (this.Speed * this.lifeElapsed)) with
      {
        z = 0.0f
      };
      this.gameObject.rectTransform().anchoredPosition = (Vector2) screen;
    }
    else
    {
      Vector3 screen = PopFXManager.Instance.WorldToScreen(this.startPos + this.offset + Vector3.up * this.lifeElapsed * (this.Speed * (this.lifeElapsed / 2f))) with
      {
        z = 0.0f
      };
      this.gameObject.rectTransform().anchoredPosition = (Vector2) screen;
    }
    this.canvasGroup.alpha = this.isActiveWorld ? (float) (1.5 * (((double) this.lifetime - (double) this.lifeElapsed) / (double) this.lifetime)) : 0.0f;
  }
}
