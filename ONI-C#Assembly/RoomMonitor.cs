// Decompiled with JetBrains decompiler
// Type: RoomMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

#nullable disable
public class RoomMonitor : GameStateMachine<RoomMonitor, RoomMonitor.Instance>
{
  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.EventHandler(GameHashes.PathAdvanced, new StateMachine<RoomMonitor, RoomMonitor.Instance, IStateMachineTarget, object>.State.Callback(RoomMonitor.UpdateRoomType));
  }

  private static void UpdateRoomType(RoomMonitor.Instance smi)
  {
    Room roomOfGameObject = Game.Instance.roomProber.GetRoomOfGameObject(smi.master.gameObject);
    if (roomOfGameObject == smi.currentRoom)
      return;
    smi.currentRoom = roomOfGameObject;
    roomOfGameObject?.cavity.OnEnter((object) smi.master.gameObject);
  }

  public new class Instance(IStateMachineTarget master) : 
    GameStateMachine<RoomMonitor, RoomMonitor.Instance, IStateMachineTarget, object>.GameInstance(master)
  {
    public Room currentRoom;
  }
}
