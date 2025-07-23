﻿// Decompiled with JetBrains decompiler
// Type: ReportScreenEntry
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ReportScreenEntry")]
public class ReportScreenEntry : KMonoBehaviour
{
  [SerializeField]
  private ReportScreenEntryRow rowTemplate;
  private ReportScreenEntryRow mainRow;
  private List<ReportScreenEntryRow> contextRows = new List<ReportScreenEntryRow>();
  private int currentContextCount;

  public void SetMainEntry(ReportManager.ReportEntry entry, ReportManager.ReportGroup reportGroup)
  {
    if ((UnityEngine.Object) this.mainRow == (UnityEngine.Object) null)
    {
      this.mainRow = Util.KInstantiateUI(this.rowTemplate.gameObject, this.gameObject, true).GetComponent<ReportScreenEntryRow>();
      this.mainRow.toggle.onClick += new System.Action(this.ToggleContext);
      this.mainRow.name.GetComponentInChildren<MultiToggle>().onClick += new System.Action(this.ToggleContext);
      this.mainRow.added.GetComponentInChildren<MultiToggle>().onClick += new System.Action(this.ToggleContext);
      this.mainRow.removed.GetComponentInChildren<MultiToggle>().onClick += new System.Action(this.ToggleContext);
      this.mainRow.net.GetComponentInChildren<MultiToggle>().onClick += new System.Action(this.ToggleContext);
    }
    this.mainRow.SetLine(entry, reportGroup);
    this.currentContextCount = entry.contextEntries.Count;
    for (int index = 0; index < entry.contextEntries.Count; ++index)
    {
      if (index >= this.contextRows.Count)
        this.contextRows.Add(Util.KInstantiateUI(this.rowTemplate.gameObject, this.gameObject).GetComponent<ReportScreenEntryRow>());
      this.contextRows[index].SetLine(entry.contextEntries[index], reportGroup);
    }
    this.UpdateVisibility();
  }

  private void ToggleContext()
  {
    this.mainRow.toggle.NextState();
    this.UpdateVisibility();
  }

  private void UpdateVisibility()
  {
    int index;
    for (index = 0; index < this.currentContextCount; ++index)
      this.contextRows[index].gameObject.SetActive(this.mainRow.toggle.CurrentState == 1);
    for (; index < this.contextRows.Count; ++index)
      this.contextRows[index].gameObject.SetActive(false);
  }
}
