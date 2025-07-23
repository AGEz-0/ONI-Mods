﻿// Decompiled with JetBrains decompiler
// Type: LogicGateAndConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class LogicGateAndConfig : LogicGateBaseConfig
{
  public const string ID = "LogicGateAND";

  protected override LogicGateBase.Op GetLogicOp() => LogicGateBase.Op.And;

  protected override CellOffset[] InputPortOffsets
  {
    get
    {
      return new CellOffset[2]
      {
        CellOffset.none,
        new CellOffset(0, 1)
      };
    }
  }

  protected override CellOffset[] OutputPortOffsets
  {
    get => new CellOffset[1]{ new CellOffset(1, 0) };
  }

  protected override CellOffset[] ControlPortOffsets => (CellOffset[]) null;

  protected override LogicGate.LogicGateDescriptions GetDescriptions()
  {
    return new LogicGate.LogicGateDescriptions()
    {
      outputOne = new LogicGate.LogicGateDescriptions.Description()
      {
        name = (string) BUILDINGS.PREFABS.LOGICGATEAND.OUTPUT_NAME,
        active = (string) BUILDINGS.PREFABS.LOGICGATEAND.OUTPUT_ACTIVE,
        inactive = (string) BUILDINGS.PREFABS.LOGICGATEAND.OUTPUT_INACTIVE
      }
    };
  }

  public override BuildingDef CreateBuildingDef()
  {
    return this.CreateBuildingDef("LogicGateAND", "logic_and_kanim");
  }
}
