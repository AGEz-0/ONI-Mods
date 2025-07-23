// Decompiled with JetBrains decompiler
// Type: MessStation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/Workable/MessStation")]
public class MessStation : Workable, IGameObjectEffectDescriptor
{
  [MyCmpGet]
  private Ownable ownable;
  private MessStation.MessStationSM.Instance smi;

  protected override void OnPrefabInit()
  {
    this.ownable.AddAssignPrecondition(new Func<MinionAssignablesProxy, bool>(this.HasCaloriesOwnablePrecondition));
    base.OnPrefabInit();
    this.overrideAnims = new KAnimFile[1]
    {
      Assets.GetAnim((HashedString) "anim_use_machine_kanim")
    };
  }

  public static bool CanBeAssignedTo(IAssignableIdentity assignee)
  {
    MinionAssignablesProxy assignablesProxy = assignee as MinionAssignablesProxy;
    if ((UnityEngine.Object) assignablesProxy == (UnityEngine.Object) null)
      return false;
    MinionIdentity target = assignablesProxy.target as MinionIdentity;
    if ((UnityEngine.Object) target == (UnityEngine.Object) null)
      return false;
    if (Db.Get().Amounts.Calories.Lookup((Component) target) != null)
      return true;
    return Game.IsDlcActiveForCurrentSave("DLC3_ID") && target.model == BionicMinionConfig.MODEL;
  }

  private bool HasCaloriesOwnablePrecondition(MinionAssignablesProxy worker)
  {
    return MessStation.CanBeAssignedTo((IAssignableIdentity) worker);
  }

  protected override void OnCompleteWork(WorkerBase worker)
  {
    worker.GetWorkable().GetComponent<Edible>().CompleteWork(worker);
  }

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.smi = new MessStation.MessStationSM.Instance(this);
    this.smi.StartSM();
  }

  public override List<Descriptor> GetDescriptors(GameObject go)
  {
    List<Descriptor> descriptors = new List<Descriptor>();
    if (go.GetComponent<Storage>().Has(TableSaltConfig.ID.ToTag()))
      descriptors.Add(new Descriptor(string.Format((string) UI.BUILDINGEFFECTS.MESS_TABLE_SALT, (object) TableSaltTuning.MORALE_MODIFIER), string.Format((string) UI.BUILDINGEFFECTS.TOOLTIPS.MESS_TABLE_SALT, (object) TableSaltTuning.MORALE_MODIFIER)));
    return descriptors;
  }

  public bool HasSalt => this.smi.HasSalt;

  public class MessStationSM : 
    GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation>
  {
    public MessStation.MessStationSM.SaltState salt;
    public GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.State eating;

    public override void InitializeStates(out StateMachine.BaseState default_state)
    {
      default_state = (StateMachine.BaseState) this.salt.none;
      this.salt.none.Transition(this.salt.salty, (StateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.Transition.ConditionCallback) (smi => smi.HasSalt)).PlayAnim("off");
      this.salt.salty.Transition(this.salt.none, (StateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.Transition.ConditionCallback) (smi => !smi.HasSalt)).PlayAnim("salt").EventTransition(GameHashes.EatStart, this.eating);
      this.eating.Transition(this.salt.salty, (StateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.Transition.ConditionCallback) (smi => smi.HasSalt && !smi.IsEating())).Transition(this.salt.none, (StateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.Transition.ConditionCallback) (smi => !smi.HasSalt && !smi.IsEating())).PlayAnim("off");
    }

    public class SaltState : 
      GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.State
    {
      public GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.State none;
      public GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.State salty;
    }

    public new class Instance : 
      GameStateMachine<MessStation.MessStationSM, MessStation.MessStationSM.Instance, MessStation, object>.GameInstance
    {
      private Storage saltStorage;
      private Assignable assigned;

      public Instance(MessStation master)
        : base(master)
      {
        this.saltStorage = master.GetComponent<Storage>();
        this.assigned = master.GetComponent<Assignable>();
      }

      public bool HasSalt => this.saltStorage.Has(TableSaltConfig.ID.ToTag());

      public bool IsEating()
      {
        if ((UnityEngine.Object) this.assigned == (UnityEngine.Object) null || this.assigned.assignee == null)
          return false;
        Ownables soleOwner = this.assigned.assignee.GetSoleOwner();
        if ((UnityEngine.Object) soleOwner == (UnityEngine.Object) null)
          return false;
        GameObject targetGameObject = soleOwner.GetComponent<MinionAssignablesProxy>().GetTargetGameObject();
        if ((UnityEngine.Object) targetGameObject == (UnityEngine.Object) null)
          return false;
        ChoreDriver component = targetGameObject.GetComponent<ChoreDriver>();
        if ((UnityEngine.Object) component == (UnityEngine.Object) null || !component.HasChore())
          return false;
        return component.GetCurrentChore() is ReloadElectrobankChore currentChore ? currentChore.IsInstallingAtMessStation() : component.GetCurrentChore().choreType.urge == Db.Get().Urges.Eat;
      }
    }
  }
}
