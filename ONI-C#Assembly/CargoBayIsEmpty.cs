// Decompiled with JetBrains decompiler
// Type: CargoBayIsEmpty
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using STRINGS;
using UnityEngine;

#nullable disable
public class CargoBayIsEmpty : ProcessCondition
{
  private CommandModule commandModule;

  public CargoBayIsEmpty(CommandModule module) => this.commandModule = module;

  public override ProcessCondition.Status EvaluateCondition()
  {
    foreach (GameObject gameObject in AttachableBuilding.GetAttachedNetwork(this.commandModule.GetComponent<AttachableBuilding>()))
    {
      CargoBay component = gameObject.GetComponent<CargoBay>();
      if ((Object) component != (Object) null && (double) component.storage.MassStored() != 0.0)
        return ProcessCondition.Status.Failure;
    }
    return ProcessCondition.Status.Ready;
  }

  public override string GetStatusMessage(ProcessCondition.Status status)
  {
    return (string) UI.STARMAP.CARGOEMPTY.NAME;
  }

  public override string GetStatusTooltip(ProcessCondition.Status status)
  {
    return (string) UI.STARMAP.CARGOEMPTY.TOOLTIP;
  }

  public override bool ShowInUI() => true;
}
