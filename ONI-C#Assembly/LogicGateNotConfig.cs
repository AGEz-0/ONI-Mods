// Decompiled with JetBrains decompiler
// Type: LogicGateNotConfig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class LogicGateNotConfig : LogicGateBaseConfig
{
  public const string ID = "LogicGateNOT";

  protected override LogicGateBase.Op GetLogicOp() => LogicGateBase.Op.Not;

  protected override CellOffset[] InputPortOffsets
  {
    get => new CellOffset[1]{ CellOffset.none };
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
        name = (string) BUILDINGS.PREFABS.LOGICGATENOT.OUTPUT_NAME,
        active = (string) BUILDINGS.PREFABS.LOGICGATENOT.OUTPUT_ACTIVE,
        inactive = (string) BUILDINGS.PREFABS.LOGICGATENOT.OUTPUT_INACTIVE
      }
    };
  }

  public override BuildingDef CreateBuildingDef()
  {
    return this.CreateBuildingDef("LogicGateNOT", "logic_not_kanim", height: 1);
  }
}
