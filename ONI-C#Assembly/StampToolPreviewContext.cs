// Decompiled with JetBrains decompiler
// Type: StampToolPreviewContext
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

#nullable disable
public class StampToolPreviewContext
{
  public Transform previewParent;
  public InterfaceTool tool;
  public TemplateContainer stampTemplate;
  public System.Action frameAfterSetupFn;
  public Action<int> refreshFn;
  public System.Action onPlaceFn;
  public Action<string> onErrorChangeFn;
  public System.Action cleanupFn;
}
