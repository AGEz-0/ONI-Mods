// Decompiled with JetBrains decompiler
// Type: EventSystem2Syntax.NewExample
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace EventSystem2Syntax;

internal class NewExample : KMonoBehaviour2
{
  protected override void OnPrefabInit()
  {
    this.Subscribe<NewExample, NewExample.ObjectDestroyedEvent>(new Action<NewExample, NewExample.ObjectDestroyedEvent>(NewExample.OnObjectDestroyed));
    this.Trigger<NewExample.ObjectDestroyedEvent>(new NewExample.ObjectDestroyedEvent()
    {
      parameter = false
    });
  }

  private static void OnObjectDestroyed(NewExample example, NewExample.ObjectDestroyedEvent evt)
  {
  }

  private struct ObjectDestroyedEvent : IEventData
  {
    public bool parameter;
  }
}
