// Decompiled with JetBrains decompiler
// Type: CodexUnlockedMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class CodexUnlockedMessage : Message
{
  private string unlockMessage;
  private string lockId;

  public CodexUnlockedMessage()
  {
  }

  public CodexUnlockedMessage(string lock_id, string unlock_message)
  {
    this.lockId = lock_id;
    this.unlockMessage = unlock_message;
  }

  public string GetLockId() => this.lockId;

  public override string GetSound() => "AI_Notification_ResearchComplete";

  public override string GetMessageBody()
  {
    return UI.CODEX.CODEX_DISCOVERED_MESSAGE.BODY.Replace("{codex}", this.unlockMessage);
  }

  public override string GetTitle() => (string) UI.CODEX.CODEX_DISCOVERED_MESSAGE.TITLE;

  public override string GetTooltip() => this.GetMessageBody();

  public override bool IsValid() => true;
}
