﻿// Decompiled with JetBrains decompiler
// Type: TUNING.GAMEPLAYEVENT
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace TUNING;

public class GAMEPLAYEVENT
{
  public class PERIOD
  {
    public const float EVERY_CYCLE = 1f;
    public const float TIER1 = 5f;
    public const float TIER2 = 10f;
    public const float TIER3 = 20f;
    public const float TIER4 = 50f;
    public const float TIER5 = 100f;
    public const float TIER6 = 200f;
    public const float TIER7 = 500f;
    public const float TIER8 = 1000f;
  }

  public class PRIORITY_BOOST
  {
    public const int TIER0 = 1;
    public const int TIER1 = 5;
    public const int TIER2 = 10;
    public const int TIER3 = 20;
    public const int TIER4 = 30;
  }

  public class BASE_PRIORITY
  {
    public const int TIER1 = 0;
    public const int TIER2 = 10;
    public const int TIER3 = 20;
    public const int TIER4 = 30;
  }
}
