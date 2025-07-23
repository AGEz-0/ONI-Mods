// Decompiled with JetBrains decompiler
// Type: MeterScreen_Sickness
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Klei.AI;
using STRINGS;
using System.Collections.Generic;

#nullable disable
public class MeterScreen_Sickness : MeterScreen_VTD_DuplicantIterator
{
  protected override void InternalRefresh()
  {
    this.Label.text = this.CountSickDupes(this.GetWorldMinionIdentities()).ToString();
  }

  protected override string OnTooltip()
  {
    List<MinionIdentity> minionIdentities = this.GetWorldMinionIdentities();
    int num1 = this.CountSickDupes(minionIdentities);
    this.Tooltip.ClearMultiStringTooltip();
    this.Tooltip.AddMultiStringTooltip(string.Format((string) UI.TOOLTIPS.METERSCREEN_SICK_DUPES, (object) num1.ToString()), this.ToolTipStyle_Header);
    for (int index = 0; index < minionIdentities.Count; ++index)
    {
      MinionIdentity minionIdentity = minionIdentities[index];
      if (!minionIdentity.IsNullOrDestroyed())
      {
        string str1 = minionIdentity.GetComponent<KSelectable>().GetName();
        Sicknesses sicknesses = minionIdentity.GetComponent<MinionModifiers>().sicknesses;
        if (sicknesses.IsInfected())
        {
          string str2 = str1 + " (";
          int num2 = 0;
          foreach (SicknessInstance sicknessInstance in (Modifications<Sickness, SicknessInstance>) sicknesses)
          {
            str2 = str2 + (num2 > 0 ? ", " : "") + sicknessInstance.modifier.Name;
            ++num2;
          }
          str1 = str2 + ")";
        }
        bool selected = index == this.lastSelectedDuplicantIndex;
        this.AddToolTipLine(str1, selected);
      }
    }
    return "";
  }

  private int CountSickDupes(List<MinionIdentity> minions)
  {
    int num = 0;
    foreach (MinionIdentity minion in minions)
    {
      if (!minion.IsNullOrDestroyed() && minion.GetComponent<MinionModifiers>().sicknesses.IsInfected())
        ++num;
    }
    return num;
  }
}
