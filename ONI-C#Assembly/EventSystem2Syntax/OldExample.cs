// Decompiled with JetBrains decompiler
// Type: EventSystem2Syntax.OldExample
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace EventSystem2Syntax;

internal class OldExample : KMonoBehaviour2
{
  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.Subscribe(0, new Action<object>(this.OnObjectDestroyed));
    this.Trigger(0, (object) false);
  }

  private void OnObjectDestroyed(object data) => Debug.Log((object) (bool) data);
}
