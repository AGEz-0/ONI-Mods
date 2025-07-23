// Decompiled with JetBrains decompiler
// Type: GameplayEvent`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public abstract class GameplayEvent<StateMachineInstanceType> : GameplayEvent where StateMachineInstanceType : StateMachine.Instance
{
  public GameplayEvent(
    string id,
    int priority = 0,
    int importance = 0,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
    : base(id, priority, importance, requiredDlcIds, forbiddenDlcIds)
  {
  }
}
