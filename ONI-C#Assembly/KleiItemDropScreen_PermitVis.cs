// Decompiled with JetBrains decompiler
// Type: KleiItemDropScreen_PermitVis
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections;
using UnityEngine;

#nullable disable
public class KleiItemDropScreen_PermitVis : KMonoBehaviour
{
  [SerializeField]
  private RectTransform root;
  [Header("Different Permit Visualizers")]
  [SerializeField]
  private KleiItemDropScreen_PermitVis_Fallback fallbackVis;
  [SerializeField]
  private KleiItemDropScreen_PermitVis_DupeEquipment equipmentVis;

  public void ConfigureWith(DropScreenPresentationInfo info)
  {
    this.ResetState();
    this.equipmentVis.gameObject.SetActive(false);
    this.fallbackVis.gameObject.SetActive(false);
    if (info.UseEquipmentVis)
    {
      this.equipmentVis.gameObject.SetActive(true);
      this.equipmentVis.ConfigureWith(info);
    }
    else
    {
      this.fallbackVis.gameObject.SetActive(true);
      this.fallbackVis.ConfigureWith(info);
    }
  }

  public Promise AnimateIn() => Updater.RunRoutine((MonoBehaviour) this, this.AnimateInRoutine());

  public Promise AnimateOut() => Updater.RunRoutine((MonoBehaviour) this, this.AnimateOutRoutine());

  private IEnumerator AnimateInRoutine()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    KleiItemDropScreen_PermitVis dropScreenPermitVis = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    dropScreenPermitVis.root.gameObject.SetActive(true);
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    this.\u003C\u003E2__current = (object) Updater.Ease(new Action<Vector3>(dropScreenPermitVis.\u003CAnimateInRoutine\u003Eb__6_0), dropScreenPermitVis.root.transform.localScale, Vector3.one, 0.5f, Easing.EaseOutBack);
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  private IEnumerator AnimateOutRoutine()
  {
    // ISSUE: reference to a compiler-generated field
    int num = this.\u003C\u003E1__state;
    KleiItemDropScreen_PermitVis dropScreenPermitVis = this;
    if (num != 0)
    {
      if (num != 1)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.\u003C\u003E1__state = -1;
      dropScreenPermitVis.root.gameObject.SetActive(true);
      return false;
    }
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = -1;
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated method
    this.\u003C\u003E2__current = (object) Updater.Ease(new Action<Vector3>(dropScreenPermitVis.\u003CAnimateOutRoutine\u003Eb__7_0), dropScreenPermitVis.root.transform.localScale, Vector3.zero, 0.25f);
    // ISSUE: reference to a compiler-generated field
    this.\u003C\u003E1__state = 1;
    return true;
  }

  public void ResetState() => this.root.transform.localScale = Vector3.zero;
}
