// Decompiled with JetBrains decompiler
// Type: CritterEmoteMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;
using System.Collections.Generic;

#nullable disable
public class CritterEmoteMonitor : 
  GameStateMachine<CritterEmoteMonitor, CritterEmoteMonitor.Instance>
{
  public GameStateMachine<CritterEmoteMonitor, CritterEmoteMonitor.Instance, IStateMachineTarget, object>.State satisfied;
  public GameStateMachine<CritterEmoteMonitor, CritterEmoteMonitor.Instance, IStateMachineTarget, object>.State ready;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.satisfied;
    this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
    this.satisfied.ScheduleGoTo((Func<CritterEmoteMonitor.Instance, float>) (smi => UnityEngine.Random.Range(75f, 150f)), (StateMachine.BaseState) this.ready);
    this.ready.Enter(new StateMachine<CritterEmoteMonitor, CritterEmoteMonitor.Instance, IStateMachineTarget, object>.State.Callback(CritterEmoteMonitor.CreateChore)).ToggleUrge(Db.Get().Urges.Emote).EventHandler(GameHashes.BeginChore, (GameStateMachine<CritterEmoteMonitor, CritterEmoteMonitor.Instance, IStateMachineTarget, object>.GameEvent.Callback) ((smi, o) => smi.OnStartChore(o)));
  }

  public static void CreateChore(CritterEmoteMonitor.Instance smi)
  {
    EmoteChore emoteChore = new EmoteChore((IStateMachineTarget) smi.GetComponent<ChoreProvider>(), Db.Get().ChoreTypes.Emote, smi.emotes.GetRandom<Emote>());
  }

  public new class Instance : 
    GameStateMachine<CritterEmoteMonitor, CritterEmoteMonitor.Instance, IStateMachineTarget, object>.GameInstance
  {
    public List<Emote> emotes;

    public Instance(IStateMachineTarget master, List<Emote> emotes)
      : base(master)
    {
      this.emotes = emotes;
    }

    public void OnStartChore(object o)
    {
      if (!((Chore) o).SatisfiesUrge(Db.Get().Urges.Emote))
        return;
      this.GoTo((StateMachine.BaseState) this.sm.satisfied);
    }
  }
}
