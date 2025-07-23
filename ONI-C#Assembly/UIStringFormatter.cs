// Decompiled with JetBrains decompiler
// Type: UIStringFormatter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public class UIStringFormatter
{
  private List<UIStringFormatter.Entry> entries = new List<UIStringFormatter.Entry>();

  private struct Entry
  {
    public string format;
    public string key;
    public string value;
    public string result;
  }
}
