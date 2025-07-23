// Decompiled with JetBrains decompiler
// Type: BionicWaterDamageMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using System;

#nullable disable
public class BionicWaterDamageMonitor : 
  GameStateMachine<BionicWaterDamageMonitor, BionicWaterDamageMonitor.Instance, IStateMachineTarget, BionicWaterDamageMonitor.Def>
{
  public const string EFFECT_NAME = "BionicWaterStress";
  public GameStateMachine<BionicWaterDamageMonitor, BionicWaterDamageMonitor.Instance, IStateMachineTarget, BionicWaterDamageMonitor.Def>.State safe;
  public GameStateMachine<BionicWaterDamageMonitor, BionicWaterDamageMonitor.Instance, IStateMachineTarget, BionicWaterDamageMonitor.Def>.State suffering;

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    this.serializable = StateMachine.SerializeType.ParamsOnly;
    default_state = (StateMachine.BaseState) this.safe;
    this.safe.Transition(this.suffering, new StateMachine<BionicWaterDamageMonitor, BionicWaterDamageMonitor.Instance, IStateMachineTarget, BionicWaterDamageMonitor.Def>.Transition.ConditionCallback(BionicWaterDamageMonitor.IsSuffering));
    this.suffering.Transition(this.safe, GameStateMachine<BionicWaterDamageMonitor, BionicWaterDamageMonitor.Instance, IStateMachineTarget, BionicWaterDamageMonitor.Def>.Not(new StateMachine<BionicWaterDamageMonitor, BionicWaterDamageMonitor.Instance, IStateMachineTarget, BionicWaterDamageMonitor.Def>.Transition.ConditionCallback(BionicWaterDamageMonitor.IsSuffering))).ToggleEffect("BionicWaterStress").ToggleReactable(new Func<BionicWaterDamageMonitor.Instance, Reactable>(BionicWaterDamageMonitor.ZapReactable));
  }

  private static Reactable ZapReactable(BionicWaterDamageMonitor.Instance smi)
  {
    return smi.GetZapReactable();
  }

  private static bool IsSuffering(BionicWaterDamageMonitor.Instance smi)
  {
    return BionicWaterDamageMonitor.IsFloorWetWithIntolerantSubstance(smi);
  }

  private static bool IsFloorWetWithIntolerantSubstance(BionicWaterDamageMonitor.Instance smi)
  {
    if (smi.master.gameObject.HasTag(GameTags.InTransitTube))
      return false;
    int cell = Grid.PosToCell((StateMachine.Instance) smi);
    return Grid.IsValidCell(cell) && Grid.Element[cell].IsLiquid && !smi.kpid.HasTag(GameTags.HasAirtightSuit) && smi.def.IsElementIntolerable(Grid.Element[cell].id);
  }

  public class Def : StateMachine.BaseDef
  {
    public readonly SimHashes[] IntolerantToElements = new SimHashes[4]
    {
      SimHashes.Water,
      SimHashes.DirtyWater,
      SimHashes.SaltWater,
      SimHashes.Brine
    };
    public static float ZapInterval = 10f;

    public bool IsElementIntolerable(SimHashes element)
    {
      for (int index = 0; index < this.IntolerantToElements.Length; ++index)
      {
        if (this.IntolerantToElements[index] == element)
          return true;
      }
      return false;
    }
  }

  public new class Instance : 
    GameStateMachine<BionicWaterDamageMonitor, BionicWaterDamageMonitor.Instance, IStateMachineTarget, BionicWaterDamageMonitor.Def>.GameInstance
  {
    public Effects effects;
    [MyCmpGet]
    public KPrefabID kpid;

    public bool IsAffectedByWaterDamage => this.effects.HasEffect("BionicWaterStress");

    public Instance(IStateMachineTarget master, BionicWaterDamageMonitor.Def def)
      : base(master, def)
    {
      this.effects = this.GetComponent<Effects>();
    }

    public Reactable GetZapReactable()
    {
      SelfEmoteReactable zapReactable = new SelfEmoteReactable(this.master.gameObject, (HashedString) Db.Get().Emotes.Minion.WaterDamage.Id, Db.Get().ChoreTypes.WaterDamageZap, localCooldown: BionicWaterDamageMonitor.Def.ZapInterval);
      zapReactable.SetEmote(Db.Get().Emotes.Minion.WaterDamage);
      zapReactable.preventChoreInterruption = true;
      return (Reactable) zapReactable;
    }
  }
}
