// Decompiled with JetBrains decompiler
// Type: Database.CollectedSpaceArtifacts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class CollectedSpaceArtifacts : VictoryColonyAchievementRequirement
{
  private const int REQUIRED_ARTIFACT_COUNT = 10;

  public override string GetProgress(bool complete)
  {
    return ((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.COLLECT_SPACE_ARTIFACTS).Replace("{collectedCount}", this.GetStudiedSpaceArtifactCount().ToString()).Replace("{neededCount}", 10.ToString());
  }

  public override string Description() => this.GetProgress(this.Success());

  public override bool Success() => ArtifactSelector.Instance.AnalyzedSpaceArtifactCount >= 10;

  private int GetStudiedSpaceArtifactCount()
  {
    return ArtifactSelector.Instance.AnalyzedSpaceArtifactCount;
  }

  public override string Name()
  {
    return ((string) COLONY_ACHIEVEMENTS.STUDY_ARTIFACTS.REQUIREMENTS.STUDY_SPACE_ARTIFACTS).Replace("{artifactCount}", 10.ToString());
  }
}
