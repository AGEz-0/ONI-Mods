// Decompiled with JetBrains decompiler
// Type: Klei.CustomSettings.CustomMixingSettingsConfigs
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
namespace Klei.CustomSettings;

public static class CustomMixingSettingsConfigs
{
  public static SettingConfig DLC2Mixing = (SettingConfig) new DlcMixingSettingConfig("DLC2_ID", (string) UI.DLC2.NAME, (string) UI.DLC2.MIXING_TOOLTIP, required_content: DlcManager.DLC2, dlcIdFrom: "DLC2_ID");
  public static SettingConfig DLC3Mixing = (SettingConfig) new DlcMixingSettingConfig("DLC3_ID", (string) UI.DLC3.NAME, (string) UI.DLC3.MIXING_TOOLTIP, required_content: DlcManager.DLC3, dlcIdFrom: "DLC3_ID");
  public static SettingConfig DLC4Mixing = (SettingConfig) new DlcMixingSettingConfig("DLC4_ID", (string) UI.DLC4.NAME, (string) UI.DLC4.MIXING_TOOLTIP, required_content: DlcManager.DLC4, dlcIdFrom: "DLC4_ID");
  public static SettingConfig CeresAsteroidMixing = (SettingConfig) new WorldMixingSettingConfig(nameof (CeresAsteroidMixing), "dlc2::worldMixing/CeresMixingSettings", DlcManager.DLC2, "DLC2_ID");
  public static SettingConfig PrehistoricAsteroidMixing = (SettingConfig) new WorldMixingSettingConfig(nameof (PrehistoricAsteroidMixing), "dlc4::worldMixing/PrehistoricMixingSettings", DlcManager.DLC4, "DLC4_ID");
  public static SettingConfig IceCavesMixing = (SettingConfig) new SubworldMixingSettingConfig(nameof (IceCavesMixing), "dlc2::subworldMixing/IceCavesMixingSettings", DlcManager.DLC2, "DLC2_ID");
  public static SettingConfig CarrotQuarryMixing = (SettingConfig) new SubworldMixingSettingConfig(nameof (CarrotQuarryMixing), "dlc2::subworldMixing/CarrotQuarryMixingSettings", DlcManager.DLC2, "DLC2_ID");
  public static SettingConfig SugarWoodsMixing = (SettingConfig) new SubworldMixingSettingConfig(nameof (SugarWoodsMixing), "dlc2::subworldMixing/SugarWoodsMixingSettings", DlcManager.DLC2, "DLC2_ID");
  public static SettingConfig GardenMixing = (SettingConfig) new SubworldMixingSettingConfig(nameof (GardenMixing), "dlc4::subworldMixing/GardenMixingSettings", DlcManager.DLC4, "DLC4_ID");
  public static SettingConfig RaptorMixing = (SettingConfig) new SubworldMixingSettingConfig(nameof (RaptorMixing), "dlc4::subworldMixing/RaptorMixingSettings", DlcManager.DLC4, "DLC4_ID");
  public static SettingConfig WetlandsMixing = (SettingConfig) new SubworldMixingSettingConfig(nameof (WetlandsMixing), "dlc4::subworldMixing/WetlandsMixingSettings", DlcManager.DLC4, "DLC4_ID");
}
