﻿// Decompiled with JetBrains decompiler
// Type: BalloonArtistFacadeInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using Database;

#nullable disable
public class BalloonArtistFacadeInfo : IBlueprintInfo, IHasDlcRestrictions
{
  public BalloonArtistFacadeType balloonFacadeType;
  public string[] requiredDlcIds;
  public string[] forbiddenDlcIds;

  public string id { get; set; }

  public string name { get; set; }

  public string desc { get; set; }

  public PermitRarity rarity { get; set; }

  public string animFile { get; set; }

  public BalloonArtistFacadeInfo(
    string id,
    string name,
    string desc,
    PermitRarity rarity,
    string animFile,
    BalloonArtistFacadeType balloonFacadeType,
    string[] requiredDlcIds = null,
    string[] forbiddenDlcIds = null)
  {
    this.id = id;
    this.name = name;
    this.desc = desc;
    this.rarity = rarity;
    this.animFile = animFile;
    this.balloonFacadeType = balloonFacadeType;
    this.requiredDlcIds = requiredDlcIds;
    this.forbiddenDlcIds = forbiddenDlcIds;
  }

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => this.forbiddenDlcIds;
}
