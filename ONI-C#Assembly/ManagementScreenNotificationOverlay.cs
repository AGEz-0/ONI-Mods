// Decompiled with JetBrains decompiler
// Type: ManagementScreenNotificationOverlay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ManagementScreenNotificationOverlay : KMonoBehaviour
{
  public Action currentMenu;
  public NotificationAlertBar alertBarPrefab;
  public RectTransform alertContainer;
  private List<NotificationAlertBar> alertBars = new List<NotificationAlertBar>();

  protected void OnEnable()
  {
  }

  protected override void OnDisable()
  {
  }

  private NotificationAlertBar CreateAlertBar(ManagementMenuNotification notification)
  {
    NotificationAlertBar alertBar = Util.KInstantiateUI<NotificationAlertBar>(this.alertBarPrefab.gameObject, this.alertContainer.gameObject);
    alertBar.Init(notification);
    alertBar.gameObject.SetActive(true);
    return alertBar;
  }

  private void NotificationsChanged()
  {
  }
}
