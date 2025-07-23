// Decompiled with JetBrains decompiler
// Type: ConditionHasAtmoSuit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;

#nullable disable
public class ConditionHasAtmoSuit : ProcessCondition
{
  private CommandModule module;

  public ConditionHasAtmoSuit(CommandModule module)
  {
    this.module = module;
    ManualDeliveryKG orAdd = this.module.FindOrAdd<ManualDeliveryKG>();
    orAdd.choreTypeIDHash = Db.Get().ChoreTypes.MachineFetch.IdHash;
    orAdd.SetStorage(module.storage);
    orAdd.RequestedItemTag = GameTags.AtmoSuit;
    orAdd.MinimumMass = 1f;
    orAdd.refillMass = 0.1f;
    orAdd.capacity = 1f;
  }

  public override ProcessCondition.Status EvaluateCondition()
  {
    return (double) this.module.storage.GetAmountAvailable(GameTags.AtmoSuit) < 1.0 ? ProcessCondition.Status.Failure : ProcessCondition.Status.Ready;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.HASSUIT.NAME : (string) UI.STARMAP.NOSUIT.NAME;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return status == ProcessCondition.Status.Ready ? (string) UI.STARMAP.HASSUIT.TOOLTIP : (string) UI.STARMAP.NOSUIT.TOOLTIP;
  }

  public override bool ShowInUI() => true;
}
