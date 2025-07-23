// Decompiled with JetBrains decompiler
// Type: ManagementMenuNotificationDisplayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class ManagementMenuNotificationDisplayer : NotificationDisplayer
{
  public List<ManagementMenuNotification> displayedManagementMenuNotifications { get; private set; }

  public event System.Action onNotificationsChanged;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.displayedManagementMenuNotifications = new List<ManagementMenuNotification>();
  }

  public void NotificationWasViewed(ManagementMenuNotification notification)
  {
    this.onNotificationsChanged();
  }

  protected override void OnNotificationAdded(Notification notification)
  {
    this.displayedManagementMenuNotifications.Add(notification as ManagementMenuNotification);
    this.onNotificationsChanged();
  }

  protected override void OnNotificationRemoved(Notification notification)
  {
    this.displayedManagementMenuNotifications.Remove(notification as ManagementMenuNotification);
    this.onNotificationsChanged();
  }

  protected override bool ShouldDisplayNotification(Notification notification)
  {
    return notification is ManagementMenuNotification;
  }

  public List<ManagementMenuNotification> GetNotificationsForAction(Action hotKey)
  {
    List<ManagementMenuNotification> notificationsForAction = new List<ManagementMenuNotification>();
    foreach (ManagementMenuNotification menuNotification in this.displayedManagementMenuNotifications)
    {
      if (menuNotification.targetMenu == hotKey)
        notificationsForAction.Add(menuNotification);
    }
    return notificationsForAction;
  }
}
