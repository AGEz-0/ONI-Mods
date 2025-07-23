// Decompiled with JetBrains decompiler
// Type: KleiPermitDioramaVisScaler
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
[ExecuteAlways]
public class KleiPermitDioramaVisScaler : UIBehaviour
{
  public const float REFERENCE_WIDTH = 1700f;
  public const float REFERENCE_HEIGHT = 800f;
  [SerializeField]
  private RectTransform root;
  [SerializeField]
  private RectTransform scaleTarget;
  [SerializeField]
  private RectTransform slot;

  protected override void OnRectTransformDimensionsChange() => this.Layout();

  public void Layout() => KleiPermitDioramaVisScaler.Layout(this.root, this.scaleTarget, this.slot);

  public static void Layout(RectTransform root, RectTransform scaleTarget, RectTransform slot)
  {
    float num1 = 2.125f;
    AspectRatioFitter orAddComponent = slot.FindOrAddComponent<AspectRatioFitter>();
    orAddComponent.aspectRatio = num1;
    orAddComponent.aspectMode = AspectRatioFitter.AspectMode.WidthControlsHeight;
    float num2 = 1700f;
    double a = (double) Mathf.Max(0.1f, root.rect.width) / (double) num2;
    float num3 = 800f;
    double b = (double) (Mathf.Max(0.1f, root.rect.height) / num3);
    float num4 = Mathf.Max((float) a, (float) b);
    scaleTarget.localScale = Vector3.one * num4;
    scaleTarget.sizeDelta = new Vector2(1700f, 800f);
    scaleTarget.anchorMin = Vector2.one * 0.5f;
    scaleTarget.anchorMax = Vector2.one * 0.5f;
    scaleTarget.pivot = Vector2.one * 0.5f;
    scaleTarget.anchoredPosition = Vector2.zero;
  }
}
