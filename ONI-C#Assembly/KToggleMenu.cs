﻿// Decompiled with JetBrains decompiler
// Type: KToggleMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class KToggleMenu : KScreen
{
  [SerializeField]
  private Transform toggleParent;
  [SerializeField]
  private KToggle prefab;
  [SerializeField]
  private ToggleGroup group;
  protected IList<KToggleMenu.ToggleInfo> toggleInfo;
  protected List<KToggle> toggles = new List<KToggle>();
  private static int selected = -1;

  public event KToggleMenu.OnSelect onSelect;

  public void Setup(IList<KToggleMenu.ToggleInfo> toggleInfo)
  {
    this.toggleInfo = toggleInfo;
    this.RefreshButtons();
  }

  protected void Setup() => this.RefreshButtons();

  private void RefreshButtons()
  {
    foreach (KToggle toggle in this.toggles)
    {
      if ((UnityEngine.Object) toggle != (UnityEngine.Object) null)
        UnityEngine.Object.Destroy((UnityEngine.Object) toggle.gameObject);
    }
    this.toggles.Clear();
    if (this.toggleInfo == null)
      return;
    Transform parent = (UnityEngine.Object) this.toggleParent != (UnityEngine.Object) null ? this.toggleParent : this.transform;
    for (int index = 0; index < this.toggleInfo.Count; ++index)
    {
      int idx = index;
      KToggleMenu.ToggleInfo toggleInfo = this.toggleInfo[index];
      if (toggleInfo == null)
      {
        this.toggles.Add((KToggle) null);
      }
      else
      {
        KToggle ktoggle = UnityEngine.Object.Instantiate<KToggle>(this.prefab, Vector3.zero, Quaternion.identity);
        ktoggle.gameObject.name = "Toggle:" + toggleInfo.text;
        ktoggle.transform.SetParent(parent, false);
        ktoggle.group = this.group;
        ktoggle.onClick += (System.Action) (() => this.OnClick(idx));
        ktoggle.GetComponentsInChildren<Text>(true)[0].text = toggleInfo.text;
        toggleInfo.toggle = ktoggle;
        this.toggles.Add(ktoggle);
      }
    }
  }

  public int GetSelected() => KToggleMenu.selected;

  private void OnClick(int i)
  {
    UISounds.PlaySound(UISounds.Sound.ClickObject);
    if (this.onSelect == null)
      return;
    this.onSelect(this.toggleInfo[i]);
  }

  public override void OnKeyDown(KButtonEvent e)
  {
    if (this.toggles == null)
      return;
    for (int index = 0; index < this.toggleInfo.Count; ++index)
    {
      Action hotKey = this.toggleInfo[index].hotKey;
      if (hotKey != Action.NumActions && e.TryConsume(hotKey))
      {
        this.toggles[index].Click();
        break;
      }
    }
  }

  public delegate void OnSelect(KToggleMenu.ToggleInfo toggleInfo);

  public class ToggleInfo
  {
    public string text;
    public object userData;
    public KToggle toggle;
    public Action hotKey;

    public ToggleInfo(string text, object user_data = null, Action hotKey = Action.NumActions)
    {
      this.text = text;
      this.userData = user_data;
      this.hotKey = hotKey;
    }
  }
}
