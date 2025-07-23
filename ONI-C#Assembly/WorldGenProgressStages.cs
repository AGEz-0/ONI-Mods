﻿// Decompiled with JetBrains decompiler
// Type: WorldGenProgressStages
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
public static class WorldGenProgressStages
{
  public static KeyValuePair<WorldGenProgressStages.Stages, float>[] StageWeights = new KeyValuePair<WorldGenProgressStages.Stages, float>[19]
  {
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.Failure, 0.0f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.SetupNoise, 0.01f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.GenerateNoise, 1f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.GenerateSolarSystem, 0.01f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.WorldLayout, 1f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.CompleteLayout, 0.01f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.NoiseMapBuilder, 9f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.ClearingLevel, 0.5f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.Processing, 1f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.Borders, 0.1f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.ProcessRivers, 0.1f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.ConvertCellsToEdges, 0.0f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.DrawWorldBorder, 0.2f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.PlaceTemplates, 5f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.SettleSim, 6f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.DetectNaturalCavities, 6f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.PlacingCreatures, 0.01f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.Complete, 0.0f),
    new KeyValuePair<WorldGenProgressStages.Stages, float>(WorldGenProgressStages.Stages.NumberOfStages, 0.0f)
  };

  public enum Stages
  {
    Failure,
    SetupNoise,
    GenerateNoise,
    GenerateSolarSystem,
    WorldLayout,
    CompleteLayout,
    NoiseMapBuilder,
    ClearingLevel,
    Processing,
    Borders,
    ProcessRivers,
    ConvertCellsToEdges,
    DrawWorldBorder,
    PlaceTemplates,
    SettleSim,
    DetectNaturalCavities,
    PlacingCreatures,
    Complete,
    NumberOfStages,
  }
}
