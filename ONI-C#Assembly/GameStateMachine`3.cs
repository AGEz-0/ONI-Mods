// Decompiled with JetBrains decompiler
// Type: GameStateMachine`3
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType> : 
  GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, object>
  where StateMachineType : GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, object>
  where StateMachineInstanceType : GameStateMachine<StateMachineType, StateMachineInstanceType, MasterType, object>.GameInstance
  where MasterType : IStateMachineTarget
{
}
