// Decompiled with JetBrains decompiler
// Type: ScheduleScreenColumnEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class ScheduleScreenColumnEntry : 
  MonoBehaviour,
  IPointerEnterHandler,
  IEventSystemHandler,
  IPointerDownHandler
{
  public Image image;
  public System.Action onLeftClick;

  public void OnPointerEnter(PointerEventData event_data) => this.RunCallbacks();

  private void RunCallbacks()
  {
    if (!Input.GetMouseButton(0) || this.onLeftClick == null)
      return;
    this.onLeftClick();
  }

  public void OnPointerDown(PointerEventData event_data) => this.RunCallbacks();
}
