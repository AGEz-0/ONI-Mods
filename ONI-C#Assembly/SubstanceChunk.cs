// Decompiled with JetBrains decompiler
// Type: SubstanceChunk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using KSerialization;
using STRINGS;
using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
[SerializationConfig(MemberSerialization.OptIn)]
[AddComponentMenu("KMonoBehaviour/scripts/SubstanceChunk")]
public class SubstanceChunk : KMonoBehaviour, ISaveLoadable
{
  private static readonly KAnimHashedString symbolToTint = new KAnimHashedString("substance_tinter");
  private static readonly KAnimHashedString symbolToTint2 = new KAnimHashedString("substance_tinter_cap");

  protected override void OnSpawn()
  {
    base.OnSpawn();
    Color colour = (Color) this.GetComponent<PrimaryElement>().Element.substance.colour with
    {
      a = 1f
    };
    this.GetComponent<KBatchedAnimController>().SetSymbolTint(SubstanceChunk.symbolToTint, colour);
    this.GetComponent<KBatchedAnimController>().SetSymbolTint(SubstanceChunk.symbolToTint2, colour);
  }

  private void OnRefreshUserMenu(object data)
  {
    Game.Instance.userMenu.AddButton(this.gameObject, new KIconButtonMenu.ButtonInfo("action_deconstruct", (string) UI.USERMENUACTIONS.RELEASEELEMENT.NAME, new System.Action(this.OnRelease), tooltipText: (string) UI.USERMENUACTIONS.RELEASEELEMENT.TOOLTIP));
  }

  private void OnRelease()
  {
    int cell = Grid.PosToCell(this.transform.GetPosition());
    PrimaryElement component = this.GetComponent<PrimaryElement>();
    if ((double) component.Mass > 0.0)
      SimMessages.AddRemoveSubstance(cell, component.ElementID, CellEventLogger.Instance.ExhaustSimUpdate, component.Mass, component.Temperature, component.DiseaseIdx, component.DiseaseCount);
    this.gameObject.DeleteObject();
  }
}
