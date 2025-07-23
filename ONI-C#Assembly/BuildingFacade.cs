// Decompiled with JetBrains decompiler
// Type: BuildingFacade
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;
using KSerialization;
using System;
using System.Collections.Generic;

#nullable disable
[SerializationConfig(MemberSerialization.OptIn)]
public class BuildingFacade : KMonoBehaviour
{
  [Serialize]
  private string currentFacade;
  public KAnimFile[] animFiles;
  public Dictionary<string, KAnimFile[]> interactAnims = new Dictionary<string, KAnimFile[]>();
  private BuildingFacadeAnimateIn animateIn;

  public string CurrentFacade => this.currentFacade;

  public bool IsOriginal => this.currentFacade.IsNullOrWhiteSpace();

  protected override void OnPrefabInit()
  {
  }

  protected override void OnSpawn()
  {
    if (this.IsOriginal)
      return;
    this.ApplyBuildingFacade(Db.GetBuildingFacades().TryGet(this.currentFacade));
  }

  public void ApplyDefaultFacade(bool shouldTryAnimate = false)
  {
    this.currentFacade = "DEFAULT_FACADE";
    this.ClearFacade(shouldTryAnimate);
  }

  public void ApplyBuildingFacade(BuildingFacadeResource facade, bool shouldTryAnimate = false)
  {
    if (facade == null)
    {
      this.ClearFacade();
    }
    else
    {
      this.currentFacade = facade.Id;
      this.ChangeBuilding(new KAnimFile[1]
      {
        Assets.GetAnim((HashedString) facade.AnimFile)
      }, facade.Name, facade.Description, facade.InteractFile, shouldTryAnimate);
    }
  }

  private void ClearFacade(bool shouldTryAnimate = false)
  {
    Building component = this.GetComponent<Building>();
    this.ChangeBuilding(component.Def.AnimFiles, component.Def.Name, component.Def.Desc, shouldTryAnimate: shouldTryAnimate);
  }

  private void ChangeBuilding(
    KAnimFile[] animFiles,
    string displayName,
    string desc,
    Dictionary<string, string> interactAnimsNames = null,
    bool shouldTryAnimate = false)
  {
    this.interactAnims.Clear();
    if (interactAnimsNames != null && interactAnimsNames.Count > 0)
    {
      this.interactAnims = new Dictionary<string, KAnimFile[]>();
      foreach (KeyValuePair<string, string> interactAnimsName in interactAnimsNames)
        this.interactAnims.Add(interactAnimsName.Key, new KAnimFile[1]
        {
          Assets.GetAnim((HashedString) interactAnimsName.Value)
        });
    }
    Building[] components = this.GetComponents<Building>();
    foreach (Building building in components)
    {
      building.SetDescriptionFlavour(desc);
      KBatchedAnimController component = building.GetComponent<KBatchedAnimController>();
      HashedString batchGroupId = component.batchGroupID;
      component.SwapAnims(animFiles);
      foreach (KBatchedAnimController componentsInChild in building.GetComponentsInChildren<KBatchedAnimController>(true))
      {
        if (componentsInChild.batchGroupID == batchGroupId)
          componentsInChild.SwapAnims(animFiles);
      }
      if (!this.animateIn.IsNullOrDestroyed())
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.animateIn);
        this.animateIn = (BuildingFacadeAnimateIn) null;
      }
      if (shouldTryAnimate)
      {
        this.animateIn = BuildingFacadeAnimateIn.MakeFor(component);
        string parameter = "Unlocked";
        float parameterValue = 1f;
        KFMOD.PlayUISoundWithParameter(GlobalAssets.GetSound(KleiInventoryScreen.GetFacadeItemSoundName(Db.Get().Permits.TryGet(this.currentFacade)) + "_Click"), parameter, parameterValue);
      }
    }
    this.GetComponent<KSelectable>().SetName(displayName);
    if (!((UnityEngine.Object) this.GetComponent<AnimTileable>() != (UnityEngine.Object) null) || components.Length == 0)
      return;
    GameScenePartitioner.Instance.TriggerEvent(components[0].GetExtents(), GameScenePartitioner.Instance.objectLayers[1], (object) null);
  }

  public string GetNextFacade()
  {
    BuildingDef def = this.GetComponent<Building>().Def;
    int index = def.AvailableFacades.FindIndex((Predicate<string>) (s => s == this.currentFacade)) + 1;
    if (index >= def.AvailableFacades.Count)
      index = 0;
    return def.AvailableFacades[index];
  }
}
