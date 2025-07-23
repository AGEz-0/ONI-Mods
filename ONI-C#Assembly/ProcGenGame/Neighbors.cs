// Decompiled with JetBrains decompiler
// Type: ProcGenGame.Neighbors
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;

#nullable disable
namespace ProcGenGame;

[SerializationConfig(MemberSerialization.OptOut)]
public struct Neighbors
{
  public TerrainCell n0;
  public TerrainCell n1;

  public Neighbors(TerrainCell a, TerrainCell b)
  {
    Debug.Assert(a != null && b != null, (object) "NULL Neighbor");
    this.n0 = a;
    this.n1 = b;
  }
}
