// Decompiled with JetBrains decompiler
// Type: NavigationTactics
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public static class NavigationTactics
{
  public static NavTactic ReduceTravelDistance = new NavTactic(0, 0, pathCostPenalty: 4);
  public static NavTactic Range_2_AvoidOverlaps = new NavTactic(2, 6, 12);
  public static NavTactic Range_3_ProhibitOverlap = new NavTactic(3, 6, 9999);
  public static NavTactic FetchDronePickup = new NavTactic(1, 0, 0, 0, 1, 0, 1, 1);
}
