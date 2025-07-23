// Decompiled with JetBrains decompiler
// Type: MessageNotification
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MessageNotification : Notification
{
  public Message message;

  private string OnToolTip(List<Notification> notifications, string tooltipText) => tooltipText;

  public MessageNotification(Message m)
    : base(m.GetTitle(), NotificationType.Messages, expires: false, show_dismiss_button: true)
  {
    MessageNotification messageNotification = this;
    this.message = m;
    this.Type = m.GetMessageType();
    this.showDismissButton = m.ShowDismissButton();
    if (!this.message.PlayNotificationSound())
      this.playSound = false;
    this.ToolTip = (Func<List<Notification>, object, string>) ((notifications, data) => messageNotification.OnToolTip(notifications, m.GetTooltip()));
    this.clickFocus = (Transform) null;
  }
}
