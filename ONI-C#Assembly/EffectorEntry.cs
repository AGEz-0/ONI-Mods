// Decompiled with JetBrains decompiler
// Type: EffectorEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
internal struct EffectorEntry(string name, float value)
{
  public string name = name;
  public int count = 1;
  public float value = value;

  public override string ToString()
  {
    string str = "";
    if (this.count > 1)
      str = string.Format((string) UI.OVERLAYS.DECOR.COUNT, (object) this.count);
    return string.Format((string) UI.OVERLAYS.DECOR.ENTRY, (object) GameUtil.GetFormattedDecor(this.value), (object) this.name, (object) str);
  }
}
