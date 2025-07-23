// Decompiled with JetBrains decompiler
// Type: EventBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class EventBase : Resource
{
  public int hash;

  public EventBase(string id)
    : base(id, id)
  {
    this.hash = Hash.SDBMLower(id);
  }

  public virtual string GetDescription(EventInstanceBase ev) => "";
}
