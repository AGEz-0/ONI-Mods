// Decompiled with JetBrains decompiler
// Type: MorbRoverMakerKeepsake
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
public class MorbRoverMakerKeepsake : 
  GameStateMachine<MorbRoverMakerKeepsake, MorbRoverMakerKeepsake.Instance, IStateMachineTarget, MorbRoverMakerKeepsake.Def>
{
  public const string SILENT_ANIMATION_NAME = "silent";
  public const string TALKING_ANIMATION_NAME = "idle";
  public GameStateMachine<MorbRoverMakerKeepsake, MorbRoverMakerKeepsake.Instance, IStateMachineTarget, MorbRoverMakerKeepsake.Def>.State silent;
  public GameStateMachine<MorbRoverMakerKeepsake, MorbRoverMakerKeepsake.Instance, IStateMachineTarget, MorbRoverMakerKeepsake.Def>.State talking;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    this.serializable = StateMachine.SerializeType.ParamsOnly;
    default_state = (StateMachine.BaseState) this.silent;
    this.silent.PlayAnim("silent").Enter(new StateMachine<MorbRoverMakerKeepsake, MorbRoverMakerKeepsake.Instance, IStateMachineTarget, MorbRoverMakerKeepsake.Def>.State.Callback(MorbRoverMakerKeepsake.CalculateNextActivationTime)).Update(new System.Action<MorbRoverMakerKeepsake.Instance, float>(MorbRoverMakerKeepsake.TimerUpdate));
    this.talking.PlayAnim("idle").OnAnimQueueComplete(this.silent);
  }

  public static void CalculateNextActivationTime(MorbRoverMakerKeepsake.Instance smi)
  {
    smi.CalculateNextActivationTime();
  }

  public static void TimerUpdate(MorbRoverMakerKeepsake.Instance smi, float dt)
  {
    if ((double) GameClock.Instance.GetTime() <= (double) smi.NextActivationTime)
      return;
    smi.GoTo((StateMachine.BaseState) smi.sm.talking);
  }

  public class Def : StateMachine.BaseDef
  {
    public Vector2 OperationalRandomnessRange = new Vector2(120f, 600f);
  }

  public new class Instance(IStateMachineTarget master, MorbRoverMakerKeepsake.Def def) : 
    GameStateMachine<MorbRoverMakerKeepsake, MorbRoverMakerKeepsake.Instance, IStateMachineTarget, MorbRoverMakerKeepsake.Def>.GameInstance(master, def)
  {
    public float NextActivationTime = -1f;

    public void CalculateNextActivationTime()
    {
      double time = (double) GameClock.Instance.GetTime();
      this.NextActivationTime = UnityEngine.Random.Range((float) time + this.def.OperationalRandomnessRange.x, (float) time + this.def.OperationalRandomnessRange.y);
    }
  }
}
