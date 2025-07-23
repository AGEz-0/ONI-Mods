// Decompiled with JetBrains decompiler
// Type: ModularLaunchpadPortLiquidUnloaderConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ModularLaunchpadPortLiquidUnloaderConfig : IBuildingConfig
{
  public const string ID = "ModularLaunchpadPortLiquidUnloader";

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    return BaseModularLaunchpadPortConfig.CreateBaseLaunchpadPort("ModularLaunchpadPortLiquidUnloader", "conduit_port_liquid_unloader_kanim", ConduitType.Liquid, false);
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    BaseModularLaunchpadPortConfig.ConfigureBuildingTemplate(go, prefab_tag, ConduitType.Liquid, 10f, false);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    BaseModularLaunchpadPortConfig.DoPostConfigureComplete(go, false);
  }
}
