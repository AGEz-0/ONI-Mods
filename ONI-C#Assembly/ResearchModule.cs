// Decompiled with JetBrains decompiler
// Type: ResearchModule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;
using TUNING;
using UnityEngine;

#nullable disable
[AddComponentMenu("KMonoBehaviour/scripts/ResearchModule")]
public class ResearchModule : KMonoBehaviour
{
  private static readonly EventSystem.IntraObjectHandler<ResearchModule> OnLaunchDelegate = new EventSystem.IntraObjectHandler<ResearchModule>((Action<ResearchModule, object>) ((component, data) => component.OnLaunch(data)));
  private static readonly EventSystem.IntraObjectHandler<ResearchModule> OnLandDelegate = new EventSystem.IntraObjectHandler<ResearchModule>((Action<ResearchModule, object>) ((component, data) => component.OnLand(data)));

  protected override void OnSpawn()
  {
    base.OnSpawn();
    this.GetComponent<KBatchedAnimController>().Play((HashedString) "grounded", KAnim.PlayMode.Loop);
    this.Subscribe<ResearchModule>(-1277991738, ResearchModule.OnLaunchDelegate);
    this.Subscribe<ResearchModule>(-887025858, ResearchModule.OnLandDelegate);
  }

  public void OnLaunch(object data)
  {
  }

  public void OnLand(object data)
  {
    if (!DlcManager.FeatureClusterSpaceEnabled())
    {
      SpaceDestination.ResearchOpportunity researchOpportunity = SpacecraftManager.instance.GetSpacecraftDestination(SpacecraftManager.instance.GetSpacecraftID(this.GetComponent<RocketModule>().conditionManager.GetComponent<ILaunchableRocket>())).TryCompleteResearchOpportunity();
      if (researchOpportunity != null)
      {
        GameObject gameObject = GameUtil.KInstantiate(Assets.GetPrefab((Tag) "ResearchDatabank"), this.gameObject.transform.GetPosition(), Grid.SceneLayer.Ore);
        gameObject.SetActive(true);
        gameObject.GetComponent<PrimaryElement>().Mass = (float) researchOpportunity.dataValue;
        if (!string.IsNullOrEmpty(researchOpportunity.discoveredRareItem))
        {
          GameObject prefab = Assets.GetPrefab((Tag) researchOpportunity.discoveredRareItem);
          if ((UnityEngine.Object) prefab == (UnityEngine.Object) null)
            KCrashReporter.Assert(false, "Missing prefab: " + researchOpportunity.discoveredRareItem);
          else
            GameUtil.KInstantiate(prefab, this.gameObject.transform.GetPosition(), Grid.SceneLayer.Ore).SetActive(true);
        }
      }
    }
    GameObject gameObject1 = GameUtil.KInstantiate(Assets.GetPrefab((Tag) "ResearchDatabank"), this.gameObject.transform.GetPosition(), Grid.SceneLayer.Ore);
    gameObject1.SetActive(true);
    gameObject1.GetComponent<PrimaryElement>().Mass = (float) ROCKETRY.DESTINATION_RESEARCH.EVERGREEN;
  }
}
