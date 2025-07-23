// Decompiled with JetBrains decompiler
// Type: KleiPermitDioramaVis_AutomationGates
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class KleiPermitDioramaVis_AutomationGates : KMonoBehaviour, IKleiPermitDioramaVisTarget
{
  [SerializeField]
  private Image itemSprite;
  [SerializeField]
  private KBatchedAnimController buildingKAnim;
  private PrefabDefinedUIPosition buildingKAnimPosition = new PrefabDefinedUIPosition();

  public GameObject GetGameObject() => this.gameObject;

  public void ConfigureSetup()
  {
  }

  public void ConfigureWith(PermitResource permit)
  {
    this.itemSprite.gameObject.SetActive(false);
    KleiPermitVisUtil.ConfigureToRenderBuilding(this.buildingKAnim, (BuildingFacadeResource) permit);
    BuildingDef buildingDef = KleiPermitVisUtil.GetBuildingDef(permit);
    Dictionary<int, float> dictionary1 = new Dictionary<int, float>()
    {
      {
        3,
        0.7f
      },
      {
        2,
        0.9f
      },
      {
        1,
        0.85f
      }
    };
    Dictionary<int, float> dictionary2 = new Dictionary<int, float>()
    {
      {
        4,
        32f
      },
      {
        3,
        32f
      },
      {
        2,
        32f
      },
      {
        1,
        96f
      }
    };
    this.buildingKAnimPosition.SetOn((Component) this.buildingKAnim);
    this.buildingKAnim.rectTransform().localScale = Vector3.one * dictionary1[buildingDef.WidthInCells];
    this.buildingKAnim.rectTransform().anchoredPosition += new Vector2(0.0f, dictionary2[buildingDef.HeightInCells]);
    KleiPermitVisUtil.AnimateIn(this.buildingKAnim);
  }
}
