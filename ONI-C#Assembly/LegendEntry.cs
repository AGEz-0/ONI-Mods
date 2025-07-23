// Decompiled with JetBrains decompiler
// Type: LegendEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class LegendEntry
{
  public string name;
  public string desc;
  public string desc_arg;
  public Color colour;
  public Sprite sprite;
  public bool displaySprite;

  public LegendEntry(
    string name,
    string desc,
    Color colour,
    string desc_arg = null,
    Sprite sprite = null,
    bool displaySprite = true)
  {
    this.name = name;
    this.desc = desc;
    this.colour = colour;
    this.desc_arg = desc_arg;
    this.sprite = (Object) sprite == (Object) null ? Assets.instance.LegendColourBox : sprite;
    this.displaySprite = displaySprite;
  }
}
