﻿// Decompiled with JetBrains decompiler
// Type: OptionSelector
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class OptionSelector : MonoBehaviour
{
  private object id;
  public Action<object, int> OnChangePriority;
  [SerializeField]
  private KImage selectedItem;
  [SerializeField]
  private KImage itemTemplate;

  private void Start()
  {
    this.selectedItem.GetComponent<KButton>().onBtnClick += new Action<KKeyCode>(this.OnClick);
  }

  public void Initialize(object id) => this.id = id;

  private void OnClick(KKeyCode button)
  {
    if (button != KKeyCode.Mouse0)
    {
      if (button != KKeyCode.Mouse1)
        return;
      this.OnChangePriority(this.id, -1);
    }
    else
      this.OnChangePriority(this.id, 1);
  }

  public void ConfigureItem(bool disabled, OptionSelector.DisplayOptionInfo display_info)
  {
    HierarchyReferences component = this.selectedItem.GetComponent<HierarchyReferences>();
    KImage reference1 = component.GetReference("BG") as KImage;
    if (display_info.bgOptions == null)
      reference1.gameObject.SetActive(false);
    else
      reference1.sprite = display_info.bgOptions[display_info.bgIndex];
    KImage reference2 = component.GetReference("FG") as KImage;
    if (display_info.fgOptions == null)
      reference2.gameObject.SetActive(false);
    else
      reference2.sprite = display_info.fgOptions[display_info.fgIndex];
    KImage reference3 = component.GetReference("Fill") as KImage;
    if ((UnityEngine.Object) reference3 != (UnityEngine.Object) null)
    {
      reference3.enabled = !disabled;
      reference3.color = (Color) display_info.fillColour;
    }
    KImage reference4 = component.GetReference("Outline") as KImage;
    if (!((UnityEngine.Object) reference4 != (UnityEngine.Object) null))
      return;
    reference4.enabled = !disabled;
  }

  public class DisplayOptionInfo
  {
    public IList<Sprite> bgOptions;
    public IList<Sprite> fgOptions;
    public int bgIndex;
    public int fgIndex;
    public Color32 fillColour;
  }
}
