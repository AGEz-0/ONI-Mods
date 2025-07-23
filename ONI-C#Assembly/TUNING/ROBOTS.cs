﻿// Decompiled with JetBrains decompiler
// Type: TUNING.ROBOTS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace TUNING;

public class ROBOTS
{
  public class SCOUTBOT
  {
    public static float CARRY_CAPACITY = DUPLICANTSTATS.STANDARD.BaseStats.CARRY_CAPACITY;
    public static readonly float DIGGING = 1f;
    public static readonly float CONSTRUCTION = 1f;
    public static readonly float ATHLETICS = 1f;
    public static readonly float HIT_POINTS = 100f;
    public static readonly float BATTERY_DEPLETION_RATE = 30f;
    public static readonly float BATTERY_CAPACITY = (float) ((double) ROBOTS.SCOUTBOT.BATTERY_DEPLETION_RATE * 10.0 * 600.0);
  }

  public class MORBBOT
  {
    public static float CARRY_CAPACITY = DUPLICANTSTATS.STANDARD.BaseStats.CARRY_CAPACITY * 2f;
    public const float DIGGING = 1f;
    public const float CONSTRUCTION = 1f;
    public const float ATHLETICS = 3f;
    public static readonly float HIT_POINTS = 100f;
    public const float LIFETIME = 6000f;
    public const float BATTERY_DEPLETION_RATE = 30f;
    public const float BATTERY_CAPACITY = 180000f;
    public const float DECONSTRUCTION_WORK_TIME = 10f;
  }

  public class FETCHDRONE
  {
    public static float CARRY_CAPACITY = DUPLICANTSTATS.STANDARD.BaseStats.CARRY_CAPACITY * 2f;
    public static readonly float HIT_POINTS = 100f;
    public const float BATTERY_DEPLETION_RATE = 50f;
  }
}
