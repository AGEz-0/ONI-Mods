// Decompiled with JetBrains decompiler
// Type: Database.BuildingFacades
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;

#nullable disable
namespace Database;

public class BuildingFacades : ResourceSet<BuildingFacadeResource>
{
  public BuildingFacades(ResourceSet parent)
    : base(nameof (BuildingFacades), parent)
  {
    this.Initialize();
    foreach (BuildingFacadeInfo buildingFacade in Blueprints.Get().all.buildingFacades)
      this.Add(buildingFacade.id, (LocString) buildingFacade.name, (LocString) buildingFacade.desc, buildingFacade.rarity, buildingFacade.prefabId, buildingFacade.animFile, buildingFacade.workables, buildingFacade.GetRequiredDlcIds(), buildingFacade.GetForbiddenDlcIds());
  }

  public void Add(
    string id,
    LocString Name,
    LocString Desc,
    PermitRarity rarity,
    string prefabId,
    string animFile,
    Dictionary<string, string> workables = null,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
  {
    this.resources.Add(new BuildingFacadeResource(id, (string) Name, (string) Desc, rarity, prefabId, animFile, workables, requiredDlcIds, forbiddenDlcIds));
  }

  public void PostProcess()
  {
    foreach (BuildingFacadeResource resource in this.resources)
      resource.Init();
  }
}
