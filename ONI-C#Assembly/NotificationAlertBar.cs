// Decompiled with JetBrains decompiler
// Type: NotificationAlertBar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class NotificationAlertBar : KMonoBehaviour
{
  public ManagementMenuNotification notification;
  public KButton thisButton;
  public KImage background;
  public LocText text;
  public ToolTip tooltip;
  public KButton muteButton;
  public List<ColorStyleSetting> alertColorStyle;

  public void Init(ManagementMenuNotification notification)
  {
    this.notification = notification;
    this.thisButton.onClick += new System.Action(this.OnThisButtonClicked);
    this.background.colorStyleSetting = this.alertColorStyle[(int) notification.valence];
    this.background.ApplyColorStyleSetting();
    this.text.text = notification.titleText;
    this.tooltip.SetSimpleTooltip(notification.ToolTip((List<Notification>) null, notification.tooltipData));
    this.muteButton.onClick += new System.Action(this.OnMuteButtonClicked);
  }

  private void OnThisButtonClicked()
  {
    NotificationHighlightController componentInParent = this.GetComponentInParent<NotificationHighlightController>();
    if ((UnityEngine.Object) componentInParent != (UnityEngine.Object) null)
      componentInParent.SetActiveTarget(this.notification);
    else
      this.notification.View();
  }

  private void OnMuteButtonClicked()
  {
  }
}
