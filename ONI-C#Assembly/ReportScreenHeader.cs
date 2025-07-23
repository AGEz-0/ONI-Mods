// Decompiled with JetBrains decompiler
// Type: ReportScreenHeader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ReportScreenHeader")]
public class ReportScreenHeader : KMonoBehaviour
{
  [SerializeField]
  private ReportScreenHeaderRow rowTemplate;
  private ReportScreenHeaderRow mainRow;

  public void SetMainEntry(ReportManager.ReportGroup reportGroup)
  {
    if ((Object) this.mainRow == (Object) null)
      this.mainRow = Util.KInstantiateUI(this.rowTemplate.gameObject, this.gameObject, true).GetComponent<ReportScreenHeaderRow>();
    this.mainRow.SetLine(reportGroup);
  }
}
