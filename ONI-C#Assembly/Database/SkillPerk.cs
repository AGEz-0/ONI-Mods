// Decompiled with JetBrains decompiler
// Type: Database.SkillPerk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3B73C925-1141-43C5-BAD3-1CCBC5FACDF1
// Assembly location: D:\Program Files (x86)\Steam\steamapps\common\OxygenNotIncluded\OxygenNotIncluded_Data\Managed\Assembly-CSharp.dll

using System;

#nullable disable
namespace Database;

public class SkillPerk : Resource, IHasDlcRestrictions
{
  public string[] requiredDlcIds;

  public string[] GetRequiredDlcIds() => this.requiredDlcIds;

  public string[] GetForbiddenDlcIds() => (string[]) null;

  public Action<MinionResume> OnApply { get; protected set; }

  public Action<MinionResume> OnRemove { get; protected set; }

  public Action<MinionResume> OnMinionsChanged { get; protected set; }

  public bool affectAll { get; protected set; }

  public static string GetDescription(string perkID)
  {
    return GameUtil.NamesOfBuildingsRequiringSkillPerk(perkID) ?? Db.Get().SkillPerks.Get(perkID).Name;
  }

  public SkillPerk(
    string id_str,
    string description,
    Action<MinionResume> OnApply,
    Action<MinionResume> OnRemove,
    Action<MinionResume> OnMinionsChanged,
    bool affectAll = false)
    : base(id_str, description)
  {
    this.OnApply = OnApply;
    this.OnRemove = OnRemove;
    this.OnMinionsChanged = OnMinionsChanged;
    this.affectAll = affectAll;
  }

  public SkillPerk(
    string id_str,
    string description,
    Action<MinionResume> OnApply,
    Action<MinionResume> OnRemove,
    Action<MinionResume> OnMinionsChanged,
    string[] requiredDlcIds = null,
    bool affectAll = false)
    : base(id_str, description)
  {
    this.OnApply = OnApply;
    this.OnRemove = OnRemove;
    this.OnMinionsChanged = OnMinionsChanged;
    this.affectAll = affectAll;
    this.requiredDlcIds = requiredDlcIds;
  }
}
