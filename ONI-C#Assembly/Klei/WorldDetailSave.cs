// Decompiled with JetBrains decompiler
// Type: Klei.WorldDetailSave
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Delaunay.Geo;
using KSerialization;
using ProcGen;
using ProcGenGame;
using System.Collections.Generic;

#nullable disable
namespace Klei;

public class WorldDetailSave
{
  public List<WorldDetailSave.OverworldCell> overworldCells;
  public int globalWorldSeed;
  public int globalWorldLayoutSeed;
  public int globalTerrainSeed;
  public int globalNoiseSeed;

  public WorldDetailSave() => this.overworldCells = new List<WorldDetailSave.OverworldCell>();

  [SerializationConfig(MemberSerialization.OptOut)]
  public class OverworldCell
  {
    public Polygon poly;
    public TagSet tags;
    public SubWorld.ZoneType zoneType;

    public OverworldCell()
    {
    }

    public OverworldCell(SubWorld.ZoneType zoneType, TerrainCell tc)
    {
      this.poly = tc.poly;
      this.tags = tc.node.tags;
      this.zoneType = zoneType;
    }
  }
}
