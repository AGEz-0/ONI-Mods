// Decompiled with JetBrains decompiler
// Type: Klei.TerrainCellLogged
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using ProcGenGame;
using System.Collections.Generic;
using VoronoiTree;

#nullable disable
namespace Klei;

public class TerrainCellLogged : TerrainCell
{
  public TerrainCellLogged()
  {
  }

  public TerrainCellLogged(ProcGen.Map.Cell node, Diagram.Site site, Dictionary<Tag, int> distancesToTags)
    : base(node, site, distancesToTags)
  {
  }

  public override void LogInfo(string evt, string param, float value)
  {
  }
}
