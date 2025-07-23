// Decompiled with JetBrains decompiler
// Type: TUNING.STRESS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
namespace TUNING;

public class STRESS
{
  public static float ACTING_OUT_RESET = 60f;
  public static float VOMIT_AMOUNT = 0.900000036f;
  public static float TEARS_RATE = 0.0400000028f;
  public static int BANSHEE_WAIL_RADIUS = 8;

  public class SHOCKER
  {
    public static int SHOCK_RADIUS = 4;
    public static float DAMAGE_RATE = 2.5f;
    public static float POWER_CONSUMPTION_RATE = 2000f;
    public static float FAKE_POWER_CONSUMPTION_RATE = STRESS.SHOCKER.POWER_CONSUMPTION_RATE * 0.25f;
    public static float MAX_POWER_USE = 120000f;
  }
}
