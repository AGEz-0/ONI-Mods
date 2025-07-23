// Decompiled with JetBrains decompiler
// Type: OvercrowdingMonitor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Diagnostics;

#nullable disable
public class OvercrowdingMonitor : 
  GameStateMachine<OvercrowdingMonitor, OvercrowdingMonitor.Instance, IStateMachineTarget, OvercrowdingMonitor.Def>
{
  public const float OVERCROWDED_FERTILITY_DEBUFF = -1f;
  public static Tag[] confinementImmunity = new Tag[2]
  {
    GameTags.Creatures.Burrowed,
    GameTags.Creatures.Digger
  };

  [Conditional("DETAILED_OVERCROWDING_MONITOR_PROFILE")]
  private static void BeginDetailedSample(string regionName)
  {
  }

  [Conditional("DETAILED_OVERCROWDING_MONITOR_PROFILE")]
  private static void EndDetailedSample(string regionName)
  {
  }

  public override void InitializeStates(out StateMachine.BaseState default_state)
  {
    default_state = (StateMachine.BaseState) this.root;
    this.root.Update(new System.Action<OvercrowdingMonitor.Instance, float>(OvercrowdingMonitor.UpdateState), UpdateRate.SIM_1000ms, true);
  }

  private static bool IsConfined(OvercrowdingMonitor.Instance smi)
  {
    if (smi.kpid.HasAnyTags(OvercrowdingMonitor.confinementImmunity))
      return false;
    if (smi.isFish)
    {
      int cell = Grid.PosToCell((StateMachine.Instance) smi);
      if (Grid.IsValidCell(cell) && !Grid.IsLiquid(cell) || smi.fishOvercrowdingMonitor.cellCount < smi.def.spaceRequiredPerCreature)
        return true;
    }
    else if (smi.cavity == null || smi.cavity.numCells < smi.def.spaceRequiredPerCreature)
      return true;
    return false;
  }

  private static bool IsFutureOvercrowded(OvercrowdingMonitor.Instance smi)
  {
    if (smi.cavity == null)
      return false;
    int num = smi.cavity.creatures.Count + smi.cavity.eggs.Count;
    return num != 0 && smi.cavity.eggs.Count != 0 && smi.cavity.numCells / num < smi.def.spaceRequiredPerCreature;
  }

  private static int CalculateOvercrowdedModifer(OvercrowdingMonitor.Instance smi)
  {
    if (smi.fishOvercrowdingMonitor != null)
    {
      int fishCount = smi.fishOvercrowdingMonitor.fishCount;
      if (fishCount <= 0)
        return 0;
      int num = smi.fishOvercrowdingMonitor.cellCount / smi.def.spaceRequiredPerCreature;
      return num < smi.fishOvercrowdingMonitor.fishCount ? -(fishCount - num) : 0;
    }
    if (smi.cavity == null || smi.cavity.creatures.Count <= 1)
      return 0;
    int num1 = smi.cavity.numCells / smi.def.spaceRequiredPerCreature;
    return num1 < smi.cavity.creatures.Count ? -(smi.cavity.creatures.Count - num1) : 0;
  }

  private static bool IsOvercrowded(OvercrowdingMonitor.Instance smi)
  {
    if (smi.def.spaceRequiredPerCreature == 0)
      return false;
    if (smi.fishOvercrowdingMonitor != null)
    {
      int fishCount = smi.fishOvercrowdingMonitor.fishCount;
      if (fishCount > 0)
        return smi.fishOvercrowdingMonitor.cellCount / fishCount < smi.def.spaceRequiredPerCreature;
      int cell = Grid.PosToCell((StateMachine.Instance) smi);
      return Grid.IsValidCell(cell) && !Grid.IsLiquid(cell);
    }
    return smi.cavity != null && smi.cavity.creatures.Count > 1 && smi.cavity.numCells / smi.cavity.creatures.Count < smi.def.spaceRequiredPerCreature;
  }

  private static void UpdateState(OvercrowdingMonitor.Instance smi, float dt)
  {
    bool flag1 = smi.kpid.HasTag(GameTags.Creatures.Confined);
    bool flag2 = smi.kpid.HasTag(GameTags.Creatures.Expecting);
    bool flag3 = smi.kpid.HasTag(GameTags.Creatures.Overcrowded);
    OvercrowdingMonitor.UpdateCavity(smi, dt);
    if (smi.def.spaceRequiredPerCreature == 0)
      return;
    bool set1 = OvercrowdingMonitor.IsConfined(smi);
    bool set2 = OvercrowdingMonitor.IsOvercrowded(smi);
    if (set2)
    {
      if (!smi.isFish)
        smi.overcrowdedModifier.SetValue((float) OvercrowdingMonitor.CalculateOvercrowdedModifer(smi));
      else
        smi.fishOvercrowdedModifier.SetValue((float) OvercrowdingMonitor.CalculateOvercrowdedModifer(smi));
    }
    bool set3 = !smi.isBaby && OvercrowdingMonitor.IsFutureOvercrowded(smi);
    if (flag1 == set1 && flag2 == set3 && flag3 == set2)
      return;
    KPrefabID kpid = smi.kpid;
    Effect effect = smi.isFish ? smi.fishOvercrowdedEffect : smi.overcrowdedEffect;
    kpid.SetTag(GameTags.Creatures.Confined, set1);
    kpid.SetTag(GameTags.Creatures.Overcrowded, set2);
    kpid.SetTag(GameTags.Creatures.Expecting, set3);
    OvercrowdingMonitor.SetEffect(smi, smi.stuckEffect, set1);
    OvercrowdingMonitor.SetEffect(smi, effect, !set1 & set2);
    OvercrowdingMonitor.SetEffect(smi, smi.futureOvercrowdedEffect, !set1 & set3);
  }

  private static void SetEffect(OvercrowdingMonitor.Instance smi, Effect effect, bool set)
  {
    if (set)
      smi.effects.Add(effect, false);
    else
      smi.effects.Remove(effect);
  }

  private static void UpdateCavity(OvercrowdingMonitor.Instance smi, float dt)
  {
    CavityInfo cavityForCell = Game.Instance.roomProber.GetCavityForCell(Grid.PosToCell((StateMachine.Instance) smi));
    if (cavityForCell == smi.cavity)
      return;
    if (smi.cavity != null)
    {
      if (smi.kpid.HasTag(GameTags.Egg))
        smi.cavity.RemoveFromCavity(smi.kpid, smi.cavity.eggs);
      else
        smi.cavity.RemoveFromCavity(smi.kpid, smi.cavity.creatures);
      Game.Instance.roomProber.UpdateRoom(cavityForCell);
    }
    smi.cavity = cavityForCell;
    if (smi.cavity == null)
      return;
    if (smi.kpid.HasTag(GameTags.Egg))
      smi.cavity.eggs.Add(smi.kpid);
    else
      smi.cavity.creatures.Add(smi.kpid);
    Game.Instance.roomProber.UpdateRoom(smi.cavity);
  }

  public class Def : StateMachine.BaseDef
  {
    public int spaceRequiredPerCreature;
  }

  public new class Instance : 
    GameStateMachine<OvercrowdingMonitor, OvercrowdingMonitor.Instance, IStateMachineTarget, OvercrowdingMonitor.Def>.GameInstance
  {
    public CavityInfo cavity;
    public bool isBaby;
    public bool isFish;
    public Effect futureOvercrowdedEffect;
    public Effect overcrowdedEffect;
    public AttributeModifier overcrowdedModifier;
    public Effect fishOvercrowdedEffect;
    public AttributeModifier fishOvercrowdedModifier;
    public Effect stuckEffect;
    [MyCmpReq]
    public KPrefabID kpid;
    [MyCmpReq]
    public Effects effects;
    [MySmiGet]
    public FishOvercrowdingMonitor.Instance fishOvercrowdingMonitor;

    public Instance(IStateMachineTarget master, OvercrowdingMonitor.Def def)
      : base(master, def)
    {
      this.isBaby = master.gameObject.GetDef<BabyMonitor.Def>() != null;
      this.isFish = master.gameObject.GetDef<FishOvercrowdingMonitor.Def>() != null;
      this.futureOvercrowdedEffect = new Effect("FutureOvercrowded", (string) CREATURES.MODIFIERS.FUTURE_OVERCROWDED.NAME, (string) CREATURES.MODIFIERS.FUTURE_OVERCROWDED.TOOLTIP, 0.0f, true, false, true);
      this.futureOvercrowdedEffect.Add(new AttributeModifier(Db.Get().Amounts.Fertility.deltaAttribute.Id, -1f, (string) CREATURES.MODIFIERS.FUTURE_OVERCROWDED.NAME, true));
      this.overcrowdedEffect = new Effect("Overcrowded", (string) CREATURES.MODIFIERS.OVERCROWDED.NAME, (string) CREATURES.MODIFIERS.OVERCROWDED.TOOLTIP, 0.0f, true, false, true);
      this.overcrowdedModifier = new AttributeModifier(Db.Get().CritterAttributes.Happiness.Id, 0.0f, (string) CREATURES.MODIFIERS.OVERCROWDED.NAME, is_readonly: false);
      this.overcrowdedEffect.Add(this.overcrowdedModifier);
      this.fishOvercrowdedEffect = new Effect("Overcrowded", (string) CREATURES.MODIFIERS.OVERCROWDED.NAME, (string) CREATURES.MODIFIERS.OVERCROWDED.FISHTOOLTIP, 0.0f, true, false, true);
      this.fishOvercrowdedModifier = new AttributeModifier(Db.Get().CritterAttributes.Happiness.Id, -5f, (string) CREATURES.MODIFIERS.OVERCROWDED.NAME, is_readonly: false);
      this.fishOvercrowdedEffect.Add(this.fishOvercrowdedModifier);
      this.stuckEffect = new Effect("Confined", (string) CREATURES.MODIFIERS.CONFINED.NAME, (string) CREATURES.MODIFIERS.CONFINED.TOOLTIP, 0.0f, true, false, true);
      this.stuckEffect.Add(new AttributeModifier(Db.Get().CritterAttributes.Happiness.Id, -10f, (string) CREATURES.MODIFIERS.CONFINED.NAME));
      this.stuckEffect.Add(new AttributeModifier(Db.Get().Amounts.Fertility.deltaAttribute.Id, -1f, (string) CREATURES.MODIFIERS.CONFINED.NAME, true));
      OvercrowdingMonitor.UpdateState(this, 0.0f);
    }

    protected override void OnCleanUp()
    {
      if (this.cavity == null)
        return;
      if (this.kpid.HasTag(GameTags.Egg))
        this.cavity.RemoveFromCavity(this.kpid, this.cavity.eggs);
      else
        this.cavity.RemoveFromCavity(this.kpid, this.cavity.creatures);
    }

    public void RoomRefreshUpdateCavity() => OvercrowdingMonitor.UpdateState(this, 0.0f);
  }
}
