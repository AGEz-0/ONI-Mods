﻿// Decompiled with JetBrains decompiler
// Type: Klei.Data
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ProcGen;
using ProcGenGame;
using System.Collections.Generic;
using VoronoiTree;

#nullable disable
namespace Klei;

public class Data
{
  public int globalWorldSeed;
  public int globalWorldLayoutSeed;
  public int globalTerrainSeed;
  public int globalNoiseSeed;
  public int chunkEdgeSize = 32 /*0x20*/;
  public WorldLayout worldLayout;
  public List<TerrainCell> terrainCells;
  public List<TerrainCell> overworldCells;
  public List<ProcGen.River> rivers;
  public GameSpawnData gameSpawnData;
  public Chunk world;
  public Tree voronoiTree;
  public AxialI clusterLocation;

  public Data()
  {
    this.worldLayout = new WorldLayout((WorldGen) null, 0);
    this.terrainCells = new List<TerrainCell>();
    this.overworldCells = new List<TerrainCell>();
    this.rivers = new List<ProcGen.River>();
    this.gameSpawnData = new GameSpawnData();
    this.world = new Chunk();
    this.voronoiTree = new Tree(0);
  }
}
