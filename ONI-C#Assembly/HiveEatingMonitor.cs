// Decompiled with JetBrains decompiler
// Type: HiveEatingMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class HiveEatingMonitor : 
  GameStateMachine<HiveEatingMonitor, HiveEatingMonitor.Instance, IStateMachineTarget, HiveEatingMonitor.Def>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.ToggleBehaviour(GameTags.Creatures.WantsToEat, new StateMachine<HiveEatingMonitor, HiveEatingMonitor.Instance, IStateMachineTarget, HiveEatingMonitor.Def>.Transition.ConditionCallback(HiveEatingMonitor.ShouldEat));
  }

  public static bool ShouldEat(HiveEatingMonitor.Instance smi)
  {
    return (Object) smi.storage.FindFirst(smi.def.consumedOre) != (Object) null;
  }

  public class Def : StateMachine.BaseDef
  {
    public Tag consumedOre;
  }

  public new class Instance(IStateMachineTarget master, HiveEatingMonitor.Def def) : 
    GameStateMachine<HiveEatingMonitor, HiveEatingMonitor.Instance, IStateMachineTarget, HiveEatingMonitor.Def>.GameInstance(master, def)
  {
    [MyCmpReq]
    public Storage storage;
  }
}
