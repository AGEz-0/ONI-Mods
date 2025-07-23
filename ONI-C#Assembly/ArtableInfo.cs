// Decompiled with JetBrains decompiler
// Type: ArtableInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class ArtableInfo : IBlueprintInfo, IHasDlcRestrictions
{
  public string anim;
  public int decor_value;
  public bool cheer_on_complete;
  public string status_id;
  public string prefabId;
  public string symbolname;
  public string[] requiredDlcIds;
  public string[] forbiddenDlcIds;

  public string id { get; set; }

  public string name { get; set; }

  public string desc { get; set; }

  public PermitRarity rarity { get; set; }

  public string animFile { get; set; }

  public ArtableInfo(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string animFile,
    string anim,
    int decor_value,
    bool cheer_on_complete,
    string status_id,
    string prefabId,
    string symbolname = "",
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
  {
    this.id = id;
    this.name = name;
    this.desc = desc;
    this.rarity = rarity;
    this.animFile = animFile;
    this.anim = anim;
    this.decor_value = decor_value;
    this.cheer_on_complete = cheer_on_complete;
    this.status_id = status_id;
    this.prefabId = prefabId;
    this.symbolname = symbolname;
    this.requiredDlcIds = requiredDlcIds;
    this.forbiddenDlcIds = forbiddenDlcIds;
  }

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
}
