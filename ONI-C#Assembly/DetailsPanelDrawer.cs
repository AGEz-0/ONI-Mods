// Decompiled with JetBrains decompiler
// Type: DetailsPanelDrawer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class DetailsPanelDrawer
{
  private List<DetailsPanelDrawer.Label> labels = new List<DetailsPanelDrawer.Label>();
  private int activeLabelCount;
  private UIStringFormatter stringformatter;
  private UIFloatFormatter floatFormatter;
  private GameObject parent;
  private GameObject labelPrefab;

  public DetailsPanelDrawer(GameObject label_prefab, GameObject parent)
  {
    this.parent = parent;
    this.labelPrefab = label_prefab;
    this.stringformatter = new UIStringFormatter();
    this.floatFormatter = new UIFloatFormatter();
  }

  public DetailsPanelDrawer NewLabel(string text)
  {
    DetailsPanelDrawer.Label label = new DetailsPanelDrawer.Label();
    if (this.activeLabelCount >= this.labels.Count)
    {
      label.text = Util.KInstantiate(this.labelPrefab, this.parent).GetComponent<LocText>();
      label.tooltip = label.text.GetComponent<ToolTip>();
      label.text.transform.localScale = new Vector3(1f, 1f, 1f);
      this.labels.Add(label);
    }
    else
      label = this.labels[this.activeLabelCount];
    ++this.activeLabelCount;
    label.text.text = text;
    label.tooltip.toolTip = "";
    label.tooltip.OnToolTip = (Func<string>) null;
    label.text.gameObject.SetActive(true);
    return this;
  }

  public DetailsPanelDrawer BeginDrawing() => this;

  public DetailsPanelDrawer EndDrawing() => this;

  private struct Label
  {
    public LocText text;
    public ToolTip tooltip;
  }
}
