// Decompiled with JetBrains decompiler
// Type: Face
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class Face : Resource
{
  public HashedString hash;
  public HashedString headFXHash;
  private const string SYMBOL_PREFIX = "headfx_";

  public Face(string id, string headFXSymbol = null)
    : base(id)
  {
    this.hash = new HashedString(id);
    this.headFXHash = (HashedString) headFXSymbol;
  }
}
