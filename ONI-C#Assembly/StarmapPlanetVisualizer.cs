// Decompiled with JetBrains decompiler
// Type: StarmapPlanetVisualizer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/StarmapPlanetVisualizer")]
public class StarmapPlanetVisualizer : KMonoBehaviour
{
  public Image image;
  public LocText label;
  public MultiToggle button;
  public RectTransform selection;
  public GameObject analysisSelection;
  public Image unknownBG;
  public GameObject rocketIconContainer;
}
