// Decompiled with JetBrains decompiler
// Type: Database.PermitRarityExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Database;

public static class PermitRarityExtensions
{
  public static string GetLocStringName(this PermitRarity rarity)
  {
    switch (rarity)
    {
      case PermitRarity.Unknown:
        return (string) UI.PERMIT_RARITY.UNKNOWN;
      case PermitRarity.Universal:
        return (string) UI.PERMIT_RARITY.UNIVERSAL;
      case PermitRarity.Loyalty:
        return (string) UI.PERMIT_RARITY.LOYALTY;
      case PermitRarity.Common:
        return (string) UI.PERMIT_RARITY.COMMON;
      case PermitRarity.Decent:
        return (string) UI.PERMIT_RARITY.DECENT;
      case PermitRarity.Nifty:
        return (string) UI.PERMIT_RARITY.NIFTY;
      case PermitRarity.Splendid:
        return (string) UI.PERMIT_RARITY.SPLENDID;
      default:
        DebugUtil.DevAssert(false, $"Couldn't get name for rarity {rarity}");
        return "-";
    }
  }
}
