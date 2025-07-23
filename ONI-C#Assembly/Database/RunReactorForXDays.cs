// Decompiled with JetBrains decompiler
// Type: Database.RunReactorForXDays
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public class RunReactorForXDays : ColonyAchievementRequirement
{
  private int numCycles;

  public RunReactorForXDays(int numCycles) => this.numCycles = numCycles;

  public override string GetProgress(bool complete)
  {
    int num = 0;
    foreach (Reactor reactor in Components.NuclearReactors.Items)
    {
      if (reactor.numCyclesRunning > num)
        num = reactor.numCyclesRunning;
    }
    return string.Format((string) COLONY_ACHIEVEMENTS.MISC_REQUIREMENTS.STATUS.RUN_A_REACTOR, (object) (complete ? this.numCycles : num), (object) this.numCycles);
  }

  public override bool Success()
  {
    foreach (Reactor reactor in Components.NuclearReactors.Items)
    {
      if (reactor.numCyclesRunning >= this.numCycles)
        return true;
    }
    return false;
  }
}
