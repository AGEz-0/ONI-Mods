﻿// Decompiled with JetBrains decompiler
// Type: ProcGenGame.GameSpawnData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.CustomSettings;
using KSerialization;
using System.Collections.Generic;
using TemplateClasses;
using UnityEngine;

#nullable disable
namespace ProcGenGame;

[SerializationConfig(MemberSerialization.OptOut)]
public class GameSpawnData
{
  public Vector2I baseStartPos;
  public List<Prefab> buildings = new List<Prefab>();
  public List<Prefab> pickupables = new List<Prefab>();
  public List<Prefab> elementalOres = new List<Prefab>();
  public List<Prefab> otherEntities = new List<Prefab>();
  public List<Tag> discoveredResources = new List<Tag>();
  public List<KeyValuePair<Vector2I, bool>> preventFoWReveal = new List<KeyValuePair<Vector2I, bool>>();

  public void AddRange(IEnumerable<KeyValuePair<int, string>> newItems)
  {
    foreach (KeyValuePair<int, string> newItem in newItems)
    {
      Vector2I xy = Grid.CellToXY(newItem.Key);
      this.otherEntities.Add(new Prefab(newItem.Value, Prefab.Type.Other, xy.x, xy.y, (SimHashes) 0));
    }
  }

  public void AddTemplate(
    TemplateContainer template,
    Vector2I position,
    ref Dictionary<int, int> claimedCells)
  {
    int cell1 = Grid.XYToCell(position.x, position.y);
    bool flag = true;
    if (DlcManager.IsExpansion1Active() && (Object) CustomGameSettings.Instance != (Object) null)
      flag = CustomGameSettings.Instance.GetCurrentQualitySetting(CustomGameSettingConfigs.Teleporters).id == "Enabled";
    if (template.buildings != null)
    {
      foreach (Prefab building in template.buildings)
      {
        if (!claimedCells.ContainsKey(Grid.OffsetCell(cell1, building.location_x, building.location_y)) && (flag || !this.IsWarpTeleporter(building)))
          this.buildings.Add(building.Clone(position));
      }
    }
    if (template.pickupables != null)
    {
      foreach (Prefab pickupable in template.pickupables)
      {
        if (!claimedCells.ContainsKey(Grid.OffsetCell(cell1, pickupable.location_x, pickupable.location_y)))
          this.pickupables.Add(pickupable.Clone(position));
      }
    }
    if (template.elementalOres != null)
    {
      foreach (Prefab elementalOre in template.elementalOres)
      {
        if (!claimedCells.ContainsKey(Grid.OffsetCell(cell1, elementalOre.location_x, elementalOre.location_y)))
          this.elementalOres.Add(elementalOre.Clone(position));
      }
    }
    if (template.otherEntities != null)
    {
      foreach (Prefab otherEntity in template.otherEntities)
      {
        if (!claimedCells.ContainsKey(Grid.OffsetCell(cell1, otherEntity.location_x, otherEntity.location_y)) && (flag || !this.IsWarpTeleporter(otherEntity)))
          this.otherEntities.Add(otherEntity.Clone(position));
      }
    }
    if (template.cells != null)
    {
      for (int index = 0; index < template.cells.Count; ++index)
      {
        int cell2 = Grid.XYToCell(position.x + template.cells[index].location_x, position.y + template.cells[index].location_y);
        if (!claimedCells.ContainsKey(cell2))
        {
          claimedCells[cell2] = 1;
          this.preventFoWReveal.Add(new KeyValuePair<Vector2I, bool>(new Vector2I(position.x + template.cells[index].location_x, position.y + template.cells[index].location_y), template.cells[index].preventFoWReveal));
        }
        else
          ++claimedCells[cell2];
      }
    }
    if (template.info == null || template.info.discover_tags == null)
      return;
    foreach (Tag discoverTag in template.info.discover_tags)
      this.discoveredResources.Add(discoverTag);
  }

  private bool IsWarpTeleporter(Prefab prefab)
  {
    return prefab.id == "WarpPortal" || prefab.id == WarpReceiverConfig.ID || prefab.id == "WarpConduitSender" || prefab.id == "WarpConduitReceiver";
  }
}
