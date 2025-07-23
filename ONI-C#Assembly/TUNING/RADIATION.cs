﻿// Decompiled with JetBrains decompiler
// Type: TUNING.RADIATION
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace TUNING;

public class RADIATION
{
  public const float GERM_RAD_SCALE = 0.01f;
  public const float STANDARD_DAILY_RECOVERY = 100f;
  public const float EXTRA_VOMIT_RECOVERY = 20f;
  public const float REACT_THRESHOLD = 133f;

  public class STANDARD_EMITTER
  {
    public const float STEADY_PULSE_RATE = 0.2f;
    public const float DOUBLE_SPEED_PULSE_RATE = 0.1f;
    public const float RADIUS_SCALE = 1f;
  }

  public class RADIATION_PER_SECOND
  {
    public const float TRIVIAL = 60f;
    public const float VERY_LOW = 120f;
    public const float LOW = 240f;
    public const float MODERATE = 600f;
    public const float HIGH = 1800f;
    public const float VERY_HIGH = 4800f;
    public const int EXTREME = 9600;
  }

  public class RADIATION_CONSTANT_RADS_PER_CYCLE
  {
    public const float LESS_THAN_TRIVIAL = 60f;
    public const float TRIVIAL = 120f;
    public const float VERY_LOW = 240f;
    public const float LOW = 480f;
    public const float MODERATE = 1200f;
    public const float MODERATE_PLUS = 2400f;
    public const float HIGH = 3600f;
    public const float VERY_HIGH = 8400f;
    public const int EXTREME = 16800;
  }
}
