// Decompiled with JetBrains decompiler
// Type: Database.BuildALaunchPad
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class BuildALaunchPad : ColonyAchievementRequirement
{
  public override string GetProgress(bool complete)
  {
    return (string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.BUILD_A_LAUNCHPAD;
  }

  public override bool Success()
  {
    foreach (KMonoBehaviour component in Components.LaunchPads.Items)
    {
      WorldContainer myWorld = component.GetMyWorld();
      if (!myWorld.IsStartWorld && Components.WarpReceivers.GetWorldItems(myWorld.id).Count == 0)
        return true;
    }
    return false;
  }
}
