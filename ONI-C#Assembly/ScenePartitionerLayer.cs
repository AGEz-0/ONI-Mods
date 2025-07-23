// Decompiled with JetBrains decompiler
// Type: ScenePartitionerLayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
public class ScenePartitionerLayer
{
  public HashedString name;
  public int layer;
  public Action<int, object> OnEvent;

  public ScenePartitionerLayer(HashedString name, int layer)
  {
    this.name = name;
    this.layer = layer;
  }
}
