// Decompiled with JetBrains decompiler
// Type: KleiPermitDioramaVis_ArtableSculpture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using UnityEngine;

#nullable disable
public class KleiPermitDioramaVis_ArtableSculpture : KMonoBehaviour, IKleiPermitDioramaVisTarget
{
  [SerializeField]
  private KBatchedAnimController buildingKAnim;

  public GameObject GetGameObject() => this.gameObject;

  public void ConfigureSetup()
  {
    SymbolOverrideControllerUtil.AddToPrefab(this.buildingKAnim.gameObject);
  }

  public void ConfigureWith(PermitResource permit)
  {
    KleiPermitVisUtil.ConfigureToRenderBuilding(this.buildingKAnim, (ArtableStage) permit);
    KleiPermitVisUtil.AnimateIn(this.buildingKAnim);
  }
}
