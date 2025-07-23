// Decompiled with JetBrains decompiler
// Type: EquippableFacadeInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class EquippableFacadeInfo : IBlueprintInfo, IHasDlcRestrictions
{
  public string buildOverride;
  public string defID;
  public string[] requiredDlcIds;
  public string[] forbiddenDlcIds;

  public string id { get; set; }

  public string name { get; set; }

  public string desc { get; set; }

  public PermitRarity rarity { get; set; }

  public string animFile { get; set; }

  public EquippableFacadeInfo(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string defID,
    string buildOverride,
    string animFile,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
  {
    this.id = id;
    this.name = name;
    this.desc = desc;
    this.rarity = rarity;
    this.defID = defID;
    this.buildOverride = buildOverride;
    this.animFile = animFile;
    this.requiredDlcIds = requiredDlcIds;
    this.forbiddenDlcIds = forbiddenDlcIds;
  }

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
}
