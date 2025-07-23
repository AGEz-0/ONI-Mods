// Decompiled with JetBrains decompiler
// Type: CellEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class CellEvent : EventBase
{
  public string reason;
  public bool isSend;
  public bool enableLogging;

  public CellEvent(string id, string reason, bool is_send, bool enable_logging = true)
    : base(id)
  {
    this.reason = reason;
    this.isSend = is_send;
    this.enableLogging = enable_logging;
  }

  public string GetMessagePrefix() => this.isSend ? ">>>: " : "<<<: ";
}
