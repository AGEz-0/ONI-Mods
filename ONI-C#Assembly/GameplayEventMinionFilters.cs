﻿// Decompiled with JetBrains decompiler
// Type: GameplayEventMinionFilters
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class GameplayEventMinionFilters
{
  private static GameplayEventMinionFilters _instance;

  public static GameplayEventMinionFilters Instance
  {
    get
    {
      if (GameplayEventMinionFilters._instance == null)
        GameplayEventMinionFilters._instance = new GameplayEventMinionFilters();
      return GameplayEventMinionFilters._instance;
    }
  }

  public GameplayEventMinionFilter HasMasteredSkill(Skill skill)
  {
    return new GameplayEventMinionFilter()
    {
      filter = (GameplayEventMinionFilter.FilterFn) (minion => minion.GetComponent<MinionResume>().HasMasteredSkill(skill.Id)),
      id = nameof (HasMasteredSkill)
    };
  }

  public GameplayEventMinionFilter HasSkillAptitude(Skill skill)
  {
    return new GameplayEventMinionFilter()
    {
      filter = (GameplayEventMinionFilter.FilterFn) (minion => minion.GetComponent<MinionResume>().HasSkillAptitude(skill)),
      id = nameof (HasSkillAptitude)
    };
  }

  public GameplayEventMinionFilter HasChoreGroupPriorityOrHigher(
    ChoreGroup choreGroup,
    int priority)
  {
    return new GameplayEventMinionFilter()
    {
      filter = (GameplayEventMinionFilter.FilterFn) (minion =>
      {
        ChoreConsumer component = minion.GetComponent<ChoreConsumer>();
        return !component.IsChoreGroupDisabled(choreGroup) && component.GetPersonalPriority(choreGroup) >= priority;
      }),
      id = nameof (HasChoreGroupPriorityOrHigher)
    };
  }

  public GameplayEventMinionFilter AgeRange(float min = 0.0f, float max = float.PositiveInfinity)
  {
    return new GameplayEventMinionFilter()
    {
      filter = (GameplayEventMinionFilter.FilterFn) (minion => (double) minion.arrivalTime >= (double) min && (double) minion.arrivalTime <= (double) max),
      id = nameof (AgeRange)
    };
  }

  public GameplayEventMinionFilter PriorityIn()
  {
    return new GameplayEventMinionFilter()
    {
      filter = (GameplayEventMinionFilter.FilterFn) (minion => true),
      id = nameof (PriorityIn)
    };
  }

  public GameplayEventMinionFilter Not(GameplayEventMinionFilter filter)
  {
    return new GameplayEventMinionFilter()
    {
      filter = (GameplayEventMinionFilter.FilterFn) (minion => !filter.filter(minion)),
      id = $"Not[{filter.id}]"
    };
  }

  public GameplayEventMinionFilter Or(
    GameplayEventMinionFilter precondition1,
    GameplayEventMinionFilter precondition2)
  {
    return new GameplayEventMinionFilter()
    {
      filter = (GameplayEventMinionFilter.FilterFn) (minion => precondition1.filter(minion) || precondition2.filter(minion)),
      id = $"[{precondition1.id}]-OR-[{precondition2.id}]"
    };
  }
}
