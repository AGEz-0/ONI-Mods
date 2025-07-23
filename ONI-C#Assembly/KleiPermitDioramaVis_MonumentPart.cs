// Decompiled with JetBrains decompiler
// Type: KleiPermitDioramaVis_MonumentPart
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using UnityEngine;

#nullable disable
public class KleiPermitDioramaVis_MonumentPart : KMonoBehaviour, IKleiPermitDioramaVisTarget
{
  [SerializeField]
  private KBatchedAnimController buildingKAnim;
  private PrefabDefinedUIPosition buildingKAnimPosition = new PrefabDefinedUIPosition();

  public GameObject GetGameObject() => this.gameObject;

  public void ConfigureSetup()
  {
  }

  public void ConfigureWith(PermitResource permit)
  {
    KleiPermitVisUtil.ConfigureToRenderBuilding(this.buildingKAnim, (MonumentPartResource) permit);
    BuildingDef buildingDef = KleiPermitVisUtil.GetBuildingDef(permit);
    this.buildingKAnimPosition.SetOn((Component) this.buildingKAnim);
    this.buildingKAnim.rectTransform().anchoredPosition += new Vector2(0.0f, (float) (buildingDef.HeightInCells * 6) - 176f);
    this.buildingKAnim.rectTransform().localScale = Vector3.one * 0.55f;
    KleiPermitVisUtil.AnimateIn(this.buildingKAnim);
  }
}
