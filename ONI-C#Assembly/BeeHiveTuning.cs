// Decompiled with JetBrains decompiler
// Type: BeeHiveTuning
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class BeeHiveTuning
{
  public static float ORE_DELIVERY_AMOUNT = 1f;
  public static float KG_ORE_EATEN_PER_CYCLE = BeeHiveTuning.ORE_DELIVERY_AMOUNT * 10f;
  public static float STANDARD_CALORIES_PER_CYCLE = 1500000f;
  public static float STANDARD_STARVE_CYCLES = 30f;
  public static float STANDARD_STOMACH_SIZE = BeeHiveTuning.STANDARD_CALORIES_PER_CYCLE * BeeHiveTuning.STANDARD_STARVE_CYCLES;
  public static float CALORIES_PER_KG_OF_ORE = BeeHiveTuning.STANDARD_CALORIES_PER_CYCLE / BeeHiveTuning.KG_ORE_EATEN_PER_CYCLE;
  public static float POOP_CONVERSTION_RATE = 0.9f;
  public static Tag CONSUMED_ORE = SimHashes.UraniumOre.CreateTag();
  public static Tag PRODUCED_ORE = SimHashes.EnrichedUranium.CreateTag();
  public static float HIVE_GROWTH_TIME = 2f;
  public static float WASTE_DROPPED_ON_DEATH = 5f;
  public static int GERMS_DROPPED_ON_DEATH = 10000;
}
