// Decompiled with JetBrains decompiler
// Type: NotificationHighlightTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class NotificationHighlightTarget : KMonoBehaviour
{
  public string targetKey;
  private NotificationHighlightController controller;

  protected void OnEnable()
  {
    this.controller = this.GetComponentInParent<NotificationHighlightController>();
    if (!((Object) this.controller != (Object) null))
      return;
    this.controller.AddTarget(this);
  }

  protected override void OnDisable()
  {
    if (!((Object) this.controller != (Object) null))
      return;
    this.controller.RemoveTarget(this);
  }

  public void View()
  {
    this.GetComponentInParent<NotificationHighlightController>().TargetViewed(this);
  }
}
