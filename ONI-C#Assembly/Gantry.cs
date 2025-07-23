﻿// Decompiled with JetBrains decompiler
// Type: Gantry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;

#nullable disable
public class Gantry : Switch
{
  public static readonly HashedString PORT_ID = (HashedString) nameof (Gantry);
  [MyCmpReq]
  private Building building;
  [MyCmpReq]
  private FakeFloorAdder fakeFloorAdder;
  private Gantry.Instance smi;
  private static StatusItem infoStatusItem;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    if (Gantry.infoStatusItem == null)
    {
      Gantry.infoStatusItem = new StatusItem("GantryAutomationInfo", "BUILDING", "", StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID);
      Gantry.infoStatusItem.resolveStringCallback = new Func<string, object, string>(Gantry.ResolveInfoStatusItemString);
    }
    this.GetComponent<KAnimControllerBase>().PlaySpeedMultiplier = 0.5f;
    this.smi = new Gantry.Instance(this, this.IsSwitchedOn);
    this.smi.StartSM();
    this.GetComponent<KSelectable>().ToggleStatusItem(Gantry.infoStatusItem, true, (object) this.smi);
  }

  protected override void OnCleanUp()
  {
    if (this.smi != null)
      this.smi.StopSM("cleanup");
    base.OnCleanUp();
  }

  public void SetWalkable(bool active) => this.fakeFloorAdder.SetFloor(active);

  protected override void Toggle()
  {
    base.Toggle();
    this.smi.SetSwitchState(this.switchedOn);
  }

  protected override void OnRefreshUserMenu(object data)
  {
    if (this.smi.IsAutomated())
      return;
    base.OnRefreshUserMenu(data);
  }

  protected override void UpdateSwitchStatus()
  {
  }

  private static string ResolveInfoStatusItemString(string format_str, object data)
  {
    Gantry.Instance instance = (Gantry.Instance) data;
    return string.Format((string) (instance.IsAutomated() ? BUILDING.STATUSITEMS.GANTRY.AUTOMATION_CONTROL : BUILDING.STATUSITEMS.GANTRY.MANUAL_CONTROL), (object) (string) (instance.IsExtended() ? BUILDING.STATUSITEMS.GANTRY.EXTENDED : BUILDING.STATUSITEMS.GANTRY.RETRACTED));
  }

  public class States : GameStateMachine<Gantry.States, Gantry.Instance, Gantry>
  {
    public GameStateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State retracted_pre;
    public GameStateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State retracted;
    public GameStateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State extended_pre;
    public GameStateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State extended;
    public StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.BoolParameter should_extend;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.extended;
      this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
      this.retracted_pre.Enter((StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State.Callback) (smi => smi.SetActive(true))).Exit((StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State.Callback) (smi => smi.SetActive(false))).PlayAnim("off_pre").OnAnimQueueComplete(this.retracted);
      this.retracted.PlayAnim("off").ParamTransition<bool>((StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.Parameter<bool>) this.should_extend, this.extended_pre, GameStateMachine<Gantry.States, Gantry.Instance, Gantry, object>.IsTrue);
      this.extended_pre.Enter((StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State.Callback) (smi => smi.SetActive(true))).Exit((StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State.Callback) (smi => smi.SetActive(false))).PlayAnim("on_pre").OnAnimQueueComplete(this.extended);
      this.extended.Enter((StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State.Callback) (smi => smi.master.SetWalkable(true))).Exit((StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.State.Callback) (smi => smi.master.SetWalkable(false))).PlayAnim("on").ParamTransition<bool>((StateMachine<Gantry.States, Gantry.Instance, Gantry, object>.Parameter<bool>) this.should_extend, this.retracted_pre, GameStateMachine<Gantry.States, Gantry.Instance, Gantry, object>.IsFalse).ToggleTag(GameTags.GantryExtended);
    }
  }

  public class Instance : 
    GameStateMachine<Gantry.States, Gantry.Instance, Gantry, object>.GameInstance
  {
    private Operational operational;
    public LogicPorts logic;
    public bool logic_on = true;
    private bool manual_on;

    public Instance(Gantry master, bool manual_start_state)
      : base(master)
    {
      this.manual_on = manual_start_state;
      this.operational = this.GetComponent<Operational>();
      this.logic = this.GetComponent<LogicPorts>();
      this.Subscribe(-592767678, new Action<object>(this.OnOperationalChanged));
      this.Subscribe(-801688580, new Action<object>(this.OnLogicValueChanged));
      this.smi.sm.should_extend.Set(true, this.smi);
    }

    public bool IsAutomated() => this.logic.IsPortConnected(Gantry.PORT_ID);

    public bool IsExtended() => !this.IsAutomated() ? this.manual_on : this.logic_on;

    public void SetSwitchState(bool on)
    {
      this.manual_on = on;
      this.UpdateShouldExtend();
    }

    public void SetActive(bool active)
    {
      this.operational.SetActive(this.operational.IsOperational & active);
    }

    private void OnOperationalChanged(object data) => this.UpdateShouldExtend();

    private void OnLogicValueChanged(object data)
    {
      LogicValueChanged logicValueChanged = (LogicValueChanged) data;
      if (logicValueChanged.portID != Gantry.PORT_ID)
        return;
      this.logic_on = LogicCircuitNetwork.IsBitActive(0, logicValueChanged.newValue);
      this.UpdateShouldExtend();
    }

    private void UpdateShouldExtend()
    {
      if (!this.operational.IsOperational)
        return;
      if (this.IsAutomated())
        this.smi.sm.should_extend.Set(this.logic_on, this.smi);
      else
        this.smi.sm.should_extend.Set(this.manual_on, this.smi);
    }
  }
}
