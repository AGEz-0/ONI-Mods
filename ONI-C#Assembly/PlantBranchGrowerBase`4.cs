// Decompiled with JetBrains decompiler
// Type: PlantBranchGrowerBase`4
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class PlantBranchGrowerBase<StateMachineType, StateMachineInstanceType, MasterType, DefType> : 
  GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, DefType>
  where StateMachineType : GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, DefType>
  where StateMachineInstanceType : GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, DefType>.GameInstance
  where MasterType : IStateMachineTarget
  where DefType : PlantBranchGrowerBase<StateMachineType, StateMachineInstanceType, MasterType, DefType>.PlantBranchGrowerBaseDef
{
  public class PlantBranchGrowerBaseDef : StateMachine.BaseDef, IPlantBranchGrower
  {
    public int MAX_BRANCH_COUNT;
    public string BRANCH_PREFAB_NAME;

    public string GetPlantBranchPrefabName() => this.BRANCH_PREFAB_NAME;

    public int GetMaxBranchCount() => this.MAX_BRANCH_COUNT;
  }
}
