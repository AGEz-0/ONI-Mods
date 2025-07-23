// Decompiled with JetBrains decompiler
// Type: ModularLaunchpadPortLiquidConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class ModularLaunchpadPortLiquidConfig : IBuildingConfig
{
  public const string ID = "ModularLaunchpadPortLiquid";

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    return BaseModularLaunchpadPortConfig.CreateBaseLaunchpadPort("ModularLaunchpadPortLiquid", "conduit_port_liquid_loader_kanim", ConduitType.Liquid, true, height: 2);
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    BaseModularLaunchpadPortConfig.ConfigureBuildingTemplate(go, prefab_tag, ConduitType.Liquid, 10f, true);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    BaseModularLaunchpadPortConfig.DoPostConfigureComplete(go, true);
  }
}
