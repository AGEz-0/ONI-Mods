// Decompiled with JetBrains decompiler
// Type: INToggleSideScreenControl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public interface INToggleSideScreenControl
{
  string SidescreenTitleKey { get; }

  List<LocString> Options { get; }

  List<LocString> Tooltips { get; }

  string Description { get; }

  int SelectedOption { get; }

  int QueuedOption { get; }

  void QueueSelectedOption(int option);
}
