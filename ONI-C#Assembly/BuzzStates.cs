// Decompiled with JetBrains decompiler
// Type: BuzzStates
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;

#nullable disable
public class BuzzStates : 
  GameStateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>
{
  private StateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.IntParameter numMoves;
  private BuzzStates.BuzzingStates buzz;
  public GameStateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State idle;
  public GameStateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State move;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.idle;
    GameStateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State state = this.root.Exit("StopNavigator", (StateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State.Callback) (smi => smi.GetComponent<Navigator>().Stop()));
    string name = (string) CREATURES.STATUSITEMS.IDLE.NAME;
    string tooltip = (string) CREATURES.STATUSITEMS.IDLE.TOOLTIP;
    StatusItemCategory main = Db.Get().StatusItemCategories.Main;
    HashedString render_overlay = new HashedString();
    StatusItemCategory category = main;
    state.ToggleStatusItem(name, tooltip, render_overlay: render_overlay, category: category).ToggleTag(GameTags.Idle);
    this.idle.Enter(new StateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State.Callback(this.PlayIdle)).ToggleScheduleCallback("DoBuzz", (Func<BuzzStates.Instance, float>) (smi => (float) UnityEngine.Random.Range(3, 10)), (System.Action<BuzzStates.Instance>) (smi =>
    {
      this.numMoves.Set(UnityEngine.Random.Range(4, 6), smi);
      smi.GoTo((StateMachine.BaseState) this.buzz.move);
    }));
    this.buzz.ParamTransition<int>((StateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.Parameter<int>) this.numMoves, this.idle, (StateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.Parameter<int>.Callback) ((smi, p) => p <= 0));
    this.buzz.move.Enter(new StateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State.Callback(this.MoveToNewCell)).EventTransition(GameHashes.DestinationReached, this.buzz.pause).EventTransition(GameHashes.NavigationFailed, this.buzz.pause);
    this.buzz.pause.Enter((StateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State.Callback) (smi =>
    {
      this.numMoves.Set(this.numMoves.Get(smi) - 1, smi);
      smi.GoTo((StateMachine.BaseState) this.buzz.move);
    }));
  }

  public void MoveToNewCell(BuzzStates.Instance smi)
  {
    Navigator component = smi.GetComponent<Navigator>();
    BuzzStates.MoveCellQuery query = new BuzzStates.MoveCellQuery(component.CurrentNavType);
    query.allowLiquid = smi.gameObject.HasTag(GameTags.Amphibious);
    component.RunQuery((PathFinderQuery) query);
    component.GoTo(query.GetResultCell());
  }

  public void PlayIdle(BuzzStates.Instance smi)
  {
    KAnimControllerBase component1 = smi.GetComponent<KAnimControllerBase>();
    Navigator component2 = smi.GetComponent<Navigator>();
    NavType nav_type = component2.CurrentNavType;
    if (smi.GetComponent<Facing>().GetFacing())
      nav_type = NavGrid.MirrorNavType(nav_type);
    if (smi.def.customIdleAnim != null)
    {
      HashedString invalid = HashedString.Invalid;
      HashedString anim_name = smi.def.customIdleAnim(smi, ref invalid);
      if (anim_name != HashedString.Invalid)
      {
        if (invalid != HashedString.Invalid)
          component1.Play(invalid);
        component1.Queue(anim_name, KAnim.PlayMode.Loop);
        return;
      }
    }
    HashedString idleAnim = component2.NavGrid.GetIdleAnim(nav_type);
    component1.Play(idleAnim, KAnim.PlayMode.Loop);
  }

  public class Def : StateMachine.BaseDef
  {
    public BuzzStates.Def.IdleAnimCallback customIdleAnim;

    public delegate HashedString IdleAnimCallback(
      BuzzStates.Instance smi,
      ref HashedString pre_anim);
  }

  public new class Instance(Chore<BuzzStates.Instance> chore, BuzzStates.Def def) : 
    GameStateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.GameInstance((IStateMachineTarget) chore, def)
  {
  }

  public class BuzzingStates : 
    GameStateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State
  {
    public GameStateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State move;
    public GameStateMachine<BuzzStates, BuzzStates.Instance, IStateMachineTarget, BuzzStates.Def>.State pause;
  }

  public class MoveCellQuery : PathFinderQuery
  {
    private NavType navType;
    private int targetCell = Grid.InvalidCell;
    private int maxIterations;

    public bool allowLiquid { get; set; }

    public MoveCellQuery(NavType navType)
    {
      this.navType = navType;
      this.maxIterations = UnityEngine.Random.Range(5, 25);
    }

    public override bool IsMatch(int cell, int parent_cell, int cost)
    {
      if (!Grid.IsValidCell(cell))
        return false;
      bool flag1 = this.navType != NavType.Swim;
      bool flag2 = this.navType == NavType.Swim || this.allowLiquid;
      bool flag3 = Grid.IsSubstantialLiquid(cell);
      if (flag3 && !flag2 || !flag3 && !flag1)
        return false;
      this.targetCell = cell;
      return --this.maxIterations <= 0;
    }

    public override int GetResultCell() => this.targetCell;
  }
}
