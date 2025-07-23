// Decompiled with JetBrains decompiler
// Type: ResearchTreeTitle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class ResearchTreeTitle : MonoBehaviour
{
  [Header("References")]
  [SerializeField]
  private LocText treeLabel;
  [SerializeField]
  private Image BG;

  public void SetLabel(string txt) => this.treeLabel.text = txt;

  public void SetColor(int id) => this.BG.enabled = id % 2 != 0;
}
