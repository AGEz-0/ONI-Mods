// Decompiled with JetBrains decompiler
// Type: SimpleUIShowHide
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/SimpleUIShowHide")]
public class SimpleUIShowHide : KMonoBehaviour
{
  [MyCmpReq]
  private MultiToggle toggle;
  [SerializeField]
  public GameObject content;
  [SerializeField]
  private string saveStatePreferenceKey;
  private const int onState = 0;

  protected override void OnPrefabInit()
  {
    base.OnPrefabInit();
    this.toggle.onClick += new System.Action(this.OnClick);
    if (this.saveStatePreferenceKey.IsNullOrWhiteSpace() || KPlayerPrefs.GetInt(this.saveStatePreferenceKey, 1) == 1 || this.toggle.CurrentState != 0)
      return;
    this.OnClick();
  }

  private void OnClick()
  {
    this.toggle.NextState();
    this.content.SetActive(this.toggle.CurrentState == 0);
    if (this.saveStatePreferenceKey.IsNullOrWhiteSpace())
      return;
    KPlayerPrefs.SetInt(this.saveStatePreferenceKey, this.toggle.CurrentState == 0 ? 1 : 0);
  }
}
