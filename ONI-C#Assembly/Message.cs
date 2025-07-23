// Decompiled with JetBrains decompiler
// Type: Message
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public abstract class Message : ISaveLoadable
{
  public abstract string GetTitle();

  public abstract string GetSound();

  public abstract string GetMessageBody();

  public abstract string GetTooltip();

  public virtual bool ShowDialog() => true;

  public virtual void OnCleanUp()
  {
  }

  public virtual bool IsValid() => true;

  public virtual bool PlayNotificationSound() => true;

  public virtual void OnClick()
  {
  }

  public virtual NotificationType GetMessageType() => NotificationType.Messages;

  public virtual bool ShowDismissButton() => true;
}
