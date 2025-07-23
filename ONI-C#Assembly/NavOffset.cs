// Decompiled with JetBrains decompiler
// Type: NavOffset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public struct NavOffset
{
  public NavType navType;
  public CellOffset offset;

  public NavOffset(NavType nav_type, int x, int y)
  {
    this.navType = nav_type;
    this.offset.x = x;
    this.offset.y = y;
  }
}
