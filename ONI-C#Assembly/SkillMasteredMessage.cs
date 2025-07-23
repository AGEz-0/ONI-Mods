// Decompiled with JetBrains decompiler
// Type: SkillMasteredMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;

#nullable disable
public class SkillMasteredMessage : Message
{
  [Serialize]
  private string minionName;

  public SkillMasteredMessage()
  {
  }

  public SkillMasteredMessage(MinionResume resume) => this.minionName = resume.GetProperName();

  public override string GetSound() => "AI_Notification_ResearchComplete";

  public override string GetMessageBody()
  {
    Debug.Assert(this.minionName != null);
    string str = string.Format((string) MISC.NOTIFICATIONS.SKILL_POINT_EARNED.LINE, (object) this.minionName);
    return string.Format((string) MISC.NOTIFICATIONS.SKILL_POINT_EARNED.MESSAGEBODY, (object) str);
  }

  public override string GetTitle()
  {
    return MISC.NOTIFICATIONS.SKILL_POINT_EARNED.NAME.Replace("{Duplicant}", this.minionName);
  }

  public override string GetTooltip()
  {
    return MISC.NOTIFICATIONS.SKILL_POINT_EARNED.TOOLTIP.Replace("{Duplicant}", this.minionName);
  }

  public override bool IsValid() => this.minionName != null;
}
