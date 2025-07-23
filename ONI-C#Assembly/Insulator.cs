// Decompiled with JetBrains decompiler
// Type: Insulator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[SkipSaveFileSerialization]
[AddComponentMenu("KMonoBehaviour/scripts/Insulator")]
public class Insulator : KMonoBehaviour
{
  [MyCmpReq]
  private Building building;
  [SerializeField]
  public CellOffset offset = CellOffset.none;

  protected override void OnSpawn()
  {
    SimMessages.SetInsulation(Grid.OffsetCell(Grid.PosToCell(this.transform.GetPosition()), this.offset), this.building.Def.ThermalConductivity);
  }

  protected override void OnCleanUp()
  {
    SimMessages.SetInsulation(Grid.OffsetCell(Grid.PosToCell(this.transform.GetPosition()), this.offset), 1f);
  }
}
