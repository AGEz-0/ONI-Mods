// Decompiled with JetBrains decompiler
// Type: EventSystem2Syntax.KMonoBehaviour2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace EventSystem2Syntax;

internal class KMonoBehaviour2
{
  protected virtual void OnPrefabInit()
  {
  }

  public void Subscribe(int evt, Action<object> cb)
  {
  }

  public void Trigger(int evt, object data)
  {
  }

  public void Subscribe<ListenerType, EventType>(Action<ListenerType, EventType> cb) where EventType : IEventData
  {
  }

  public void Trigger<EventType>(EventType evt) where EventType : IEventData
  {
  }
}
