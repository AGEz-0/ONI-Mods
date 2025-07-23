﻿// Decompiled with JetBrains decompiler
// Type: WarpConduitSenderConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using TUNING;
using UnityEngine;

#nullable disable
public class WarpConduitSenderConfig : IBuildingConfig
{
  public const string ID = "WarpConduitSender";
  private ConduitPortInfo gasInputPort = new ConduitPortInfo(ConduitType.Gas, new CellOffset(0, 1));
  private ConduitPortInfo liquidInputPort = new ConduitPortInfo(ConduitType.Liquid, new CellOffset(1, 1));
  private ConduitPortInfo solidInputPort = new ConduitPortInfo(ConduitType.Solid, new CellOffset(2, 1));

  public override string[] GetRequiredDlcIds() => DlcManager.EXPANSION1;

  public override BuildingDef CreateBuildingDef()
  {
    float[] tieR4 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
    string[] allMetals = MATERIALS.ALL_METALS;
    EffectorValues tieR5 = NOISE_POLLUTION.NOISY.TIER5;
    EffectorValues none = BUILDINGS.DECOR.NONE;
    EffectorValues noise = tieR5;
    BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("WarpConduitSender", 4, 3, "warp_conduit_sender_kanim", 250, 30f, tieR4, allMetals, 1600f, BuildLocationRule.OnFloor, none, noise);
    buildingDef.Floodable = false;
    buildingDef.Overheatable = false;
    buildingDef.ShowInBuildMenu = false;
    buildingDef.DefaultAnimState = "idle";
    buildingDef.CanMove = true;
    buildingDef.Invincible = true;
    return buildingDef;
  }

  private void AttachPorts(GameObject go)
  {
    go.AddComponent<ConduitSecondaryInput>().portInfo = this.liquidInputPort;
    go.AddComponent<ConduitSecondaryInput>().portInfo = this.gasInputPort;
    go.AddComponent<ConduitSecondaryInput>().portInfo = this.solidInputPort;
  }

  public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
  {
    Prioritizable.AddRef(go);
    go.GetComponent<KPrefabID>().AddTag(GameTags.Gravitas);
    PrimaryElement component = go.GetComponent<PrimaryElement>();
    component.SetElement(SimHashes.Unobtanium);
    component.Temperature = 294.15f;
    WarpConduitSender warpConduitSender = go.AddOrGet<WarpConduitSender>();
    warpConduitSender.liquidPortInfo = this.liquidInputPort;
    warpConduitSender.gasPortInfo = this.gasInputPort;
    warpConduitSender.solidPortInfo = this.solidInputPort;
    warpConduitSender.gasStorage = go.AddComponent<Storage>();
    warpConduitSender.gasStorage.showInUI = false;
    warpConduitSender.gasStorage.capacityKg = 1f;
    warpConduitSender.liquidStorage = go.AddComponent<Storage>();
    warpConduitSender.liquidStorage.showInUI = false;
    warpConduitSender.liquidStorage.capacityKg = 10f;
    warpConduitSender.solidStorage = go.AddComponent<Storage>();
    warpConduitSender.solidStorage.showInUI = false;
    warpConduitSender.solidStorage.capacityKg = 100f;
    Activatable activatable = go.AddOrGet<Activatable>();
    activatable.synchronizeAnims = true;
    activatable.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_interacts_warp_conduit_sender_kanim")
    };
    activatable.workAnims = new HashedString[2]
    {
      (HashedString) "sending_pre",
      (HashedString) "sending_loop"
    };
    activatable.workingPstComplete = new HashedString[1]
    {
      (HashedString) "sending_pst"
    };
    activatable.workingPstFailed = new HashedString[1]
    {
      (HashedString) "sending_pre"
    };
    activatable.SetWorkTime(30f);
  }

  public override void DoPostConfigureComplete(GameObject go)
  {
    go.AddOrGet<BuildingCellVisualizer>();
    go.GetComponent<Deconstructable>().SetAllowDeconstruction(false);
    go.GetComponent<Activatable>().requiredSkillPerk = Db.Get().SkillPerks.CanStudyWorldObjects.Id;
  }

  public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
  {
    base.DoPostConfigurePreview(def, go);
    go.AddOrGet<BuildingCellVisualizer>();
    this.AttachPorts(go);
  }

  public override void DoPostConfigureUnderConstruction(GameObject go)
  {
    base.DoPostConfigureUnderConstruction(go);
    go.AddOrGet<BuildingCellVisualizer>();
    this.AttachPorts(go);
  }
}
