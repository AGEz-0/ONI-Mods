// Decompiled with JetBrains decompiler
// Type: AchievementEarnedMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class AchievementEarnedMessage : Message
{
  public override bool ShowDialog() => false;

  public override string GetSound() => "AI_Notification_ResearchComplete";

  public override string GetMessageBody() => "";

  public override string GetTitle() => (string) MISC.NOTIFICATIONS.COLONY_ACHIEVEMENT_EARNED.NAME;

  public override string GetTooltip()
  {
    return (string) MISC.NOTIFICATIONS.COLONY_ACHIEVEMENT_EARNED.TOOLTIP;
  }

  public override bool IsValid() => true;

  public override void OnClick()
  {
    RetireColonyUtility.SaveColonySummaryData();
    MainMenu.ActivateRetiredColoniesScreenFromData(PauseScreen.Instance.transform.parent.gameObject, RetireColonyUtility.GetCurrentColonyRetiredColonyData());
  }
}
