// Decompiled with JetBrains decompiler
// Type: PlanStamp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/PlanStamp")]
public class PlanStamp : KMonoBehaviour
{
  public PlanStamp.StampArt stampSprites;
  [SerializeField]
  private Image StampImage;
  [SerializeField]
  private Text StampText;

  public void SetStamp(Sprite sprite, string Text)
  {
    this.StampImage.sprite = sprite;
    this.StampText.text = Text.ToUpper();
  }

  [Serializable]
  public struct StampArt
  {
    public Sprite UnderConstruction;
    public Sprite NeedsResearch;
    public Sprite SelectResource;
    public Sprite NeedsRepair;
    public Sprite NeedsPower;
    public Sprite NeedsResource;
    public Sprite NeedsGasPipe;
    public Sprite NeedsLiquidPipe;
  }
}
