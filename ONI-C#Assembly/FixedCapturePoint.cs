// Decompiled with JetBrains decompiler
// Type: FixedCapturePoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using System;
using UnityEngine;

#nullable disable
public class FixedCapturePoint : 
  GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>
{
  public static readonly Operational.Flag enabledFlag = new Operational.Flag("enabled", Operational.Flag.Type.Requirement);
  private StateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.BoolParameter automated;
  public GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.State unoperational;
  public FixedCapturePoint.OperationalState operational;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.operational;
    this.serializable = StateMachine.SerializeType.Both_DEPRECATED;
    this.unoperational.TagTransition(GameTags.Operational, (GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.State) this.operational);
    this.operational.DefaultState(this.operational.manual).TagTransition(GameTags.Operational, this.unoperational, true);
    this.operational.manual.ParamTransition<bool>((StateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.Parameter<bool>) this.automated, this.operational.automated, GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.IsTrue);
    this.operational.automated.ParamTransition<bool>((StateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.Parameter<bool>) this.automated, this.operational.manual, GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.IsFalse).ToggleChore((Func<FixedCapturePoint.Instance, Chore>) (smi => smi.CreateChore()), this.unoperational, this.unoperational).Update("FindFixedCapturable", (System.Action<FixedCapturePoint.Instance, float>) ((smi, dt) => smi.FindFixedCapturable()), UpdateRate.SIM_1000ms);
  }

  public class Def : StateMachine.BaseDef
  {
    public Func<FixedCapturePoint.Instance, FixedCapturableMonitor.Instance, bool> isAmountStoredOverCapacity;
    public Func<FixedCapturePoint.Instance, int> getTargetCapturePoint = (Func<FixedCapturePoint.Instance, int>) (smi =>
    {
      int cell = Grid.PosToCell((StateMachine.Instance) smi);
      Navigator navigator = smi.targetCapturable.Navigator;
      if (Grid.IsValidCell(cell - 1) && navigator.CanReach(cell - 1))
        return cell - 1;
      return Grid.IsValidCell(cell + 1) && navigator.CanReach(cell + 1) ? cell + 1 : cell;
    });
    public bool allowBabies;
  }

  public class OperationalState : 
    GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.State
  {
    public GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.State manual;
    public GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.State automated;
  }

  [SerializationConfig(MemberSerialization.OptIn)]
  public new class Instance : 
    GameStateMachine<FixedCapturePoint, FixedCapturePoint.Instance, IStateMachineTarget, FixedCapturePoint.Def>.GameInstance
  {
    public BaggableCritterCapacityTracker critterCapactiy;
    private int captureCell;
    private Operational operationComp;
    private LogicPorts logicPorts;

    public FixedCapturableMonitor.Instance targetCapturable { get; private set; }

    public bool shouldCreatureGoGetCaptured { get; private set; }

    public Instance(IStateMachineTarget master, FixedCapturePoint.Def def)
      : base(master, def)
    {
      this.Subscribe(-905833192, new System.Action<object>(this.OnCopySettings));
      this.captureCell = Grid.PosToCell(this.transform.GetPosition());
      this.critterCapactiy = this.GetComponent<BaggableCritterCapacityTracker>();
      this.operationComp = this.GetComponent<Operational>();
      this.logicPorts = this.GetComponent<LogicPorts>();
      if ((UnityEngine.Object) this.logicPorts != (UnityEngine.Object) null)
      {
        this.Subscribe(-801688580, new System.Action<object>(this.OnLogicEvent));
        this.operationComp.SetFlag(FixedCapturePoint.enabledFlag, !this.logicPorts.IsPortConnected((HashedString) "CritterPickUpInput") || this.logicPorts.GetInputValue((HashedString) "CritterPickUpInput") > 0);
      }
      else
        this.operationComp.SetFlag(FixedCapturePoint.enabledFlag, true);
    }

    private void OnLogicEvent(object data)
    {
      LogicValueChanged logicValueChanged = (LogicValueChanged) data;
      if (!(logicValueChanged.portID == (HashedString) "CritterPickUpInput") || !this.logicPorts.IsPortConnected((HashedString) "CritterPickUpInput"))
        return;
      this.operationComp.SetFlag(FixedCapturePoint.enabledFlag, logicValueChanged.newValue > 0);
    }

    public override void StartSM()
    {
      base.StartSM();
      if (!((UnityEngine.Object) this.GetComponent<FixedCapturePoint.AutoWrangleCapture>() == (UnityEngine.Object) null))
        return;
      this.sm.automated.Set(true, this);
    }

    private void OnCopySettings(object data)
    {
      GameObject go = (GameObject) data;
      if ((UnityEngine.Object) go == (UnityEngine.Object) null)
        return;
      FixedCapturePoint.Instance smi = go.GetSMI<FixedCapturePoint.Instance>();
      if (smi == null)
        return;
      this.sm.automated.Set(this.sm.automated.Get(smi), this);
    }

    public bool GetAutomated() => this.sm.automated.Get(this);

    public void SetAutomated(bool automate) => this.sm.automated.Set(automate, this);

    public Chore CreateChore()
    {
      this.FindFixedCapturable();
      return (Chore) new FixedCaptureChore(this.GetComponent<KPrefabID>());
    }

    public bool IsCreatureAvailableForFixedCapture()
    {
      return !this.targetCapturable.IsNullOrStopped() && FixedCapturePoint.Instance.CanCapturableBeCapturedAtCapturePoint(this.targetCapturable, this, Game.Instance.roomProber.GetCavityForCell(this.captureCell), this.captureCell);
    }

    public void SetRancherIsAvailableForCapturing() => this.shouldCreatureGoGetCaptured = true;

    public void ClearRancherIsAvailableForCapturing() => this.shouldCreatureGoGetCaptured = false;

    private static bool CanCapturableBeCapturedAtCapturePoint(
      FixedCapturableMonitor.Instance capturable,
      FixedCapturePoint.Instance capture_point,
      CavityInfo capture_cavity_info,
      int capture_cell)
    {
      if (!capturable.IsRunning() || capturable.targetCapturePoint != capture_point && !capturable.targetCapturePoint.IsNullOrStopped())
        return false;
      CavityInfo cavityForCell = Game.Instance.roomProber.GetCavityForCell(Grid.PosToCell(capturable.transform.GetPosition()));
      return cavityForCell != null && cavityForCell == capture_cavity_info && !capturable.HasTag(GameTags.Creatures.Bagged) && (!capturable.isBaby || capture_point.def.allowBabies) && capturable.ChoreConsumer.IsChoreEqualOrAboveCurrentChorePriority<FixedCaptureStates>() && capturable.Navigator.GetNavigationCost(capture_cell) != -1 && capture_point.def.isAmountStoredOverCapacity(capture_point, capturable);
    }

    public void FindFixedCapturable()
    {
      int cell = Grid.PosToCell(this.transform.GetPosition());
      CavityInfo cavityForCell = Game.Instance.roomProber.GetCavityForCell(cell);
      if (cavityForCell == null)
      {
        this.ResetCapturePoint();
      }
      else
      {
        if (!this.targetCapturable.IsNullOrStopped() && !FixedCapturePoint.Instance.CanCapturableBeCapturedAtCapturePoint(this.targetCapturable, this, cavityForCell, cell))
          this.ResetCapturePoint();
        if (!this.targetCapturable.IsNullOrStopped())
          return;
        foreach (FixedCapturableMonitor.Instance capturableMonitor in Components.FixedCapturableMonitors)
        {
          if (FixedCapturePoint.Instance.CanCapturableBeCapturedAtCapturePoint(capturableMonitor, this, cavityForCell, cell))
          {
            this.targetCapturable = capturableMonitor;
            if (this.targetCapturable.IsNullOrStopped())
              break;
            this.targetCapturable.targetCapturePoint = this;
            break;
          }
        }
      }
    }

    public void ResetCapturePoint()
    {
      this.Trigger(643180843);
      if (this.targetCapturable.IsNullOrStopped())
        return;
      this.targetCapturable.targetCapturePoint = (FixedCapturePoint.Instance) null;
      this.targetCapturable.Trigger(1034952693);
      this.targetCapturable = (FixedCapturableMonitor.Instance) null;
    }
  }

  public class AutoWrangleCapture : KMonoBehaviour, ICheckboxControl
  {
    private FixedCapturePoint.Instance fcp;

    protected override void OnSpawn()
    {
      base.OnSpawn();
      this.fcp = this.GetSMI<FixedCapturePoint.Instance>();
    }

    string ICheckboxControl.CheckboxTitleKey
    {
      get => UI.UISIDESCREENS.CAPTURE_POINT_SIDE_SCREEN.TITLE.key.String;
    }

    string ICheckboxControl.CheckboxLabel
    {
      get => (string) UI.UISIDESCREENS.CAPTURE_POINT_SIDE_SCREEN.AUTOWRANGLE;
    }

    string ICheckboxControl.CheckboxTooltip
    {
      get => (string) UI.UISIDESCREENS.CAPTURE_POINT_SIDE_SCREEN.AUTOWRANGLE_TOOLTIP;
    }

    bool ICheckboxControl.GetCheckboxValue() => this.fcp.GetAutomated();

    void ICheckboxControl.SetCheckboxValue(bool value) => this.fcp.SetAutomated(value);
  }
}
