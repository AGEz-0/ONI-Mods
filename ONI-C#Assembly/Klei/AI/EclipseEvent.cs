// Decompiled with JetBrains decompiler
// Type: Klei.AI.EclipseEvent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;

#nullable disable
namespace Klei.AI;

public class EclipseEvent : GameplayEvent<EclipseEvent.StatesInstance>
{
  public const string ID = "EclipseEvent";
  public const float duration = 30f;

  public EclipseEvent()
    : base(nameof (EclipseEvent))
  {
    this.title = (string) GAMEPLAY_EVENTS.EVENT_TYPES.ECLIPSE.NAME;
    this.description = (string) GAMEPLAY_EVENTS.EVENT_TYPES.ECLIPSE.DESCRIPTION;
  }

  public override StateMachine.Instance GetSMI(
    GameplayEventManager manager,
    GameplayEventInstance eventInstance)
  {
    return (StateMachine.Instance) new EclipseEvent.StatesInstance(manager, eventInstance, this);
  }

  public class StatesInstance(
    GameplayEventManager master,
    GameplayEventInstance eventInstance,
    EclipseEvent eclipseEvent) : 
    GameplayEventStateMachine<EclipseEvent.States, EclipseEvent.StatesInstance, GameplayEventManager, EclipseEvent>.GameplayEventStateMachineInstance(master, eventInstance, eclipseEvent)
  {
  }

  public class States : 
    GameplayEventStateMachine<EclipseEvent.States, EclipseEvent.StatesInstance, GameplayEventManager, EclipseEvent>
  {
    public GameStateMachine<EclipseEvent.States, EclipseEvent.StatesInstance, GameplayEventManager, object>.State planning;
    public GameStateMachine<EclipseEvent.States, EclipseEvent.StatesInstance, GameplayEventManager, object>.State eclipse;
    public GameStateMachine<EclipseEvent.States, EclipseEvent.StatesInstance, GameplayEventManager, object>.State finished;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.planning;
      this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
      this.planning.GoTo(this.eclipse);
      this.eclipse.ToggleNotification((Func<EclipseEvent.StatesInstance, Notification>) (smi => EventInfoScreen.CreateNotification(this.GenerateEventPopupData(smi)))).Enter((StateMachine<EclipseEvent.States, EclipseEvent.StatesInstance, GameplayEventManager, object>.State.Callback) (smi => TimeOfDay.Instance.SetEclipse(true))).Exit((StateMachine<EclipseEvent.States, EclipseEvent.StatesInstance, GameplayEventManager, object>.State.Callback) (smi => TimeOfDay.Instance.SetEclipse(false))).ScheduleGoTo(30f, (StateMachine.BaseState) this.finished);
      this.finished.ReturnSuccess();
    }

    public override EventInfoData GenerateEventPopupData(EclipseEvent.StatesInstance smi)
    {
      return new EventInfoData(smi.gameplayEvent.title, smi.gameplayEvent.description, smi.gameplayEvent.animFileName)
      {
        location = (string) GAMEPLAY_EVENTS.LOCATIONS.SUN,
        whenDescription = (string) GAMEPLAY_EVENTS.TIMES.NOW
      };
    }
  }
}
