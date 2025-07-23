// Decompiled with JetBrains decompiler
// Type: RoomTypeCategory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class RoomTypeCategory : Resource
{
  public string colorName { get; private set; }

  public string icon { get; private set; }

  public RoomTypeCategory(string id, string name, string colorName, string icon)
    : base(id, name)
  {
    this.colorName = colorName;
    this.icon = icon;
  }
}
