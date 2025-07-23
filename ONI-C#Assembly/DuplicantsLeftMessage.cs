// Decompiled with JetBrains decompiler
// Type: DuplicantsLeftMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class DuplicantsLeftMessage : Message
{
  public override string GetSound() => "";

  public override string GetTitle() => (string) MISC.NOTIFICATIONS.DUPLICANTABSORBED.NAME;

  public override string GetMessageBody()
  {
    return (string) MISC.NOTIFICATIONS.DUPLICANTABSORBED.MESSAGEBODY;
  }

  public override string GetTooltip() => (string) MISC.NOTIFICATIONS.DUPLICANTABSORBED.TOOLTIP;
}
