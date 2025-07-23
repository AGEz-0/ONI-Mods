// Decompiled with JetBrains decompiler
// Type: LogicControlInputUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/LogicRibbonDisplayUI")]
public class LogicControlInputUI : KMonoBehaviour
{
  [SerializeField]
  private Image icon;
  [SerializeField]
  private Image border;
  [SerializeField]
  private LogicModeUI uiAsset;
  private Color32 colourOn;
  private Color32 colourOff;
  private Color32 colourDisconnected;

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.colourOn = GlobalAssets.Instance.colorSet.logicOn;
    this.colourOff = GlobalAssets.Instance.colorSet.logicOff;
    this.colourOn.a = this.colourOff.a = byte.MaxValue;
    this.colourDisconnected = GlobalAssets.Instance.colorSet.logicDisconnected;
    this.icon.raycastTarget = false;
    this.border.raycastTarget = false;
  }

  public void SetContent(LogicCircuitNetwork network)
  {
    this.icon.color = (Color) (network == null ? GlobalAssets.Instance.colorSet.logicDisconnected : (network.IsBitActive(0) ? this.colourOn : this.colourOff));
  }
}
