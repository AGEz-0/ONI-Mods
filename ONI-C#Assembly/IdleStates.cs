// Decompiled with JetBrains decompiler
// Type: IdleStates
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class IdleStates : 
  GameStateMachine<IdleStates, IdleStates.Instance, IStateMachineTarget, IdleStates.Def>
{
  private GameStateMachine<IdleStates, IdleStates.Instance, IStateMachineTarget, IdleStates.Def>.State loop;
  private GameStateMachine<IdleStates, IdleStates.Instance, IStateMachineTarget, IdleStates.Def>.State move;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.loop;
    GameStateMachine<IdleStates, IdleStates.Instance, IStateMachineTarget, IdleStates.Def>.State state = this.root.Exit("StopNavigator", (StateMachine<IdleStates, IdleStates.Instance, IStateMachineTarget, IdleStates.Def>.State.Callback) (smi => smi.GetComponent<Navigator>().Stop()));
    string name = (string) CREATURES.STATUSITEMS.IDLE.NAME;
    string tooltip = (string) CREATURES.STATUSITEMS.IDLE.TOOLTIP;
    StatusItemCategory main = Db.Get().StatusItemCategories.Main;
    HashedString render_overlay = new HashedString();
    StatusItemCategory category = main;
    state.ToggleStatusItem(name, tooltip, render_overlay: render_overlay, category: category).ToggleTag(GameTags.Idle);
    this.loop.Enter(new StateMachine<IdleStates, IdleStates.Instance, IStateMachineTarget, IdleStates.Def>.State.Callback(this.PlayIdle)).ToggleScheduleCallback("IdleMove", (Func<IdleStates.Instance, float>) (smi => (float) UnityEngine.Random.Range(3, 10)), (System.Action<IdleStates.Instance>) (smi => smi.GoTo((StateMachine.BaseState) this.move)));
    this.move.Enter(new StateMachine<IdleStates, IdleStates.Instance, IStateMachineTarget, IdleStates.Def>.State.Callback(this.MoveToNewCell)).EventTransition(GameHashes.DestinationReached, this.loop).EventTransition(GameHashes.NavigationFailed, this.loop);
  }

  public void MoveToNewCell(IdleStates.Instance smi)
  {
    if (smi.HasTag(GameTags.StationaryIdling))
    {
      smi.GoTo((StateMachine.BaseState) smi.sm.loop);
    }
    else
    {
      Navigator component = smi.GetComponent<Navigator>();
      IdleStates.MoveCellQuery query = new IdleStates.MoveCellQuery(component.CurrentNavType);
      query.allowLiquid = smi.gameObject.HasTag(GameTags.Amphibious);
      query.submerged = smi.gameObject.HasTag(GameTags.Creatures.Submerged);
      int cell1 = Grid.PosToCell((KMonoBehaviour) component);
      if (component.CurrentNavType == NavType.Hover && CellSelectionObject.IsExposedToSpace(cell1))
      {
        int num = 0;
        int cell2 = cell1;
        for (int index = 0; index < 10; ++index)
        {
          cell2 = Grid.CellBelow(cell2);
          if (Grid.IsValidCell(cell2) && !Grid.IsSolidCell(cell2) && CellSelectionObject.IsExposedToSpace(cell2))
            ++num;
          else
            break;
        }
        query.lowerCellBias = num == 10;
      }
      component.RunQuery((PathFinderQuery) query);
      component.GoTo(query.GetResultCell());
    }
  }

  public void PlayIdle(IdleStates.Instance smi)
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
    public IdleStates.Def.IdleAnimCallback customIdleAnim;
    public PriorityScreen.PriorityClass priorityClass;

    public delegate HashedString IdleAnimCallback(
      IdleStates.Instance smi,
      ref HashedString pre_anim);
  }

  public new class Instance : 
    GameStateMachine<IdleStates, IdleStates.Instance, IStateMachineTarget, IdleStates.Def>.GameInstance
  {
    public Instance(Chore<IdleStates.Instance> chore, IdleStates.Def def)
      : base((IStateMachineTarget) chore, def)
    {
      chore.masterPriority.priority_class = def.priorityClass;
    }
  }

  public class MoveCellQuery : PathFinderQuery
  {
    private NavType navType;
    private int targetCell = Grid.InvalidCell;
    private int maxIterations;

    public bool allowLiquid { get; set; }

    public bool submerged { get; set; }

    public bool lowerCellBias { get; set; }

    public MoveCellQuery(NavType navType)
    {
      this.navType = navType;
      this.maxIterations = UnityEngine.Random.Range(5, 25);
    }

    public override bool IsMatch(int cell, int parent_cell, int cost)
    {
      if (!Grid.IsValidCell(cell))
        return false;
      GameObject gameObject;
      Grid.ObjectLayers[1].TryGetValue(cell, out gameObject);
      if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
      {
        BuildingUnderConstruction component = gameObject.GetComponent<BuildingUnderConstruction>();
        if ((UnityEngine.Object) component != (UnityEngine.Object) null && (component.Def.IsFoundation || component.HasTag(GameTags.NoCreatureIdling)))
          return false;
      }
      bool flag1 = this.submerged || Grid.IsNavigatableLiquid(cell);
      bool flag2 = this.navType != NavType.Swim;
      bool flag3 = this.navType == NavType.Swim || this.allowLiquid;
      if (flag1 && !flag3 || !flag1 && !flag2)
        return false;
      if (this.targetCell == Grid.InvalidCell || !this.lowerCellBias)
      {
        this.targetCell = cell;
      }
      else
      {
        int num = Grid.CellRow(this.targetCell);
        if (Grid.CellRow(cell) < num)
          this.targetCell = cell;
      }
      return --this.maxIterations <= 0;
    }

    public override int GetResultCell() => this.targetCell;
  }
}
