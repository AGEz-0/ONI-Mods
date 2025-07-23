﻿// Decompiled with JetBrains decompiler
// Type: SetNavOrientationOnSpawnMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class SetNavOrientationOnSpawnMonitor : 
  GameStateMachine<SetNavOrientationOnSpawnMonitor, SetNavOrientationOnSpawnMonitor.Instance, IStateMachineTarget, SetNavOrientationOnSpawnMonitor.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    this.serializable = StateMachine.SerializeType.ParamsOnly;
    default_state = (StateMachine.BaseState) this.root;
  }

  public class Def : StateMachine.BaseDef
  {
  }

  public new class Instance : 
    GameStateMachine<SetNavOrientationOnSpawnMonitor, SetNavOrientationOnSpawnMonitor.Instance, IStateMachineTarget, SetNavOrientationOnSpawnMonitor.Def>.GameInstance
  {
    public Instance(IStateMachineTarget master, SetNavOrientationOnSpawnMonitor.Def def)
      : base(master, def)
    {
      this.Subscribe(1119167081, new System.Action<object>(this.SetSpawnOrientation));
    }

    public void SetSpawnOrientation(object o)
    {
      int cell = Grid.PosToCell((StateMachine.Instance) this);
      if (!Grid.IsValidCell(cell))
        return;
      int num1 = Grid.CellAbove(cell);
      int num2 = Grid.CellBelow(cell);
      if ((!Grid.IsValidCell(num1) || !Grid.Solid[num1] ? 0 : (!Grid.IsValidCell(num2) ? 1 : (!Grid.Solid[num2] ? 1 : 0))) == 0)
        return;
      this.gameObject.GetComponent<Navigator>().CurrentNavType = NavType.Ceiling;
    }

    protected override void OnCleanUp()
    {
      this.Unsubscribe(1119167081, new System.Action<object>(this.SetSpawnOrientation));
      base.OnCleanUp();
    }
  }
}
